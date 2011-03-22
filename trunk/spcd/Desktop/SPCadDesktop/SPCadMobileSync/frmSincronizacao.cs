using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CommonHelpMobile;
using System.Net;
using SPCadMobileSync.SPCadServices;
using SPCadMobileData.Data;
using System.IO;
using SPCadMobileSync.DataADO.Flow;

namespace SPCadMobileSync
{
    public partial class frmSincronizacao : Form
    {
        private static SPCadServices.SPCadServices syncService = new SPCadServices.SPCadServices();        
        private SPCadMobileSync.SPCadServices.Autenticantion user = new SPCadMobileSync.SPCadServices.Autenticantion();  
        
        public frmSincronizacao()
        {
            InitializeComponent();
        }

        private void uBtnCfgWebService_Click_1(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                using (FrmConfigSinc configWeb = new FrmConfigSinc())
                {
                    this.SuspendLayout();
                    Cursor.Current = Cursors.Default;
                    configWeb.ShowDialog();
                    this.ResumeLayout();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        
        // Inicio do processo de Sincronização
        private void menuItemSincronizar_Click(object sender, EventArgs e)
        {
            //desabilita o esquema de energia do pocket
            DeviceStateSleep.DisableDeviceSleep();

            #region testes de conexão e obtenção de data e hora

            tbxLog.Text = "";
            // Passa credencial para o servidor.
            tbxLog.Text += "Conectando ao Servidor...\r\n";

            ConfigWebService cfgWS = new ConfigWebService();

            try
            {
                //testa se o endereco de webservice esta preenchido.
                if (string.IsNullOrEmpty(cfgWS.WebServiceCurrent))
                {
                    throw new Exception("URL do webservice não configurado.");
                }

                //testa se o endereco de webservice foi preenchido corretamente.
                try
                {
                    syncService.Url = cfgWS.WebServiceCurrent;
                }
                catch (Exception)
                {
                    throw new Exception("A URL do webservice é inválida.");
                }

                //testa se o login foi informado.
                if (string.IsNullOrEmpty(cfgWS.LoginWebService))
                {
                    throw new Exception("Login não informado.");
                }

                //testa se a senha foi informada.
                if (string.IsNullOrEmpty(cfgWS.SenhaWebService))
                {
                    throw new Exception("Senha não informada.");
                }

                syncService.Timeout = int.Parse(cfgWS.TimeOutWebService) * (60 * 1000);
                user.User = cfgWS.LoginWebService;
                user.Password = cfgWS.SenhaWebService;
                user.IdPDA = cfgWS.SerialDevice;
                user.IpPDA = MyDeviceIP.GetMyIP();

                DateTime ddy = syncService.getDateDBServer(user);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha na conexão:\n" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                tbxLog.Text += "Conexão não realizada!";
                return;
            }

            DateTime dd;
            tbxLog.Text += "Sincronizando data...\r\n";

            try
            {
                //Verifica se ocorreu algum erro de conexão.                 
                try
                {
                    dd = syncService.getDateDBServer(user);
                }
                catch (WebException ex)
                {
                    if (ex.Status == WebExceptionStatus.ConnectionClosed)
                    {
                        throw new Exception("Perda de conexão. \nErro:" + ex.Status);
                    }

                    if (ex.Status == System.Net.WebExceptionStatus.ConnectFailure || ex.Status == WebExceptionStatus.ProtocolError)
                    {
                        throw new Exception("Falha ao conectar com webservice, verifique sua conexão com a internet. \nErro:" + ex.Status);
                    }

                    if (ex.Status == System.Net.WebExceptionStatus.ReceiveFailure ||
                       ex.Status == System.Net.WebExceptionStatus.SendFailure ||
                                 ex.Status == System.Net.WebExceptionStatus.Timeout)
                    {
                        throw new Exception("Falha ao enviar ou receber dados do servidor. \nErro:" + ex.Status);
                    }
                    else
                    {
                        throw new Exception("Falha ao conectar com webservice. \nErro: " + ex.Status);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

                // Atualiza o horário do sistema.                
                MobileTools.SystemTimeInfo.UpdateSystemTime(dd);
                tbxLog.Text += "Data sincronizada.\r\n";
                tbxLog.Text += "Iniciando sincronização de dados em: " + string.Format("{0:HH:mm:ss}", DateTime.Now) + "\r\n";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                tbxLog.Text += "Conexão não realizada!";
                return;
            }

            #endregion

            #region sincronização: inicial ou parcial
            //Executa a sincronização dos dados.
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (cbxSincroInicial.Checked)
                {
                    syncUpload();
                    CleanData(cbxSincroInicial.Checked);
                    syncDownload();
                }
                else
                {
                    syncUpload();
                    syncDownload();

                    int funcionario = SingletonFlow.funcionarioFlow.GetFuncionario(user.User).Id;
                    List<SPCadMobileData.Data.Model.Rota> lstRotas = SingletonFlow.rotaFlow.GetRotasQtdCad(funcionario);
                    
                    verificaRotaFinalizada(lstRotas);
                    
                    verificaRotaConcluida(lstRotas);
                }

                tbxLog.Text += "SINCRONIZAÇÃO CONCLUÍDA.\r\n";
                MessageBox.Show("Sincronização concluída", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                DeviceStateSleep.EnableDeviceSleep();
                Cursor.Current = Cursors.Default;
            }

            #endregion

        }              

        #region Fluxo de sincronismo

        /// <summary>
        /// Apaga todos os dados do banco de dados.
        /// </summary>
        /// <param name="inicial"></param>
        public void CleanData(bool inicial)
        {
            if (inicial)
            {
                tbxLog.Text += "Limpando a base de dados...\r\n";

                SingletonFlow.fotoFlow.DeleteAll();
                SingletonFlow.historicoConsumoFlow.DeleteAll();
                SingletonFlow.cadastroFlow.DeleteAll();
                SingletonFlow.rotaFlow.DeleteAll();
                SingletonFlow.distritoFlow.DeleteAll();
                SingletonFlow.fonteAlternativaFlow.DeleteAll();
                SingletonFlow.tipoPadraoFlow.DeleteAll();
                SingletonFlow.localizacaoPadraoFlow.DeleteAll();
                SingletonFlow.tipoComplementoFlow.DeleteAll();
                SingletonFlow.condicaoImovelFlow.DeleteAll();
                SingletonFlow.ramoAtividadeFlow.DeleteAll();
                SingletonFlow.ocorrenciaFlow.DeleteAll();
                SingletonFlow.funcionarioFlow.DeleteAll();

                tbxLog.Text += "Finalizado com sucesso...\r\n";
            }
        }

        /// <summary>
        /// Realiza o Download das tabelas
        /// </summary>
        public void syncDownload()
        {
            //verifica se a sincronização é parcial ou inicial
            if (cbxSincroInicial.Checked)
            {
                syncFuncionarioDownload();
                syncOcorrenciaDownload();
                syncRamoAtividadeDownload();
                syncCondicaoImovelDownload();
                syncTipoComplementoDownload();
                syncLocalizacaoPadraoDownload();
                syncTipoPadraoDownload();
                syncFonteAlternativaDownload();
                syncDistritoDownload();
            }

            syncRotaDownload();

            //recupera rotas liberadas
            SPCadServices.Rota[] rotasLiberadas = syncService.GetListRotaLibQtdCad(user);
            

            try
            {
                tbxLog.Text += "Recebendo tabela de Cadastro...\r\n";

                //Recebe cadastros do sevidor
                foreach (SPCadServices.Rota rotaLib in rotasLiberadas)
                {
                    syncCadastroDownload(rotaLib);
                }

                tbxLog.Text += "Tabela Cadastro sincronizada.\r\n";

                //Recebe historicos de consumo do sevidor
                tbxLog.Text += "Recebendo tabela de Historico Consumo...\r\n";
                
                //alexis teste
                //foreach (SPCadServices.Rota rotaLib in rotasLiberadas)
                //{
                //    syncHistoricoConsumoDownload(rotaLib);
                //}

                //alexis teste
                foreach (SPCadServices.Rota rotaLib in rotasLiberadas)
                {
                    syncHistoricoConsumoDownloadTest(rotaLib);
                }

                tbxLog.Text += "Tabela Historico Consumo sincronizada.\r\n";

                //atualiza o campo situacao carga no servidor
                foreach (SPCadServices.Rota rotaLib in rotasLiberadas)
                {
                    syncService.SetSituacaoCargaRota(rotaLib, user, "3");//o parametro 3 significa "carregado".
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1); ;
            }
        }

        /// <summary>
        /// Realiza o upload das tabelas
        /// </summary>
        public void syncUpload()
        {
            syncCadastroUpload();
            syncFotoUpload();
        }

        //verifica rotas finalizadas no servidor
        private void verificaRotaFinalizada(List<SPCadMobileData.Data.Model.Rota> lstRotas)
        {
            tbxLog.Text += "Verificando se existe rotas finalizadas no servidor...\r\n";

            SPCadMobileSync.SPCadServices.Rota[] rotaWebList = SyncUtil<SPCadMobileData.Data.Model.Rota, SPCadMobileSync.SPCadServices.Rota>.ConvertModelToWSObject(lstRotas);

            SPCadServices.Rota[] rotaWebListFinalizadas = syncService.GetRotasFinalizadas(rotaWebList,user);

            if(rotaWebListFinalizadas.Length == 0)
                tbxLog.Text += "Não foram encontrados rotas finalizadas.\r\n";
                return;

            List<SPCadMobileData.Data.Model.Rota> rotaPDAFinalizadas = SyncUtil<SPCadMobileData.Data.Model.Rota, SPCadMobileSync.SPCadServices.Rota>.ConvertWSObjectToModel(ref rotaWebListFinalizadas);
            tbxLog.Text += "Limpando rotas...\r\n";
            foreach (SPCadMobileData.Data.Model.Rota rota in rotaPDAFinalizadas)
            {
                bool statusCad = SingletonFlow.cadastroFlow.StatusCadRotaFinal(rota);
                //verifica se as fotos da rota estão sincronizadas, caso sim, true.
                bool statusFot = SingletonFlow.fotoFlow.StatusFotoFinal(rota);

                if (statusCad && statusFot)
                {
                    DeleteRota(rota, "finalizado");                    
                }                
            }

            tbxLog.Text += "Finalizado com sucesso...\r\n";

        } 

        //verifica rotas concluídas
        public void verificaRotaConcluida(List<SPCadMobileData.Data.Model.Rota> lstRotas)
        {
            tbxLog.Text += "Verificando e limpando rotas concluídas...\r\n";
            foreach (SPCadMobileData.Data.Model.Rota rota in lstRotas)
            {
                //verifica se a quantidade de cadastros executados ou impedidos é a rota completa, caso sim, true.
                bool statusCad = SingletonFlow.cadastroFlow.StatusExecucaoRota(rota);
                //verifica se as fotos da rota estão sincronizadas, caso sim, true.
                bool statusFot = SingletonFlow.fotoFlow.StatusFotoCadExec(rota);

                if (statusCad && statusFot)
                {
                    DeleteRota(rota, "executado");

                    List<SPCadMobileData.Data.Model.Rota> rotas = new List<SPCadMobileData.Data.Model.Rota>();
                    rotas.Add(rota);

                    SPCadMobileSync.SPCadServices.Rota[] rotaWeb = SyncUtil<SPCadMobileData.Data.Model.Rota, SPCadMobileSync.SPCadServices.Rota>.ConvertModelToWSObject(rotas);

                    syncService.SetSituacaoCargaRota(rotaWeb[0], user, "4");//o parametro 4 significa "descarregado".
                }
            }

            tbxLog.Text += "Finalizado com sucesso.\r\n";
        }

        private void DeleteRota(SPCadMobileData.Data.Model.Rota rota, string tipo)
        {
            SingletonFlow.fotoFlow.DelFotoExecOrFinal(rota, tipo);
            SingletonFlow.historicoConsumoFlow.DelHisConsExecOrFinal(rota);
            SingletonFlow.cadastroFlow.DelCadExecOrFinal(rota);
            SingletonFlow.rotaFlow.DelRotaExecOrFinal(rota);
        }

        #endregion

        #region Métodos de Download

        private void syncFuncionarioDownload()
        {
            try
            {
                //*** Recebe dados do sevidor ***\\
                tbxLog.Text += "Recebendo tabela Funcionários...\r\n";

                SPCadMobileSync.SPCadServices.Funcionario[] modelWeb = syncService.GetListFuncionario(user);

                if (modelWeb == null || modelWeb.Length == 0)
                {
                    tbxLog.Text += "Tabela vazia no servidor.\r\n";
                    return;
                }

                progressBar1.Maximum = modelWeb.Length;

                if (modelWeb.Length != 0)
                {
                    List<SPCadMobileData.Data.Model.Funcionario> modelPDA = SyncUtil<SPCadMobileData.Data.Model.Funcionario, SPCadMobileSync.SPCadServices.Funcionario>.ConvertWSObjectToModel(ref modelWeb);

                    int x = 0;

                    foreach (SPCadMobileData.Data.Model.Funcionario item in modelPDA)
                    {

                        SingletonFlow.funcionarioFlow.InsertOrUpdateSync(item);
                        progressBar1.Value = ++x;
                    }
                }
                tbxLog.Text += "Tabela Funcionários sincronizada.\r\n";
            }
            finally
            {
                progressBar1.Value = 0;
            }
        }

        private void syncOcorrenciaDownload()
        {
            try
            {
                //*** Recebe dados do sevidor ***\\
                tbxLog.Text += "Recebendo tabela Ocorrência...\r\n";

                SPCadMobileSync.SPCadServices.Ocorrencia[] modelWeb = syncService.GetListOcorrencia(user);

                if (modelWeb == null || modelWeb.Length == 0)
                {
                    tbxLog.Text += "Tabela vazia no servidor.\r\n";
                    return;
                }

                progressBar1.Maximum = modelWeb.Length;

                if (modelWeb.Length != 0)
                {
                    List<SPCadMobileData.Data.Model.Ocorrencia> modelPDA = SyncUtil<SPCadMobileData.Data.Model.Ocorrencia, SPCadMobileSync.SPCadServices.Ocorrencia>.ConvertWSObjectToModel(ref modelWeb);

                    int x = 0;

                    foreach (SPCadMobileData.Data.Model.Ocorrencia item in modelPDA)
                    {
                        SingletonFlow.ocorrenciaFlow.InsertOrUpdateSync(item);
                        progressBar1.Value = ++x;
                    }
                }
                tbxLog.Text += "Tabela Funcionários sincronizada.\r\n";
            }
            finally
            {
                progressBar1.Value = 0;
            }
        }

        private void syncRamoAtividadeDownload()
        {
            try
            {
                //*** Recebe dados do sevidor ***\\
                tbxLog.Text += "Recebendo tabela de ramo atividades...\r\n";

                SPCadMobileSync.SPCadServices.RamoAtividade[] modelWeb = syncService.GetListRamoAtividade(user);

                if (modelWeb == null || modelWeb.Length == 0)
                {
                    tbxLog.Text += "Tabela vazia no servidor.\r\n";
                    return;
                }

                progressBar1.Maximum = modelWeb.Length;

                if (modelWeb.Length != 0)
                {
                    List<SPCadMobileData.Data.Model.RamoAtividade> modelPDA = SyncUtil<SPCadMobileData.Data.Model.RamoAtividade, SPCadMobileSync.SPCadServices.RamoAtividade>.ConvertWSObjectToModel(ref modelWeb);

                    int x = 0;

                    foreach (SPCadMobileData.Data.Model.RamoAtividade item in modelPDA)
                    {

                        SingletonFlow.ramoAtividadeFlow.InsertOrUpdateSync(item);
                        progressBar1.Value = ++x;
                    }
                }
                tbxLog.Text += "Tabela Ramo Atividades sincronizada.\r\n";
            }
            finally
            {
                progressBar1.Value = 0;
            }
        }

        private void syncCondicaoImovelDownload()
        {
            try
            {
                //*** Recebe dados do sevidor ***\\
                tbxLog.Text += "Recebendo tabela de Condição Imóvel...\r\n";

                SPCadMobileSync.SPCadServices.CondicaoImovel[] modelWeb = syncService.GetListCondicaoImovel(user);

                if (modelWeb == null || modelWeb.Length == 0)
                {
                    tbxLog.Text += "Tabela vazia no servidor.\r\n";
                    return;
                }

                progressBar1.Maximum = modelWeb.Length;

                if (modelWeb.Length != 0)
                {
                    List<SPCadMobileData.Data.Model.CondicaoImovel> modelPDA = SyncUtil<SPCadMobileData.Data.Model.CondicaoImovel, SPCadMobileSync.SPCadServices.CondicaoImovel>.ConvertWSObjectToModel(ref modelWeb);

                    int x = 0;

                    foreach (SPCadMobileData.Data.Model.CondicaoImovel item in modelPDA)
                    {

                        SingletonFlow.condicaoImovelFlow.InsertOrUpdateSync(item);
                        progressBar1.Value = ++x;
                    }
                }
                tbxLog.Text += "Tabela Condição Imóvel sincronizada.\r\n";
            }
            finally
            {
                progressBar1.Value = 0;
            }
        }

        private void syncTipoComplementoDownload()
        {
            try
            {
                //*** Recebe dados do sevidor ***\\
                tbxLog.Text += "Recebendo tabela de Tipo Complemento...\r\n";

                SPCadMobileSync.SPCadServices.TipoComplemento[] modelWeb = syncService.GetListTipoComplemento(user);

                if (modelWeb == null || modelWeb.Length == 0)
                {
                    tbxLog.Text += "Tabela vazia no servidor.\r\n";
                    return;
                }

                progressBar1.Maximum = modelWeb.Length;

                if (modelWeb.Length != 0)
                {
                    List<SPCadMobileData.Data.Model.TipoComplemento> modelPDA = SyncUtil<SPCadMobileData.Data.Model.TipoComplemento, SPCadMobileSync.SPCadServices.TipoComplemento>.ConvertWSObjectToModel(ref modelWeb);

                    int x = 0;

                    foreach (SPCadMobileData.Data.Model.TipoComplemento item in modelPDA)
                    {

                        SingletonFlow.tipoComplementoFlow.InsertOrUpdateSync(item);
                        progressBar1.Value = ++x;
                    }
                }
                tbxLog.Text += "Tabela Tipo Complemento sincronizada.\r\n";
            }
            finally
            {
                progressBar1.Value = 0;
            }
        }

        private void syncLocalizacaoPadraoDownload()
        {
            try
            {
                //*** Recebe dados do sevidor ***\\
                tbxLog.Text += "Recebendo tabela de Localizacao Padrao...\r\n";

                SPCadMobileSync.SPCadServices.LocalizacaoPadrao[] modelWeb = syncService.GetListLocalizacaoPadrao(user);

                if (modelWeb == null || modelWeb.Length == 0)
                {
                    tbxLog.Text += "Tabela vazia no servidor.\r\n";
                    return;
                }

                progressBar1.Maximum = modelWeb.Length;

                if (modelWeb.Length != 0)
                {
                    List<SPCadMobileData.Data.Model.LocalizacaoPadrao> modelPDA = SyncUtil<SPCadMobileData.Data.Model.LocalizacaoPadrao, SPCadMobileSync.SPCadServices.LocalizacaoPadrao>.ConvertWSObjectToModel(ref modelWeb);

                    int x = 0;

                    foreach (SPCadMobileData.Data.Model.LocalizacaoPadrao item in modelPDA)
                    {

                        SingletonFlow.localizacaoPadraoFlow.InsertOrUpdateSync(item);
                        progressBar1.Value = ++x;
                    }
                }
                tbxLog.Text += "Tabela Localização Padrão sincronizada.\r\n";
            }
            finally
            {
                progressBar1.Value = 0;
            }
        }

        private void syncTipoPadraoDownload()
        {
            try
            {
                //*** Recebe dados do sevidor ***\\
                tbxLog.Text += "Recebendo tabela Tipo Padrão...\r\n";

                SPCadMobileSync.SPCadServices.TipoPadrao[] modelWeb = syncService.GetListTipoPadrao(user);

                if (modelWeb == null || modelWeb.Length == 0)
                {
                    tbxLog.Text += "Tabela vazia no servidor.\r\n";
                    return;
                }

                progressBar1.Maximum = modelWeb.Length;

                if (modelWeb.Length != 0)
                {
                    List<SPCadMobileData.Data.Model.TipoPadrao> modelPDA = SyncUtil<SPCadMobileData.Data.Model.TipoPadrao, SPCadMobileSync.SPCadServices.TipoPadrao>.ConvertWSObjectToModel(ref modelWeb);

                    int x = 0;

                    foreach (SPCadMobileData.Data.Model.TipoPadrao item in modelPDA)
                    {

                        SingletonFlow.tipoPadraoFlow.InsertOrUpdateSync(item);
                        progressBar1.Value = ++x;
                    }
                }
                tbxLog.Text += "Tabela Tipo Padrão sincronizada.\r\n";
            }
            finally
            {
                progressBar1.Value = 0;
            }
        }

        private void syncFonteAlternativaDownload()
        {
            try
            {
                //*** Recebe dados do sevidor ***\\
                tbxLog.Text += "Recebendo tabela Fonte Alternativa...\r\n";

                SPCadMobileSync.SPCadServices.FonteAlternativa[] modelWeb = syncService.GetListFonteAlternativa(user);

                if (modelWeb == null || modelWeb.Length == 0)
                {
                    tbxLog.Text += "Tabela vazia no servidor.\r\n";
                    return;
                }

                progressBar1.Maximum = modelWeb.Length;

                if (modelWeb.Length != 0)
                {
                    List<SPCadMobileData.Data.Model.FonteAlternativa> modelPDA = SyncUtil<SPCadMobileData.Data.Model.FonteAlternativa, SPCadMobileSync.SPCadServices.FonteAlternativa>.ConvertWSObjectToModel(ref modelWeb);

                    int x = 0;

                    foreach (SPCadMobileData.Data.Model.FonteAlternativa item in modelPDA)
                    {

                        SingletonFlow.fonteAlternativaFlow.InsertOrUpdateSync(item);
                        progressBar1.Value = ++x;
                    }
                }
                tbxLog.Text += "Tabela Fonte Alternativa sincronizada.\r\n";
            }
            finally
            {
                progressBar1.Value = 0;
            }
        }

        private void syncDistritoDownload()
        {
            try
            {
                //*** Recebe dados do sevidor ***\\
                tbxLog.Text += "Recebendo tabela Distrito...\r\n";

                SPCadMobileSync.SPCadServices.Distrito[] modelWeb = syncService.GetListDistrito(user);

                if (modelWeb == null || modelWeb.Length == 0)
                {
                    tbxLog.Text += "Tabela vazia no servidor.\r\n";
                    return;
                }

                progressBar1.Maximum = modelWeb.Length;

                if (modelWeb.Length != 0)
                {
                    List<SPCadMobileData.Data.Model.Distrito> modelPDA = SyncUtil<SPCadMobileData.Data.Model.Distrito, SPCadMobileSync.SPCadServices.Distrito>.ConvertWSObjectToModel(ref modelWeb);

                    int x = 0;

                    foreach (SPCadMobileData.Data.Model.Distrito item in modelPDA)
                    {

                        SingletonFlow.distritoFlow.InsertOrUpdateSync(item);
                        progressBar1.Value = ++x;
                    }
                }
                tbxLog.Text += "Tabela Distrito sincronizada.\r\n";
            }
            finally
            {
                progressBar1.Value = 0;
            }
        }

        private void syncRotaDownload()
        {
            try
            {

                user.parcial = !cbxSincroInicial.Checked;

                //*** Recebe dados do sevidor ***\\
                tbxLog.Text += "Recebendo tabela Rota...\r\n";

                SPCadMobileSync.SPCadServices.Rota[] modelWeb = syncService.GetListRotaLiberada(user);

                if (modelWeb == null || modelWeb.Length == 0)
                {
                    tbxLog.Text += "Tabela vazia no servidor.\r\n";
                    return;
                }

                progressBar1.Maximum = modelWeb.Length;

                if (modelWeb.Length != 0)
                {
                    List<SPCadMobileData.Data.Model.Rota> modelPDA = SyncUtil<SPCadMobileData.Data.Model.Rota, SPCadMobileSync.SPCadServices.Rota>.ConvertWSObjectToModel(ref modelWeb);

                    int x = 0;

                    foreach (SPCadMobileData.Data.Model.Rota item in modelPDA)
                    {

                        SingletonFlow.rotaFlow.InsertOrUpdateSync(item);
                        progressBar1.Value = ++x;
                    }
                }
                tbxLog.Text += "Tabela Rota sincronizada.\r\n";
            }
            finally
            {
                progressBar1.Value = 0;
            }
        }

        private void syncCadastroDownload(SPCadServices.Rota rota)
        {
            try
            {
                user.parcial = !cbxSincroInicial.Checked;

                progressBar1.Maximum = rota.QtdCad;

                SPCadMobileSync.SPCadServices.Cadastro[] modelWeb = syncService.GetListCadastro(user, rota);

                if (modelWeb == null || modelWeb.Length == 0)
                {
                    tbxLog.Text += "Tabela vazia no servidor.\r\n";
                    return;
                }

                if (modelWeb.Length != rota.QtdCad)
                {
                    throw new Exception("Quantidade de cadastros diferente da quantidade liberada.");
                }

                if (modelWeb.Length != 0)
                {
                    List<SPCadMobileData.Data.Model.Cadastro> modelPDA = SyncUtil<SPCadMobileData.Data.Model.Cadastro, SPCadMobileSync.SPCadServices.Cadastro>.ConvertWSObjectToModel(ref modelWeb);

                    int x = 0;

                    //recebe os cadastros inseridos no banco. Caso ocorrer algum erro os cadastros desta lista serão removidos do banco.
                    List<SPCadMobileData.Data.Model.Cadastro> cadTemp = new List<SPCadMobileData.Data.Model.Cadastro>();

                    try
                    {
                        foreach (SPCadMobileData.Data.Model.Cadastro item in modelPDA)
                        {
                            SingletonFlow.cadastroFlow.InsertOrUpdateSync(item);
                            cadTemp.Add(item);
                            progressBar1.Value = ++x;
                        }
                    }
                    catch (Exception ex)
                    {
                        tbxLog.Text += "Deletando dados incompletos.\r\n";

                        progressBar1.Maximum = cadTemp.Count;
                        int y = cadTemp.Count;

                        foreach (SPCadMobileData.Data.Model.Cadastro item in cadTemp)
                        {
                            SingletonFlow.cadastroFlow.Delete(item);
                            progressBar1.Value = --y;
                        }

                        tbxLog.Text += "Deleção completa.\r\n";

                        throw new Exception("Falha durante sincronização!\r\nÉ necessário sincronizar novamente.");
                    }
                }
            }
            finally
            {
                progressBar1.Value = 0;
            }
        }

        private void syncHistoricoConsumoDownload(SPCadServices.Rota rota)
        {
            try
            {
                user.parcial = !cbxSincroInicial.Checked;

                SPCadMobileSync.SPCadServices.HistoricoConsumo[] modelWeb = syncService.GetListHistoricoConsumo(user, rota);

                if (modelWeb == null || modelWeb.Length == 0)
                {
                    tbxLog.Text += "Tabela vazia no servidor.\r\n";
                    return;
                }

                // TODO: Voltar esta regra.
                //if (modelWeb.Length != rota.QtdHist)
                //{
                //    throw new Exception("Quantidade de historico consumo diferente da quantidade liberada.");
                //}

                progressBar1.Maximum = modelWeb.Length;

                if (modelWeb.Length != 0)
                {
                    List<SPCadMobileData.Data.Model.HistoricoConsumo> modelPDA = SyncUtil<SPCadMobileData.Data.Model.HistoricoConsumo, SPCadMobileSync.SPCadServices.HistoricoConsumo>.ConvertWSObjectToModel(ref modelWeb);

                    //recebe os cadastros inseridos no banco. Caso ocorrer algum erro os cadastros desta lista serão removidos do banco.
                    List<SPCadMobileData.Data.Model.HistoricoConsumo> histTemp = new List<SPCadMobileData.Data.Model.HistoricoConsumo>();

                    int x = 0;
                    try
                    {
                        foreach (SPCadMobileData.Data.Model.HistoricoConsumo item in modelPDA)
                        {
                            SingletonFlow.historicoConsumoFlow.InsertOrUpdateSync(item);
                            histTemp.Add(item);
                            progressBar1.Value = ++x;
                        }
                    }
                    catch (Exception ex)
                    {
                        tbxLog.Text += "Deletando dados incompletos.\r\n";

                        progressBar1.Maximum = histTemp.Count;
                        int y = histTemp.Count;

                        foreach (SPCadMobileData.Data.Model.HistoricoConsumo item in histTemp)
                        {
                            SingletonFlow.historicoConsumoFlow.Delete(item);
                            progressBar1.Value = --y;
                        }

                        tbxLog.Text += "Deleção completa.\r\n";

                        throw new Exception("Falha durante sincronização!\r\nÉ necessário sincronizar novamente.");
                    }
                }
            }
            finally
            {
                progressBar1.Value = 0;
            }
        }

        //Metodo de teste
        private void syncHistoricoConsumoDownloadTest(SPCadServices.Rota rota)
        {
            try
            {
                user.parcial = !cbxSincroInicial.Checked;
                SPCadMobileSync.SPCadServices.HistoricoConsumo[] modelWeb = syncService.GetListHistoricoConsumo(user, rota);             

                //Lista temporaria caso haja falha na sincronização.
                List<SPCadMobileSync.SPCadServices.HistoricoConsumo> histTemp = new List<SPCadMobileSync.SPCadServices.HistoricoConsumo>();
                
                if (modelWeb == null || modelWeb.Length == 0)
                {
                    tbxLog.Text += "Tabela vazia no servidor.\r\n";
                    return;
                }

                progressBar1.Maximum = modelWeb.Length;

                if (modelWeb.Length != 0)
                {
                    int x = 0;
                    try
                    {
                        foreach (SPCadMobileSync.SPCadServices.HistoricoConsumo item in modelWeb)
                        {
                            HistoricoConsumoFlow.Insert(item);
                            histTemp.Add(item);
                            progressBar1.Value = ++x;
                        }
                    }
                    catch (Exception ex)
                    {
                        tbxLog.Text += "Deletando dados incompletos.\r\n";

                        progressBar1.Maximum = histTemp.Count;
                        int y = histTemp.Count;

                        foreach (SPCadMobileSync.SPCadServices.HistoricoConsumo item in histTemp)
                        {
                            HistoricoConsumoFlow.Delete(item);
                            progressBar1.Value = --y;
                        }

                        tbxLog.Text += "Deleção completa.\r\n";

                        throw new Exception("Falha durante sincronização!\r\nÉ necessário sincronizar novamente.");
                    }
                }
            }
            finally
            {
                progressBar1.Value = 0;
            }
        }

        #endregion Métodos de Download

        #region Métodos de Upload

        private void syncCadastroUpload()
        {
            //*** Envia dados ao servidor***\\
            tbxLog.Text += "Sincronizando tabela de Cadastro...\r\n";
            tbxLog.Text += "Enviando tabela de Cadastro...\r\n";

            //recupera lista de dados não sincronizados.
            List<SPCadMobileData.Data.Model.Cadastro> modelMobileList = SingletonFlow.cadastroFlow.GetListNotSync();

            if (modelMobileList.Count <= 0) return;

            //converte os dados recuperados para o tipo do webservice.
            SPCadMobileSync.SPCadServices.Cadastro[] modelWebList = SyncUtil<SPCadMobileData.Data.Model.Cadastro, SPCadMobileSync.SPCadServices.Cadastro>.ConvertModelToWSObject(modelMobileList);

            //envia lista dedados para webservice e recebe resposta de recebimento.
            SPCadMobileSync.SPCadServices.RespostaWS[] resposta = syncService.SetListCadastro(user, modelWebList);

            //*** Recupera resposta de enviao ao servidor ***\\
            tbxLog.Text += "Recebendo resposta...\r\n";
            List<long> listIdResposta = new List<long>();
            if (resposta != null)
            {
                foreach (SPCadMobileSync.SPCadServices.RespostaWS item in resposta)
                {
                    if (string.IsNullOrEmpty(item.errorMsg))
                    {
                        listIdResposta.Add(item.idRecord);
                    }
                    else
                    {
                        tbxLog.Text += item.errorMsg + "\r\n";
                    }
                }
            }

            //posição corrente da lista
            int x = 0;
            int y = 100; //limite inicial da lista
            do
            {
                List<long> listMenor = new List<long>();

                if (y > listIdResposta.Count)
                {
                    y = listIdResposta.Count;
                }

                for (; x < y; x++)
                {
                    listMenor.Add(listIdResposta[x]);
                }

                SingletonFlow.cadastroFlow.SetListNotSync(listMenor);

                y += 100;

            } while (x < listIdResposta.Count);  
            
            tbxLog.Text += "Tabela de Cadastro recebida.\r\n";
        }

        private void syncFotoUpload()
        {
            FileToByte convertFoto = new FileToByte();
            //*** Envia dados ao servidor***\\
            tbxLog.Text += "Sincronizando tabela fotos...\r\n";
            tbxLog.Text += "Enviando tabela de fotos...\r\n";

            //recupera lista de dados não sincronizados.
            List<SPCadMobileData.Data.Model.Foto> modelMobileList = SingletonFlow.fotoFlow.GetListNotSync();

            if (modelMobileList.Count <= 0) return;

            //converte os dados recuperados para o tipo do webservice.
            SPCadMobileSync.SPCadServices.Foto[] modelWebList = SyncUtil<SPCadMobileData.Data.Model.Foto, SPCadMobileSync.SPCadServices.Foto>.ConvertModelToWSObject(modelMobileList);

            List<SPCadMobileSync.SPCadServices.RespostaWS> resposta = new List<SPCadMobileSync.SPCadServices.RespostaWS>();

            int i = 0;
            foreach (var item in modelWebList)
            {
                byte[] bsFoto;

                if (System.IO.File.Exists(InfoFiles.GetPathFoto() + modelWebList[i].nomFoto))
                {
                    bsFoto = convertFoto.ReadByteArrayFromFile(InfoFiles.GetPathFoto() + modelWebList[i].nomFoto);
                }
                else
                {
                    throw new Exception("A foto " + modelWebList[i].nomFoto + "não foi encontrada");                   
                }

                resposta.Add(syncService.SetListFoto(user, item, bsFoto));
                i++;
            }

            //*** Recupera resposta de enviao ao servidor ***\\
            tbxLog.Text += "Recebendo resposta...\r\n";
            List<string> listIdResposta = new List<string>();
            if (resposta != null)
            {
                foreach (SPCadMobileSync.SPCadServices.RespostaWS item in resposta)
                {
                    if (string.IsNullOrEmpty(item.errorMsg))
                    {
                        listIdResposta.Add(item.aux);
                    }
                    else
                    {
                        tbxLog.Text += item.errorMsg + "\r\n";
                    }
                }
            }

            SingletonFlow.fotoFlow.SetListNotSync(listIdResposta);
            tbxLog.Text += "Fotos recebidas.\r\n";
        }

        #endregion Métodos de Upload

        #region Métodos auxiliares

        private void menuItemSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }//fim metodo sair

        private void uBtnCfgWebService_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                using (FrmConfigSinc confWS = new FrmConfigSinc())
                {
                    this.SuspendLayout();
                    Cursor.Current = Cursors.Default;
                    confWS.ShowDialog();
                    this.ResumeLayout();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void tbxLog_TextChanged(object sender, EventArgs e)
        {
            tbxLog.SelectionStart = tbxLog.Text.Length;
            tbxLog.ScrollToCaret();

        }//fim metodo de configuração de webservice

        #endregion Métodos auxiliares
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SPCadToPDA.Helper;
using SPCadToPDA.SPCadServices;
using System.Data.SqlServerCe;
using System.IO;
using System.Reflection;
using SPCadMobileData.Data.BFL;
using SPCadMobileData.Data.Model;
using CommonHelpMobile;
using SPCadMobileData.Data;

namespace SPCadToPDA
{
    public partial class FrmExportToPDA : Form
    {
        private static SPCadServices.SPCadServices syncService = new SPCadServices.SPCadServices();
        SPCadServices.Autenticantion user = new SPCadServices.Autenticantion();

        //ConnectionBase sql;

        static string msg = string.Empty;
        static int max = 0;

        public delegate void setMax();
        public delegate void EnableComponetes();
        setMax setMaxValue;
        EnableComponetes InvertEnableComp;

        public FrmExportToPDA(User usuario)
        {
            InitializeComponent();

            setMaxValue = SetMax;
            InvertEnableComp = EnableComp;            
            user.IdUser = usuario.IdUsuario;
            user.User = usuario.Login.Trim();
            user.Password = usuario.Senha.Trim();

            lblPesquisador.Text = usuario.Usuario;
        }

        private void SetText(Control target, string value)
        {
            try
            {
                if (target.InvokeRequired)
                {
                    target.Invoke(new EventHandler(delegate { target.Text = value; }));
                }
                else
                {
                    target.Text = value;                    
                }
            }
            catch
            { }
        }

        public void SetMax()
        {
            progressBar1.Maximum = max;
        }

        private void SetText(Control target, int value)
        {
            try
            {
                max = value;

                if (target.InvokeRequired)
                {
                    target.Invoke(setMaxValue);
                }
            }
            catch
            { }
        }

        private void btnGetEndereco_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = string.Empty;
            tbxEnderecoBase.Text = string.Empty;

            folderBrowserDialog.ShowDialog();
            tbxEnderecoBase.Text = folderBrowserDialog.SelectedPath;

        }



        private void btnGerarArq_Click(object sender, EventArgs e)
        {
            try
            {
                streamToFile(tbxEnderecoBase.Text);
                ConnectionGDA.DataBaseConnect(tbxEnderecoBase.Text);

                //sql = new ConnectionBase(tbxEnderecoBase.Text);

                bwProcessExport.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void bwProcessExport_DoWork(object sender, DoWorkEventArgs e)
        {
            Invoke(InvertEnableComp);

            GerarArquivoSDF();
        }

        private void bwProcessExport_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value += e.ProgressPercentage;
        }

        private void bwProcessExport_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Invoke(InvertEnableComp);
            MessageBox.Show("Geração de dados concluído!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
        }

        //toda: começa aqui a parte do pda

        private string streamToFile(string filename)
        {
            try
            {
                Stream ums = Assembly.GetExecutingAssembly().GetManifestResourceStream("SPCadToPDA.BancoPDA.SPCad.sdf");

                int length = 256;
                int bytesRead = 0;
                Byte[] buffer = new Byte[length];

                // write the required bytes
                using (FileStream fs = new FileStream(filename + "\\SPCad.sdf", FileMode.Create))
                {
                    do
                    {
                        bytesRead = ums.Read(buffer, 0, length);
                        fs.Write(buffer, 0, bytesRead);
                    }
                    while (bytesRead == length);
                }

                ums.Dispose();
                return "Ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }




        // Inicio do processo de Sincronização
        private void GerarArquivoSDF()
        {
            //Executa a sincronização dos dados.
            try
            {
                syncDownload();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }
        }

        #region Fluxo de sincronismo



        /// <summary>
        /// Realiza o Download das tabelas
        /// </summary>
        public void syncDownload()
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


            syncRotaDownload();

            ////recupera rotas liberadas
            SPCadServices.Rota[] rotasLiberadas = syncService.GetListRotaLibQtdCad(user);


            try
            {
                SetText(lblDescricao, "Recebendo tabela de Cadastro.");

                //Recebe cadastros do sevidor
                foreach (SPCadServices.Rota rotaLib in rotasLiberadas)
                {
                    syncCadastroDownload(rotaLib);
                }

                SetText(lblDescricao, "Tabela Cadastro sincronizada.");

                //Recebe historicos de consumo do sevidor                
                SetText(lblDescricao, "Recebendo tabela de Historico Consumo.");


                foreach (SPCadServices.Rota rotaLib in rotasLiberadas)
                {
                    syncHistoricoConsumoDownload(rotaLib);
                }

                SetText(lblDescricao, "Tabela Historico Consumo sincronizada.");

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

        //verifica rotas finalizadas no servidor
        //private void verificaRotaFinalizada(List<SPCadMobileData.Data.Model.Rota> lstRotas)
        //{
        //    //lblDescricao.Text += "Verificando se existe rotas finalizadas no servidor...\r\n";

        //    SPCadServices.Rota[] rotaWebList = SyncUtil<SPCadMobileData.Data.Model.Rota, SPCadServices.Rota>.ConvertModelToWSObject(lstRotas);

        //    SPCadServices.Rota[] rotaWebListFinalizadas = syncService.GetRotasFinalizadas(rotaWebList, user);

        //    if (rotaWebListFinalizadas.Length == 0)
        //        //lblDescricao.Text += "Não foram encontrados rotas finalizadas.\r\n";
        //    return;

        //    List<SPCadMobileData.Data.Model.Rota> rotaPDAFinalizadas = SyncUtil<SPCadMobileData.Data.Model.Rota, SPCadServices.Rota>.ConvertWSObjectToModel(ref rotaWebListFinalizadas);
        //    //lblDescricao.Text += "Limpando rotas...\r\n";
        //    foreach (SPCadMobileData.Data.Model.Rota rota in rotaPDAFinalizadas)
        //    {
        //        bool statusCad = SingletonFlow.cadastroFlow.StatusCadRotaFinal(rota);
        //        //verifica se as fotos da rota estão sincronizadas, caso sim, true.
        //        bool statusFot = SingletonFlow.fotoFlow.StatusFotoFinal(rota);

        //        if (statusCad && statusFot)
        //        {
        //            DeleteRota(rota, "finalizado");
        //        }
        //    }

        //    //lblDescricao.Text += "Finalizado com sucesso...\r\n";

        //}

        //verifica rotas concluídas
        //public void verificaRotaConcluida(List<SPCadMobileData.Data.Model.Rota> lstRotas)
        //{
        //    //lblDescricao.Text += "Verificando e limpando rotas concluídas...\r\n";
        //    foreach (SPCadMobileData.Data.Model.Rota rota in lstRotas)
        //    {
        //        //verifica se a quantidade de cadastros executados ou impedidos é a rota completa, caso sim, true.
        //        bool statusCad = SingletonFlow.cadastroFlow.StatusExecucaoRota(rota);
        //        //verifica se as fotos da rota estão sincronizadas, caso sim, true.
        //        bool statusFot = SingletonFlow.fotoFlow.StatusFotoCadExec(rota);

        //        if (statusCad && statusFot)
        //        {
        //            DeleteRota(rota, "executado");

        //            List<SPCadMobileData.Data.Model.Rota> rotas = new List<SPCadMobileData.Data.Model.Rota>();
        //            rotas.Add(rota);

        //            SPCadServices.Rota[] rotaWeb = SyncUtil<SPCadMobileData.Data.Model.Rota, SPCadServices.Rota>.ConvertModelToWSObject(rotas);

        //            syncService.SetSituacaoCargaRota(rotaWeb[0], user, "4");//o parametro 4 significa "descarregado".
        //        }
        //    }

        //    //lblDescricao.Text += "Finalizado com sucesso.\r\n";
        //}

        //private void DeleteRota(SPCadMobileData.Data.Model.Rota rota, string tipo)
        //{
        //    SingletonFlow.fotoFlow.DelFotoExecOrFinal(rota, tipo);
        //    SingletonFlow.historicoConsumoFlow.DelHisConsExecOrFinal(rota);
        //    SingletonFlow.cadastroFlow.DelCadExecOrFinal(rota);
        //    SingletonFlow.rotaFlow.DelRotaExecOrFinal(rota);
        //}

        #endregion

        #region Métodos de Download

        private void syncFuncionarioDownload()
        {
            try
            {
                //*** Recebe dados do sevidor ***\\
                SetText(lblDescricao, "Gerando tabela Funcionários...");

                SPCadServices.Funcionario[] modelWeb = syncService.GetListFuncionario(user);

                if (modelWeb == null || modelWeb.Length == 0)
                {
                    SetText(lblDescricao, "Tabela vazia no servidor.");
                    return;
                }

                SetText(progressBar1, modelWeb.Length);

                if (modelWeb.Length != 0)
                {
                    List<SPCadMobileData.Data.Model.Funcionario> modelPDA = SyncUtil<SPCadMobileData.Data.Model.Funcionario, SPCadServices.Funcionario>.ConvertWSObjectToModel(ref modelWeb);

                    foreach (SPCadMobileData.Data.Model.Funcionario item in modelPDA)
                    {
                        SingletonFlow.funcionarioFlow.InsertOrUpdateSync(item);
                        bwProcessExport.ReportProgress(1);
                    }
                }
                SetText(lblDescricao, "Tabela Funcionários gerada.");
            }
            finally
            {
                SetText(progressBar1, 0);
            }
        }

        private void syncOcorrenciaDownload()
        {
            try
            {
                //*** Recebe dados do sevidor ***\\                
                SetText(lblDescricao, "Recebendo tabela Ocorrência.");

                SPCadServices.Ocorrencia[] modelWeb = syncService.GetListOcorrencia(user);

                if (modelWeb == null || modelWeb.Length == 0)
                {
                    SetText(lblDescricao, "Tabela vazia no servidor.");
                    return;
                }

                SetText(progressBar1, modelWeb.Length);

                if (modelWeb.Length != 0)
                {
                    List<SPCadMobileData.Data.Model.Ocorrencia> modelPDA = SyncUtil<SPCadMobileData.Data.Model.Ocorrencia, SPCadServices.Ocorrencia>.ConvertWSObjectToModel(ref modelWeb);

                    foreach (SPCadMobileData.Data.Model.Ocorrencia item in modelPDA)
                    {
                        SingletonFlow.ocorrenciaFlow.InsertOrUpdateSync(item);
                        bwProcessExport.ReportProgress(1);
                    }
                }
                SetText(lblDescricao, "Tabela Funcionários gerada.");
            }
            finally
            {
                SetText(progressBar1, 0);
            }
        }

        private void syncRamoAtividadeDownload()
        {
            try
            {
                //*** Recebe dados do sevidor ***\\                
                SetText(lblDescricao, "Gerando tabela de ramo atividades.");

                SPCadServices.RamoAtividade[] modelWeb = syncService.GetListRamoAtividade(user);

                if (modelWeb == null || modelWeb.Length == 0)
                {
                    SetText(lblDescricao, "Tabela vazia no servidor.");
                    return;
                }

                SetText(progressBar1, modelWeb.Length);

                if (modelWeb.Length != 0)
                {
                    List<SPCadMobileData.Data.Model.RamoAtividade> modelPDA = SyncUtil<SPCadMobileData.Data.Model.RamoAtividade, SPCadServices.RamoAtividade>.ConvertWSObjectToModel(ref modelWeb);

                    foreach (SPCadMobileData.Data.Model.RamoAtividade item in modelPDA)
                    {
                        SingletonFlow.ramoAtividadeFlow.InsertOrUpdateSync(item);
                        bwProcessExport.ReportProgress(1);
                    }
                }

                SetText(lblDescricao, "Tabela Ramo Atividades gerada.");
            }
            finally
            {
                SetText(progressBar1, 0);
            }
        }

        private void syncCondicaoImovelDownload()
        {
            try
            {
                //*** Recebe dados do sevidor ***\\                
                SetText(lblDescricao, "Recebendo tabela de Condição Imóvel.");

                SPCadServices.CondicaoImovel[] modelWeb = syncService.GetListCondicaoImovel(user);

                if (modelWeb == null || modelWeb.Length == 0)
                {
                    SetText(lblDescricao, "Tabela vazia no servidor.");

                    return;
                }

                SetText(progressBar1, modelWeb.Length);

                if (modelWeb.Length != 0)
                {
                    List<SPCadMobileData.Data.Model.CondicaoImovel> modelPDA = SyncUtil<SPCadMobileData.Data.Model.CondicaoImovel, SPCadServices.CondicaoImovel>.ConvertWSObjectToModel(ref modelWeb);

                    foreach (SPCadMobileData.Data.Model.CondicaoImovel item in modelPDA)
                    {

                        SingletonFlow.condicaoImovelFlow.InsertOrUpdateSync(item);
                        bwProcessExport.ReportProgress(1);
                    }
                }

                SetText(lblDescricao, "Tabela Condição Imóvel sincronizada.");
            }
            finally
            {
                SetText(progressBar1, 0);
            }
        }

        private void syncTipoComplementoDownload()
        {
            try
            {
                //*** Recebe dados do sevidor ***\\                
                SetText(lblDescricao, "Recebendo tabela de Tipo Complemento.");

                SPCadServices.TipoComplemento[] modelWeb = syncService.GetListTipoComplemento(user);

                if (modelWeb == null || modelWeb.Length == 0)
                {
                    SetText(lblDescricao, "Tabela vazia no servidor.");
                    return;
                }

                SetText(progressBar1, modelWeb.Length);

                if (modelWeb.Length != 0)
                {
                    List<SPCadMobileData.Data.Model.TipoComplemento> modelPDA = SyncUtil<SPCadMobileData.Data.Model.TipoComplemento, SPCadServices.TipoComplemento>.ConvertWSObjectToModel(ref modelWeb);

                    foreach (SPCadMobileData.Data.Model.TipoComplemento item in modelPDA)
                    {

                        SingletonFlow.tipoComplementoFlow.InsertOrUpdateSync(item);
                        bwProcessExport.ReportProgress(1);
                    }
                }

                SetText(lblDescricao, "Tabela Tipo Complemento sincronizada.");
            }
            finally
            {
                SetText(progressBar1, 0);
            }
        }

        private void syncLocalizacaoPadraoDownload()
        {
            try
            {
                //*** Recebe dados do sevidor ***\\                
                SetText(lblDescricao, "Recebendo tabela de Localizacao Padrao.");

                SPCadServices.LocalizacaoPadrao[] modelWeb = syncService.GetListLocalizacaoPadrao(user);

                if (modelWeb == null || modelWeb.Length == 0)
                {
                    SetText(lblDescricao, "Tabela vazia no servidor.");
                    return;
                }

                SetText(progressBar1, modelWeb.Length);

                if (modelWeb.Length != 0)
                {
                    List<SPCadMobileData.Data.Model.LocalizacaoPadrao> modelPDA = SyncUtil<SPCadMobileData.Data.Model.LocalizacaoPadrao, SPCadServices.LocalizacaoPadrao>.ConvertWSObjectToModel(ref modelWeb);

                    foreach (SPCadMobileData.Data.Model.LocalizacaoPadrao item in modelPDA)
                    {

                        SingletonFlow.localizacaoPadraoFlow.InsertOrUpdateSync(item);

                        bwProcessExport.ReportProgress(1);
                    }
                }

                SetText(lblDescricao, "Tabela Localização Padrão sincronizada.");
            }
            finally
            {

                SetText(progressBar1, 0);
            }
        }

        private void syncTipoPadraoDownload()
        {
            try
            {
                //*** Recebe dados do sevidor ***\\                
                SetText(lblDescricao, "Recebendo tabela Tipo Padrão.");

                SPCadServices.TipoPadrao[] modelWeb = syncService.GetListTipoPadrao(user);

                if (modelWeb == null || modelWeb.Length == 0)
                {

                    SetText(lblDescricao, "Tabela vazia no servidor.");
                    return;
                }

                SetText(progressBar1, modelWeb.Length);

                if (modelWeb.Length != 0)
                {
                    List<SPCadMobileData.Data.Model.TipoPadrao> modelPDA = SyncUtil<SPCadMobileData.Data.Model.TipoPadrao, SPCadServices.TipoPadrao>.ConvertWSObjectToModel(ref modelWeb);

                    foreach (SPCadMobileData.Data.Model.TipoPadrao item in modelPDA)
                    {

                        SingletonFlow.tipoPadraoFlow.InsertOrUpdateSync(item);
                        bwProcessExport.ReportProgress(1);
                    }
                }

                SetText(lblDescricao, "Tabela Tipo Padrão sincronizada.");
            }
            finally
            {
                SetText(progressBar1, 0);
            }
        }

        private void syncFonteAlternativaDownload()
        {
            try
            {
                //*** Recebe dados do sevidor ***\\                
                SetText(lblDescricao, "Recebendo tabela Fonte Alternativa.");

                SPCadServices.FonteAlternativa[] modelWeb = syncService.GetListFonteAlternativa(user);

                if (modelWeb == null || modelWeb.Length == 0)
                {
                    SetText(lblDescricao, "Tabela vazia no servidor.");
                    return;
                }

                SetText(progressBar1, modelWeb.Length);

                if (modelWeb.Length != 0)
                {
                    List<SPCadMobileData.Data.Model.FonteAlternativa> modelPDA = SyncUtil<SPCadMobileData.Data.Model.FonteAlternativa, SPCadServices.FonteAlternativa>.ConvertWSObjectToModel(ref modelWeb);

                    foreach (SPCadMobileData.Data.Model.FonteAlternativa item in modelPDA)
                    {

                        SingletonFlow.fonteAlternativaFlow.InsertOrUpdateSync(item);
                        bwProcessExport.ReportProgress(1);
                    }
                }

                SetText(lblDescricao, "Tabela Fonte Alternativa sincronizada.");
            }
            finally
            {
                SetText(progressBar1, 0);
            }
        }

        private void syncDistritoDownload()
        {
            try
            {
                //*** Recebe dados do sevidor ***\\

                SetText(lblDescricao, "Recebendo tabela Distrito.");

                SPCadServices.Distrito[] modelWeb = syncService.GetListDistrito(user);

                if (modelWeb == null || modelWeb.Length == 0)
                {
                    SetText(lblDescricao, "Tabela vazia no servidor.");
                    return;
                }

                max = modelWeb.Length;
                SetText(progressBar1, modelWeb.Length);

                if (modelWeb.Length != 0)
                {
                    List<SPCadMobileData.Data.Model.Distrito> modelPDA = SyncUtil<SPCadMobileData.Data.Model.Distrito, SPCadServices.Distrito>.ConvertWSObjectToModel(ref modelWeb);

                    int x = 0;

                    foreach (SPCadMobileData.Data.Model.Distrito item in modelPDA)
                    {
                        SingletonFlow.distritoFlow.InsertOrUpdateSync(item);
                        bwProcessExport.ReportProgress(1);
                    }
                }

                SetText(lblDescricao, "Tabela Distrito sincronizada.");
            }
            finally
            {
                SetText(progressBar1, 0);
            }
        }

        private void syncRotaDownload()
        {
            try
            {
                user.parcial = false;

                //*** Recebe dados do sevidor ***\\                
                SetText(lblDescricao, "Recebendo tabela Rota.");

                SPCadServices.Rota[] modelWeb = syncService.GetListRotaLiberada(user);

                if (modelWeb == null || modelWeb.Length == 0)
                {
                    SetText(lblDescricao, "Tabela vazia no servidor.");
                    return;
                }

                SetText(progressBar1, modelWeb.Length);

                if (modelWeb.Length != 0)
                {
                    List<SPCadMobileData.Data.Model.Rota> modelPDA = SyncUtil<SPCadMobileData.Data.Model.Rota, SPCadServices.Rota>.ConvertWSObjectToModel(ref modelWeb);

                    foreach (SPCadMobileData.Data.Model.Rota item in modelPDA)
                    {
                        SingletonFlow.rotaFlow.InsertOrUpdateSync(item);
                        bwProcessExport.ReportProgress(1);
                    }
                }
                SetText(lblDescricao, "Tabela Rota sincronizada.");
            }
            finally
            {
                SetText(progressBar1, 0);
            }
        }

        private void syncCadastroDownload(SPCadServices.Rota rota)
        {
            try
            {
                user.parcial = false;

                SetText(progressBar1, rota.QtdCad);

                SPCadServices.Cadastro[] modelWeb = syncService.GetListCadastro(user, rota);

                if (modelWeb == null || modelWeb.Length == 0)
                {
                    SetText(lblDescricao, "Tabela vazia no servidor.");
                    return;
                }

                if (modelWeb.Length != rota.QtdCad)
                {
                    throw new Exception("Quantidade de cadastros diferente da quantidade liberada.");
                }

                if (modelWeb.Length != 0)
                {
                    List<SPCadMobileData.Data.Model.Cadastro> modelPDA = SyncUtil<SPCadMobileData.Data.Model.Cadastro, SPCadServices.Cadastro>.ConvertWSObjectToModel(ref modelWeb);



                    //recebe os cadastros inseridos no banco. Caso ocorrer algum erro os cadastros desta lista serão removidos do banco.
                    List<SPCadMobileData.Data.Model.Cadastro> cadTemp = new List<SPCadMobileData.Data.Model.Cadastro>();

                    try
                    {
                        foreach (SPCadMobileData.Data.Model.Cadastro item in modelPDA)
                        {
                            SingletonFlow.cadastroFlow.InsertOrUpdateSync(item);
                            cadTemp.Add(item);
                            bwProcessExport.ReportProgress(1);
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        SetText(lblDescricao, "Deletando dados incompletos.");

                        SetText(progressBar1, cadTemp.Count);
                        int x = cadTemp.Count;
                        foreach (SPCadMobileData.Data.Model.Cadastro item in cadTemp)
                        {
                            SingletonFlow.cadastroFlow.Delete(item);
                            bwProcessExport.ReportProgress(--x);
                        }

                        SetText(lblDescricao, "Deleção completa.");

                        throw new Exception("Falha durante sincronização!\r\nÉ necessário sincronizar novamente.");
                    }
                }
            }
            finally
            {
                SetText(progressBar1, 0);
            }
        }

        private void syncHistoricoConsumoDownload(SPCadServices.Rota rota)
        {
            try
            {
                user.parcial = false;

                SPCadServices.HistoricoConsumo[] modelWeb = syncService.GetListHistoricoConsumo(user, rota);

                if (modelWeb == null || modelWeb.Length == 0)
                {
                    SetText(lblDescricao, "Tabela vazia no servidor.");
                    return;
                }

                // TODO: Voltar esta regra.
                //if (modelWeb.Length != rota.QtdHist)
                //{
                //    throw new Exception("Quantidade de historico consumo diferente da quantidade liberada.");
                //}



                if (modelWeb.Length != 0)
                {
                    List<SPCadMobileData.Data.Model.HistoricoConsumo> modelPDA = SyncUtil<SPCadMobileData.Data.Model.HistoricoConsumo, SPCadServices.HistoricoConsumo>.ConvertWSObjectToModel(ref modelWeb);

                    //recebe os cadastros inseridos no banco. Caso ocorrer algum erro os cadastros desta lista serão removidos do banco.
                    List<SPCadMobileData.Data.Model.HistoricoConsumo> histTemp = new List<SPCadMobileData.Data.Model.HistoricoConsumo>();

                    SetText(progressBar1, modelWeb.Length);

                    try
                    {
                        foreach (SPCadMobileData.Data.Model.HistoricoConsumo item in modelPDA)
                        {
                            SingletonFlow.historicoConsumoFlow.InsertOrUpdateSync(item);
                            histTemp.Add(item);
                            bwProcessExport.ReportProgress(1);
                        }
                    }
                    catch (Exception ex)
                    {
                        SetText(lblDescricao, "Deletando dados incompletos.");

                        SetText(progressBar1, histTemp.Count);
                        int x = histTemp.Count;
                        foreach (SPCadMobileData.Data.Model.HistoricoConsumo item in histTemp)
                        {
                            SingletonFlow.historicoConsumoFlow.Delete(item);
                            bwProcessExport.ReportProgress(--x);
                        }

                        SetText(lblDescricao, "Deleção completa.");

                        throw new Exception("Falha durante sincronização!\r\nÉ necessário sincronizar novamente.");
                    }
                }
            }
            finally
            {
                SetText(progressBar1, 0);
            }
        }

        public void EnableComp()
        {
            bool status = btnGerarArq.Enabled;
            btnGetEndereco.Enabled = !status;
            btnGerarArq.Enabled = !status;
            tbxEnderecoBase.ReadOnly = !status;
        }

        #endregion Métodos de Download

    }
}


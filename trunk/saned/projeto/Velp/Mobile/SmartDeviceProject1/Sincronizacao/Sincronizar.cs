using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DeviceProject.Util;
using DeviceProject.referencia;
using DeviceProject.DATA;
using DeviceProject.Config;
using System.Data.SqlServerCe;
using System.Threading;
using System.Reflection;
using DeviceProject.Sincronizacao;
using DeviceProject.DATA.dataSaned.Model;
using DeviceProject.DATA.dataSaned.Flow;
using System.Diagnostics;

namespace DeviceProject.Sincronizacao
{
    /// <summary>
    ///  Classe de controle da tela de sicronização
    /// </summary>
    partial class Sincronizar : Form
    {
        // Variaveis do contexto
        #region Variaveis

        //campo global define no sincronismo quando a thread está acionando o metodo de envio.
        public static bool statusThread { get; set; }
        public static bool statusThreadExec { get; set; }

        //thread de sincronismo
        Thread syncThread = new Thread(new ThreadStart(VoltaLeituraUpload));

        /// <summary>
        ///  Dados de identificação
        /// </summary>
        public static referencia.Identificacao UserPdaCurrent = new Identificacao();

        /// <summary>
        /// Variavel de inicio da sincronização
        /// </summary>
        private DateTime sicronizacaoIni;

        /// <summary>
        /// Variavel de usuario 
        /// </summary>
        public static int userCurrent = (string.IsNullOrEmpty(ConfiguracaoPDA.CurrentInstance.Username))?0:int.Parse(ConfiguracaoPDA.CurrentInstance.Username);

        /// <summary>
        /// Senha do Usuario
        /// </summary>
        private string senha = ConfiguracaoPDA.CurrentInstance.Password;

        /// <summary>
        /// Objeto de comunicação com web server
        /// </summary>
        public static referencia.Service1 _webService = new referencia.Service1();

        /// <summary>
        /// Identifica a localização do processo
        /// </summary>
        private static string status = null;

        /// <summary>
        /// Objeto da classe distribuicao
        /// </summary>
        private Distribuicao[] distribuicao;

        /// <summary>
        ///  Tempo da thead
        /// </summary>
        private static string autoSyncTime;


        #endregion

        /// <summary>
        /// Metodo construtor da classse
        /// </summary>
        public Sincronizar()
        {
            InitializeComponent();

            // Recarrega as configurações do registro
            ConfiguracaoPDA.RefreshCurrent();
            _webService.Url = DeviceProject.Config.ConfiguracaoPDA.CurrentInstance.WebServiceAddress;
            userCurrent = (string.IsNullOrEmpty(ConfiguracaoPDA.CurrentInstance.Username)) ? 0 : int.Parse(ConfiguracaoPDA.CurrentInstance.Username);
            senha = ConfiguracaoPDA.CurrentInstance.Password;
            UserPdaCurrent.usuario = userCurrent;
            UserPdaCurrent.coletor = ConfiguracaoPDA.GetDeviceID();

            // Verifica se a sincronização e automatica
            if (ConfiguracaoPDA.CurrentInstance.SincronizacaoAuto == "TRUE")
            {
                syncThread.IsBackground = true;
                statusThread = true;
                syncThread.Start();
            }
            else
            {
                statusThread = false;
            }

            
            // Carrega a versão do programa
            string versaoPDA = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            string versao = String.Format("Versão : {0}", versaoPDA);
            ldVersao.Text = versao;
            ldVersao.Refresh();

            // Seta o agente cadastrado
            lusuario.Text = "Agente : " + ConfiguracaoPDA.CurrentInstance.Username;

            // Seta o valor padrão para o check box
            enviarBox.Checked = true;

            // Verifica se o banco de dados existe (caso não existe o cria)
            SQLHelper.VerificaBanco();
        }

        /// <summary>
        ///  Sair do aplicativo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem3_Click(object sender, EventArgs e)
        {
            syncThread.Abort();
            this.Close();
        }

        /// <summary>
        ///  Metodo que redireciona para a rotina especifica
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realizar o sincronismo?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                try
                {
                    if (statusThreadExec)
                    {
                        MessageBox.Show("Favor sincronizar dentro de um minuto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        this.Refresh();
                        return;
                    }

                    statusThread = false;
                    
                    Cursor.Current = Cursors.WaitCursor;

                    this.Refresh();

                    if (ReceberBox.Checked == true && enviarBox.Checked == false)
                    {
                        ReceberDados();
                    }
                    else if (enviarBox.Checked == true && ReceberBox.Checked == false)
                    {
                        EnviarDados();
                    }
                    else
                    {
                        MessageBox.Show("Selecione receber ou enviar os dados.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                finally
                {
                    statusThread = true;
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        /// <summary>
        /// Altera o estado o check Box 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReceberBox_CheckStateChanged(object sender, EventArgs e)
        {
            ultraButton2.Visible = false;
            ultraButton3.Visible = true;
        }

        /// <summary>
        /// Altera o estado o check Box 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void enviarBox_CheckStateChanged(object sender, EventArgs e)
        {
            ultraButton3.Visible = false;
            ultraButton2.Visible = true;
        }

        /// <summary>
        /// Metodo responsavel por receber os dados do web server
        /// </summary>
        public void ReceberDados()
        {
            // Identifica o tempo inicial da sicronização
            sicronizacaoIni = DateTime.Now;

            #region Ini try
            try
            {
                // Limpa o ListBox
                label1.Items.Clear();

                // Seta o progresso do ListBox
                setMensagem(1, "Iniciando.....");

                // Seta o progresso do ListBox
                setMensagem(2, "Validando.....");

                //Verifica se a versão e valida
                if (!ValidaVersao())
                    Application.Exit();

                // Se todas as validações forem corretas
                if (ValidacaoCorretaReceber())
                {

                    // Seta o progresso do ListBox
                    setMensagem(3, "Limpeza.....");

                    // Metodo da sincronização (limpa o banco de dados)
                    Receber sincronizar = new Receber();
                    DateTime dataInicial = DateTime.Now;

                    // Seta o progresso do ListBox
                    setMensagem(4, "Carregado dados...");

                    // Seta o progresso do ListBox
                    setMensagem(5, "Categoria...");

                    dataInicial = DateTime.Now;
                    sincronizar.Categoria();
                    setMensagem(1, "Tempo de :" + ExtensionMethods.GetTime(dataInicial));

                    // Seta o progresso do ListBox
                    setMensagem(1, "Tipo Entrega...");

                    dataInicial = DateTime.Now;
                    sincronizar.TipoEntrega();
                    setMensagem(2, "Tempo de :" + ExtensionMethods.GetTime(dataInicial));

                    // Seta o progresso do ListBox
                    setMensagem(2, "Desconto Diadema...");

                    dataInicial = DateTime.Now;
                    sincronizar.DescontoDiadema();
                    setMensagem(3, "Tempo de :" + ExtensionMethods.GetTime(dataInicial));

                    // Seta o progresso do ListBox
                    setMensagem(3, "Imposto Diadema...");

                    dataInicial = DateTime.Now;
                    sincronizar.ImpostoDiadema();
                    setMensagem(4, "Tempo de :" + ExtensionMethods.GetTime(dataInicial));

                    // Seta o progresso do ListBox
                    setMensagem(4, "Localização Hidrometro...");

                    dataInicial = DateTime.Now;
                    sincronizar.LocalizacaoHidrometro();
                    setMensagem(5, "Tempo de :" + ExtensionMethods.GetTime(dataInicial));

                    // Seta o progresso do ListBox
                    setMensagem(5, "Ocorrencia...");

                    dataInicial = DateTime.Now;
                    sincronizar.Ocorrencia();
                    setMensagem(5, "Tempo de :" + ExtensionMethods.GetTime(dataInicial));

                    // Seta o progresso do ListBox
                    setMensagem(6, "Parametro...");

                    dataInicial = DateTime.Now;
                    sincronizar.Parametro();
                    setMensagem(6, "Tempo de :" + ExtensionMethods.GetTime(dataInicial));

                    // Seta o progresso do ListBox
                    setMensagem(7, "Parametro Retenção...");

                    dataInicial = DateTime.Now;
                    sincronizar.ParametroRetencao();
                    setMensagem(7, "Tempo de :" + ExtensionMethods.GetTime(dataInicial));

                    // Seta o progresso do ListBox
                    setMensagem(8, "Taxa...");

                    dataInicial = DateTime.Now;
                    sincronizar.Taxa();
                    setMensagem(8, "Tempo de :" + ExtensionMethods.GetTime(dataInicial));

                    // Seta o progresso do ListBox
                    setMensagem(9, "Agente...");

                    dataInicial = DateTime.Now;
                    sincronizar.Agente();
                    setMensagem(9, "Tempo de :" + ExtensionMethods.GetTime(dataInicial));

                    // Seta o progresso do ListBox
                    setMensagem(10, "Grupo Fatura...");

                    dataInicial = DateTime.Now;
                    sincronizar.GrupoFatura();
                    setMensagem(10, "Tempo de :" + ExtensionMethods.GetTime(dataInicial));

                    // Seta o progresso do ListBox
                    setMensagem(16, "Matricula Carga...");

                    dataInicial = DateTime.Now;
                    sincronizar.MatriculaCarga();
                    setMensagem(13, "Tempo de :" + ExtensionMethods.GetTime(dataInicial));

                    // Seta o progresso do ListBox
                    setMensagem(13, "Movimento...");

                    dataInicial = DateTime.Now;
                    sincronizar.Movimento();
                    setMensagem(35, "Tempo de :" + ExtensionMethods.GetTime(dataInicial));

                    // Seta o progresso do ListBox
                    setMensagem(35, "Qualidade Agua...");

                    dataInicial = DateTime.Now;
                    sincronizar.QualidadeAgua();
                    setMensagem(36, "Tempo de :" + ExtensionMethods.GetTime(dataInicial));

                    // Seta o progresso do ListBox
                    setMensagem(36, "Roteiro...");

                    dataInicial = DateTime.Now;
                    sincronizar.Roteiro();
                    setMensagem(37, "Tempo de :" + ExtensionMethods.GetTime(dataInicial));

                    // Seta o progresso do ListBox
                    setMensagem(37, "Fatura...");

                    dataInicial = DateTime.Now;
                    sincronizar.Fatura();
                    setMensagem(73, "Tempo de :" + ExtensionMethods.GetTime(dataInicial));

                    // Seta o progresso do ListBox
                    setMensagem(73, "Aviso Debito...");

                    dataInicial = DateTime.Now;
                    sincronizar.AvisoDebito();
                    setMensagem(76, "Tempo de :" + ExtensionMethods.GetTime(dataInicial));

                    // Seta o progresso do ListBox
                    setMensagem(76, "Fatura Categoria...");

                    dataInicial = DateTime.Now;
                    sincronizar.FaturaCategoria();
                    setMensagem(84, "Tempo de :" + ExtensionMethods.GetTime(dataInicial));

                    // Seta o progresso do ListBox
                    setMensagem(84, "Fatura Aviso...");

                    dataInicial = DateTime.Now;
                    sincronizar.FaturaAviso();
                    setMensagem(88, "Tempo de :" + ExtensionMethods.GetTime(dataInicial));

                    // Seta o progresso do ListBox
                    setMensagem(88, "Hidrometro...");

                    dataInicial = DateTime.Now;
                    sincronizar.Hidrometro();
                    setMensagem(90, "Tempo de :" + ExtensionMethods.GetTime(dataInicial));

                    // Seta o progresso do ListBox
                    setMensagem(90, "Historico...");

                    dataInicial = DateTime.Now;
                    sincronizar.Historico();
                    setMensagem(91, "Tempo de :" + ExtensionMethods.GetTime(dataInicial));

                    // Seta o progresso do ListBox
                    setMensagem(91, "Logradouro...");

                    dataInicial = DateTime.Now;
                    sincronizar.Logradouro();
                    setMensagem(92, "Tempo de :" + ExtensionMethods.GetTime(dataInicial));

                    // Seta o progresso do ListBox
                    setMensagem(92, "Matricula...");

                    dataInicial = DateTime.Now;
                    sincronizar.Matricula();
                    setMensagem(93, "Tempo de :" + ExtensionMethods.GetTime(dataInicial));

                    // Seta o progresso do ListBox
                    setMensagem(93, "Movimento Categoria...");

                    dataInicial = DateTime.Now;
                    sincronizar.MovimentoCategoria();
                    setMensagem(94, "Tempo de :" + ExtensionMethods.GetTime(dataInicial));

                    // Seta o progresso do ListBox
                    setMensagem(94, "Movimento Taxa...");

                    dataInicial = DateTime.Now;
                    sincronizar.MovimentoTaxa();
                    setMensagem(95, "Tempo de :" + ExtensionMethods.GetTime(dataInicial));

                    // Seta o progresso do ListBox
                    setMensagem(95, "Matricula Diadema...");

                    dataInicial = DateTime.Now;
                    sincronizar.MatriculaDiadema();
                    setMensagem(96, "Tempo de :" + ExtensionMethods.GetTime(dataInicial));

                    // Seta o progresso do ListBox
                    setMensagem(96, "Mensagem Movimento...");

                    dataInicial = DateTime.Now;
                    sincronizar.MensagemMovimento();
                    setMensagem(97, "Tempo de :" + ExtensionMethods.GetTime(dataInicial));

                    // Seta o progresso do ListBox
                    setMensagem(97, "Taxa Tarifa...");

                    dataInicial = DateTime.Now;
                    sincronizar.TaxaTarifa();
                    setMensagem(98, "Tempo de :" + ExtensionMethods.GetTime(dataInicial));

                    // Seta o progresso do ListBox
                    setMensagem(98, "Referencia Pendente...");

                    dataInicial = DateTime.Now;
                    sincronizar.ReferenciaPendente();
                    setMensagem(99, "Tempo de :" + ExtensionMethods.GetTime(dataInicial));

                    // Seta o progresso do ListBox
                    setMensagem(99, "Taxa Tarifa Faixa...");

                    dataInicial = DateTime.Now;
                    sincronizar.TaxaTarifaFaixa();
                    setMensagem(99, "Tempo de :" + ExtensionMethods.GetTime(dataInicial));

                    // Seta o progresso do ListBox
                    setMensagem(99, "Serviço Fatura...");

                    dataInicial = DateTime.Now;
                    sincronizar.ServicoFatura();
                    setMensagem(99, "Tempo de :" + ExtensionMethods.GetTime(dataInicial));

                    // Seta o progresso do ListBox
                    setMensagem(99, "Utilização Ligação...");

                    dataInicial = DateTime.Now;
                    sincronizar.UtilizacaoLigacao();
                    setMensagem(99, "Tempo de :" + ExtensionMethods.GetTime(dataInicial));

                    // Seta o progresso do ListBox
                    setMensagem(100, "Finalizando...");

                    //*******Finaliza a Carga das Tabelas do PDA**********
                    setMensagem(100, "Atualizando dados: IDA_DISTRIBUICAO");

                    // Conecta ao web server (Realiza a atualização da tabela de distribuição)
                    _webService.AtualizaDistribuicao(distribuicao[0].Grupo, userCurrent, distribuicao[0].Rota);

                    setMensagem(100, "FINALIZADO");

                    // Retorna a quantidade de minutos que decoreu a carga
                    string tempoTotal = ExtensionMethods.GetTime(sicronizacaoIni);
                    setMensagem(100, "TEMPO TOTAL - " + tempoTotal);
                    DeviceProject.Util.ExtensionMethods.MsgInfomation("Sincronização finalizada com o tempo de : " + tempoTotal, "Informação");
                }
            }
            catch (Exception exc)
            {
                GenericDAO<Boolean> Limpar = new GenericDAO<Boolean>();
                Limpar.LimpaBanco();
                MessageBox.Show("Erro em: " + status + "\n" + exc.Message);
            }
            finally
            {
                // FORÇA O FEÇHAMENTO DA CONEXÂO DO BANCO DE DADOSS
                SQLHelper.cmdOrigem.Connection.Close();
            }

            #endregion
        }

        /// <summary>
        /// Metodo responsavel por Realizar a descarga do dados
        /// </summary>
        public void EnviarDados()
        {
            try
            {
                // Seta o progresso do ListBox
                setMensagem(1, "Iniciando....");
                setMensagem(1, "Validando....");

                //Verifica se a versão e valida
                if (!ValidaVersao())
                    Application.Exit();

                // Verifica se todas as validacões estão corretas
                if (ValidacaoCorretaEnvio())
                {

                    // Identifica o tempo inicial da sicronização
                    sicronizacaoIni = DateTime.Now;

                    // Instacia da classe de envio
                    Envio enviar = new Envio();

                    DateTime dataInicial = DateTime.Now;
                    setMensagem(5, "Enviando os dados de VOLTA ROTEIRO.");
                    enviar.VoltaRoteiro();
                    setMensagem(5, "Tempo de :" + ExtensionMethods.GetTime(dataInicial));

                    dataInicial = DateTime.Now;
                    setMensagem(9, "Enviando os dados de VOLTA LEITURA.");
                    enviar.VoltaLeitura();
                    setMensagem(9, "Tempo de :" + ExtensionMethods.GetTime(dataInicial));

                    dataInicial = DateTime.Now;
                    setMensagem(50, "Enviando os dados de VOLTA ALTERACAO.");
                    enviar.VoltaAlteracao();
                    setMensagem(50, "Tempo de :" + ExtensionMethods.GetTime(dataInicial));

                    dataInicial = DateTime.Now;
                    setMensagem(80, "Enviando os dados de VOLTA NOVO REGISTRO.");
                    enviar.VoltaNovoRegistro();
                    setMensagem(80, "Tempo de :" + ExtensionMethods.GetTime(dataInicial));

                    dataInicial = DateTime.Now;
                    setMensagem(90, "Enviando os dados de VOLTA LOG ATENDIMENTO.");
                    enviar.VoltaLogAtendimento();
                    setMensagem(90, "Tempo de :" + ExtensionMethods.GetTime(dataInicial));

                    // Limpa o banco de dados e faz uma copia
                    setMensagem(90, "Limpa e cria uma copia do banco.");
                    GenericDAO<Boolean> Limpar = new GenericDAO<Boolean>();
                    SQLHelper.BackpBanco();
                    Limpar.LimpaBanco();

                    // FORÇA O FEÇHAMENTO DA CONEXÂO DO BANCO DE DADOSS
                    SQLHelper.cmdOrigem.Connection.Close();

                    //*******Finaliza a descarga **********
                    setMensagem(100, "FINALIZADO");

                    // Retorna a quantidade de minutos que decorreu a carga
                    string tempoTotal = ExtensionMethods.GetTime(sicronizacaoIni);
                    setMensagem(100, "TEMPO TOTAL - " + tempoTotal);
                    DeviceProject.Util.ExtensionMethods.MsgInfomation("Sincronização finalizada com o tempo de : " + tempoTotal, "Informação");
                }
            }
            catch (Exception exc)
            {
                DeviceProject.Util.ExtensionMethods.MsgError(exc.Message, "Erro");
            }
            finally
            {
                // FORÇA O FEÇHAMENTO DA CONEXÂO DO BANCO DE DADOSS
                SQLHelper.cmdOrigem.Connection.Close();
            }
        }

        /// <summary>
        ///  Metodo ivocado pela thread para enviar os dados
        /// </summary>
        public static void VoltaLeituraUpload()
        {
            while (true)
            {
                try
                {
                    try
                    {
                        autoSyncTime = _webService.TimeSyncAutomatic();
                    }
                    catch (Exception)
                    {
                        autoSyncTime = "1800000";//padrao 30 minutos
                    }

                    int waitTime = int.Parse(autoSyncTime);

                    Thread.Sleep(waitTime);

                    if (statusThread)
                    {
                        statusThreadExec = true;

                        List<VoltaRoteiro> ListaRoteiros = new List<VoltaRoteiro>();
                        GenericDAO<VoltaRoteiro> ObjVoltaRoteiro = new GenericDAO<VoltaRoteiro>();

                        ListaRoteiros = ObjVoltaRoteiro.SelectVoltaRoteiro();

                        if (ListaRoteiros.Count > 0)
                        {

                            // Busca no banco registros a serem descarregados
                            GenericDAO<int> Descarga = new GenericDAO<int>();
                            int qtdcargaPDA = Descarga.VerficaCarga();

                            if (new Envio().ValidaCarga(ListaRoteiros[0].Grupo, ListaRoteiros[0].Rota, ListaRoteiros[0].Referencia, "LEITURA", qtdcargaPDA))
                            {

                                GenericDAO<VoltaLeitura> ObjVoltaLeitura = new GenericDAO<VoltaLeitura>();
                                int setor = _webService.RetornaSetor(ListaRoteiros[0].Grupo, ListaRoteiros[0].Rota, ListaRoteiros[0].Rota);

                                // Retorna uma lista com todos os dados 
                                List<VoltaLeitura> ListaVoltaLeitura = new List<VoltaLeitura>();
                                ListaVoltaLeitura = ObjVoltaLeitura.SelectVoltaLeitura(setor);

                                //Fecha a connecção
                                if (ListaVoltaLeitura.Count() > 0)
                                {
                                    // Percorre a lista inserindo os dados no Banco 
                                    foreach (VoltaLeitura Leitura in ListaVoltaLeitura)
                                    {
                                        try
                                        {
                                            // Conecta ao web server
                                            _webService.InsertVoltaLeitura(Leitura, UserPdaCurrent);

                                            LogSync log = new LogSync();
                                            log.Matricula = Leitura.CDC;
                                            log.TipoSync = "U";
                                            log.DataSync = DateTime.Now;
                                            LogSyncFlow.Insert(log);
                                        }
                                        catch (Exception ex)
                                        {
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // TODO: verifica forma de emitir mensagem de erro na thread.
                }

                statusThreadExec = false;
            }

        }

        /// <summary>
        /// Metodo responsavel pela animação da tela (barra de progresso e listbox)
        /// </summary>
        /// <param name="mensagem"></param>
        public void setMensagem(int progresso, string mensagem)
        {
            try
            {
                if (progresso <= 100 && progresso > 0)
                {
                    try
                    {
                        // Barra de progresso
                        pbProgresso.Value = progresso;

                        // Mensagem percentula
                        lblMsg.Text = progresso.ToString() + "%";
                        lblMsg.Refresh();

                        if (!mensagem.Equals(null))
                        {
                            // Mensagem e barra de progresso 
                            label1.Items.Add(mensagem);
                            label1.Refresh();
                            label1.SelectedIndex = label1.Items.Count - 1;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                else
                {
                    label1.Items.Clear();
                    pbProgresso.Maximum = 100;
                    lblMsg.Text = "0%";
                    lblMsg.Refresh();
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Validação para realizar a trasmissão dos dados
        /// </summary>
        /// <returns></returns>
        public Boolean ValidacaoCorretaReceber()
        {
            List<Boolean> resultado = new List<Boolean>();
            bool validar = true;
            bool retorno = false;
            string messagemErro = "";
            try
            {
                #region//**** VALIDACAO 1 VERIFICA CONEXÃO COM BANCO DE DADOS COMPACTO****//
                try
                {
                    if (SQLHelper.TestCon())
                    {
                        resultado.Add(true);
                    }
                    else
                    {
                        resultado.Add(false);
                    }
                }
                catch (Exception ex)
                {
                    messagemErro+= "- Falha ao conectar com o banco do aparelho.\n";
                    throw ex;
                }
                #endregion

                #region//**** VALIDACAO 1 VERIFICA CONEXÃO WEB SERVER****//
                try
                {
                    // Testa uma conexão com web server
                    validar = DeviceProject.Util.ExtensionMethods.CheckConnected(DeviceProject.Config.ConfiguracaoPDA.CurrentInstance.WebServiceAddress);
                    if (!validar)
                        resultado.Add(false);
                    else
                        resultado.Add(true);
                }
                catch (Exception ex)
                {
                    messagemErro += "- Falha ao conectar com servidor.\n";
                    throw ex;
                }

                #endregion

                #region//**** VALIDACAO 2 AUTENTICA O USUARIO ****//
                if (validar)
                {
                    if (_webService.AutenticaAgent(userCurrent.ToString(), senha))
                    {
                        resultado.Add(true);
                    }
                    else
                    {
                        messagemErro += "- Usuario e senha incorreto.\n";
                        resultado.Add(false);
                    }
                }
                #endregion

                #region//**** VALIDACAO 3 VERIFICA CONEXÃO COM BANCO DE DADOS DO WEB SERVER ****//

                //Verifica se e possivel conectar ao web server
                if (validar)
                {
                    if (_webService.teste())
                        resultado.Add(true);
                    else
                    {
                        messagemErro += "- Falha ao conectar ao banco de dados do Servidor.\n";
                        resultado.Add(false);
                    }
                }
                #endregion

                #region//**** VALIDACAO 4 VERIFICA REGISTROS A SEREM TRANSMITIDOS ****//

                //Verifica se e possivel conectar ao web server
                if (validar)
                {
                    // Recupera a distribuição
                    distribuicao = _webService.Distribuicao(userCurrent, senha, UserPdaCurrent);

                    // Verifica se foi retornado uma distribuição
                    if (distribuicao.Count() < 1)
                    {
                        resultado.Add(false);
                        messagemErro += "- Não foram encontradas distribuições disponiveis.\n";
                        //DeviceProject.Util.ExtensionMethods.MsgExclamation("Não foram encontradas distribuições disponiveis.", "Atenção");
                    }
                    else
                    {
                        resultado.Add(true);
                    }
                }
                #endregion

                #region//**** VALIDACAO 5 VERIFICA A EXISTEMCIA DE REGISTROS A SEREM ENVIADOS ****//

                try
                {
                    // Verifica se existem dados para descarregar
                    GenericDAO<int> Obj = new GenericDAO<int>();
                    int RegistroDescarga = Obj.VerficaCarga();
                    if (RegistroDescarga > 0)
                    {
                        resultado.Add(false);
                        messagemErro += "- Existem " + RegistroDescarga.ToString() + " matriculas que precisam ser descarregados\n";
                    }
                    else
                    {
                        resultado.Add(true);
                    }
                }
                catch (Exception ex)
                {
                    messagemErro += "- Erro ao verificar registros a serem enviados verifique a log de erro.\n";
                    throw ex;
                }
                #endregion

            }
            catch (Exception ex)
            {
                LogErroFlow.SetErro(ex, "VALIDACAO_RECEBER", "V");
            }

            // Verifica se todas as validações estão corretas
            retorno = DeviceProject.Util.ExtensionMethods.ValidacaoCorreta(resultado.ToArray());

            if (!retorno)
            {
                if (!String.IsNullOrEmpty(messagemErro))
                    DeviceProject.Util.ExtensionMethods.MsgExclamation("Menssagem(s):\n" + messagemErro, "Validação");
            }
            return retorno;
        }

        /// <summary>
        /// Validação para realizar o envio dos dados
        /// </summary>
        /// <returns></returns>
        public Boolean ValidacaoCorretaEnvio()
        {
            List<Boolean> resultado = new List<Boolean>();
            bool validar = false;
            bool retorno = false;
            string messagemErro = "";
            try
            {
                #region//**** VALIDACAO 1 VERIFICA CONEXÃO COM BANCO DE DADOS COMPACTO****//
                try
                {
                    if (SQLHelper.TestCon())
                    {
                        resultado.Add(true);
                    }
                    else
                    {
                        resultado.Add(false);
                    }
                }
                catch (Exception e)
                {
                    messagemErro += "- Falha ao conectar com o banco do aparelho.\n";
                    throw e;
                }
                #endregion

                #region//**** VALIDACAO 1 VERIFICA CONEXÃO WEB SERVER****//
                try
                {
                    // Testa uma conexão com web server
                    validar = DeviceProject.Util.ExtensionMethods.CheckConnected(DeviceProject.Config.ConfiguracaoPDA.CurrentInstance.WebServiceAddress);
                    if (!validar)
                        resultado.Add(false);
                    else
                        resultado.Add(true);
                }
                catch (Exception e)
                {
                    messagemErro += "- Falha ao conectar com servidor.\n";
                    throw e;
                }

                #endregion

                #region//**** VALIDACAO 2 AUTENTICA O USUARIO ****//

                if (validar)
                {
                    if (_webService.AutenticaAgent(userCurrent.ToString(), senha))
                    {
                        resultado.Add(true);
                    }
                    else
                    {
                        //DeviceProject.Util.ExtensionMethods.MsgExclamation("Usuario e senha incorreto.", "Atenção");
                        messagemErro += "- Usuario e senha incorreto.\n";
                        resultado.Add(false);
                    }
                }
                #endregion

                #region//**** VALIDACAO 3 VERIFICA CONEXÃO COM BANCO DE DADOS DO WEB SERVER ****//

                //Verifica se e possivel conectar ao web server
                if (validar)
                {
                    if (_webService.teste())
                        resultado.Add(true);
                    else
                    {
                        messagemErro += "- Falha ao conectar ao banco de dados do Servidor.\n";
                        resultado.Add(false);
                    }
                }
                #endregion

                #region//**** VALIDACAO 4 VERIFICA SE EXISTEM REGISTROS A SEREM DESCARREGADOS ****//

                try
                {
                    // Busca no banco registros a serem descarregados
                    GenericDAO<int> Descarga = new GenericDAO<int>();
                    int QuantidadeDescarga = Descarga.VerficaCarga();
                    if (QuantidadeDescarga < 1)
                    {
                        resultado.Add(false);
                        messagemErro += "- Não existem registros a serem descarregados.\n";
                    }
                    else
                        resultado.Add(true);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                #endregion

                #region//**** VALIDACAO 6 VERIFICA SE O WEBSERVICE E O PDA ESTA SICRONIZADAS ****//

                if (this.ValidaVersao())
                {
                    resultado.Add(true);
                }
                else
                {
                    resultado.Add(false);
                }
                #endregion
            }
            catch (Exception ex)
            {
                LogErroFlow.SetErro(ex, "VALIDACAO_ENVIO", "V");
            }

            // Verifica se todas as validações estão corretas
            retorno = DeviceProject.Util.ExtensionMethods.ValidacaoCorreta(resultado.ToArray());

            if (!retorno)
            {
                if (!String.IsNullOrEmpty(messagemErro))
                    DeviceProject.Util.ExtensionMethods.MsgExclamation("Menssagem(s):\n\r" + messagemErro, "Validação");
            }
            return retorno;
        }

        /// <summary>
        /// Comparar duas versoes
        /// </summary>
        /// <param name="versao1"></param>
        /// <param name="versao2"></param>
        /// <returns></returns>
        public bool ValidaVersao()
        {
            bool retorno = false;
            string versaoPDA = "";
            string versaoWebService = "";

            try
            {
                // Rtorna a versão do PDA
                versaoPDA = Assembly.GetExecutingAssembly().GetName().Version.ToString();
                
                // Testa a conxão com webService
                if (DeviceProject.Util.ExtensionMethods.CheckConnected(DeviceProject.Config.ConfiguracaoPDA.CurrentInstance.WebServiceAddress))
                {
                    // Instancia Web service
                    versaoWebService = _webService.ExibeVersao();

                    // Retorna um array de CHAR 
                    char[] charVersaoPDA = versaoPDA.ToCharArray();
                    int total = charVersaoPDA.Count();

                    // Verifica se a versão e valida
                    if (versaoPDA == versaoWebService)
                    {
                        retorno = true;
                    }
                    else //verifica qual versão esta antiga
                    {
                        for (int i = 0; i < total; i++)
                        {
                            // verifica qual e diferente
                            if (charVersaoPDA[i] != versaoWebService[i])
                            {
                                // Compara somente os numeros
                                if (charVersaoPDA[i] != '.' && versaoWebService[i] != '.')
                                {
                                    if (int.Parse(charVersaoPDA[i].ToString()) > int.Parse(versaoWebService[i].ToString()))
                                        DeviceProject.Util.ExtensionMethods.MsgInfomation("Atenção versão do web service desatualizada", "Informação");
                                    else
                                        DeviceProject.Util.ExtensionMethods.MsgInfomation("Atenção versão do PDA desatualizada", "Informação");
                                    break;
                                }
                            }
                        }//for
                    }
                }
                else
                {
                    // em caso de falta de concxão retorna true
                    retorno = true;
                }
            }
            catch (Exception ex)
            {
                // em caso erro retorna true
                retorno = true;
                LogErroFlow.SetErro(ex, "VALIDACAO_VERSAO", "V");
            }
            return retorno;
        }

        /// <summary>
        ///  Abre o aplicativo ONPLACE
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem4_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            p.StartInfo.FileName = "\\Program Files\\OnPlaceMovel\\OnPlaceMovel.exe";
            p.Start();
        }

        /// <summary>
        /// Abre a tela de configuração
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ConfiguracaoWeb configWebServer = new ConfiguracaoWeb();

            configWebServer.ShowDialog();

            if (configWebServer.DialogResult == DialogResult.Yes)
            {
                userCurrent = int.Parse(ConfiguracaoPDA.CurrentInstance.Username);
                UserPdaCurrent.usuario = userCurrent;
                senha = ConfiguracaoPDA.CurrentInstance.Password;
            }
            lusuario.Text = "Agente : " + ConfiguracaoPDA.CurrentInstance.Username;
        }

    }
}
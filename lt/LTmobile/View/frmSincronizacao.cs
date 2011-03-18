using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LTmobile.Sincronizacao;
using LTmobileData.Data.BFL;
using LTmobileData.Data.Model;
using System.IO;
using System.Net;
using LTmobileData.Utils;
using LTmobileData.Data.Helper;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;


namespace LTmobile.View
{
    public partial class frmSincronizacao : Form
    {
        [DllImport("coredll.dll", EntryPoint = "SetForegroundWindow")]
        private static extern int SetForegroundWindow(IntPtr hWnd);

        /// <summary>
        /// Sincronização
        /// </summary>
        private static WS_ltMobile syncService = new WS_ltMobile();

        /// <summary>
        /// Usuário logado
        /// </summary>
        private Autenticantion user = new Autenticantion();

        /// <summary>
        /// COndição para confirmação de leitura
        /// </summary>
        string strConfirmaLeitura = "";

        /// <summary>
        /// Condição para atualizar leitura
        /// </summary>
        string strCondicaoMensagem = "";

        /// <summary>
        /// Condição para atualizar mensagem
        /// </summary>
        string strCondicaoMensagem2 = "";



        public frmSincronizacao()
        {
            InitializeComponent();
            txbSincronizacao.Focus();
            
        }

        private void frmSincronizacao_Load(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Verifica se está conectado com a internet
        /// </summary>
        /// <returns></returns>
        public bool estaConectado()
        {
            try
            {
                System.Net.IPHostEntry obj = System.Net.Dns.GetHostByName("www.velp.com.br");
                return true;
            }
            catch
            {
                try
                {
                    System.Net.IPHostEntry obj = System.Net.Dns.GetHostByName("www.google.com.br");
                    return true;
                }
                catch(Exception ex)
                {
                    txbSincronizacao.Text += "Não foi possível se conectar a internet. Ex: " + ex.ToString();
                    return false; // host not reachable. 
                }
            }
        }



        private void menuItem1_Click(object sender, EventArgs e)
        {
            if (frmLogin.StatusSinc == true)
            {
                MessageBox.Show("Sincronização já está em andamento. Aguarde!");
                return;                
            }
            else
            {
                frmLogin.setStatusSinc(true);
            }

            if (!estaConectado())
            {
                MessageBox.Show("Não foi possível se conectar a internet");
                frmLogin.setStatusSinc(false);
                return;
            }

            txbSincronizacao.Text = "";

            txbSincronizacao.Text = txbSincronizacao.Text + "Conectando ao Servidor...\r\n";

            ConfigWebService configWS = new ConfigWebService();

            try
            {
                //testa se o endereco de webservice esta preenchido.
                if (string.IsNullOrEmpty(configWS.WebServiceCurrent))
                {
                    throw new Exception("URL do webservice não configurado.");
                }

                //testa se o endereco de webservice foi preenchido corretamente.
                try
                {
                    syncService.Url = configWS.WebServiceCurrent;
                }
                catch (Exception ex) { throw new Exception("A URL do webservice é inválida."); }

                //testa se o login foi informado.
                if (string.IsNullOrEmpty(configWS.LoginWebService))
                {
                    throw new Exception("Login não informado.");
                }

                //testa se a senha foi informada.
                if (string.IsNullOrEmpty(configWS.SenhaWebService))
                {
                    throw new Exception("Senha não informada.");
                }

                user.User = configWS.LoginWebService;
                user.Password = configWS.SenhaWebService;



                DateTime data;
                txbSincronizacao.Text += "Sincronizando data...\r\n";
               
                try
                {
                    data = syncService.getDateDBServer(user);
                }
                catch (Exception ex) 
                {
                    txbSincronizacao.Text += "Falha ao conectar com webservice, verifique sua conexão com a internet. Ex: " + ex.ToString();
                    MessageBox.Show("Falha ao conectar com webservice, verifique sua conexão com a internet. Ex: " + ex.ToString() + "");
                    return;
                    //throw new Exception("Falha ao conectar com webservice, verifique sua conexão com a internet. Ex: " + ex + ""); 
                }

                try
                {
                    MobileTools.SystemTimeInfo.UpdateSystemTime(data);
                    txbSincronizacao.Text = txbSincronizacao.Text + "Data sincronizada.\r\n";
                    txbSincronizacao.Text = txbSincronizacao.Text + "Iniciando sincronização de dados em: " + string.Format("{0:HH:mm:ss}", DateTime.Now) + "\r\n";
                }
                catch (Exception ex)
                {
                    txbSincronizacao.Text += "Erro ao atualizar data do PDA: "+ex.ToString();
                    return;
                }
            

                try
                {
                    Cursor.Current = Cursors.WaitCursor;



                    syncSetLeitura();
                    syncSetMensagem();
                    syncSetLeituraProvisoria();
                    syncSetFotos();
                    syncSetCorreioEletronico();


                    syncLeitura();
                    syncMensagem();
                    syncGetCorreioEletronico();
                    //syncGetOcorrencia();
                    txbSincronizacao.Text = txbSincronizacao.Text + "Sincronização Concluída";
                    MessageBox.Show("Sincronização Finalizada");
                    /*  syncGetFuncionario();
                      syncGetOcorrencia();                
                      syncGetFoto();*/
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha na conexão:\n" + ex.Message);
                txbSincronizacao.Text += "Conexão não realizada! Erro:"+ex.ToString();
            }
            finally
            {
                frmLogin.setStatusSinc(false);
                Cursor.Current = Cursors.Default;
            }
            
        }

        private void syncSetLeitura()
        {
            string Condicao = "";
            Sincronizacao.LeituraWS[] lstLeituraNotSync = null;
            List<ErroLeituraWS> Erros = null;
            int ErroEnvioLeitura = 1;

            //*** Envia dados ao servidor***\\
            txbSincronizacao.Text += "Sincronizando Unidade Consumidora...\r\n";
            txbSincronizacao.Text += "Enviando tabela de Leitura...\r\n";
            txbSincronizacao.ScrollToCaret();

            List<Leitura> LeituraNotSync = LeituraFlow.getLeituraNotSync();
            if (LeituraNotSync.Count <= 0)
            {
                txbSincronizacao.Text += "Não existe leitura a ser enviada ";
                return;
            }


            try
            {
                txbSincronizacao.Text += "Buscando leitura não sincronizadas ";
                lstLeituraNotSync = SyncUtil<Leitura, Sincronizacao.LeituraWS>.ConvertModelToWSObject(LeituraNotSync);
            }
            catch (Exception ex)
            {
                txbSincronizacao.Text += "Erro ao buscar leitura não sincronizadas: "+ ex.ToString();
                throw new Exception("Erro ao buscar leitura não sincronizadas: "+ ex.ToString());
                //return;
            }

            bool boLoopLeitura = true;
            while (boLoopLeitura)
            {
                try
                {
                    txbSincronizacao.Text += "Tentando enviar " + LeituraNotSync.Count() + " leituras...";
                    Erros = syncService.setLeitura(lstLeituraNotSync);
                    boLoopLeitura = false;
                }
                catch (Exception ex)
                {                       
                    if (ErroEnvioLeitura > 2)
                    {
                        txbSincronizacao.Text += "Não foi possível enviar leitura. Erro: " + ex.ToString();
                        throw new Exception("Não foi possível enviar leitura. Erro: " + ex.ToString());                        
                    }
                    else
                    {
                        ErroEnvioLeitura += +1;
                    }
                }
            }


            if(Erros.Count > 0)
            {

                foreach (ErroLeituraWS e in Erros)
                {
                    if (e.EXCEPTION == "")
                    {
                        Condicao += "(NUM_UC=" + e.NUM_UC + " AND TIPO_MEDIC= '" + e.TIPO_MEDIC + "') ";
                        Condicao += "OR ";
                    }
                    else
                    {
                        txbSincronizacao.Text += "Houve erro ao enviar a seguinte leitura: NUM_UC:" + e.NUM_UC + "  COD_EMPRT:" + e.COD_EMPRT + " COD_LOCAL:" + e.COD_LOCAL + " MES_ANO_FATUR:" + e.MES_ANO_FATUR + " NUM_RAZAO:" + e.NUM_RAZAO + " TIPO_MEDIC:" + e.TIPO_MEDIC + " Erro:" + e.EXCEPTION;
                        throw new Exception("Houve erro ao enviar a seguinte leitura: NUM_UC:" + e.NUM_UC + "  COD_EMPRT:" + e.COD_EMPRT + " COD_LOCAL:" + e.COD_LOCAL + " MES_ANO_FATUR:" + e.MES_ANO_FATUR + " NUM_RAZAO:" + e.NUM_RAZAO + " TIPO_MEDIC:" + e.TIPO_MEDIC + " Erro:" + e.EXCEPTION);                        
                    }

                }
                Condicao = Condicao.Substring(0, (Condicao.Length - 3));
                try
                {
                    LeituraFlow.AlteraStatusLeitura(Condicao);
                }
                catch (Exception ex)
                {
                    txbSincronizacao.Text += "Não foi possível alterar status da leitura no PDA. Erro: " + ex.ToString();
                    throw new Exception("Não foi possível alterar status da leitura no PDA. Erro: " + ex.ToString());                   
                }
            }
       
            txbSincronizacao.Text = txbSincronizacao.Text + "Tabela Leitura enviada...\r\n";
        }

        public void syncSetCorreioEletronico()
        {
            string strCondicao = "";
            Sincronizacao.CorreioEletronicoWS[] lstCorreioEletronicoNotSync = null;
            List<ErroCorreioEletronicoWS> Erros = null;
            //*** Envia dados ao servidor***\\
            txbSincronizacao.Text = txbSincronizacao.Text + "Sincronizando Correio Eletrônico...\r\n";
            txbSincronizacao.Text = txbSincronizacao.Text + "Enviando tabela de Correio Eletrônico...\r\n";
            txbSincronizacao.ScrollToCaret();

            List<CorreioEletronico> CorreioEletronicoNotSync = CorreioEletronicoFlow.getCorreioEletronicoNotSync();

            if (CorreioEletronicoNotSync.Count <= 0)
            {
                txbSincronizacao.Text += "Não existe mensagem de correio eletrônico a ser enviada ";
                return;
            }
            
            try
            {
                txbSincronizacao.Text += "Buscando correio eletrônico não sincronizado ";
                lstCorreioEletronicoNotSync = SyncUtil<CorreioEletronico, Sincronizacao.CorreioEletronicoWS>.ConvertModelToWSObject(CorreioEletronicoNotSync);
            }
            catch (Exception ex)
            {
                txbSincronizacao.Text += "Erro ao buscar correio eletrônico não sincronizada: " + ex.ToString();
                throw new Exception("Erro ao buscar correio eletrônico não sincronizada: " + ex.ToString());
                //return;
            }

            bool boLoopCorreio = true;
            int erroEnvioCorreio = 1;
            while (boLoopCorreio)
            {
                try
                {
                    Erros = syncService.setCorreioEletronico(lstCorreioEletronicoNotSync);
                    boLoopCorreio = false;
                }
                catch (Exception ex)
                {
                    if (erroEnvioCorreio > 2)
                    {
                        txbSincronizacao.Text += "Não foi possível enviar correio eletrônico. Erro: " + ex.ToString();
                        throw new Exception("Não foi possível enviar correio eletrônico. Erro: " + ex.ToString());
                    }
                    else
                    {
                        erroEnvioCorreio += +1;
                    }

                }
            }
            
            
            
            if (Erros.Count > 0)
            {

                strCondicao += "(STATUS_REG = 2 AND TIPO_MSG = 'C' AND STATUS_MSG = 0) AND (";

                foreach (ErroCorreioEletronicoWS e in Erros)
                {
                    if (e.EXCEPTION == "")
                    {
                        strCondicao += "(ID_MSG = " + e.ID_MSG + ") ";
                        strCondicao += "OR ";
                    }
                    else
                    {
                        txbSincronizacao.Text += "Houve erro ao enviar o seguinte correio: Id_Msg:" + e.ID_MSG + " Erro:" + e.EXCEPTION;
                        throw new Exception("Houve erro ao enviar o seguinte correio: Id_Msg:" + e.ID_MSG + " Erro:" + e.EXCEPTION);
                    }

                }

                strCondicao = strCondicao.Substring(0, (strCondicao.Length - 3));
                strCondicao += ") ";
                
                try
                {
                    CorreioEletronicoFlow.AlteraStatusCorreioEletronico(strCondicao);
                }
                catch (Exception ex)
                {
                    txbSincronizacao.Text += "Não foi possível alterar status do correio eletrônico no PDA. Erro: " + ex.ToString();
                    throw new Exception("Não foi possível alterar status do correio eletrônico no PDA. Erro: " + ex.ToString());
                }

            }
            
            
            txbSincronizacao.Text = txbSincronizacao.Text + "Tabela Correio Eletronico enviada...\r\n";
        }

        public void syncSetFotos()
        {
            string Condicao = "";
            Sincronizacao.FotoWS[] lstFotosNotSync = null;
            //*** Envia dados ao servidor***\\
            txbSincronizacao.Text = txbSincronizacao.Text + "Sincronizando Fotos...\r\n";
            txbSincronizacao.Text = txbSincronizacao.Text + "Enviando tabela de Fotos...\r\n";
            txbSincronizacao.ScrollToCaret();

            List<Fotos> FotosNotSync = FotosFlow.getFotosNotSync();

            if (FotosNotSync.Count <= 0)
            {
                txbSincronizacao.Text += "Não existe foto a ser enviada ";
                return;
            }

            try
            {
                txbSincronizacao.Text += "Buscando foto não sincronizadas ";
                lstFotosNotSync = SyncUtil<Fotos, Sincronizacao.FotoWS>.ConvertModelToWSObject(FotosNotSync);
            }
            catch (Exception ex)
            {
                txbSincronizacao.Text += "Erro ao buscar foto não sincronizadas: " + ex.ToString();
                throw new Exception("Erro ao buscar foto não sincronizadas: " + ex.ToString());
                //return;
            }

            List<ErroFotoWS> Erros = new List<ErroFotoWS>();
            int i = 0;
            foreach (var item in lstFotosNotSync)
            {
                string strFoto = GetPathFoto() + lstFotosNotSync[i].ID_FOTO + ".jpg";                    
                if (File.Exists(strFoto))
                {
                    try
                    {

                        byte[] btFoto = ReadByteArrayFromFile(strFoto);

                        Erros.Add(syncService.setFoto(lstFotosNotSync[i], btFoto));

                    }
                    catch(Exception ex) 
                    {
                        txbSincronizacao.Text += "Erro ao enviar foto: " + ex.ToString();
                        throw new Exception("Erro ao enviar foto: " + ex.ToString());
                    }
                }
                i++;

            }


            Condicao += "(STATUS_REG = 2) AND (";


            foreach (ErroFotoWS e in Erros)
            {
                if (e.NUM_UC != 0)
                {
                    Condicao += "(NUM_UC=" + e.NUM_UC + " AND TIPO_MEDIC= '" + e.TIPO_MEDIC + "') ";
                    Condicao += "OR ";
                }

            }
            Condicao = Condicao.Substring(0, (Condicao.Length - 3));
            Condicao += ") ";
            FotosFlow.AlteraStatusFoto(Condicao);

            /*foreach (ErroFotoWS e in Erros)
            {
                if (e.NUM_UC != 0)
                {
                    Condicao += " AND (NOT(NUM_UC = " + e.NUM_UC + ") OR NOT(MES_ANO_FATUR = " + e.MES_ANO_FATUR + ") OR NOT(COD_LOCAL = " + e.COD_LOCAL + ") " +
                    "OR NOT(TIPO_MEDIC = '" + e.TIPO_MEDIC + "') OR NOT(COD_EMPRT = " + e.COD_EMPRT + ") OR NOT(NUM_RAZAO = '" + e.NUM_RAZAO + "')OR NOT(NUM_SEQ_FOTO = '" + e.NUM_SEQ_FOTO + "'))";
                }
            }
            
        FotosFlow.AlteraStatusFoto(Condicao);*/


            
            txbSincronizacao.Text = txbSincronizacao.Text + "Tabela Fotos enviada...\r\n";
        }

        public void syncSetLeituraProvisoria()
        {
            string Condicao = "";
            
            txbSincronizacao.Text = txbSincronizacao.Text + "Sincronizando Leitura Provisória...\r\n";
            txbSincronizacao.Text = txbSincronizacao.Text + "Enviando tabela de Leitura Provisoria...\r\n";
            txbSincronizacao.ScrollToCaret();

            List<LeituraProvisoria> LeituraProvisoriaNotSync = LeituraProvisoriaFlow.LeituraProvisoriaNotSync();

            if (LeituraProvisoriaNotSync.Count <= 0) return;
            else
            {
                Sincronizacao.LeituraProvisoriaWS[] lstLeituraProvisoriaNotSync = SyncUtil<LeituraProvisoria, Sincronizacao.LeituraProvisoriaWS>.ConvertModelToWSObject(LeituraProvisoriaNotSync);

                try
                {
                    List<ErroLeituraProvisoriaWS> Erros = syncService.setLeituraPovisoria(lstLeituraProvisoriaNotSync);

                    /*if (Erros.Count > 0)
                    {

                        foreach (ErroLeituraProvisoriaWS e in Erros)
                        {
                            Condicao += " AND (NOT(MES_ANO_FATUR = " + e.MES_ANO_FATUR + ") OR NOT(COD_LOCAL = " + e.COD_LOCAL + ") OR NOT(COD_EMPRT = " + e.COD_EMPRT + ") " +
                            "OR NOT(TIPO_MEDIC = '" + e.TIPO_MEDIC + "') OR NOT(NUM_MEDIDR = " + e.NUM_MEDIDR + ") OR NOT(NUM_UC_REF = '" + e.NUM_UC_REF + "')OR NOT(NUM_RAZAO = '" + e.NUM_RAZAO + "'))";
                        }
                    }
                    try
                    {
                        LeituraProvisoriaFlow.AlteraStatusLeituraProvisoria(Condicao);
                    }
                    catch { }*/

                    if (Erros.Count > 0)
                    {

                        Condicao += "(STATUS_REG = 2) AND (";


                        foreach (ErroLeituraProvisoriaWS e in Erros)
                        {
                            Condicao += "(NUM_UC_REF = '" + e.NUM_UC_REF + "' AND TIPO_MEDIC= '" + e.TIPO_MEDIC + "' AND MES_ANO_FATUR = " + e.MES_ANO_FATUR + " AND COD_LOCAL = " + e.COD_LOCAL + " " +
                               "AND COD_EMPRT = " + e.COD_EMPRT + " AND NUM_MEDIDR = " + e.NUM_MEDIDR + " AND NUM_RAZAO = '" + e.NUM_RAZAO + "')";
                            Condicao += "OR ";

                        }
                        Condicao = Condicao.Substring(0, (Condicao.Length - 3));
                        Condicao += ") ";
                        LeituraProvisoriaFlow.AlteraStatusLeituraProvisoria(Condicao);
                    }


                }
                catch (Exception ex)
                {
                    txbSincronizacao.Text = ex.ToString();
                }
            }
            txbSincronizacao.Text = txbSincronizacao.Text + "Tabela Leitura Provisória enviada...\r\n";
        }

        public void syncSetMensagem()
        {
            string Condicao = "";

            txbSincronizacao.Text = txbSincronizacao.Text + "Sincronizando Mensagens...\r\n";
            txbSincronizacao.Text = txbSincronizacao.Text + "Enviando tabela de Mensagem...\r\n";
            txbSincronizacao.ScrollToCaret();

            List<mensagemUc> MensagemNotSync = MensagemUcFlow.getMensagemNotSync();

            if (MensagemNotSync.Count <= 0) return;
            else
            {
                Sincronizacao.MensagemWS[] lstMensagemNotSync = SyncUtil<mensagemUc, Sincronizacao.MensagemWS>.ConvertModelToWSObject(MensagemNotSync);

                try
                {
                    List<ErroMensagemWS> Erros = syncService.setMensagem(lstMensagemNotSync);

                    if (Erros.Count > 0)
                    {

                        /*foreach (ErroMensagemWS e in Erros)
                        {
                            Condicao += " AND (NOT(NUM_UC = " + e.NUM_UC + ") OR NOT(MES_ANO_FATUR = " + e.MES_ANO_FATUR + ") OR NOT(COD_LOCAL = " + e.COD_LOCAL + ") " +
                            "OR NOT(TIPO_MEDIC = '" + e.TIPO_MEDIC + "') OR NOT(COD_EMPRT = " + e.COD_EMPRT + ") OR NOT(NUM_RAZAO = '" + e.NUM_RAZAO + "')OR NOT(ID_MSG = '" + e.ID_MSG + "'))";
                        }*/
                        /*foreach (ErroMensagemWS e in Erros)
                        {

                            Condicao += "(NUM_UC=" + e.NUM_UC + " AND TIPO_MEDIC= '" + e.TIPO_MEDIC + "' AND ID_MSG = '" + e.ID_MSG + "') ";
                            Condicao += "OR ";

                        }
                        Condicao = Condicao.Substring(0, (Condicao.Length - 3));
                        MensagemUcFlow.AlteraStatusMensagem(Condicao);
                        //*/
                        Condicao += "(STATUS_REG = 2 AND FLAG_SENTIDO = 'C') AND (";


                        foreach (ErroMensagemWS e in Erros)
                        {
                            Condicao += "(NUM_UC=" + e.NUM_UC + " AND TIPO_MEDIC= '" + e.TIPO_MEDIC + "' AND ID_MSG = '" + e.ID_MSG + "') ";
                            Condicao += "OR ";

                        }
                        Condicao = Condicao.Substring(0, (Condicao.Length - 3));
                        Condicao += ") ";
                        MensagemUcFlow.AlteraStatusMensagem(Condicao);
                    }
                    //MensagemUcFlow.AlteraStatusMensagem(Condicao);

                }
                catch (Exception ex)
                {
                    txbSincronizacao.Text = ex.ToString();
                }
            }
            txbSincronizacao.Text = txbSincronizacao.Text + "Tabela Mensagem enviada...\r\n";
        }

        /// <summary>
        /// Sincroniza tabela de leitura
        /// </summary>
        private void syncLeitura()
        {
            strCondicaoMensagem = "";
            LTmobileData.Data.Model.Leitura leitura = null;

            txbSincronizacao.Text = txbSincronizacao.Text + "Buscando Unidade Consumidora...\r\n";
            txbSincronizacao.ScrollToCaret();

            // WS_ltMobile sincronizar = new Sincronizacao.WS_ltMobile();

            List<LTmobile.Sincronizacao.LeituraWS> LstLeitura = null;

            int tamanho = 0;
            //Leitura leitura = new Leitura();
            try
            {
                LstLeitura = syncService.getLeituraWS(user);
            }
            catch (Exception ex) 
            {
                txbSincronizacao.Text += "Não foi possível buscar leitura. Erro: " + ex.ToString();
                throw new Exception("Não foi possível buscar leitura. Erro: " + ex.ToString());                        

            }

            int index = 0;
            if (LstLeitura != null)
            {
                tamanho = LstLeitura.Count();
                txbSincronizacao.Text += "PDA buscou " + tamanho + " leituras...";
            }


            while (tamanho > index)
            {
                try
                {
                    leitura = new LTmobileData.Data.Model.Leitura();
                    leitura.MATRIC_FUNC = LstLeitura[index].MATRIC_FUNC;
                    leitura.NUM_LIVRO = LstLeitura[index].NUM_LIVRO;
                    leitura.SEQ_LIVRO = LstLeitura[index].SEQ_LIVRO;
                    leitura.NUM_UC = LstLeitura[index].NUM_UC;
                    leitura.MES_ANO_FATUR = LstLeitura[index].MES_ANO_FATUR;
                    leitura.COD_LOCAL = LstLeitura[index].COD_LOCAL;
                    leitura.COD_EMPRT = LstLeitura[index].COD_EMPRT;
                    leitura.TIPO_MEDIC = LstLeitura[index].TIPO_MEDIC;
                    //leitura.ESTADO_SERVC = LstLeitura[index].ESTADO_SERVC;
                    leitura.FLAG_REPASSE = (LstLeitura[index].ESTADO_SERVC == 5 ? "1" : "0");
                    leitura.ESTADO_SERVC = 0;
                    leitura.COD_IRREGL = LstLeitura[index].COD_IRREGL;
                    leitura.NUM_ROTR_OPER = LstLeitura[index].NUM_ROTR_OPER;
                    leitura.SEQ_ROTR_OPER = LstLeitura[index].SEQ_ROTR_OPER;
                    leitura.ENDER_UC = LstLeitura[index].ENDER_UC;
                    leitura.COMPL_ENDER = LstLeitura[index].COMPL_ENDER;
                    leitura.NUM_MEDIDR = LstLeitura[index].NUM_MEDIDR;
                    leitura.LEITUR_MAX = LstLeitura[index].LEITUR_MAX;
                    leitura.LEITUR_MIN = LstLeitura[index].LEITUR_MIN;
                    leitura.LEITUR_ANTER = LstLeitura[index].LEITUR_ANTER;
                    leitura.SITUAC_UC = LstLeitura[index].SITUAC_UC;
                    leitura.MEDIA_CONSUM = LstLeitura[index].MEDIA_CONSUM;
                    leitura.CONSUM_ANTER = LstLeitura[index].CONSUM_ANTER;
                    leitura.QTDE_LEITUR_ESTIMD = LstLeitura[index].QTDE_LEITUR_ESTIMD;
                    leitura.IRREGL_ANTER = LstLeitura[index].IRREGL_ANTER;
                    //leitura.IRREGL_ATUAL1 = LstLeitura[index].IRREGL_ATUAL1;
                    leitura.IRREGL_ATUAL1 = 0;
                    //leitura.IRREGL_ATUAL2 = LstLeitura[index].IRREGL_ATUAL2;
                    leitura.IRREGL_ATUAL2 = 0;
                    //leitura.IRREGL_ATUAL3 = LstLeitura[index].IRREGL_ATUAL3;
                    leitura.IRREGL_ATUAL3 = 0;
                    //leitura.DATA_IMPORT = Convert.ToDateTime(LstLeitura[index].DATA_IMPORT.ToString("dd/MM/yyyy"));
                    leitura.DATA_IMPORT = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"));
                    //leitura.HORA_IMPORT = LstLeitura[index].HORA_IMPORT;
                    leitura.HORA_IMPORT = DateTime.Now.ToString("HHmmss");
                    //leitura.DATA_VISITA = Convert.ToDateTime(LstLeitura[index].DATA_VISITA.ToString("dd/MM/yyyy"));
                    leitura.DATA_VISITA = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"));
                    leitura.HORA_VISITA = LstLeitura[index].HORA_VISITA;
                    leitura.USUAR_ATLZ = LstLeitura[index].USUAR_ATLZ;
                    leitura.DATA_ATLZ = Convert.ToDateTime(LstLeitura[index].DATA_ATLZ.ToString("dd/MM/yyyy"));
                    leitura.HORA_ATLZ = LstLeitura[index].HORA_ATLZ;
                    //leitura.FLAG_REPASSE = LstLeitura[index].FLAG_REPASSE;
                    //leitura.COMPL_ATUAL1 = LstLeitura[index].COMPL_ATUAL1;
                    leitura.COMPL_ATUAL1 = "";
                    //leitura.COMPL_ATUAL2 = LstLeitura[index].COMPL_ATUAL2;
                    leitura.COMPL_ATUAL2 = "";
                    //leitura.COMPL_ATUAL3 = LstLeitura[index].COMPL_ATUAL3;
                    leitura.COMPL_ATUAL3 = "";
                    leitura.DATA_CALENDARIO = LstLeitura[index].DATA_CALENDARIO;
                    leitura.COORD_X = LstLeitura[index].COORD_X;
                    leitura.COORD_Y = LstLeitura[index].COORD_Y;
                    //leitura.STATUS_REG = LstLeitura[index].STATUS_REG;
                    leitura.STATUS_REG = "0";
                    leitura.NUM_RAZAO = LstLeitura[index].NUM_RAZAO;
                    leitura.FATOR_MULTIP = LstLeitura[index].FATOR_MULTIP;
                    leitura.QTDE_DIGIT = LstLeitura[index].QTDE_DIGIT;
                    leitura.FASE_MEDIDR = LstLeitura[index].FASE_MEDIDR;
                    leitura.CLASSE_CONSUMO = LstLeitura[index].CLASSE_CONSUMO;
                    leitura.NOME_CONSMD = LstLeitura[index].NOME_CONSMD;
                    leitura.LEITUR_VISITA = 0;
                }
                catch (Exception ex)
                {
                    txbSincronizacao.Text += "Não foi possível atribuir valores a variaveis de leitura. Erro: " + ex.ToString();
                    throw new Exception("Não foi possível atribuir valores a variaveis de leitura. Erro: " + ex.ToString()); 
                }


                try
                {
                    //LeituraFlow.InsertorUpdate(leitura);

                    LeituraFlow.Insert(leitura);


                    if (index + 1 == tamanho && index == 0)
                    {
                        strCondicaoMensagem += "AND ((COD_EMPRT = " + LstLeitura[index].COD_EMPRT + ") AND (COD_LOCAL = " + LstLeitura[index].COD_LOCAL + ") " +
                                               "AND (NUM_RAZAO = " + LstLeitura[index].NUM_RAZAO + ") AND (MES_ANO_FATUR = " + LstLeitura[index].MES_ANO_FATUR + ") " +
                                               "AND (NUM_UC = " + LstLeitura[index].NUM_UC + ") AND (TIPO_MEDIC = '" + LstLeitura[index].TIPO_MEDIC + "'))";
                    }
                    else if (index == 0)
                    {
                        strCondicaoMensagem += "AND (((COD_EMPRT = " + LstLeitura[index].COD_EMPRT + ") AND (COD_LOCAL = " + LstLeitura[index].COD_LOCAL + ") " +
                                               "AND (NUM_RAZAO = " + LstLeitura[index].NUM_RAZAO + ") AND (MES_ANO_FATUR = " + LstLeitura[index].MES_ANO_FATUR + ") " +
                                               "AND (NUM_UC = " + LstLeitura[index].NUM_UC + ") AND (TIPO_MEDIC = '" + LstLeitura[index].TIPO_MEDIC + "'))";
                    }
                    else if (index > 0 && index + 1 < tamanho)
                    {
                        strCondicaoMensagem += "OR ((COD_EMPRT = " + LstLeitura[index].COD_EMPRT + ") AND (COD_LOCAL = " + LstLeitura[index].COD_LOCAL + ") " +
                                               "AND (NUM_RAZAO = " + LstLeitura[index].NUM_RAZAO + ") AND (MES_ANO_FATUR = " + LstLeitura[index].MES_ANO_FATUR + ") " +
                                               "AND (NUM_UC = " + LstLeitura[index].NUM_UC + ") AND (TIPO_MEDIC = '" + LstLeitura[index].TIPO_MEDIC + "'))";
                    }
                    else if (index + 1 == tamanho && index != 0)
                    {
                        strCondicaoMensagem += "OR ((COD_EMPRT = " + LstLeitura[index].COD_EMPRT + ") AND (COD_LOCAL = " + LstLeitura[index].COD_LOCAL + ") " +
                                               "AND (NUM_RAZAO = " + LstLeitura[index].NUM_RAZAO + ") AND (MES_ANO_FATUR = " + LstLeitura[index].MES_ANO_FATUR + ") " +
                                               "AND (NUM_UC = " + LstLeitura[index].NUM_UC + ") AND (TIPO_MEDIC = '" + LstLeitura[index].TIPO_MEDIC + "')))";
                    }

                }
                catch(Exception ex)
                {
                    txbSincronizacao.Text += "Erro ao atualizar leitura no PDA. Num_Uc: " + LstLeitura[index].NUM_UC +" COD_LOCAL:" + LstLeitura[index].COD_LOCAL + " NUM_RAZAO = " + LstLeitura[index].NUM_RAZAO + "MES_ANO_FATUR = " + LstLeitura[index].MES_ANO_FATUR + "TIPO_MEDIC = '" + LstLeitura[index].TIPO_MEDIC + "' Erro: "+ex.ToString()+"";
                    throw new Exception("Erro ao atualizar leitura no PDA. Num_Uc: " + LstLeitura[index].NUM_UC +" COD_LOCAL:" + LstLeitura[index].COD_LOCAL + " NUM_RAZAO = " + LstLeitura[index].NUM_RAZAO + "MES_ANO_FATUR = " + LstLeitura[index].MES_ANO_FATUR + "TIPO_MEDIC = '" + LstLeitura[index].TIPO_MEDIC + "' Erro: "+ex.ToString()+""); 
                }
                index++;

            }
            //Atualiza no webservice as leituras sincronizadas
            if (strCondicaoMensagem != "")
            {
                try
                {
                    syncService.setLeituraConfirmada(user.User, strCondicaoMensagem);
                }
                catch (Exception ex) 
                { 
                    txbSincronizacao.Text += "Erro setLeituraConfirmada" + ex.ToString();
                    throw new Exception("Erro setLeituraConfirmada" + ex.ToString()); 
                
                }
            }


            txbSincronizacao.Text = txbSincronizacao.Text + "Unidade consumidora sincronizada.\r\n";
        }

        private void syncGetCorreioEletronico()
        {
            string strCondicaoConfirmaCorreio = "";
            txbSincronizacao.Text = txbSincronizacao.Text + "Buscando Correio Eletrônico...\r\n";
            txbSincronizacao.ScrollToCaret();

            // WS_ltMobile sincronizar = new Sincronizacao.WS_ltMobile();

            int tamanho = 0;

            // WS_ltMobile sincronizar = new Sincronizacao.WS_ltMobile();

            List<LTmobile.Sincronizacao.CorreioEletronicoWS> LstCorreioEletronico = null;
            //Leitura leitura = new Leitura();
            try
            {
                LstCorreioEletronico = syncService.getCorreioEletronico(user);
            }
            catch { }

            int index = 0;
            if (LstCorreioEletronico != null)
            {
                tamanho = LstCorreioEletronico.Count();
            }

            while (tamanho > index)
            {
                LTmobileData.Data.Model.CorreioEletronico correio = new LTmobileData.Data.Model.CorreioEletronico();

                correio.COD_EMPRT = LstCorreioEletronico[index].COD_EMPRT;
                correio.MATRIC_FUNC = LstCorreioEletronico[index].MATRIC_FUNC;
                correio.ID_MSG = LstCorreioEletronico[index].ID_MSG;
                correio.ASSUNTO = LstCorreioEletronico[index].ASSUNTO;
                correio.DT_MSG = LstCorreioEletronico[index].DT_MSG;
                correio.STATUS_MSG = LstCorreioEletronico[index].STATUS_MSG;
                correio.DESC_MSG = LstCorreioEletronico[index].DESC_MSG;
                correio.TIPO_MSG = LstCorreioEletronico[index].TIPO_MSG;
                correio.STATUS_REG = "0";

                try
                {
                    CorreioEletronicoFlow.Insert(correio);

                    if (index + 1 == tamanho && index == 0)
                    {
                        strCondicaoConfirmaCorreio += " AND ID_MSG = " + LstCorreioEletronico[index].ID_MSG + "";

                    }
                    else if (index == 0)
                    {
                        strCondicaoConfirmaCorreio += " AND((ID_MSG = " + LstCorreioEletronico[index].ID_MSG + ")";

                    }
                    else if (index > 0 && index + 1 < tamanho)
                    {
                        strCondicaoConfirmaCorreio += " OR(ID_MSG = " + LstCorreioEletronico[index].ID_MSG + ")";

                    }
                    else if (index + 1 == tamanho && index != 0)
                    {
                        strCondicaoConfirmaCorreio += " OR(ID_MSG = " + LstCorreioEletronico[index].ID_MSG + "))";
                    }

                }
                catch { }
                index++;

            }

            if (strCondicaoConfirmaCorreio != "")
            {
                try
                {
                    syncService.setCorreioEletronicoConfirmado(user.User, strCondicaoConfirmaCorreio);
                }
                catch { }
            }
            txbSincronizacao.Text = txbSincronizacao.Text + "Correio eletrônico sincronizado.\r\n";
        }

        private void syncGetFoto()
        {
            txbSincronizacao.Text = txbSincronizacao.Text + "Buscando Fotos...\r\n";
            txbSincronizacao.ScrollToCaret();

            // WS_ltMobile sincronizar = new Sincronizacao.WS_ltMobile();
            int tamanho = 0;

            List<LTmobile.Sincronizacao.FotoWS> LstFoto = null;
            //Leitura leitura = new Leitura();
            try
            {
                LstFoto = syncService.getFoto(user);
            }
            catch { }

            int index = 0;
            if (LstFoto != null)
            {
                tamanho = LstFoto.Count();
            }

            while (tamanho > index)
            {
                LTmobileData.Data.Model.Fotos foto = new LTmobileData.Data.Model.Fotos();

                foto.ID_FOTO = LstFoto[index].ID_FOTO;
                foto.MES_ANO_FATUR = LstFoto[index].MES_ANO_FATUR;
                foto.TIPO_MEDIC = LstFoto[index].TIPO_MEDIC;
                foto.COD_LOCAL = LstFoto[index].COD_LOCAL;
                foto.NUM_UC = LstFoto[index].NUM_UC;
                foto.COD_EMPRT = LstFoto[index].COD_EMPRT;
                foto.NUM_RAZAO = LstFoto[index].NUM_RAZAO;
                foto.NUM_MEDIDR = LstFoto[index].NUM_MEDIDR;
                foto.NUM_SEQ_FOTO = LstFoto[index].NUM_SEQ_FOTO;
                foto.DESC_FOTO = LstFoto[index].DESC_FOTO;
                foto.USUAR_ATLZ = LstFoto[index].USUAR_ATLZ;
                foto.DATA_ATLZ = LstFoto[index].DATA_ATLZ;
                foto.HORA_ATLZ = LstFoto[index].HORA_ATLZ;
                foto.CORD_X = LstFoto[index].CORD_X;
                foto.CORD_Y = LstFoto[index].CORD_Y;

                try
                {
                    FotosFlow.InsertOrUpdate(foto);
                }
                catch { }
                index++;

            }

            txbSincronizacao.Text = txbSincronizacao.Text + "Foto sincronizado.\r\n";
        }

        private void syncGetFuncionario()
        {
            txbSincronizacao.Text = txbSincronizacao.Text + "Buscando Funcionários...\r\n";
            txbSincronizacao.ScrollToCaret();

            // WS_ltMobile sincronizar = new Sincronizacao.WS_ltMobile();
            int tamanho = 0;

            List<LTmobile.Sincronizacao.FuncionariosWS> LstFuncionario = null;
            //Leitura leitura = new Leitura();
            try
            {
                LstFuncionario = syncService.getFuncionario(user);
            }
            catch { }

            int index = 0;

            if (LstFuncionario != null)
            {
                tamanho = LstFuncionario.Count();
            }

            while (tamanho > index)
            {
                LTmobileData.Data.Model.Usuario usuario = new LTmobileData.Data.Model.Usuario();

                usuario.COD_EMPRT = LstFuncionario[index].COD_EMPRT;
                usuario.COD_LOCAL_TRAB = LstFuncionario[index].COD_LOCAL_TRAB;
                usuario.MATRIC_FUNC = LstFuncionario[index].MATRIC_FUNC;
                usuario.NOME_FUNC = LstFuncionario[index].NOME_FUNC;
                usuario.NUM_COLETR = LstFuncionario[index].NUM_COLETR;
                usuario.SENHA_FUNC = LstFuncionario[index].SENHA_FUNC;
                usuario.SITUAC_FUNC = LstFuncionario[index].SITUAC_FUNC;

                try { UsuarioFlow.InsertOrUpdate(usuario); }
                catch { }
                index++;

            }

            txbSincronizacao.Text = txbSincronizacao.Text + "Usuario sincronizado.\r\n";
       
        }

        private void syncMensagem()
        {
            string strCondicaoConfirmaMensagem = "";

            int tamanho = 0;
            // WS_ltMobile sincronizar = new Sincronizacao.WS_ltMobile();

            List<LTmobile.Sincronizacao.MensagemWS> LstMensagem = null;
            //Leitura leitura = new Leitura();
            try
            {
                LstMensagem = syncService.getMensagem(strCondicaoMensagem);
            }
            catch { }

            int index = 0;
            if (LstMensagem != null)
            {
                tamanho = LstMensagem.Count();
            }

            while (tamanho > index)
            {
                LTmobileData.Data.Model.mensagemUc mensagem = new LTmobileData.Data.Model.mensagemUc();

                mensagem.ID_MSG = LstMensagem[index].ID_MSG;
                mensagem.DESC_MSG = LstMensagem[index].DESC_MSG;
                mensagem.NUM_UC = LstMensagem[index].NUM_UC;
                mensagem.MES_ANO_FATUR = LstMensagem[index].MES_ANO_FATUR;
                mensagem.COD_LOCAL = LstMensagem[index].COD_LOCAL;
                mensagem.COD_EMPRT = LstMensagem[index].COD_EMPRT;
                mensagem.STATUS_REG = "0";
                mensagem.NUM_RAZAO = LstMensagem[index].NUM_RAZAO;
                mensagem.FLAG_SENTIDO = LstMensagem[index].FLAG_SENTIDO;
                mensagem.DT_MSG = LstMensagem[index].DT_MSG;

                try
                {
                    MensagemUcFlow.Insert(mensagem);
                    if (index + 1 == tamanho && index == 0)
                    {
                        strCondicaoConfirmaMensagem += "AND ((COD_EMPRT = " + LstMensagem[index].COD_EMPRT + ") AND (COD_LOCAL = " + LstMensagem[index].COD_LOCAL + ") " +
                                               "AND (NUM_RAZAO = " + LstMensagem[index].NUM_RAZAO + ") AND (MES_ANO_FATUR = " + LstMensagem[index].MES_ANO_FATUR + ") " +
                                               "AND (NUM_UC = " + LstMensagem[index].NUM_UC + ") AND (TIPO_MEDIC = '" + LstMensagem[index].TIPO_MEDIC + "'))";
                    }
                    else if (index == 0)
                    {
                        strCondicaoConfirmaMensagem += "AND (((COD_EMPRT = " + LstMensagem[index].COD_EMPRT + ") AND (COD_LOCAL = " + LstMensagem[index].COD_LOCAL + ") " +
                                               "AND (NUM_RAZAO = " + LstMensagem[index].NUM_RAZAO + ") AND (MES_ANO_FATUR = " + LstMensagem[index].MES_ANO_FATUR + ") " +
                                               "AND (NUM_UC = " + LstMensagem[index].NUM_UC + ") AND (TIPO_MEDIC = '" + LstMensagem[index].TIPO_MEDIC + "'))";
                    }
                    else if (index > 0 && index + 1 < tamanho)
                    {
                        strCondicaoConfirmaMensagem += "OR ((COD_EMPRT = " + LstMensagem[index].COD_EMPRT + ") AND (COD_LOCAL = " + LstMensagem[index].COD_LOCAL + ") " +
                                               "AND (NUM_RAZAO = " + LstMensagem[index].NUM_RAZAO + ") AND (MES_ANO_FATUR = " + LstMensagem[index].MES_ANO_FATUR + ") " +
                                               "AND (NUM_UC = " + LstMensagem[index].NUM_UC + ") AND (TIPO_MEDIC = '" + LstMensagem[index].TIPO_MEDIC + "'))";
                    }
                    else if (index + 1 == tamanho && index != 0)
                    {
                        strCondicaoConfirmaMensagem += "OR ((COD_EMPRT = " + LstMensagem[index].COD_EMPRT + ") AND (COD_LOCAL = " + LstMensagem[index].COD_LOCAL + ") " +
                                               "AND (NUM_RAZAO = " + LstMensagem[index].NUM_RAZAO + ") AND (MES_ANO_FATUR = " + LstMensagem[index].MES_ANO_FATUR + ") " +
                                               "AND (NUM_UC = " + LstMensagem[index].NUM_UC + ") AND (TIPO_MEDIC = '" + LstMensagem[index].TIPO_MEDIC + "')))";
                    }
                }
                catch
                { }
                index++;


            }

            if (strCondicaoConfirmaMensagem != "")
            {
                syncService.setMensagemConfirmada(strCondicaoConfirmaMensagem);
            }

            txbSincronizacao.Text = txbSincronizacao.Text + "Mensagem sincronizado.\r\n";
       
        }

        private void syncGetOcorrencia()
        {
            txbSincronizacao.Text = txbSincronizacao.Text + "Sincronizando Ocorrencia...\r\n";
            txbSincronizacao.ScrollToCaret();

            int tamanho = 0;
            // WS_ltMobile sincronizar = new Sincronizacao.WS_ltMobile();

            List<LTmobile.Sincronizacao.OcorrenciaWS> LstOcorrencia = null;
            //Leitura leitura = new Leitura();
            try
            {
                LstOcorrencia = syncService.getOcorrencia();
            }
            catch { }

            int index = 0;
            if (LstOcorrencia != null)
            {
                tamanho = LstOcorrencia.Count();
            }

            while (tamanho > index)
            {
                LTmobileData.Data.Model.Ocorrencia ocorrencia = new LTmobileData.Data.Model.Ocorrencia();

                ocorrencia.COD_EMPRT = LstOcorrencia[index].COD_EMPRT;
                ocorrencia.COD_IRREGL = LstOcorrencia[index].COD_IRREGL;
                ocorrencia.DATA_ATLZ = LstOcorrencia[index].DATA_ATLZ;
                ocorrencia.DESC_IRREGL = LstOcorrencia[index].DESC_IRREGL;
                ocorrencia.FLAG_COMPLEMENTO = LstOcorrencia[index].FLAG_COMPLEMENTO;
                ocorrencia.FLAG_IMPEDIMENTO = LstOcorrencia[index].FLAG_IMPEDIMENTO;
                ocorrencia.HORA_ATLZ = LstOcorrencia[index].HORA_ATLZ;
                ocorrencia.NUM_PRIOR = LstOcorrencia[index].NUM_PRIOR;
                ocorrencia.USUAR_ATLZ = LstOcorrencia[index].USUAR_ATLZ;
                ocorrencia.FLAG_FOTO = LstOcorrencia[index].FLAG_FOTO;
                ocorrencia.OBS_PADRAO = LstOcorrencia[index].OBS_PADRAO;

                try
                {
                    OcorrenciaFlow.InsertOrUpdate(ocorrencia);
                }
                catch { }
                index++;

            }
            txbSincronizacao.Text = txbSincronizacao.Text + "Ocorrência sincronizado.\r\n";
       
        }

        public byte[] ReadByteArrayFromFile(string fileName)
        {
            byte[] buff = null;
            if (File.Exists(fileName))
            {
                
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                long numBytes = new FileInfo(fileName).Length;
                buff = br.ReadBytes((int)numBytes);
            }
            return buff;
        }
        public static string GetPathFoto()
        {
            string PathDefaultFiles = null;
            // Define o nome da pasta onde serão salvas as fotos
            PathDefaultFiles = Utils.LocalPath + "\\Fotos\\";

            // Verifica se a pasta existe
            if (!System.IO.Directory.Exists(PathDefaultFiles))
            {
                // Cria a pasta
                System.IO.Directory.CreateDirectory(PathDefaultFiles);
            }

            return PathDefaultFiles;
        }

        private void nmSair2_Click(object sender, EventArgs e)
        {
            
        }

        private void mnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnConfigurar_Click(object sender, EventArgs e)
        {
            using (frmConfiguracao configuracao = new frmConfiguracao())
            {
                configuracao.ShowDialog();
            }
        }

        private void mnSincInicial_Click(object sender, EventArgs e)
        {
            if (frmLogin.StatusSinc == true)
            {
                MessageBox.Show("Sincronização já está em andamento. Aguarde!");
                return;
            }
            else
            {
                frmLogin.setStatusSinc(true);
            }

            if (!estaConectado())
            {
                MessageBox.Show("Não foi possível se conectar a internet");
                frmLogin.setStatusSinc(false);
                return;
            }

            try
            {
                txbSincronizacao.Text = "";

                txbSincronizacao.Text = txbSincronizacao.Text + "Conectando ao Servidor...\r\n";

                ConfigWebService configWS = new ConfigWebService();

                try
                {
                    //testa se o endereco de webservice esta preenchido.
                    if (string.IsNullOrEmpty(configWS.WebServiceCurrent))
                    {
                        throw new Exception("URL do webservice não configurado.");
                    }

                    //testa se o endereco de webservice foi preenchido corretamente.
                    try
                    {
                        syncService.Url = configWS.WebServiceCurrent;
                    }
                    catch (Exception ex) { throw new Exception("A URL do webservice é inválida."); }

                    //testa se o login foi informado.
                    if (string.IsNullOrEmpty(configWS.LoginWebService))
                    {
                        throw new Exception("Login não informado.");
                    }

                    //testa se a senha foi informada.
                    if (string.IsNullOrEmpty(configWS.SenhaWebService))
                    {
                        throw new Exception("Senha não informada.");
                    }

                    user.User = configWS.LoginWebService;
                    user.Password = configWS.SenhaWebService;

                }
                catch (Exception ex)
                {
                    throw new Exception("Falha na conexão:\n" + ex.Message);
                    txbSincronizacao.Text += "Conexão não realizada!";

                }

                DateTime data;
                txbSincronizacao.Text = txbSincronizacao.Text + "Sincronizando data...\r\n";

                try
                {
                    data = syncService.getDateDBServer(user);
                }
                catch (Exception ex)
                {
                    txbSincronizacao.Text += "Falha ao conectar com webservice, verifique sua conexão com a internet. Ex: " + ex.ToString();
                    MessageBox.Show("Falha ao conectar com webservice, verifique sua conexão com a internet. Ex: " + ex.ToString() + "");
                    return;
                    //throw new Exception("Falha ao conectar com webservice, verifique sua conexão com a internet. Ex: " + ex + ""); 
                }

                try
                {
                    MobileTools.SystemTimeInfo.UpdateSystemTime(data);
                    txbSincronizacao.Text = txbSincronizacao.Text + "Data sincronizada.\r\n";
                    txbSincronizacao.Text = txbSincronizacao.Text + "Iniciando sincronização de dados em: " + string.Format("{0:HH:mm:ss}", DateTime.Now) + "\r\n";
                }
                catch (Exception ex)
                {
                    txbSincronizacao.Text += "Erro ao atualizar data do PDA: " + ex.ToString();
                    return;
                }


                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    syncSetLeitura();
                    syncSetMensagem();
                    syncSetLeituraProvisoria();
                    syncSetFotos();
                    syncSetCorreioEletronico();

                    CorreioEletronicoFlow.DeleteTodos();
                    FotosFlow.DeleteTodos();
                    //         LeituraFlow.DeleteTodos();
                    LeituraProvisoriaFlow.DeleteTodos();
                    MensagemUcFlow.DeleteTodos();
                    OcorrenciaFlow.DeleteTodos();
                    UsuarioFlow.DeleteTodos();

                    syncGetFuncionario();
                    syncLeitura();
                    syncMensagem();
                    syncGetCorreioEletronico();
                    syncGetOcorrencia();
                    txbSincronizacao.Text = txbSincronizacao.Text + "Sincronização Concluída";

                    MessageBox.Show("sincronização concluída com sucesso!");
                    //  syncGetFoto();*/
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    frmLogin.setStatusSinc(false);
                    Cursor.Current = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha na conexão:\n" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                txbSincronizacao.Text += "Conexão não realizada!";
                return;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                frmLogin.setStatusSinc(true);
            }
        }

        private void frmSincronizacao_KeyDown(object sender, KeyEventArgs e)
        {

            if ((e.KeyCode == System.Windows.Forms.Keys.Up))
            {
                // Up
                txbSincronizacao.Focus();
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Down))
            {
                // Down
                txbSincronizacao.Focus();
            }
 

        }

        private void frmSincronizacao_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 115 || e.KeyValue == 114)
            {
                Thread.Sleep(1000);
                Process P = Process.GetProcessById(Process.GetCurrentProcess().Id);
                SetForegroundWindow(P.MainWindowHandle);
            }
        }
    }            
}
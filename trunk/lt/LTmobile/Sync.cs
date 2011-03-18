using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using LTmobile.Sincronizacao;
using System.Windows.Forms;
using LTmobileData.Data.Model;
using LTmobileData.Data.BFL;
using LTmobileData.Utils;
using System.IO;
using LTmobileData.Data.Helper;

namespace LTmobile
{
    public class Sync
    {


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
        /// Condição para atualizar mensagem
        /// </summary>
        string strCondicaoMensagem = "";

        /// <summary>
        /// Inicia a sincronização
        /// </summary>
        public void IniciaSinc()
        {
            if (frmLogin.StatusSinc == true)
            {                
                return;
            }
            else
            {
                frmLogin.setStatusSinc(true);
            }


            try
            {
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
                    catch (Exception ex)
                    {
                        throw new Exception("A URL do webservice é inválida.");
                    }

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
                }



                try
                {
                    DateTime data = DateTime.Now;
                    try
                    {
                        data = syncService.getDateDBServer(user);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Falha ao conectar com webservice, verifique sua conexão com a internet. Ex: " + ex + "");
                    }

                    MobileTools.SystemTimeInfo.UpdateSystemTime(data);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                    //return;
                }

                try
                {
                    syncSetLeitura();
                    syncSetMensagem();
                    syncSetLeituraProvisoria();
                    syncSetFotos();
                    syncSetCorreioEletronico();


                    syncLeitura();
                    syncMensagem();
                    syncGetCorreioEletronico();
                    //syncGetOcorrencia();

                    //MessageBox.Show("Sincronização concluída com sucesso");
                    /*  syncGetFuncionario();
                      syncGetOcorrencia();                
                      syncGetFoto();*/
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao sincronizar: " + ex);
                    //throw new Exception(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                }
            }
            catch (Exception ex)
            {
                //throw new Exception("Erro ao sincronizar: " + ex);
                //MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                
                frmLogin.setStatusSinc(false);
            }
           

        }

        public void syncSetLeitura()
        {
            string Condicao = "";

            //*** Envia dados ao servidor***\\

            List<Leitura> LeituraNotSync = LeituraFlow.getLeituraNotSync();
            if (LeituraNotSync.Count <= 0) return;
            else
            {
                Sincronizacao.LeituraWS[] lstLeituraNotSync = SyncUtil<Leitura, Sincronizacao.LeituraWS>.ConvertModelToWSObject(LeituraNotSync);
                try
                {

                    List<ErroLeituraWS> Erros = syncService.setLeitura(lstLeituraNotSync);

                    if (Erros.Count > 0)
                    {

                        foreach (ErroLeituraWS e in Erros)
                        {
                            if (e.EXCEPTION == "")
                            {
                                Condicao += "(NUM_UC=" + e.NUM_UC + " AND TIPO_MEDIC= '" + e.TIPO_MEDIC + "') ";
                                Condicao += "OR ";
                            }
                        }
                        Condicao = Condicao.Substring(0, (Condicao.Length - 3));
                        LeituraFlow.AlteraStatusLeitura(Condicao);
                    }
                    
/*
                    Condicao += "(STATUS_REG = 2) AND (";


                    foreach (Leitura l in LeituraNotSync)
                    {
                        Condicao += "NUM_UC=" + l.NUM_UC + " AND TIPO_MEDIC= '" + l.TIPO_MEDIC+"' ";
                        Condicao += "OR ";
                            
                    }
                    Condicao = Condicao.Substring(0, (Condicao.Length - 3));
                    Condicao += ") ";

                    if (Erros.Count > 0)
                    {

                        foreach (ErroLeituraWS e in Erros)
                        {
                                                        
                            Condicao += "AND (NOT (NUM_UC = "+e.NUM_UC+") OR NOT (TIPO_MEDIC = '"+e.TIPO_MEDIC+"'))";


                        }
                    }

                    */


                    //LeituraFlow.AlteraStatusLeitura(Condicao);



                }
                catch(Exception ex)
                {
                }
            }
        }

        public void syncSetCorreioEletronico()
        {
            string strCondicao = "";
            //*** Envia dados ao servidor***\\

            List<CorreioEletronico> CorreioEletronicoNotSync = CorreioEletronicoFlow.getCorreioEletronicoNotSync();

            if (CorreioEletronicoNotSync.Count <= 0) return;
            else
            {
                Sincronizacao.CorreioEletronicoWS[] lstCorreioEletronicoNotSync = SyncUtil<CorreioEletronico, Sincronizacao.CorreioEletronicoWS>.ConvertModelToWSObject(CorreioEletronicoNotSync);
                try
                {
                    List<ErroCorreioEletronicoWS> Erros = syncService.setCorreioEletronico(lstCorreioEletronicoNotSync);

                    if (Erros.Count > 0)
                    {
                        //
                        strCondicao += "(STATUS_REG = 2 AND TIPO_MSG = 'C' AND STATUS_MSG = 0) AND (";


                        foreach (ErroCorreioEletronicoWS e in Erros)
                        {

                            strCondicao += "(ID_MSG = " + e.ID_MSG + ") ";
                            strCondicao += "OR ";

                        }
                        strCondicao = strCondicao.Substring(0, (strCondicao.Length - 3));
                        strCondicao += ") ";
                        CorreioEletronicoFlow.AlteraStatusCorreioEletronico(strCondicao);
                    }

                    


                   /* if (Erros.Count > 0)
                    {                        

                        foreach (ErroCorreioEletronicoWS e in Erros)
                        {
                            strCondicao += " AND (NOT(ID_MSG = " + e.ID_MSG + "))";
                        }
                    }
                    CorreioEletronicoFlow.AlteraStatusCorreioEletronico(strCondicao);*/

                }
                catch
                {
                }
            }
        }

        public void syncSetFotos()
        {
            string Condicao = "";
            //*** Envia dados ao servidor***\\

            List<Fotos> FotosNotSync = FotosFlow.getFotosNotSync();

            if (FotosNotSync.Count <= 0) return;
            else
            {
                Sincronizacao.FotoWS[] lstFotosNotSync = SyncUtil<Fotos, Sincronizacao.FotoWS>.ConvertModelToWSObject(FotosNotSync);

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
                        catch { }
                    }
                    i++;

                }


                  Condicao += "(STATUS_REG = 2) AND (";


                    foreach (ErroFotoWS e in Erros)
                    {
                        if (e.NUM_UC != 0)
                        {
                            if (e.EXCEPTION == "")
                            {
                                Condicao += "(NUM_UC=" + e.NUM_UC + " AND TIPO_MEDIC= '" + e.TIPO_MEDIC + "') ";
                                Condicao += "OR ";
                            }
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


            }
        }

        public void syncSetLeituraProvisoria()
        {
            string Condicao = "";

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
                            if (e.EXCEPTION == "")
                            {
                                Condicao += "(NUM_UC_REF = '" + e.NUM_UC_REF + "' AND TIPO_MEDIC= '" + e.TIPO_MEDIC + "' AND MES_ANO_FATUR = " + e.MES_ANO_FATUR + " AND COD_LOCAL = " + e.COD_LOCAL + " " +
                                   "AND COD_EMPRT = " + e.COD_EMPRT + " AND NUM_MEDIDR = " + e.NUM_MEDIDR + " AND NUM_RAZAO = '" + e.NUM_RAZAO + "')";
                                Condicao += "OR ";
                            }

                        }
                        Condicao = Condicao.Substring(0, (Condicao.Length - 3));
                        Condicao += ") ";
                        LeituraProvisoriaFlow.AlteraStatusLeituraProvisoria(Condicao);
                    }

                }
                catch
                { }
            }
        }

        public void syncSetMensagem()
        {
            string Condicao = "";

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
                            if (e.EXCEPTION == "")
                            {
                                Condicao += "(NUM_UC=" + e.NUM_UC + " AND TIPO_MEDIC= '" + e.TIPO_MEDIC + "' AND ID_MSG = '" + e.ID_MSG + "') ";
                                Condicao += "OR ";
                            }

                        }
                        Condicao = Condicao.Substring(0, (Condicao.Length - 3));
                        Condicao += ") ";
                        MensagemUcFlow.AlteraStatusMensagem(Condicao);
                    }
                    //MensagemUcFlow.AlteraStatusMensagem(Condicao);

                }
                catch(Exception ex)
                { }
            }

        }

        /// <summary>
        /// Sincroniza tabela de leitura
        /// </summary>
        public void syncLeitura()
        {
            // WS_ltMobile sincronizar = new Sincronizacao.WS_ltMobile();

            List<LTmobile.Sincronizacao.LeituraWS> LstLeitura = null;

            int tamanho = 0;
            //Leitura leitura = new Leitura();
            try
            {
                LstLeitura = syncService.getLeituraWS(user);
            }
            catch(Exception ex) { }

            int index = 0;
            if (LstLeitura != null)
            {
                tamanho = LstLeitura.Count();
            }
           

            while (tamanho > index)
            {
                LTmobileData.Data.Model.Leitura leitura = new LTmobileData.Data.Model.Leitura();
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
                    // strConfirmaLeitura += " AND (NOT(COD_EMPRT = " + e.COD_EMPRT + ") OR NOT(COD_LOCAL = " + e.COD_LOCAL + ") OR NOT(NUM_RAZAO = " + e.NUM_RAZAO + ") " +
                    //                            "OR NOT(MES_ANO_FATUR = " + e.MES_ANO_FATUR + ") OR NOT(NUM_UC = " + e.NUM_UC + ") OR NOT(TIPO_MEDIC = '" + e.TIPO_MEDIC + "'))";
                    string erro = ex.ToString();
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
                catch (Exception ex) { MessageBox.Show("Erro setLeituraConfirmada" + ex); }
            }

        }

        public void syncGetCorreioEletronico()
        {
            string strCondicaoConfirmaCorreio = "";

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
        }

        public void syncGetFoto()
        {

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

        }

        public void syncGetFuncionario()
        {

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

        }

        public void syncMensagem()
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


        }

        public void syncGetOcorrencia()
        {
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


    }

}

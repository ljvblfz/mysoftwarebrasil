using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SPCadMobileDataWeb.Data.DAL;
using SPCadMobileDataWeb.Data.Model;


namespace SPCadMobileDataWeb.Data.BFL
{
    public class CadastroFlow
    {
        private Dao<Cadastro> _cadastroDAO = DaoFactory.getCadastro();

        #region CRUD

        public void Insert(Cadastro cadastro)
        {
            try
            {
                _cadastroDAO.Insert(cadastro);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível inserir!\n" + ex.Message, (Exception)ex);
            }
        }

        public void Delete(Cadastro cadastro)
        {
            try
            {
                _cadastroDAO.Delete(cadastro);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível deletar!\n" + ex.Message, (Exception)ex);
            }
        }

        public void Update(Cadastro cadastro)
        {
            try
            {
                _cadastroDAO.Update(cadastro);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar!\n" + ex.Message, (Exception)ex);
            }
        }


        #endregion

        /// <summary>
        /// Retorna lista de Distrito
        /// </summary>
        /// <returns></returns>
        public List<Cadastro> GetList()
        {
            try
            {
                List<Cadastro> cadListFull = _cadastroDAO.Select();
                List<Cadastro> cadList = new List<Cadastro>();

                foreach (Cadastro cad in cadListFull)
                {
                    cadList.Add(verifyCadastroAlterDownload(cad));
                }

                return cadList;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar!\n" + ex.Message, (Exception)ex);
            }
        }

        public List<Cadastro> GetList(int codDistrito, int codSetor, int codRota, int funcionario, bool parcial)
        {
            string sitCarga = string.Empty;

            if (parcial)
            {
                sitCarga = "'2'";// 2 = roteiro liberado
            }
            else
            {
                sitCarga = "'2','3'";// 2 = roteiro liberado, 3 = carregado
            }

            try
            {
                string sql = string.Format(@"Select ca.ID_CADAST,ca.COD_DISTRT,ca.NUM_SETOR,ca.COD_ROTA,ca.NUM_MATRIC,ca.NOM_CLIENT,ca.TIP_LOGRD,ca.NOM_LOGRD
                                            ,ca.NUM_IMOV,ca.NUM_IMOV_ALTER,ca.TIP_COMPL,ca.TIP_COMPL_ALTER,ca.INF_COMPL,ca.INF_COMPL_ALTER,ca.NOM_BAIRR,ca.NOM_CIDAD
                                            ,ca.COND_IMOV,ca.COND_IMOV_ALTER,ca.PREVS_FIM_OBRA,ca.NUM_FACE,ca.NUM_SEQ,ca.QTD_ECONOM_RES,ca.QTD_ECONOM_COM
                                            ,ca.QTD_ECONOM_IND,ca.QTD_ECONOM_PUB,ca.QTD_ECONOM_RES_ALTER,ca.QTD_ECONOM_COM_ALTER,ca.QTD_ECONOM_IND_ALTER
                                            ,ca.QTD_ECONOM_PUB_ALTER,ca.RAMO_ATIVD_1,ca.RAMO_ATIVD_2,ca.RAMO_ATIVD_3,ca.RAMO_ATIVD_4,ca.RAMO_ATIVD_1_ALTER
                                            ,ca.RAMO_ATIVD_2_ALTER,ca.RAMO_ATIVD_3_ALTER,ca.RAMO_ATIVD_4_ALTER,ca.TARF_SOCIAL,ca.TARF_SOCIAL_IMCOMP
                                            ,ca.OBS_TARFC_SOCIAL_IMCOMP,ca.FONTE_ALTERN,ca.FONTE_ALTERN_ALTER,ca.FLG_PISCIN,ca.FLG_PISCIN_ALTER,ca.FLG_RESERT
                                            ,ca.FLG_RESERT_ALTER,ca.SIT_IMOVEL,ca.SIT_IMOVEL_ALTER,ca.OBS_VISITA,ca.SIT_PONTO_SERVC,ca.SIT_PONTO_SERVC_ALTER
                                            ,ca.NUM_PONTO_SERVC,ca.LOCLZ_PADRAO,ca.LOCLZ_PADRAO_ALTER,ca.TIP_PADRAO,ca.TIP_PADRAO_ALTER,ca.PADRAO_LACRADO
                                            ,ca.ELIMND_AR,ca.EXISTE_MEDIDR,ca.POSSUI_TORNR_PADRAO,ca.NUM_MEDIDR,ca.NUM_MEDIDR_ALTER,ca.LEITURA,ca.QTD_DIGIT_MEDIDR
                                            ,ca.QTD_DIGIT_MEDIDR_ALTER,ca.CLASS_METRLG,ca.CLASS_METRLG_ALTER,ca.MEDIDR_LACRADO,ca.FLG_SEGND_LIGAC,ca.NUM_MEDIDR_2
                                            ,ca.LEITURA_2,ca.QTD_DIGIT_MEDIDR_2,ca.CLASS_METRLG_2,ca.MEDIDR_LACRADO_2,ca.DAT_INSTAL,ca.VETOR_OCORRC,ca.OBS_IMPDM
                                            ,ca.SUSPEI_FRAUDE,ca.OBS_SUSPEI_FRAUDE,ca.EXPCTV_CONSM,ca.COD_FUNCN,ca.COORD_X,ca.COORD_Y,ca.DAT_VISITA,ca.STATUS_EXEC
                                            ,ca.OBS_COMPL,ca.DATAGPS,ca.VERSAO,ca.USU_MOVIMENTACAO,ca.DT_MOVIMENTACAO,ca.IP_MOVIMENTACAO
                                            ,di.SITUACAO_CARGA
                                            from TB_CADASTRO ca                                            
                                            inner join TB_DISTRIBUICAO di on(di.COD_DISTRT = ca.COD_DISTRT and di.NUM_SETOR = ca.NUM_SETOR and di.COD_ROTA = ca.COD_ROTA)
                                            where ca.COD_DISTRT = {0} 
                                            and ca.NUM_SETOR = {1}
                                            and ca.COD_ROTA = {2}                                            
                                            and di.SITUACAO_CARGA in({4})
                                            and ca.STATUS_EXEC in('0','2')
                                            and di.COD_FUNCN = {3}
                                            order by ca.COD_DISTRT, ca.NUM_SETOR, ca.COD_ROTA", codDistrito, codSetor, codRota, funcionario, sitCarga);

                List<Cadastro> cadList = _cadastroDAO.CurrentPersistenceObject.LoadData(sql);
                List<Cadastro> cadListSend = new List<Cadastro>();

                foreach (Cadastro cad in cadList)
                {
                    cadListSend.Add(verifyCadastroAlterDownload(cad));
                }

                return cadListSend;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, (Exception)ex);
            }
        }

        public void InsertOrUpdate(Cadastro item)
        {
            try
            {
                //Cadastro cad = verifyCadastroAlterUpload(item);

                string sql = string.Empty;

                _cadastroDAO.InsertOrUpdate(item);               

            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }

        private Cadastro verifyCadastroAlterUpload(Cadastro item)
        {
            Cadastro cad = item;

            if (cad.NumeroImovel == cad.NumeroImovelAlter)
                cad.NumeroImovelAlter = null;

            if (cad.TipoComplemento == cad.TipoComplementoAlter)
                cad.TipoComplementoAlter = null;

            if (cad.InformacaoComplementar == cad.InformacaoComplementarAlter)
                cad.InformacaoComplementarAlter = null;

            if (cad.CondicaoImovel == cad.CondicaoImovelAlter)
                cad.CondicaoImovelAlter = null;

            if (cad.QtdeEconomiasResidencial == cad.QtdeEconomiasResidencialAlter)
                cad.QtdeEconomiasResidencialAlter = null;

            if (cad.QtdeEconomiasComercial == cad.QtdeEconomiasComercialAlter)
                cad.QtdeEconomiasComercialAlter = null;

            if (cad.QtdeEconomiasIndustrial == cad.QtdeEconomiasIndustrialAlter)
                cad.QtdeEconomiasIndustrialAlter = null;

            if (cad.QtdeEconomiasPublica == cad.QtdeEconomiasPublicaAlter)
                cad.QtdeEconomiasPublicaAlter = null;

            if (cad.RamoAtividade1 == cad.RamoAtividade1Alter)
                cad.RamoAtividade1Alter = null;

            if (cad.RamoAtividade2 == cad.RamoAtividade2Alter)
                cad.RamoAtividade2Alter = null;

            if (cad.RamoAtividade3 == cad.RamoAtividade3Alter)
                cad.RamoAtividade3Alter = null;

            if (cad.RamoAtividade4 == cad.RamoAtividade4Alter)
                cad.RamoAtividade4Alter = null;
            
            if (cad.FonteAlternativa == cad.FonteAlternativaAlter)
                cad.FonteAlternativaAlter = null;

            if (cad.Piscina == cad.PiscinaAlter)
                cad.PiscinaAlter = null;

            if (cad.Reservatorio == cad.ReservatorioAlter)
                cad.ReservatorioAlter = null;

            if (cad.SituacaoImovel == cad.SituacaoImovelAlter)
                cad.SituacaoImovelAlter = null;

            if (cad.SituacaoPontoServico == cad.SituacaoPontoServicoAlter)
                cad.SituacaoPontoServicoAlter = null;

            if (cad.LocalizacaoPadrao == cad.LocalizacaoPadraoAlter)
                cad.LocalizacaoPadraoAlter = null;

            if (cad.TipoPadrao == cad.TipoPadraoAlter)
                cad.TipoPadraoAlter = null;

            if (cad.NumeroMedidor == cad.NumeroMedidorAlter)
                cad.NumeroMedidorAlter = null;

            if (cad.QtdeDigitosMedidor == cad.QtdeDigitosMedidorAlter)
                cad.QtdeDigitosMedidorAlter = null;

            if (cad.ClasseMetrologica == cad.ClasseMetrologicaAlter)
                cad.ClasseMetrologicaAlter = null;

            return cad;
        }

        private Cadastro verifyCadastroAlterDownload(Cadastro item)
        {
            Cadastro cad = item;

            if (cad.NumeroImovelAlter == null)
            {
                cad.NumeroImovelAlter = cad.NumeroImovel;
            }

            if (cad.TipoComplementoAlter == null)
                cad.TipoComplementoAlter = cad.TipoComplemento;

            if (cad.InformacaoComplementarAlter == null)
                cad.InformacaoComplementarAlter = cad.InformacaoComplementar;

            if (cad.CondicaoImovelAlter == null)
                cad.CondicaoImovelAlter = cad.CondicaoImovel;

            if (cad.QtdeEconomiasResidencialAlter == null)
                cad.QtdeEconomiasResidencialAlter = cad.QtdeEconomiasResidencial;

            if (cad.QtdeEconomiasComercialAlter == null)
                cad.QtdeEconomiasComercialAlter = cad.QtdeEconomiasComercial;

            if (cad.QtdeEconomiasIndustrialAlter == null)
                cad.QtdeEconomiasIndustrialAlter = cad.QtdeEconomiasIndustrial;

            if (cad.QtdeEconomiasPublicaAlter == null)
                cad.QtdeEconomiasPublicaAlter = cad.QtdeEconomiasPublica;

            if (cad.RamoAtividade1Alter == null)
                cad.RamoAtividade1Alter = cad.RamoAtividade1;

            if (cad.RamoAtividade2Alter == null)
                cad.RamoAtividade2Alter = cad.RamoAtividade2;

            if (cad.RamoAtividade3Alter == null)
                cad.RamoAtividade3Alter = cad.RamoAtividade3;

            if (cad.RamoAtividade4Alter == null)
                cad.RamoAtividade4Alter = cad.RamoAtividade4;

            if (cad.FonteAlternativaAlter == null)
                cad.FonteAlternativaAlter = cad.FonteAlternativa;

            if (cad.PiscinaAlter == null)
                cad.PiscinaAlter = cad.Piscina;

            if (cad.ReservatorioAlter == null)
                cad.ReservatorioAlter = cad.Reservatorio;

            if (cad.SituacaoImovelAlter == null)
                cad.SituacaoImovelAlter = cad.SituacaoImovel;

            if (cad.SituacaoPontoServicoAlter == null)
                cad.SituacaoPontoServicoAlter = cad.SituacaoPontoServico;

            if (cad.LocalizacaoPadraoAlter == null)
                cad.LocalizacaoPadraoAlter = cad.LocalizacaoPadrao;

            if (cad.TipoPadraoAlter == null)
                cad.TipoPadraoAlter = cad.TipoPadrao;

            if (cad.NumeroMedidorAlter == null)
                cad.NumeroMedidorAlter = cad.NumeroMedidor;

            if (cad.QtdeDigitosMedidorAlter == null)
                cad.QtdeDigitosMedidorAlter = cad.QtdeDigitosMedidor;

            if (cad.ClasseMetrologicaAlter == null)
                cad.ClasseMetrologicaAlter = cad.ClasseMetrologica;

            return cad;
        }
    }
}

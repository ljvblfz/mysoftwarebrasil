using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SPCadDesktopData.Data.DAL;
using SPCadDesktopData.Data.Model;
using CommonHelpDesktop;
using GDA.Sql;
using GDA;


namespace SPCadDesktopData.Data.BFL
{
    public class CadastroFlow
    {
        private Dao<Cadastro> _cadastroDAO = DaoFactory.getCadastro();
        private Dao<CadastroAuxiliar> _cadastroAuxDAO = DaoFactory.getCadastroAuxiliar();

        #region SQL

        private string sqlBase = @"
                                    SELECT
	                                     F.NOM_FUNCN AS NOME  
	                                    ,CA.COD_DISTRT
	                                    ,CA.NUM_SETOR
	                                    ,CA.COD_ROTA
	                                    ,CA.NUM_MATRIC
	                                    ,CA.NOM_CLIENT
	                                    ,CA.TIP_LOGRD
	                                    ,CA.NOM_LOGRD
	                                    ,CA.NUM_IMOV
	                                    ,CA.NUM_IMOV_ALTER
	                                    ,CA.TIP_COMPL
	                                    ,CA.TIP_COMPL_ALTER
	                                    ,CA.INF_COMPL
	                                    ,CA.INF_COMPL_ALTER
	                                    ,CA.NOM_BAIRR
	                                    ,CA.NOM_CIDAD
	                                    ,CA.COND_IMOV
	                                    ,CA.COND_IMOV_ALTER
	                                    ,CA.PREVS_FIM_OBRA
	                                    ,CA.NUM_FACE
	                                    ,CA.NUM_SEQ
	                                    ,CA.QTD_ECONOM_RES
	                                    ,CA.QTD_ECONOM_COM
	                                    ,CA.QTD_ECONOM_IND
	                                    ,CA.QTD_ECONOM_PUB
	                                    ,CA.QTD_ECONOM_RES_ALTER
	                                    ,CA.QTD_ECONOM_COM_ALTER
	                                    ,CA.QTD_ECONOM_IND_ALTER
	                                    ,CA.QTD_ECONOM_PUB_ALTER
	                                    ,CA.RAMO_ATIVD_1
	                                    ,CA.RAMO_ATIVD_2
	                                    ,CA.RAMO_ATIVD_3
	                                    ,CA.RAMO_ATIVD_4
	                                    ,CA.RAMO_ATIVD_1_ALTER
	                                    ,CA.RAMO_ATIVD_2_ALTER
	                                    ,CA.RAMO_ATIVD_3_ALTER
	                                    ,CA.RAMO_ATIVD_4_ALTER
	                                    ,CA.TARF_SOCIAL
	                                    ,CA.TARF_SOCIAL_IMCOMP
	                                    ,CA.OBS_TARFC_SOCIAL_IMCOMP
	                                    ,CA.FONTE_ALTERN
	                                    ,CA.FONTE_ALTERN_ALTER
	                                    ,CA.FLG_PISCIN
	                                    ,CA.FLG_PISCIN_ALTER
	                                    ,CA.FLG_RESERT
	                                    ,CA.FLG_RESERT_ALTER
	                                    ,CA.SIT_IMOVEL
	                                    ,CA.SIT_IMOVEL_ALTER
	                                    ,CA.OBS_VISITA
	                                    ,CA.SIT_PONTO_SERVC
	                                    ,CA.SIT_PONTO_SERVC_ALTER
	                                    ,CA.NUM_PONTO_SERVC
	                                    ,CA.LOCLZ_PADRAO
	                                    ,CA.LOCLZ_PADRAO_ALTER
	                                    ,CA.TIP_PADRAO
	                                    ,CA.TIP_PADRAO_ALTER
	                                    ,CA.PADRAO_LACRADO
	                                    ,CA.ELIMND_AR
	                                    ,CA.EXISTE_MEDIDR
	                                    ,CA.POSSUI_TORNR_PADRAO
	                                    ,CA.NUM_MEDIDR
	                                    ,CA.NUM_MEDIDR_ALTER
	                                    ,CA.LEITURA
	                                    ,CA.QTD_DIGIT_MEDIDR
	                                    ,CA.QTD_DIGIT_MEDIDR_ALTER
	                                    ,CA.CLASS_METRLG
	                                    ,CA.CLASS_METRLG_ALTER
	                                    ,CA.MEDIDR_LACRADO
	                                    ,CA.FLG_SEGND_LIGAC
	                                    ,CA.NUM_MEDIDR_2
	                                    ,CA.LEITURA_2
	                                    ,CA.QTD_DIGIT_MEDIDR_2
	                                    ,CA.CLASS_METRLG_2
	                                    ,CA.MEDIDR_LACRADO_2
	                                    ,CA.DAT_INSTAL
	                                    ,CA.VETOR_OCORRC
	                                    ,CA.OBS_IMPDM
	                                    ,CA.SUSPEI_FRAUDE
	                                    ,CA.OBS_SUSPEI_FRAUDE
	                                    ,CA.EXPCTV_CONSM
	                                    ,CA.COD_FUNCN
	                                    ,CA.COORD_X
	                                    ,CA.COORD_Y
	                                    ,CA.DAT_VISITA
	                                    ,CA.STATUS_EXEC
	                                    ,CA.OBS_COMPL
	                                    ,CA.DATAGPS
	                                    ,CA.VERSAO
	                                    ,CA.USU_MOVIMENTACAO
	                                    ,CA.DT_MOVIMENTACAO
	                                    ,CA.IP_MOVIMENTACAO
	                                    ,CA.COD_LOTE_EXP
	                                    ,CA.ID_CADAST
	                                    ,CA.ID_CADAST_TEMP 
	                                    ,CO.DES_TIP_COMPL
	                                    ,RA1.DES_RAMO_ATIVD RamoAtivDesc1
	                                    ,RA2.DES_RAMO_ATIVD RamoAtivDesc2
	                                    ,RA3.DES_RAMO_ATIVD RamoAtivDesc3
	                                    ,RA4.DES_RAMO_ATIVD RamoAtivDesc4
	                                    ,RA1O.DES_RAMO_ATIVD RamoAtivDescOrig1
	                                    ,RA2O.DES_RAMO_ATIVD RamoAtivDescOrig2
	                                    ,RA3O.DES_RAMO_ATIVD RamoAtivDescOrig3
	                                    ,RA4O.DES_RAMO_ATIVD RamoAtivDescOrig4
	                                    ,DST.NOM_DISTRT SIGLA_DISTRT

                                    FROM TB_CADASTRO CA

	                                    LEFT JOIN TB_TIPO_COMPLEMENTO CO ON (CO.TIP_COMPL = CA.TIP_COMPL) 
	                                    LEFT JOIN TB_RAMO_ATIVIDADE RA1 ON (RA1.COD_RAMO_ATIVD = CA.RAMO_ATIVD_1_ALTER)
	                                    LEFT JOIN TB_RAMO_ATIVIDADE RA2 ON (RA2.COD_RAMO_ATIVD = CA.RAMO_ATIVD_2_ALTER)
	                                    LEFT JOIN TB_RAMO_ATIVIDADE RA3 ON (RA3.COD_RAMO_ATIVD = CA.RAMO_ATIVD_3_ALTER)
	                                    LEFT JOIN TB_RAMO_ATIVIDADE RA4 ON (RA4.COD_RAMO_ATIVD = CA.RAMO_ATIVD_4_ALTER)
	                                    LEFT JOIN TB_RAMO_ATIVIDADE RA1O ON (RA1O.COD_RAMO_ATIVD = CA.RAMO_ATIVD_1)
	                                    LEFT JOIN TB_RAMO_ATIVIDADE RA2O ON (RA2O.COD_RAMO_ATIVD = CA.RAMO_ATIVD_2)
	                                    LEFT JOIN TB_RAMO_ATIVIDADE RA3O ON (RA3O.COD_RAMO_ATIVD = CA.RAMO_ATIVD_3)
	                                    LEFT JOIN TB_RAMO_ATIVIDADE RA4O ON (RA4O.COD_RAMO_ATIVD = CA.RAMO_ATIVD_4)
	                                    LEFT JOIN TB_DISTRITO DST ON (DST.COD_DISTRT = CA.COD_DISTRT)
	                                    LEFT JOIN TB_FUNCIONARIO F ON CA.COD_FUNCN = F.COD_FUNCN
                                        {0}";

        #endregion

        #region CRUD

        public void Insert(Cadastro cadastro)
        {
            try
            {
                //cadastro.StatusReg = "3";
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
            catch (GDAException ex)
            {
                throw new GDAException("Não foi possível atualizar!\n" + ex.Message, (Exception)ex);
            }
        }

        #endregion

        public CadastroAuxiliar getCadAuxById(long idCad)
        {
            string sql = string.Format("select * from tb_cadastro where id_cadast = {0}", idCad);

            return _cadastroAuxDAO.CurrentPersistenceObject.LoadOneData(sql);
        }

        //Atualiza a informação adicional apartir de um cadastro auxiliar.
        public void UpdateInfoAdd(CadastroAuxiliar cadAux)
        {
            try
            {
                long cadastro = cadAux.Id;
                long matricula = cadAux.Matricula;
                string vetorOcor = cadAux.VetorOcorrencia;

                string sql = string.Format(@"UPDATE TB_CADASTRO
                                            SET 
                                               STATUS_REG = '2',
                                               vetor_ocorrc = '{2}'                                            
                                            WHERE ID_CADAST = {0} and NUM_MATRIC = {1}", cadastro, matricula, vetorOcor);

                _cadastroDAO.CurrentPersistenceObject.ExecuteCommand(sql);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar!\n" + ex.Message, (Exception)ex);
            }
        }

        public void InsertOrUpdate(Cadastro cadastro)
        {
            try
            {
                //cadastro.StatusReg = "2";
                _cadastroDAO.InsertOrUpdate(cadastro);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível inserir ou atualizar!\n" + ex.Message, (Exception)ex);
            }
        }

        /// <summary>
        /// Retorna lista completa de cadastro por parâmetro informado.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public List<Cadastro> GetListCadastroByParam(string p, int distrito, int setor, int rota)
        {
            string c = string.Empty;

            switch (p)
            {
                case "TD":
                    break;
                case "NV": c = " AND CA.STATUS_EXEC = 0";
                    break;
                case "EX": c = " AND CA.STATUS_EXEC = 1";
                    break;
                case "IE": c = " AND CA.STATUS_EXEC = 2";
                    break;
            }

            string sql = string.Format(@"SELECT  CA.*, CO.DES_TIP_COMPL FROM TB_CADASTRO CA
                                       LEFT JOIN TB_TIPO_COMPLEMENTO CO ON (CO.TIP_COMPL = CA.TIP_COMPL)
                                       INNER JOIN TB_OCORRENCIA OCO ON (OCO.TIP_COMPL = OCO.TIP_COMPL)
                                       WHERE CA.COD_DISTRT = {0} AND CA.NUM_SETOR = {1} AND CA.COD_ROTA = {2} {3} ORDER BY CA.NUM_MATRIC, CA.NUM_SEQ, CA.NUM_PONTO_SERVC", distrito, setor, rota, c);

            return _cadastroDAO.CurrentPersistenceObject.LoadData(sql);
        }

        public List<Cadastro> GetListCadastroByParam(int distrito, int setor, int rota, int? codFunc, SituacaoPesqiosaEnum situac, string[] lograd, string bairro, string sqlAdcional)
        {
            string where = "";
            if (distrito > 0) where += " and CA.COD_DISTRT = " + distrito.ToString();
            if (setor > 0) where += " and NUM_SETOR = " + setor.ToString();
            if (rota > 0) where += " and COD_ROTA = " + rota.ToString();

            if (codFunc != null && codFunc > 0) where += " and COD_FUNCN = " + codFunc.ToString();
            if (!string.IsNullOrEmpty(bairro)) where += " and NOM_BAIRR like '" + bairro.ToString() + "%'";
            if (lograd != null && lograd.Length > 0) where += string.Format(" and NOM_LOGRD in ('{0}')", string.Join("', '", lograd));

            // TODO: Deve ser implementado aqui a restrição da situação pesquisa.
            switch (situac)
            {
                case SituacaoPesqiosaEnum.NaoExecutados:
                    where += " and STATUS_EXEC = 0 ";
                    break;
                case SituacaoPesqiosaEnum.ImpedidosExec:
                    where += " and STATUS_EXEC = 2 ";
                    break;
                case SituacaoPesqiosaEnum.Executados:
                    where += " and STATUS_EXEC = 1 ";
                    break;
                case SituacaoPesqiosaEnum.Exportados:
                    where += " and COD_LOTE_EXP > 0 ";
                    break;
            }

            // string de sql adicional.
            if (!string.IsNullOrEmpty(sqlAdcional)) where += " and " + sqlAdcional;

            if (!string.IsNullOrEmpty(where))
            {
                where = where.Remove(0, 4);
                where = " where " + where;
            }

            string sql = string.Format(sqlBase, where);
            List<Cadastro> listaCadastro = new List<Cadastro>();
            listaCadastro = _cadastroDAO.CurrentPersistenceObject.LoadData(sql);
            return listaCadastro;
        }

        public List<Cadastro> GetListCadastroByMatricula(string Matricula)
        {

            string sql = string.Format(@"SELECT  CA.*, CO.DES_TIP_COMPL FROM TB_CADASTRO CA
                                       LEFT JOIN TB_TIPO_COMPLEMENTO CO ON (CO.TIP_COMPL = CA.TIP_COMPL) where NUM_MATRIC = {0}", Matricula);

            return _cadastroDAO.CurrentPersistenceObject.LoadData(sql);
        }

        public Cadastro GetListCadastroByMatriculaPS(string matricula, string pontoServico)
        {

            string sql = string.Format(@"SELECT  CA.*, CO.DES_TIP_COMPL FROM TB_CADASTRO CA
                                       LEFT JOIN TB_TIPO_COMPLEMENTO CO ON (CO.TIP_COMPL = CA.TIP_COMPL) 
                                       where NUM_MATRIC = {0} and NUM_PONTO_SERVC = {1}", matricula, pontoServico);
            List<Cadastro> lista = _cadastroDAO.CurrentPersistenceObject.LoadData(sql);
            if (lista == null || lista.Count == 0)
                return null;
            return lista.First();
        }

        /// <summary>
        /// Retorna uma lista de cadastro de forma que cada registro contém os campos que se encontram na model CadastroAuxiliar.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public List<CadastroAuxiliar> GetListCadSimples(string p, int distrito, int setor, int rota)
        {
            string c = string.Empty;

            switch (p)
            {
                case "TD":
                    break;
                case "NV": c = " AND CA.STATUS_EXEC = 0";
                    break;
                case "EX": c = " AND CA.STATUS_EXEC = 1";
                    break;
                case "IE": c = " AND CA.STATUS_EXEC = 2";
                    break;
            }

            string sql = string.Format(@"SELECT  CA.ID_CADAST, CA.COD_DISTRT, CA.NUM_SETOR, CA.COD_ROTA, CA.NUM_SEQ, CA.NUM_FACE, CA.NOM_LOGRD, CA.NUM_IMOV, CA.NUM_IMOV_ALTER, CA.FLG_IMOABA,CA.OBS_VISITA, CA.VETOR_OCORRC, CA.OBS_IMPDM, CA.COORD_X, CA.COORD_Y, CA.DATAGPS,
                                         CA.STATUS_EXEC, CA.NOM_BAIRR, CA.NUM_MEDIDR, CA.OBS_COMPL, CA.NUM_MATRIC, CA.NOM_CLIENT, CA.NUM_PONTO_SERVC, CA.TIP_LOGRD, CA.NOM_BAIRR, CA.NOM_CIDAD,CO.DES_TIP_COMPL FROM TB_CADASTRO CA
                                         LEFT JOIN TB_TIPO_COMPLEMENTO CO ON (CO.TIP_COMPL = CA.TIP_COMPL) 
                                         WHERE CA.COD_DISTRT = {0} AND CA.NUM_SETOR = {1} AND CA.COD_ROTA = {2} {3} ORDER BY CA.NUM_MATRIC, CA.NUM_SEQ, CA.NUM_PONTO_SERVC", distrito, setor, rota, c);
            List<CadastroAuxiliar> lst = _cadastroAuxDAO.CurrentPersistenceObject.LoadData(sql);

            if (lst.Count == 0)
            {
                throw new Exception("Nenhum item encontrado.");
            }

            return lst;
        }

        /// <summary>
        /// Retorna um registro por id de cadastro e numero matricula.
        /// Este método é exclusívo o carregamento de dados da interface frmDadosImóvel.
        /// </summary>
        /// <param name="cadastro"></param>
        /// <param name="matricula"></param>
        /// <returns></returns>
        public Cadastro getPontoServicobyMatCadDI(long cadastro, long matricula)
        {
            string sql = string.Format(@"SELECT  ca.ID_CADAST,
                                        ca.COD_DISTRT,
                                        ca.NUM_SETOR,
                                        ca.COD_ROTA,
                                        ca.NUM_MATRIC,
                                        ca.NOM_CLIENT,
                                        ca.TIP_LOGRD,
                                        ca.NOM_LOGRD,
                                        ca.NUM_IMOV,
                                        ca.NUM_IMOV_ALTER,
                                        ca.TIP_COMPL,
                                        ca.TIP_COMPL_ALTER,
                                        ca.INF_COMPL,
                                        ca.INF_COMPL_ALTER,
                                        ca.NOM_BAIRR,
                                        ca.NOM_CIDAD,
                                        ca.COND_IMOV,
                                        ca.COND_IMOV_ALTER,
                                        ca.PREVS_FIM_OBRA,
                                        ca.NUM_FACE,
                                        ca.NUM_SEQ,
                                        ca.QTD_ECONOM_RES,
                                        ca.QTD_ECONOM_COM,
                                        ca.QTD_ECONOM_IND,
                                        ca.QTD_ECONOM_PUB,
                                        ca.QTD_ECONOM_RES_ALTER,
                                        ca.QTD_ECONOM_COM_ALTER,
                                        ca.QTD_ECONOM_IND_ALTER,
                                        ca.QTD_ECONOM_PUB_ALTER,
                                        ca.RAMO_ATIVD_1,
                                        ca.RAMO_ATIVD_2,
                                        ca.RAMO_ATIVD_3,
                                        ca.RAMO_ATIVD_4,
                                        ca.RAMO_ATIVD_1_ALTER,
                                        ca.RAMO_ATIVD_2_ALTER,
                                        ca.RAMO_ATIVD_3_ALTER,
                                        ca.RAMO_ATIVD_4_ALTER,
                                        ca.TARF_SOCIAL,
                                        ca.TARF_SOCIAL_IMCOMP,
                                        ca.OBS_TARFC_SOCIAL_IMCOMP,
                                        ca.FONTE_ALTERN,
                                        ca.FONTE_ALTERN_ALTER,
                                        ca.FLG_PISCIN,
                                        ca.FLG_PISCIN_ALTER,
                                        ca.FLG_RESERT,
                                        ca.FLG_RESERT_ALTER,
                                        ca.FLG_IMOABA,
                                        ca.FLG_PSHIDRO,
                                        ca.SIT_IMOVEL,
                                        ca.SIT_IMOVEL_ALTER,
                                        ca.OBS_VISITA,
                                        ca.SIT_PONTO_SERVC,
                                        ca.SIT_PONTO_SERVC_ALTER,
                                        ca.NUM_PONTO_SERVC,
                                        ca.LOCLZ_PADRAO,
                                        ca.LOCLZ_PADRAO_ALTER,
                                        ca.TIP_PADRAO,
                                        ca.TIP_PADRAO_ALTER,
                                        ca.PADRAO_LACRADO,
                                        ca.ELIMND_AR,
                                        ca.EXISTE_MEDIDR,
                                        ca.POSSUI_TORNR_PADRAO,
                                        ca.NUM_MEDIDR,
                                        ca.NUM_MEDIDR_ALTER,
                                        ca.LEITURA,
                                        ca.QTD_DIGIT_MEDIDR,
                                        ca.QTD_DIGIT_MEDIDR_ALTER,
                                        ca.CLASS_METRLG,
                                        ca.CLASS_METRLG_ALTER,
                                        ca.MEDIDR_LACRADO,
                                        ca.FLG_SEGND_LIGAC,
                                        ca.NUM_MEDIDR_2,
                                        ca.LEITURA_2,
                                        ca.QTD_DIGIT_MEDIDR_2,
                                        ca.CLASS_METRLG_2,
                                        ca.MEDIDR_LACRADO_2,
                                        ca.DAT_INSTAL,
                                        ca.VETOR_OCORRC,
                                        ca.OBS_IMPDM,
                                        ca.SUSPEI_FRAUDE,
                                        ca.OBS_SUSPEI_FRAUDE,
                                        ca.EXPCTV_CONSM,
                                        ca.COD_FUNCN,
                                        ca.COORD_X,
                                        ca.COORD_Y,
                                        ca.DAT_VISITA,
                                        ca.STATUS_EXEC,
                                        ca.OBS_COMPL,
                                        ca.DATAGPS,
                                        ca.VERSAO,
                                        ca.USU_MOVIMENTACAO,
                                        ca.DT_MOVIMENTACAO,
                                        ca.IP_MOVIMENTACAO, 
                                        CO.DES_TIP_COMPL, 
                                        RA1.DES_RAMO_ATIVD RamoAtivDesc1,
                                        RA2.DES_RAMO_ATIVD RamoAtivDesc2,
                                        RA3.DES_RAMO_ATIVD RamoAtivDesc3,
                                        RA4.DES_RAMO_ATIVD RamoAtivDesc4 
                                        FROM TB_CADASTRO CA
                                        LEFT JOIN TB_TIPO_COMPLEMENTO CO ON (CO.TIP_COMPL = CA.TIP_COMPL) 
                                        LEFT JOIN TB_RAMO_ATIVIDADE RA1 ON (RA1.COD_RAMO_ATIVD = CA.RAMO_ATIVD_1_ALTER)
                                        LEFT JOIN TB_RAMO_ATIVIDADE RA2 ON (RA2.COD_RAMO_ATIVD = CA.RAMO_ATIVD_2_ALTER)
                                        LEFT JOIN TB_RAMO_ATIVIDADE RA3 ON (RA3.COD_RAMO_ATIVD = CA.RAMO_ATIVD_3_ALTER)
                                        LEFT JOIN TB_RAMO_ATIVIDADE RA4 ON (RA4.COD_RAMO_ATIVD = CA.RAMO_ATIVD_4_ALTER)
                                        WHERE CA.ID_CADAST = {0} AND CA.NUM_MATRIC = {1}", cadastro, matricula);

            return _cadastroDAO.CurrentPersistenceObject.LoadOneData(sql);
        }


        public bool ValidaCodVetorOcorrencia(string codigo)
        {
            bool valida = false;

            List<ItemCombo> lst = SingletonFlow.ocorrenciaFlow.getListOcorrencia();

            foreach (ItemCombo posicao in lst)
            {
                if (posicao.Value.ToString() == codigo)
                {
                    valida = true;
                    break;
                }
            }

            return valida;
        }

        /// <summary>
        /// Atualiza somente os três campos da tabela Cadastro, *campos modificados na tela frmConsumo.
        /// </summary>
        public void UpdateCadHistorico(HistoricoConsumo hist)
        {
            long cadastro = hist.Cadastro;
            long matricula = hist.Matricula;
            string expectativa = hist.ExpectativaConsu;
            string suspeita = hist.Incompatibilidade;
            string observConf = hist.ObsNaoConf;

            string sql = string.Format(@"UPDATE TB_CADASTRO
                                        SET EXPCTV_CONSM = '{2}',
                                            SUSPEI_FRAUDE = '{3}',
                                            STATUS_REG = '2',
                                            OBS_SUSPEI_FRAUDE = '{4}'
                                        WHERE ID_CADAST = {0} and NUM_MATRIC = {1}", cadastro, matricula, expectativa, suspeita, observConf);

            _cadastroDAO.CurrentPersistenceObject.ExecuteCommand(sql);
        }
        /// <summary>
        /// Atualiza obsvisita
        /// </summary>
        /// <param name="cad"></param>
        public void UpdateObsVisita(CadastroAuxiliar cad)
        {
            long cadastro = cad.Id;
            long matricula = cad.Matricula;
            string obsVisita = cad.ObservacaoVisita;

            string sql = string.Format(@"UPDATE TB_CADASTRO
                                        SET OBS_VISITA = '{2}',
                                            STATUS_REG = '2'
                                        WHERE ID_CADAST = {0} and NUM_MATRIC = {1}", cadastro, matricula, obsVisita);

            _cadastroDAO.CurrentPersistenceObject.ExecuteCommand(sql);
        }
        /// <summary>
        /// Recupera observação visita
        /// </summary>
        /// <param name="cadastro"></param>
        /// <param name="matricula"></param>
        /// <returns></returns>
        public string getObsVista(long cadastro, long matricula)
        {
            string sql = string.Format(@"SELECT  CA.* FROM TB_CADASTRO CA
                                         WHERE CA.ID_CADAST = {0} AND CA.NUM_MATRIC = {1}", cadastro, matricula);

            Cadastro obsvis = _cadastroDAO.CurrentPersistenceObject.LoadOneData(sql);

            if (obsvis.ObservacaoVisita == null)
            {
                return null;
            }

            return obsvis.ObservacaoVisita;
        }
        /// <summary>
        /// Atualiza posição do gps
        /// </summary>
        /// <param name="cad"></param>
        public void UpdateGPS(CadastroAuxiliar cad)
        {
            long cadastro = cad.Id;
            long matricula = cad.Matricula;
            string lati = cad.CoordenadaX;
            string longi = cad.CoordenadaY;
            DateTime? datagps = cad.DataGPS;

            string sql = string.Format(@"UPDATE TB_CADASTRO
                                        SET COORD_X = '{2}',
                                            COORD_Y = '{3}',
                                            DATAGPS = '{4}',   
                                            STATUS_REG = '2'
                                        WHERE ID_CADAST = {0} and NUM_MATRIC = {1}", cadastro, matricula, lati, longi, datagps);

            _cadastroDAO.CurrentPersistenceObject.ExecuteCommand(sql);
        }
        /// <summary>
        /// Recupera cadastro com ocorrencia
        /// </summary>
        /// <param name="cad"></param>
        /// <param name="matric"></param>
        /// <returns></returns>
        public CadastroAuxiliar getListCadImp(long cad, long matric)
        {
            long cadastro = cad;
            long matricula = matric;

            string sql = string.Format(@"SELECT  CA.ID_CADAST,  CA.COD_ROTA,  CA.COD_DISTRT,  CA.NUM_SEQ ,  CA.NUM_FACE,  CA.STATUS_EXEC,  CA.NUM_MEDIDR,  CA.NUM_MATRIC,  CA.NOM_CLIENT,  CA.NUM_PONTO_SERVC,  CA.FLG_IMOABA,  CA.TIP_LOGRD,  CA.NUM_IMOV, CA.NUM_IMOV_ALTER, CA.NOM_BAIRR,  CA.NOM_CIDAD,  CA.OBS_COMPL,  CA.OBS_VISITA,  CA.VETOR_OCORRC,  CA.OBS_IMPDM,  CA.COORD_X,  CA.COORD_Y,  CA.DATAGPS,  ' ' DES_TIP_COMPL, ' ' QtdPS,  CA.NOM_LOGRD
                                         FROM TB_CADASTRO CA
                                         LEFT JOIN TB_OCORRENCIA OC ON (CONVERT(NVARCHAR, OC.COD_OCORRC) = CA.VETOR_OCORRC) 
                                         WHERE CA.ID_CADAST = {0} and CA.NUM_MATRIC = {1}", cadastro, matricula);


            return _cadastroAuxDAO.CurrentPersistenceObject.LoadOneData(sql);
        }
        /// <summary>
        /// grava impedimento
        /// </summary>
        /// <param name="cad"></param>
        public void UpdateImpedimento(CadastroAuxiliar cad)
        {
            string vetor = cad.VetorOcorrencia;
            string obsImp = cad.ObservacaoImpedimento;
            long cadastro = cad.Id;
            long matricula = cad.Matricula;
            int? statusExec = 2;

            if (cad.VetorOcorrencia == "S")
            {
                throw new Exception("Campo motivo impedimento não informado.");
            }

            string sql = string.Format(@"UPDATE TB_CADASTRO
                                        SET VETOR_OCORRC = '{2}',
                                            OBS_IMPDM = '{3}',
                                            STATUS_EXEC = {4},
                                            STATUS_REG = '2'
                                        WHERE ID_CADAST = {0} and NUM_MATRIC = {1}", cadastro, matricula, vetor, obsImp, statusExec);

            _cadastroDAO.CurrentPersistenceObject.ExecuteCommand(sql);
        }
        /// <summary>
        /// desfaz o impedimento.
        /// </summary>
        /// <param name="cad"></param>
        public void UpdateImpDesfazer(CadastroAuxiliar cad)
        {
            string vetor = null;
            string obsImp = null;
            long cadastro = cad.Id;
            long matricula = cad.Matricula;
            int? statusExec = 0;

            string sql = string.Format(@"UPDATE TB_CADASTRO
                                        SET VETOR_OCORRC = '{2}',
                                            OBS_IMPDM = '{3}',
                                            STATUS_EXEC = {4},
                                            STATUS_REG = '2'
                                        WHERE ID_CADAST = {0} and NUM_MATRIC = {1}", cadastro, matricula, vetor, obsImp, statusExec);

            _cadastroDAO.CurrentPersistenceObject.ExecuteCommand(sql);
        }
        /// <summary>
        /// Atualiza campo status execução quando todos os campos obrigatórios foram preenchidos
        /// </summary>
        /// <param name="cad"></param>
        public void UpdateStatusExec(CadastroAuxiliar cad, int? stat)
        {
            long cadastro = cad.Id;
            long matricula = cad.Matricula;
            int? statusExec = stat;

            string sql = string.Format(@"UPDATE TB_CADASTRO
                                        SET STATUS_EXEC = {2},
                                            STATUS_REG = '2'
                                        WHERE ID_CADAST = {0} and NUM_MATRIC = {1}", cadastro, matricula, statusExec);

            _cadastroDAO.CurrentPersistenceObject.ExecuteCommand(sql);
        }

        public List<Cadastro> GetListNotSync()
        {
            string sql = string.Format(@"SELECT *
                                        FROM TB_CADASTRO 
                                        WHERE status_reg <> 1 ");

            return _cadastroDAO.CurrentPersistenceObject.LoadData(sql);
        }

        /// <summary>
        /// Recupera todos os registros ainda não sincronizados
        /// </summary>
        /// <returns>Lista tipada</returns>
        public void SetListNotSync(List<long> listUpdate)
        {
            _cadastroDAO.SetListNotSync(listUpdate);
        }

        public void DeleteAll()
        {
            _cadastroDAO.DeleteAll();
        }

        public bool StatusExecucaoRota(Rota rota)
        {
            bool status = false;//false para não concluído ou não sincronizado           

            int cadExec = 0;

            //busca por cadastros não sincronizados e não executados
            string sql = string.Format(@"select count(ca.id_cadast)
                                       from TB_CADASTRO ca
                                       where 
	                                       STATUS_EXEC in ('1','2') and 
	                                       status_reg = '1'  and
	                                       ca.COD_DISTRT = {0} and 
	                                       ca.NUM_SETOR = {1} and
	                                       ca.COD_ROTA = {2}
                                       group by ca.COD_DISTRT, ca.NUM_SETOR, ca.COD_ROTA", rota.CodigoDistrito, rota.Setor, rota.CodigoRota);

            object qtdCadExec = _cadastroDAO.CurrentPersistenceObject.ExecuteScalar(sql);

            //a igualdade nesta operação significa que não foi encontrado cadadastro que não estejam executados e sincronizados.
            if (qtdCadExec == null)
            {
                return false;
            }
            else
            {
                cadExec = (int)qtdCadExec;
            }

            if (rota.QtdCad == cadExec)
            {
                status = true;
            }

            return status;
        }

        public void DelCadExecOrFinal(Rota rota)
        {
            string sql = string.Format(@"delete from TB_CADASTRO
                                        where COD_DISTRT = {0} and 
                                        NUM_SETOR = {1} and
                                        COD_ROTA = {2}", rota.CodigoDistrito, rota.Setor, rota.CodigoRota);

            _cadastroDAO.CurrentPersistenceObject.ExecuteCommand(sql);
        }

        public bool StatusCadRotaFinal(Rota rota)
        {
            bool status = false;//false para não não sincronizado                       

            //busca por cadastros não sincronizados e não executados
            string sql = string.Format(@"select count(ca.id_cadast)
                                       from TB_CADASTRO ca
                                       where 
	                                       status_reg <> '1'  and
	                                       ca.COD_DISTRT = {0} and 
	                                       ca.NUM_SETOR = {1} and
	                                       ca.COD_ROTA = {2}
                                       group by ca.COD_DISTRT, ca.NUM_SETOR, ca.COD_ROTA", rota.CodigoDistrito, rota.Setor, rota.CodigoRota);

            object qtdCadExec = _cadastroDAO.CurrentPersistenceObject.ExecuteScalar(sql);

            //a igualdade nesta operação significa que não foi encontrado cadadastro que não estejam executados e sincronizados.
            if (qtdCadExec == null)
            {
                return true;
            }

            return status;
        }
        public List<string> GetListLogradouros()
        {
            string sql = @"select DISTINCT NOM_LOGRD
                         from TB_CADASTRO ca";

            return _cadastroDAO.CurrentPersistenceObject.LoadValues<string>(sql);

        }

        public List<Cadastro> getCadastroRelatorio(string ocorrencia)
        {
            string sql = String.Format(@"
                            SELECT
	                            COD_DISTRT
	                            ,NUM_SETOR
	                            ,COD_ROTA
	                            ,NUM_MATRIC
	                            ,NOM_CLIENT
	                            ,TIP_LOGRD
	                            ,NOM_LOGRD
	                            ,NUM_IMOV
	                            ,NUM_IMOV_ALTER
	                            ,TIP_COMPL
	                            ,TIP_COMPL_ALTER
	                            ,INF_COMPL
	                            ,INF_COMPL_ALTER
	                            ,NOM_BAIRR
	                            ,NOM_CIDAD
	                            ,COND_IMOV
	                            ,COND_IMOV_ALTER
	                            ,PREVS_FIM_OBRA
	                            ,NUM_FACE
	                            ,NUM_SEQ
	                            ,QTD_ECONOM_RES
	                            ,QTD_ECONOM_COM
	                            ,QTD_ECONOM_IND
	                            ,QTD_ECONOM_PUB
	                            ,QTD_ECONOM_RES_ALTER
	                            ,QTD_ECONOM_COM_ALTER
	                            ,QTD_ECONOM_IND_ALTER
	                            ,QTD_ECONOM_PUB_ALTER
	                            ,RAMO_ATIVD_1
	                            ,RAMO_ATIVD_2
	                            ,RAMO_ATIVD_3
	                            ,RAMO_ATIVD_4
	                            ,RAMO_ATIVD_1_ALTER
	                            ,RAMO_ATIVD_2_ALTER
	                            ,RAMO_ATIVD_3_ALTER
	                            ,RAMO_ATIVD_4_ALTER
	                            ,TARF_SOCIAL
	                            ,TARF_SOCIAL_IMCOMP
	                            ,OBS_TARFC_SOCIAL_IMCOMP
	                            ,FONTE_ALTERN
	                            ,FONTE_ALTERN_ALTER
	                            ,FLG_PISCIN
	                            ,FLG_PISCIN_ALTER
	                            ,FLG_RESERT
	                            ,FLG_RESERT_ALTER
	                            ,SIT_IMOVEL
	                            ,SIT_IMOVEL_ALTER
	                            ,OBS_VISITA
	                            ,SIT_PONTO_SERVC
	                            ,SIT_PONTO_SERVC_ALTER
	                            ,NUM_PONTO_SERVC
	                            ,LOCLZ_PADRAO
	                            ,LOCLZ_PADRAO_ALTER
	                            ,TIP_PADRAO
	                            ,TIP_PADRAO_ALTER
	                            ,PADRAO_LACRADO
	                            ,ELIMND_AR
	                            ,EXISTE_MEDIDR
	                            ,POSSUI_TORNR_PADRAO
	                            ,NUM_MEDIDR
	                            ,NUM_MEDIDR_ALTER
	                            ,LEITURA
	                            ,QTD_DIGIT_MEDIDR
	                            ,QTD_DIGIT_MEDIDR_ALTER
	                            ,CLASS_METRLG
	                            ,CLASS_METRLG_ALTER
	                            ,MEDIDR_LACRADO
	                            ,FLG_SEGND_LIGAC
	                            ,NUM_MEDIDR_2
	                            ,LEITURA_2
	                            ,QTD_DIGIT_MEDIDR_2
	                            ,CLASS_METRLG_2
	                            ,MEDIDR_LACRADO_2
	                            ,DAT_INSTAL
	                            ,VETOR_OCORRC
	                            ,OBS_IMPDM
	                            ,SUSPEI_FRAUDE
	                            ,OBS_SUSPEI_FRAUDE
	                            ,EXPCTV_CONSM
	                            ,COD_FUNCN
	                            ,COORD_X
	                            ,COORD_Y
	                            ,DAT_VISITA
	                            ,STATUS_EXEC
	                            ,OBS_COMPL
	                            ,DATAGPS
	                            ,VERSAO
	                            ,USU_MOVIMENTACAO
	                            ,DT_MOVIMENTACAO
	                            ,IP_MOVIMENTACAO
	                            ,COD_LOTE_EXP
	                            ,ID_CADAST
	                            ,ID_CADAST_TEMP
                            FROM TB_CADASTRO CA
                            WHERE  
	                            VETOR_OCORRC like '%{0}%'
                                ", ocorrencia);

            List<Cadastro> listaCadastro = _cadastroDAO.CurrentPersistenceObject.LoadData(sql);

            if (listaCadastro == null)
                listaCadastro = new List<Cadastro>();

            return listaCadastro;
        }

    }
}

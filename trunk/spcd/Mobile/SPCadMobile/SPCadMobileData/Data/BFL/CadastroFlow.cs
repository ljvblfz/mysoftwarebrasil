using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SPCadMobileData.Data.DAL;
using SPCadMobileData.Data.Model;
using CommonHelpMobile;
using GDA.Sql;

namespace SPCadMobileData.Data.BFL
{
    public class CadastroFlow
    {
        private Dao<Cadastro> _cadastroDAO = DaoFactory.getCadastro();
        private Dao<CadastroAuxiliar> _cadastroAuxDAO = DaoFactory.getCadastroAuxiliar();
        private Dao<AuxConsCadast> _auxConsCadastDAO = DaoFactory.getAuxConsCadast();

        #region CRUD

        public void Insert(Cadastro cadastro)
        {
            try
            {
                cadastro.StatusReg = "3";
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
                cadastro.StatusReg = "2";
                cadastro.DtMovimentacao = DateTime.Now;
                cadastro.DataVisita = DateTime.Now;
                _cadastroDAO.Update(cadastro);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar!\n" + ex.Message, (Exception)ex);
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
                cadastro.StatusReg = "2";
                cadastro.DtMovimentacao = DateTime.Now;
                _cadastroDAO.InsertOrUpdate(cadastro);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível inserir ou atualizar!\n" + ex.Message, (Exception)ex);
            }
        }

        /// <summary>
        /// inserção ou atualização na sincronização
        /// </summary>
        /// <param name="cadastro"></param>
        public void InsertOrUpdateSync(Cadastro cadastro)
        {
            try
            {
                _cadastroDAO.InsertOrUpdateSync(cadastro);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, (Exception)ex);
            }
        }

        /// <summary>
        /// Update utilizado para a interface frmPontoServHidrometro.cs
        /// retorna 2 se as infomações estiverem completas ou 1 se incompletas.
        /// </summary>
        /// <param name="cadastro"></param>
        /// <param name="aba"></param>
        /// <returns></returns>
        public void UpdatePSHidrometro(string aba, Cadastro cad, ref string flag)
        {
            string msg = string.Empty;
            try
            {
                cad.FlagPSHidro = "2";

                //teste aba padrão
                if (aba == "tabPadrao" && (string.IsNullOrEmpty(cad.SituacaoPontoServicoAlter) ||
                    cad.LocalizacaoPadraoAlter.isNullorZero() ||
                    cad.TipoPadraoAlter.isNullorZero() ||
                    string.IsNullOrEmpty(cad.PadraoLacrado) || cad.PadraoLacrado == "0" ||
                    string.IsNullOrEmpty(cad.EliminadorAr) || cad.EliminadorAr == "0" ||
                    string.IsNullOrEmpty(cad.PossuiTorneiraPadrao) || cad.PossuiTorneiraPadrao == "0")
                    )
                {
                    cad.FlagPSHidro = "1";
                    msg = "As informações da aba \"Padrão\" estão incompletas.";
                }

                //teste aba medidor                
                if (aba == "tabMedidor")
                {
                    if (!string.IsNullOrEmpty(cad.ExisteMedidor))
                    {
                        if (cad.ExisteMedidor == "1")//testa se a resposta é sim("1") para validar campos.
                        {
                            if (string.IsNullOrEmpty(cad.NumeroMedidorAlter) ||
                                cad.Leitura.isNullorZero() ||
                                cad.QtdeDigitosMedidorAlter.isNullorZero() ||
                                string.IsNullOrEmpty(cad.ClasseMetrologicaAlter) ||
                                string.IsNullOrEmpty(cad.MedidorLacrado) ||
                                string.IsNullOrEmpty(cad.SegundaLigacao)
                                )
                            {
                                cad.FlagPSHidro = "1";
                                msg += "\r\nAs informações da aba \"Medidor\" estão incompletas.";

                            }
                        }
                        else if (cad.ExisteMedidor == "2")
                        {
                            cad.NumeroMedidorAlter = null;
                            cad.Leitura = null;
                            cad.QtdeDigitosMedidorAlter = null;
                            cad.ClasseMetrologicaAlter = null;
                            cad.MedidorLacrado = null;
                        }
                        else
                        {
                            cad.FlagPSHidro = "1";
                            msg += "\r\nAs informações da aba \"Medidor\" estão incompletas.";
                        }
                    }
                    else
                    {
                        cad.FlagPSHidro = "1";
                        msg += "\r\nAs informações da aba \"Medidor\" estão incompletas.";
                    }
                }

                //teste 2 ligação
                if (aba == "tabMedidor2" && cad.SegundaLigacao == "1")
                {
                    if (string.IsNullOrEmpty(cad.NumeroMedidor2) ||
                        cad.Leitura2.isNullorZero() ||
                        cad.QtdeDigitosMedidor2.isNullorZero() ||
                        string.IsNullOrEmpty(cad.ClasseMetrologica2) ||
                        string.IsNullOrEmpty(cad.MedidorLacrado2)
                        )
                    {
                        cad.FlagPSHidro = "1";
                        msg += "\r\nAs informações da aba \"2° Ligação\" estão incompletas.";
                    }
                }
                else if (cad.SegundaLigacao == "2")
                {
                    cad.NumeroMedidor2 = null;
                    cad.Leitura2 = null;
                    cad.QtdeDigitosMedidor2 = null;
                    cad.ClasseMetrologica2 = null;
                    cad.MedidorLacrado2 = null;
                }

                cad.StatusReg = "2";
                cad.DtMovimentacao = DateTime.Now;
                _cadastroDAO.Update(cad);
                flag = cad.FlagPSHidro;//configura a flag de completo/incompleto da interface frmPontoServHidrometro
                if (!string.IsNullOrEmpty(msg))
                { throw new Exception(msg); }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, (Exception)ex);
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

            string sql = @"
                            SELECT  
	                            CA.ID_CADAST
	                            ,CA.COD_DISTRT
	                            ,CA.NUM_SETOR
	                            ,CA.COD_ROTA
	                            ,CA.NUM_SEQ
	                            ,CA.NUM_FACE
	                            ,CA.NOM_LOGRD
	                            ,CA.NUM_IMOV
	                            ,CA.NUM_IMOV_ALTER
	                            ,CA.FLG_IMOABA
	                            ,CA.OBS_VISITA
	                            ,CA.VETOR_OCORRC
	                            ,CA.OBS_IMPDM
	                            ,CA.COORD_X
	                            ,CA.COORD_Y
	                            ,CA.DATAGPS
	                            ,CA.STATUS_EXEC
	                            ,CA.NOM_BAIRR
	                            ,CA.NUM_MEDIDR
	                            ,CA.OBS_COMPL
	                            ,CA.NUM_MATRIC
                                ,CA.NOM_CLIENT
	                            ,CA.NUM_PONTO_SERVC
	                            ,CA.TIP_LOGRD
	                            ,CA.NOM_BAIRR
	                            ,CA.NOM_CIDAD
	                            ,CO.DES_TIP_COMPL
	                            ,CA.SIT_PONTO_SERVC_ALTER
                                ,CA.COD_FUNCN
                            	
                            FROM TB_CADASTRO CA

	                             LEFT JOIN TB_TIPO_COMPLEMENTO CO ON (CO.TIP_COMPL = CA.TIP_COMPL) 
	                             WHERE 
		                            CA.COD_DISTRT = {0} 
		                            AND CA.NUM_SETOR = {1} 
		                            AND CA.COD_ROTA = {2} {3} 
                            		
	                            ORDER BY CA.NUM_FACE, CA.NUM_SEQ";
            sql = string.Format(sql, distrito, setor, rota, c);
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

        /// <summary>
        /// Retorna a flag de conclusão do imovel.
        /// </summary>
        /// <param name="cadastro"></param>
        /// <param name="matricula"></param>
        /// <returns></returns>
        public string getFlagImovel(long cadastro, long matricula)
        {
            string sql = string.Format(@"SELECT  CA.* FROM TB_CADASTRO CA
                                         WHERE CA.ID_CADAST = {0} AND CA.NUM_MATRIC = {1}", cadastro, matricula);

            Cadastro flgCad = _cadastroDAO.CurrentPersistenceObject.LoadOneData(sql);

            if (flgCad == null)
            {
                return null;
            }

            return flgCad.FlagImovelAba;
        }

        /// <summary>
        /// Retorna a flag de conclusão do Hidrometro.
        /// </summary>
        /// <param name="cadastro"></param>
        /// <param name="matricula"></param>
        /// <returns></returns>
        public string getFlagPSHidro(long cadastro, long matricula)
        {
            string sql = string.Format(@"SELECT  CA.* FROM TB_CADASTRO CA
                                         WHERE CA.ID_CADAST = {0} AND CA.NUM_MATRIC = {1}", cadastro, matricula);

            Cadastro flgPsH = _cadastroDAO.CurrentPersistenceObject.LoadOneData(sql);

            if (flgPsH == null)
            {
                return null;
            }

            return flgPsH.FlagPSHidro;
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

        public AuxConsCadast GetConsumCad(long cadastro, long matricula)
        {
            string sql = string.Format(@"SELECT
                                         CAD.ID_CADAST,
                                         CAD.NUM_MATRIC,                                         
                                         CAD.EXPCTV_CONSM,
                                         CAD.SUSPEI_FRAUDE,
                                         CAD.OBS_SUSPEI_FRAUDE 
                                         FROM TB_CADASTRO CAD                                    
                                         WHERE CAD.ID_CADAST = {0} and CAD.NUM_MATRIC = {1}", cadastro, matricula);

            return _auxConsCadastDAO.CurrentPersistenceObject.LoadOneData(sql);
        }

        /// <summary>
        /// Atualiza somente os três campos da tabela Cadastro, *campos modificados na tela frmConsumo.
        /// </summary>
        public void UpdateCadConsumo(AuxConsCadast cadConsum)
        {
            string sql = string.Format(@"UPDATE TB_CADASTRO
                                        SET EXPCTV_CONSM = '{2}',
                                            SUSPEI_FRAUDE = '{3}',
                                            STATUS_REG = '2',
                                            OBS_SUSPEI_FRAUDE = '{4}'
                                        WHERE ID_CADAST = {0} and NUM_MATRIC = {1}", cadConsum.Cadastro, cadConsum.Matricula, cadConsum.ExpectativaConsu, cadConsum.Incompatibilidade, cadConsum.ObsNaoConf);

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
                                            DATAGPS = '{4:MM/dd/yyyy HH:mm:ss}',   
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

            string sql = string.Format(@"SELECT  
                                            CA.ID_CADAST
                                            ,CA.COD_ROTA
                                            ,CA.COD_DISTRT
                                            ,CA.NUM_SEQ 
                                            ,CA.NUM_FACE
                                            ,CA.STATUS_EXEC
                                            ,CA.NUM_MEDIDR
                                            ,CA.NUM_MATRIC
                                            ,CA.NOM_CLIENT
                                            ,CA.NUM_PONTO_SERVC
                                            ,CA.FLG_IMOABA
                                            ,CA.TIP_LOGRD
                                            ,CA.NUM_IMOV
                                            ,CA.NUM_IMOV_ALTER
                                            ,CA.NOM_BAIRR
                                            ,CA.NOM_CIDAD
                                            ,CA.OBS_COMPL
                                            ,CA.OBS_VISITA
                                            ,CA.VETOR_OCORRC
                                            ,CA.OBS_IMPDM
                                            ,CA.COORD_X
                                            ,CA.COORD_Y
                                            ,CA.DATAGPS
                                            ,' ' DES_TIP_COMPL
                                            ,' ' QtdPS
                                            ,CA.NOM_LOGRD 
                                            ,CA.COD_FUNCN
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
        /// atualiza ocorrencia removendo os impedimentos.
        /// </summary>
        /// <param name="cad"></param>
        public void UpdateImpedimento(long idCad, List<string> lst)
        {   
            //status de execução para não executado
            int statusExec = 0;
            string[] temp;
            string vetor = null;

            if (lst.Count > 0)
            {
                //converte lista para string

                temp = lst.ToArray();              

                foreach (string item in temp)
                {
                    vetor += item + ",";
                }

                //remove a virgula do final
                vetor = vetor.Remove(vetor.Length - 1, 1);
            }

            string sql = string.Format(@"UPDATE TB_CADASTRO
                                        SET VETOR_OCORRC = '{1}',
                                            STATUS_EXEC = {2},
                                            STATUS_REG = '2'
                                        WHERE ID_CADAST = {0}", idCad, vetor, statusExec);

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
            long userIdCurrent = FuncionarioFlow.FuncionarioLogado.Id;
            
            string sql = string.Format(@"UPDATE TB_CADASTRO
                                        SET STATUS_EXEC = {2},
                                            STATUS_REG = '2',
                                            COD_FUNCN = {3}
                                        WHERE ID_CADAST = {0} and NUM_MATRIC = {1}", cadastro, matricula, statusExec, userIdCurrent);

            _cadastroDAO.CurrentPersistenceObject.ExecuteCommand(sql);
        }

        /// <summary>
        /// Atualiza campo status execução
        /// </summary>
        /// <param name="cad"></param>
        public void UpdateStatusExec(Cadastro cad)
        {
            long cadastro = cad.Id;
            long matricula = cad.Matricula;
            int? statusExec = cad.StatusExecucao;

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

        //verifica se há algum valor no campo de expectativa consumo.
        public string verificaConsumo(long idCad)
        {
            try
            {
                string valor = new Query("Id = ?Id").Add("?Id", idCad).First<Cadastro>().ExpectativaConsumo;

                return (string.IsNullOrEmpty(valor) || valor == "0") ? "1" : "2";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Cadastro getCadastroById(long p)
        {
            return new Query("ID = ?id").Add("?id", p).First<Cadastro>();
        }

        public int? getStatusExecByMatricula(long p)
        {
            return new Query("Matricula = ?codMat").Add("?codMat", p).First<Cadastro>().StatusExecucao;
        }
    }
}

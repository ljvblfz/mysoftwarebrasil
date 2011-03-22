using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GDA;
using CommonHelpMobile;

namespace SPCadMobileData.Data.Model
{
    [PersistenceClass("TB_CADASTRO")]
    //[PersistenceBaseDAO(typeof(RotaDAO))]
    public class Cadastro : AuditoriaSuper
    {
        #region Identificadores
        [PersistenceProperty("ID_CADAST", PersistenceParameterType.Key)]
        public long Id { get; set; }

        [PersistenceProperty("COD_ROTA")]
        [PersistenceForeignKey(typeof(Rota), "CodigoRota")]
        public int CodigoRota { get; set; }

        [PersistenceProperty("COD_DISTRT")]
        [PersistenceForeignKey(typeof(Rota), "CodigoDistrito")]
        public int CodigoDistrito { get; set; }

        [PersistenceProperty("NUM_SETOR")]
        [PersistenceForeignKey(typeof(Rota), "Setor")]
        public int Setor { get; set; }

        [PersistenceProperty("NUM_MATRIC")]
        public long Matricula { get; set; }
        #endregion

        #region Imóvel

        [PersistenceProperty("NOM_CLIENT")]
        public string NomeCliente { get; set; }

        [PersistenceProperty("TIP_LOGRD")]
        public string TipoLogradouro { get; set; }        


        [PersistenceProperty("NOM_LOGRD")]
        public string NomeLogradouro { get; set; }

        [PersistenceProperty("NUM_IMOV")]
        public int NumeroImovel { get; set; }

        [PersistenceProperty("NUM_IMOV_ALTER")]
        public int? NumeroImovelAlter { get; set; }

        [PersistenceProperty("TIP_COMPL")]
        [PersistenceForeignKey(typeof(TipoComplemento), "Tipo")]
        public string TipoComplemento { get; set; }

        [PersistenceProperty("TIP_COMPL_ALTER")]
        [PersistenceForeignKey(typeof(TipoComplemento), "Tipo")]
        public string TipoComplementoAlter { get; set; }

        [PersistenceProperty("INF_COMPL")]
        public string InformacaoComplementar { get; set; }

        [PersistenceProperty("INF_COMPL_ALTER")]
        public string InformacaoComplementarAlter { get; set; }

        [PersistenceProperty("NOM_BAIRR")]
        public string NomeBairro { get; set; }

        [PersistenceProperty("NOM_CIDAD")]
        public string NomeCidade { get; set; }

        [PersistenceProperty("COND_IMOV")]
        [PersistenceForeignKey(typeof(CondicaoImovel), "Id")]
        public int CondicaoImovel { get; set; }

        [PersistenceProperty("COND_IMOV_ALTER")]
        [PersistenceForeignKey(typeof(CondicaoImovel), "Id")]
        public int? CondicaoImovelAlter { get; set; }


        [PersistenceProperty("PREVS_FIM_OBRA")]
        public DateTime? PrevisaoFimObra { get; set; }

        [PersistenceProperty("NUM_FACE")]
        public int Face { get; set; }

        [PersistenceProperty("NUM_SEQ")]
        public int Sequencia { get; set; }

        [PersistenceProperty("OBS_COMPL")]
        public string Observacao_complementar { get; set; }

        //cada posição da string, ou cada posição de caractere, representa o estado de cada aba, respectivamente, na interface frmDadosImovel.cs 
        [PersistenceProperty("FLG_IMOABA")]
        public string FlagImovelAba { get; set; }

        //cada posição da string, ou cada posição de caractere, representa o estado de cada aba, respectivamente, na interface frmPontoServHidrometro.cs 
        [PersistenceProperty("FLG_PSHIDRO")]
        public string FlagPSHidro { get; set; }

        #endregion

        #region Economias
        [PersistenceProperty("QTD_ECONOM_RES")]
        public int QtdeEconomiasResidencial { get; set; }

        [PersistenceProperty("QTD_ECONOM_COM")]
        public int QtdeEconomiasComercial { get; set; }

        [PersistenceProperty("QTD_ECONOM_IND")]
        public int QtdeEconomiasIndustrial { get; set; }

        [PersistenceProperty("QTD_ECONOM_PUB")]
        public int QtdeEconomiasPublica { get; set; }

        [PersistenceProperty("QTD_ECONOM_RES_ALTER")]
        public int? QtdeEconomiasResidencialAlter { get; set; }

        [PersistenceProperty("QTD_ECONOM_COM_ALTER")]
        public int? QtdeEconomiasComercialAlter { get; set; }

        [PersistenceProperty("QTD_ECONOM_IND_ALTER")]
        public int? QtdeEconomiasIndustrialAlter { get; set; }

        [PersistenceProperty("QTD_ECONOM_PUB_ALTER")]
        public int? QtdeEconomiasPublicaAlter { get; set; }

        [PersistenceProperty("RAMO_ATIVD_1")]
        public int? RamoAtividade1 { get; set; }

        [PersistenceProperty("RAMO_ATIVD_2")]
        public int? RamoAtividade2 { get; set; }

        [PersistenceProperty("RAMO_ATIVD_3")]
        public int? RamoAtividade3 { get; set; }

        [PersistenceProperty("RAMO_ATIVD_4")]
        public int? RamoAtividade4 { get; set; }

        [PersistenceProperty("RAMO_ATIVD_1_ALTER")]
        public int? RamoAtividade1Alter { get; set; }

        [PersistenceProperty("RAMO_ATIVD_2_ALTER")]
        public int? RamoAtividade2Alter { get; set; }

        [PersistenceProperty("RAMO_ATIVD_3_ALTER")]
        public int? RamoAtividade3Alter { get; set; }

        [PersistenceProperty("RAMO_ATIVD_4_ALTER")]
        public int? RamoAtividade4Alter { get; set; }
        #endregion

        #region Caracterícicas

        [PersistenceProperty("TARF_SOCIAL")]
        public string TarifaSocial { get; set; }

      

        [PersistenceProperty("TARF_SOCIAL_IMCOMP")]
        public string TarifaSocialIncompativel { get; set; }       

        [PersistenceProperty("OBS_TARFC_SOCIAL_IMCOMP")]
        public string TarifaSocialIncompativelObs { get; set; }

        [PersistenceProperty("FONTE_ALTERN")]
        [PersistenceForeignKey(typeof(FonteAlternativa), "Id")]
        public string FonteAlternativa{get; set;}        

        [PersistenceProperty("FONTE_ALTERN_ALTER")]
        [PersistenceForeignKey(typeof(FonteAlternativa), "Id")]
        public string FonteAlternativaAlter { get; set; }

      
        [PersistenceProperty("FLG_PISCIN")]
        public string Piscina { get; set; }

        [PersistenceProperty("FLG_PISCIN_ALTER")]
        public string PiscinaAlter { get; set; }

        [PersistenceProperty("FLG_RESERT")]
        public string Reservatorio { get; set; }

        [PersistenceProperty("FLG_RESERT_ALTER")]
        public string ReservatorioAlter { get; set; }

        [PersistenceProperty("SIT_IMOVEL")]
        public string SituacaoImovel { get; set; }

        [PersistenceProperty("SIT_IMOVEL_ALTER")]
        public string SituacaoImovelAlter { get; set; }

       

        [PersistenceProperty("SIT_PONTO_SERVC")]
        public string SituacaoPontoServico { get; set; }

        [PersistenceProperty("SIT_PONTO_SERVC_ALTER")]
        public string SituacaoPontoServicoAlter { get; set; }       

        #endregion

        [PersistenceProperty("OBS_VISITA")]
        public string ObservacaoVisita { get; set; }

        #region P.S. / Hidrômetro (Padrão)

        [PersistenceProperty("NUM_PONTO_SERVC")]
        public string NumeroPontoServico { get; set; }

        [PersistenceProperty("LOCLZ_PADRAO")]
        [PersistenceForeignKey(typeof(LocalizacaoPadrao), "Id")]
        public int LocalizacaoPadrao { get; set; }

        [PersistenceProperty("LOCLZ_PADRAO_ALTER")]
        [PersistenceForeignKey(typeof(LocalizacaoPadrao), "Id")]
        public int? LocalizacaoPadraoAlter { get; set; }

        [PersistenceProperty("TIP_PADRAO")]
        [PersistenceForeignKey(typeof(TipoPadrao), "Id")]
        public int TipoPadrao { get; set; }

        [PersistenceProperty("TIP_PADRAO_ALTER")]
        [PersistenceForeignKey(typeof(TipoPadrao), "Id")]
        public int? TipoPadraoAlter { get; set; }

        [PersistenceProperty("PADRAO_LACRADO")]
        public string PadraoLacrado { get; set; }

        [PersistenceProperty("ELIMND_AR")]
        public string EliminadorAr { get; set; }

        [PersistenceProperty("POSSUI_TORNR_PADRAO")]
        public string PossuiTorneiraPadrao { get; set; }

        #endregion

        #region P.S. / Hidrômetro (Medidor)

        /// <summary>
        /// "1" para sim, "2" para não
        /// </summary>
        [PersistenceProperty("EXISTE_MEDIDR")]
        public string ExisteMedidor { get; set; }

       

        [PersistenceProperty("NUM_MEDIDR")]
        public string NumeroMedidor { get; set; }

        [PersistenceProperty("NUM_MEDIDR_ALTER")]
        public string NumeroMedidorAlter { get; set; }

        [PersistenceProperty("LEITURA")]
        public long? Leitura { get; set; }

        [PersistenceProperty("QTD_DIGIT_MEDIDR")]
        public int QtdeDigitosMedidor { get; set; }

        [PersistenceProperty("QTD_DIGIT_MEDIDR_ALTER")]
        public int? QtdeDigitosMedidorAlter { get; set; }

        [PersistenceProperty("CLASS_METRLG")]
        public string ClasseMetrologica { get; set; }

        [PersistenceProperty("CLASS_METRLG_ALTER")]
        public string ClasseMetrologicaAlter { get; set; }

        [PersistenceProperty("MEDIDR_LACRADO")]
        public string MedidorLacrado { get; set; }

        [PersistenceProperty("FLG_SEGND_LIGAC")]
        public string SegundaLigacao { get; set; }

        #endregion

        #region P.S. / Hidrômetro (2ª Ligação)

        [PersistenceProperty("NUM_MEDIDR_2")]
        public string NumeroMedidor2 { get; set; }

        [PersistenceProperty("LEITURA_2")]
        public long? Leitura2 { get; set; }

        [PersistenceProperty("QTD_DIGIT_MEDIDR_2")]
        public int? QtdeDigitosMedidor2 { get; set; }

        [PersistenceProperty("CLASS_METRLG_2")]
        public string ClasseMetrologica2 { get; set; }

       

        [PersistenceProperty("MEDIDR_LACRADO_2")]
        public string MedidorLacrado2 { get; set; }

       
        #endregion

        #region Histórico Consumo
        [PersistenceProperty("DAT_INSTAL")]
        public DateTime DataInstalacao { get; set; }

        [PersistenceProperty("VETOR_OCORRC")]
        public string VetorOcorrencia 
        { 
            get 
            {
                return _vetorOcorrencia;
            } 
            set
            {
                if (value != null)
                {
                    _vetorOcorrencia = value;
                }
                else
                {
                    _vetorOcorrencia = string.Empty;
                }
            }
        }

        private string _vetorOcorrencia;

        [PersistenceProperty("OBS_IMPDM")]
        public string ObservacaoImpedimento { get; set; }

        [PersistenceProperty("SUSPEI_FRAUDE")]
        public string SuspeitaFraude { get; set; }

        [PersistenceProperty("OBS_SUSPEI_FRAUDE")]
        public string SuspeitaFraudeObs { get; set; }

        [PersistenceProperty("EXPCTV_CONSM")]
        public string ExpectativaConsumo { get; set; }


        #endregion

        #region Campos de Controle
        [PersistenceProperty("COD_FUNCN")]
        public int CodigoFuncionario { get; set; }

        [PersistenceProperty("COORD_X")]
        public string CoordenadaX { get; set; }

        [PersistenceProperty("COORD_Y")]
        public string CoordenadaY { get; set; }

        [PersistenceProperty("DAT_VISITA")]
        public DateTime? DataVisita { get; set; }

        //0-Não executado; 1-Executado; 2-Impedido de Execução
        [PersistenceProperty("STATUS_EXEC")]
        public int? StatusExecucao { get; set; }

        [PersistenceProperty("DATAGPS")]
        public DateTime? DataGPS { get; set; }

        #endregion      
        
    }
}

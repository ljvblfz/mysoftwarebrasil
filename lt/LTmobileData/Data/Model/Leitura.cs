using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using GDA;
using LTmobileData.Data.DAL;

namespace LTmobileData.Data.Model
{
    /// <summary>
    /// Leitura
    /// </summary>
    [PersistenceClass("LTDT_ORDENS_LEITURA")]
    [PersistenceBaseDAO(typeof(LeituraDAO))]
    public class Leitura
    {
        [PersistenceProperty("NUM_UC", PersistenceParameterType.Key)]
        public int NUM_UC { get; set; }

        [PersistenceProperty("MES_ANO_FATUR", PersistenceParameterType.Key)]
        public int MES_ANO_FATUR { get; set; }

        [PersistenceProperty("COD_LOCAL", PersistenceParameterType.Key)]
        public int COD_LOCAL { get; set; }

        [PersistenceProperty("TIPO_MEDIC", PersistenceParameterType.Key)]
        public string TIPO_MEDIC { get; set; }

        [PersistenceProperty("COD_EMPRT", PersistenceParameterType.Key)]
        public int COD_EMPRT { get; set; }

        [PersistenceProperty("NUM_RAZAO", PersistenceParameterType.Key)]
        public int NUM_RAZAO { get; set; }

        [PersistenceProperty("ESTADO_SERVC")]
        public int ESTADO_SERVC { get; set; }

        [PersistenceProperty("MATRIC_FUNC")]
        public int MATRIC_FUNC { get; set; }

        [PersistenceProperty("NUM_LIVRO")]
        public string NUM_LIVRO { get; set; }

        [PersistenceProperty("SEQ_LIVRO")]
        public int SEQ_LIVRO { get; set; }

        [PersistenceProperty("COD_IRREGL")]
        public int COD_IRREGL { get; set; }

        [PersistenceProperty("NUM_ROTR_OPER")]
        public int NUM_ROTR_OPER { get; set; }

        [PersistenceProperty("SEQ_ROTR_OPER")]
        public int SEQ_ROTR_OPER { get; set; }

        [PersistenceProperty("ENDER_UC")]
        public string ENDER_UC { get; set; }

        [PersistenceProperty("COMPL_ENDER")]
        public string COMPL_ENDER { get; set; }

        [PersistenceProperty("NUM_MEDIDR")]
        public string NUM_MEDIDR { get; set; }

        [PersistenceProperty("LEITUR_MAX")]
        public int LEITUR_MAX { get; set; }

        [PersistenceProperty("LEITUR_MIN")]
        public int LEITUR_MIN { get; set; }

        [PersistenceProperty("LEITUR_ANTER")]
        public int LEITUR_ANTER { get; set; }

        [PersistenceProperty("LEITUR_VISITA")]
        public int LEITUR_VISITA { get; set; }

        [PersistenceProperty("SITUAC_UC")]
        public string SITUAC_UC { get; set; }

        [PersistenceProperty("MEDIA_CONSUM")]
        public int MEDIA_CONSUM { get; set; }

        [PersistenceProperty("CONSUM_ANTER")]
        public int CONSUM_ANTER { get; set; }

        [PersistenceProperty("QTDE_LEITUR_ESTIMD")]
        public int QTDE_LEITUR_ESTIMD { get; set; }

        [PersistenceProperty("IRREGL_ANTER")]
        public int IRREGL_ANTER { get; set; }

        [PersistenceProperty("IRREGL_ATUAL1")]
        public int IRREGL_ATUAL1 { get; set; }

        [PersistenceProperty("IRREGL_ATUAL2")]
        public int IRREGL_ATUAL2 { get; set; }

        [PersistenceProperty("IRREGL_ATUAL3")]
        public int IRREGL_ATUAL3 { get; set; }

        [PersistenceProperty("DATA_IMPORT")]
        public DateTime DATA_IMPORT { get; set; }

        [PersistenceProperty("HORA_IMPORT")]
        public string HORA_IMPORT { get; set; }

        [PersistenceProperty("DATA_VISITA")]
        public DateTime DATA_VISITA { get; set; }

        [PersistenceProperty("HORA_VISITA")]
        public string HORA_VISITA { get; set; }

        [PersistenceProperty("USUAR_ATLZ")]
        public string USUAR_ATLZ { get; set; }

        [PersistenceProperty("DATA_ATLZ")]
        public DateTime DATA_ATLZ { get; set; }

        [PersistenceProperty("HORA_ATLZ")]
        public string HORA_ATLZ { get; set; }

        [PersistenceProperty("FLAG_REPASSE")]
        public string FLAG_REPASSE { get; set; }

        [PersistenceProperty("COMPL_ATUAL1")]
        public string COMPL_ATUAL1 { get; set; }

        [PersistenceProperty("COMPL_ATUAL2")]
        public string COMPL_ATUAL2 { get; set; }

        [PersistenceProperty("COMPL_ATUAL3")]
        public string COMPL_ATUAL3 { get; set; }

        [PersistenceProperty("DATA_CALENDARIO")]
        public DateTime DATA_CALENDARIO { get; set; }

        [PersistenceProperty("COORD_X")]
        public string COORD_X { get; set; }

        [PersistenceProperty("COORD_Y")]
        public string COORD_Y { get; set; }

        [PersistenceProperty("STATUS_REG")]
        public string STATUS_REG { get; set; }

        [PersistenceProperty("FATOR_MULTIP")]
        public int FATOR_MULTIP { get; set; }

        [PersistenceProperty("QTDE_DIGIT")]
        public int QTDE_DIGIT { get; set; }

        [PersistenceProperty("FASE_MEDIDR")]
        public string FASE_MEDIDR { get; set; }

        [PersistenceProperty("CLASSE_CONSUMO")]
        public string CLASSE_CONSUMO { get; set; }

        [PersistenceProperty("NOME_CONSMD")]
        public string NOME_CONSMD { get; set; }

       /* private string _RotaLivro;

        public string RotaLivro 
        { 
            get
            {
                return _RotaLivro;
            }
            set
            {
                _RotaLivro = value;
            }
        
        }*/

        private string statusLeitua;
        
        public string status
        {   
            get
            {
                statusLeitua = "";
                
                //Repasse
                if (FLAG_REPASSE == "1")
                {
                    statusLeitua = "R";
                }
            
                //Não executado
                if (ESTADO_SERVC == 0)
                {
                    statusLeitua += "";
                }//Executado
                else if (ESTADO_SERVC == 1)
                {
                    statusLeitua += "L";
                }//Impedimento
                else if (ESTADO_SERVC == 2)
                {
                    statusLeitua += "I";
                }
                
                return statusLeitua;
            }
        
        }

        public string EnderecoComplemento
        {
            get
            {
                return ENDER_UC + " " + COMPL_ENDER;
            }
        }

        public string MedidorTipoMed
        {
            get
            {
                return TIPO_MEDIC + "-" + NUM_MEDIDR;
            }
        }
        
    }
}

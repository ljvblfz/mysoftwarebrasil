using System;
using System.Collections.Generic;
using System.Text;

namespace WS_ltMbileData.Data.Model
{
    public class LeituraWS
    {
        #region Contrutores
        
        public LeituraWS()
        { }

        public LeituraWS(int NUM_UC, int MES_ANO_FATUR, int COD_LOCAL, string TIPO_MEDIC, int COD_EMPRT)
        {
            this.NUM_UC = NUM_UC;
            this.MES_ANO_FATUR = MES_ANO_FATUR;
            this.COD_LOCAL = COD_LOCAL;
            this.TIPO_MEDIC = TIPO_MEDIC;
            this.COD_EMPRT = COD_EMPRT;
        }

        public LeituraWS(int ESTADO_SERVC, int NUM_UC, int MES_ANO_FATUR, int COD_LOCAL, string TIPO_MEDIC, int COD_EMPRT, int MATRIC_FUNC, int COD_IRREGL, int NUM_ROTR_OPER, int SEQ_ROTR_OPER, string ENDER_UC, string COMPL_ENDER, string NUM_MEDIDR, int LEITUR_MAX, int LEITUR_MIN, int LEITUR_ANTER, int LEITUR_VISITA, string SITUAC_UC, int MEDIA_CONSUM, int CONSUM_ANTER, int QTDE_LEITUR_ESTIMD, int IRREGL_ANTER, int IRREGL_ATUAL1, int IRREGL_ATUAL2, int IRREGL_ATUAL3, DateTime DATA_IMPORT, string HORA_IMPORT, DateTime DATA_VISITA, string HORA_VISITA, string USUAR_ATLZ, DateTime DATA_ATLZ, string HORA_ATLZ, string FLAG_REPASSE, string COMPL_ATUAL1, string COMPL_ATUAL2, string COMPL_ATUAL3, DateTime DATA_CALENDARIO, int COORD_X, int COORD_Y, string STATUS_REG, int NUM_RAZAO, int FATOR_MULTIP, int QTDE_DIGIT, string FASE_MEDIDR, string CLASSE_CONSUMO, string NUM_LIVRO, int SEQ_LIVRO)
        {
            this.ESTADO_SERVC = ESTADO_SERVC;
            this.NUM_LIVRO = NUM_LIVRO;
            this.SEQ_LIVRO = SEQ_LIVRO;
            this.NUM_UC = NUM_UC;
            this.MES_ANO_FATUR = MES_ANO_FATUR;
            this.COD_LOCAL = COD_LOCAL;
            this.TIPO_MEDIC = TIPO_MEDIC;
            this.COD_EMPRT = COD_EMPRT;
            this.MATRIC_FUNC = MATRIC_FUNC;     
            this.COD_IRREGL = COD_IRREGL; 
            this.NUM_ROTR_OPER = NUM_ROTR_OPER;     
            this.SEQ_ROTR_OPER = SEQ_ROTR_OPER;  
            this.ENDER_UC = ENDER_UC;  
            this.COMPL_ENDER = COMPL_ENDER;  
            this.NUM_MEDIDR = NUM_MEDIDR;  
            this.LEITUR_MAX = LEITUR_MAX;  
            this.LEITUR_MIN = LEITUR_MIN;  
            this.LEITUR_ANTER = LEITUR_ANTER;  
            this.LEITUR_VISITA = LEITUR_VISITA;  
            this.SITUAC_UC = SITUAC_UC;  
            this.MEDIA_CONSUM = MEDIA_CONSUM;  
            this.CONSUM_ANTER = CONSUM_ANTER;  
            this.QTDE_LEITUR_ESTIMD = QTDE_LEITUR_ESTIMD;  
            this.IRREGL_ANTER = IRREGL_ANTER;  
            this.IRREGL_ATUAL1 = IRREGL_ATUAL1;  
            this.IRREGL_ATUAL2 = IRREGL_ATUAL2;  
            this.IRREGL_ATUAL3 = IRREGL_ATUAL3;  
            this.DATA_IMPORT = DATA_IMPORT;  
            this.HORA_IMPORT = HORA_IMPORT;  
            this.DATA_VISITA = DATA_VISITA;  
            this.HORA_VISITA = HORA_VISITA;  
            this.USUAR_ATLZ = USUAR_ATLZ;  
            this.DATA_ATLZ = DATA_ATLZ;  
            this.HORA_ATLZ = HORA_ATLZ;  
            this.FLAG_REPASSE = FLAG_REPASSE;  
            this.COMPL_ATUAL1 = COMPL_ATUAL1;  
            this.COMPL_ATUAL2 = COMPL_ATUAL2;  
            this.COMPL_ATUAL3 = COMPL_ATUAL3;  
            this.DATA_CALENDARIO = DATA_CALENDARIO;  
            this.COORD_X = COORD_X.ToString();  
            this.COORD_Y = COORD_Y.ToString();  
            this.STATUS_REG = STATUS_REG;  
            this.NUM_RAZAO = NUM_RAZAO;  
            this.FATOR_MULTIP = FATOR_MULTIP;  
            this.QTDE_DIGIT = QTDE_DIGIT;  
            this.FASE_MEDIDR = FASE_MEDIDR;
            this.CLASSE_CONSUMO = CLASSE_CONSUMO;

        }

        #endregion

        #region Propriedades

        public int Estado_Servc { get; set; }        
        
        public int NUM_UC { get; set; }        

        public int MES_ANO_FATUR { get; set; }

        public int COD_LOCAL { get; set; }

        public string TIPO_MEDIC { get; set; }

        public int COD_EMPRT { get; set; }

        public string NUM_LIVRO { get; set; }

        public int ESTADO_SERVC { get; set; }

        public int SEQ_LIVRO { get; set; }

        public int MATRIC_FUNC { get; set; }

        public int COD_IRREGL { get; set; }

        public int NUM_ROTR_OPER { get; set; }

        public int SEQ_ROTR_OPER { get; set; }

        public string ENDER_UC { get; set; }

        public string COMPL_ENDER { get; set; }

        public string NUM_MEDIDR { get; set; }

        public int LEITUR_MAX { get; set; }

        public int LEITUR_MIN { get; set; }

        public int LEITUR_ANTER { get; set; }

        public int LEITUR_VISITA { get; set; }

        public string SITUAC_UC { get; set; }

        public int MEDIA_CONSUM { get; set; }

        public int CONSUM_ANTER { get; set; }

        public int QTDE_LEITUR_ESTIMD { get; set; }

        public int IRREGL_ANTER { get; set; }

        public int IRREGL_ATUAL1 { get; set; }

        public int IRREGL_ATUAL2 { get; set; }

        public int IRREGL_ATUAL3 { get; set; }

        public DateTime DATA_IMPORT { get; set; }

        public string HORA_IMPORT { get; set; }

        public DateTime DATA_VISITA { get; set; }

        public string HORA_VISITA { get; set; }

        public string USUAR_ATLZ { get; set; }

        public DateTime DATA_ATLZ { get; set; }

        public string HORA_ATLZ { get; set; }

        public string FLAG_REPASSE { get; set; }

        public string COMPL_ATUAL1 { get; set; }

        public string COMPL_ATUAL2 { get; set; }

        public string COMPL_ATUAL3 { get; set; }

        public DateTime DATA_CALENDARIO { get; set; }

        public string COORD_X { get; set; }

        public string COORD_Y { get; set; }

        public string STATUS_REG { get; set; }

        public int NUM_RAZAO { get; set; }

        public int FATOR_MULTIP { get; set; }

        public int QTDE_DIGIT { get; set; }

        public string FASE_MEDIDR { get; set; }

        public string CLASSE_CONSUMO { get; set; }

        public string NOME_CONSMD { get; set; }

        #endregion 

    }
}

using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using LTmobileData.Data.Model;
using System.Data.SqlServerCe;
using GDA;

namespace LTmobileData.Data.DAL
{
    public class LeituraDAO:BaseDAO<Leitura>
    {
        /// <summary>
        /// Condição Where
        /// </summary>
        string strCondicao;

        /// <summary>
        /// Sql
        /// </summary>
        string strSql;

        /// <summary>
        /// Sql padrão para select 
        /// </summary>
        /// <returns></returns>
        public string Sql()
        {
            string strSqlAux = "SELECT NUM_UC, MES_ANO_FATUR, COD_LOCAL, TIPO_MEDIC, COD_EMPRT,  ESTADO_SERVC, MATRIC_FUNC, COD_IRREGL, NUM_ROTR_OPER, SEQ_ROTR_OPER," +
                      "ENDER_UC, COMPL_ENDER, NUM_MEDIDR, LEITUR_MAX, LEITUR_MIN, LEITUR_ANTER, LEITUR_VISITA, SITUAC_UC, MEDIA_CONSUM," +
                      "CONSUM_ANTER, QTDE_LEITUR_ESTIMD, IRREGL_ANTER, IRREGL_ATUAL1, IRREGL_ATUAL2, IRREGL_ATUAL3, DATA_IMPORT, HORA_IMPORT," +
                      "DATA_VISITA, HORA_VISITA, USUAR_ATLZ, DATA_ATLZ, HORA_ATLZ, FLAG_REPASSE, COMPL_ATUAL1, COMPL_ATUAL2, COMPL_ATUAL3," +
                      "DATA_CALENDARIO, COORD_X, COORD_Y, STATUS_REG, NUM_RAZAO, FATOR_MULTIP, QTDE_DIGIT, FASE_MEDIDR," +
                      "CLASSE_CONSUMO, NUM_LIVRO, SEQ_LIVRO, NOME_CONSMD " +
                      "FROM LTDT_Ordens_Leitura ";
            return strSqlAux;
        }

        public void AlteraStatusLeitura(string Condicao)
        {
            
            /*strSql = "DELETE FROM LTDT_Ordens_Leitura"+                     
                     " WHERE STATUS_REG = 2 " + Condicao + "";*/

            strSql = "DELETE FROM LTDT_Ordens_Leitura" +
                     " WHERE " + Condicao + "";
            CurrentPersistenceObject.ExecuteScalar(strSql);
        
        }

        public List<Leitura> getLeituraNotSync()
        {
            strSql = Sql() +
                     "WHERE STATUS_REG = 2";
            return CurrentPersistenceObject.LoadData(strSql);
        }

        /// <summary>
        /// Retorna Razão.
        /// </summary>
        /// <returns>Razão</returns>
        public List<int> getRazao(int usuario, string servico)
        {
            string condicao ="";

            if (servico == "Repasse")
            { 
                condicao = "AND FLAG_REPASSE = 1";
            }
            else if (servico == "Não Executados")
            {
                condicao = "AND ESTADO_SERVC = 0";
            }
            else if (servico == "Primeira Execução")
            {
                condicao = "AND FLAG_REPASSE = 0";
            }
            
            strSql = "SELECT DISTINCT NUM_RAZAO FROM LTDT_ORDENS_LEITURA WHERE MATRIC_FUNC = " + usuario + " "+condicao+"";
            return CurrentPersistenceObject.LoadValues<int>(strSql);
        }

        /// <summary>
        /// Retorna rota.
        /// </summary>
        /// <returns>Rota</returns>
        public List<string> getRota(string Razao, int usuario, string servico)
        {
            string condicao = "";

            if (servico == "Repasse")
            {
                condicao = "AND FLAG_REPASSE = 1";
            }
            else if (servico == "Não Executados")
            {
                condicao = "AND ESTADO_SERVC = 0";
            }
            else if (servico == "Primeira Execução")
            {
                condicao = "AND FLAG_REPASSE = 0";
            }

            if (Razao == "Todas")
            {
                //strSql = "SELECT DISTINCT NUM_ROTR_OPER,NUM_LIVRO FROM LTDT_ORDENS_LEITURA WHERE MATRIC_FUNC = " + usuario + " ORDER BY NUM_ROTR_OPER, NUM_LIVRO";
                strSql = "SELECT DISTINCT CAST(NUM_ROTR_OPER AS nvarchar(2)) + '/' + NUM_LIVRO AS RotaLivro " +
                         "FROM LTDT_ORDENS_LEITURA WHERE MATRIC_FUNC = " + usuario + " AND NUM_RAZAO = " + Razao + " " + condicao + " ORDER BY RotaLivro";
            }
            else
            {
                //strSql = "SELECT DISTINCT NUM_ROTR_OPER,NUM_LIVRO FROM LTDT_ORDENS_LEITURA WHERE MATRIC_FUNC =" + usuario + " AND NUM_RAZAO = " + Razao + " ORDER BY NUM_ROTR_OPER, NUM_LIVRO";
                strSql = "SELECT DISTINCT CAST(NUM_ROTR_OPER AS nvarchar(2)) + '/' + NUM_LIVRO AS RotaLivro " +
                         "FROM LTDT_ORDENS_LEITURA WHERE MATRIC_FUNC = " + usuario + " AND NUM_RAZAO = " + Razao + " " + condicao + " ORDER BY RotaLivro";
            }
            return CurrentPersistenceObject.LoadValues<string>(strSql);
            
        }

        /// <summary>
        /// Retorna todas as Leituras de UC Ascendente
        /// </summary>
        /// <param name="razao"></param>
        /// <param name="rota"></param>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public List<Leitura> getRotaleituraAsc(string razao, string rota, string livro, string servico, int usuario)
        {
            strSql = Sql() +
                      "WHERE 1>0 " + getCondicao(razao, rota, livro, servico, usuario) + " ORDER BY SEQ_ROTR_OPER ASC";
            return CurrentPersistenceObject.LoadData(strSql);
        }

        /// <summary>
        /// Retorna todas as Leituras de UC Decrescente
        /// </summary>
        /// <param name="razao"></param>
        /// <param name="rota"></param>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public List<Leitura> getRotaleituraDesc(string razao, string rota, string livro, string servico, int usuario)
        {
            strSql = Sql() +
                      "WHERE 1>0 " + getCondicao(razao, rota, livro, servico, usuario) + " ORDER BY SEQ_ROTR_OPER DESC";
            return CurrentPersistenceObject.LoadData(strSql);
        }

        /// <summary>
        /// Retorna a rota de leitura filtrada pelo medidor
        /// </summary>
        /// <param name="razao"></param>
        /// <param name="rota"></param>
        /// <param name="usuario"></param>
        /// <param name="medidor"></param>
        /// <returns></returns>
        public List<Leitura> getRotaLeituraFiltroMedidor(string razao, string rota, string servico, string livro, int usuario, string medidor)
        {
            strSql = Sql() +
                      "WHERE 1>0 " + getCondicao(razao, rota, livro, servico, usuario) + " AND NUM_MEDIDR like '%" + medidor + "%' ";
            return CurrentPersistenceObject.LoadData(strSql);
        }


        /// TODO: TROCAR A FUNÇÃO PARA LOADONDATA

        /// <summary>
        /// Retorna a rota de Leitura filtrada pelo número de UC
        /// </summary>
        /// <param name="razao"></param>
        /// <param name="rota"></param>
        /// <param name="usuario"></param>
        /// <param name="Uc"></param>
        /// <returns></returns>
        public List<Leitura> getRotaLeituraFiltroUc(string razao, string rota, string livro, string servico, int usuario, string Uc)
        {
            strSql = Sql() +
                      "WHERE 1>0 " + getCondicao(razao, rota, livro, servico, usuario) + " AND NUM_UC like '%" + Uc + "%' ";
            return CurrentPersistenceObject.LoadData(strSql);
        }

        /// <summary>
        /// Retorna rota de leitura de Uc´s que tem repasse
        /// </summary>
        /// <param name="razao"></param>
        /// <param name="rota"></param>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public List<Leitura> getRotaLeituraRepasse(string razao, string rota, string livro, string servico, int usuario)
        {
            strSql = Sql() +
                      "WHERE 1>0 " + getCondicao(razao, rota, livro, servico, usuario) + " AND FLAG_REPASSE = 1 ORDER BY SEQ_ROTR_OPER DESC";
            return CurrentPersistenceObject.LoadData(strSql);
        }

        /// <summary>
        /// Retorna rota de leitura de Uc´s que tem repasse
        /// </summary>
        /// <param name="razao"></param>
        /// <param name="rota"></param>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public List<Leitura> getRotaLeituraRepasseAsc(string razao, string rota, string livro, string servico, int usuario)
        {
            strSql = Sql() +
                      "WHERE 1>0 " + getCondicao(razao, rota, livro, servico, usuario) + " AND FLAG_REPASSE = 1 ORDER BY SEQ_ROTR_OPER ASC";
            return CurrentPersistenceObject.LoadData(strSql);
        }


        /// <summary>
        /// Retorna a quantidade de UC´s que tem repasse
        /// </summary>
        /// <param name="razao"></param>
        /// <param name="rota"></param>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public int getQtdeRepasse(int usuario)
        {
            strSql = "SELECT COUNT(NUM_UC)" +
                      "FROM LTDT_Ordens_Leitura " +
                      "WHERE MATRIC_FUNC = " + usuario + " AND FLAG_REPASSE = 1";
            return CurrentPersistenceObject.LoadValues<int>(strSql)[0];

        }

        /// <summary>
        /// Retorna rota de Leitura de Uc´s que não foram executadas (Não foram registradas leitura ou ocorrência de impedimento).
        /// </summary>
        /// <param name="razao"></param>
        /// <param name="rota"></param>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public List<Leitura> getRotaLeituraNExecutados(string razao, string rota, string livro, string servico, int usuario)
        {
            /*strSql = Sql() +
                      "WHERE 1>0 " + getCondicao(razao, rota, livro, usuario) + " AND LEITUR_VISITA = 0 AND (IRREGL_ATUAL1 <> 0 AND IRREGL_ATUAL2 <> 0 AND IRREGL_ATUAL3 <> 0)";
              */
            strSql = Sql() +
                      "WHERE 1>0 " + getCondicao(razao, rota, livro,servico, usuario) + " AND ESTADO_SERVC = 0";

            return CurrentPersistenceObject.LoadData(strSql);
        }

        /// <summary>
        /// Retorna quantidade de rota de Leitura de Uc´s que não foram executadas (Não foram registradas leitura ou ocorrência de impedimento).
        /// </summary>
        /// <param name="razao"></param>
        /// <param name="rota"></param>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public int getQtdNExecutados(int usuario)
        {
            strSql = "SELECT COUNT(NUM_UC)" +
              "FROM LTDT_Ordens_Leitura " +
              "WHERE MATRIC_FUNC = " + usuario + " AND ESTADO_SERVC = 0";
            return CurrentPersistenceObject.LoadValues<int>(strSql)[0];
           
        }

        
        /// <summary>
        /// Retorna rota de Leitura de Uc´s que não foram executadas (Não foram registradas leitura ou ocorrência de impedimento).
        /// </summary>
        /// <param name="razao"></param>
        /// <param name="rota"></param>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public List<Leitura> getRotaLeituraNExecutadosAsc(string razao, string rota, string livro, string servico, int usuario)
        {
            /*strSql = Sql() +
                      "WHERE 1>0 " + getCondicao(razao, rota, livro, usuario) + " AND LEITUR_VISITA = 0 AND (IRREGL_ATUAL1 <> 0 AND IRREGL_ATUAL2 <> 0 AND IRREGL_ATUAL3 <> 0)";
              */
            strSql = Sql() +
                      "WHERE 1>0 " + getCondicao(razao, rota, livro,servico, usuario) + " AND ESTADO_SERVC = 0 ORDER BY SEQ_ROTR_OPER ASC";

            return CurrentPersistenceObject.LoadData(strSql);
        }

        /// <summary>
        /// Retorna rota de Leitura de Uc´s que não foram executadas (Não foram registradas leitura ou ocorrência de impedimento).
        /// </summary>
        /// <param name="razao"></param>
        /// <param name="rota"></param>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public List<Leitura> getRotaLeituraNExecutadosDesc(string razao, string rota, string livro, string servico, int usuario)
        {
            /*strSql = Sql() +
                      "WHERE 1>0 " + getCondicao(razao, rota, livro, usuario) + " AND LEITUR_VISITA = 0 AND (IRREGL_ATUAL1 <> 0 AND IRREGL_ATUAL2 <> 0 AND IRREGL_ATUAL3 <> 0)";
              */
            strSql = Sql() +
                      "WHERE 1>0 " + getCondicao(razao, rota, livro,servico, usuario) + " AND ESTADO_SERVC = 0 ORDER BY SEQ_ROTR_OPER DESC";

            return CurrentPersistenceObject.LoadData(strSql);
        }

        /// <summary>
        /// Retorna rota de leitura com primeira execução (Não é repasse). 
        /// </summary>
        /// <param name="razao"></param>
        /// <param name="rota"></param>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public List<Leitura> getRotaLeituraPriExecucao(string razao, string rota, string livro, string servico, int usuario)
        {
            strSql = Sql() +
                      "WHERE 1>0 " + getCondicao(razao, rota, livro, servico, usuario) + " AND FLAG_REPASSE = 0 ORDER BY SEQ_ROTR_OPER DESC";
            return CurrentPersistenceObject.LoadData(strSql);
        }

        /// <summary>
        /// Retorna rota de leitura com primeira execução (Não é repasse). 
        /// </summary>
        /// <param name="razao"></param>
        /// <param name="rota"></param>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public List<Leitura> getRotaLeituraPriExecucaoAsc(string razao, string rota, string livro, string servico, int usuario)
        {
            strSql = Sql() +
                      "WHERE 1>0 " + getCondicao(razao, rota, livro, servico, usuario) + " AND FLAG_REPASSE = 0 ORDER BY SEQ_ROTR_OPER ASC";
            return CurrentPersistenceObject.LoadData(strSql);
        }

        /// <summary>
        /// Retorna quantidade de rota de leitura com primeira execução (Não é repasse). 
        /// </summary>
        /// <param name="razao"></param>
        /// <param name="rota"></param>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public int getQtdPriExecucao(int usuario)
        {
            strSql = "SELECT COUNT(NUM_UC)" +
                "FROM LTDT_Ordens_Leitura " +
                "WHERE MATRIC_FUNC = " + usuario + " AND FLAG_REPASSE = 0";
            return CurrentPersistenceObject.LoadValues<int>(strSql)[0];
                        
        }


        /// <summary>
        /// Condição da clausula WHERE
        /// </summary>
        /// <param name="razao"></param>
        /// <param name="rota"></param>
        /// <returns></returns>
        public string getCondicao(string razao, string rota, string livro, string servico, int usuario)
        {
            if (razao != "Todas")
            {
                strCondicao += " AND NUM_RAZAO = " + razao + "";
            }

            if (rota != "Todas")
            {
                strCondicao += " AND NUM_ROTR_OPER = " + rota + "";
            }
            if (livro != "Todas")
            {
                strCondicao += " AND NUM_LIVRO = " + livro + "";
            }

            if (servico == "Repasse")
            {
                strCondicao += " AND FLAG_REPASSE = 1";
            }
            else if (servico == "Não Executados")
            {
                strCondicao += " AND ESTADO_SERVC = 0";
            }
            else if (servico == "Primeira Execução")
            {
                strCondicao += " AND FLAG_REPASSE = 0";
            }

            strCondicao += " AND MATRIC_FUNC = " + usuario + "";

            return strCondicao;
  
        }

        /// <summary>
        /// Retorna dados da UC específica
        /// </summary>
        /// <param name="razao"></param>
        /// <param name="rota"></param>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public List<Leitura> getRotaleituraEspecifica(string UC)
        {
            strSql = Sql() +
                      "WHERE NUM_UC = "+UC+"";
            return CurrentPersistenceObject.LoadData(strSql);
        }

        /// <summary>
        /// Retorna quantidade de Uc´s visitadas
        /// </summary>
        /// <param name="razao"></param>
        /// <param name="rota"></param>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public int getQtdVisitados(string razao, string rota, string livro, string servico, int usuario)
        {
            strSql = "SELECT COUNT(NUM_UC)" +
                      "FROM LTDT_Ordens_Leitura " +
                      "WHERE 1>0 " + getCondicao(razao, rota, livro,servico, usuario) + " AND LEITUR_VISITA <> 0";
            return CurrentPersistenceObject.LoadValues<int>(strSql)[0];
        }

        /// <summary>
        /// qUANTIDADE DE UC VISITADA
        /// </summary>
        /// <param name="razao"></param>
        /// <param name="rota"></param>
        /// <param name="livro"></param>
        /// <returns></returns>
        public int getQtdUcVisitada(string razao, string rota, string livro, string servico, int usuario)
        {
            strSql = "SELECT COUNT(*) " +
                      "FROM LTDT_Ordens_Leitura " +
                      "WHERE 1>0 " + getCondicao(razao, rota, livro,"", usuario) + " AND (ESTADO_SERVC = 1 OR ESTADO_SERVC = 2)";
            return CurrentPersistenceObject.LoadValues<int>(strSql)[0];
        }

        /// <summary>
        /// Retorna a quantidade de UC´s
        /// </summary>
        /// <param name="razao"></param>
        /// <param name="rota"></param>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public int getQtdUc(string razao, string rota, string livro, string servico, int usuario)
        {
            strSql = "SELECT COUNT(NUM_UC) " +
                      "FROM LTDT_Ordens_Leitura " +
                      "WHERE 1>0 " + getCondicao(razao, rota, livro, "", usuario) + "";
            return CurrentPersistenceObject.LoadValues<int>(strSql)[0];
        }

        /// <summary>
        /// Retorna a quantidade de UC´s que tem repasse
        /// </summary>
        /// <param name="razao"></param>
        /// <param name="rota"></param>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public int getQtdRepasse(string razao, string rota, string livro, string servico, int usuario)
        {
            strSql = "SELECT COUNT(NUM_UC)" +
                      "FROM LTDT_Ordens_Leitura " +
                      "WHERE 1>0 " + getCondicao(razao, rota, livro, "", usuario) + " AND FLAG_REPASSE = 1";
            return CurrentPersistenceObject.LoadValues<int>(strSql)[0];
        }

        /// <summary>
        /// Retorna a quantidade de Repasse executados
        /// </summary>
        /// <param name="razao"></param>
        /// <param name="rota"></param>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public int getQtdRepasseRealizado(string razao, string rota, string livro, string servico, int usuario)
        {
            strSql = "SELECT COUNT(NUM_UC)" +
                      "FROM LTDT_Ordens_Leitura " +
                      "WHERE 1>0 " + getCondicao(razao, rota, livro, "", usuario) + " AND FLAG_REPASSE = 1 AND LEITUR_VISITA <> 0";
            return CurrentPersistenceObject.LoadValues<int>(strSql)[0];
        }

        public void DeleteTodos()
        {
            string strSql = "DELETE FROM LTDT_ORDENS_LEITURA";
            CurrentPersistenceObject.ExecuteCommand(strSql);
        }

        /// <summary>
        /// Retorna a quantidade de UC´s com impedimento
        /// </summary>
        /// <param name="razao"></param>
        /// <param name="rota"></param>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public int getQtdImpedimento(string razao, string rota, string livro, string servico, int usuario)
        {
            /*strSql = "SELECT COUNT(LTDT_ORDENS_LEITURA.NUM_UC) " +
                    "FROM LTDT_ORDENS_LEITURA, LTTB_IRREGULARIDADES "+
                    "WHERE 1>0 " + getCondicao(razao, rota, livro, usuario) + " " +
                    "AND (LTDT_ORDENS_LEITURA.IRREGL_ATUAL1 = LTTB_IRREGULARIDADES.COD_IRREGL " +
                    "OR LTDT_ORDENS_LEITURA.IRREGL_ATUAL2 = LTTB_IRREGULARIDADES.COD_IRREGL "+
                    "OR LTDT_ORDENS_LEITURA.IRREGL_ATUAL3 = LTTB_IRREGULARIDADES.COD_IRREGL) "+
                    "AND LTTB_IRREGULARIDADES.FLAG_IMPEDIMENTO = 1";*/

            strSql ="SELECT COUNT(*) " +
                    "FROM LTDT_ORDENS_LEITURA " +
                    "WHERE 1>0 " + getCondicao(razao, rota, livro,"", usuario) + " " +
                    "AND ESTADO_SERVC = 2";

            return CurrentPersistenceObject.LoadValues<int>(strSql)[0];
        }

        /// <summary>
        /// Retorna a ultima Uc registrada.
        /// </summary>
        /// <param name="razao"></param>
        /// <param name="rota"></param>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public List<Leitura> getUltimaUcReg(string razao, string rota, string livro, string servico, int usuario)
        {/*
            strSql = "SELECT NUM_UC, MES_ANO_FATUR, COD_LOCAL, TIPO_MEDIC, COD_EMPRT, MATRIC_FUNC, COD_IRREGL, NUM_ROTR_OPER, SEQ_ROTR_OPER, " +
                     "ENDER_UC, COMPL_ENDER, NUM_MEDIDR, LEITUR_MAX, LEITUR_MIN, LEITUR_ANTER, LEITUR_VISITA, SITUAC_UC, MEDIA_CONSUM, " +
                     "CONSUM_ANTER, QTDE_LEITUR_ESTIMD, IRREGL_ANTER, IRREGL_ATUAL1, IRREGL_ATUAL2, IRREGL_ATUAL3, DATA_IMPORT, HORA_IMPORT, " +
                     "DATA_VISITA, HORA_VISITA, USUAR_ATLZ, DATA_ATLZ, HORA_ATLZ, FLAG_REPASSE, COMPL_ATUAL1, COMPL_ATUAL2, COMPL_ATUAL3, " +
                     "DATA_CALENDARIO, COORD_X, COORD_Y, STATUS_REG, NUM_RAZAO, FATOR_MULTIP, QTDE_DIGIT, FASE_MEDIDR, " +
                     "CLASSE_CONSUMO " +
                     "FROM LTDT_ORDENS_LEITURA " +
                     "WHERE MATRIC_FUNC = " + usuario + "" + getCondicao(razao, rota) + " AND (HORA_VISITA = (SELECT MAX(HORA_VISITA) FROM LTDT_ORDENS_LEITURA))";
            return CurrentPersistenceObject.LoadData(strSql);*/

            strSql = "select top (1)*  from LTDT_ORDENS_LEITURA WHERE 1>0 " + getCondicao(razao, rota, livro, servico, usuario) + " order by DATA_VISITA DESC, HORA_VISITA DESC";
            return CurrentPersistenceObject.LoadData(strSql);
        }

        /// <summary>
        /// Recupera as ocorrencias da UC
        /// </summary>
        /// <param name="COD_EMPRT"></param>
        /// <param name="COD_LOCAL"></param>
        /// <param name="NUM_RAZAO"></param>
        /// <param name="MES_ANO_FATUR"></param>
        /// <param name="NUM_UC"></param>
        /// <param name="TIPO_MEDIC"></param>
        /// <returns></returns>
        public List<Leitura> getOcorrenciaUc(int COD_EMPRT, int COD_LOCAL, int NUM_RAZAO, int MES_ANO_FATUR, int NUM_UC, string TIPO_MEDIC)
        { 
            strSql = "SELECT IRREGL_ATUAL1, IRREGL_ATUAL2, IRREGL_ATUAL3"+
                     "FROM LTDT_ORDENS_LEITURA " +
                     "WHERE COD_EMPRT = "+COD_EMPRT+" AND COD_EMPRT = "+COD_LOCAL+" AND NUM_RAZAO = "+NUM_RAZAO+" AND MES_ANO_FATUR = "+MES_ANO_FATUR+" AND NUM_UC = "+NUM_UC+" AND TIPO_MEDIC = "+TIPO_MEDIC+"";
            
            return CurrentPersistenceObject.LoadData(strSql);
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using Data.Model;
using Data.DAL;
using GDA;
using System.Data;
using System.Globalization;

namespace Data.BFL
{
    public class  DistribuicaoFlow
    {
        /// <summary>
        ///  Globalization pt-BR
        /// </summary>
        protected static CultureInfo culture = new CultureInfo("pt-BR"); 

        /// <summary>
        ///  Retorna grupo e a rota correspondente
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <param name="senha"></param>
        /// <returns></returns>
        public static List<Distribuicao> RetornaGrupoRota(int idUsuario, string senha)
        {
            DistribuicaoDAO distribuicaoObj = new DistribuicaoDAO();
            List<Distribuicao> distribuicaoLista = distribuicaoObj.RetornaGrupoRota(idUsuario, senha);
            return distribuicaoLista;
        }

        /// <summary>
        ///  Atualiza uma lista de distribuição
        /// </summary>
        /// <param name="listaDistribuicao"></param>
        /// <returns></returns>
        public static int UpdateList(List<Distribuicao> listaDistribuicao)
        {
            DistribuicaoDAO distribuicaoObj = new DistribuicaoDAO();
            int contador=0;
            int retornoAUX = 0;
            foreach(Distribuicao item in listaDistribuicao)
            {
                //int retornoAUX = distribuicaoObj.InsertDistribuicao(item);
                List<Distribuicao> ListExist = distribuicaoObj.RetornaDistribuicao(item.Grupo, item.Rota, item.Referencia);
                if(ListExist.Count<=0 && !item.Codigo_Agente.Equals(null))
                    retornoAUX = int.Parse(distribuicaoObj.Insert(item).ToString());
                if (ListExist.Count>0)
                    retornoAUX = distribuicaoObj.UpdateDistribuicao(item);
                if (retornoAUX > 0)
                    contador = contador + retornoAUX;
            }
            return contador;
        }

        /// <summary>
        /// Atualiza a distribuição na carga
        /// </summary>
        /// <param name="grupo"></param>
        /// <param name="usuario"></param>
        /// <param name="rota"></param>
        public static void AtualizaDistribuicao(int grupo, int usuario, int rota)
        {
            DistribuicaoDAO distribuicaoObj = new DistribuicaoDAO();
            string where = string.Format("Grupo = {0} AND Codigo_Agente = {1} AND Rota = {2}", grupo, usuario, rota);
            List<Distribuicao> lDistribuicao = distribuicaoObj.ListaDistribuicao(where);
            if (lDistribuicao.Count > 0)
            {
                lDistribuicao[0].Data_Carga = DateTime.Now;
                lDistribuicao[0].Situacao = "C";
                distribuicaoObj.UpdateDistribuicao(lDistribuicao[0]);
                //distribuicaoObj.Update(lDistribuicao[0]);
            }
        }

        /// <summary>
        /// Atualiza a distribuição na descarga
        /// </summary>
        /// <param name="grupo"></param>
        /// <param name="usuario"></param>
        /// <param name="rota"></param>
        public static void AtualizaDistribuicaoDescarga(int grupo, int usuario, int rota)
        {
            DistribuicaoDAO distribuicaoObj = new DistribuicaoDAO();
            string where = string.Format("Grupo = {0} AND Codigo_Agente = {1} AND Rota = {2}", grupo, usuario, rota);
            List<Distribuicao> lDistribuicao = distribuicaoObj.Select(new GDA.Sql.Query(where));
            if (lDistribuicao.Count > 0)
            {
                lDistribuicao[0].Data_Descarga = DateTime.Now;
                lDistribuicao[0].Situacao = "D";
                distribuicaoObj.UpdateDistribuicao(lDistribuicao[0]);
                //distribuicaoObj.Update(lDistribuicao[0]);
            }
        }

        /// <summary>
        /// Retorna uma lista com as distribuições informadas
        /// </summary>
        /// <param name="grupo"></param>
        /// <param name="referencia"></param>
        /// <returns></returns>
        public static List<Distribuicao> ListaDistribuicao(int grupo, DateTime referencia)
        {
            DistribuicaoDAO distribuicaoObj = new DistribuicaoDAO();

            string where = String.Format("Grupo = {0} AND Referencia = CONVERT(DATETIME,{},103)", grupo, referencia);

            return distribuicaoObj.Select(new GDA.Sql.Query(where));
        }

        /// <summary>
        /// Retorna uma lista com as distribuições informadas
        /// </summary>
        /// <param name="grupo"></param>
        /// <param name="referencia"></param>
        /// <returns></returns>
        public static List<Distribuicao> ListaDistribuicao(DateTime referencia)
        {
            DistribuicaoDAO distribuicaoObj = new DistribuicaoDAO();

            string where = String.Format("Referencia = CONVERT(DATETIME,{},103)",referencia);

            return distribuicaoObj.Select(new GDA.Sql.Query(where));
        }

        /// <summary>
        ///  Retorna uma lista com as distribuições apartir de um grupo para criar as distribuiçoes
        /// </summary>
        /// <param name="grupo"></param>
        /// <returns></returns>
        public static DataTable ListaDistribuicao(int grupo)
        {
            LigacoesDAO objLigacoes = new LigacoesDAO();
            DistribuicaoDAO objDistribuicao = new DistribuicaoDAO();

            DataTable dtRota = new DataTable();
            dtRota.Columns.Add("Quant_Matricula");
            dtRota.Columns.Add("Data_Carga");
            dtRota.Columns.Add("Data_Descarga");
            dtRota.Columns.Add("Agente");
            dtRota.Columns.Add("Rota");
            
            DataTable dtRotas = objLigacoes.RetornaRotas(grupo);
            for (int i = 0; i < dtRotas.Rows.Count; i++)
            {
                if (dtRotas.Rows[i]["Rota"] != null)
                {
                    DateTime dataCarga;
                    string dataCargaString = String.Empty;
                    DateTime dataDescarga;
                    string dataDescargaString = String.Empty;

                    int rota = int.Parse(dtRotas.Rows[i]["Rota"].ToString());
                    DataRowCollection linha = objDistribuicao.RetornaDistribuicao(rota, grupo).Rows;
                    if (!String.IsNullOrEmpty(linha[0]["Data_Carga"].ToString()))
                    {
                        dataCarga = DateTime.Parse(linha[0]["Data_Carga"].ToString());
                        dataCargaString = dataCarga.ToString("d", culture);
                    }
                    if (!String.IsNullOrEmpty(linha[0]["Data_Descarga"].ToString()))
                    {
                        dataDescarga = DateTime.Parse(linha[0]["Data_Descarga"].ToString());
                        dataDescargaString = dataDescarga.ToString("d", culture);
                        
                    }
                    if (linha.Count > 0)
                        dtRota.Rows.Add(new object[] { linha[0]["Quant_Matricula"], dataCargaString, dataDescargaString, linha[0]["Agente"], linha[0]["Rota"] });
                    else
                        dtRota.Rows.Add(new object[] { 0, "", "", "", dtRotas.Rows[i]["Rota"] });
                }
            }
            return dtRota;
        }

        /// <summary>
        ///  Lisbera a distribuição para 
        /// </summary>
        /// <param name="grupo"></param>
        /// <param name="referencia"></param>
        /// <returns></returns>
        public static bool LiberarDistribuicao(int grupo, DateTime referencia)
        {
            DistribuicaoDAO distribuicaoObj = new DistribuicaoDAO();
            bool retorno;
            int liberado = distribuicaoObj.LiberarDistribuicao(grupo, referencia);

            if (liberado > 0)
                retorno = true;
            else
                retorno = false;

            return retorno;
        }

        /// <summary>
        ///  Lisbera a distribuição  
        /// </summary>
        /// <param name="grupo"></param>
        /// <param name="referencia"></param>
        /// <returns></returns>
        //public static bool LiberarDistribuicao(int grupo,int rota, DateTime referencia)
        //{
        //    DistribuicaoDAO distribuicaoObj = new DistribuicaoDAO();
        //    bool retorno;
        //    int liberado = distribuicaoObj.LiberarDistribuicao(grupo,rota, referencia);

        //    if (liberado > 0)
        //        retorno = true;
        //    else
        //        retorno = false;

        //    return retorno;
        //}

        /// <summary>
        ///  retorna uma distribuição
        /// </summary>
        /// <param name="grupo"></param>
        /// <param name="rota"></param>
        /// <param name="referencia"></param>
        /// <returns></returns>
        public static List<Distribuicao> RetornaDistribuicao(int grupo, int rota, DateTime? referencia)
        {
            DistribuicaoDAO distribuicaoObj = new DistribuicaoDAO();
            return distribuicaoObj.RetornaDistribuicao(grupo, rota, referencia);
        }

        /// <summary>
        ///  Retorna uma tabela de dados para o acompanhamento on line
        /// </summary>
        /// <param name="grupo"></param>
        /// <returns></returns>
        public static DataTable RetornaAcompanhamento(int grupo)
        {
            LigacoesDAO objLigacoes = new LigacoesDAO();

            return objLigacoes.RetornaAcompanhamento(grupo);
        }
    }
}

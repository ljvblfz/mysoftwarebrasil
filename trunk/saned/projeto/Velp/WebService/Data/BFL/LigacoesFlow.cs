using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using GDA;
using Data.DAL;
using Data.Model;
using System.Data;

namespace Data.BFL
{
    public class LigacoesFlow
    {
        /// <summary>
        ///  Metodo que retorna todos os dados
        /// </summary>
        /// <returns></returns>
        public static List<Ligacoes> Lista()
        {
            LigacoesDAO Ligacoes = new LigacoesDAO();
            return Ligacoes.Lista();
        }

        /// <summary>
        ///  Metodo que retorna dados
        /// </summary>
        /// <returns></returns>
        public static List<Ligacoes> Lista(int CDC)
        {
            LigacoesDAO Ligacoes = new LigacoesDAO();
            string where = String.Format("CDC = {0}", CDC);
            return Ligacoes.Select(new GDA.Sql.Query(where));
        }

        /// <summary>
        ///  Metodo que retorna uma lista vazia
        /// </summary>
        /// <returns></returns>
        public static List<Ligacoes> ListaVazia()
        {
            List<Ligacoes> List = new List<Ligacoes>();
            return List;
        }

        /// <summary>
        /// Metodo que insere um registro na tabela
        /// </summary>
        /// <returns></returns>
        public static void Insert(List<Ligacoes> ListLigacoes)
        {
            LigacoesDAO Ligacoes = new LigacoesDAO();

            try
            {
                foreach(Ligacoes ItemLigacoes in ListLigacoes)
                    Ligacoes.Insert(ItemLigacoes);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        ///     Retorna os dados de Ligações informando a matricula
        /// </summary>
        /// <returns></returns>
        public static List<Ligacoes> RetornaLigacoes(List<VoltaLeitura> listaVoltaLeitura)
        {
            // Instancia da DAO
            LigacoesDAO objLigacoes = new LigacoesDAO();
            List<Ligacoes> listaLigacoes = new List<Ligacoes>();

            // Percorre todos os resultados adicionando na lista de saida
            foreach (VoltaLeitura itemVoltaLeitura in listaVoltaLeitura)
            {
                // Condição
                string where = string.Format("CDC = {0}", itemVoltaLeitura.CDC);

                // Retorna uma lista OBS:(A matricula e o campo unico.)
                List<Ligacoes> listaLigacoesAUX = objLigacoes.RetornaLigacoes(where);

                if (listaLigacoesAUX.Count() > 0)
                    listaLigacoes.Add(listaLigacoesAUX[0]);
            }

            return listaLigacoes;
        }

        /// <summary>
        ///     Retorna os dados de Ligações informando a matricula
        /// </summary>
        /// <returns></returns>
        public static List<Ligacoes> RetornaLigacoes(string where)
        {
            // Instancia da DAO
            LigacoesDAO objLigacoes = new LigacoesDAO();

            // Retorna uma lista OBS:(A matricula e o campo unico.)
            return objLigacoes.RetornaLigacoes(where);
        }

        /// <summary>
        /// Retorna os dados de uma ligação
        /// </summary>
        /// <param name="CDC"></param>
        /// <returns></returns>
        public static List<Ligacoes> RetornaLigacoes(int CDC)
        {
            // Instancia da DAO
            LigacoesDAO objLigacoes = new LigacoesDAO();
            List<Ligacoes> listaLigacoes = new List<Ligacoes>();

            // Condição
            string where = string.Format("CDC = {0}", CDC);

            // Retorna uma lista OBS:(A matricula e o campo unico.)
            List<Ligacoes> listaLigacoesAUX = objLigacoes.RetornaLigacoes(where);

            if (listaLigacoesAUX.Count()>0)
                listaLigacoes.Add(listaLigacoesAUX[0]);

            return listaLigacoes;
        }

        /// <summary>
        ///  Retorna todas as rotas relacionadas ao grupo
        /// </summary>
        /// <returns></returns>
        public static List<Ligacoes> RetornaRotas(int Grupo)
        {
            // Instancia da DAO
            LigacoesDAO objLigacoes = new LigacoesDAO();
            List<Ligacoes> listaLigacoes = new List<Ligacoes>(); 

            DataTable dtRotas = objLigacoes.RetornaRotas(Grupo);
                    
            for (int i = 0; i < dtRotas.Rows.Count; i++)
            {
                if (dtRotas.Rows[i]["Rota"] != null)
                {
                    Ligacoes ligacoes = new Ligacoes();
                    int rota = int.Parse(dtRotas.Rows[i]["Rota"].ToString());
                    ligacoes.Rota = rota;
                    listaLigacoes.Add(ligacoes);
                }
            }

            return listaLigacoes;
        }

        /// <summary>
        /// Retorna as ligações de todas as matriculas relacionadas 
        /// </summary>
        /// <param name="CDC"></param>
        /// <returns></returns>
        public static List<Ligacoes> RetornaCDCrelacionadas(int CDC)
        {
            // Instancia da DAO
            LigacoesDAO objLigacoes = new LigacoesDAO();
            List<Ligacoes> listaLigacoes = objLigacoes.RetornaCDCrelacionadas(CDC);
            if (listaLigacoes.Count == 0)
            {
                string where = String.Format("CDC = {0}", CDC);
                listaLigacoes = objLigacoes.Select(new GDA.Sql.Query(where));
            }
            return listaLigacoes;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static int QuantidadeRotas(int grupo)
        {
            LigacoesDAO Ligacoes = new LigacoesDAO();
            return Ligacoes.QuantidadeRotas(grupo);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using Data.Model;

namespace Data.DAL
{
    public class DistribuicaoGridDAO : BaseDAO<DistribuicaoGrid>
    {

        /// <summary>
        ///  Lista Dados de Distribuição
        /// </summary>
        /// <param name="referencia"></param>
        /// <returns></returns>
        public DistribuicaoGrid ListaDistribuicao(int grupo,DateTime referencia)
        {
            DistribuicaoGrid distribuicao = new DistribuicaoGrid();
            distribuicao.Quantidade_Roteiro = RetornaQuantidadeRoteiros(grupo);
            distribuicao.Quantidade_Distribuido = RetornaQuantidadeDistribuida(grupo, referencia);
            distribuicao.Quantidade_Descarga = RetornaQuantidadeDescarregada(grupo, referencia);
            distribuicao.Grupo = grupo;

            /// <summary>
            ///  Campo que define a situação da distribuição
            ///     - L (liberada)
            ///     - C (carregada)
            ///     - D (descarregada)
            ///     - B (bloqueada)
            /// </summary>
            string situacao = RetornaSituaçãoDistribuida(grupo, referencia);
            switch (situacao)
            {
                case "L":
                    {
                        distribuicao.Situacao = "Liberada";
                        break;
                    }
                case "C":
                    {
                        distribuicao.Situacao = "Carregada";
                        break;
                    }
                case "D":
                    {
                        distribuicao.Situacao = "Descarregada";
                        break;
                    }
                case "B":
                    {
                        distribuicao.Situacao = "Bloqueada";
                        break;
                    }
                default:
                    {
                        distribuicao.Situacao = "Não Atribuida";
                        break;
                    }
            }
            return distribuicao;
        }

        /// <summary>
        ///  Retorna a situação da distribuição
        /// </summary>
        /// <param name="grupo"></param>
        /// <returns></returns>
        public string RetornaSituaçãoDistribuida(int grupo, DateTime referencia)
        {
            string sql = @"
                            SELECT 
                                Situacao 
                            FROM IDA_DISTRIBUICAO 
                            WHERE 
                                Referencia = CONVERT(DATETIME,'"+referencia+@"',103)
	                            AND grupo = "+grupo+@"
                          ";
            object objQuantidadeDistribuida = CurrentPersistenceObject.ExecuteScalar(sql);
            if (objQuantidadeDistribuida == null)
                objQuantidadeDistribuida = " ";
            return objQuantidadeDistribuida.ToString();
        }

        /// <summary>
        ///  Retorna a quantidade de Descarregada
        /// </summary>
        /// <param name="grupo"></param>
        /// <returns></returns>
        public int RetornaQuantidadeDescarregada(int grupo, DateTime referencia)
        {
            string sql = @"
                            SELECT 
                                COUNT(*) 
                            FROM IDA_DISTRIBUICAO 
                            WHERE 
                                Referencia = CONVERT(DATETIME,?referencia,103)
	                            AND grupo = ?grupo
                                AND Situacao = 'D'
                          ";
            object objQuantidadeDescarregada = CurrentPersistenceObject.ExecuteScalar(sql, new GDAParameter("?grupo", grupo), new GDAParameter("?referencia", referencia));
            int quantidadedescarregada = 0;
            if (objQuantidadeDescarregada != null)
                quantidadedescarregada = int.Parse(objQuantidadeDescarregada.ToString());
            return quantidadedescarregada;
        }

        /// <summary>
        ///  Retorna a quantidade de Distribuida
        /// </summary>
        /// <param name="grupo"></param>
        /// <returns></returns>
        public int RetornaQuantidadeDistribuida(int grupo, DateTime referencia)
        {
            string sql = @"
                            SELECT 
                                COUNT(*) 
                            FROM IDA_DISTRIBUICAO 
                            WHERE 
                                Referencia = CONVERT(DATETIME,?referencia,103)
	                            AND grupo = ?grupo
                          ";
            object objQuantidadeDistribuida = CurrentPersistenceObject.ExecuteScalar(sql, new GDAParameter("?grupo", grupo), new GDAParameter("?referencia", referencia));
            int quantidadedistribuida = 0;
            if (objQuantidadeDistribuida != null)
                quantidadedistribuida = int.Parse(objQuantidadeDistribuida.ToString());
            return quantidadedistribuida;
        }

        /// <summary>
        ///  Retorna a quantidade de roteiros
        /// </summary>
        /// <param name="grupo"></param>
        /// <returns></returns>
        public int RetornaQuantidadeRoteiros(int grupo)
        {
            LigacoesDAO ligacoes = new LigacoesDAO();
            return ligacoes.QuantidadeRotas(grupo);
        }

    }
}



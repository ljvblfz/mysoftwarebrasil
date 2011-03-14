using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using Data.Model;

namespace Data.DAL
{
    public class GrupoDAO : BaseDAO<GrupoONP>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<GrupoONP> ListaGrupo()
        {
            string sql = @"
                            SELECT 
                                *
							FROM IDA_GRUPOS
                            ORDER BY Grupo
                         ";
            return  CurrentPersistenceObject.LoadData(sql);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="grupo"></param>
        /// <param name="rotaInicial"></param>
        /// <param name="rotaFinal"></param>
        /// <returns></returns>
        public int RetornaSetor(int grupo, int rotaInicial, int rotaFinal)
        {
            string sql = @"
                            SELECT DISTINCT 
                                Setor AS Grupo
                            FROM IDA_LIGACOES 
                            WHERE 
                                rota BETWEEN ?rotaInicial AND ?rotaFinal 
                                AND grupo = ?grupo
                          ";
            object setor = CurrentPersistenceObject.ExecuteScalar(sql, new GDAParameter("?grupo", grupo), new GDAParameter("?rotaInicial", rotaInicial), new GDAParameter("?rotaFinal", rotaFinal));
            return int.Parse(setor.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="grupo"></param>
        /// <returns></returns>
        public DateTime RetornaReferencia(int grupo)
        {
            string sql = @"
                            SELECT 
                                referencia 
                            FROM IDA_GRUPOS 
                            WHERE grupo = ?grupo
                          ";
            object setor = CurrentPersistenceObject.ExecuteScalar(sql, new GDAParameter("?grupo", grupo));
            return DateTime.Parse(setor.ToString());
        }
    }
}

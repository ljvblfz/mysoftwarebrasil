using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using DeviceProject.DATA.dataSaned.Model;
using System.Data.SqlServerCe;

namespace DeviceProject.DATA.dataSaned.Dao
{
    /// <summary>
    ///  Classe DAO da log de erro
    /// </summary>
    public class LogErroDao : LogErro
    {
        /// <summary>
        ///     Insert na tabela de erro
        /// </summary>
        /// <param name="obj">Objeto de erro</param>
        public void Insert(LogErro obj)
        {
            ConectDBSabed sql = new ConectDBSabed();
            string query = "";
            try
            {
                sql.cmd.CommandText = @"SELECT 
	                                        CASE WHEN MAX(id) IS NULL
		                                        THEN 1 
		                                        ELSE MAX(id)+1
	                                        END
                                        FROM TBLOGERRO";
                object id = sql.cmd.ExecuteScalar();

                query = string.Format(
                                        @"
                                            INSERT INTO " + TableName + @"
                                            (
                                                id
                                                ,rotina
                                                ,tabela
                                                ,data
                                                ,erro
                                            )
                                            VALUES
                                            (
                                                {0}
                                                ,'{1}'
                                                ,'{2}'
                                                ,CONVERT(DATETIME,'{3}',102)
                                                ,CONVERT(nchar(3999),'{4}',102)
                                            )"
                                    ,
                                        id
                                        , obj.rotina
                                        , obj.tabela
                                        , String.Format("{0:M/d/yyyy}", obj.data)
                                        ,obj.erro
                                   );
                sql.cmd.CommandText = query;

                sql.cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sql.CloseConection();
            }
        }
    }
}

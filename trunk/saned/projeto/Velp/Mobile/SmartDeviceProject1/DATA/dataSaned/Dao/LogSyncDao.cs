using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using DeviceProject.DATA.dataSaned.Model;
using System.Data;
using System.Data.SqlServerCe;

namespace DeviceProject.DATA.dataSaned.Dao
{
    public class LogSyncDao
    {
        /// <summary>
        /// Insere um registro
        /// </summary>
        /// <param name="obj">Objeto da model</param>
        public void Insert(LogSync obj)
        {
            if (Exist(obj.Matricula)>0)
            {
                return;
            }

            ConectDBSabed sql = new ConectDBSabed();
            try
            {
                List<SqlCeParameter> parametros = new List<SqlCeParameter>();
                SqlCeParameter param1 = sql.cmd.CreateParameter();
                param1.ParameterName = "@Matricula";
                param1.Value = obj.Matricula;
                parametros.Add(param1);
                GC.SuppressFinalize(param1);

                SqlCeParameter param2 = sql.cmd.CreateParameter();
                param2.ParameterName = "@DataSync";
                param2.Value = obj.DataSync;
                parametros.Add(param2);
                GC.SuppressFinalize(param2);

                SqlCeParameter param3 = sql.cmd.CreateParameter();
                param3.ParameterName = "@TipoSync";
                param3.Value = obj.TipoSync;
                parametros.Add(param3);
                GC.SuppressFinalize(param2);

                sql.cmd.Parameters.AddRange(parametros.ToArray());
                sql.cmd.CommandText = @"
                                        INSERT INTO 
                                            TBLOGSYNC(MATRICULA, DATASYNC, TIPOSYNC)
                                            VALUES(@Matricula,@DataSync,@TipoSync)
                                        ";
                sql.cmd.ExecuteNonQuery();                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sql.CloseConection();
                GC.SuppressFinalize(sql);
            }
        }

        /// <summary>
        /// Deleta o registro especifico
        /// </summary>
        /// <param name="obj">Objeto da model</param>
        public void Delete(LogSync obj)
        {
            ConectDBSabed sql = new ConectDBSabed();
            try
            {
                sql.cmd.CommandText = string.Format(@"delete from TBLOGSYNC where MATRICULA = {0}", obj.Matricula);
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

        /// <summary>
        /// Deleta todos os dados da tabela
        /// </summary>
        public void DeleteAll()
        {
            ConectDBSabed sql = new ConectDBSabed();

            try
            {
                sql.cmd.CommandText = string.Format(@"delete from TBLOGSYNC");
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

        /// <summary>
        /// Retorna uma lista com todos os dados
        /// </summary>
        public List<LogSync> Select()
        {
            List<LogSync> lst = new List<LogSync>();
            ConectDBSabed sql = new ConectDBSabed();
            IDataReader dReader;             

            try
            {
                sql.cmd.CommandText = string.Format(@"Select * from TBLOGSYNC");
                dReader = sql.cmd.ExecuteReader();                

                while (dReader.Read())
                {
                    LogSync NovoRegistro = new LogSync();

                    NovoRegistro.Matricula = long.Parse(dReader["MATRICULA"].ToString());
                    NovoRegistro.DataSync = (DateTime)dReader["DATASYNC"];
                    NovoRegistro.TipoSync = dReader["TIPOSYNC"].ToString();                    

                    // adciona a lista
                    lst.Add(NovoRegistro);
                }

                dReader.Close();

                return lst;
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

        /// <summary>
        ///  Verifica se a matricula existe
        /// </summary>
        /// <param name="matricula">numero da matricula</param>
        /// <returns>quantidade de matriculas cadastradas (1 ou 0)</returns>
        public int Exist(long matricula)
        {
            int count = 0;
            ConectDBSabed sql = new ConectDBSabed();
            IDataReader dReader;
            try
            {
                SqlCeParameter param = sql.cmd.CreateParameter();
                param.ParameterName = "@Matricula";
                param.Value = matricula;
                sql.cmd.Parameters.Add(param);
                sql.cmd.CommandText = string.Format(@"SELECT COUNT(*) FROM TBLOGSYNC WHERE MATRICULA = @Matricula");
                object value = sql.cmd.ExecuteScalar();
                if (value != null)
                    count = int.Parse(value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sql.CloseConection();
            }
            return count;
        }



    }
}

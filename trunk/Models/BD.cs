using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using Castle.ActiveRecord;
using Castle.ActiveRecord.Framework.Config;
using NHibernate.Cfg;
using Castle.ActiveRecord.Framework;
using NHibernate;
using System.Data;

namespace BlogSample.Models
{
    class BD
    {
        public static List<object> pegaIP()
        {
            string host = Dns.GetHostName();
            List<object> s = new List<object>();
            IPAddress[] addressList = Dns.GetHostByName(host).AddressList;
            for (int i = 0; i < addressList.Length; i++)
                s.Add(addressList[i].ToString());

            return s;
        }

        public static void getCofig()
        {
            string[] retorno = new string[2];
            Configuration[] confg = ActiveRecordMediator.GetSessionFactoryHolder().GetAllConfigurations();
            object stringConect = confg[0].Properties["hibernate.connection.connection_string"];

            if (stringConect != null)
            {
            }
            //ActiveRecordMediator.GetSessionFactoryHolder().GetSessionFactory(typeof(object)).ConnectionProvider.GetConnection();
        }

        public static List<IDictionary<string, object>> getDados(string tabela)
        {
            List<IDictionary<string, object>> retorno = new List<IDictionary<string, object>>();
            ISessionFactoryHolder factoryHolder = ActiveRecordMediator.GetSessionFactoryHolder();

            ISession session = factoryHolder.CreateSession(typeof(object));
            try
            {
                IDbCommand cmd = session.Connection.CreateCommand();
                cmd.CommandText = @"
							        SELECT
								        C.COLUMN_NAME AS NOME,
								        CASE
									         -- TIPO bigint
									         WHEN C.DATA_TYPE = 'bigint' AND C.IS_NULLABLE = 'NO'
									         THEN 'decimal'
									         WHEN C.DATA_TYPE = 'bigint' AND C.IS_NULLABLE = 'YES'
									         THEN 'decimal?'

									         -- TIPO bit
									         WHEN C.DATA_TYPE = 'bit' AND C.IS_NULLABLE = 'NO'
									         THEN 'bool'
									         WHEN C.DATA_TYPE = 'bit' AND C.IS_NULLABLE = 'YES'
									         THEN 'bool?'

									         -- TIPO decimal
									         WHEN C.DATA_TYPE = 'decimal' AND C.IS_NULLABLE = 'NO'
									         THEN 'decimal'
									         WHEN C.DATA_TYPE = 'decimal' AND C.IS_NULLABLE = 'YES'
									         THEN 'decimal?'

									         -- TIPO int
									         WHEN C.DATA_TYPE = 'int' AND C.IS_NULLABLE = 'NO'
									         THEN 'int'
									         WHEN C.DATA_TYPE = 'int' AND C.IS_NULLABLE = 'YES'
									         THEN 'int?'

									         -- TIPO money
									         WHEN C.DATA_TYPE = 'money' AND C.IS_NULLABLE = 'NO'
									         THEN 'double'
									         WHEN C.DATA_TYPE = 'money' AND C.IS_NULLABLE = 'YES'
									         THEN 'double?'

									         -- TIPO numeric
									         WHEN C.DATA_TYPE = 'numeric' AND C.IS_NULLABLE = 'NO'
									         THEN 'double'
									         WHEN C.DATA_TYPE = 'numeric' AND C.IS_NULLABLE = 'YES'
									         THEN 'double?'

									         -- TIPO real
									         WHEN C.DATA_TYPE = 'real' AND C.IS_NULLABLE = 'NO'
									         THEN 'double'
									         WHEN C.DATA_TYPE = 'real' AND C.IS_NULLABLE = 'YES'
									         THEN 'double?'

									         -- TIPO smallint
									         WHEN C.DATA_TYPE = 'smallint' AND C.IS_NULLABLE = 'NO'
									         THEN 'int'
									         WHEN C.DATA_TYPE = 'smallint' AND C.IS_NULLABLE = 'YES'
									         THEN 'int?'

									         -- TIPO smallmoney
									         WHEN C.DATA_TYPE = 'smallmoney' AND C.IS_NULLABLE = 'NO'
									         THEN 'decimal'
									         WHEN C.DATA_TYPE = 'smallmoney' AND C.IS_NULLABLE = 'YES'
									         THEN 'decimal?'

									         -- TIPO tinyint
									         WHEN C.DATA_TYPE = 'tinyint' AND C.IS_NULLABLE = 'NO'
									         THEN 'int'
									         WHEN C.DATA_TYPE = 'tinyint' AND C.IS_NULLABLE = 'YES'
									         THEN 'int?'

									         -- TIPO float
									         WHEN C.DATA_TYPE = 'float' AND C.IS_NULLABLE = 'NO'
									         THEN 'float'
									         WHEN C.DATA_TYPE = 'float' AND C.IS_NULLABLE = 'YES'
									         THEN 'float?'

									         -- TIPO date
									         WHEN
										        (
											        C.DATA_TYPE = 'date' OR
											        C.DATA_TYPE = 'datetime2' OR
											        C.DATA_TYPE = 'datetime' OR
											        C.DATA_TYPE = 'datetimeoffset' OR
											        C.DATA_TYPE = 'smalldatetime' OR
											        C.DATA_TYPE = 'time'
										        ) AND C.IS_NULLABLE = 'NO'
									         THEN 'DateTime'
									         WHEN
										        (
											        C.DATA_TYPE = 'date' OR
											        C.DATA_TYPE = 'datetime2' OR
											        C.DATA_TYPE = 'datetime' OR
											        C.DATA_TYPE = 'datetimeoffset' OR
											        C.DATA_TYPE = 'smalldatetime' OR
											        C.DATA_TYPE = 'time'
										        ) AND C.IS_NULLABLE = 'YES'
									         THEN 'DateTime?'

									         ELSE 'string'
								        END AS TIPO,
								        C.CHARACTER_MAXIMUM_LENGTH AS MAXLEN,
								        CASE WHEN (SELECT CONSTRAINT_NAME FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE TABLE_NAME = '{$tabela}' AND COLUMN_NAME = C.COLUMN_NAME) IS NOT NULL 
									         THEN 1
									         ELSE 0
								        END AS PRIMARIA
							        FROM INFORMATION_SCHEMA.COLUMNS C
							        LEFT JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE CU ON CU.COLUMN_NAME = C.COLUMN_NAME
							        WHERE C.TABLE_NAME = '" + tabela + @"'
                                   ";
                // Executa o comando
                IDataReader dReader;
                dReader = cmd.ExecuteReader();

                while (dReader.Read())
                {
                    IDictionary<string, object> openWith = new Dictionary<string, object>();
                    openWith.Add("NOME", dReader["NOME"]);
                    openWith.Add("TIPO", dReader["TIPO"]);
                    openWith.Add("MAXLEN", dReader["MAXLEN"]);
                    openWith.Add("PRIMARIA", dReader["PRIMARIA"]);
                    retorno.Add(openWith);
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                factoryHolder.ReleaseSession(session);
            }

            return retorno;

        }


        public static object[] getTabelas()
        {
            List<object> retorno = new List<object>();
            ISessionFactoryHolder factoryHolder = ActiveRecordMediator.GetSessionFactoryHolder();

            ISession session = factoryHolder.CreateSession(typeof(object));
            try
            {
                IDbCommand cmd = session.Connection.CreateCommand();
                cmd.CommandText = @"SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES";
                // Executa o comando
                IDataReader dReader;
                dReader = cmd.ExecuteReader();

                while (dReader.Read())
                {
                    IDictionary<string, object> openWith = new Dictionary<string, object>();
                    retorno.Add(dReader["TABLE_NAME"]);
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                factoryHolder.ReleaseSession(session);
            }

            return retorno.ToArray();
        }

    }
}

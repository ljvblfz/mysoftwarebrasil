//
//  Copyright (c) 2008, Ivan Paulovich
//  All rights reserved.
//
//  Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
//
//  * Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
//
//  * Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other 
//  materials provided with the distribution.
//
//  * Neither the name of Paulovich nor the names of its contributors may be used to endorse or promote products derived from this software without specific prior 
//  written permission.
//
//  THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT 
//  LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT 
//  OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT 
//  LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON 
//  ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE 
//  USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
//
//  Authors: 
//           
//           * Ivan Paulovich (ivan@100loop.com)
//           Blog: http://www.100loop.com/blogs/           
//           Messenger: ivanpaulovich@hotmail.com 
//
//           * André Paulovich (paulovich@100loop.com)     
//           Blog: http://www.100loop.com/blogs/           
//           Messenger: andrepaulovich@hotmail.com
//

using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;
using MySql.Data.MySqlClient;
using Paulovich.Data.Dialect;
using Paulovich.Data.Resources;

namespace Paulovich.Data
{
    /// <summary>
    /// Classe de acesso a dados
    /// </summary>
    public class Command
    {
        #region members

        /// <summary>
        /// String de Conexão Atual
        /// </summary>
        [ThreadStatic]
        private static ConnectionStringSettings currentConnectionStringSettings;

        /// <summary>
        /// Command genérico
        /// </summary>
        private IDbCommand command;

        /// <summary>
        /// Stream para o log das operações no banco de dados
        /// </summary>
        public static TextWriter Log { get; set; }

        #endregion

        #region properties

        /// <summary>
        /// Provider Atual
        /// </summary>
        public DataBaseType DataBaseType { get; set; }

        /// <summary>
        /// Current CommandType mode.
        /// </summary>
        public CommandType CommandType
        {
            get { return DbCommand.CommandType; }
            set { DbCommand.CommandType = value; }
        }

        /// <summary>
        /// Current CommandType mode.
        /// </summary>
        public string CommandText
        {
            get { return DbCommand.CommandText; }
            set { DbCommand.CommandText = value; }
        }

        /// <summary>
        /// Command
        /// </summary>
        public IDbCommand DbCommand
        {
            get { return command; }
            set { command = value; }
        }

        /// <summary>
        /// Dialeto Atual
        /// </summary>
        public Dialect.Dialect CurrentDialect { get; set; }

        #endregion

        #region constructors

        /// <summary>
        /// Cria um Command usando a string de conexão 'dbPortal'
        /// </summary>
        public Command()
        {

            Initialize();

        }

        /// <summary>
        /// Cria um novo Command
        /// </summary>
        /// <param name="connectionString">String de Conexão</param>
        /// <param name="providerName">Provider. Tipos suportados: System.Data.SqlClient | System.Data.OracleClient | System.Data.OleDb | System.Data.Odbc</param>
        public Command(string connectionString, string providerName)
        {

            #region debug

            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentNullException("connectionString", Messages.InvalidArgumentValue);

            if (string.IsNullOrEmpty(providerName))
                throw new ArgumentNullException("providerName", Messages.InvalidArgumentValue);

            #endregion

            currentConnectionStringSettings = new ConnectionStringSettings("dbPortal", connectionString, providerName);

            Initialize();
        }

        /// <summary>
        /// Nome da chave de 
        /// </summary>
        /// <param name="connectionName"></param>
        public Command(string connectionName)
        {
            #region debug

            if (string.IsNullOrEmpty(connectionName))
                throw new ArgumentNullException("connectionName", Messages.InvalidArgumentValue);

            #endregion

            currentConnectionStringSettings = ConfigurationManager.ConnectionStrings[connectionName];

            if (currentConnectionStringSettings == null)
            {
                throw new Exception(string.Format("Connection '{0}' not found.", connectionName));
            }

            Initialize();
        }

        #endregion

        #region private methods

        /// <summary>
        /// Define o DataBaseType e cria o DBCommand
        /// </summary>
        private void Initialize()
        {

            if (currentConnectionStringSettings == null)
            {

                //
                // Carrega do web.config
                //                   
                currentConnectionStringSettings = ConfigurationManager.ConnectionStrings["dbPortal"];
            }

            if (currentConnectionStringSettings == null)
            {
                throw new Exception("Current Connection String Settings Not Set");
            }

            if (currentConnectionStringSettings != null)
            {

                switch (currentConnectionStringSettings.ProviderName)
                {
                    case "System.Data.SqlClient":
                        DataBaseType = DataBaseType.Sql;
                        break;
                    case "System.Data.OracleClient":
                        DataBaseType = DataBaseType.Oracle;
                        break;
                    case "MySql.Data.MySqlClient":
                        DataBaseType = DataBaseType.MySql;
                        break;
                    default:
                        DataBaseType = currentConnectionStringSettings.ProviderName == "System.Data.OleDb"
                                           ? DataBaseType.OleDb
                                           : DataBaseType.Oledbc;
                        break;
                }

                CreateCommand();
            }
        }

        /// <summary>
        /// Cria o command de acordo com o DataBaseType
        /// </summary>
        private void CreateCommand()
        {
            if (command == null)
            {
                switch (DataBaseType)
                {
                    case DataBaseType.Oledbc:
                        {
                            command = new OdbcCommand {Connection = new OdbcConnection()};
                            CurrentDialect = new SqlServer();
                            break;
                        }

                    case DataBaseType.OleDb:
                        {
                            command = new OleDbCommand {Connection = new OleDbConnection()};
                            CurrentDialect = new SqlServer();
                            break;
                        }

                    case DataBaseType.Oracle:
                        {
                            command = new OracleCommand {Connection = new OracleConnection()};
                            CurrentDialect = new Oracle();
                            break;
                        }

                    case DataBaseType.Sql:
                        {
                            command = new SqlCommand {Connection = new SqlConnection()};
                            CurrentDialect = new SqlServer();
                            break;
                        }

                    case DataBaseType.MySql:
                        {
                            command = new MySqlCommand {Connection = new MySqlConnection()};
                            CurrentDialect = new MySqlDialect();
                            break;
                        }

                    default:
                        {
                            command = new OdbcCommand {Connection = new OdbcConnection()};
                            CurrentDialect = new SqlServer();
                            break;
                        }
                }
            }
            else
                command = command.Transaction.Connection.CreateCommand();

            command.Connection.ConnectionString = currentConnectionStringSettings.ConnectionString;
        }

        /// <summary>
        /// Create an Adapter based in the current DataBaseType.
        /// </summary>
        /// <returns>Return an Adapter</returns>
        private DataAdapter CreateAdapter()
        {
            switch (DataBaseType)
            {
                case DataBaseType.Oledbc:
                    return new OdbcDataAdapter((OdbcCommand) command);

                case DataBaseType.OleDb:
                    return new OleDbDataAdapter((OleDbCommand) command);

                case DataBaseType.Oracle:
                    return new OracleDataAdapter((OracleCommand) command);

                case DataBaseType.Sql:
                    return new SqlDataAdapter((SqlCommand) command);

                case DataBaseType.MySql:
                    return new MySqlDataAdapter((MySqlCommand) command);

                default:
                    return new OdbcDataAdapter((OdbcCommand) command);
            }
        }

        #endregion

        #region public methods

        public static DataBaseType GetDataBaseTypeByName(string dataBaseType)
        {
            #region debug

            if (string.IsNullOrEmpty(dataBaseType))
                throw new ArgumentNullException("dataBaseType", Messages.InvalidDatabaseType);

            #endregion

            switch (dataBaseType)
            {
                case "System.Data.Odbc":
                    return DataBaseType.Oledbc;

                case "System.Data.OleDb":
                    return DataBaseType.OleDb;

                case "System.Data.OracleClient":
                    return DataBaseType.Oracle;

                case "System.Data.SqlClient":
                    return DataBaseType.Sql;

                case "MySql.Data.MySqlClient":
                    return DataBaseType.MySql;
            }

            #region debug

            throw new ArgumentException("dataBaseType", Messages.InvalidDatabaseType);

            #endregion
        }

        public static string GetDataBaseNameByType(DataBaseType dataBaseType)
        {
            switch (dataBaseType)
            {
                case DataBaseType.Oledbc:
                    return "System.Data.Odbc";

                case DataBaseType.OleDb:
                    return "System.Data.OleDb";

                case DataBaseType.Oracle:
                    return "System.Data.OracleClient";

                case DataBaseType.Sql:
                    return "System.Data.SqlClient";

                case DataBaseType.MySql:
                    return "MySql.Data.MySqlClient";
            }

            #region debug

            throw new ArgumentException("dataBaseType", Messages.InvalidDatabaseType);

            #endregion
        }

        /// <summary>
        /// Sets global connectionstring using Application["dbPortal"] object
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="providerName"></param>
        public static void SetConnection(string connectionString, string providerName)
        {
            #region debug

            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentNullException("connectionString", Messages.InvalidArgumentValue);

            if (string.IsNullOrEmpty(providerName))
                throw new ArgumentNullException("providerName", Messages.InvalidArgumentValue);

            #endregion

            currentConnectionStringSettings = new ConnectionStringSettings("dbPortal", connectionString, providerName);
        }

        /// <summary>
        /// Gets the default configurations of "dbPortal"
        /// </summary>
        /// <returns>ConnectionStringSettings</returns>
        internal static ConnectionStringSettings GetDefaultConnectionSettings()
        {
            return GetConnectionSettings("dbPortal");
        }

        /// <summary>
        /// Gets the configurations of connection in web.config
        /// </summary>
        /// <param name="connectionName">Name of connection on web.config</param>
        /// <returns>ConnectionStringSettings</returns>
        internal static ConnectionStringSettings GetConnectionSettings(string connectionName)
        {
            return ConfigurationManager.ConnectionStrings[connectionName];
        }

        /// <summary>
        /// Gets a DbConnection object created using de default conection settings on Web.Config (dbPortal)
        /// </summary>
        /// <returns>DbConnection</returns>
        public static DbConnection GetDefaultConnection()
        {
            return GetConnection("dbPortal");
        }

        /// <summary>
        /// Gets a DbConnection object created using de default conection settings on Web.Config
        /// </summary>
        /// <returns>DbConnection</returns>
        public static DbConnection GetConnection(string connectionName)
        {
            #region debug

            if (string.IsNullOrEmpty(connectionName))
                throw new ArgumentNullException("connectionName", Messages.InvalidArgumentValue);

            #endregion

            ConnectionStringSettings connStr = ConfigurationManager.ConnectionStrings[connectionName];
            DbProviderFactory f = DbProviderFactories.GetFactory(connStr.ProviderName);
            DbConnection conn = f.CreateConnection();
            conn.ConnectionString = connStr.ConnectionString;

            return conn;
        }

        public static bool HasConnection()
        {
            return currentConnectionStringSettings != null;
        }

        public static void SetConnection(DataBaseType dataBaseType, string connectionString)
        {
            #region debug

            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentNullException("connectionString", Messages.InvalidArgumentValue);

            #endregion

            string providerName;

            switch (dataBaseType)
            {
                case DataBaseType.Sql:
                    providerName = "System.Data.SqlClient";
                    break;
                case DataBaseType.Oracle:
                    providerName = "System.Data.OracleClient";
                    break;
                case DataBaseType.MySql:
                    providerName = "MySql.Data.MySqlClient";
                    break;
                default:
                    providerName = dataBaseType == DataBaseType.OleDb ? "System.Data.OleDb" : "System.Data.Odbc";
                    break;
            }

            currentConnectionStringSettings = new ConnectionStringSettings("dbPortal", connectionString, providerName);
        }

        /// <summary>
        /// Add a Parameter.
        /// </summary>
        /// <param name="fieldName">Fieldname</param>
        /// <param name="dbType">System.Data.DbType</param>
        /// <param name="value">Value</param>
        /// <param name="direction">Direction</param>
        /// <param name="size">Size</param>
        public void AddParameter(string fieldName, DbType dbType, object value, ParameterDirection direction, int size)
        {
            OdbcParameter parameter;
            switch (DataBaseType)
            {
                case DataBaseType.Oledbc:
                    {
                        parameter = new OdbcParameter
                                        {
                                            ParameterName = fieldName.Replace("@", CurrentDialect.GetParamString()),
                                            DbType = dbType,
                                            Value = value ?? DBNull.Value,
                                            Direction = direction,
                                            Size = size,
                                            IsNullable = value == null || value == DBNull.Value
                                        };
                        command.Parameters.Add(parameter);
                        return;
                    }
                case DataBaseType.OleDb:
                    {
                        var parameter2 = new OleDbParameter
                                             {
                                                 ParameterName = fieldName.Replace("@", CurrentDialect.GetParamString()),
                                                 DbType = dbType,
                                                 Value = value ?? DBNull.Value,
                                                 Direction = direction,
                                                 Size = size,
                                                 IsNullable = value == null || value == DBNull.Value
                                             };
                        command.Parameters.Add(parameter2);
                        return;
                    }
                case DataBaseType.Oracle:
                    {
                        var parameter3 = new OracleParameter
                                             {
                                                 ParameterName = fieldName.Replace("@", CurrentDialect.GetParamString()),
                                                 DbType = dbType,
                                                 Value = value ?? DBNull.Value,
                                                 Direction = direction,
                                                 Size = size,
                                                 IsNullable = value == null || value == DBNull.Value
                                             };
                        command.Parameters.Add(parameter3);
                        return;
                    }
                case DataBaseType.Sql:
                    {
                        var parameter4 = new SqlParameter
                                             {
                                                 ParameterName = fieldName.Replace("@", CurrentDialect.GetParamString()),
                                                 DbType = dbType,
                                                 Value = value ?? DBNull.Value,
                                                 Direction = direction,
                                                 Size = size,
                                                 IsNullable = value == null || value == DBNull.Value
                                             };
                        command.Parameters.Add(parameter4);
                        return;
                    }

                case DataBaseType.MySql:
                    {
                        var parameter5 = new MySqlParameter
                                             {
                                                 ParameterName = fieldName.Replace("@", CurrentDialect.GetParamString()),
                                                 DbType = dbType,
                                                 Value = value ?? DBNull.Value,
                                                 Direction = direction,
                                                 Size = size,
                                                 IsNullable = value == null || value == DBNull.Value
                                             };
                        command.Parameters.Add(parameter5);
                        return;
                    }
            }

            parameter = new OdbcParameter
                            {
                                ParameterName = fieldName.Replace("@", CurrentDialect.GetParamString()),
                                DbType = dbType,
                                Value = value ?? DBNull.Value,
                                Direction = direction,
                                Size = size,
                                IsNullable = value == null || value == DBNull.Value
                            };

            command.Parameters.Add(parameter);
        }


        /// <summary>
        /// Add a Parameter with reflection (input).
        /// </summary>
        /// <param name="fieldName">Fieldname</param>
        /// <param name="value">Value</param>
        public void AddWithValue(string fieldName, object value)
        {
            if (value != null)
            {
                AddParameter(fieldName, SingletonTypeConverter.Instance().DbTypeOf(value.GetType()), value,
                             ParameterDirection.Input, 0);
            }
            else
            {
                AddParameter(fieldName, DbType.Object, DBNull.Value, ParameterDirection.Input, 0);
            }
        }

        /// <summary>
        /// Add a Parameter with reflection (output).
        /// </summary>
        /// <param name="fieldName">Fieldname</param>
        /// <param name="value">Value</param>
        public void AddWithValueOutput(string fieldName, object value)
        {
            if (value != null)
            {
                AddParameter(fieldName, SingletonTypeConverter.Instance().DbTypeOf(value.GetType()), value,
                             ParameterDirection.Output, 0);
            }
            else
            {
                AddParameter(fieldName, DbType.Object, DBNull.Value, ParameterDirection.Output, 0);
            }
        }


        public static string CreateConnectionString(DataBaseType dataBaseType, string server, string userName,
                                                    string password, string dataSource)
        {
            switch (dataBaseType)
            {
                case DataBaseType.Oledbc:
                    return string.Empty;

                case DataBaseType.OleDb:
                    return string.Empty;

                case DataBaseType.Oracle:
                    return string.Format("Server={0};Data Source={1};Uid={2};Pwd={3};",
                                         new object[] {server, dataSource, userName, password});

                case DataBaseType.Sql:
                    return string.Format("Data Source={0};Initial Catalog={1};User Id={2};Password={3};",
                                         new object[] {server, dataSource, userName, password});

                case DataBaseType.MySql:
                    return string.Format("Server={0};Database={1};Uid={2};Pwd={3}",
                                         new object[] {server, dataSource, userName, password});
            }
            return string.Empty;
        }


        /// <summary>
        /// Add a parameter (input).
        /// </summary>
        /// <param name="fieldName">Fieldname</param>
        /// <param name="dbType">System.Data.DbType</param>
        /// <param name="value">Value</param>
        public void AddParameterInput(string fieldName, DbType dbType, object value)
        {
            AddParameter(fieldName, dbType, value, ParameterDirection.Input, 0);
        }

        /// <summary>
        /// Add a parameter (output).
        /// </summary>
        /// <param name="fieldName">Fieldname</param>
        /// <param name="dbType">System.Data.DbType</param>
        public void AddParameterOutput(string fieldName, DbType dbType)
        {
            AddParameter(fieldName, dbType, null, ParameterDirection.Output, 0);
        }

        /// <summary>
        /// Add a parameter (output).
        /// </summary>
        /// <param name="fieldName">Fieldname</param>
        /// <param name="dbType">System.Data.DbType</param>
        /// <param name="size">Size</param>
        public void AddParameterOutput(string fieldName, DbType dbType, int size)
        {
            AddParameter(fieldName, dbType, null, ParameterDirection.Output, size);
        }

        /// <summary>
        /// Add a parameter (input and output direction).
        /// </summary>
        /// <param name="fieldName">Fieldname</param>
        /// <param name="dbType">System.Data.DbType</param>
        /// <param name="value">Value</param>
        public void AddParameterInputOutput(string fieldName, DbType dbType, object value)
        {
            AddParameter(fieldName, dbType, value, ParameterDirection.InputOutput, 0);
        }

        /// <summary>
        /// Add a parameter (return direction).
        /// </summary>
        /// <param name="fieldName">Fieldname</param>
        /// <param name="dbType">System.Data.DbType</param>
        public void AddParameterReturn(string fieldName, DbType dbType)
        {
            AddParameter(fieldName, dbType, null, ParameterDirection.ReturnValue, 0);
        }

        /// <summary>
        /// Retrieves a Parameter.
        /// </summary>
        /// <param name="fieldName">Fieldname</param>
        /// <returns>Parameter</returns>
        public object GetParameter(string fieldName)
        {
            #region debug

            if (string.IsNullOrEmpty(fieldName))
                throw new ArgumentNullException("fieldName", Messages.InvalidArgumentValue);

            #endregion

            return command.Parameters[fieldName];
        }

        /// <summary>
        /// Retrieves a Parameter Value.
        /// </summary>
        /// <param name="fieldName">Fieldname</param>
        /// <returns>Parameter value</returns>
        public object GetParameterValue(string fieldName)
        {
            #region debug

            if (string.IsNullOrEmpty(fieldName))
                throw new ArgumentNullException("fieldName", Messages.InvalidArgumentValue);

            #endregion

            return ((IDataParameter) command.Parameters[fieldName]).Value;
        }

        /// <summary>
        /// Removes all System.Data.Common.DbParameter values from the System.Data.Common.DbParameterCollection.
        /// </summary>
        public void ClearParameters()
        {
            command.Parameters.Clear();
        }

        #endregion

        #region database access

        /// <summary>
        /// Executes a SQL statement against a connection object.
        /// </summary>
        /// <param name="returnType">Supported Return Types</param>
        /// <returns>System.Data.DataSet | System.Data.DataTable | System.Data.DataView | System.Object | System.Xml.XmlDocument</returns>
        public object ExecuteQuery(ReturnType returnType)
        {
            return ExecuteQuery(DbCommand.CommandText, returnType);
        }

        /// <summary>
        /// Executes a SQL statement against a connection object.
        /// </summary>
        /// <param name="query">SQL query</param>
        /// <param name="returnType">Supported Return Types</param>
        /// <returns>System.Data.DataSet | System.Data.DataTable | System.Data.DataView | System.Object | System.Xml.XmlDocument | null</returns>
        public object ExecuteQuery(string query, ReturnType returnType)
        {
            #region debug

            if (string.IsNullOrEmpty(query))
                throw new ArgumentNullException("query", Messages.InvalidArgumentValue);

            #endregion

            try
            {
                //Create a new DataSet
                var set = new DataSet();

                //If the transaction is null, open a new connection
                if (command.Transaction == null)
                    command.Connection.Open();

                //
                // Replace all "@" occurrences with the current param character dialect
                //
                query = query.Replace("@", CurrentDialect.GetParamString());

                //sets the CommandText
                command.CommandText = query;

#if DEBUG

                WriteLog();

#endif

                switch (returnType)
                {
                    case ReturnType.DataReader:
                        {
                            //Executes a DataReader
                            return command.ExecuteReader(CommandBehavior.CloseConnection);
                        }

                    case ReturnType.DataSet:
                        {
                            //Fill a DataSet
                            CreateAdapter().Fill(set);
                            command.Connection.Close();

                            //return a DataSet
                            return set;
                        }

                    case ReturnType.DataTable:
                        {
                            //Fill a DataSet
                            CreateAdapter().Fill(set);

                            //return a DataTable
                            return set.Tables[0];
                        }

                    case ReturnType.DataView:
                        {
                            //Fill a DataView
                            CreateAdapter().Fill(set);

                            //return a DataView
                            return set.Tables[0].DefaultView;
                        }

                    case ReturnType.Scalar:
                        {
                            //Return a object
                            return command.ExecuteScalar();
                        }

                    case ReturnType.XmlDocument:
                        {
                            //Fill a DatSet
                            CreateAdapter().Fill(set);

                            //Create a new XmlDataDocument based in the DataSet
                            var document = new XmlDataDocument(set);

                            //Return a XmlDataDocument
                            return document;
                        }
                }

                return null;
            }
            catch (SqlException ex)
            {
                if (ex.Class == 20)
                {
                    //
                    // ConnectionString error
                    //
                    throw new ADOException(string.Format(Messages.MSG_00001, command.Connection.Database), ex);
                }

                throw;
            }
            finally
            {
                //if command != null and isn't in a datareader and isn't a transaction
                if (command != null & returnType != ReturnType.DataReader && command.Transaction == null)
                    command.Connection.Close();
            }
        }

        /// <summary>
        /// Executes a SQL statement against a connection object.
        /// </summary>
        /// <returns>Number of affected rows</returns>
        public int ExecuteNonQuery()
        {
            return ExecuteNonQuery(CommandText);
        }

        /// <summary>
        /// Executes a SQL statement against a connection object.
        /// </summary>
        /// <param name="query">SQL query</param>
        /// <returns>Number of affected rows</returns>
        public int ExecuteNonQuery(string query)
        {
            #region debug

            if (string.IsNullOrEmpty(query))
                throw new ArgumentNullException("query", Messages.InvalidArgumentValue);

            #endregion

            try
            {
                //
                // If the transaction is null, open a new connection
                //
                if (command.Transaction == null)
                    command.Connection.Open();

                //
                // Replace all "@" occurrences with the current param character dialect
                //
                query = query.Replace("@", CurrentDialect.GetParamString());

                //
                // Substitui todos os [campo] pelos delimitadores do dialeto sendo usado
                //

                string delimiter = CurrentDialect.GetOpenBracketString() + "$1" + CurrentDialect.GetCloseBracketString();
                query = Regex.Replace(query, @"\[([\w\d_ ]+)\]", delimiter);

                //
                // sets the CommandText
                //
                command.CommandText = query;

#if DEBUG

                WriteLog();

#endif

                //
                // return the number of affected rows
                //
                return command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                if (ex.Class == 20)
                {
                    //
                    // ConnectionString error
                    //
                    throw new ADOException(string.Format(Messages.MSG_00001, command.Connection.Database), ex);
                }

                throw;
            }
            catch (Exception)
            {
                //
                // Rolls back the transaction
                //
                RollBack();

                throw;
            }
            finally
            {
                //if isn't a transaction close the connection
                if (command.Transaction == null)
                    command.Connection.Close();
            }
        }

        /// <summary>
        /// Escreve a query atual e os parâmetros armazenados
        /// </summary>
        private void WriteLog()
        {
            Trace.WriteLine(string.Format("Query:\r\n\r\n\t{0}", command.CommandText));
            Trace.WriteLine("\r\n");

            for (int i = 0; i < command.Parameters.Count; i++)
            {
                Trace.WriteLine(
                    string.Format(
                        "{0}\tDbType: {1}\r\n\tDirection: {2}\r\n\tIsNullable: {3}\r\n\tParameterName: {4}\r\n\tSourceColumn: {5}\r\n\tSourceVersion: {6}\r\n\tValue: {7}\r\n",
                        i,
                        ((IDataParameter) command.Parameters[i]).DbType,
                        ((IDataParameter) command.Parameters[i]).Direction,
                        ((IDataParameter) command.Parameters[i]).IsNullable,
                        ((IDataParameter) command.Parameters[i]).ParameterName,
                        ((IDataParameter) command.Parameters[i]).SourceColumn,
                        ((IDataParameter) command.Parameters[i]).SourceVersion,
                        ((IDataParameter) command.Parameters[i]).Value));
            }
        }

        #endregion

        #region transaction control

        /// <summary>
        /// Starts a database transaction (You must use Commit).
        /// </summary>
        public void BeginTransaction()
        {
            try
            {
                //if the connection isn't open, open it
                if (command.Connection.State != ConnectionState.Open)
                    command.Connection.Open();

                //if the transaction == null create a new transaction
                if (command.Transaction == null)
                    command.Transaction = command.Connection.BeginTransaction();
            }
            catch (SqlException ex)
            {
                if (ex.Class == 20)
                {
                    //
                    // ConnectionString error
                    //
                    throw new ADOException(string.Format(Messages.MSG_00001, command.Connection.Database), ex);
                }

                throw;
            }
        }

        /// <summary>
        /// Commits the database transaction.
        /// </summary>
        public void Commit()
        {
            try
            {
                command.Transaction.Commit();
            }
            catch (SqlException ex)
            {
                if (ex.Class == 20)
                {
                    //
                    // ConnectionString error
                    //
                    throw new ADOException(string.Format(Messages.MSG_00001, command.Connection.Database), ex);
                }

                throw;
            }
            catch (Exception)
            {
                //Rolls back the transaction
                RollBack();

                throw;
            }
            finally
            {
                //closes the current connection
                if (command != null)
                    command.Connection.Close();
            }
        }

        /// <summary>
        /// Rolls back a transaction from a pending state.
        /// </summary>
        public void RollBack()
        {
            //if is in a transaction
            try
            {
                if (command.Transaction != null)
                    command.Transaction.Rollback();
            }
            catch (InvalidOperationException)
            {
                //A MySql database roolback a transaction automatically when some error occurs
                //so we must ignore an error when try to do this in a already rooledback transaction
                if (DataBaseType != DataBaseType.MySql)
                    throw;
            }
        }

        #endregion
    }
}
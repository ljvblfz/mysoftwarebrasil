using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlServerCe;
using System.Data;
using System.Threading;

namespace GeraBase
{
    /// <summary>
    ///  Classe extendida da SqlCeCommand
    ///  Responsaveis por execução de comandos no banco de dados
    /// </summary>
    public class SqlCeCommandEx
    {
        /// <summary>
        ///  Command padrão do banco
        /// </summary>
        public SqlCeCommand cmd; 

        /// <summary>
        ///  Construtor
        /// </summary>
        public SqlCeCommandEx()
        {
            cmd = SQLHelper.cmdOrigem;
        }

        /// <summary>
        ///  Seta a conexão com o banco de dados
        /// </summary>
        public SqlCeConnection Connection 
        { 
            get
            {
                return cmd.Connection;
            }
            set
            {
                cmd.Connection = value;
            }
        }

        /// <summary>
        ///  Retorna o objeto de parametros do SQL
        /// </summary>
        public SqlCeParameterCollection Parameters 
        {
            get
            {
                return cmd.Parameters;
            }
        }

        /// <summary>
        ///  Comando SQL
        /// </summary>
        public string CommandText 
        {
            get
            {
                return cmd.CommandText;
            }
            set
            {
                cmd.CommandText = value;
            }
        }

        /// <summary>
        ///  Cria um objeto de parametros
        /// </summary>
        /// <returns>objeto de parametros do SQL</returns>
        public SqlCeParameter CreateParameter()
        {
            return cmd.CreateParameter();
        }

        /// <summary>
        ///  Metodo sobreescrito do SqlCeCommand
        /// </summary>
        /// <returns>Retorna um objeto IDataReader</returns>
        public IDataReader ExecuteReader()
        {
            IDataReader retorno = null;
            isExecute();
            try
            {
                retorno = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                throw e;
            }

            return retorno;
        }

        /// <summary>
        ///  Metodo que executa um comando no banco sem retorno
        /// </summary>
        /// <returns>retorna a quantidade de linhas afetadas</returns>
        public int ExecuteNonQuery()
        {
            int retorno = 0;
            isExecute();
            try
            {
                retorno = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }

            return retorno;
        }

        /// <summary>
        ///  Metodo que retorna um unico dado do banco
        /// </summary>
        /// <returns></returns>
        public object ExecuteScalar()
        {
            object retorno = null;
            isExecute();
            try
            {
                retorno = cmd.ExecuteScalar();
            }
            catch (Exception e)
            {
                throw e;
            }

            return retorno;
        }

        /// <summary>
        ///  Metodo que verifica se e possivel executar o comando no banco
        /// </summary>
        public void isExecute()
        {
            switch (cmd.Connection.State)
            {
                case ConnectionState.Broken:
                    {
                        throw new Exception("Conecxão com o banco bloqueada");
                        break;
                    }
                case ConnectionState.Closed:
                    {
                        cmd.Connection.Open();
                        break;
                    }
                case ConnectionState.Connecting:
                    {
                        while (ConnectionState.Connecting != cmd.Connection.State)
                            Thread.Sleep(500);
                        isExecute();
                        break;
                    }
                case ConnectionState.Executing:
                    {
                        while (ConnectionState.Executing != cmd.Connection.State)
                            Thread.Sleep(500);
                        isExecute();
                        break;
                    }
                case ConnectionState.Fetching:
                    {
                        while (ConnectionState.Fetching != cmd.Connection.State)
                            Thread.Sleep(500);
                        isExecute();
                        break;
                    }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Data;


namespace WS_ltMbileData.Data
{
    public class ConexaoBD
    {
        #region Propriedades

        public OracleConnection ConexaoBancoDados { get; set; }
        public string NomeStringConexao { get; set; }


        #endregion

        #region Construtores

        public ConexaoBD()
        {
            //Banco de dados VELP
            this.NomeStringConexao = "Data Source=ORA10G;User Id=stcom_ee;Password=stcom_ee;";
            //bANCO DE DADOS Reta
            //this.NomeStringConexao = "Data Source=ORA11G;User Id=stcom_ee;Password=stcom_ee;";
            //Banco de dados aratec
            //ERRADO - this.NomeStringConexao = "Data Source=ARATEC3.WORLD;User Id=leitura;Password=leitura;";
            //this.NomeStringConexao = "Data Source=ORA9;User Id=leitura;Password=leitura;";

            //this.ConexaoBancoDados = new OracleConnection(this.NomeStringConexao);

             string connection = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.1.52)(PORT=1521)))"+
                    "(CONNECT_DATA=(SERVICE_NAME=ora10))); User Id=stcom_ee; Password=stcom_ee";

            this.ConexaoBancoDados =  new OracleConnection(connection);
            
        }

        public ConexaoBD(string nomeStringConexao)
        {
            this.NomeStringConexao = nomeStringConexao;
            this.ConexaoBancoDados = new OracleConnection(this.NomeStringConexao);
        }

        #endregion

        #region Metodos Privados

        private string GetCorrectParameterName(string parameterName)
        {
            if (parameterName[0] != '@')
            {
                parameterName = "@" + parameterName;
            }
            return parameterName;
        }

        #endregion

        #region Métodos Públicos

        public static ConexaoBD Create()
        {
            return new ConexaoBD();
        }

        public static ConexaoBD Create(string nomeStringConexao)
        {
            return new ConexaoBD(nomeStringConexao);
        }

        public void OpenConnection()
        {
            if (this.ConexaoBancoDados.State == System.Data.ConnectionState.Closed)
            {
                try
                {
                    this.ConexaoBancoDados.Open();
                }
                catch (Exception ex)
                { 
                    string aa= ex.ToString();
                }
            }

        }

        public OracleCommand CreateCommand()
        {
            return ConexaoBancoDados.CreateCommand();
        }

        public void CloseConection()
        {
            this.ConexaoBancoDados.Close();
        }


        public SqlParameter BuildParameter(string nome, object valor, DbType tipo, int size)
        {
            SqlParameter parametro = new SqlParameter(this.GetCorrectParameterName(nome), valor);
            parametro.DbType = tipo;
            parametro.Size = size;
            return parametro;
        }

        public void ExecuteNonQuery(OracleCommand command)
        {
            // return command.ExecuteNonQuery();
            OracleString rowId;
            try
            {
                //command.ExecuteOracleNonQuery(out rowId);
                command.ExecuteNonQuery();
            }
            catch (Exception ex) { throw new Exception("Erro ao inserir/alterar."); }
        }

        public void ExecuteNonQuery(OracleCommand command, bool openConnection)
        {
            if (openConnection)
            {
                this.OpenConnection();
            }
            this.ExecuteNonQuery(command);
            if (openConnection)
            {
                this.CloseConection();
            }
        }

        public void ExecuteNonQuery(string query, params OracleParameter[] parameters)
        {
            Exception erro = null;
            try
            {
                this.OpenConnection();
                OracleCommand command = CreateCommand();
                command.CommandText = query;
                command.Parameters.AddRange(parameters);
                this.ExecuteNonQuery(command);
                this.CloseConection();
            }
            catch (Exception ex)
            {
                erro = ex;
            }
            finally
            {
                this.CloseConection();
            }

            if (erro != null)
            {
                throw erro;
            }
        }

        #endregion
    }
}

using System;
using GDA;
using System.Runtime.Serialization;
using GeraBase.DAL;


namespace GeraBase.Model
{
    /// <summary>
    /// Classe que representa a tabela IDA_USUARIO.
    /// </summary>
    [PersistenceClass("IDA_USUARIO")]
    [PersistenceBaseDAO(typeof(UsuarioIdaDAO))]
    [Serializable]
    public class UsuarioIda : Persistent
    {
    	#region Local Variables
		private int  _Codigo;
        private string  _Nome;
        private string  _Login;
        private string  _Senha;

		#endregion

		#region Metodos
        [PersistenceProperty("Codigo")]
        public int Codigo
        {
            get
            {
                return _Codigo;
            }
            set
            {
                _Codigo = value;
            }
        }

        [PersistenceProperty("Nome")]
        public string Nome
        {
            get
            {
                return _Nome;
            }
            set
            {
                _Nome = value;
            }
        }

        [PersistenceProperty("Login")]
        public string Login
        {
            get
            {
                return _Login;
            }
            set
            {
                _Login = value;
            }
        }

        [PersistenceProperty("Senha")]
        public string Senha
        {
            get
            {
                return _Senha;
            }
            set
            {
                _Senha = value;
            }
        }


		#endregion
    }
}
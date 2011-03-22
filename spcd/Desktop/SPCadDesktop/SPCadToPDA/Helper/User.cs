using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPCadToPDA.Helper
{
    public class User
    {
        public int IdUsuario { get; set; }
        public string Senha { get; set; }
        public string Usuario{get; set;}
        public string Login { get; set; }

        public User()
        { }

        public User(int IdUsuario, string Senha, string Usuario, string Login)
        {
            this.IdUsuario = IdUsuario;
            this.Senha = Senha;
            this.Usuario = Usuario;
            this.Login = Login;
        }


    }
}

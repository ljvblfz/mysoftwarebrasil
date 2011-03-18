using System;
using System.Collections.Generic;
using System.Text;
using GDA.Sql;
using LTmobileData.Data.Model;
using WS_ltMbileData.Data.DAO;
using WS_ltMbileData.Data.Model;
using LTmobileData.Data.DAL;

namespace WS_ltMbileData.Data.BFL
{
    public class UsuarioFlow
    {
        /// <summary>
        /// Autentica o usuário.
        /// </summary>
        /// <param name="strUsuario">Usuário</param>
        /// <param name="strSenha">Senha</param>
        /// <returns>Estado do usuário</returns>
        public static bool AutenticarUsuario(string strUsuario, string strSenha)
        {
            /*bool boExiste = false;

            Usuario usuario = new Usuario();

            List<Usuario> lstUsuario = new Query("MATRIC_FUNC=?usuario").Add("?usuario", strUsuario).ToList<Usuario>();

            //Verifica se existe usuário
            if (lstUsuario != null && lstUsuario.Count > 0 && lstUsuario[0].SENHA_FUNC.TrimEnd() == strSenha)
            {
                boExiste = true;                

            }
            return boExiste;*/
            return new UsuarioDAO().existeUsuario(strUsuario, strSenha);
        }

        /// <summary>
        /// Retorna dados do funcionário
        /// </summary>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public static List<FuncionariosWS> getFuncionario(string Usuario)
        {
            return new FuncionarioDAO().getFuncionario(Usuario);
        }
    }
}

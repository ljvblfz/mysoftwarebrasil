using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using LTmobileData.Data.Model;
using LTmobileData.Data.DAL;
using GDA.Sql;

namespace LTmobileData.Data.BFL
{
    public class UsuarioFlow
    {

        /// <summary>
        /// Identificador do usuario logado
        /// </summary>
        public static Usuario _usuarioCurrent;

        /// <summary>
        /// Hora que o usuário realizaou login
        /// </summary>
        public static DateTime _horaLogin;


        public static Usuario UsuarioCurrent { get { return _usuarioCurrent; } }
        public static DateTime HoraLogin { get { return _horaLogin; } } 


        /// <summary>
        /// Autentica o usuário.
        /// </summary>
        /// <param name="strUsuario">Usuário</param>
        /// <param name="strSenha">Senha</param>
        /// <returns>Estado do usuário</returns>
        public bool AutenticarUsuario(string strUsuario, string strSenha)
        {
            bool boExiste = false;

            Usuario usuario = new Usuario();

            List<Usuario> lstUsuario = new Query("MATRIC_FUNC=?usuario").Add("?usuario", strUsuario).ToList<Usuario>();

            //Verifica se existe usuário
            if (lstUsuario != null && lstUsuario.Count > 0 && lstUsuario[0].SENHA_FUNC.TrimEnd() == strSenha)
            {
                boExiste = true;
                //Configura o usuário atual no sistema.
                setUsuario(strUsuario);

            }
            return boExiste;
        }

        /// <summary>
        /// Configura o usuário atual do sistema
        /// </summary>
        /// <param name="strLogin">Usuario</param>
        public static void setUsuario(string strLogin)
        {
            Usuario usuario = new Usuario();
            UsuarioDAO usuarioDAO = new UsuarioDAO();
            usuario = usuarioDAO.getUsuario(strLogin);

            if (usuario != null)
            {
                _usuarioCurrent = usuario;

                _horaLogin = DateTime.Now;
            }

        }

        public static void InsertOrUpdate(Usuario usuario)
        {
            try
            {
                new UsuarioDAO().InsertOrUpdate(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível enviar mensagem.");
            }
        }

        public static void DeleteTodos()
        {
            new UsuarioDAO().DeleteTodos();
        }
    }
}

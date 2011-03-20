using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using GDA;
using GeraBase.DAL;
using GeraBase.Model;
using System.Security.Cryptography;
using System.Text;

namespace GeraBase.BFL
{
    public class UsuarioIdaFlow
    {
        /// <summary>
        ///  Metodo que retorna todos os dados
        /// </summary>
        /// <returns></returns>
        public static List<UsuarioIda> Lista()
        {
            UsuarioIdaDAO UsuarioIda = new UsuarioIdaDAO();
            return UsuarioIda.Lista();
        }

        /// <summary>
        ///  Metodo que insere um registro na tabela
        /// </summary>
        /// <returns></returns>
        public static void Insert(List<UsuarioIda> ListUsuarioIda)
        {
            UsuarioIdaDAO UsuarioIda = new UsuarioIdaDAO();

            try
            {
                foreach(UsuarioIda ItemUsuarioIda in ListUsuarioIda)
                    UsuarioIda.Insert(ItemUsuarioIda);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        ///  Autentica Usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="senha"></param>
        /// <returns></returns>
        public static bool Autenticar(string usuario, string senha)
        {
            UsuarioIdaDAO UsuarioIda = new UsuarioIdaDAO();
            return UsuarioIda.LoginUsusario(usuario, CalculateMD5Hash(senha));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigo"></param>
        /// <param name="SenhaAntiga"></param>
        /// <param name="SenhaNova"></param>
        /// <returns></returns>
        public static bool AletrarSenha(int codigo, string SenhaAntiga, string SenhaNova)
        {
            bool retorno = false;

            UsuarioIdaDAO UsuarioIda = new UsuarioIdaDAO();
            string where = String.Format("Codigo = {0}", codigo);
            List<UsuarioIda> listaUsuario = UsuarioIda.Select(new GDA.Sql.Query(where));

            if (listaUsuario.Count > 0)
            {
                if (listaUsuario[0].Senha.ToUpper() == CalculateMD5Hash(SenhaAntiga).ToUpper())
                {
                    listaUsuario[0].Senha = CalculateMD5Hash(SenhaNova);
                    retorno = UsuarioIda.UpdateSenha(listaUsuario[0]);
                }
            }
            return retorno;
        }

        /// <summary>
        ///  Metodo que calcula o MD5
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string CalculateMD5Hash(string input)
        {

            // Primeiro passo, calcular o MD5 hash a partir da string
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // Segundo passo, converter o array de bytes em uma string haxadecimal
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using LTmobileData.Data.Model;
using System.Data.SqlServerCe;
using GDA;


namespace LTmobileData.Data.DAL
{
    public class UsuarioDAO : BaseDAO<Usuario>
    {
        /// <summary>
        /// Retorna Usuário
        /// </summary>
        /// <param name="strUsuario">Matrícula do funcionário</param>
        /// <returns>Usuário</returns>
        public Usuario getUsuario(string strUsuario)
        {
            string strSql = "SELECT LTTB_FUNCIONARIOS.*, COD_EMPRT, MATRIC_FUNC, SENHA_FUNC, NOME_FUNC, COD_LOCAL_TRAB," +
                            "SITUAC_FUNC, NUM_COLETR FROM LTTB_FUNCIONARIOS WHERE MATRIC_FUNC = "+strUsuario+"";
            return CurrentPersistenceObject.LoadOneData(strSql);
        }

        public void DeleteTodos()
        {
            string strSql = "DELETE FROM LTTB_FUNCIONARIOS";
            CurrentPersistenceObject.ExecuteCommand(strSql);
        }

    }
}

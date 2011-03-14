using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using DeviceProject.DATA.dataSaned.Model;
using DeviceProject.DATA.dataSaned.Dao;

namespace DeviceProject.DATA.dataSaned.Flow
{
    /// <summary>
    ///  Flow da log de erro
    /// </summary>
    public static class LogErroFlow
    {
        /// <summary>
        ///  Insere o log de erro
        /// </summary>
        /// <param name="obj">LogErro Model com os dados a inserir</param>
        public static void Insert(LogErro obj)
        {
            try
            {
                new LogErroDao().Insert(obj);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível inserir!\n" + ex.Message, (Exception)ex);
            }
        }

        /// <summary>
        ///  Gera o Objeto de erro
        /// </summary>
        /// <param name="ex">Exception exeção a ser inserida </param>
        /// <param name="tabela">string ,nome da tabela</param>
        /// <param name="rotina">string ,tipo de rotina</param>
        public static void SetErro(Exception ex,string tabela,string rotina)
        {
            LogErro objErro = new LogErro();
            objErro.data = DateTime.Now;
            objErro.tabela = tabela;
            objErro.rotina = rotina;
            objErro.erro = ex.Message + "  " + ex.StackTrace;
            if (objErro.erro.Length > 4000)
                objErro.erro = objErro.erro.Remove(3999, objErro.erro.Length);
            Insert(objErro);
        }
    }
}

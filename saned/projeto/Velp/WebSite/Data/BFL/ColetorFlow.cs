using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.DAL;
using Data.Model;

namespace Data.BFL
{
    public class ColetorFlow
    {
        private static ColetorDAO _coletorDAO = new ColetorDAO();

        #region CRUD

        public static void Insert(Coletor coletor)
        {
            try
            {
                _coletorDAO.Insert(coletor);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível inserir!\n" + ex.Message, (Exception)ex);
            }
        }

        public static bool CheckPdaExist(string idColetor)
        {
            try
            {
                return _coletorDAO.CheckPdaExist(idColetor);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível inserir!\n" + ex.Message, (Exception)ex);
            }
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using GDA;
using Data.Model;
using Data.DAL;

namespace Data.BFL
{
    public class VoltaNovoRegistroFlow
    {
        /// <summary>
        /// Retorna uma lista
        /// </summary>
        /// <returns></returns>
        public static List<VoltaNovoRegistro> Lista()
        {
            VoltaNovoRegistroDAO VoltaNovoRegistro = new VoltaNovoRegistroDAO();
            return VoltaNovoRegistro.Lista();
        }

        /// <summary>
        ///  Insere os dados
        /// </summary>
        /// <param name="novoRegistro"></param>
        public static void Insert(VoltaNovoRegistro novoRegistro)
        {
            try
            {
                VoltaNovoRegistroDAO VoltaNovoRegistro = new VoltaNovoRegistroDAO();
                VoltaNovoRegistro.Insert(novoRegistro);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
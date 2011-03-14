using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using Data.Model;
using Data.DAL;
using GDA;

namespace Data.BFL
{

	public class ParametroRentencaoFlow
    {

        public static List<ParametroRentencaoONP> ListaParametroRentencao()
        {
            ParametroRentencaoDAO ParametroRentencao = new ParametroRentencaoDAO();
            return ParametroRentencao.Lista();
        }
    }
}
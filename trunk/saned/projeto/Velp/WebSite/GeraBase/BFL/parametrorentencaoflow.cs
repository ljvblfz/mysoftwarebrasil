using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using GeraBase.Model;
using GeraBase.DAL;
using GDA;

namespace GeraBase.BFL
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
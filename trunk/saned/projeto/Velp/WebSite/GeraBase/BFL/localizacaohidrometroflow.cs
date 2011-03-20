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

	public class LocalizacaoHidrometroFlow
    {

        public static List<LocalizacaoHidrometroONP> ListaLocalizacaoHidrometro()
        {
            LocalizacaoHidrometroDAO LocalizacaoHidrometro = new LocalizacaoHidrometroDAO();
            return LocalizacaoHidrometro.Lista();
        }
    }
}
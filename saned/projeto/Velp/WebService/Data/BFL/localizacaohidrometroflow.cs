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

	public class LocalizacaoHidrometroFlow
    {

        public static List<LocalizacaoHidrometroONP> ListaLocalizacaoHidrometro()
        {
            LocalizacaoHidrometroDAO LocalizacaoHidrometro = new LocalizacaoHidrometroDAO();
            return LocalizacaoHidrometro.Lista();
        }
    }
}
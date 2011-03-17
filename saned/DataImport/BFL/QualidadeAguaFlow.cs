using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using GDA;
using Sinc_DATA.DAL;
using Sinc_DATA.Model;

namespace Sinc_DATA.BFL
{
    public class QualidadeAguaFlow
    {
        /// <summary>
        ///  Metodo que retorna todos os dados
        /// </summary>
        /// <returns></returns>
        public static List<QualidadeAgua> Lista()
        {
            QualidadeAguaDAO QualidadeAgua = new QualidadeAguaDAO();
            return QualidadeAgua.Lista();
        }

        /// <summary>
        /// Metodo que insere um registro na tabela
        /// </summary>
        /// <returns></returns>
        public static void Insert(List<QualidadeAgua> ListQualidadeAgua)
        {
            QualidadeAguaDAO QualidadeAgua = new QualidadeAguaDAO();

            try
            {
                foreach(QualidadeAgua ItemQualidadeAgua in ListQualidadeAgua)
                    QualidadeAgua.Insert(ItemQualidadeAgua);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
		
		/// <summary>
        ///  Metodo que retorna todos os dados
        /// </summary>
        /// <returns></returns>
        public static string getImpotacao(int grupo,int rotaIni,int rotaFim)
        {
            string result = "";
            QualidadeAguaDAO QualidadeAgua = new QualidadeAguaDAO();
            List<QualidadeAgua> lista = QualidadeAgua.Importar(grupo,rotaIni,rotaFim);
            foreach(QualidadeAgua item in lista)
            {
                result+=item.__ToSQL;
            }
            return result;
        }
    }
}
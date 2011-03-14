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
    public class QualidadeAguaFlow
    {
        public static List<QualidadeAguaONP> ListaQualidadeAgua(int grupo)
        {
            //Instancia do objeto DAO da qualidade da agua
            QualidadeAguaDAO QualidadeAgua = new QualidadeAguaDAO();

            //Lista de retorno dos dados
            List<QualidadeAguaONP> ListaQualidadeAgua;

            //Retorna uma lista de qualidade a
            ListaQualidadeAgua = QualidadeAgua.ListaQualidadeAgua(grupo);
            
            return ListaQualidadeAgua;
        }
    }
}

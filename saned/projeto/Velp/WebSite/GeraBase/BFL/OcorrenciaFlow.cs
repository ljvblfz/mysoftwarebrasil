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

    public class OcorrenciaFlow
    {

        /// <summary>
        ///  Retorna uma lista com todas as ocorencias
        /// </summary>
        /// <returns></returns>
        public static List<OcorrenciaONP> Lista()
        {
            OcorrenciaDAO Ocorrencia = new OcorrenciaDAO();
            return Ocorrencia.Lista();
        }

        /// <summary>
        ///  Retorna uma lista Para carregar um dropdownlist
        /// </summary>
        /// <returns></returns>
        public static List<OcorrenciaONP> ListaDropDown()
        {
            OcorrenciaDAO Ocorrencia = new OcorrenciaDAO();
            List<OcorrenciaONP> listaOcorrencia = Ocorrencia.Lista();
            List<OcorrenciaONP> listaOcorrenciaRetorno = new List<OcorrenciaONP>();
            OcorrenciaONP ocorrencia = new OcorrenciaONP();
            ocorrencia.cod_ocorrencia = 0;
            ocorrencia.des_ocorrencia = "SELECIONE";
            listaOcorrenciaRetorno.Add(ocorrencia);
            listaOcorrenciaRetorno.AddRange(listaOcorrencia);
            return listaOcorrenciaRetorno;
        }

        /// <summary>
        ///  Retorna a descrição da ocorrencia
        /// </summary>
        /// <param name="Codigo"></param>
        /// <returns></returns>
        public static string RetornaOcorrencia(int? Codigo)
        {
            OcorrenciaDAO Ocorrencia = new OcorrenciaDAO();
            string descricao = "";

            string where = String.Format("cod_ocorrencia = {0}", Codigo);
            List<OcorrenciaONP> listaOcorrencia = Ocorrencia.Select(new GDA.Sql.Query(where));

            if (listaOcorrencia.Count > 0)
                descricao = listaOcorrencia[0].des_ocorrencia.ToString();

            return descricao;
        }
    }
}
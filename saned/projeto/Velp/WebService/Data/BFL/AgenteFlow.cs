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
    public class AgenteFlow
    {
        /// <summary>
        /// Lista todos os agentes
        /// </summary>
        /// <param name="grupo"></param>
        /// <returns></returns>
        public static List<AgenteONP> ListaAgente(int grupo)
        {
            AgenteDAO agente = new AgenteDAO();
            return agente.ListaAgente(grupo);
        }

        /// <summary>
        /// Lista todos os agentes com um item nulo
        /// </summary>
        /// <param name="grupo"></param>
        /// <returns></returns>
        public static List<AgenteONP> ListaAgenteSelect(int grupo)
        {
            AgenteDAO objAgente = new AgenteDAO();
            AgenteONP agente = new AgenteONP();
            agente.cod_agente = null;
            agente.nom_agente = "Selecione";
            List<AgenteONP> agenteAUX = objAgente.ListaAgente(grupo);
            agenteAUX.Add(agente);

            return agenteAUX;
        }

        /// <summary>
        ///  Autentica o agente
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="senha"></param>
        /// <returns></returns>
        public static bool Autenticar(string usuario, string senha)
        {
            AgenteDAO agente = new AgenteDAO();
            return agente.LoginAgente(usuario, senha);
        }
    }
}

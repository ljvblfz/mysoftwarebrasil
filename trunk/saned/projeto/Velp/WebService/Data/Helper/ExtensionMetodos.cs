using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Helper
{
    public class ExtensionMetodos<T> where T :new() 
    {
        /// <summary>
        ///  Retorna uma pagina determinada
        /// </summary>
        /// <param name="lista">lista de dados</param>
        /// <param name="paginaInicial">pagina inicial</param>
        /// <param name="tamanho">tamanho da pagina</param>
        /// <returns>lista com o tamnho apatir do indice</returns>
        public List<T> RetornaPagina(List<T> lista,int paginaInicial,int tamanho)
        {
            // Lista de retorno
            List<T> listaPaginada = new List<T>();
            
            int paginaIni = (paginaInicial * tamanho);
            int paginaFim = (paginaIni + tamanho);

            // Verifica se a pagina esta dentro do limite
            if (lista.Count > paginaIni)
            {
                // Recupera os dados apartir
                for (int i = paginaIni; i < paginaFim; i++)
                {
                    if (lista.Count > i)
                        listaPaginada.Add(lista[i]);
                    else
                        break;
                }
            }

            return listaPaginada;
        }

    }
}

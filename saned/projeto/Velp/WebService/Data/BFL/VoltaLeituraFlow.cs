using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using GDA;
using Data.DAL;
using Data.Model;

namespace Data.BFL
{
    public class VoltaLeituraFlow
    {
        /// <summary>
        ///  Metodo que retorna todos os dados de leitura
        /// </summary>
        /// <returns></returns>
        public static List<VoltaLeitura> Lista()
        {
            VoltaLeituraDAO VoltaLeitura = new VoltaLeituraDAO();
            return VoltaLeitura.Select();
        }

        /// <summary>
        ///  Metodo que retorna todos os dados de leitura
        /// </summary>
        /// <param name="CDC"></param>
        /// <returns></returns>
        public static List<VoltaLeitura> Lista(int CDC)
        {
            VoltaLeituraDAO VoltaLeitura = new VoltaLeituraDAO();
            string where = String.Format("CDC = {0}", CDC);
            return VoltaLeitura.Select(new GDA.Sql.Query(where));
        }

        /// <summary>
        ///  Metodo que retorna todos os dados de leitura
        /// </summary>
        /// <param name="CDC"></param>
        /// <returns></returns>
        public static List<VoltaLeitura> VerificaCarga(string CDCs, int grupo, DateTime? referencia)
        {
            VoltaLeituraDAO VoltaLeitura = new VoltaLeituraDAO();
            string where = String.Format("CDC IN ({0}) AND Grupo = {1} AND Referencia = CONVERT(DATETIME,{2},102)", CDCs, grupo, referencia);
            return VoltaLeitura.Select(new GDA.Sql.Query(where));
        }

        /// <summary>
        ///  RETORNA UMA LISTA DE CRITICAS 
        /// </summary>
        /// <param name="grupo"></param>
        /// <param name="referencia"></param>
        /// <returns></returns>
        public static List<Critica> ListaCritica(int? CDC,int? rota, int? grupo, DateTime? referencia)
        {

            string where = @"
                             WHERE";
            List<GDAParameter> listaParametros = new List<GDAParameter>();

            // Cria a condição
            if (CDC == null && rota == null && grupo == null && referencia == null)
            {
                // Cria a condição para retornar todos os dados
                where += @" L.CDC <> ?CDC";
                GDAParameter parametroCDC = new GDAParameter("?CDC", 0);
                listaParametros.Add(parametroCDC);
            }
            else
            {
                if (CDC != null)
                {
                    where += @" L.CDC = ?CDC AND";
                    GDAParameter parametroCDC = new GDAParameter("?CDC", CDC);
                    listaParametros.Add(parametroCDC);
                }
                if (rota != null)
                {
                    where += @" L.Rota = ?rota AND";
                    GDAParameter parametroRota = new GDAParameter("?rota", rota);
                    listaParametros.Add(parametroRota);
                }
                if (grupo != null)
                {
                    where += @" L.Grupo = ?grupo AND";
                    GDAParameter parametroGrupo = new GDAParameter("?grupo", grupo);
                    listaParametros.Add(parametroGrupo);
                }
                if (referencia != null)
                {
                    where += @" G.Referencia = ?referencia AND";
                    GDAParameter parametroReferencia = new GDAParameter("?referencia", referencia);
                    listaParametros.Add(parametroReferencia);
                }

                where = where.TrimEnd('A', 'N', 'D');
            }

            // Instancia da DAO
            CriticaDAO objCritica = new CriticaDAO();

            // Lista de retorno
            List<Critica> listaRetorno = new List<Critica>();

            // Instancia das listas
            List<Critica> listaConsumoNegativo = new List<Critica>();
            List<Critica> listaLeituraNula = new List<Critica>();
            List<Critica> listaDiasConsumoNulo = new List<Critica>();
            List<Critica> listaValoresZerados = new List<Critica>();
            List<Critica> listaOcorrencia = new List<Critica>();
            List<Critica> listaRetida = new List<Critica>();
            List<Critica> listaConsumidoresBloqueados = new List<Critica>();
            List<Critica> listaConsumidoresNaoLido = new List<Critica>();

            // Retorna as listas com os dados separados
            listaLeituraNula = objCritica.ListaLeituraNula(where, listaParametros.ToArray());
            listaDiasConsumoNulo = objCritica.ListaDiasConsumoNulo(where, listaParametros.ToArray());
            listaValoresZerados = objCritica.ListaValoresZerados(where, listaParametros.ToArray());
            listaOcorrencia = objCritica.ListaOcorrenciaNula(where, listaParametros.ToArray());
            listaConsumoNegativo = objCritica.ListaConsumoNegativo(where, listaParametros.ToArray());
            listaRetida = objCritica.ListaContaRetida(where, listaParametros.ToArray());
            listaConsumidoresBloqueados = objCritica.ListaConsumidoBloqueado(where, listaParametros.ToArray());
            listaConsumidoresNaoLido = objCritica.ListaNaoLidos(where, listaParametros.ToArray());

            // Adiciona a lista de retorno
            listaRetorno.AddRange(listaOcorrencia);
            listaRetorno.AddRange(listaLeituraNula);
            listaRetorno.AddRange(listaDiasConsumoNulo);
            listaRetorno.AddRange(listaValoresZerados);
            listaRetorno.AddRange(listaConsumoNegativo);
            listaRetorno.AddRange(listaRetida);
            listaRetorno.AddRange(listaConsumidoresBloqueados);
            listaRetorno.AddRange(listaConsumidoresNaoLido);

            return listaRetorno;
        }

        /// <summary>
        ///  Atualiza os dados de uma lista
        /// </summary>
        /// <returns></returns>
        public static bool Updater(List<VoltaLeitura> lista)
        {
            bool retorno = true;
            VoltaLeituraDAO VoltaLeitura = new VoltaLeituraDAO();
            foreach (VoltaLeitura item in lista)
            {
                try
                {
                    int atualizou = VoltaLeitura.Update(item);

                }catch(Exception e)
                {
                    retorno = false;
                }
            }
            return retorno;
        }

        /// <summary>
        /// Metodo que insere um registro na tabela
        /// </summary>
        /// <param name="Leitura"></param>
        public static void Insert( VoltaLeitura Leitura)
        {
            VoltaLeituraDAO VoltaLeitura = new VoltaLeituraDAO();
            LigacoesDAO objLigacoes = new LigacoesDAO();
            List<Ligacoes> listaLigacoes = new List<Ligacoes>();
            long quantidade = 0;

            try
            {
                string whereLigacoes = String.Format("CDC = {0}", Leitura.CDC);
                listaLigacoes = objLigacoes.Select(new GDA.Sql.Query(whereLigacoes));
                
                if (listaLigacoes.Count > 0)
                {

                    /*
                     * Se natureza_ligacao = 1 só gravar em consumo_ajustado 
                     * Se natureza_ligacao = 2 gravar em consumo_ajustado e esgoto_ajustado 
                     * Se natureza_ligacao = 3 só gravar em esgoto_ajustado
                     * 
                     * IDA_LIGACOES.ident_consumidor = 2 pegar 
                     * val_consumo_rateado e jogar em 
                     * VOLTA_LEITURA.consumo_ajustado e esgoto_ajustado
                     */
                    if (listaLigacoes[0].Ident_Consumidor == 2)
                    {
                        if (listaLigacoes[0].Natureza_Ligacao == 1 )
                        {
                            Leitura.Consumo_Ajustado = Leitura.Consumo_Rateado;
                            Leitura.Consumo_Rateado = null;
                        }
                        else if (listaLigacoes[0].Natureza_Ligacao == 2)
                        {
                            Leitura.Esgoto_Ajustado = Leitura.Consumo_Rateado;
                            Leitura.Consumo_Ajustado = Leitura.Consumo_Rateado;
                            Leitura.Consumo_Rateado = null;
                        }
                        else if (listaLigacoes[0].Natureza_Ligacao == 3)
                        {
                            Leitura.Esgoto_Ajustado = Leitura.Consumo_Rateado;
                            Leitura.Consumo_Rateado = null;
                        }
                    }
                }

                // Retorna a quantidade de registros de uma matricula de uma referencia especifica
                quantidade = VoltaLeitura.CountVoltaLeitura(Leitura.Grupo, Leitura.Rota, Leitura.CDC, Leitura.Referencia);

                // Se existe um refistro atualiza
                if (quantidade == 1)
                    VoltaLeitura.Update(Leitura);

                // Se não existe insere o registro
                else if(quantidade < 1)
                    VoltaLeitura.Insert(Leitura);

                // CASO DE DUPLICAR REGISTROS (deleta todos e insere apenas um registro)
                else if (quantidade > 1)
                {
                    VoltaLeitura.Delete(Leitura);
                    VoltaLeitura.Insert(Leitura);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        ///  Insere uma lista da voltaLeitura
        /// </summary>
        /// <param name="listaLeitura"></param>
        public static void InsertList(List<VoltaLeitura> listaLeitura)
        {
            try
            {
                foreach(VoltaLeitura item in listaLeitura)
                {
                    Insert(item);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        ///  Veirifica Carga
        /// </summary>
        /// <param name="grupo"></param>
        /// <param name="rota"></param>
        /// <param name="referencia"></param>
        /// <returns></returns>
        public static int VerificaCarga(int grupo, int rota, DateTime referencia)
        {
            VoltaLeituraDAO objRoteiro = new VoltaLeituraDAO();
            return objRoteiro.ListaVoltaLeitura(grupo, rota, referencia);
        }

        /// <summary>
        ///  Isere dados de leitura bloqueada
        /// </summary>
        /// <param name="voltaLeitura"></param>
        /// <returns></returns>
        public static bool InsertLeituraBloqueada(VoltaLeitura voltaLeitura)
        {
            bool retorno = false;
            int saida = 0;
            VoltaLeituraDAO objLigacoes = new VoltaLeituraDAO();
            objLigacoes.Insert(voltaLeitura);
            List<VoltaLeitura> listaRetorno = Lista(voltaLeitura.CDC);
            if (listaRetorno.Count() > 0)
                retorno = true;

            return retorno;
        }
    }
}
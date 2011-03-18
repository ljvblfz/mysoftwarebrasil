using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using LTmobileData.Data.Model;
using LTmobileData.Data.DAL;
using GDA.Sql;

namespace LTmobileData.Data.BFL
{
    public class LeituraFlow
    {
        /// <summary>
        /// Quantidade de leitura realizada
        /// </summary>
        public static int _QtdLeituraRealizada = 0;

        public static int getQtdLeituraRealizadaCurrent { get { return _QtdLeituraRealizada; } set { } }

        /// <summary>
        /// Razão atual
        /// </summary>
        public static string _razaoCurrent;

        /// <summary>
        /// Razão atual
        /// </summary>
        public static string RazaoCurrent { get { return _razaoCurrent; } }

        /// <summary>
        /// Rota atual
        /// </summary>
        public static string _rotaCurrent;

        /// <summary>
        /// Rota atual
        /// </summary>
        public static string RotaCurrent { get { return _rotaCurrent; } }

        /// <summary>
        /// Livro atual
        /// </summary>
        public static string _livroCurrent;

        /// <summary>
        /// Rota atual
        /// </summary>
        public static string LivroCurrent { get { return _livroCurrent; } }

        /// <summary>
        /// Serviço atual
        /// </summary>
        public static string _ServicoCurrent;

        /// <summary>
        /// Serviço atual
        /// </summary>
        public static string ServicoCurrent { get { return _ServicoCurrent; } }

        public static List<Leitura> getLeituraNotSync()
        {
            return new LeituraDAO().getLeituraNotSync();
        }

        /// <summary>
        /// Retorna lista de Razão
        /// </summary>
        /// <returns>Razão</returns>
        public static List<int> getRazao(int usuario, string servico)
        {
            return new LeituraDAO().getRazao(usuario, servico);
        }

        /// <summary>
        /// Retorna lista de rota.
        /// </summary>
        /// <returns>Rota</returns>
        public static List<string> getRota(string razao, int usuario, string servico)
        {
            return new LeituraDAO().getRota(razao, usuario, servico);
        }

        /// <summary>
        /// Retorna todas as leituras de UC Ascendente
        /// </summary>
        /// <param name="razao"></param>
        /// <param name="usuario"></param>
        /// <param name="rota"></param>
        /// <returns></returns>
        public static List<Leitura> getRotaLeituraAsc()
        {
            return new LeituraDAO().getRotaleituraAsc(RazaoCurrent, RotaCurrent,LivroCurrent, ServicoCurrent, UsuarioFlow.UsuarioCurrent.MATRIC_FUNC);
        }

        /// <summary>
        /// Retorna rota de Leitura de Uc´s que não foram executadas (Não foram registradas leitura ou ocorrência de impedimento).
        /// </summary>
        /// <param name="razao"></param>
        /// <param name="rota"></param>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public static List<Leitura> getRotaLeituraNExecutadosAsc()
        {
            return new LeituraDAO().getRotaLeituraNExecutadosAsc(RazaoCurrent, RotaCurrent, LivroCurrent, ServicoCurrent, UsuarioFlow.UsuarioCurrent.MATRIC_FUNC);
        }

        /// <summary>
        /// Retorna rota de Leitura de Uc´s que não foram executadas (Não foram registradas leitura ou ocorrência de impedimento).
        /// </summary>
        /// <param name="razao"></param>
        /// <param name="rota"></param>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public static List<Leitura> getRotaLeituraNExecutadosDesc()
        {
            return new LeituraDAO().getRotaLeituraNExecutadosDesc(RazaoCurrent, RotaCurrent, LivroCurrent, ServicoCurrent, UsuarioFlow.UsuarioCurrent.MATRIC_FUNC);
        }

        /// <summary>
        /// Retorna todas as leituras de UC decrescente
        /// </summary>
        /// <param name="razao"></param>
        /// <param name="usuario"></param>
        /// <param name="rota"></param>
        /// <returns></returns>
        public static List<Leitura> getRotaLeituraDesc()
        {
            return new LeituraDAO().getRotaleituraDesc(RazaoCurrent, RotaCurrent, LivroCurrent, ServicoCurrent, UsuarioFlow.UsuarioCurrent.MATRIC_FUNC);
        }

        public static void AlteraStatusLeitura(string Condicao)
        {
            new LeituraDAO().AlteraStatusLeitura(Condicao);
        }

        /// <summary>
        /// Retorna rota de leitura com repasse
        /// </summary>
        /// <returns></returns>
        public static List<Leitura> getRotaLeituraRepasse()
        {
            return new LeituraDAO().getRotaLeituraRepasse(RazaoCurrent, RotaCurrent, LivroCurrent, ServicoCurrent, UsuarioFlow.UsuarioCurrent.MATRIC_FUNC);
        }

        /// <summary>
        /// Retorna rota de leitura com repasse
        /// </summary>
        /// <returns></returns>
        public static List<Leitura> getRotaLeituraRepasseAsc()
        {
            return new LeituraDAO().getRotaLeituraRepasseAsc(RazaoCurrent, RotaCurrent, LivroCurrent, ServicoCurrent, UsuarioFlow.UsuarioCurrent.MATRIC_FUNC);
        }

        /// <summary>
        /// Retorna rota de leitura de Uc´s não executadas
        /// </summary>
        /// <returns></returns>
        public static List<Leitura> getRotaLeituraNExecutados()
        {
            return new LeituraDAO().getRotaLeituraNExecutados(RazaoCurrent, RotaCurrent, LivroCurrent, ServicoCurrent, UsuarioFlow.UsuarioCurrent.MATRIC_FUNC);
        }


        public static List<Leitura> getRotaLeituraPriExecucaoAsc()
        {
            return new LeituraDAO().getRotaLeituraPriExecucaoAsc(RazaoCurrent, RotaCurrent, LivroCurrent, ServicoCurrent, UsuarioFlow.UsuarioCurrent.MATRIC_FUNC);
        }

        public static List<Leitura> getRotaLeituraPriExecucaoDesc()
        {
            return new LeituraDAO().getRotaLeituraPriExecucao(RazaoCurrent, RotaCurrent, LivroCurrent, ServicoCurrent, UsuarioFlow.UsuarioCurrent.MATRIC_FUNC);
        }

        /// <summary>
        /// Retorna Uc específica
        /// </summary>
        /// <param name="UC"></param>
        /// <returns></returns>
        public List<Leitura> getRotaleituraEspecifica(string UC)
        {
            return new LeituraDAO().getRotaleituraEspecifica(UC);
            
        }

        /// <summary>
        /// Retorna rota de leitura filtrada por medidor
        /// </summary>
        /// <param name="razao"></param>
        /// <param name="rota"></param>
        /// <param name="usuario"></param>
        /// <param name="medidor"></param>
        /// <returns></returns>
        public static List<Leitura> getRotaLeituraFiltroMedidor( string medidor)
        {
            return new LeituraDAO().getRotaLeituraFiltroMedidor(RazaoCurrent, RotaCurrent, LivroCurrent, ServicoCurrent, UsuarioFlow.UsuarioCurrent.MATRIC_FUNC, medidor);
        }

        /// <summary>
        /// Retorna rota de leitura filtrada por UC
        /// </summary>
        /// <param name="razao"></param>
        /// <param name="rota"></param>
        /// <param name="usuario"></param>
        /// <param name="Uc"></param>
        /// <returns></returns>
        public static List<Leitura> getRotaLeituraFiltroUc(string Uc)
        {
            return new LeituraDAO().getRotaLeituraFiltroUc(RazaoCurrent, RotaCurrent, LivroCurrent, ServicoCurrent, UsuarioFlow.UsuarioCurrent.MATRIC_FUNC, Uc);
        }

        /// <summary>
        /// Retorna informações da ultima uc registrada.
        /// </summary>
        /// <returns></returns>
        public static List<Leitura> getUltimaUcReg()
        {
            return new LeituraDAO().getUltimaUcReg(RazaoCurrent, RotaCurrent, LivroCurrent, ServicoCurrent, UsuarioFlow.UsuarioCurrent.MATRIC_FUNC);
        }
        
        /// <summary>
        /// Retorna quantidade de Uc´s visitados
        /// </summary>
        /// <returns></returns>
        public static int getQtdVisitados()
        {
            return new LeituraDAO().getQtdVisitados(RazaoCurrent, RotaCurrent, LivroCurrent, ServicoCurrent, UsuarioFlow.UsuarioCurrent.MATRIC_FUNC);
        }

        /// <summary>
        /// Retorna a quantidade de uc´s Repasse
        /// </summary>
        /// <returns></returns>
        public static int getQtdeRepasse()
        {
            return new LeituraDAO().getQtdeRepasse(UsuarioFlow.UsuarioCurrent.MATRIC_FUNC);
        }


        /// <summary>
        /// Retorna a quantidade de uc´s Não executados
        /// </summary>
        /// <returns></returns>
        public static int getQtdNExecutados()
        {
            return new LeituraDAO().getQtdNExecutados(UsuarioFlow.UsuarioCurrent.MATRIC_FUNC);
        }

        /// <summary>
        /// Retorna a quantidade de uc´s primeira execução
        /// </summary>
        /// <returns></returns>
        public static int getQtdPriExecucao()
        {
            return new LeituraDAO().getQtdPriExecucao(UsuarioFlow.UsuarioCurrent.MATRIC_FUNC);
        }
        
        /// <summary>
        /// Retorna a quantidade de uc´s com repasse
        /// </summary>
        /// <returns></returns>
        public static int getQtdRepasse()
        {
            return new LeituraDAO().getQtdRepasse(RazaoCurrent, RotaCurrent, LivroCurrent, ServicoCurrent, UsuarioFlow.UsuarioCurrent.MATRIC_FUNC);
        }

        /// <summary>
        /// Retorna a quantidade de uc´s
        /// </summary>
        /// <returns></returns>
        public static int getQtdUc()
        {
            return new LeituraDAO().getQtdUc(RazaoCurrent, RotaCurrent, LivroCurrent, ServicoCurrent, UsuarioFlow.UsuarioCurrent.MATRIC_FUNC);
        }

        /// <summary>
        /// Quantidade de repasses realizados
        /// </summary>
        /// <returns></returns>
        public static int getQtdRepasseRealizado()
        {
            return new LeituraDAO().getQtdRepasseRealizado(RazaoCurrent, RotaCurrent, LivroCurrent, ServicoCurrent, UsuarioFlow.UsuarioCurrent.MATRIC_FUNC);
        }

        /// <summary>
        /// Quantidade de impedimento
        /// </summary>
        /// <returns></returns>
        public static int getQtdImpedimento()
        {
            return new LeituraDAO().getQtdImpedimento(RazaoCurrent, RotaCurrent, LivroCurrent, ServicoCurrent, UsuarioFlow.UsuarioCurrent.MATRIC_FUNC);
        }

        public static int getQtdUcVisitada()
        {
            return new LeituraDAO().getQtdUcVisitada(RazaoCurrent, RotaCurrent, LivroCurrent, ServicoCurrent, UsuarioFlow.UsuarioCurrent.MATRIC_FUNC);

        }

        public static void DeleteTodos()
        {
            new LeituraDAO().DeleteTodos();
        }

        /// <summary>
        /// Atualiza informações da UC
        /// </summary>
        /// <param name="leitura"></param>
        public static void Update(Leitura leitura)
        {
            try
            {
                new LeituraDAO().Update(leitura);
                setQtdLeituraRealizada();

            }catch(Exception ex)
            {
                throw new Exception("Não foi possível alterar informações da unidade consumidora. Ex: "+ex+"");
            }
        
        }

        /// <summary>
        /// Insere leitura
        /// </summary>
        /// <param name="leitura"></param>
        public static void Insert(Leitura leitura)
        {
            try
            {
                new LeituraDAO().Insert(leitura);
            }
            catch (Exception ex)
            {                
                throw new Exception("Não foi possível Inserir informações da unidade consumidora"+ex.ToString());
            }
        
        }

        /// <summary>
        /// Insere ou atualiza leitura
        /// </summary>
        /// <param name="leitura"></param>
        public static void InsertorUpdate(Leitura leitura)
        {
            try
            {
                new LeituraDAO().InsertOrUpdate(leitura);
                setQtdLeituraRealizada();
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível alterar informações da unidade consumidora. Ex: "+ex+"");
            }
        }

        /// <summary>
        /// Grava o filtro de razão e rota
        /// </summary>
        /// <param name="razao"></param>
        /// <param name="rota"></param>
        public static void setFiltro(string razao, string rota, string servico)
        {          

            if (razao != null)
            {
                _razaoCurrent = razao;
            }
            if (rota != null)
            {
                if (rota == "Todas")
                {
                    _rotaCurrent = "Todas";
                    _livroCurrent = "Todas";
                }
                else
                {
                    _rotaCurrent = rota.Substring(0, rota.IndexOf("/"));

                    _livroCurrent = rota.Substring((rota.IndexOf("/") + 1), ((rota.Length - rota.IndexOf("/") - 1)));
                }

            }

            if (servico != null)
            {
                _ServicoCurrent = servico;
            }

        }

        /// <summary>
        /// Quantidade de leitura realizada
        /// </summary>
        public static void setQtdLeituraRealizada()
        {
            _QtdLeituraRealizada = _QtdLeituraRealizada + 1;
        }

        /// <summary>
        /// Reinicia quantidade de leitura realizada
        /// </summary>
        public static void ReiniciaQtdLeitReal()
        {
            _QtdLeituraRealizada = 0;
        }

        public static List<Leitura> getOcorrenciaUc(int COD_EMPRT, int COD_LOCAL, int NUM_RAZAO, int MES_ANO_FATUR, int NUM_UC, string TIPO_MEDIC)
        {
            return new LeituraDAO().getOcorrenciaUc( COD_EMPRT, COD_LOCAL, NUM_RAZAO, MES_ANO_FATUR, NUM_UC, TIPO_MEDIC);
        }

        


    }
}

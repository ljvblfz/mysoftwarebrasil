using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using Strategos.Api.Log4CS;
using Strategos.Api.Database.Impl;
using OnPlaceMovel.Source.Banco;
using OnPlaceMovel.Source.Forms;
using OnPlaceMovel.Source.Impressao;
using Strategos.Api.Database;

namespace OnPlaceMovel.Source.Controladores {
	public class BDController : IDisposable {
		#region Atributos e Propriedades
		private FormBD _bdForm;
		private FormAgenteCarga _formAgenteCarga;
		private OnpAgente _agente;
		private IImpressao _impressao;
		#endregion // Atributos e Propriedades

		public BDController(OnpAgente agente) {
			_agente = agente;
			
			_bdForm = new FormBD(this);
			_formAgenteCarga = new FormAgenteCarga();

			_impressao = ConfigXML.GetClasseImpressao();
		}

		#region Metodos Publicos
		/// <summary>
		/// Mostra o form de BD
		/// </summary>
		public void Show() {
			_bdForm.ShowDialog();
		}

		/// <summary>
		/// Sobrescrever a base normal com a base de dados vazia, efetivamente desfazendo uma carga
		/// </summary>
		public void DesfazerCarga() {
			File.Copy(ConfigXML.ArquivoBaseVazia, ConfigXML.ArquivoBase, true);
		}

		/// <summary>
		/// Teste de impressão para verificar se esta funcionando e conetado a impressa
		/// </summary>
		public void TesteImpressao() { 
			bool podeSair = false;
			int tentativas = 0;

			int MAX_TENTIVAS = 3;

            //TODO TESTE ALEXIS 19/10/2010
            //do {
            //    try {
            //        tentativas++;

            //        string groupoRoteiro = OnpRoteiro.GrupoRoteiroCarregado();
            //        string[] estatisticas = NavegacaoController.Estatisticas();
            //        if (_impressao.printTeste(Controlador.Agente, groupoRoteiro, estatisticas))
            //            podeSair = true;

            //    } catch (Exception ex) {
            //        MessageBox.Show("Erro ao tentar imprimir, verifica se a impressora esta ligada. (tentativa " + tentativas.ToString() + ")");
            //        Log4CS.Error("Erro no imprimir conta: " + ex.Message);
            //        podeSair = tentativas >= MAX_TENTIVAS;
            //    }
            //} while (!podeSair);
		}

		/// <summary>
		/// Gera uma copia da base com o nome do arquivo no formato "OnPlace-roteiro-referencia.sdf"
		/// </summary>
		/// <returns>Retorna o nome do arquivo que foi usado.</returns>
		public static void CopiarBase() {
			GerarCopia("OnPlace", true, true);
		}

		/// <summary>
		/// Gera uma copia da base com o nome do arquivo no formato "Carga-roteiro-referencia.sdf"
		/// </summary>
		/// <returns>Retorna o nome do arquivo que foi usado.</returns>
		public static string CriarBackupCarga() {
			return GerarCopia("Carga", false, false);
		}

		/// <summary>
		/// Gera uma copia da base com o nome do arquivo no formato "Descarga-roteiro-referencia.sdf"
		/// </summary>
		/// <returns>Retorna o nome do arquiv que foi usado.</returns>
		public static string CriarBackupDescarga() {
			return GerarCopia("Descarga", false, false);
		}

        // Gera arquivo com os dados (LOG) para poder visualizar
        public static bool GerarArqCSV(bool copiabase) {
            bool bRetorna = true;

            // criando tela de progresso
            ProgressoController _progresso;
            _progresso = new ProgressoController(false);
            _progresso.Show();
            _progresso.valorMin = 0;
            _progresso.valorMax = 3;
            _progresso.Posicao = 1;
            _progresso.Mensagem = "Buscando os dados do roteiro";
            _progresso.Refresh();

            Collection<OnpRoteiro> roteiros = new OnpRoteiro().SelectCollection();
            if (roteiros.Count == 0) {
                _progresso.Close();
                _progresso.Dispose();
                return false;
            }
            OnpRoteiro roteiro = roteiros[0];

            // Montando o menu
            _progresso.Posicao = 2;
            _progresso.Mensagem = "Buscando os dados de movimento";
            _progresso.Refresh();
            Collection<OnpMovimento> movimentos = new OnpMovimento().SelectCollection();

            // Mostrando tela de progresso
            _progresso.valorMin = 0;
            _progresso.valorMax = movimentos.Count + 4;
            _progresso.Posicao = 1;
            _progresso.Mensagem = "Apagando arquivos de log";
            _progresso.Refresh();

            string caminho = @"\Program files\OnPlaceMovel\base\";
            string arquivo = caminho + "log" + "-" + OnpRoteiro.GrupoRoteiroCarregado() + "-" + roteiro.CodReferencia + ".csv";
            string logMessage;
            string logOcorrencias;
            
            string[] arquivos = Directory.GetFiles(caminho, "*.csv");
            foreach (string st in arquivos) {
                // Apaga o arquivo caso exista
                if (File.Exists(st))
                    File.Delete(st);
            }

            _progresso.Posicao ++;
            _progresso.Mensagem = "Criando o arquivo de log";
            _progresso.Refresh();

            // Monta o arquivo
            StreamWriter writer = File.AppendText(arquivo);
            
            // Grupo 
            logMessage = "Roteiro: " + OnpRoteiro.GrupoRoteiroCarregado();
            writer.WriteLine(logMessage);
            // Referencia
            logMessage = "Referencia: " + roteiro.CodReferencia;
            writer.WriteLine(logMessage);
            // Data e hora de geração
            logMessage = "Arquivo gerado em " + DateTime.Now.ToString("dd/MM/yyyy") + " as " + DateTime.Now.ToString("HH:mm:ss");
            writer.WriteLine(logMessage);

            _progresso.Posicao++;
            _progresso.Mensagem = "Criando o arquivo de log - Estatísticas";
            _progresso.Refresh();
            // Estatistica
            string[] estatisticas = NavegacaoController.Estatisticas();
            writer.WriteLine("Total: " + estatisticas[4]);
            writer.WriteLine("Processadas: " + estatisticas[1]);
            writer.WriteLine("Emitidas: " + estatisticas[2]);
            writer.WriteLine("Retidas: " + estatisticas[3]);
            writer.WriteLine("Contas restantes: " + (int.Parse(estatisticas[4]) - int.Parse(estatisticas[1])));


            // Cabeçalho
            logMessage = "Data da Leitura;Agente;CDC;Situacao;Leitura Real;Leitura Atribuida;Ocorrencias;Consumo Medido;Consumo Atribuido;Consumo Rateado;Emissoes;Forma de Entrega";
            writer.WriteLine(logMessage);

            // Busca todas as leituras
            foreach (OnpMovimento mov in movimentos) {
                _progresso.Posicao++;
                _progresso.Mensagem = "Criando o arquivo de log - CDC " + mov.SeqMatricula.ToString();
                _progresso.Refresh();

                // Inicializa
                logMessage = mov.DatLeitura.ToString() + ";" +
                             mov.CodAgente.ToString() + ";" +
                             mov.SeqMatricula.ToString() + ";" +
                             mov.IndSituacaoMovimento.ToString() + ";" +
                             mov.ValLeituraReal.ToString() + ";" +
                             mov.ValLeituraAtribuida.ToString() + ";";

                // Busca as anormalidades
                logOcorrencias = "";
                foreach (OnpMovimentoOcorrencia oc in mov.MovimentosOcorrencia) {
                    if (!logOcorrencias.Equals(""))
                        logOcorrencias += " - ";
                    logOcorrencias += oc.CodOcorrencia.ToString();
                }

                // Finaliza
                logMessage += logOcorrencias + ";" +
                              mov.ValConsumoMedido.ToString() + ";" +
                              mov.ValConsumoAtribuido.ToString() + ";" +
                              mov.ValConsumoRateado.ToString() + ";" +
                              mov.ValImpressoes.ToString() + ";" +
                              mov.SeqTipoEntrega.ToString();
                // Grava a linha
                writer.WriteLine(logMessage);
            }
            
            writer.Flush();
            writer.Close();


            _progresso.Posicao++;
            _progresso.Mensagem = "Copiando a base";
            _progresso.Refresh();
            if (copiabase)
                bRetorna = (!GerarCopia("OnPlace", false, true).Equals(""));
            
            _progresso.Close();
            _progresso.Dispose();

            return bRetorna;
        }


		/// <summary>
		/// Faz dispose de componentes usados pelo controlador
		/// </summary>
		public void Dispose() {
			_formAgenteCarga.Dispose();
			_bdForm.Dispose();
		}
		#endregion // Metodos Publicos

		#region Metodos Privados
		/// <summary>
		/// Gera uma copia da base de dados.
		/// </summary>
		/// <param name="prefixo">Prefixo a ser usado no arquivo copiado.</param>
		/// <param name="pergunta">Indica se deve pergunta para sobrescrever arquivo caso o arquivo já exista.</param>
		/// <returns>Retorna o nome do arquiv que foi usado.</returns>
		private static string GerarCopia(string prefixo, bool pergunta, bool sobreescreve) {
			Collection<OnpRoteiro> roteiros = new OnpRoteiro().SelectCollection();

			if (roteiros.Count == 0) {
				if (pergunta)
					MessageBox.Show("Nenhum roteiro carregado para que seja feita copia");
				return string.Empty;
			}

			OnpRoteiro roteiro = roteiros[0];
			string caminho = @"\Program files\OnPlaceMovel\base\";
			string arquivo = caminho + prefixo + "-" + OnpRoteiro.GrupoRoteiroCarregado() + "-" + roteiro.CodReferencia + ".sdf";
            bool existearq = false;

            // Devido a problemas com a Irene, Retirei para sempre sobreesquever
            if (File.Exists(arquivo)) {
                existearq = true;
            }

            if (sobreescreve) {
                // apaga todos os existentes
                string[] arquivos = Directory.GetFiles(caminho, prefixo+"-*.csv");
                foreach (string st in arquivos) {
                    // Apaga o arquivo caso exista
                    if (File.Exists(st))
                        File.Delete(st);
                }
            }

            if (existearq && !sobreescreve && pergunta) {

                if (!pergunta)
                    return string.Empty;
                DialogResult dr = MessageBox.Show("Arquivo de copia já existe, sobrescrever?", "OnPlaceMovel", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (dr == DialogResult.No)
                    return string.Empty;
                dr = MessageBox.Show("Deseja mesmo sobrescrever? Este operação não pode ser desfeita.", "OnPlaceMovel", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (dr == DialogResult.No)
                    return string.Empty;
            }

			File.Copy(ConfigXML.ArquivoBase, arquivo, true);

            if (pergunta) {
                if (!existearq)
                   MessageBox.Show("Cópia da base realizada com sucesso!");
                else
                   MessageBox.Show("Cópia da base realizada com sucesso! Arquivo sobrescrito!");
            }
			return arquivo;
		}
		#endregion // Metodos Privados
	}
}

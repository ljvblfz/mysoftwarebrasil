using System;
using System.IO;
using System.Xml;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Collections.Generic;
using Strategos.Api.Patterns;
using Strategos.Api.Log4CS;
using OnPlaceMovel.Source.Banco;
using OnPlaceMovel.Source.Impressao;
using OnPlaceMovel.Source.Controladores;
using Strategos.Api.Winapi;

namespace OnPlaceMovel.Source.Teste {
	/// <summary>
	/// Classe que lê o arquivo de teste e executa os testes na matriculas do arquivo
	/// </summary>
	public class TesteController: OnPlaceMovel.Source.Teste.ITesteController {
		#region Constantes
		/// <summary>
		/// Constante com o caminho e o nome do arquivo que tem as matriculas para teste
		/// </summary>
		protected const string ARQUIVO_TESTE = @"\Program files\OnPlaceMovel\Teste\tst_matricula.xml";
		/// <summary>
		/// Numero de tentativas de impressão antes de pular a impressão da matricula
		/// </summary>
		protected const int TENTATIVAS_IMPRESSAO = 3;
		#endregion // Constantes

		#region Atributos e Propriedades
		/// <summary>
		/// Tela de progresso do teste
		/// </summary>
		protected ProgressoController _progresso;
		/// <summary>
		/// Classe de impressao usada para imprimir contas
		/// </summary>
		protected IImpressao _impressao;
		/// <summary>
		/// Guarda os parametro do teste (matriculas, ocorrencias, leituras)
		/// </summary>
		protected ParametrosTeste _parametrosTeste;
		#endregion

		/// <summary>
		/// Inicializa o objeto
		/// </summary>
		/// <remarks>
		/// Funcionamento:
		/// <list type="bullet">
		/// <item><description>Atribui um novo ProgressoController passando false para o construtor</description></item>
		/// <item><description>Atribui o resultado da chamada do metodo GetClasseImpressao() de ConfigXML para _impressao</description></item>
		/// </list>
		/// </remarks>
		public TesteController() {
			_impressao = ConfigXML.GetClasseImpressao();
			_parametrosTeste = CarregarMatriculas(TesteController.ARQUIVO_TESTE);
		}

		#region Metodos publicos
		/// <summary>
		/// Inicia o processo de teste do calculo sem parar em caso de erros e sem fazer impressão de contas
		/// </summary>
		/// <remarks>
		/// Funcionamento:
		/// <list type="bullet">
		/// <item><description>Chama o metodo ExecutarTeste() passando false em ambos os parametros</description></item>
		/// </list>
		/// </remarks>
		public bool ExecutarTeste() {
			return ExecutarTeste(false, false);
		}

		/// <summary>
		/// Testa uma matricula especifica
		/// </summary>
		/// <remarks>
		/// Funcionamento:
		/// <list type="bullet">
		/// <item><description>Chama o metodo ProcurarMatricula passando seqMatricula como parametro</description></item>
		/// <item><description>Caso o retorno desta chamada seja diferente de null chama o metodo TestarMatricula, passando false e o objeto retornado como parâmetro, retorna true</description></item>
		/// <item><description>Caso o retorno seja null, retorna false</description></item>
		/// </list>
		/// </remarks>
		/// <param name="seqMatricula">Sequencial da matricula a ser testada</param>
		/// <returns>Retorna true se testou ou falso caso nao tenha encontrado matricula.</returns>
		public bool TestarMatricula(int seqMatricula) {
			TstMatricula mat = ProcurarMatricula(seqMatricula);

			SystemTime.SetSystemTime(_parametrosTeste.DatLeitura);

			if (mat != null)
				TestarMatricula(false, mat);
			else
				return false;

			return true;
		}

		/// <summary>
		/// Inicia o processo de teste do calculo
		/// </summary>
		/// <remarks>
		/// Funcionamento:
		/// <list type="bullet">
		/// <item><description>Chama o metodo ProcurarMatricula passando seqMatricula como parametro</description></item>
		/// <item><description>Caso o retorno desta chamada seja diferente de null chama o metodo TestarMatricula, passando false e o objeto retornado como parâmetro, retorna true</description></item>
		/// <item><description>Caso o retorno seja null, retorna false</description></item>
		/// </list>
		/// </remarks>
		/// <param name="stopOnError">Indica se o teste deve ser interrompido caso o processamente de um TstMatricula de erro.</param>
		/// <param name="imprimirContas">Indica se contas devem ser impressas.</param>
		/// <returns>Retorna true se nao teve erros, caso contrario retorna false</returns>
		public bool ExecutarTeste(bool stopOnError, bool imprimirContas) {
			bool retorno = true;

			Log4CS.ResetTime("INICIANDO TESTE");

			if (!File.Exists(TesteController.ARQUIVO_TESTE)) {
				string msg = "Arquivo não encontrado: " + TesteController.ARQUIVO_TESTE;
				MessageBox.Show(msg, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
				Log4CS.Error(msg);
				retorno = false;
			} else {
				Log4CS.SplitTime("Matriculas carregadas para teste: " + _parametrosTeste.Matriculas.Length);

				// Altera a dada do sistema
				SystemTime.SetSystemTime(_parametrosTeste.DatLeitura);

				// Mostrando tela de progresso
				_progresso = new ProgressoController(false);
				_progresso.Show();
				_progresso.valorMin = 0;
				_progresso.valorMax = _parametrosTeste.Matriculas.Length;
				_progresso.Posicao = 0;
				_progresso.Mensagem = "Teste em andamento...";
				_progresso.Refresh();

				foreach (TstMatricula tm in _parametrosTeste.Matriculas) {
					try {
						TestarMatricula(imprimirContas, tm);
					} catch (Exception ex) {
						Log4CS.Error("==============================================================");
						Log4CS.Error("Erro executando teste na matricula " + tm.SeqMatricula.Value);
						Log4CS.Error(ex.Message);
						Log4CS.Error(ex.StackTrace);
						Log4CS.Error("==============================================================");

						retorno = false;

						if (stopOnError)
							break;
					}

					// Atualiza progresso na tela
					_progresso.Posicao++;
					_progresso.Refresh();
				}

				_progresso.Close();
				_progresso.Dispose();
			}

			Log4CS.SplitTime("FIM DO TESTE");

			return retorno;
		}
		#endregion // Metodos publicos

		#region Metodos privados
		/// <summary>
		/// Testa uma matricula
		/// </summary>
		/// <remarks>
		/// Funcionamento:
		/// <list type="bullet">
		/// <item><description>Materializa um OnpMatricula com base no seqMatricula de <paramref name="tm"/> (<c>matricula</c>)</description></item>
		/// <item><description>Caso esta matricula não tenha sido processada (IndProcessado igual a "N")</description></item>
		/// <item><description>Caso <paramref name="tm"/> tenha ocorrencias, chama o metodo CriarOcorrencias passando <c>matricula</c> e <paramref name="tm"/> como parametro</description></item>
		/// <item><description>Caso <paramref name="tm"/> tenha um ValLeitura diferente de null e PoderLer() passando <c>matricula</c> como parametro retorne true:</description></item>
		/// <item><description>- Chama o metodo ProcessaLeitura() do Movimento da <c>matricula</c> passando ValLeitura de <paramref name="tm"/> como parametro.</description></item>
		/// <item><description>- Caso contrario chama o metodo Processa() do Movimento da <c>matricula</c></description></item>
		/// <item><description>Caso PodeImprimir(<c>matricula</c>) retorne true:</description></item>
		/// <item><description>- Se imprimirConta for true chama o metodo ImprimirConta() passando <c>matricula</c> como parametro</description></item>
		/// <item><description>Faz as atribuições para o Movimento de <c>matricula</c></description></item>
		/// <item><description>- ValImpressoes = 1</description></item>
		/// <item><description>- SeqTipoEntrega = 1</description></item>
		/// <item><description>- IndFaturaEmitida = "S"</description></item>
		/// <item><description>Chama o metodo Persist() do Movimento de <c>matricula</c></description></item>
		/// <item><description>Caso Fatura de Movimento de <c>matricula</c> nao seja nulo</description></item>
		/// <item><description>- Se valor ValValorFatura da fatura for maior que zero chama o metodo geraCodigoBarrasELinhaDigitavel()</description></item>
		/// <item><description>- Atribui ValImpressoes, SeqTipoEntrega e IndFaturaEmitida do movimento para os respectivos atributos da Fatura de <c>matricula</c></description></item>
		/// <item><description>Chama o metodo Persist() da fatura</description></item>
		/// </list>
		/// </remarks>
		/// <param name="imprimirConta">Indica se deve imprimir a conta para a matricula testada</param>
		/// <param name="tm">Informações para teste da matricula.</param>
		protected virtual void TestarMatricula(bool imprimirConta, TstMatricula tm) {
			// Carregando OnpMatricula
			OnpMatricula matricula = OnpMatricula.Materialize(tm.SeqMatricula.Value);

			if (matricula.IndProcessado.Equals("N")) {
				// Inserindo as ocorrencias no movimento
				if (tm.Ocorrencias != null && tm.Ocorrencias.Length > 0)
					CriarOcorrencias(matricula, tm);

				// Verifica caso ocorrencia deixa fazer leitura
				if (FazerLeitura(matricula)) {
					if (tm.ValLeitura.HasValue && PodeLer(matricula)) {
						while (!matricula.Movimento.ProcessaLeitura(tm.ValLeitura.Value)) { }
					} else {
						matricula.Movimento.Processa();
					}
					
					matricula.IndProcessado = "S";
					matricula.Persist();
				}
			}

			// Impressão de contas
			ImprimirConta(imprimirConta, matricula);
		}

		/// <summary>
		/// Imprimi uma conta ou somente simula impressão
		/// </summary>
		/// <remarks>
		/// Funcionamento:
		/// <list type="bullet">
		/// <item><description>Caso nao possa imprimir (PodeImprimir(<c>matricula</c>) == false)</description></item>
		/// <item><description>- Para Fatura diferente de null ValValorFaturado maior que zero</description></item>
		/// <item><description>-- Chama o metodo geraCodigoBarrasELinhaDigitavel()</description></item>
		/// <item><description>-- Chama o metodo Persist() da fatura</description></item>
		/// <item><description>Atribui "S" para IndProcessado de <c>matricula</c></description></item>
		/// <item><description>Chama o metodo Persist() de <c>matricula</c></description></item>
		/// </list>
		/// </remarks>
		/// <param name="imprimirConta"></param>
		/// <param name="matricula"></param>
		protected virtual void ImprimirConta(bool imprimirConta, OnpMatricula matricula) {
			if (PodeImprimir(matricula) && matricula.IndProcessado.Equals("S")) {
				if (imprimirConta)
					ImprimirConta(matricula);

				// Forçando valores
				matricula.Movimento = null; // Forca recarregar dados do banco de dados
				AtribuiValoresImpressao(matricula);
			}
		}

		/// <summary>
		/// Faz impressão da conta ou do aviso de retenção da matricula
		/// </summary>
		/// <remarks>
		/// Funcionamento:
		/// <list type="bullet">
		/// <item><description>Sempre retorna true para o teste padrao</description></item>
		/// </list>
		/// </remarks>
		///  <param name="matricula">Retorna true se pode fazer leitura da matricula, caso contrario retorna false.</param>
		protected virtual bool FazerLeitura(OnpMatricula matricula) {
			return true;
		}

		/// <summary>
		/// Faz impressão da conta ou do aviso de retenção da matricula
		/// </summary>
		/// <remarks>
		/// Funcionamento:
		/// <list type="bullet">
		/// <item><description>Chama o metodo printFatura() de _impressao passando <c>matricula</c> como parametro</description></item>
		/// <item><description>Caso esta chamada retorna false, coloca no log um erro dizendo que nao foi possivel imprimir a conta da matricula junto com o seqMatricula</description></item>
		/// </list>
		/// </remarks>
		/// <param name="matricula">Matricula que tera a conta impressa.</param>
		protected virtual void ImprimirConta(OnpMatricula matricula) {
			if (!_impressao.printFatura(matricula))
				Log4CS.Error("Não foi possível imprimir conta da matricula: " + matricula.SeqMatricula);
		}										

		/// <summary>
		/// Verifica se pode fazer impressao de conta nas ocorrencias e na entrega especial
		/// </summary>
		/// <remarks>
		/// Funcionamento:
		/// <list type="bullet">
		/// <item><description>Retorna true se:</description></item>
		/// <item><description>- Caso naoEmitePorOcorrencia() retorna true</description></item>
		/// <item><description>- IndEntregaEspecial de Movimento for igual a "0" ou "1" ou "6"</description></item>
		/// </list>
		/// </remarks>
		/// <param name="matricula">Matricula que deve ser verificada.</param>
		/// <returns>Retorna true se pode imprimir, caso contrario retorna.</returns>
		protected virtual bool PodeImprimir(OnpMatricula matricula) {
			return (
				!matricula.Movimento.naoEmitePorOcorrencia() &&
				(matricula.Movimento.IndEntregaEspecial.Equals("0") ||
				matricula.Movimento.IndEntregaEspecial.Equals("1") ||
				matricula.Movimento.IndEntregaEspecial.Equals("6"))
			);
		}

		/// <summary>
		/// Verifica se a primeira ocorrencia exige leitura
		/// </summary>
		/// <remarks>
		/// Funcionamento:
		/// <list type="bullet">
		/// <item><description>Caso Movimento tenha ocorrencias:</description></item>
		/// <item><description>- Caso IndLeitura da ocorrencia de GetPrimeiraOcorrencia() do movimento seja "N", retorna false</description></item>
		/// <item><description>Retorna true</description></item>
		/// </list>
		/// </remarks>
		/// <param name="matricula">Matricula a ser verificada</param>
		/// <returns>Retorna true caso a matricula possa ser lida, caso contrário retorna false.</returns>
		protected virtual bool PodeLer(OnpMatricula matricula) {
			bool podeLer = true;

			// Verifica se exite ocorrencia que não deixa fazer leitura
			if (matricula.Movimento.MovimentosOcorrencia.Count > 0)
				if (matricula.Movimento.GetPrimeiraOcorrencia().Ocorrencia.IndLeitura.Equals("N"))
					podeLer = false;

			return podeLer;
		}

		/// <summary>
		/// Procura uma matricula no arquivo de teste
		/// </summary>
		/// <remarks>
		/// Funcionamento:
		/// <list type="bullet">
		/// <item><description>Chama o metodo CarregarMatriculas() passando ARQUIVO_TESTE como parametro (pt)</description></item>
		/// <item><description>Procura na lista de matricula de pt um TstMatricula que tem o mesmo sequencial recebido como parametro</description></item>
		/// <item><description>Retorna o TstMatricula encontrado ou null caso nao encontre</description></item>
		/// </list>
		/// </remarks>
		/// <param name="seqMatricula">Sequencial a ser matriculado</param>
		/// <returns>Retorna a matricula caso a encontra, ou null caso nao encontre.</returns>
		protected virtual TstMatricula ProcurarMatricula(int seqMatricula) {
			foreach (TstMatricula m in _parametrosTeste.Matriculas)
				if (m.SeqMatricula.Value == seqMatricula)
					return m;

			return null;
		}

		/// <summary>
		/// Cria as ocorrencias para matricula
		/// </summary>
		/// <remarks>
		/// Funcionamento:
		/// <list type="bullet">
		/// <item><description>Cria um OnpMovimentoOcorrencia para cada ocorrencia de Ocorrencias de <paramref name="tm"/></description></item>
		/// </list>
		/// </remarks>
		/// <param name="matricula">Matricula que vai receber as ocorrencias.</param>
		/// <param name="tm">Objeto que contém as informações de ocorrência a serem criadas.</param>
		protected virtual void CriarOcorrencias(OnpMatricula matricula, TstMatricula tm) {
			OnpMovimentoOcorrencia ocorrencia = new OnpMovimentoOcorrencia();

			ocorrencia.SeqMatricula = matricula.Movimento.SeqMatricula;
			ocorrencia.SeqRoteiro = matricula.Movimento.SeqRoteiro;
			ocorrencia.CodReferencia = matricula.Movimento.CodReferencia;
			ocorrencia.SeqSequencial = 0;

			// Não precisa criar um novo objeto toda vez que for inserir
			// pois a chave primeira será alterada e um novo registro
			// no banco de dados será criado quando o objeto for persistido
			foreach (TstMatriculaOcorrencia tmo in tm.Ocorrencias) {
				ocorrencia.CodOcorrencia = tmo.SeqOcorrencia;
				ocorrencia.SeqSequencial++;
				ocorrencia.Persist();
			}
		}

		/// <summary>
		/// Carrega a lista de matriculas do arquivo passado.
		/// </summary>
		/// <remarks>
		/// Funcionamento:
		/// <list type="bullet">
		/// <item><description>Lê os parametros de teste do arquivo recebido como parametro</description></item>
		/// <item><description>Retorna um ParametrosTeste com os parametro lidos ou null caso ocorra algum erro</description></item>
		/// </list>
		/// </remarks>
		/// <param name="FileXML">Caminho e nome do arquivo que contém as matrículas.</param>
		/// <returns>Retorna a lista de matriculas do arquivo ou null caso nao consiga carregar.</returns>
		protected virtual ParametrosTeste CarregarMatriculas(string FileXML) {
			ParametrosTeste retorno = null;
			Stream streamReader = null;

			try {
				XmlSerializer xmls = new XmlSerializer(typeof(ParametrosTeste));

				// Abre o arquivo para leitura
				streamReader = new FileStream(FileXML, FileMode.Open, FileAccess.Read, FileShare.None);

				// Lê a lista do arquivo
				retorno = xmls.Deserialize(streamReader) as ParametrosTeste;

				OrdenarMatriculas(retorno);

			} catch (Exception Ex) {
				Log4CS.Error(Ex);
				retorno = null;
			} finally {
				if (streamReader != null)
					streamReader.Close();
			}

			return retorno;
		}

		/// <summary>
		/// Ordena a lista de matriculas de forma a optimizar ou testar certas matriculas na ordem certa
		/// </summary>
		/// <param name="retorno"></param>
		protected virtual void OrdenarMatriculas(ParametrosTeste retorno) {
			return;
		}

		protected static void AtribuiValoresImpressao(OnpMatricula mat) {
			if (mat.Movimento.IndSituacaoMovimento.Equals("R") || mat.Movimento.IndSituacaoMovimento.Equals("F")) {
				mat.Movimento.ValImpressoes = 1;
				mat.Movimento.SeqTipoEntrega = 1;
				mat.Movimento.IndFaturaEmitida = "S";
				mat.Movimento.Persist();

				if (mat.Movimento.Fatura != null) {
					mat.Movimento.Fatura.ValImpressoes = mat.Movimento.ValImpressoes;
					mat.Movimento.Fatura.SeqTipoEntrega = mat.Movimento.SeqTipoEntrega;
					mat.Movimento.Fatura.IndFaturaEmitida = mat.Movimento.IndFaturaEmitida;
					mat.Movimento.Fatura.Persist();
				}
			}
		}
		#endregion // Metodos estaticos privados
	}
}

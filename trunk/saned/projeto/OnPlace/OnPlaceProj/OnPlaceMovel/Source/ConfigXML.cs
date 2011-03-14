using System;
using System.Xml;
using System.Windows.Forms;
using OnPlaceMovel.Source.Impressao;
using OnPlaceMovel.Source.CalculoTaxas;
using OnPlaceMovel.Source.Controladores;
using Strategos.Api.Log4CS;
using OnPlaceMovel.Source.Teste;
using OnPlaceMovel.Source.Banco;

namespace OnPlaceMovel.Source {
	/// <summary>
	/// Classe que acessa o arquivo de configuração do aplicativo
	/// </summary>
	public static class ConfigXML {
		#region Atributos para cache
		private static ITesteController _testeController;

		private static ILeitura _leitura;
		private static IAnaliseConta _analiseConta;
		private static ICodigoBarras _codigoBarras;
		private static ICalculaTaxas _calculaTaxas;
		private static ILeituraHDController _leituraHD;
		private static ICalculoConsumo _calculoConsumo;

		private static IPrinter _impressora;
		private static IImpressao _impressao;
		private static IImpressaoController _impressaoController;

		private static string _tentativasLeitura;
		private static string _senhaColeta;
		#endregion

		#region Informações
		/// <summary>
		/// Localização da base de dados
		/// </summary>
		public const string ArquivoBase = @"\Program files\OnPlaceMovel\base\OnPlace.sdf";

		/// <summary>
		/// Localização da base de dados vazia
		/// </summary>
		public const string ArquivoBaseVazia = @"\Program files\OnPlaceMovel\base\OnPlaceEmpty.sdf";

		/// <summary>
		/// Localização da base de dados com informacoes de teste,
		/// esta base sobrescreve ArquivoBase toda vez que o OnPlace roda, caso o ArquivoBaseTeste exista
		/// </summary>
		public const string ArquivoBaseTeste = @"\Program files\OnPlaceMovel\base\OnPlaceTeste.sdf";
		#endregion

		#region Metodos publicos
		/// <summary>
		/// Pega o objeto que deve ser usado para executar testes. Sai do aplicativo caso a classe indicada no arquivo não exista.
		/// </summary>
		/// <returns>Retorn o objeto que deve ser usado.</returns>
		public static ICalculoConsumo GetCalculoConsumo() {
			if (_calculoConsumo == null) {
				string classe = GetOpcao("calculoconsumo");

				if (string.IsNullOrEmpty(classe))
					_calculoConsumo = new CalculoConsumo();
				else
					_calculoConsumo = System.Reflection.Assembly.GetCallingAssembly().CreateInstance(classe) as ICalculoConsumo;

				if (_calculoConsumo == null) {
					MessageBox.Show("Erro lendo arquivo de configuração (classe '" + classe + "' não existe)");
					Application.Exit();
				}
			}

			return _calculoConsumo;
		}

		/// <summary>
		/// Pega o objeto que deve ser usado para executar testes. Sai do aplicativo caso a classe indicada no arquivo nao exista.
		/// </summary>
		/// <returns>Retorn o objeto que deve ser usado.</returns>
		public static ILeituraHDController GetLeituraHD() {
			string classe = GetOpcao("leiturahd");

			if (string.IsNullOrEmpty(classe))
				_leituraHD = new LeituraHDControllerPadrao();
			else
				_leituraHD = System.Reflection.Assembly.GetCallingAssembly().CreateInstance(classe) as ILeituraHDController;

			if (_leituraHD == null) {
				MessageBox.Show("Erro lendo arquivo de configuração (classe " + classe + " não existe)");
				Application.Exit();
			}

			return _leituraHD;
		}

		/// <summary>
		/// Pega o objeto que deve ser usado para executar testes. Sai do aplicativo caso a classe indicada no arquivo nao exista.
		/// </summary>
		/// <returns>Retorn o objeto que deve ser usado.</returns>
		public static ITesteController GetTesteController() {
			if (_testeController == null) {
				string classe = GetOpcao("classetestecontroller");

				if (string.IsNullOrEmpty(classe))
					_testeController = new TesteController();
				else
					_testeController = System.Reflection.Assembly.GetCallingAssembly().CreateInstance(classe) as ITesteController;

				if (_testeController == null) {
					MessageBox.Show("Erro lendo arquivo de configuração (classe " + classe + " não existe)");
					Application.Exit();
				}
			}

			return _testeController;
		}

		/// <summary>
		/// Pega a senha usada para fazer coleta
		/// </summary>
		/// <returns>String com a senha que deve ser usada para coleta</returns>
		public static string GetSenhaColeta() {
			if (string.IsNullOrEmpty(_senhaColeta)) {
				_senhaColeta = GetOpcao("senhaColeta");

				if (string.IsNullOrEmpty(_senhaColeta)) {
					MessageBox.Show("Erro lendo arquivo de configuração (senha de coleta nula ou vazia");
					Application.Exit();
				}
			}

			return _senhaColeta;
		}

		/// <summary>
		/// Retorna o objeto que deve ser usado para gerar codigo de barras
		/// </summary>
		/// <returns></returns>
		public static ICodigoBarras GetCodigoBarras() {
			if (_codigoBarras == null) {
				string classe = GetOpcao("classecodigobarras");

				if (string.IsNullOrEmpty(classe))
					_codigoBarras = new CodigoBarrasPadrao();
				else
					_codigoBarras = System.Reflection.Assembly.GetCallingAssembly().CreateInstance(classe) as ICodigoBarras;

				if (_codigoBarras == null) {
					MessageBox.Show("Erro lendo arquivo de configuração (classe " + classe + " não existe)");
					Application.Exit();
				}
			}

			return _codigoBarras;
		}

		/// <summary>
		/// Retorna o numero de tentativas que podem ser feitas para leitura. Valor padrao são 2 tentativas
		/// </summary>
		/// <remarks>
		/// Funcionamento:
		/// <list type="bullet">
		/// <item><description>Caso _tentativasLeitura seja nulo ou vazio:</description></item>
		/// <item><description>- Chama o metodo getOpcao() passando "tetantivasleitura" como parametro</description></item>
		/// <item><description>- Caso o resultado da chamada nao seja nulo atribui ele para _tentativasLeitura</description></item>
		/// <item><description>- Caso contrario atribui "2"</description></item>
		/// <item><description>Converte _tentativasLeitura para inteiro e retorna este valor</description></item>
		/// </list>
		/// </remarks>
		/// <returns>Retorna o numero de tentativas.</returns>
		public static int GetTentativasLeitura() {
			if (string.IsNullOrEmpty(_tentativasLeitura)) {
				_tentativasLeitura = GetOpcao("tentativasleitura");

				if (string.IsNullOrEmpty(_tentativasLeitura))
					_tentativasLeitura = "2";
			}

			return int.Parse(_tentativasLeitura);
		}

		/// <summary>
		/// Procura no config.xml qual o codigo do usuario administrador
		/// </summary>
		/// <remarks>
		/// Funcionamento:
		/// <list type="bullet">
		/// <item><description>Chama o metodo getOpcao passando "Adminstrador" como parametro</description></item>
		/// <item><description>Retorna o resultado da chamada</description></item>
		/// </list>
		/// </remarks>
		/// <returns>Retorna uma string com o codigo do adminstrador.</returns>
		public static string GetAdministrador() {
			return GetOpcao("Administrador");
		}

		/// <summary>
		/// Procura no config.xml a senha do usuario administrador
		/// </summary>
		/// <remarks>
		/// Funcionamento:
		/// <list type="bullet">
		/// <item><description>Chama o metodo getOpcao passando "SenhaAdm" como parametro</description></item>
		/// <item><description>Retorna o resultado da chamada</description></item>
		/// </list>
		/// </remarks>
		/// <returns>Retorna a senha recuperada do arquivo de configuração.</returns>
		public static string GetAdmPassword() {
			return GetOpcao("SenhaAdm");
		}

		/// <summary>
		/// Cria um objeto para leitura com base na classe descrita no config.xml
		/// </summary>
		/// <remarks>
		/// Funcionamento:
		/// <list type="bullet">
		/// <item><description>Chama o metodo getOpcao() passando "impressacontroler" como parametro (classe)</description></item>
		/// <item><description>Se classe for nulo atribui um novo ImpressaoController para _impressaoController</description></item>
		/// <item><description>Caso contrario atribui um objeto da classe especificado na string classe para _impressaoController</description></item>
		/// <item><description>Se nao conseguir criar a classe mostra um erro dizendo que a classe nao existe e sai do aplicativo</description></item>
		/// <item><description>Retorna _impressaoController</description></item>
		/// </list>
		/// </remarks>
		/// <returns>Retorna o objeto que deve ser usada para executar a leitura e registro de ocorrencias.</returns>
		public static IImpressaoController GetImpressaoController() {
			string classe = GetOpcao("impressaocontroller");

			if (string.IsNullOrEmpty(classe))
				_impressaoController = new ImpressaoController();
			else
				_impressaoController = System.Reflection.Assembly.GetCallingAssembly().CreateInstance(classe) as IImpressaoController;

			if (_impressaoController == null) {
				MessageBox.Show("Erro lendo arquivo de configuração (classe " + classe + " não existe)");
				Application.Exit();
			}

			return _impressaoController;
		}

		/// <summary>
		/// Cria um objeto para leitura com base na classe descrita no config.xml
		/// </summary>
		/// <remarks>
		/// Funcionamento:
		/// <list type="bullet">
		/// <item><description>Chama o metodo getOpcao() passando "classeleitura" como parametro (classe)</description></item>
		/// <item><description>Se classe for nulo atribui um novo LeituraPadrao para _leitura</description></item>
		/// <item><description>Caso contrario atribui um objeto da classe especificado na string classe para _leitura</description></item>
		/// <item><description>Se nao conseguir criar a classe mostra um erro dizendo que a classe nao existe e sai do aplicativo</description></item>
		/// <item><description>Retorna _leitura</description></item>
		/// </list>
		/// </remarks>
		/// <returns>Retorna o objeto que deve ser usada para fazer leitura e registro de ocorrencias.</returns>
		public static ILeitura GetClasseLeitura() {
			string classe = GetOpcao("classeleitura");

			if (string.IsNullOrEmpty(classe))
				_leitura = new LeituraPadrao();
			else
				_leitura = System.Reflection.Assembly.GetCallingAssembly().CreateInstance(classe) as ILeitura;

			if (_leitura == null) {
				MessageBox.Show("Erro lendo arquivo de configuração (classe " + classe + " não existe)");
				Application.Exit();
			}

			return _leitura;
		}

		/// <summary>
		/// Cria um objeto para calculo de taxas com base na classe descrita no config.xml
		/// </summary>
		/// <remarks>
		/// Funcionamento:
		/// <list type="bullet">
		/// <item><description>Chama o metodo getOpcao() passando "classecalculotaxa" como parametro (classe)</description></item>
		/// <item><description>Se classe for nulo atribui um novo CalculaTaxasPadrao para _calculaTaxas</description></item>
		/// <item><description>Caso contrario atribui um objeto da classe especificado na string classe para _calculaTaxas</description></item>
		/// <item><description>Se nao conseguir criar a classe mostra um erro dizendo que a classe nao existe e sai do aplicativo</description></item>
		/// <item><description>Retorna _calculaTaxas</description></item>
		/// </list>
		/// </remarks>
		/// <returns>Retorna o objeto que deve ser usada para fazer calculo de taxas.</returns>
		public static ICalculaTaxas GetClasseCalculoTaxas() {
			string classe = GetOpcao("classecalculotaxa");

			if (string.IsNullOrEmpty(classe))
				_calculaTaxas = new CalculaTaxasPadrao();
			else
				_calculaTaxas = System.Reflection.Assembly.GetCallingAssembly().CreateInstance(classe) as ICalculaTaxas;

			if (_calculaTaxas == null) {
				MessageBox.Show("Erro lendo arquivo de configuração (classe " + classe + " não existe)");
				Application.Exit();
			}

			return _calculaTaxas;
		}

		/// <summary>
		/// Cria um objeto para impressão de dados com base na classe descrita no config.xml
		/// </summary>
		/// <remarks>
		/// Funcionamento:
		/// <list type="bullet">
		/// <item><description>Chama o metodo getOpcao() passando "classeimpressao" como parametro (classe)</description></item>
		/// <item><description>Se classe for nulo atribui um novo ImpressaoPadrao para _impressao</description></item>
		/// <item><description>Caso contrario atribui um objeto da classe especificado na string classe para _impressao</description></item>
		/// <item><description>Se nao conseguir criar a classe mostra um erro dizendo que a classe nao existe e sai do aplicativo</description></item>
		/// <item><description>Atribui GetClasseImpressora() para Impressora de _impressao</description></item>
		/// <item><description>Retorna _impressao</description></item>
		/// </list>
		/// </remarks>
		/// <returns>Retorna o objeto que deve ser usada para fazer impressão de contas e avisos.</returns>
		public static IImpressao GetClasseImpressao() {
			if (_impressao == null) {
				string classe = GetOpcao("classeimpressao");

				if (!string.IsNullOrEmpty(classe))
					_impressao = System.Reflection.Assembly.GetCallingAssembly().CreateInstance(classe) as IImpressao;

				if (_impressao == null) {
					MessageBox.Show("Erro lendo arquivo de configuração (classe " + classe + " não existe)");
					Application.Exit();
				}

				_impressao.Impressora = ConfigXML.GetClasseImpressora();
			}

			return _impressao;
		}

		/// <summary>
		/// Cria um objeto para interagir com a impressora conectado no pocketpc com base na classe descrita no config.xml
		/// </summary>
		/// <remarks>
		/// Funcionamento:
		/// <list type="bullet">
		/// <item><description>Chama o metodo getOpcao() passando "classeimpressora" como parametro (classe)</description></item>
		/// <item><description>Se classe for nulo atribui um novo ZebraRW420 para _impressora</description></item>
		/// <item><description>Caso contrario atribui um objeto da classe especificado na string classe para _impressao</description></item>
		/// <item><description>Se nao conseguir criar a classe mostra um erro dizendo que a classe nao existe e sai do aplicativo</description></item>
		/// <item><description>Atribui GetPrinterPort() para Porta de _impressora</description></item>
		/// <item><description>Retorna _impressora</description></item>
		/// </list>
		/// </remarks>
		/// <returns>Retorna o objeto que deve ser usada para fazer interação com a impressora conectado no pocketpc.</returns>
		public static IPrinter GetClasseImpressora() {
			if (_impressora == null) {
				string classe = GetOpcao("classeimpressora");

				if (string.IsNullOrEmpty(classe))
					classe = typeof(ZebraRw420).FullName;

				_impressora = System.Reflection.Assembly.GetCallingAssembly().CreateInstance(classe) as IPrinter;

				if (_impressora == null) {
					MessageBox.Show("Erro lendo arquivo de configuração (classe " + classe + " não existe)");
					Application.Exit();
				}

				_impressora.Porta = ConfigXML.GetPrinterPort();
			}

			return _impressora;
		}

		/// <summary>
		/// Le o arquivo config.xml a porta que deve ser usada para fazer comunicacao com a impressora.
		/// </summary>
		/// <remarks>
		/// Funcionamento:
		/// <list type="bullet">
		/// <item><description>Chama o metodo getOpcao() passando "printerport" como parametro</description></item>
		/// <item><description>Retorna o resultado da chamada</description></item>
		/// </list>
		/// </remarks>
		/// <returns>Retorna uma string com a porta a ser usada.</returns>
		public static string GetPrinterPort() {
			return GetOpcao("printerport");
		}

		/// <summary>
		/// Cria um objeto para analise de contas com base na classe descrita no config.xml
		/// </summary>
		/// <remarks>
		/// Funcionamento:
		/// <list type="bullet">
		/// <item><description>Chama o metodo getOpcao() passando "classeanaliseconta" como parametro (classe)</description></item>
		/// <item><description>Se classe for nulo atribui um novo AnaliseConta para _analiseConta</description></item>
		/// <item><description>Caso contrario atribui um objeto da classe especificado na string classe para _analiseConta</description></item>
		/// <item><description>Se nao conseguir criar a classe mostra um erro dizendo que a classe nao existe e sai do aplicativo</description></item>
		/// <item><description>Atribui GetPrinterPort() para Porta de _impressora</description></item>
		/// <item><description>Retorna _analiseConta</description></item>
		/// </list>
		/// </remarks>
		/// <returns>Retorna o objeto que deve ser usada para fazer analise de contas.</returns>
		public static IAnaliseConta GetClasseAnaliseConta() {
			string classe = GetOpcao("classeanaliseconta");

			if (string.IsNullOrEmpty(classe))
				_analiseConta = new AnaliseConta();
			else
				_analiseConta = System.Reflection.Assembly.GetCallingAssembly().CreateInstance(classe) as IAnaliseConta;

			if (_analiseConta == null) {
				MessageBox.Show("Erro lendo arquivo de configuração (classe " + classe + " não existe)");
				Application.Exit();
			}

			return _analiseConta;
		}

		/// <summary>
		/// Devolve o nivel de log do arquivo de configuracao
		/// </summary>
		/// <remarks>
		/// Funcionamento:
		/// <list type="bullet">
		/// <item><description>Chama o metodo getOpcao() passando "log4cs.level" como parametro (classe)</description></item>
		/// <item><description>Chama o metodo Enum.Parse() passando o tipo de LogLevel, level e true como parametro</description></item>
		/// <item><description>Retorna o resultado da ultima chamada</description></item>
		/// </list>
		/// </remarks>
		/// <returns>Retorna o nivel de log.</returns>
		public static LogLevel GetLogLevel() {
			LogLevel logLevel = LogLevel.None;
			string level = GetOpcao("log4cs.level");
			logLevel = (LogLevel)Enum.Parse(typeof(LogLevel), level, true);
			return logLevel;
		}

		/// <summary>
		/// Le um parametro String do XML de configuração
		/// </summary>
		/// <remarks>
		/// Funcionamento:
		/// <list type="bullet">
		/// <item><description>chama o metodo getOpcao passando <paramref name="name"/> como parametro</description></item>
		/// <item><description>Retorna o resultado da chamada</description></item>
		/// </list>
		/// </remarks>
		/// <param name="name">Nome do parametro</param>
		/// <returns>String com o valor do parametro</returns>
		public static string GetParameter(string name) {
			return GetOpcao(name);
		}

		#endregion

		#region Metodos Privados
		/// <summary>
		/// Pega o valor de uma opção do arquivo de configuração do aplicativo
		/// </summary>
		/// <remarks>
		/// Funcionamento:
		/// <list type="bullet">
		/// <item><description>Abre o arquivo config.xml usando uma classe de leitura de arquivo xml</description></item>
		/// <item><description>Procura nos nós do arquivo xml uma tag com nome "opcao" e tem que tem o atributo name igual ao <paramref name="name"/> passado.</description></item>
		/// <item><description>Retorna a string do atributo valor desta tag</description></item>
		/// <item><description>Retorna uma string vazia caso acontece alguma exception.</description></item>
		/// </list>
		/// </remarks>
		/// <param name="name">Nome da opção</param>
		/// <returns>Retorna o valor da opcao que tem nome igual a <paramref name="name"/> ou uma string vazia caso acontece algum erro.</returns>
		private static string GetOpcao(string name) {
			string retorno = string.Empty;

			try {
				XmlDocument xmlDoc = new XmlDocument();
				xmlDoc.Load("\\Program Files\\OnPlaceMovel\\config.xml");

				// XML Tag
				XmlNode xml = xmlDoc.DocumentElement;

				foreach (XmlNode node in xml.ChildNodes)
					if (node.Name.Equals("opcao", StringComparison.CurrentCultureIgnoreCase) && node.Attributes["nome"].Value.Equals(name, StringComparison.CurrentCultureIgnoreCase)) {
						retorno = node.Attributes["valor"].Value;
						break;
					}
			} catch (XmlException) {
			}

			return retorno;
		}
		#endregion
	}
}

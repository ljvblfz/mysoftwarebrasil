namespace OnPlaceLoader.CommandLine {
	class CommandLineParser : Strategos.DesignPatterns.Singleton<CommandLineParser> {
		#region Atributos e Propriedades
		protected OnPlaceLoader.Enumerations.Cliente _cliente;
		[CommandLineSwitch("cliente", "Nome do cliente (Strategos, Diadema, Scs). Padrao: Strategos")]
		public OnPlaceLoader.Enumerations.Cliente Cliente {
			get { return _cliente; }
			set { _cliente = value; }
		}

		protected string _database;
		[CommandLineSwitch("database", "Nome da base de dados")]
		public string Database {
			get { return _database; }
			set { _database = value; }
		}

		protected string _server;
		[CommandLineSwitch("server", "Nome do Servidor")]
		public string Server {
			get { return _server; }
			set { _server = value; }
		}

		protected string _username;
		[CommandLineSwitch("username", "Nome do usuario para acessar o banco")]
		public string Username {
			get { return _username; }
			set { _username = value; }
		}

		protected string _password;
		[CommandLineSwitch("password", "Senha de acesso ao banco")]
		public string Password {
			get { return _password; }
			set { _password = value; }
		}

		protected int _roteiro;
		[CommandLineSwitch("roteiro", "Sequencia do roteiro a ser carregado")]
		public int Roteiro {
			get { return _roteiro; }
			set { _roteiro = value; }
		}

		protected string _referencia;
		[CommandLineSwitch("referencia", "Código da referencia")]
		public string Referencia {
			get { return _referencia; }
			set { _referencia = value; }
		}

		protected string _target;
		[CommandLineSwitch("target", "Caminho e nome do arquivo de saida para carga ou de entrada da descarga")]
		public string Target {
			get { return _target; }
			set { _target = value; }
		}

		protected bool _descarga;
		[CommandLineSwitch("descarga", "Indica que deve ser feita a descarga do arquivo especificado de 'target'")]
		public bool Descarga {
			get { return _descarga; }
			set { _descarga = value; }
		}

		protected bool _visivel;
		[CommandLineSwitch("visivel", "Indica se a janela de log deve ficar visivel")]
		public bool Visivel {
			get { return _visivel; }
			set { _visivel = value; }
		}

		private bool _empty;
		[CommandLineSwitch("empty", "Cria a base SDF vazia e nao faz mais nada")]
		public bool Empty {
			get { return _empty; }
			set { _empty = value; }
		}
		#endregion // Atributos e Propriedades

		public CommandLineParser() {
			_cliente = OnPlaceLoader.Enumerations.Cliente.Diadema;
			_roteiro = -1;

			Parser parser = new Parser(System.Environment.CommandLine, this);
			parser.Parse();
		}
	}
}

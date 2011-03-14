namespace OnPlaceMovel.Source.Impressao {
	/// <summary>
	/// interface que impressoras devem implementar
	/// </summary>
	public interface IPrinter {
		/// <summary>
		/// Porta de comunicacao usada
		/// </summary>
		string Porta { get; set; }

		/// <summary>
		/// Tipo da fonte
		/// </summary>
		int Fonte { get; set; }
		
		/// <summary>
		/// Tamanho da fonte
		/// </summary>
		int FonteSize { get; set; }
		
		/// <summary>
		/// Distancia entre as barras do codigo
		/// </summary>
		int BarcodeRatio { get; set; }
		
		/// <summary>
		/// Tipo do codigo de barras
		/// </summary>
		string BarcodeType { get; set; }
		
		/// <summary>
		/// Largura do codigo
		/// </summary>
		double BarcodeWidth { get; set; }
		
		/// <summary>
		/// Altura do codigo
		/// </summary>
		double BarcodeHeight { get; set; }

		/// <summary>
		/// Indica se o buffer de impressao esta vazio ou não
		/// </summary>
		bool BufferVazio { get; }

		/// <summary>
		/// Envia os comandos no buffer para impressora
		/// </summary>
		/// <returns>Retorna true se conseguiu enviar o buffer de comandos com sucesso</returns>
		bool Imprimir();
		
		/// <summary>
		/// Deve conecta na impressora/porta ou iniciar a comunicação
		/// </summary>
		void Conectar();
		
		/// <summary>
		/// Deve fechar porta ou desconectar da impressora
		/// </summary>
		void Desconectar();
	
		/// <summary>
		/// Limpa o buffer que tem os dados a serem enviados para a impressora
		/// </summary>
		void LimparComandos();

		/// <summary>
		/// Envia um comando para impressora
		/// </summary>
		/// <param name="cmd">Comando a ser enviador para impressora</param>
		void addCommand(string cmd);

		/// <summary>
		/// Imprime uma linha do ponto x,y inicial ate o x,y final com a largura especificada
		/// </summary>
		/// <param name="xIni">X inicial</param>
		/// <param name="yIni">Y inicial</param>
		/// <param name="xFim">X final</param>
		/// <param name="yFim">Y final</param>
		/// <param name="width">Largura da linha</param>
		void printLine(int xIni, int yIni, int xFim, int yFim, int width);

		/// <summary>
		/// Imprimi um texto alinhado para a esquerda
		/// </summary>
		/// <param name="texto">Texto a ser impresso</param>
		/// <param name="x">Posicao X (relativo a margem esquerda)</param>
		/// <param name="y">Posicao Y</param>
		void printText(string texto, int x, int y);
		
		/// <summary>
		/// Imprimi um codigo de barra
		/// </summary>
		/// <param name="code">Codigo a ser impresso</param>
		/// <param name="x">Posicao X</param>
		/// <param name="y">Posicao Y</param>
		void printBarCode(string code, int x, int y);
		
		/// <summary>
		/// Imprimi um texto alinhado para a direita
		/// </summary>
		/// <param name="texto">Texto a ser impresso</param>
		/// <param name="x">Posicao X (relativo a margem direita)</param>
		/// <param name="y">Posicao Y</param>
		void printTextRight(string texto, int x, int y);
	}
}

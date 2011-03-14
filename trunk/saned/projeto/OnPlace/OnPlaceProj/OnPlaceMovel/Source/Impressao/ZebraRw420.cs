using System;
using System.Text;
using System.IO.Ports;
using System.Collections.ObjectModel;

namespace OnPlaceMovel.Source.Impressao {
    /// <summary>
    /// Classe para impressora ZebraRW420
    /// </summary>
    public class ZebraRw420 : IPrinter {
        #region Atributos e Propriedades
        protected SerialPort _porta;
        protected Collection<string> _comandos;

		/// <summary>
		/// Indica se o buffer de impressão esta vazio ou não
		/// </summary>
		public bool BufferVazio {
			get { return _comandos.Count == 0; }
		}

		protected string _portaCom;
        /// <summary>
        /// Porta de comunicacao usada
        /// </summary>
        /// <remarks>
        /// <para>get: retorna _portaCom</para>
        /// <para>set: atribui para _portaCom o value</para>
        /// </remarks>
        public string Porta {
            get {
                return _portaCom;
            }
            set {
                _portaCom = value;
            }
        }

        protected string _barcodeType;
        /// <summary>
        /// Tipo do codigo de barras
        /// </summary>
        /// <remarks>
        /// <para>get: retorna _barcodeType</para>
        /// <para>set: atribui para _barcodeType o value</para>
        /// </remarks>
        public string BarcodeType {
            get {
                return _barcodeType;
            }
            set {
                _barcodeType = value;
            }
        }

        protected double _barcodeWidth;
        /// <summary>
        /// Largura do codigo
        /// </summary>
        /// <remarks>
        /// <para>get: retorna _barcodeWidth</para>
        /// <para>set: atribui para _barcodeWidth o value</para>
        /// </remarks>
        public double BarcodeWidth {
            get {
                return _barcodeWidth;
            }
            set {
                _barcodeWidth = value;
            }
        }

        protected int _barcodeRatio;
        /// <summary>
        /// distancia entre as barras do codigo
        /// </summary>
        /// <remarks>
        /// <para>get: retorna _barcodeRatio</para>
        /// <para>set: atribui para _barcodeRatio o value</para>
        /// </remarks>
        public int BarcodeRatio {
            get {
                return _barcodeRatio;
            }
            set {
                _barcodeRatio = value;
            }
        }

        protected double _barcodeHeight;
        /// <summary>
        /// Altura do codigo
        /// </summary>
        /// <remarks>
        /// <para>get: retorna _barcodeHeight</para>
        /// <para>set: atribui para _barcodeHeight o value</para>
        /// </remarks>
        public double BarcodeHeight {
            get {
                return _barcodeHeight;
            }
            set {
                _barcodeHeight = value;
            }
        }

        protected int _fonte;
        /// <summary>
        /// Tipo da fonte
        /// </summary>
        /// <remarks>
        /// <para>get: retorna _fonte</para>
        /// <para>set: atribui para _fonte o value</para>
        /// </remarks>
        public int Fonte {
            get {
                return _fonte;
            }
            set {
                _fonte = value;
            }
        }

        protected int _fonteSize;
        /// <summary>
        /// Tamanho da fonte
        /// </summary>
        /// <remarks>
        /// <para>get: retorna _fonteSize</para>
        /// <para>set: atribui para _fonteSize o value</para>
        /// </remarks>
        public int FonteSize {
            get {
                return _fonteSize;
            }
            set {
                _fonteSize = value;
            }
        }
        #endregion // Atributos e Propriedades

        /// <summary>
        /// Inicializa a classe com os valores padrões
        /// </summary>
        /// <remarks>
        /// Funcionamento:
        /// <list type="bullet">
        /// <item><description>Inicializa _comandos com uma nova colecao de string vazia</description></item>
        /// <item><description>Faz as seguintes atribuições:</description></item>
        /// <item><description>- _barcodeType = "I2OF5"</description></item>
        /// <item><description>- _barcodeWidth = 1</description></item>
        /// <item><description>- _barcodeRatio = 1</description></item>
        /// <item><description>- _barcodeHeight = 1</description></item>
        /// <item><description>- _fonte = 7</description></item>
        /// <item><description>- _fonteSize = 1</description></item>
        /// </list>
        /// </remarks>
        public ZebraRw420() {
            _comandos = new Collection<string>();

            _barcodeWidth = 0.24;
            _barcodeRatio = 2;
            _barcodeHeight = 13;
            _barcodeType = "I2OF5";

            _fonte = 7;
            _fonteSize = 1;
        }

        #region Metodos públicos
		/// <summary>
		/// Envia um comando para impressora
		/// </summary>
		/// <param name="cmd">Comando a ser enviador para impressora</param>
		public void addCommand(string cmd) {
			_comandos.Add(cmd);
		}
		
		/// <summary>
        /// Conecta na impressora, envia os comandos de impressão e desconecta. Não limpa a lista de comandos após envio.
        /// </summary>
        /// <remarks>
        /// Funcionamento:
        /// <list type="bullet">
        /// <item><description>Se _porta for null cria um novo SerialPort passado _portaCom como parametro. Seta o timeout para 5000 milisegundos e newline para "\n"</description></item>
        /// <item><description>Chama o metodo Conectar()</description></item>
        /// <item><description>Envia para impressora a string "! 0 200 200 220 1" usando o meotod WhiteLine()</description></item>
        /// <item><description>Envia para impressora a string "IN-MILLIMETERS" usando o meotod WhiteLine()</description></item>
        /// <item><description>Envia para impressora a string "LT LF" usando o meotod WhiteLine()</description></item>
        /// <item><description>Envia todos as string na lista _comandos usando o metodo WhiteLine()</description></item>
        /// <item><description>Envia para impressora a string "FORM" usando o meotod WhiteLine()</description></item>
        /// <item><description>Envia para impressora a string "PRint" usando o meotod WhiteLine()</description></item>
        /// <item><description>Chama o metodo Desconectar()</description></item>
        /// <item><description>Retorn true</description></item>
        /// <item><description>Captura as exceções TimeoutException, ArgumentException e InvalidOperationException, retorna false caso alguma destas exceções aconteça</description></item>
        /// </list>
        /// </remarks>
        /// <returns>Retorna true se conseguiu imprimir</returns>
        public virtual bool Imprimir() {
            try {
                if (_porta == null) {
                    _porta = new SerialPort(_portaCom);
                    _porta.WriteTimeout = 5000; // 5 segundos de timeout
                    _porta.NewLine = "\n";
                    //_porta.WriteBufferSize = 4096;
                }

                Conectar();

                _porta.WriteLine("! 0 200 200 225 1"); // Inicia a página passando o tamanho da página
                _porta.WriteLine("IN-MILLIMETERS"); // Em milimetros
                _porta.WriteLine("LT LF"); // Código de caracters
                //_porta.WriteLine( "CHAR-SET LATIN9" ); // Código de caracters

                foreach (string comando in _comandos) // Imprime a página
                    _porta.WriteLine(comando);

                _porta.WriteLine("FORM"); // Próxima página
                _porta.WriteLine("PRINT"); // Finaliza a impressão

                Desconectar();
            } catch (TimeoutException) {
                return false;
            } catch (ArgumentException) {
                return false;
            } catch (InvalidOperationException) {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Imprimi o texto passando alinhando ele a esquerda
        /// </summary>
        /// <remarks>
        /// Funcionamento:
        /// <list type="bullet">
        /// <item><description>Monta uma string no formato: "TEXT fonte fontesize x y texto"</description></item>
        /// <item><description>Deve-se usar o texto retornado pelo metodo tiraAcentos()</description></item>
        /// <item><description>Adiciona a string montada em _comandos</description></item>
        /// </list>
        /// </remarks>
        /// <param name="texto">Texto a ser impresso</param>
        /// <param name="x">Posicao x (milimetros)</param>
        /// <param name="y">Posicao y (milimetros)</param>
        public virtual void printText(string texto, int x, int y) {
            string comando = string.Format("TEXT {0} {1} {2} {3} {4}", _fonte, _fonteSize, x, y, tiraAcentos(texto));
            _comandos.Add(comando);
        }

        /// <summary>
        /// Imprimi o texto passado alinhando ele a direita
        /// </summary>
        /// <remarks>
        /// Funcionamento:
        /// <list type="bullet">
        /// <item><description>Monta uma string no formato: "RIGHT x"</description></item>
        /// <item><description>Adiciona a string em _comandos</description></item>
        /// <item><description>Monta uma string no formato: "TEXT fonte fontesize 0 y texto"</description></item>
        /// <item><description>Deve-se usar o texto retornado pelo metodo tiraAcentos()</description></item>
        /// <item><description>Adiciona a string montada em _comandos</description></item>
        /// <item><description>Adiciona a string "LEFT" em _comandos</description></item>
        /// </list>
        /// </remarks>
        /// <param name="texto">Texto a ser impresso</param>
        /// <param name="x">Posicao x (milimetros)</param>
        /// <param name="y">Posicao y (milimetros)</param>
        public virtual void printTextRight(string texto, int x, int y) {
            string cmdRight = string.Format("RIGHT {0}", x);
            string comando = string.Format("TEXT {0} {1} {2} {3} {4}", _fonte, _fonteSize, 0, y, tiraAcentos(texto));
            string cmdLeft = "LEFT";

            _comandos.Add(cmdRight);
            _comandos.Add(comando);
            _comandos.Add(cmdLeft);
        }

        /// <summary>
        /// Imprimi uma linha na espera passada usando os pontos passados
        /// </summary>
        /// <remarks>
        /// Funcionamento:
        /// <list type="bullet">
        /// <item><description>Monta uma string no formato: "LINE xIni yIni xFim yFim width"</description></item>
        /// <item><description>Adiciona a string montada em _comandos</description></item>
        /// </list>
        /// </remarks>
        /// <param name="xIni">Posicao x inicial (milimetros)</param>
        /// <param name="yIni">Posicao y inicial (milimetros)</param>
        /// <param name="xFim">Posicao x final (milimetros)</param>
        /// <param name="yFim">Posicao y final (milimetros)</param>
        /// <param name="width">Largura da linha (milimetros)</param>
        public virtual void printLine(int xIni, int yIni, int xFim, int yFim, int width) {
            string comando = string.Format("LINE {0} {1} {2} {3} {4}", xIni, yIni, xFim, yFim, width);
            _comandos.Add(comando);
        }

        /// <summary>
        /// Imprimi o codigo de barras passado
        /// </summary>
        /// <remarks>
        /// Funcionamento:
        /// <list type="bullet">
        /// <item><description>Monta uma string no formato: "BARCODE type width ratio height x y code"</description></item>
        /// <item><description>Adiciona a string montada em _comandos</description></item>
        /// </list>
        /// </remarks>
        /// <param name="code"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public virtual void printBarCode(string code, int x, int y) {
            string comando = string.Format("BARCODE {0} {1} {2} {3} {4} {5} {6}", _barcodeType, _barcodeWidth, _barcodeRatio, _barcodeHeight, x, y, code);
            _comandos.Add(comando);
        }

        /// <summary>
        /// Limpa a lista de comandos da impressora
        /// </summary>
        /// <remarks>
        /// Funcionamento:
        /// <list type="bullet">
        /// <item><description>Chama o metodo Clear() de _comandos</description></item>
        /// </list>
        /// </remarks>
        public virtual void LimparComandos() {
            _comandos.Clear();
        }

        /// <summary>
        /// Abre conexão com a impressora
        /// </summary>
        /// <remarks>
        /// Funcionamento:
        /// <list type="bullet">
        /// <item><description>Caso IsOpen de _porta for false, chama o metodo Open() do _porta</description></item>
        /// </list>
        /// </remarks>
        public virtual void Conectar() {
            if (!_porta.IsOpen)
                _porta.Open();
        }

        /// <summary>
        /// Fecha a conexão com a impressora
        /// </summary>
        /// <remarks>
        /// Funcionamento:
        /// <list type="bullet">
        /// <item><description>Caso IsOpen de _porta for true, chama o metodo Close() do _porta</description></item>
        /// </list>
        /// </remarks>
        public virtual void Desconectar() {
            if (_porta.IsOpen)
                _porta.Close();
        }
        #endregion

        #region Métodos privados
        /// <summary>
        /// Remove qualquer tipo de acento da string passada
        /// </summary>
        /// <remarks>
        /// Funcionamento:
        /// <list type="bullet">
        /// <item><description>Remove qualquer caracter com acento de <paramref name="src"/></description></item>
        /// <item><description>Retorna a string modificada</description></item>
        /// </list>
        /// </remarks>
        /// <param name="src">String cuja os acentos devem ser removidos</param>
        /// <returns>Retorna a string sem acentos</returns>
        protected string tiraAcentos(string src) {
            StringBuilder result = new StringBuilder();

            if (!string.IsNullOrEmpty(src)) {
                const string de = "áãâäàêéèëíìîïóòôõöúùûüçÁÀÂÃÄÊÉÈËÍÌÎÏÔÕÓÒÖÚÙÛÜÇ";
                const string por = "aaaaaeeeeiiiiooooouuuucAAAAAEEEEIIIIOOOOOUUUUC";

                foreach (char c in src) {
                    int pi = de.IndexOf(c);

                    if (pi >= 0)
                        result.Append(por[pi]);
                    else
                        result.Append(c);
                }
            }

            return result.ToString();
        }
        #endregion
	}
}

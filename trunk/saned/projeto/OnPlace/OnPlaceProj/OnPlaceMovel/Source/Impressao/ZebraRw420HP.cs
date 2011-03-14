using System;
using System.Text;
using System.IO.Ports;
using System.Collections.ObjectModel;

namespace OnPlaceMovel.Source.Impressao {
	/// <summary>
	/// Classe para impressora ZebraRW420 para ser usada no PocketPC
	/// </summary>
	public class ZebraRw420HP: ZebraRw420 {
		public ZebraRw420HP() : base() {
		}

		/// <summary>
		/// Destrutor da classe, libera os devices necessarios
		/// </summary>
		~ZebraRw420HP() {
			Liberar();
		}


		#region Metodos públicos
		/// <summary>
		/// Conecta na impressora, envia os comandos de impressão e desconecta. Não limpa a lista de comandos após envio.
		/// </summary>
		/// <remarks>
		/// Funcionamento:
		/// <list type="bullet">
		/// <item><description>Concatena em uma string "! 0 200 200 220 1\r\n", "IN-MILLIMETERS\r\n", "CHAR-SET LATIN9\r\n" e todos so comandos de _comandos colocando "\r\n" depois de cada string</description></item>
		/// <item><description>Concatena a string "FORM\r\n" e "PRint\r\n" junto a string anterior</description></item>
		/// <item><description>Converte a string montada em um array de bytes</description></item>
		/// <item><description>Caso _porta seja null, cria uma nova SerialPort passando _portaCom e 57600 como parametros</description></item>
		/// <item><description>Chama o metodo Conectar()</description></item>
		/// <item><description>Escreve na porta a string convertida para array de bytes</description></item>
		/// <item><description>Chama o metodo Desconectar()</description></item>
		/// <item><description>Retorn true</description></item>
		/// <item><description>Captura as exceções TimeoutException, ArgumentException e InvalidOperationException, retorna false caso alguma destas exceções aconteça</description></item>
		/// </list>
		/// </remarks>
		/// <returns></returns>
		/// <returns>Retorna true se conseguiu imprimir</returns>
		public override bool Imprimir() {
			try {
				//Monta a impressao
				StringBuilder data = new StringBuilder();

				data.Append("! 0 200 200 220 1\r\n"); // Inicia a página passando o tamanho da página
				data.Append("IN-MILLIMETERS\r\n"); // Em milimetros
				data.Append("CHAR-SET LATIN9\r\n"); // Código de caracters

				foreach (string comando in _comandos) // Imprime a página
					data.Append(comando + "\r\n");

				data.Append("FORM\r\n"); // Próxima página
				data.Append("PRINT\r\n"); // Finaliza a impressão

				// Converte em binario
				byte[] dataBin = System.Text.ASCIIEncoding.ASCII.GetBytes(data.ToString());

				// Descarrega na impressora
                if (_porta == null) {
                    _porta = new SerialPort(_portaCom);
                    _porta.WriteTimeout = 5000; // 5 segundos de timeout
                    _porta.NewLine = "\n";
                    _porta.WriteBufferSize = 4096;
                }

				Conectar();
				_porta.Write(dataBin, 0, dataBin.Length);
				Desconectar();

                _porta = null;
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
		/// Libera a impressora
		/// </summary>
		/// <remarks>
		/// Funcionamento:
		/// <list type="bullet">
		/// <item><description>Se _porta for diferente de null chama o metodo Dipose() e atribui null para _porta</description></item>
		/// </list>
		/// </remarks>
		public virtual void Liberar() {
			if (_porta != null) {
				_porta.Dispose();
				_porta = null;
			}
		}

		#endregion
	}
}

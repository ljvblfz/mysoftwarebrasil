namespace OnPlaceMovel.Source.Impressao {
	/// <summary>
	/// interface que deve ser implementada para classes que fazem impressao de contas
	/// </summary>
    public interface IImpressao {
		/// <summary>
		/// Retorna a matricula que vai ter conta impressa
		/// </summary>
		OnPlaceMovel.Source.Banco.OnpMatricula Matricula { get; }

		/// <summary>
		/// Impressora que sera usada para imprimir a conta
		/// </summary>
        IPrinter Impressora { get; set; }

		/// <summary>
		/// Imprimi a fatura para a matricula recebida
		/// </summary>
		/// <param name="matricula">Matricula que deve ter a conta impressa</param>
		/// <returns>Retorna true se imprimir, caso contrario retorna false.</returns>
		bool printFatura(OnPlaceMovel.Source.Banco.OnpMatricula matricula);
        
		/// <summary>
		/// Imprimi a fatura em forma de segunda via
		/// </summary>
		/// <param name="segVia">Fatura a ser impressa</param>
		/// <returns>Retorna true se imprimir, caso contrario retorna false.</returns>
		bool print2aVia(OnPlaceMovel.Source.Banco.OnpFatura segVia);

		/// <summary>
		/// Imprimi um aviso de debito
		/// </summary>
		/// <param name="matricula"></param>
		/// <returns>Retorna true se imprimir, caso contrario retorna false.</returns>
		bool printAvisoDebito(OnPlaceMovel.Source.Banco.OnpMatricula matricula);

		/// <summary>
		/// Imprimi uma folha de teste
		/// </summary>
		/// <param name="agente"></param>
		/// <param name="grupoRoteiro"></param>
		/// <param name="estatisticas"></param>
		/// <returns>Retorna true se imprimir, caso contrario retorna false.</returns>
		bool printTeste(OnPlaceMovel.Source.Banco.OnpAgente agente, string grupoRoteiro, string[] estatisticas);
    }
}

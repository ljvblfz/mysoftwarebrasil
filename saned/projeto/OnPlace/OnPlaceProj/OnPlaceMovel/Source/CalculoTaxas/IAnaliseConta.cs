using System;

namespace OnPlaceMovel.Source.CalculoTaxas {
	/// <summary>
	/// interface que deve ser implementada para clientes que têm regras especificas de analise de conta
	/// </summary>
	public interface IAnaliseConta {
		/// <summary>
		/// Indica se deve acrestimo de consumo
		/// </summary>
		/// <param name="movimento">Movimento a ser analisado</param>
		/// <returns>Retorna true se teve acrescimo de consumo, caso contrario retorna false</returns>
		bool AcrescimoConsumo(OnPlaceMovel.Source.Banco.OnpMovimento movimento);
		
		/// <summary>
		/// Indica se deve ser emitido um aviso de variacao na conta do cliente
		/// </summary>
		/// <param name="matricula"></param>
		/// <returns>Retorna true se o aviso deve ser emitido, caso contrario retorna false</returns>
		bool EmiteAvisoVariacao(OnPlaceMovel.Source.Banco.OnpMatricula matricula);
		
		/// <summary>
		/// Faz analise da conta indicando se deve ou não reter para análise
		/// </summary>
		/// <param name="movimento">Movimento a ser analisado</param>
		/// <returns>Retorna true se a conta deve ficar retida para analise</returns>
		bool RetemParaAnalise(OnPlaceMovel.Source.Banco.OnpMovimento movimento);
		
		/// <summary>
		/// Calcula variação do consumo em porcentagem
		/// </summary>
		/// <param name="movimento">Movimento a ser analisado</param>
		/// <returns>Retorna um valor percentual positivo indicando acréscimo ou um valor percentual negativo indicando descréscimo</returns>
		int VariacaoConsumo(OnPlaceMovel.Source.Banco.OnpMovimento movimento);
	}
}

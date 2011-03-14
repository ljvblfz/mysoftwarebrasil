using System;
using System.Text;
using OnPlaceMovel.Source.Teste;
using Strategos.Api.Patterns;
using OnPlaceMovel.Source.Banco;
using System.Collections.Generic;
using Strategos.Api.Log4CS;

namespace OnPlaceMovel.Source.Diadema {
	public class TesteControllerDiadema: TesteController {
		/// <summary>
		/// Retorna false caso a matricula seja filho de uma matricula do tipo comunitario ou fatura composta
		/// </summary>
		/// <param name="matricula"></param>
		/// <returns></returns>
		protected override bool FazerLeitura(OnpMatricula matricula) {
			OnpMatriculaDiadema matd = new OnpMatriculaDiadema(matricula.SeqMatricula.Value);

			// Se for filho de comunitario
			// ou pai de fatura composta nao processar
			if ((matd.MatriculaPai.IndTipoConsumidor == OnpMatriculaDiadema.TipoConsumidor.FaturaComposta8 ||
				matd.MatriculaPai.IndTipoConsumidor == OnpMatriculaDiadema.TipoConsumidor.FaturaComposta3) && !matd.isFilho)
				return false;

			return base.FazerLeitura(matricula);
		}

		/// <summary>
		/// Verifica se a matricula recebida eh um pai de comunitario
		/// </summary>
		/// <param name="s"></param>
		/// <returns>Retorna true se a matricula recebida eh um pai de comunitario</returns>
		private static bool IsPaiComunitario(TstMatricula s) {
			OnpMatriculaDiadema matd = new OnpMatriculaDiadema();
			matd.SeqMatricula = s.SeqMatricula;

			if (!matd.Select())
				return false;

			return matd.IndTipoConsumidor.Equals(OnpMatriculaDiadema.TipoConsumidor.HDComunitario) && !matd.isFilho;
		}

		/// <summary>
		/// Coloca os pais de HDs comunitarios em primeiro na lista
		/// </summary>
		/// <param name="retorno"></param>
		protected override void OrdenarMatriculas(ParametrosTeste retorno) {
			List<TstMatricula> matriculas = new List<TstMatricula>(retorno.Matriculas);
			List<TstMatricula> pais = matriculas.FindAll(IsPaiComunitario);

			matriculas.RemoveAll(IsPaiComunitario);
			matriculas.InsertRange(0, pais);

			matriculas.CopyTo(retorno.Matriculas);
		}

		/// <summary>
		/// Trata casos onde nao se pode imprimir Pai de fatura composta e apartamento
		/// </summary>
		/// <param name="matricula"></param>
		/// <returns></returns>
		protected override bool PodeImprimir(OnpMatricula matricula) {
			OnpMatriculaDiadema matd = new OnpMatriculaDiadema(matricula.SeqMatricula.Value);

			if (matd.IndEmiteFatura.Equals("N"))
				return false;

			if (matd.IndTipoConsumidor.Equals(OnpMatriculaDiadema.TipoConsumidor.HDApartamento) && !matd.MatriculaPai.isFilho)
				return false;

			if (matd.IndTipoConsumidor.Equals(OnpMatriculaDiadema.TipoConsumidor.FaturaComposta3) ||
				matd.IndTipoConsumidor.Equals(OnpMatriculaDiadema.TipoConsumidor.FaturaComposta8)
				&& !matd.MatriculaPai.isFilho)
				return false;

			return base.PodeImprimir(matricula);
		}

		/// <summary>
		/// Imprimi filhos de contas de apartamento e comunitario
		/// </summary>
		/// <param name="imprimirConta">Se for true, vai realmente tentar imprimir a conta. Caso contrario somente simula a impressão.</param>
		/// <param name="matricula"></param>
		protected override void ImprimirConta(bool imprimirConta, OnpMatricula matricula) {
			OnpMatriculaDiadema matd = new OnpMatriculaDiadema(matricula.SeqMatricula.Value);

			// Imprime filhos
			if ((matd.MatriculaPai.IndTipoConsumidor == OnpMatriculaDiadema.TipoConsumidor.HDApartamento && matd.MatriculaPai.LeuTodosFilhos()) ||
				(matd.MatriculaPai.IndTipoConsumidor == OnpMatriculaDiadema.TipoConsumidor.HDComunitario && !matd.isFilho)) {

				foreach (OnpMatriculaDiadema md in matd.MatriculaPai.Filhos) {
					if (PodeImprimir(md.Matricula)) {
						if (matd.IndEmiteFatura.Equals("N"))
							continue;

						if (imprimirConta) {
							ImprimirConta(md.Matricula);
							ImprimiNotificacao(md.Matricula);
						}

						AtribuiValoresImpressao(md.Matricula);
					}
				}
			} else {
				if (PodeImprimir(matricula) && matricula.IndProcessado.Equals("S")) {
					if (matd.IndEmiteFatura.Equals("N"))
						return;

					if (imprimirConta) {
						ImprimirConta(matricula);
						ImprimiNotificacao(matricula);
					}

					// Forçando valores
					matricula.Movimento = null; // Forca recarregar dados do banco de dados
					AtribuiValoresImpressao(matricula);
				}
			}
		}

		/// <summary>
		/// Imprimi o aviso/notificacao de debito para a matricula passada
		/// </summary>
		/// <param name="matricula"></param>
		private void ImprimiNotificacao(OnpMatricula matricula) {
			if (matricula.Aviso != null && matricula.Aviso.FaturasAviso != null)
				if (!_impressao.printAvisoDebito(matricula))
					Log4CS.Error("Não foi possível imprimir aviso de debito da matricula: " + matricula.SeqMatricula);
		}

		/// <summary>
		/// Override para impedir leitura de filhos de comunitarios
		/// </summary>
		/// <param name="matricula"></param>
		/// <returns></returns>
		protected override bool PodeLer(OnpMatricula matricula) {
			OnpMatriculaDiadema matd = new OnpMatriculaDiadema(matricula.SeqMatricula.Value);

			// Nao faz leitura de filhos de comunitarios
			if (matd.MatriculaPai.IndTipoConsumidor == OnpMatriculaDiadema.TipoConsumidor.HDComunitario && matd.isFilho)
				return false;

			return base.PodeLer(matricula);
		}

	}
}

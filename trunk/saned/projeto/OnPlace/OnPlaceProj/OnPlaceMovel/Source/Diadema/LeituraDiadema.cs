using System;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using OnPlaceMovel.Source.Banco;
using OnPlaceMovel.Source.CalculoTaxas;
using OnPlaceMovel.Source.Controladores;
using Strategos.Api.Log4CS;
using OnPlaceMovel.Source.Forms;
using Strategos.Api.Database.Impl;

namespace OnPlaceMovel.Source.Diadema {
	public class LeituraDiadema: LeituraPadrao {
		public LeituraDiadema() {
		}

		#region Metodos Publicos
		public override bool IniciaLeitura(OnpMatricula matricula) {
			// valida a data atual e a data da ultima leitura
			ValidaData(matricula);

			OnpMatriculaDiadema matd = new OnpMatriculaDiadema(matricula.SeqMatricula.Value);
			bool fazerLeitura = true;
			bool pegarOcorrencias = true;
			bool continuarProcessamento = true;
			bool processar = false;
			bool podeSair = false;

			switch (matd.IndTipoConsumidor) {
				case OnpMatriculaDiadema.TipoConsumidor.HDComunitario:
					// REGRA: para HD comunitario nao imprime conta do pai, retorna false
					if (matd.isFilho) {
						if (!matd.MatriculaPai.LeuPai()) {
							MessageBox.Show("Primeiro faça a leitura do pai: " + matd.MatriculaPai.SeqMatricula + "/" + matd.MatriculaPai.Matricula.SeqLeitura);
							return false;
						} else if (!matd.Matricula.IndProcessado.Equals("S")) {
							matricula.Movimento.Processa();
							matricula.IndProcessado = "S";
							podeSair = true; 
							pegarOcorrencias = fazerLeitura = false;
						} else {
							podeSair = true;
							pegarOcorrencias = fazerLeitura = false;
						}
					} else {
						pegarOcorrencias = fazerLeitura = true;
					}
					break;

				case OnpMatriculaDiadema.TipoConsumidor.FaturaComposta3:
				case OnpMatriculaDiadema.TipoConsumidor.FaturaComposta8:
					if (matd.isFilho) {
						if (matricula.Lido()) {
							MessageBox.Show("Matricula filha de fatura composta já lida, não será feita impressão!");
							return false;
						}

						processar = pegarOcorrencias = fazerLeitura = true;
					} else {
						if (matd.getFilhosNaoProcessados() == 0) {
							processar = true;
							pegarOcorrencias = fazerLeitura = false;
						} else {
							MessageBox.Show("Matricula pai de fatura composta, leia os filhos primeiro!");
							return false;
						}
					}
					break;

				case OnpMatriculaDiadema.TipoConsumidor.HDApartamento:
					// Só vai fazer a impressao se tiver lido todo mundo
					continuarProcessamento = matd.MatriculaPai.LeuPai() && matd.MatriculaPai.LeuTodosFilhos();

					// Calculo normal, não precisa fazer nada
					pegarOcorrencias = fazerLeitura = true;
					break;

				case OnpMatriculaDiadema.TipoConsumidor.CaminhaoPipaNF:
					if (!matd.isFilho) {
						podeSair = true;
						continuarProcessamento = pegarOcorrencias = fazerLeitura = processar = false;
						MessageBox.Show("Cadastro nota fiscal, sem leitura.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
					}
					break;

				case OnpMatriculaDiadema.TipoConsumidor.HDPoco:
				case OnpMatriculaDiadema.TipoConsumidor.MedidorEsgoto:
				case OnpMatriculaDiadema.TipoConsumidor.NormalEsgotamentoEspecial:
				case OnpMatriculaDiadema.TipoConsumidor.CaminhaoPipaHD:
				case OnpMatriculaDiadema.TipoConsumidor.Normal:
					// Calculo normal, não precisa fazer nada
					pegarOcorrencias = fazerLeitura = true;
					break;
			}

			// Mensagens
			ProcessarMensagens(matricula, matd);

			if (!matricula.IndProcessado.Equals("S")) {
				AnaliseContaDiadema analiseConta = ConfigXML.GetClasseAnaliseConta() as AnaliseContaDiadema;

				while (!podeSair) {
					bool ocorrenciaComLeitura = false;
					TipoLeitura tl = TipoLeitura.Pode;

					if (pegarOcorrencias) {
						OcorrenciaController ocorrencia = new OcorrenciaController(matricula);

						do {
							ocorrencia.ShowOcorrencia();

							// Caso processo de leitura seja cancelado pelo usuario
							if (ocorrencia.Cancelar) {
								LimpaOcorrencia(matricula);
								return false;
							}
						} while (matricula.Movimento.MovimentosOcorrencia.Count == 0);

						ocorrencia.Dispose();

						if (matricula.Movimento.GetPrimeiraOcorrencia().Ocorrencia.IndLeitura.Equals("N")) {
							ocorrenciaComLeitura = false;
							tl = TipoLeitura.Recusa;
							processar = true;
						} else if (matricula.Movimento.GetPrimeiraOcorrencia().Ocorrencia.IndLeitura.Equals("S")) {
							ocorrenciaComLeitura = true;
							tl = TipoLeitura.Precisa;
						}
					}

					// Pula leitura para matriculas sem hidrometro
					if (matricula.Movimento.Hidrometro != null) {
						if (fazerLeitura) {
							_leitura = ConfigXML.GetLeituraHD();
							_leitura.FazerLeitura(matricula, tl, false);

							_leitura.Dispose();

							if (_leitura.Cancelar) {
								LimpaOcorrencia(matricula);
								return false;
							}

							if (matricula.Movimento.IndSituacaoMovimento.Equals("R"))
								MessageBox.Show(_leitura.MsgRetidaParaAnalise());

							matricula.IndProcessado = "S";
						}
					} else {
						processar = true;
					}

					bool asl = true;

					podeSair =
						(!ocorrenciaComLeitura && !matricula.Movimento.ValLeituraReal.HasValue && (asl = AceitarSemLeitura(tl)) ||
						(ocorrenciaComLeitura && matricula.Movimento.ValLeituraReal.HasValue) ||
						(!matricula.Movimento.ValLeituraReal.HasValue && matricula.Movimento.Hidrometro == null));

					if (!asl)
						matricula.IndProcessado = "N";

					if (!podeSair && asl) {
						if (matricula.Movimento.IndSituacaoMovimento.Equals("P")) {
							MessageBox.Show("Inconsistência entre ocorrência e entrada ou falta de leitura, verifique a ocorrência!");
							matricula.Movimento.ValLeituraReal = null;
							matricula.Movimento.Persist();
							matricula.IndProcessado = "N";
							matricula.Persist();
						} else {
							podeSair = true;
						}
					} else if (podeSair && asl && matricula.Movimento.IndSituacaoMovimento.Equals("P"))
						processar = true;

					ocorrenciaComLeitura = false;
				}

				if (processar || (fazerLeitura && matricula.IndProcessado.Equals("N"))) {
					matricula.Movimento.Processa();
					matricula.IndProcessado = "S";
				}

				matricula.Movimento.CodAgente = Controlador.Agente.CodAgente;
				matricula.Movimento.Persist();
			}

			// Ja vai imprimir a retenção para esta matricula
			// caso ela esteja processada e foi retida
			if (matd.IndTipoConsumidor.Equals(OnpMatriculaDiadema.TipoConsumidor.HDApartamento) && matricula.IndProcessado.Equals("S")) {
				if (matricula.Movimento.IndSituacaoMovimento.Equals("R") && matd.isFilho)
					continuarProcessamento = true;

				if (!matd.MatriculaPai.LeuPai() || !matd.MatriculaPai.LeuTodosFilhos())
					MessageBox.Show("Não será feita impressão. Primeiro é necessário ler o pai e o filhos desta matricula.");
			}

			return continuarProcessamento;
		}

		private static void LimpaOcorrencia(OnpMatricula matricula) {
			int qtdeOcorrencia = matricula.Movimento.MovimentosOcorrencia.Count;
			while (qtdeOcorrencia > 0) {
				qtdeOcorrencia--;
				matricula.Movimento.MovimentosOcorrencia[qtdeOcorrencia].Remove();
			}
            // Limpa Leitura
            matricula.Movimento.ValConsumoAtribuido = null;
            matricula.Movimento.ValConsumoMedido    = null;
            matricula.Movimento.ValLeituraAtribuida = null;
            matricula.Movimento.ValLeituraReal      = null;
            matricula.Movimento.Persist();
        }

		private static bool AceitarSemLeitura(TipoLeitura tl) {
			if (tl == TipoLeitura.Pode || tl == TipoLeitura.Recusa)
				return MessageBox.Show("Confirma processar sem leitura?", "OnPlace", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes;
			else
				return true;
		}
		#endregion // Metodos publicos

		#region Metodos privados
		private void ProcessarMensagens(OnPlaceMovel.Source.Banco.OnpMatricula matricula, OnpMatriculaDiadema matd) {
			if (!string.IsNullOrEmpty(matd.IndCachorro) && matd.IndCachorro.Equals("S"))
				MessageBox.Show("Cuidado! Cão solto no imóvel", "OnPlace", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

			if (matd.ValFraudes.GetValueOrDefault(0) > 0)
				MessageBox.Show("Atenção! Há " + matd.ValFraudes.ToString() + " registros de fraude.", "OnPlace", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

			if (!string.IsNullOrEmpty(matd.DesMensagem1))
				MessageBox.Show(matd.DesMensagem1, "OnPlace", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

			if (!string.IsNullOrEmpty(matd.DesMensagem2))
				MessageBox.Show(matd.DesMensagem2, "OnPlace", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

			bool cortada = false;
			foreach (OnpMovimentoCategoria c in matricula.Movimento.MovimentosCategoria)
				foreach (OnpMovimentoTaxa t in c.Taxas)
					if (t.IndSituacao.Equals("3")) {
						cortada = true;
						break;
					}

			if (cortada && matd.DatBloqueio.HasValue)
				MessageBox.Show("Atenção! Ligação cortada em " + matd.DatBloqueio.Value.ToString("dd/MM/yyyy") , "OnPlace", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

		}
		#endregion // Metodos privados
	}
}

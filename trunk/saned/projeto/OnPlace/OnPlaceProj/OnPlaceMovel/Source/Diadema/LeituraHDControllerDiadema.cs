using System;
using System.Collections.Generic;
using System.Text;
using OnPlaceMovel.Source.Controladores;
using System.Windows.Forms;

namespace OnPlaceMovel.Source.Diadema {
	public class LeituraHDControllerDiadema: LeituraHDControllerPadrao {
		#region Atributos e Propriedades
		private bool _consumoInexpressivoAvisado = false;
		private bool _consumoVariadoAvisado = false;
		private bool _leituraIgualAnteriorAvisado = false;
		private bool _leituraMenorQueAnterior = false;
		private bool _ultimaLeitura = false;

		public override OnPlaceMovel.Source.Banco.OnpMatricula Matricula {
			get {
				return base.Matricula;
			}
			set {
				base.Matricula = value;
				_consumoInexpressivoAvisado = false;
			}
		}

		private OnpMatriculaDiadema matd;

		#endregion // Atributos e Propriedades

		public override bool setLeitura(int leitura) {
			_formLeitura.MostraMensagem("Repita a leitura.");
			if (matd == null) {
				matd = new OnpMatriculaDiadema(_matricula.SeqMatricula.Value);
				matd.Matricula = _matricula;
			}

			if (!_ultimaLeitura) {
				if (_matricula.Movimento.UltimaLeitura != leitura) {
					_leituraIgualAnteriorAvisado = false;
					_consumoInexpressivoAvisado = false;
					_leituraMenorQueAnterior = false;
					_consumoVariadoAvisado = false;
				}

				if ((_matricula.Movimento.ValNumeroLeituras.GetValueOrDefault(0) + 1) >= ConfigXML.GetTentativasLeitura()) {
					_ultimaLeitura = true;
					_formLeitura.MostraMensagem("Última digitação permitida");
				} else if (!_leituraMenorQueAnterior && leitura < _matricula.Movimento.ValLeituraAnterior.GetValueOrDefault(0)) {
					_matricula.Movimento.ValNumeroLeituras = _matricula.Movimento.ValNumeroLeituras.GetValueOrDefault(0) + 1;
					_formLeitura.MostraMensagem("Leit. Atual < Leit. Anterior");
					_leituraIgualAnteriorAvisado = false;
					_consumoInexpressivoAvisado = false;
					_consumoVariadoAvisado = false;
					_leituraMenorQueAnterior = true;
					_matricula.Movimento.UltimaLeitura = leitura;
					return false; // recusa a leitura para forcar entrada de nova leitura
				} else if (!_leituraIgualAnteriorAvisado && leitura == _matricula.Movimento.ValLeituraAnterior) {
					_matricula.Movimento.ValNumeroLeituras = _matricula.Movimento.ValNumeroLeituras.GetValueOrDefault(0) + 1;
                    _formLeitura.MostraMensagem("Consumo Inexpressivo");
					_consumoInexpressivoAvisado = false;
					_leituraMenorQueAnterior = false;
					_consumoVariadoAvisado = false;
					_leituraIgualAnteriorAvisado = true;
					_matricula.Movimento.UltimaLeitura = leitura;
					return false; // recusa a leitura para forcar entrada de nova leitura
				} else {

					// Verifica se ajusta leitura
					bool ajusta = true;
					if (!string.IsNullOrEmpty(matd.IndBloqueio) && matd.IndBloqueio.Equals("S")) {
						ajusta = false;
					} else if (ajusta && (matd.IndTipoConsumidor.Equals("6") || matd.IndTipoConsumidor.Equals("10"))) {
						ajusta = false;
					} else if (matd.Matricula.Movimento.MovimentosOcorrencia.Count > 0) {
						if (matd.Matricula.Movimento.GetPrimeiraOcorrencia().Ocorrencia.IndConsumo.Equals("0") &&
							matd.Matricula.Movimento.GetPrimeiraOcorrencia().Ocorrencia.IndConsumo.Equals("9") &&
							matd.Matricula.Movimento.GetPrimeiraOcorrencia().Ocorrencia.IndConsumo.Equals("10"))
							ajusta = false;
					}

					int totalEconomias = _matricula.Movimento.TotalEconomias();
					if (totalEconomias <= 0)
						totalEconomias = 1;
					int consumoMedio = _matricula.Movimento.ValConsumoMedio.GetValueOrDefault(0);
					int consumoMedido = _matricula.Movimento.calculaConsumoLeitura(leitura, ajusta);
					double consumoPorEco = (consumoMedido / totalEconomias);

					// À pedido do João, comparar o consumo por economia igual a 1
					if (consumoPorEco < 1) {
						consumoPorEco = 1;
					}

					if (!_consumoInexpressivoAvisado && leitura > _matricula.Movimento.ValLeituraAnterior && consumoPorEco <= 3) {
						_matricula.Movimento.ValNumeroLeituras = _matricula.Movimento.ValNumeroLeituras.GetValueOrDefault(0) + 1;
						_formLeitura.MostraMensagem("Consumo Inexpressivo");
						_leituraIgualAnteriorAvisado = false;
						_leituraMenorQueAnterior = false;
						_consumoVariadoAvisado = false;
						_consumoInexpressivoAvisado = true;
						_matricula.Movimento.UltimaLeitura = leitura;
						return false;
					} else if (!_consumoVariadoAvisado) {

						_formLeitura.MostraMensagem("");

						string tipoVariacao = _matricula.Movimento.verificaVariacaoConsumo(consumoMedio, consumoMedido);

						if (tipoVariacao != "SemVariar") {

							if (tipoVariacao == "ExcessoConsumo") {
								_formLeitura.MostraMensagem("Excesso de consumo!");
							} else if (tipoVariacao == "ConsumoAcima") {
								_formLeitura.MostraMensagem("Consumo acima do normal!");
							} else if (tipoVariacao == "ConsumoRedusido") {
								_formLeitura.MostraMensagem("Redução no consumo");
							} else if (tipoVariacao == "ConsumoAbaixo") {
								_formLeitura.MostraMensagem("Consumo abaixo do normal");
							}
							
							_matricula.Movimento.ValNumeroLeituras = _matricula.Movimento.ValNumeroLeituras.GetValueOrDefault(0) + 1;
							_leituraIgualAnteriorAvisado = false;
							_leituraMenorQueAnterior = false;
							_consumoInexpressivoAvisado = false;
							_consumoVariadoAvisado = true;
							_matricula.Movimento.UltimaLeitura = leitura;
							return false;
						}

					}

				}
			}

			bool result = base.setLeitura(leitura);
			if (!result) {
				// Inicializa valores devido o calculo de ajuste e verificação de retenção atualizarem estes dados.
                _matricula.Movimento.ValConsumoAtribuido = null;
				_matricula.Movimento.ValConsumoMedido = null;
				_matricula.Movimento.ValLeituraAtribuida = null;
				_matricula.Movimento.ValLeituraReal = null;
                _matricula.Movimento.Persist();
			}

			return result;
		}
	}
}

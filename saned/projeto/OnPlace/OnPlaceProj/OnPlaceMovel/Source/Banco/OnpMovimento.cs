using System;
using System.Xml;
using System.Text;
using System.Reflection;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using OnPlaceMovel.Source.CalculoTaxas;
using Strategos.Api.Log4CS;
using Strategos.Api.Patterns;
using Strategos.Api.Database.Impl;
using Strategos.Api.Database.Attributes;

namespace OnPlaceMovel.Source.Banco {
	[Table(TableName = "onp_Movimento")]
	public sealed class OnpMovimento: PersistClass<OnpMovimento> {
		#region Atributos e Propriedades
		private int ultimaLeitura = -1;
		public int UltimaLeitura {
			get { return ultimaLeitura; }
			set { ultimaLeitura = value; }
		}

		private string codReferencia;
		[Column(ColumnName = "cod_Referencia", Pk = true)]
		public string CodReferencia {
			get { return codReferencia; }
			set { codReferencia = value; }
		}

		private int? seqMatricula;
		[Column(ColumnName = "seq_Matricula", Pk = true)]
		public int? SeqMatricula {
			get { return seqMatricula; }
			set { seqMatricula = value; }
		}

		private int? seqRoteiro;
		[Column(ColumnName = "seq_Roteiro", Pk = true)]
		public int? SeqRoteiro {
			get { return seqRoteiro; }
			set { seqRoteiro = value; }
		}

		private int? codAgente;
		[Column(ColumnName = "cod_Agente")]
		public int? CodAgente {
			get { return codAgente; }
			set { codAgente = value; }
		}

		private string codHidrometro;
		[Column(ColumnName = "cod_Hidrometro")]
		public string CodHidrometro {
			get { return codHidrometro; }
			set { codHidrometro = value; }
		}

		private int? valLeituraAnterior;
		[Column(ColumnName = "val_Leitura_Anterior")]
		public int? ValLeituraAnterior {
			get { return valLeituraAnterior; }
			set { valLeituraAnterior = value; }
		}

		private int? valLeituraReal;
		[Column(ColumnName = "val_Leitura_Real")]
		public int? ValLeituraReal {
			get { return valLeituraReal; }
			set { valLeituraReal = value; }
		}

		private int? valLeituraAtribuida;
		[Column(ColumnName = "val_Leitura_Atribuida")]
		public int? ValLeituraAtribuida {
			get { return valLeituraAtribuida; }
			set {
				valLeituraAtribuida = value;
				if (valLeituraAtribuida >= LeituraMaxima()) {
					valLeituraAtribuida = valLeituraAtribuida - LeituraMaxima();
				}
			}
		}

		private int? valNumeroLeituras;
		[Column(ColumnName = "val_Numero_Leituras")]
		public int? ValNumeroLeituras {
			get { return valNumeroLeituras; }
			set { valNumeroLeituras = value; }
		}

		private int? valConsumoMedido;
		[Column(ColumnName = "val_Consumo_Medido")]
		public int? ValConsumoMedido {
			get { return valConsumoMedido; }
			set { valConsumoMedido = value; }
		}

		private int? valConsumoMedio;
		[Column(ColumnName = "val_Consumo_Medio")]
		public int? ValConsumoMedio {
			get { return valConsumoMedio; }
			set { valConsumoMedio = value; }
		}

		private int? valConsumoAtribuido;
		[Column(ColumnName = "val_Consumo_Atribuido")]
		public int? ValConsumoAtribuido {
			get { return valConsumoAtribuido; }
			set { valConsumoAtribuido = value; }
		}

		private int? valConsumoTroca;
		[Column(ColumnName = "val_Consumo_Troca")]
		public int? ValConsumoTroca {
			get { return valConsumoTroca; }
			set { valConsumoTroca = value; }
		}

		private int? valConsumoRateado;
		[Column(ColumnName = "val_Consumo_Rateado")]
		public int? ValConsumoRateado {
			get { return valConsumoRateado; }
			set { valConsumoRateado = value; }
		}

		private int? valImpressoes;
		[Column(ColumnName = "val_Impressoes")]
		public int? ValImpressoes {
			get { return valImpressoes; }
			set { valImpressoes = value; }
		}

		private string desBancoDebito;
		[Column(ColumnName = "des_Banco_Debito")]
		public string DesBancoDebito {
			get { return desBancoDebito; }
			set { desBancoDebito = value; }
		}

		private string desBancoAgenciaDebito;
		[Column(ColumnName = "des_Banco_Agencia_Debito")]
		public string DesBancoAgenciaDebito {
			get { return desBancoAgenciaDebito; }
			set { desBancoAgenciaDebito = value; }
		}

		private string indLeituraDivergente;
		[Column(ColumnName = "ind_Leitura_Divergente")]
		public string IndLeituraDivergente {
			get { return indLeituraDivergente; }
			set { indLeituraDivergente = value; }
		}

		private int? seqTipoEntrega;
		[Column(ColumnName = "seq_Tipo_Entrega")]
		public int? SeqTipoEntrega {
			get { return seqTipoEntrega; }
			set { seqTipoEntrega = value; }
		}

		private DateTime? datVencimento;
		[Column(ColumnName = "dat_Vencimento")]
		public DateTime? DatVencimento {
			get { return datVencimento; }
			set { datVencimento = value; }
		}

		private DateTime? datLeituraAnterior;
		[Column(ColumnName = "dat_Leitura_Anterior")]
		public DateTime? DatLeituraAnterior {
			get { return datLeituraAnterior; }
			set { datLeituraAnterior = value; }
		}

		private DateTime? datLeitura;
		[Column(ColumnName = "dat_Leitura")]
		public DateTime? DatLeitura {
			get { return datLeitura; }
			set { datLeitura = value; }
		}

		private string indEntregaEspecial;
		[Column(ColumnName = "ind_Entrega_Especial")]
		public string IndEntregaEspecial {
			get { return indEntregaEspecial; }
			set { indEntregaEspecial = value; }
		}

		private int? valQuantidadePendente;
		[Column(ColumnName = "val_Quantidade_Pendente")]
		public int? ValQuantidadePendente {
			get { return valQuantidadePendente; }
			set { valQuantidadePendente = value; }
		}

		private double? valDesconto;
		[Column(ColumnName = "val_Desconto")]
		public double? ValDesconto {
			get { return valDesconto; }
			set { valDesconto = value; }
		}

		private string indMotivoRetirada;
		[Column(ColumnName = "ind_Motivo_Retirada")]
		public string IndMotivoRetirada {
			get { return indMotivoRetirada; }
			set { indMotivoRetirada = value; }
		}

		private DateTime? datTroca;
		[Column(ColumnName = "dat_Troca")]
		public DateTime? DatTroca {
			get { return datTroca; }
			set { datTroca = value; }
		}

		private string indSituacaoMovimento;
		[Column(ColumnName = "ind_Situacao_Movimento")]
		public string IndSituacaoMovimento {
			get { return indSituacaoMovimento; }
			set { indSituacaoMovimento = value; }
		}

		private DateTime? datProximaLeitura;
		[Column(ColumnName = "dat_Proxima_Leitura")]
		public DateTime? DatProximaLeitura {
			get { return datProximaLeitura; }
			set { datProximaLeitura = value; }
		}

		private string indFaturaEmitida;
		[Column(ColumnName = "ind_Fatura_Emitida")]
		public string IndFaturaEmitida {
			get { return indFaturaEmitida; }
			set { indFaturaEmitida = value; }
		}

		private double? valArredondaAnterior;
		[Column(ColumnName = "val_Arredonda_Anterior")]
		public double? ValArredondaAnterior {
			get { return valArredondaAnterior; }
			set { valArredondaAnterior = value; }
		}

		private bool lancaMinimoNasTaxas;
		public bool LancaMinimoNasTaxas {
			get { return lancaMinimoNasTaxas; }
			set { lancaMinimoNasTaxas = value; }
		}

		private OnpMatricula matricula;
		public OnpMatricula Matricula {
			get {
				if (matricula == null)
					matricula = new OnpMatricula(this.seqMatricula.Value);

				return matricula;
			}
		}

		private OnpRoteiro roteiro;
		public OnpRoteiro Roteiro {
			get {
				if (roteiro == null)
					roteiro = new OnpRoteiro(this.seqRoteiro);

				return roteiro;
			}
		}

		private OnpFatura fatura;
		public OnpFatura Fatura {
			get {
				if (fatura == null) {
					fatura = new OnpFatura();

					fatura.SeqMatricula = seqMatricula;
					fatura.CodReferencia = codReferencia;
					fatura.SeqRoteiro = seqRoteiro;

					if (!fatura.Select())
						fatura = null;
				}

				return fatura;
			}
			set {
				fatura = value;
			}
		}

		private OnpHidrometro hidrometro;
		public OnpHidrometro Hidrometro {
			get {
				if (hidrometro == null) {
					hidrometro = new OnpHidrometro();

					hidrometro.CodHidrometro = this.codHidrometro;
					hidrometro.SeqMatricula = this.seqMatricula.Value;

					if (!hidrometro.Select())
						hidrometro = null;
				}

				return hidrometro;
			}
		}

		private Collection<OnpServicoFatura> servicosFatura;
		public Collection<OnpServicoFatura> ServicosFatura {
			get {
				if (servicosFatura == null) {
					OnpServicoFatura sfFiltro = new OnpServicoFatura();
					sfFiltro.SeqMatricula = this.seqMatricula;
					sfFiltro.CodReferencia = this.codReferencia;
					sfFiltro.SeqRoteiro = this.seqRoteiro;
					servicosFatura = sfFiltro.SelectCollection();
				}

				return servicosFatura;
			}
		}

		private Collection<OnpFatura> segundasVias;
		public Collection<OnpFatura> SegundasVias {
			get {
				if (segundasVias == null) {
					OnpReferenciaPendente refFiltro = new OnpReferenciaPendente();
					refFiltro.SeqMatricula = this.seqMatricula;

					Collection<OnpReferenciaPendente> refsPendentes = refFiltro.SelectCollection();

					segundasVias = new Collection<OnpFatura>();

					OnpFatura fat;
					foreach (OnpReferenciaPendente rp in refsPendentes) {
						fat = new OnpFatura();
						fat.SeqFatura = rp.SeqFatura;
						fat.Select();
						segundasVias.Add(fat);
					}
				}

				return segundasVias;
			}
		}

		private Collection<OnpMovimentoCategoria> movimentosCategoria;
		public Collection<OnpMovimentoCategoria> MovimentosCategoria {
			get {
				if (movimentosCategoria == null) {
					OnpMovimentoCategoria filtro = new OnpMovimentoCategoria();
					filtro.SeqMatricula = this.seqMatricula;
					filtro.CodReferencia = this.codReferencia;
					filtro.SeqRoteiro = this.seqRoteiro;
					movimentosCategoria = filtro.SelectCollection();
				}

				return movimentosCategoria;
			}
		}

		private Collection<OnpMovimentoOcorrencia> movimentosOcorrencia;
		public Collection<OnpMovimentoOcorrencia> MovimentosOcorrencia {
			get {
				if (movimentosOcorrencia == null) {
					OnpMovimentoOcorrencia filtro = new OnpMovimentoOcorrencia();
					filtro.CodReferencia = this.CodReferencia;
					filtro.SeqMatricula = this.SeqMatricula;
					filtro.SeqRoteiro = this.seqRoteiro;
					movimentosOcorrencia = filtro.SelectCollection();
				}

				return movimentosOcorrencia;
			}
		}

		#endregion // Atributos e Propriedades

		public OnpMovimento() {
			lancaMinimoNasTaxas = false;
		}

		public OnpMovimento(string codReferencia, int seqMatricula, int seqRoteiro)
			: this() {
			this.codReferencia = codReferencia;
			this.seqMatricula = seqMatricula;
			this.seqRoteiro = seqRoteiro;

			Materialize();
		}

		#region Metodos publicos
		/// <summary>
		/// Reseta a ultima leitura para -1
		/// </summary>
		public void resetLeitura() {
			ultimaLeitura = -1;
		}

		/// <summary>
		/// Verifica se há ocorrencias que não permite impressao
		/// </summary>
		/// <returns>Retorna true se pode imprimir ou false caso nao possa.</returns>
		public bool Imprime() {
			if (MovimentosOcorrencia.Count > 0)
				if (GetPrimeiraOcorrencia().Ocorrencia.IndEmite.Equals("N"))
					return false;

			return true;
		}

		/// <sumary>
		/// Calcula o numero total de economias das categorias
		/// </sumary>
		/// <returns>inteiro com o total de economias</returns>
		public int TotalEconomias() {
			int result = 0;

			foreach (OnpMovimentoCategoria categoria in MovimentosCategoria)
				result += categoria.ValNumeroEconomia.Value;

			return result;
		}

		/// <summary>
		/// Pega a primeira ocorrencia registrada
		/// </summary>
		/// <returns>Retorna a ocorrencia com sequencial 1 ou nulo caso nao tenha</returns>
		public OnpMovimentoOcorrencia GetPrimeiraOcorrencia() {
			foreach (OnpMovimentoOcorrencia omo in MovimentosOcorrencia)
				if (omo.SeqSequencial.Value == 1)
					return omo;

			return null;
		}
		#endregion // Metodos publicos

		#region Processa a leitura
		/// <summary>
		/// Processa a leitura
		/// </summary>
		/// <param name="leitura"></param>
		/// <returns>Retorna false caso deva realizar mais uma leitura</returns>
		public bool ProcessaLeitura(int leitura) {
			// Resultado default
			bool result = false;

			// Calcula o consumo
			int consumo = calculaConsumoLeitura(leitura);

			// Numero de tentativas
			if (ValNumeroLeituras.HasValue)
				ValNumeroLeituras = ValNumeroLeituras + 1;
			else
				ValNumeroLeituras = 1;

			if (string.IsNullOrEmpty(IndLeituraDivergente) || IndLeituraDivergente.Equals("N"))
				IndLeituraDivergente = (ultimaLeitura != -1 && ultimaLeitura != leitura ? "S" : "N");

			Persist();

			// Caso o consumo esteja ok (Mesmo que leitura atual divergente da anterior
			// Ou a ultima leitura seja igual a atual
			// Ou seja o limite de leituras
			if (!VerificaAlteracaoConsumo(consumo, leitura) ||
				 ultimaLeitura == leitura ||
				 ValNumeroLeituras > ConfigXML.GetTentativasLeitura()) {
				ultimaLeitura = -1;

				ValLeituraReal = leitura;
				ValConsumoMedido = consumo;
				DatLeitura = DateTime.Now;
				IndSituacaoMovimento = "L"; // Lido

				result = true;

				Processa();
			} else {
				// Guarda o valor da leitura
				ultimaLeitura = leitura;
			}

			// Retorno do metodo
			return result;
		}

		/// <summary>
		/// Processa o movimento e gera a fatura
		/// </summary>
		public void Processa() {
			if (!DatLeitura.HasValue)
				DatLeitura = DateTime.Now;

			if (IndSituacaoMovimento.Equals("P") || IndSituacaoMovimento.Equals("L"))
				IndSituacaoMovimento = "C";

			if (!ConfigXML.GetClasseAnaliseConta().RetemParaAnalise(this)) { // Caso nao deva reter a conta 
				geraFatura(); // Gera a fatura
			} else {
				calculaConsumoFatura(TipoCalculoConsumo());
			}

			Matricula.Persist();
			Persist();
		}

		/// <summary>
		/// Verifica se tem alguma ocorrencia que nao permita a emissao da fatura
		/// </summary>
		/// <returns>Retorna true se nao deve emitir, caso contrario retorna false.</returns>
		public bool naoEmitePorOcorrencia() {
			if (MovimentosOcorrencia.Count > 0) {
				// Caso a ocorrencia nao emita fatura
				if (GetPrimeiraOcorrencia().Ocorrencia.IndEmite.Equals("N"))
					return true;

				// Caso especial de calculo e retenção
				if (GetPrimeiraOcorrencia().Ocorrencia.TipoCalculoConsumo == OnpOcorrencia.CalculoConsumo.SeMediaZeroCobraMinimoSenaoRetem && ValConsumoMedio.Value > 0)
					return true;
			}

			return false;
		}
		#endregion

		#region Calculo do consumo
		/// <summary>
		/// Calcula o consumo
		/// </summary>
		/// <param name="leitura">Leitura</param>
		/// <returns>Retorna o calculo do consumo.</returns>
		public int calculaConsumoLeitura(int leitura) {
			return calculaConsumoLeitura(leitura, false);
		}

		/// <summary>
		/// Calcula o consumo
		/// </summary>
		/// <param name="leitura">Leitura</param>
		/// <param name="ajusta">Ajuste de leitura proporcional aos dias de consumo, caso necessario</param>
		/// <returns>Retorna o calculo do consumo.</returns>
		public int calculaConsumoLeitura(int leitura, bool ajusta) {
			ICalculoConsumo cc = ConfigXML.GetCalculoConsumo();
			return cc.CalculaConsumo(this, leitura, ajusta);
		}

		/// <summary>
		/// Leitura maxima que o hidrometro associado permite, se nao tiver hidrometro usa 4 digitos como padrao
		/// </summary>
		/// <returns>Retorna o valor da leitura maxima</returns>
		public int LeituraMaxima() {
			int digitos = 4;

			if (Hidrometro != null && Hidrometro.ValNumeroDigitos.HasValue)
				digitos = Hidrometro.ValNumeroDigitos.Value;

			return (int)System.Math.Pow(10, digitos);
		}

		/// <summary>
		/// Verifica alteracao de consumo
		/// </summary>
		/// <returns>Retorna true se deve reter ou emitir aviso</returns>
		public bool VerificaAlteracaoConsumo(int consumo, int leitura) {
			bool result = false;

			IAnaliseConta analiseConta = ConfigXML.GetClasseAnaliseConta();

			//Calcula retencao apenas para quem tem media
			if (ValConsumoMedio.HasValue && consumo != ValConsumoMedio) {
				int? consumoSalvo = ValConsumoMedido;
				int? leituraSalva = ValLeituraReal;
				string situacao = IndSituacaoMovimento;
				string processado = this.Matricula.IndProcessado;

				ValLeituraReal = leitura;
				ValConsumoMedido = consumo;
				IndSituacaoMovimento = "C"; // Calculado, pois o RetemParaAnalise() só processa matriculas com consumo calculado
				Matricula.IndProcessado = "S";
				Persist();

				result = analiseConta.RetemParaAnalise(this) || analiseConta.EmiteAvisoVariacao(this.Matricula);

				ValLeituraReal = leituraSalva;
				ValConsumoMedido = consumoSalvo;
				if (IndSituacaoMovimento.Equals("R")) // Restaura o estado caso o RetemParaAnalise nao tenha mudado para "R"
					IndSituacaoMovimento = situacao;
				Matricula.IndProcessado = processado;
				Persist();
			}

			return result;
		}

		/// <summary>
		/// Verifica se há uma ocorrência que obrigue a retenção para analise
		/// </summary>
		/// <returns>OnpOcorrencia</returns>
		public OnpOcorrencia ocorrenciaRetemAnalise() {
			OnpOcorrencia result = null;

			// Verifica as ocorrencias
			if (MovimentosOcorrencia.Count > 0) {
				OnpMovimentoOcorrencia mo = GetPrimeiraOcorrencia();
				if (mo.Ocorrencia.IndEmite.Equals("R"))
					result = mo.Ocorrencia;
			}

			return result;
		}

		/// <summary>
		/// Tipo de calculo do consumo
		/// </summary>
		/// <returns></returns>
		public OnpOcorrencia.CalculoConsumo TipoCalculoConsumo() {
			OnpOcorrencia.CalculoConsumo result = OnpOcorrencia.CalculoConsumo.LeituraInformada;

			// Verifica as ocorrencias
			int ocoConsumo, resConsumo;
			if (MovimentosOcorrencia.Count > 0) {
				OnpMovimentoOcorrencia mo = GetPrimeiraOcorrencia();

				ocoConsumo = int.Parse(mo.Ocorrencia.IndConsumo);
				resConsumo = (int)result;

				if (ocoConsumo > resConsumo)
					result = mo.Ocorrencia.TipoCalculoConsumo;
			}

			return result;
		}
		#endregion

		#region Calculo da fatura
		/// <summary>
		/// Gera a fatura para o movimento
		/// </summary>
		private void CalcularFatura(bool distribuirConsumo) {
			// Faz o calculo
			ICalculaTaxas calculoTaxas = ConfigXML.GetClasseCalculoTaxas();
			calculoTaxas.LancaMinimoNasTaxas = lancaMinimoNasTaxas;
			calculoTaxas.Calcular(this, distribuirConsumo);
		}

		/// <summary>
		/// Gera a fatura para o movimento
		/// </summary>
		private void geraFatura() {
			OnpOcorrencia.CalculoConsumo cc = TipoCalculoConsumo();
			if (cc != OnpOcorrencia.CalculoConsumo.NaoGeraFatura) {
				bool distribuiConsumo = calculaConsumoFatura(cc);
				CalcularFatura(distribuiConsumo);
			} else {
				indSituacaoMovimento = "N"; // Não faturar
				Matricula.IndProcessado = "S";
			}
		}

		/// <sumary>
		/// Calcula o numero total de economias das categorias
		/// </sumary>
		/// <returns>Retorna o numero de economias calculado ou zero caso nao tenha nenhuma economias para o movimento em questão.</returns>
		public int GetTotalEconomias() {
			int result = 0;

			foreach (OnpMovimentoCategoria categoria in this.MovimentosCategoria)
				result += categoria.ValNumeroEconomia.Value;

			return result;
		}

		/// <summary>
		/// Calcula o consumo a ser distribuido
		/// </summary>
		/// <returns>Retorna true caso deve ter distribuicao do consumo, caso contrário retorna false.</returns>
		private bool calculaConsumoFatura(OnpOcorrencia.CalculoConsumo cc) {
			bool retorno = true;
			lancaMinimoNasTaxas = false;

			//Forma de calculo do consumo
			switch (cc) {
				case OnpOcorrencia.CalculoConsumo.LeituraInformada:
					calculaConsumoLeituraInformada();

					// Para que o consumo nas taxas nao fique menor que o minimo
					// sera lancado o minimo nas taxas
					int consumoMinimo = AchaConsumoParaMinimo() * GetTotalEconomias();
					if (valConsumoMedido < consumoMinimo)
						lancaMinimoNasTaxas = true;
					break;

				case OnpOcorrencia.CalculoConsumo.LeituraAnteriorMaisMedia:
					valConsumoAtribuido = valConsumoMedio;
					valLeituraAtribuida = valLeituraAnterior.Value + valConsumoAtribuido;
					valLeituraAtribuida = VerificaLeitura(valLeituraAtribuida.Value);
					break;

				case OnpOcorrencia.CalculoConsumo.LeituraAnteriorMaisMinimo:
					valConsumoAtribuido = AchaConsumoParaMinimo() * GetTotalEconomias();
					valLeituraAtribuida = valLeituraAnterior.Value + valConsumoAtribuido;
					valLeituraAtribuida = VerificaLeitura(valLeituraAtribuida.Value);
					lancaMinimoNasTaxas = true;
					break;

				case OnpOcorrencia.CalculoConsumo.RepeteLeituraCobraMinimo:
					valConsumoAtribuido = AchaConsumoParaMinimo() * GetTotalEconomias();
					valLeituraAtribuida = valLeituraAnterior;
					lancaMinimoNasTaxas = true;
					break;

				case OnpOcorrencia.CalculoConsumo.RepeteLeituraCobraMedia:
					valConsumoAtribuido = valConsumoMedio;
					valLeituraAtribuida = valLeituraAnterior;
					break;

				case OnpOcorrencia.CalculoConsumo.LeituraInformadaCobraMedia:
					valConsumoAtribuido = valConsumoMedio;
					break;

				case OnpOcorrencia.CalculoConsumo.LeituraInformadaCobraMinimo:
					valConsumoAtribuido = AchaConsumoParaMinimo() * GetTotalEconomias();
					lancaMinimoNasTaxas = true;
					break;

				case OnpOcorrencia.CalculoConsumo.NaoTemLeituraCobraMedia:
					if (!valLeituraReal.HasValue) {
						valConsumoAtribuido = valConsumoMedio;
						valLeituraAtribuida = valLeituraAnterior + valConsumoAtribuido;
						valLeituraAtribuida = VerificaLeitura(valLeituraAtribuida.Value);
					}
					break;

				case OnpOcorrencia.CalculoConsumo.NaoTemLeituraCobraMinimo:
					if (!valLeituraReal.HasValue) {
						valConsumoAtribuido = AchaConsumoParaMinimo() * GetTotalEconomias();
						valLeituraAtribuida = valLeituraAnterior;
						lancaMinimoNasTaxas = true;
					}
					break;

				case OnpOcorrencia.CalculoConsumo.SeMediaZeroCobraMinimoSenaoRetem:
					if (valConsumoMedio.HasValue && ValConsumoMedio.Value == 0) {
						valConsumoAtribuido = AchaConsumoParaMinimo() * GetTotalEconomias();
						valLeituraAtribuida = valLeituraAnterior;
						lancaMinimoNasTaxas = true;
					}
					break;

				case OnpOcorrencia.CalculoConsumo.NaoGeraFatura:
					// Nao faz calculo de consumo
					retorno = false;
					break;
			}



			Persist();

			return retorno;
		}

		/// <summary>
		/// Verifica se a leitura nao passou do valor maximo do hidrometro da ligacao, caso a ligacao nao tenha hidrometro usa 4 digitos
		/// </summary>
		/// <param name="valLeituraAtribuida"></param>
		/// <returns></returns>
		private int VerificaLeitura(int leitura) {
			int digitos = 4;

			if (Hidrometro != null)
				digitos = Hidrometro.ValNumeroDigitos.GetValueOrDefault(4);

			if (leitura >= Math.Pow(10, digitos))
				return leitura - (int)Math.Pow(10, digitos);

			return leitura;
		}

		/// <summary>
		/// Calculo o valor do consumo para quando fatura por minimo
		/// </summary>
		/// <returns></returns>
		private int AchaConsumoParaMinimo() {
			int result = 0;
			int minimo = 0;

			foreach (OnpMovimentoCategoria mc in MovimentosCategoria) {
				foreach (OnpMovimentoTaxa mt in mc.Taxas) {
					minimo = QueriesCE.ConsumoMinimo(mt.SeqTaxa.Value, mt.SeqCategoria.Value, Roteiro.DatBase.Value);
					if (minimo > 0) {
						result = minimo;
						break;
					}
				}
			}

			return result;
		}

		/// <summary>
		/// Calcula o consumo - Leitura Informada
		/// </summary>
		private void calculaConsumoLeituraInformada() {
			ICalculoConsumo cc = ConfigXML.GetCalculoConsumo();
			// Se ja foi calculado retorna
			if (valLeituraReal.HasValue && cc.PodeCalcular(this))
				valConsumoMedido = calculaConsumoLeitura(valLeituraReal.Value);
		}

		/// <sumary>
		/// Calcula a variação de consumo e identifica se deve reter
		/// </sumary>
		public string verificaVariacaoConsumo(int consumoMedio, int consumoMedido) { 
			string retorno = "SemVariar";

			// Calcula Variação
			string indVariacaoPositiva = (consumoMedido > consumoMedio ? "A" : "D");
			double? paramAviso = -1;
			double? paramRetem = -1;
			int variacaoConsumo = (int)(consumoMedido > consumoMedio ? (consumoMedido - consumoMedio) : (consumoMedio - consumoMedido));
			double variacaoPercentual = 0;
			if (consumoMedio == 0)
				variacaoPercentual = (variacaoConsumo * 100.0);
			else
				variacaoPercentual = ((double)variacaoConsumo / consumoMedio) * 100.0;

			// Parametros de retencao para a categoria em questao para o consumo calculado			
			OnpParametroRetencao filtro = new OnpParametroRetencao();
			filtro.IndRetencao = indVariacaoPositiva;

			Collection<OnpParametroRetencao> parametros = filtro.SelectCollection();

			foreach (OnpParametroRetencao parametro in parametros) {
				if (parametro.ValMediaInicial.HasValue && parametro.ValMediaFinal.HasValue) {
					// Caso o consumo esteja no intervalo do parametro
					if (consumoMedido > parametro.ValMediaInicial.Value && consumoMedido <= parametro.ValMediaFinal.Value) {
						paramAviso = parametro.ValVariacaoAviso;
						paramRetem = parametro.ValVariacaoRetencao;
						break;
					}
				}
			}

			if (indVariacaoPositiva == "A" && variacaoPercentual >= paramRetem && paramRetem > 0) {
				retorno = "ExcessoConsumo";
			} else if (indVariacaoPositiva == "D" && variacaoPercentual >= paramRetem && paramRetem > 0) {
				retorno = "ConsumoRedusido";
			} else if (indVariacaoPositiva == "A" && variacaoPercentual >= paramAviso && paramAviso > 0) {
				retorno = "ConsumoAcima";
			} else if (indVariacaoPositiva == "D" && variacaoPercentual >= paramAviso && paramAviso > 0) {
				retorno = "ConsumoAbaixo";
			}

			return retorno;
		}

		#endregion
	}
}

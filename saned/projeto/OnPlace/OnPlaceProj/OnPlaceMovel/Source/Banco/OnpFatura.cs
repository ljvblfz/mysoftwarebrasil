using System;
using System.Text;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Strategos.Api.Database.Impl;
using Strategos.Api.Database.Attributes;

namespace OnPlaceMovel.Source.Banco {
    [Table(TableName = "onp_Fatura")]
	public sealed class OnpFatura: PersistClass<OnpFatura> {
		#region Atributos
		private int? seqFatura;
		private int? seqMatricula;
		private string codReferencia;
		private int? seqRoteiro;
		private int? seqTipoEntrega;
		private string indFaturaEmitida;
		private DateTime? datVencimento;
		private double? valArredondaAnterior;
		private double? valArredondaAtual;
		private DateTime? datHoraEmissao;
		private double? valValorFaturado;
		private DateTime? datLeitura;
		private DateTime? datLeituraAnterior;
		private DateTime? datProximaLeitura;
		private string indEntregaEspecial;
		private string desBancoDebito;
		private string desBancoAgenciaDebito;
		private int? valQuantidadePendente;
		private double? valDesconto;
		private string desCodigoBarras;
		private string desLinhaDigitavel;
		private int? valConsumoMedio;
		private int? valConsumoMedido;
		private int? valLeituraReal;
		private int? valLeituraAtribuida;
		private int? valLeituraAnterior;
		private int? valImpressoes;
		private string codHidrometro;
		private int? valConsumoAtribuido;
		private double? valValorCredito;
		private int? valConsumoRateado;

		private OnpMovimento movimento;
		private OnpMatricula matricula;
		private Collection<OnpFaturaCategoria> categorias;
		private Collection<OnpFaturaServico> servicos;
		#endregion

		#region Getters ans Setters (Fields)
        [Column(ColumnName = "seq_Fatura", Pk = true)]
		public int? SeqFatura {
			get { return seqFatura; }
			set { seqFatura = value; }
		}
        [Column(ColumnName = "seq_Matricula", Pk = true)]
		public int? SeqMatricula {
			get { return seqMatricula; }
			set { seqMatricula = value; }
		}
        [Column(ColumnName = "cod_Referencia", Pk = true)]
		public string CodReferencia {
			get { return codReferencia; }
			set { codReferencia = value; }
		}
        [Column(ColumnName = "seq_Roteiro", Pk = true)]
		public int? SeqRoteiro {
			get { return seqRoteiro; }
			set { seqRoteiro = value; }
		}
        [Column(ColumnName = "ind_Fatura_Emitida")]
		public string IndFaturaEmitida {
			get { return indFaturaEmitida; }
			set { indFaturaEmitida = value; }
		}
        [Column(ColumnName = "seq_Tipo_Entrega")]
		public int? SeqTipoEntrega {
			get { return seqTipoEntrega; }
			set { seqTipoEntrega = value; }
		}
        [Column(ColumnName = "dat_Vencimento")]
		public DateTime? DatVencimento {
			get { return datVencimento; }
			set { datVencimento = value; }
		}
        [Column(ColumnName = "val_Arredonda_Anterior")]
		public double? ValArredondaAnterior {
			get { return valArredondaAnterior; }
			set { valArredondaAnterior = value; }
		}
        [Column(ColumnName = "val_Arredonda_Atual")]
		public double? ValArredondaAtual {
			get { return valArredondaAtual; }
			set { valArredondaAtual = value; }
		}
        [Column(ColumnName = "dat_Hora_Emissao")]
		public DateTime? DatHoraEmissao {
			get { return datHoraEmissao; }
			set { datHoraEmissao = value; }
		}
        [Column(ColumnName = "val_Valor_Faturado")]
		public double? ValValorFaturado {
			get { return valValorFaturado; }
			set { valValorFaturado = value; }
		}
        [Column(ColumnName = "dat_Leitura")]
		public DateTime? DatLeitura {
			get { return datLeitura; }
			set { datLeitura = value; }
		}
        [Column(ColumnName = "dat_Leitura_Anterior")]
		public DateTime? DatLeituraAnterior {
			get { return datLeituraAnterior; }
			set { datLeituraAnterior = value; }
		}
        [Column(ColumnName = "dat_Proxima_Leitura")]
		public DateTime? DatProximaLeitura {
			get { return datProximaLeitura; }
			set { datProximaLeitura = value; }
		}
        [Column(ColumnName = "ind_Entrega_Especial")]
		public string IndEntregaEspecial {
			get { return indEntregaEspecial; }
			set { indEntregaEspecial = value; }
		}
        [Column(ColumnName = "des_Banco_Debito")]
		public string DesBancoDebito {
			get { return desBancoDebito; }
			set { desBancoDebito = value; }
		}
        [Column(ColumnName = "des_Banco_Agencia_Debito")]
		public string DesBancoAgenciaDebito {
			get { return desBancoAgenciaDebito; }
			set { desBancoAgenciaDebito = value; }
		}
        [Column(ColumnName = "val_Quantidade_Pendente")]
		public int? ValQuantidadePendente {
			get { return valQuantidadePendente; }
			set { valQuantidadePendente = value; }
		}
        [Column(ColumnName = "val_Desconto")]
		public double? ValDesconto {
			get { return valDesconto; }
			set { valDesconto = value; }
		}
        [Column(ColumnName = "des_Codigo_Barras")]
		public string DesCodigoBarras {
			get { return desCodigoBarras; }
			set { desCodigoBarras = value; }
		}
        [Column(ColumnName = "des_Linha_Digitavel")]
		public string DesLinhaDigitavel {
			get { return desLinhaDigitavel; }
			set { desLinhaDigitavel = value; }
		}
        [Column(ColumnName = "val_Consumo_Medio" )]
		public int? ValConsumoMedio {
			get { return valConsumoMedio; }
			set { valConsumoMedio = value; }
		}
        [Column(ColumnName = "val_Consumo_Medido")]
		public int? ValConsumoMedido {
			get { return valConsumoMedido; }
			set { valConsumoMedido = value; }
		}
        [Column(ColumnName = "val_Consumo_Rateado")]
		public int? ValConsumoRateado {
			get { return valConsumoRateado; }
			set { valConsumoRateado = value; }
		}
        [Column(ColumnName = "val_Leitura_Atribuida")]
		public int? ValLeituraAtribuida {
			get { return valLeituraAtribuida; }
			set { valLeituraAtribuida = value; }
		}
        [Column(ColumnName = "val_Leitura_Anterior")]
		public int? ValLeituraAnterior {
			get { return valLeituraAnterior; }
			set { valLeituraAnterior = value; }
		}
        [Column(ColumnName = "val_Leitura_Real")]
		public int? ValLeituraReal {
			get { return valLeituraReal; }
			set { valLeituraReal = value; }
		}
        [Column(ColumnName = "val_Impressoes")]
		public int? ValImpressoes {
			get { return valImpressoes; }
			set { valImpressoes = value; }
		}
        [Column(ColumnName = "cod_Hidrometro")]
		public string CodHidrometro {
			get { return codHidrometro; }
			set { codHidrometro = value; }
		}
        [Column(ColumnName = "val_Consumo_Atribuido")]
		public int? ValConsumoAtribuido {
			get { return valConsumoAtribuido; }
			set { valConsumoAtribuido = value; }
		}
        [Column(ColumnName = "val_Valor_Credito")]
		public double? ValValorCredito {
			get { return valValorCredito; }
			set { valValorCredito = value; }
		}

		public OnpMovimento Movimento {
			get {
				if (movimento == null) {
					movimento = Matricula.Movimento;
				}
				return movimento;
			}
			set { movimento = value; }
		}

		public Collection<OnpFaturaCategoria> Categorias {
			get {
				if (categorias == null) {
					OnpFaturaCategoria aux = new OnpFaturaCategoria();
					aux.SeqFatura = this.seqFatura;
					aux.SeqMatricula = this.seqMatricula;
					aux.SeqRoteiro = this.seqRoteiro;
					aux.CodReferencia = this.codReferencia;
					categorias = aux.SelectCollection();
				}

				return categorias;
			}
		}

		public Collection<OnpFaturaServico> Servicos {
			get {
				if (servicos == null) {
					OnpFaturaServico aux = new OnpFaturaServico();
					aux.SeqFatura = this.seqFatura;
					aux.SeqMatricula = this.seqMatricula;
					aux.SeqRoteiro = this.seqRoteiro;
					aux.CodReferencia = this.codReferencia;
					servicos = aux.SelectCollection();
				}

				return servicos;
			}
		}
		public OnpMatricula Matricula {
			get {
				if (matricula == null)
					matricula = OnpMatricula.Materialize(this.SeqMatricula.Value);
				return matricula;
			}
			set { matricula = value; }
		}

		#endregion

		#region Metodos publicos
		public static OnpFatura Materialize(int seqMatricula, string codReferencia, int seqRoteiro, int seqFatura) {
			OnpFatura result = new OnpFatura();
			result.seqMatricula = seqMatricula;
			result.codReferencia = codReferencia;
			result.seqRoteiro = seqRoteiro;
			result.seqFatura = seqFatura;

			if (!result.Select())
				result = null;

			return result;
		}

		/// <summary>
		/// Localiza o tipo de consumo
		/// </summary>
		/// <returns></returns>
		public string TipoConsumo() {
			string result = "Normal";

			foreach (OnpFaturaCategoria fatCategoria in Categorias) {
				foreach (OnpFaturaTaxa fatTaxa in fatCategoria.Taxas) {
					if (fatTaxa.TipoDoConsumo != OnpFaturaTaxa.TipoConsumo.Lido) {
						switch (fatTaxa.TipoDoConsumo) {
							case OnpFaturaTaxa.TipoConsumo.Atribuido:
								result = "Atribuido";
								break;
							
                            case OnpFaturaTaxa.TipoConsumo.Estimado:
								result = "Estimado";
								break;
							
                            case OnpFaturaTaxa.TipoConsumo.Fixo:
								result = "Fixo";
								break;
						}
					}
				}
			}

			return result;
		}

		/// <summary>
		/// Gera a lista com o historico de consumos para a fatura em questao ordenado por referencia
		/// </summary>
		/// <param name="total">Numero maximo de referencias para ser listada, passe zero para listar todos os registros.</param>
		/// <returns></returns>
		public ICollection<OnpHistorico> BuscaHistoricoConsumo(int total) {
			OnpHistorico filtro = new OnpHistorico();
			filtro.SeqMatricula = seqMatricula;
			Collection<OnpHistorico> historicoLeitura = filtro.SelectCollection();
			SortedList sl = new SortedList();

			// Ordena por referencia
			foreach (OnpHistorico hd in historicoLeitura)
				sl.Add(hd.CodReferencia, hd);

			Collection<OnpHistorico> retorno = new Collection<OnpHistorico>();
			IList listaOrdenada = sl.GetValueList();
			for (int i = listaOrdenada.Count - 1; i >= 0; i--) {
				if (total != 0 && retorno.Count >= total)
					break;
				
				if (!(listaOrdenada[i] as OnpHistorico).CodReferencia.Equals(codReferencia))
					retorno.Add(listaOrdenada[i] as OnpHistorico);
			}

			return retorno;
		}

		/// <summary>
		/// Gera o codigo de barras e a linha digitavel caso ainda nao tenha sido gerado
		/// </summary>
		public void geraCodigoBarrasELinhaDigitavel() {
			if (string.IsNullOrEmpty(DesCodigoBarras))
                DesCodigoBarras = ConfigXML.GetCodigoBarras().gerarCodigoBarras(this);

            if (string.IsNullOrEmpty(DesLinhaDigitavel))
                DesLinhaDigitavel = ConfigXML.GetCodigoBarras().gerarLinhaDigitavel(this);
		}

		/// <summary>
		/// Pega o proxima sequencial que deve ser usado para seqFatura
		/// </summary>
		/// <returns></returns>
		public static int ProximoSequencial() {
			return 0; //QueriesCE.MaxSeqFatura() + 1;
		}
		#endregion
	}
}

using System;
using GDA;
using System.Runtime.Serialization;
using GeraBase.DAL;

namespace GeraBase.Model
{
    /// <summary>
    /// Classe que representa a tabela ONP_FATURA.
    /// </summary>
    [PersistenceClass("ONP_FATURA")]
    [PersistenceBaseDAO(typeof(FaturaDAO))]
    [Serializable]
    public class FaturaONP : Persistent
    {
    	#region Local Variables
		private double?  _seq_fatura;
        private string  _cod_referencia;
        private double?  _seq_roteiro;
        private int?  _seq_matricula;
        private double?  _seq_tipo_entrega;
        private string  _cod_hidrometro;
        private string  _ind_fatura_emitida;
        private DateTime?  _dat_vencimento;
        private double?  _val_arredonda_anterior;
        private double?  _val_arredonda_atual;
        private DateTime?  _dat_hora_emissao;
        private double?  _val_valor_faturado;
        private DateTime?  _dat_leitura;
        private DateTime?  _dat_leitura_anterior;
        private string  _ind_entrega_especial;
        private string  _des_banco_debito;
        private string  _des_banco_agencia_debito;
        private double?  _val_quantidade_pendente;
        private double? _val_consumo_medio;
        private double?  _val_desconto;
        private string  _des_linha_digitavel;
        private string  _des_codigo_barras;
        private double?  _val_consumo_medido;
        private double?  _val_consumo_atribuido;
        private double?  _val_consumo_rateado;
        private double?  _val_leitura_anterior;
        private double?  _val_leitura_real;
        private double?  _val_leitura_atribuida;
        private double  _val_impressoes;
        private DateTime?  _dat_proxima_leitura;
        private double?  _val_valor_credito;

		#endregion

		#region Metodos
		[PersistenceProperty("seq_fatura", PersistenceParameterType.Key)]
        public double? seq_fatura 
		{
			get
			{
				return _seq_fatura;
			}
			set
			{
				_seq_fatura = value;
			}
        }

        [PersistenceProperty("cod_referencia", PersistenceParameterType.Key)]
        public string cod_referencia 
		{
			get
			{
				return _cod_referencia;
			}
			set
			{
				_cod_referencia = value;
			}
        }

        [PersistenceProperty("seq_roteiro", PersistenceParameterType.Key)]
        public double? seq_roteiro 
		{
			get
			{
				return _seq_roteiro;
			}
			set
			{
				_seq_roteiro = value;
			}
        }

        [PersistenceProperty("seq_matricula", PersistenceParameterType.Key)]
        public int? seq_matricula 
		{
			get
			{
				return _seq_matricula;
			}
			set
			{
				_seq_matricula = value;
			}
        }

        [PersistenceProperty("seq_tipo_entrega", PersistenceParameterType.Key)]
        public double? seq_tipo_entrega 
		{
			get
			{
				return _seq_tipo_entrega;
			}
			set
			{
				_seq_tipo_entrega = value;
			}
        }

        [PersistenceProperty("cod_hidrometro", PersistenceParameterType.Key)]
        public string cod_hidrometro 
		{
			get
			{
				return _cod_hidrometro;
			}
			set
			{
				_cod_hidrometro = value;
			}
        }
        [PersistenceProperty("ind_fatura_emitida")]
        public string ind_fatura_emitida 
			        {
				        get
				        {
					        return _ind_fatura_emitida;
				        }
				        set
				        {
					        _ind_fatura_emitida = value;
				        }
        }
        [PersistenceProperty("dat_vencimento")]
        public DateTime? dat_vencimento 
			        {
				        get
				        {
					        return _dat_vencimento;
				        }
				        set
				        {
					        _dat_vencimento = value;
				        }
        }

        [PersistenceProperty("val_arredonda_anterior")]
        public double? val_arredonda_anterior 
			        {
				        get
				        {
					        return _val_arredonda_anterior;
				        }
				        set
				        {
					        _val_arredonda_anterior = value;
				        }
        }
        [PersistenceProperty("val_arredonda_atual")]
        public double? val_arredonda_atual 
			        {
				        get
				        {
					        return _val_arredonda_atual;
				        }
				        set
				        {
					        _val_arredonda_atual = value;
				        }
        }
        [PersistenceProperty("dat_hora_emissao")]
        public DateTime? dat_hora_emissao 
			        {
				        get
				        {
					        return _dat_hora_emissao;
				        }
				        set
				        {
					        _dat_hora_emissao = value;
				        }
        }
        [PersistenceProperty("val_valor_faturado")]
        public double? val_valor_faturado 
			        {
				        get
				        {
					        return _val_valor_faturado;
				        }
				        set
				        {
					        _val_valor_faturado = value;
				        }
        }
        [PersistenceProperty("dat_leitura")]
        public DateTime? dat_leitura 
			        {
				        get
				        {
					        return _dat_leitura;
				        }
				        set
				        {
					        _dat_leitura = value;
				        }
        }
        [PersistenceProperty("dat_leitura_anterior")]
        public DateTime? dat_leitura_anterior 
			        {
				        get
				        {
					        return _dat_leitura_anterior;
				        }
				        set
				        {
					        _dat_leitura_anterior = value;
				        }
        }
        [PersistenceProperty("ind_entrega_especial")]
        public string ind_entrega_especial 
			        {
				        get
				        {
					        return _ind_entrega_especial;
				        }
				        set
				        {
					        _ind_entrega_especial = value;
				        }
        }
        [PersistenceProperty("des_banco_debito")]
        public string des_banco_debito 
			        {
				        get
				        {
					        return _des_banco_debito;
				        }
				        set
				        {
					        _des_banco_debito = value;
				        }
        }
        [PersistenceProperty("des_banco_agencia_debito")]
        public string des_banco_agencia_debito 
			        {
				        get
				        {
					        return _des_banco_agencia_debito;
				        }
				        set
				        {
					        _des_banco_agencia_debito = value;
				        }
        }
        [PersistenceProperty("val_quantidade_pendente")]
        public double? val_quantidade_pendente 
			        {
				        get
				        {
					        return _val_quantidade_pendente;
				        }
				        set
				        {
					        _val_quantidade_pendente = value;
				        }
        }
        [PersistenceProperty("val_consumo_medio")]
        public double? val_consumo_medio 
			        {
				        get
				        {
					        return _val_consumo_medio;
				        }
				        set
				        {
					        _val_consumo_medio = value;
				        }
        }
        [PersistenceProperty("val_desconto")]
        public double? val_desconto 
			        {
				        get
				        {
					        return _val_desconto;
				        }
				        set
				        {
					        _val_desconto = value;
				        }
        }
        [PersistenceProperty("des_linha_digitavel")]
        public string des_linha_digitavel 
			        {
				        get
				        {
					        return _des_linha_digitavel;
				        }
				        set
				        {
					        _des_linha_digitavel = value;
				        }
        }
        [PersistenceProperty("des_codigo_barras")]
        public string des_codigo_barras 
			        {
				        get
				        {
					        return _des_codigo_barras;
				        }
				        set
				        {
					        _des_codigo_barras = value;
				        }
        }
        [PersistenceProperty("val_consumo_medido")]
        public double? val_consumo_medido 
           {
	            get
	            {
		            return _val_consumo_medido;
	            }
	            set
	            {
		            _val_consumo_medido = value;
	            }
        }
        [PersistenceProperty("val_consumo_atribuido")]
        public double? val_consumo_atribuido 
			        {
				        get
				        {
					        return _val_consumo_atribuido;
				        }
				        set
				        {
					        _val_consumo_atribuido = value;
				        }
        }
        [PersistenceProperty("val_consumo_rateado")]
        public double? val_consumo_rateado 
			        {
				        get
				        {
					        return _val_consumo_rateado;
				        }
				        set
				        {
					        _val_consumo_rateado = value;
				        }
        }
        [PersistenceProperty("val_leitura_anterior")]
        public double? val_leitura_anterior 
			        {
				        get
				        {
					        return _val_leitura_anterior;
				        }
				        set
				        {
					        _val_leitura_anterior = value;
				        }
        }
        [PersistenceProperty("val_leitura_real")]
        public double? val_leitura_real 
			        {
				        get
				        {
					        return _val_leitura_real;
				        }
				        set
				        {
					        _val_leitura_real = value;
				        }
        }
        [PersistenceProperty("val_leitura_atribuida")]
        public double? val_leitura_atribuida 
			        {
				        get
				        {
					        return _val_leitura_atribuida;
				        }
				        set
				        {
					        _val_leitura_atribuida = value;
				        }
        }
        [PersistenceProperty("val_impressoes")]
        public double val_impressoes 
			        {
				        get
				        {
					        return _val_impressoes;
				        }
				        set
				        {
					        _val_impressoes = value;
				        }
        }
        [PersistenceProperty("dat_proxima_leitura")]
        public DateTime? dat_proxima_leitura 
			        {
				        get
				        {
					        return _dat_proxima_leitura;
				        }
				        set
				        {
					        _dat_proxima_leitura = value;
				        }
        }
        [PersistenceProperty("val_valor_credito")]
        public double? val_valor_credito 

			        {
				        get
				        {
					        return _val_valor_credito;
				        }
				        set
				        {
					        _val_valor_credito = value;
				        }

        }
		#endregion
    }
}


using System;
using GDA;
using System.Runtime.Serialization;
using Sinc_DATA.DAL;

namespace Sinc_DATA.Model
{
    /// <summary>
    /// Classe que representa a tabela ONP_FATURA.
    /// </summary>
    [PersistenceClass("ONP_FATURA")]
    [PersistenceBaseDAO(typeof(FaturaDAO))]
    [Serializable]
    public class Fatura : Persistent
    {
		#region Metodos
		[PersistenceProperty("seq_fatura", PersistenceParameterType.Key)]
public double seq_fatura
	{get;set;}
	[PersistenceProperty("cod_referencia", PersistenceParameterType.Key)]
public string cod_referencia
	{get;set;}
	[PersistenceProperty("seq_roteiro", PersistenceParameterType.Key)]
public double seq_roteiro
	{get;set;}
	[PersistenceProperty("seq_matricula", PersistenceParameterType.Key)]
public double seq_matricula
	{get;set;}
	[PersistenceProperty("seq_tipo_entrega")]
public double seq_tipo_entrega
	{get;set;}
	[PersistenceProperty("cod_hidrometro")]
public string cod_hidrometro
	{get;set;}
	[PersistenceProperty("ind_fatura_emitida")]
public string ind_fatura_emitida
	{get;set;}
	[PersistenceProperty("dat_vencimento")]
public DateTime? dat_vencimento
	{get;set;}
	[PersistenceProperty("val_arredonda_anterior")]
public double val_arredonda_anterior
	{get;set;}
	[PersistenceProperty("val_arredonda_atual")]
public double? val_arredonda_atual
	{get;set;}
	[PersistenceProperty("dat_hora_emissao")]
public DateTime? dat_hora_emissao
	{get;set;}
	[PersistenceProperty("val_valor_faturado")]
public double? val_valor_faturado
	{get;set;}
	[PersistenceProperty("dat_leitura")]
public DateTime? dat_leitura
	{get;set;}
	[PersistenceProperty("dat_leitura_anterior")]
public DateTime? dat_leitura_anterior
	{get;set;}
	[PersistenceProperty("ind_entrega_especial")]
public string ind_entrega_especial
	{get;set;}
	[PersistenceProperty("des_banco_debito")]
public string des_banco_debito
	{get;set;}
	[PersistenceProperty("des_banco_agencia_debito")]
public string des_banco_agencia_debito
	{get;set;}
	[PersistenceProperty("val_quantidade_pendente")]
public double val_quantidade_pendente
	{get;set;}
	[PersistenceProperty("val_consumo_medio")]
public double val_consumo_medio
	{get;set;}
	[PersistenceProperty("val_desconto")]
public double val_desconto
	{get;set;}
	[PersistenceProperty("des_linha_digitavel")]
public string des_linha_digitavel
	{get;set;}
	[PersistenceProperty("des_codigo_barras")]
public string des_codigo_barras
	{get;set;}
	[PersistenceProperty("val_consumo_medido")]
public double val_consumo_medido
	{get;set;}
	[PersistenceProperty("val_consumo_atribuido")]
public double val_consumo_atribuido
	{get;set;}
	[PersistenceProperty("val_consumo_rateado")]
public double val_consumo_rateado
	{get;set;}
	[PersistenceProperty("val_leitura_anterior")]
public double val_leitura_anterior
	{get;set;}
	[PersistenceProperty("val_leitura_real")]
public double? val_leitura_real
	{get;set;}
	[PersistenceProperty("val_leitura_atribuida")]
public double val_leitura_atribuida
	{get;set;}
	[PersistenceProperty("val_impressoes")]
public double val_impressoes
	{get;set;}
	[PersistenceProperty("dat_proxima_leitura")]
public DateTime? dat_proxima_leitura
	{get;set;}
	[PersistenceProperty("val_valor_credito")]
public double val_valor_credito
	{get;set;}
	
		#endregion
		
		#region Query Importacao
		        
        public string __ToSQL
        {
            get
            {
                return String.Format(@"
                                        INSERT INTO ONP_FATURA
										(
												seq_fatura
				                                ,cod_referencia
				                                ,seq_roteiro
				                                ,seq_matricula
				                                ,seq_tipo_entrega
				                                ,cod_hidrometro
				                                ,ind_fatura_emitida
				                                ,dat_vencimento
				                                ,val_arredonda_anterior
				                                ,val_arredonda_atual
				                                ,dat_hora_emissao
				                                ,val_valor_faturado
				                                ,dat_leitura
				                                ,dat_leitura_anterior
				                                ,ind_entrega_especial
				                                ,des_banco_debito
				                                ,des_banco_agencia_debito
				                                ,val_quantidade_pendente
				                                ,val_consumo_medio
				                                ,val_desconto
				                                ,des_linha_digitavel
				                                ,des_codigo_barras
				                                ,val_consumo_medido
				                                ,val_consumo_atribuido
				                                ,val_consumo_rateado
				                                ,val_leitura_anterior
				                                ,val_leitura_real
				                                ,val_leitura_atribuida
				                                ,val_impressoes
				                                ,dat_proxima_leitura
				                                ,val_valor_credito
				
										)
                                        VALUES
										(
												{0}
					                            ,'{1}'
					                            ,{2}
					                            ,{3}
					                            ,{4}
					                            ,'{5}'
					                            ,'{6}'
					                            ,{7}
					                            ,{8}
					                            ,{9}
					                            ,{10}
					                            ,{11}
					                            ,{12}
					                            ,{13}
					                            ,'{14}'
					                            ,'{15}'
					                            ,'{16}'
					                            ,{17}
					                            ,{18}
					                            ,{19}
					                            ,'{20}'
					                            ,'{21}'
					                            ,{22}
					                            ,{23}
					                            ,{24}
					                            ,{25}
					                            ,{26}
					                            ,{27}
					                            ,{28}
					                            ,{29}
					                            ,{30}
					
										)"
                                                ,(seq_fatura != null ? (String.IsNullOrEmpty(seq_fatura.ToString()) ? "''" : seq_fatura.ToString()) : "''")
				                                ,(cod_referencia != null ? (String.IsNullOrEmpty(cod_referencia.ToString()) ? "''" : cod_referencia.ToString()) : "''")
				                                ,(seq_roteiro != null ? (String.IsNullOrEmpty(seq_roteiro.ToString()) ? "''" : seq_roteiro.ToString()) : "''")
				                                ,(seq_matricula != null ? (String.IsNullOrEmpty(seq_matricula.ToString()) ? "''" : seq_matricula.ToString()) : "''")
				                                ,(seq_tipo_entrega != null ? (String.IsNullOrEmpty(seq_tipo_entrega.ToString()) ? "''" : seq_tipo_entrega.ToString()) : "''")
				                                ,(cod_hidrometro != null ? (String.IsNullOrEmpty(cod_hidrometro.ToString()) ? "" : cod_hidrometro.ToString()) : "")
				                                ,(ind_fatura_emitida != null ? (String.IsNullOrEmpty(ind_fatura_emitida.ToString()) ? "''" : ind_fatura_emitida.ToString()) : "''")
                                                ,(dat_vencimento != null ? (String.IsNullOrEmpty(dat_vencimento.ToString()) ? "null" : "CONVERT(DATETIME," + String.Format("{0:dd/MM/yyyy}", dat_vencimento) + ",102)") : "null")
				                                ,(val_arredonda_anterior != null ? (String.IsNullOrEmpty(val_arredonda_anterior.ToString()) ? "''" : val_arredonda_anterior.ToString()) : "''")
				                                ,(val_arredonda_atual != null ? (String.IsNullOrEmpty(val_arredonda_atual.ToString()) ? "''" : val_arredonda_atual.ToString()) : "''")
                                                ,(dat_hora_emissao != null ? (String.IsNullOrEmpty(dat_hora_emissao.ToString()) ? "null" : "CONVERT(DATETIME," + String.Format("{0:dd/MM/yyyy}", dat_hora_emissao) + ",102)") : "null")
				                                ,(val_valor_faturado != null ? (String.IsNullOrEmpty(val_valor_faturado.ToString()) ? "''" : val_valor_faturado.ToString()) : "''")
                                                ,(dat_leitura != null ? (String.IsNullOrEmpty(dat_leitura.ToString()) ? "null" : "CONVERT(DATETIME," + String.Format("{0:dd/MM/yyyy}", dat_leitura) + ",102)") : "''")
                                                ,(dat_leitura_anterior != null ? (String.IsNullOrEmpty(dat_leitura_anterior.ToString()) ? "null" : "CONVERT(DATETIME," + String.Format("{0:dd/MM/yyyy}", dat_leitura_anterior) + ",102)") : "null")
				                                ,(ind_entrega_especial != null ? (String.IsNullOrEmpty(ind_entrega_especial.ToString()) ? "" : ind_entrega_especial.ToString()) : "")
				                                ,(des_banco_debito != null ? (String.IsNullOrEmpty(des_banco_debito.ToString()) ? "" : des_banco_debito.ToString()) : "")
				                                ,(des_banco_agencia_debito != null ? (String.IsNullOrEmpty(des_banco_agencia_debito.ToString()) ? "" : des_banco_agencia_debito.ToString()) : "")
				                                ,(val_quantidade_pendente != null ? (String.IsNullOrEmpty(val_quantidade_pendente.ToString()) ? "''" : val_quantidade_pendente.ToString()) : "''")
				                                ,(val_consumo_medio != null ? (String.IsNullOrEmpty(val_consumo_medio.ToString()) ? "''" : val_consumo_medio.ToString()) : "''")
				                                ,(val_desconto != null ? (String.IsNullOrEmpty(val_desconto.ToString()) ? "''" : val_desconto.ToString()) : "''")
				                                ,(des_linha_digitavel != null ? (String.IsNullOrEmpty(des_linha_digitavel.ToString()) ? "''" : des_linha_digitavel.ToString()) : "''")
				                                ,(des_codigo_barras != null ? (String.IsNullOrEmpty(des_codigo_barras.ToString()) ? "''" : des_codigo_barras.ToString()) : "''")
				                                ,(val_consumo_medido != null ? (String.IsNullOrEmpty(val_consumo_medido.ToString()) ? "''" : val_consumo_medido.ToString()) : "''")
				                                ,(val_consumo_atribuido != null ? (String.IsNullOrEmpty(val_consumo_atribuido.ToString()) ? "''" : val_consumo_atribuido.ToString()) : "''")
				                                ,(val_consumo_rateado != null ? (String.IsNullOrEmpty(val_consumo_rateado.ToString()) ? "''" : val_consumo_rateado.ToString()) : "''")
				                                ,(val_leitura_anterior != null ? (String.IsNullOrEmpty(val_leitura_anterior.ToString()) ? "''" : val_leitura_anterior.ToString()) : "''")
				                                ,(val_leitura_real != null ? (String.IsNullOrEmpty(val_leitura_real.ToString()) ? "''" : val_leitura_real.ToString()) : "''")
				                                ,(val_leitura_atribuida != null ? (String.IsNullOrEmpty(val_leitura_atribuida.ToString()) ? "''" : val_leitura_atribuida.ToString()) : "''")
				                                ,(val_impressoes != null ? (String.IsNullOrEmpty(val_impressoes.ToString()) ? "''" : val_impressoes.ToString()) : "''")
                                                ,(dat_proxima_leitura != null ? (String.IsNullOrEmpty(dat_proxima_leitura.ToString()) ? "null" : "CONVERT(DATETIME," + String.Format("{0:dd/MM/yyyy}", dat_proxima_leitura) + ",102)") : "null")
				                                ,(val_valor_credito != null ? (String.IsNullOrEmpty(val_valor_credito.ToString()) ? "''" : val_valor_credito.ToString()) : "''")
				
										
									);
            }
        }

		#endregion
    }
}
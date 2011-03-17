using System;
using GDA;
using System.Runtime.Serialization;
using Sinc_DATA.DAL;

namespace Sinc_DATA.Model
{
    /// <summary>
    /// Classe que representa a tabela ONP_MOVIMENTO.
    /// </summary>
    [PersistenceClass("ONP_MOVIMENTO")]
    [PersistenceBaseDAO(typeof(MovimentoDAO))]
    [Serializable]
    public class Movimento : Persistent
    {
		#region Metodos
		[PersistenceProperty("cod_referencia", PersistenceParameterType.Key)]
public string cod_referencia
	{get;set;}
	[PersistenceProperty("seq_roteiro", PersistenceParameterType.Key)]
public double seq_roteiro
	{get;set;}
	[PersistenceProperty("seq_matricula", PersistenceParameterType.Key)]
public double seq_matricula
	{get;set;}
	[PersistenceProperty("cod_agente")]
public double cod_agente
	{get;set;}
	[PersistenceProperty("cod_hidrometro")]
public string cod_hidrometro
	{get;set;}
	[PersistenceProperty("seq_tipo_entrega")]
public double? seq_tipo_entrega
	{get;set;}
	[PersistenceProperty("val_leitura_anterior")]
public double? val_leitura_anterior
	{get;set;}
	[PersistenceProperty("val_leitura_real")]
public double? val_leitura_real
	{get;set;}
	[PersistenceProperty("val_leitura_atribuida")]
public double? val_leitura_atribuida
	{get;set;}
	[PersistenceProperty("val_numero_leituras")]
public double? val_numero_leituras
	{get;set;}
	[PersistenceProperty("ind_leitura_divergente")]
public string ind_leitura_divergente
	{get;set;}
	[PersistenceProperty("val_consumo_medido")]
public double? val_consumo_medido
	{get;set;}
	[PersistenceProperty("val_consumo_medio")]
public double? val_consumo_medio
	{get;set;}
	[PersistenceProperty("val_consumo_atribuido")]
public double? val_consumo_atribuido
	{get;set;}
	[PersistenceProperty("val_consumo_troca")]
public double? val_consumo_troca
	{get;set;}
	[PersistenceProperty("val_consumo_rateado")]
public double? val_consumo_rateado
	{get;set;}
	[PersistenceProperty("des_banco_debito")]
public string des_banco_debito
	{get;set;}
	[PersistenceProperty("des_banco_agencia_debito")]
public string des_banco_agencia_debito
	{get;set;}
	[PersistenceProperty("dat_leitura")]
public DateTime? dat_leitura
	{get;set;}
	[PersistenceProperty("dat_proxima_leitura")]
public DateTime? dat_proxima_leitura
	{get;set;}
	[PersistenceProperty("dat_vencimento")]
public DateTime? dat_vencimento
	{get;set;}
	[PersistenceProperty("dat_leitura_anterior")]
public DateTime? dat_leitura_anterior
	{get;set;}
	[PersistenceProperty("ind_entrega_especial")]
public string ind_entrega_especial
	{get;set;}
	[PersistenceProperty("val_quantidade_pendente")]
public double? val_quantidade_pendente
	{get;set;}
	[PersistenceProperty("val_desconto")]
public double? val_desconto
	{get;set;}
	[PersistenceProperty("ind_motivo_retirada")]
public string ind_motivo_retirada
	{get;set;}
	[PersistenceProperty("dat_troca")]
public DateTime? dat_troca
	{get;set;}
	[PersistenceProperty("ind_situacao_movimento")]
public string ind_situacao_movimento
	{get;set;}
	[PersistenceProperty("ind_fatura_emitida")]
public string ind_fatura_emitida
	{get;set;}
	[PersistenceProperty("val_arredonda_anterior")]
public double? val_arredonda_anterior
	{get;set;}
	[PersistenceProperty("val_impressoes")]
public double? val_impressoes
	{get;set;}
	[PersistenceProperty("val_consumo_estimado")]
public double? val_consumo_estimado
	{get;set;}
	
		#endregion
		
		#region Query Importacao
		        
        public string __ToSQL
        {
            get
            {
                return String.Format(@"
                                        INSERT INTO ONP_MOVIMENTO
										(
												cod_referencia
				,seq_roteiro
				,seq_matricula
				,cod_agente
				,cod_hidrometro
				,seq_tipo_entrega
				,val_leitura_anterior
				,val_leitura_real
				,val_leitura_atribuida
				,val_numero_leituras
				,ind_leitura_divergente
				,val_consumo_medido
				,val_consumo_medio
				,val_consumo_atribuido
				,val_consumo_troca
				,val_consumo_rateado
				,des_banco_debito
				,des_banco_agencia_debito
				,dat_leitura
				,dat_proxima_leitura
				,dat_vencimento
				,dat_leitura_anterior
				,ind_entrega_especial
				,val_quantidade_pendente
				,val_desconto
				,ind_motivo_retirada
				,dat_troca
				,ind_situacao_movimento
				,ind_fatura_emitida
				,val_arredonda_anterior
				,val_impressoes
				,val_consumo_estimado
				
										)
                                        VALUES
										(
												'{0}'
					,{1}
					,{2}
					,{3}
					,'{4}'
					,{5}
					,{6}
					,{7}
					,{8}
					,{9}
					,'{10}'
					,{11}
					,{12}
					,{13}
					,{14}
					,{15}
					,'{16}'
					,'{17}'
					,'{18}'
					,'{19}'
					,'{20}'
					,'{21}'
					,'{22}'
					,{23}
					,{24}
					,'{25}'
					,'{26}'
					,'{27}'
					,'{28}'
					,{29}
					,{30}
					,{31}
					
										)"
												,(cod_referencia != null ? (String.IsNullOrEmpty(cod_referencia.ToString()) ? "''" : cod_referencia.ToString()) : "''")
				,(seq_roteiro != null ? (String.IsNullOrEmpty(seq_roteiro.ToString()) ? "''" : seq_roteiro.ToString()) : "''")
				,(seq_matricula != null ? (String.IsNullOrEmpty(seq_matricula.ToString()) ? "''" : seq_matricula.ToString()) : "''")
				,(cod_agente != null ? (String.IsNullOrEmpty(cod_agente.ToString()) ? "''" : cod_agente.ToString()) : "''")
				,(cod_hidrometro != null ? (String.IsNullOrEmpty(cod_hidrometro.ToString()) ? "''" : cod_hidrometro.ToString()) : "''")
				,(seq_tipo_entrega != null ? (String.IsNullOrEmpty(seq_tipo_entrega.ToString()) ? "''" : seq_tipo_entrega.ToString()) : "''")
				,(val_leitura_anterior != null ? (String.IsNullOrEmpty(val_leitura_anterior.ToString()) ? "''" : val_leitura_anterior.ToString()) : "''")
				,(val_leitura_real != null ? (String.IsNullOrEmpty(val_leitura_real.ToString()) ? "''" : val_leitura_real.ToString()) : "''")
				,(val_leitura_atribuida != null ? (String.IsNullOrEmpty(val_leitura_atribuida.ToString()) ? "''" : val_leitura_atribuida.ToString()) : "''")
				,(val_numero_leituras != null ? (String.IsNullOrEmpty(val_numero_leituras.ToString()) ? "''" : val_numero_leituras.ToString()) : "''")
				,(ind_leitura_divergente != null ? (String.IsNullOrEmpty(ind_leitura_divergente.ToString()) ? "''" : ind_leitura_divergente.ToString()) : "''")
				,(val_consumo_medido != null ? (String.IsNullOrEmpty(val_consumo_medido.ToString()) ? "''" : val_consumo_medido.ToString()) : "''")
				,(val_consumo_medio != null ? (String.IsNullOrEmpty(val_consumo_medio.ToString()) ? "''" : val_consumo_medio.ToString()) : "''")
				,(val_consumo_atribuido != null ? (String.IsNullOrEmpty(val_consumo_atribuido.ToString()) ? "''" : val_consumo_atribuido.ToString()) : "''")
				,(val_consumo_troca != null ? (String.IsNullOrEmpty(val_consumo_troca.ToString()) ? "''" : val_consumo_troca.ToString()) : "''")
				,(val_consumo_rateado != null ? (String.IsNullOrEmpty(val_consumo_rateado.ToString()) ? "''" : val_consumo_rateado.ToString()) : "''")
				,(des_banco_debito != null ? (String.IsNullOrEmpty(des_banco_debito.ToString()) ? "''" : des_banco_debito.ToString()) : "''")
				,(des_banco_agencia_debito != null ? (String.IsNullOrEmpty(des_banco_agencia_debito.ToString()) ? "''" : des_banco_agencia_debito.ToString()) : "''")
				,(dat_leitura != null ? (String.IsNullOrEmpty(dat_leitura.ToString()) ? "''" : dat_leitura.ToString()) : "''")
				,(dat_proxima_leitura != null ? (String.IsNullOrEmpty(dat_proxima_leitura.ToString()) ? "''" : dat_proxima_leitura.ToString()) : "''")
				,(dat_vencimento != null ? (String.IsNullOrEmpty(dat_vencimento.ToString()) ? "''" : dat_vencimento.ToString()) : "''")
				,(dat_leitura_anterior != null ? (String.IsNullOrEmpty(dat_leitura_anterior.ToString()) ? "''" : dat_leitura_anterior.ToString()) : "''")
				,(ind_entrega_especial != null ? (String.IsNullOrEmpty(ind_entrega_especial.ToString()) ? "''" : ind_entrega_especial.ToString()) : "''")
				,(val_quantidade_pendente != null ? (String.IsNullOrEmpty(val_quantidade_pendente.ToString()) ? "''" : val_quantidade_pendente.ToString()) : "''")
				,(val_desconto != null ? (String.IsNullOrEmpty(val_desconto.ToString()) ? "''" : val_desconto.ToString()) : "''")
				,(ind_motivo_retirada != null ? (String.IsNullOrEmpty(ind_motivo_retirada.ToString()) ? "''" : ind_motivo_retirada.ToString()) : "''")
				,(dat_troca != null ? (String.IsNullOrEmpty(dat_troca.ToString()) ? "''" : dat_troca.ToString()) : "''")
				,(ind_situacao_movimento != null ? (String.IsNullOrEmpty(ind_situacao_movimento.ToString()) ? "''" : ind_situacao_movimento.ToString()) : "''")
				,(ind_fatura_emitida != null ? (String.IsNullOrEmpty(ind_fatura_emitida.ToString()) ? "''" : ind_fatura_emitida.ToString()) : "''")
				,(val_arredonda_anterior != null ? (String.IsNullOrEmpty(val_arredonda_anterior.ToString()) ? "''" : val_arredonda_anterior.ToString()) : "''")
				,(val_impressoes != null ? (String.IsNullOrEmpty(val_impressoes.ToString()) ? "''" : val_impressoes.ToString()) : "''")
				,(val_consumo_estimado != null ? (String.IsNullOrEmpty(val_consumo_estimado.ToString()) ? "''" : val_consumo_estimado.ToString()) : "''")
				
										
									);
            }
        }

		#endregion
    }
}
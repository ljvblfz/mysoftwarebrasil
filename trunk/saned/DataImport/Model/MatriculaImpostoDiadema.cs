using System;
using GDA;
using System.Runtime.Serialization;
using Sinc_DATA.DAL;

namespace Sinc_DATA.Model
{
    /// <summary>
    /// Classe que representa a tabela ONP_MATRICULA_DIADEMA.
    /// </summary>
    [PersistenceClass("ONP_MATRICULA_DIADEMA")]
    [PersistenceBaseDAO(typeof(MatriculaImpostoDiademaDAO))]
    [Serializable]
    public class MatriculaImpostoDiadema : Persistent
    {
		#region Metodos
		[PersistenceProperty("seq_matricula", PersistenceParameterType.Key)]
public double seq_matricula
	{get;set;}
	[PersistenceProperty("seq_matricula_pai")]
public double? seq_matricula_pai
	{get;set;}
	[PersistenceProperty("seq_desconto")]
public double? seq_desconto
	{get;set;}
	[PersistenceProperty("ind_corta_ligacao")]
public string ind_corta_ligacao
	{get;set;}
	[PersistenceProperty("ind_cortou_ligacao")]
public string ind_cortou_ligacao
	{get;set;}
	[PersistenceProperty("ind_retencao_impostos")]
public string ind_retencao_impostos
	{get;set;}
	[PersistenceProperty("ind_bloqueio")]
public string ind_bloqueio
	{get;set;}
	[PersistenceProperty("val_dias_bloqueio_anterior")]
public double? val_dias_bloqueio_anterior
	{get;set;}
	[PersistenceProperty("val_dias_bloqueio_atual")]
public double? val_dias_bloqueio_atual
	{get;set;}
	[PersistenceProperty("ind_cachorro")]
public string ind_cachorro
	{get;set;}
	[PersistenceProperty("val_fraudes")]
public double? val_fraudes
	{get;set;}
	[PersistenceProperty("ind_emite_fatura")]
public string ind_emite_fatura
	{get;set;}
	[PersistenceProperty("ind_calcula_fatura")]
public string ind_calcula_fatura
	{get;set;}
	[PersistenceProperty("ind_tipo_consumidor")]
public string ind_tipo_consumidor
	{get;set;}
	[PersistenceProperty("des_mensagem_1")]
public string des_mensagem_1
	{get;set;}
	[PersistenceProperty("des_mensagem_2")]
public string des_mensagem_2
	{get;set;}
	[PersistenceProperty("dat_bloqueio")]
public DateTime? dat_bloqueio
	{get;set;}
	
		#endregion
		
		#region Query Importacao
		        
        public string __ToSQL
        {
            get
            {
                return String.Format(@"
                                        INSERT INTO ONP_MATRICULA_DIADEMA
										(
												seq_matricula
				,seq_matricula_pai
				,seq_desconto
				,ind_corta_ligacao
				,ind_cortou_ligacao
				,ind_retencao_impostos
				,ind_bloqueio
				,val_dias_bloqueio_anterior
				,val_dias_bloqueio_atual
				,ind_cachorro
				,val_fraudes
				,ind_emite_fatura
				,ind_calcula_fatura
				,ind_tipo_consumidor
				,des_mensagem_1
				,des_mensagem_2
				,dat_bloqueio
				
										)
                                        VALUES
										(
												{0}
					,{1}
					,{2}
					,'{3}'
					,'{4}'
					,'{5}'
					,'{6}'
					,{7}
					,{8}
					,'{9}'
					,{10}
					,'{11}'
					,'{12}'
					,'{13}'
					,'{14}'
					,'{15}'
					,'{16}'
					
										)"
												,(seq_matricula != null ? (String.IsNullOrEmpty(seq_matricula.ToString()) ? "''" : seq_matricula.ToString()) : "''")
				,(seq_matricula_pai != null ? (String.IsNullOrEmpty(seq_matricula_pai.ToString()) ? "''" : seq_matricula_pai.ToString()) : "''")
				,(seq_desconto != null ? (String.IsNullOrEmpty(seq_desconto.ToString()) ? "''" : seq_desconto.ToString()) : "''")
				,(ind_corta_ligacao != null ? (String.IsNullOrEmpty(ind_corta_ligacao.ToString()) ? "''" : ind_corta_ligacao.ToString()) : "''")
				,(ind_cortou_ligacao != null ? (String.IsNullOrEmpty(ind_cortou_ligacao.ToString()) ? "''" : ind_cortou_ligacao.ToString()) : "''")
				,(ind_retencao_impostos != null ? (String.IsNullOrEmpty(ind_retencao_impostos.ToString()) ? "''" : ind_retencao_impostos.ToString()) : "''")
				,(ind_bloqueio != null ? (String.IsNullOrEmpty(ind_bloqueio.ToString()) ? "''" : ind_bloqueio.ToString()) : "''")
				,(val_dias_bloqueio_anterior != null ? (String.IsNullOrEmpty(val_dias_bloqueio_anterior.ToString()) ? "''" : val_dias_bloqueio_anterior.ToString()) : "''")
				,(val_dias_bloqueio_atual != null ? (String.IsNullOrEmpty(val_dias_bloqueio_atual.ToString()) ? "''" : val_dias_bloqueio_atual.ToString()) : "''")
				,(ind_cachorro != null ? (String.IsNullOrEmpty(ind_cachorro.ToString()) ? "''" : ind_cachorro.ToString()) : "''")
				,(val_fraudes != null ? (String.IsNullOrEmpty(val_fraudes.ToString()) ? "''" : val_fraudes.ToString()) : "''")
				,(ind_emite_fatura != null ? (String.IsNullOrEmpty(ind_emite_fatura.ToString()) ? "''" : ind_emite_fatura.ToString()) : "''")
				,(ind_calcula_fatura != null ? (String.IsNullOrEmpty(ind_calcula_fatura.ToString()) ? "''" : ind_calcula_fatura.ToString()) : "''")
				,(ind_tipo_consumidor != null ? (String.IsNullOrEmpty(ind_tipo_consumidor.ToString()) ? "''" : ind_tipo_consumidor.ToString()) : "''")
				,(des_mensagem_1 != null ? (String.IsNullOrEmpty(des_mensagem_1.ToString()) ? "''" : des_mensagem_1.ToString()) : "''")
				,(des_mensagem_2 != null ? (String.IsNullOrEmpty(des_mensagem_2.ToString()) ? "''" : des_mensagem_2.ToString()) : "''")
				,(dat_bloqueio != null ? (String.IsNullOrEmpty(dat_bloqueio.ToString()) ? "''" : dat_bloqueio.ToString()) : "''")
				
										
									);
            }
        }

		#endregion
    }
}
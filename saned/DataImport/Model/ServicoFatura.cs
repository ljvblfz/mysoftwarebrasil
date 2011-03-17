using System;
using GDA;
using System.Runtime.Serialization;
using Sinc_DATA.DAL;

namespace Sinc_DATA.Model
{
    /// <summary>
    /// Classe que representa a tabela ONP_SERVICO_FATURA.
    /// </summary>
    [PersistenceClass("ONP_SERVICO_FATURA")]
    [PersistenceBaseDAO(typeof(ServicoFaturaDAO))]
    [Serializable]
    public class ServicoFatura : Persistent
    {
		#region Metodos
		[PersistenceProperty("seq_matricula", PersistenceParameterType.Key)]
public double seq_matricula
	{get;set;}
	[PersistenceProperty("seq_item_servico", PersistenceParameterType.Key)]
public double seq_item_servico
	{get;set;}
	[PersistenceProperty("cod_referencia", PersistenceParameterType.Key)]
public string cod_referencia
	{get;set;}
	[PersistenceProperty("seq_roteiro", PersistenceParameterType.Key)]
public double seq_roteiro
	{get;set;}
	[PersistenceProperty("des_servico")]
public string des_servico
	{get;set;}
	[PersistenceProperty("seq_plano")]
public double? seq_plano
	{get;set;}
	[PersistenceProperty("seq_parcela")]
public double? seq_parcela
	{get;set;}
	[PersistenceProperty("val_parcela")]
public double? val_parcela
	{get;set;}
	[PersistenceProperty("ind_credito")]
public string ind_credito
	{get;set;}
	[PersistenceProperty("val_diferenca_fatura")]
public double? val_diferenca_fatura
	{get;set;}
	
		#endregion
		
		#region Query Importacao
		        
        public string __ToSQL
        {
            get
            {
                return String.Format(@"
                                        INSERT INTO ONP_SERVICO_FATURA
										(
												seq_matricula
				,seq_item_servico
				,cod_referencia
				,seq_roteiro
				,des_servico
				,seq_plano
				,seq_parcela
				,val_parcela
				,ind_credito
				,val_diferenca_fatura
				
										)
                                        VALUES
										(
												{0}
					,{1}
					,'{2}'
					,{3}
					,'{4}'
					,{5}
					,{6}
					,{7}
					,'{8}'
					,{9}
					
										)"
												,(seq_matricula != null ? (String.IsNullOrEmpty(seq_matricula.ToString()) ? "''" : seq_matricula.ToString()) : "''")
				,(seq_item_servico != null ? (String.IsNullOrEmpty(seq_item_servico.ToString()) ? "''" : seq_item_servico.ToString()) : "''")
				,(cod_referencia != null ? (String.IsNullOrEmpty(cod_referencia.ToString()) ? "''" : cod_referencia.ToString()) : "''")
				,(seq_roteiro != null ? (String.IsNullOrEmpty(seq_roteiro.ToString()) ? "''" : seq_roteiro.ToString()) : "''")
				,(des_servico != null ? (String.IsNullOrEmpty(des_servico.ToString()) ? "''" : des_servico.ToString()) : "''")
				,(seq_plano != null ? (String.IsNullOrEmpty(seq_plano.ToString()) ? "''" : seq_plano.ToString()) : "''")
				,(seq_parcela != null ? (String.IsNullOrEmpty(seq_parcela.ToString()) ? "''" : seq_parcela.ToString()) : "''")
				,(val_parcela != null ? (String.IsNullOrEmpty(val_parcela.ToString()) ? "''" : val_parcela.ToString()) : "''")
				,(ind_credito != null ? (String.IsNullOrEmpty(ind_credito.ToString()) ? "''" : ind_credito.ToString()) : "''")
				,(val_diferenca_fatura != null ? (String.IsNullOrEmpty(val_diferenca_fatura.ToString()) ? "''" : val_diferenca_fatura.ToString()) : "''")
				
										
									);
            }
        }

		#endregion
    }
}
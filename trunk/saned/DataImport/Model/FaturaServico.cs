using System;
using GDA;
using System.Runtime.Serialization;
using Sinc_DATA.DAL;

namespace Sinc_DATA.Model
{
    /// <summary>
    /// Classe que representa a tabela ONP_FATURA_SERVICO.
    /// </summary>
    [PersistenceClass("ONP_FATURA_SERVICO")]
    [PersistenceBaseDAO(typeof(FaturaServicoDAO))]
    [Serializable]
    public class FaturaServico : Persistent
    {
		#region Metodos
		[PersistenceProperty("seq_fatura", PersistenceParameterType.Key)]
public double seq_fatura
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
	[PersistenceProperty("seq_matricula", PersistenceParameterType.Key)]
public double seq_matricula
	{get;set;}
	[PersistenceProperty("des_servico")]
public string des_servico
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
	
		#endregion
		
		#region Query Importacao
		        
        public string __ToSQL
        {
            get
            {
                return String.Format(@"
                                        INSERT INTO ONP_FATURA_SERVICO
										(
												seq_fatura
				,seq_item_servico
				,cod_referencia
				,seq_roteiro
				,seq_matricula
				,des_servico
				,seq_parcela
				,val_parcela
				,ind_credito
				
										)
                                        VALUES
										(
												{0}
					,{1}
					,'{2}'
					,{3}
					,{4}
					,'{5}'
					,{6}
					,{7}
					,'{8}'
					
										)"
												,(seq_fatura != null ? (String.IsNullOrEmpty(seq_fatura.ToString()) ? "''" : seq_fatura.ToString()) : "''")
				,(seq_item_servico != null ? (String.IsNullOrEmpty(seq_item_servico.ToString()) ? "''" : seq_item_servico.ToString()) : "''")
				,(cod_referencia != null ? (String.IsNullOrEmpty(cod_referencia.ToString()) ? "''" : cod_referencia.ToString()) : "''")
				,(seq_roteiro != null ? (String.IsNullOrEmpty(seq_roteiro.ToString()) ? "''" : seq_roteiro.ToString()) : "''")
				,(seq_matricula != null ? (String.IsNullOrEmpty(seq_matricula.ToString()) ? "''" : seq_matricula.ToString()) : "''")
				,(des_servico != null ? (String.IsNullOrEmpty(des_servico.ToString()) ? "''" : des_servico.ToString()) : "''")
				,(seq_parcela != null ? (String.IsNullOrEmpty(seq_parcela.ToString()) ? "''" : seq_parcela.ToString()) : "''")
				,(val_parcela != null ? (String.IsNullOrEmpty(val_parcela.ToString()) ? "''" : val_parcela.ToString()) : "''")
				,(ind_credito != null ? (String.IsNullOrEmpty(ind_credito.ToString()) ? "''" : ind_credito.ToString()) : "''")
				
										
									);
            }
        }

		#endregion
    }
}
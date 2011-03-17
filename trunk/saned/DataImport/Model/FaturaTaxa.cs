using System;
using GDA;
using System.Runtime.Serialization;
using Sinc_DATA.DAL;

namespace Sinc_DATA.Model
{
    /// <summary>
    /// Classe que representa a tabela ONP_FATURA_TAXA.
    /// </summary>
    [PersistenceClass("ONP_FATURA_TAXA")]
    [PersistenceBaseDAO(typeof(FaturaTaxaDAO))]
    [Serializable]
    public class FaturaTaxa : Persistent
    {
		#region Metodos
		[PersistenceProperty("seq_taxa", PersistenceParameterType.Key)]
public double seq_taxa
	{get;set;}
	[PersistenceProperty("seq_categoria", PersistenceParameterType.Key)]
public double seq_categoria
	{get;set;}
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
	[PersistenceProperty("val_numero_economia")]
public double? val_numero_economia
	{get;set;}
	[PersistenceProperty("val_consumo_faturado")]
public double? val_consumo_faturado
	{get;set;}
	[PersistenceProperty("val_valor_calculado")]
public double? val_valor_calculado
	{get;set;}
	[PersistenceProperty("val_valor_faturado")]
public double? val_valor_faturado
	{get;set;}
	[PersistenceProperty("ind_situacao")]
public string ind_situacao
	{get;set;}
	[PersistenceProperty("ind_tipo_consumo")]
public string ind_tipo_consumo
	{get;set;}
	
		#endregion
		
		#region Query Importacao
		        
        public string __ToSQL
        {
            get
            {
                return String.Format(@"
                                        INSERT INTO ONP_FATURA_TAXA
										(
												seq_taxa
				,seq_categoria
				,seq_fatura
				,cod_referencia
				,seq_roteiro
				,seq_matricula
				,val_numero_economia
				,val_consumo_faturado
				,val_valor_calculado
				,val_valor_faturado
				,ind_situacao
				,ind_tipo_consumo
				
										)
                                        VALUES
										(
												{0}
					,{1}
					,{2}
					,'{3}'
					,{4}
					,{5}
					,{6}
					,{7}
					,{8}
					,{9}
					,'{10}'
					,'{11}'
					
										)"
												,(seq_taxa != null ? (String.IsNullOrEmpty(seq_taxa.ToString()) ? "''" : seq_taxa.ToString()) : "''")
				,(seq_categoria != null ? (String.IsNullOrEmpty(seq_categoria.ToString()) ? "''" : seq_categoria.ToString()) : "''")
				,(seq_fatura != null ? (String.IsNullOrEmpty(seq_fatura.ToString()) ? "''" : seq_fatura.ToString()) : "''")
				,(cod_referencia != null ? (String.IsNullOrEmpty(cod_referencia.ToString()) ? "''" : cod_referencia.ToString()) : "''")
				,(seq_roteiro != null ? (String.IsNullOrEmpty(seq_roteiro.ToString()) ? "''" : seq_roteiro.ToString()) : "''")
				,(seq_matricula != null ? (String.IsNullOrEmpty(seq_matricula.ToString()) ? "''" : seq_matricula.ToString()) : "''")
				,(val_numero_economia != null ? (String.IsNullOrEmpty(val_numero_economia.ToString()) ? "''" : val_numero_economia.ToString()) : "''")
				,(val_consumo_faturado != null ? (String.IsNullOrEmpty(val_consumo_faturado.ToString()) ? "''" : val_consumo_faturado.ToString()) : "''")
				,(val_valor_calculado != null ? (String.IsNullOrEmpty(val_valor_calculado.ToString()) ? "''" : val_valor_calculado.ToString()) : "''")
				,(val_valor_faturado != null ? (String.IsNullOrEmpty(val_valor_faturado.ToString()) ? "''" : val_valor_faturado.ToString()) : "''")
				,(ind_situacao != null ? (String.IsNullOrEmpty(ind_situacao.ToString()) ? "''" : ind_situacao.ToString()) : "''")
				,(ind_tipo_consumo != null ? (String.IsNullOrEmpty(ind_tipo_consumo.ToString()) ? "''" : ind_tipo_consumo.ToString()) : "''")
				
										
									);
            }
        }

		#endregion
    }
}
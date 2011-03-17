using System;
using GDA;
using System.Runtime.Serialization;
using Sinc_DATA.DAL;

namespace Sinc_DATA.Model
{
    /// <summary>
    /// Classe que representa a tabela ONP_TAXA_TARIFA.
    /// </summary>
    [PersistenceClass("ONP_TAXA_TARIFA")]
    [PersistenceBaseDAO(typeof(TaxaTarifaDAO))]
    [Serializable]
    public class TaxaTarifa : Persistent
    {
		#region Metodos
		[PersistenceProperty("seq_categoria", PersistenceParameterType.Key)]
public double seq_categoria
	{get;set;}
	[PersistenceProperty("seq_taxa", PersistenceParameterType.Key)]
public double seq_taxa
	{get;set;}
	[PersistenceProperty("seq_taxa_tarifa", PersistenceParameterType.Key)]
public double seq_taxa_tarifa
	{get;set;}
	[PersistenceProperty("seq_taxa_base")]
public double? seq_taxa_base
	{get;set;}
	[PersistenceProperty("dat_inicio")]
public DateTime? dat_inicio
	{get;set;}
	[PersistenceProperty("ind_tipo_taxa")]
public string ind_tipo_taxa
	{get;set;}
	[PersistenceProperty("ind_escalonada")]
public string ind_escalonada
	{get;set;}
	[PersistenceProperty("ind_dias_consumo")]
public string ind_dias_consumo
	{get;set;}
	[PersistenceProperty("ind_minimo")]
public string ind_minimo
	{get;set;}
	[PersistenceProperty("ind_proporcional")]
public string ind_proporcional
	{get;set;}
	[PersistenceProperty("val_valor_tarifa")]
public double? val_valor_tarifa
	{get;set;}
	[PersistenceProperty("val_percentual")]
public double? val_percentual
	{get;set;}
	
		#endregion
		
		#region Query Importacao
		        
        public string __ToSQL
        {
            get
            {
                return String.Format(@"
                                        INSERT INTO ONP_TAXA_TARIFA
										(
												seq_categoria
				,seq_taxa
				,seq_taxa_tarifa
				,seq_taxa_base
				,dat_inicio
				,ind_tipo_taxa
				,ind_escalonada
				,ind_dias_consumo
				,ind_minimo
				,ind_proporcional
				,val_valor_tarifa
				,val_percentual
				
										)
                                        VALUES
										(
												{0}
					,{1}
					,{2}
					,{3}
					,'{4}'
					,'{5}'
					,'{6}'
					,'{7}'
					,'{8}'
					,'{9}'
					,{10}
					,{11}
					
										)"
												,(seq_categoria != null ? (String.IsNullOrEmpty(seq_categoria.ToString()) ? "''" : seq_categoria.ToString()) : "''")
				,(seq_taxa != null ? (String.IsNullOrEmpty(seq_taxa.ToString()) ? "''" : seq_taxa.ToString()) : "''")
				,(seq_taxa_tarifa != null ? (String.IsNullOrEmpty(seq_taxa_tarifa.ToString()) ? "''" : seq_taxa_tarifa.ToString()) : "''")
				,(seq_taxa_base != null ? (String.IsNullOrEmpty(seq_taxa_base.ToString()) ? "''" : seq_taxa_base.ToString()) : "''")
				,(dat_inicio != null ? (String.IsNullOrEmpty(dat_inicio.ToString()) ? "''" : dat_inicio.ToString()) : "''")
				,(ind_tipo_taxa != null ? (String.IsNullOrEmpty(ind_tipo_taxa.ToString()) ? "''" : ind_tipo_taxa.ToString()) : "''")
				,(ind_escalonada != null ? (String.IsNullOrEmpty(ind_escalonada.ToString()) ? "''" : ind_escalonada.ToString()) : "''")
				,(ind_dias_consumo != null ? (String.IsNullOrEmpty(ind_dias_consumo.ToString()) ? "''" : ind_dias_consumo.ToString()) : "''")
				,(ind_minimo != null ? (String.IsNullOrEmpty(ind_minimo.ToString()) ? "''" : ind_minimo.ToString()) : "''")
				,(ind_proporcional != null ? (String.IsNullOrEmpty(ind_proporcional.ToString()) ? "''" : ind_proporcional.ToString()) : "''")
				,(val_valor_tarifa != null ? (String.IsNullOrEmpty(val_valor_tarifa.ToString()) ? "''" : val_valor_tarifa.ToString()) : "''")
				,(val_percentual != null ? (String.IsNullOrEmpty(val_percentual.ToString()) ? "''" : val_percentual.ToString()) : "''")
				
										
									);
            }
        }

		#endregion
    }
}
using System;
using GDA;
using System.Runtime.Serialization;
using Sinc_DATA.DAL;

namespace Sinc_DATA.Model
{
    /// <summary>
    /// Classe que representa a tabela ONP_TAXA_TARIFA_FAIXA.
    /// </summary>
    [PersistenceClass("ONP_TAXA_TARIFA_FAIXA")]
    [PersistenceBaseDAO(typeof(TaxaTarifaFaixaDAO))]
    [Serializable]
    public class TaxaTarifaFaixa : Persistent
    {
		#region Metodos
		[PersistenceProperty("seq_categoria", PersistenceParameterType.Key)]
public double seq_categoria
	{get;set;}
	[PersistenceProperty("seq_taxa_tarifa", PersistenceParameterType.Key)]
public double seq_taxa_tarifa
	{get;set;}
	[PersistenceProperty("seq_taxa", PersistenceParameterType.Key)]
public double seq_taxa
	{get;set;}
	[PersistenceProperty("seq_taxa_tarifa_faixa", PersistenceParameterType.Key)]
public double seq_taxa_tarifa_faixa
	{get;set;}
	[PersistenceProperty("val_limite_consumo")]
public double? val_limite_consumo
	{get;set;}
	[PersistenceProperty("val_valor_tarifa")]
public double? val_valor_tarifa
	{get;set;}
	
		#endregion
		
		#region Query Importacao
		        
        public string __ToSQL
        {
            get
            {
                return String.Format(@"
                                        INSERT INTO ONP_TAXA_TARIFA_FAIXA
										(
												seq_categoria
				,seq_taxa_tarifa
				,seq_taxa
				,seq_taxa_tarifa_faixa
				,val_limite_consumo
				,val_valor_tarifa
				
										)
                                        VALUES
										(
												{0}
					,{1}
					,{2}
					,{3}
					,{4}
					,{5}
					
										)"
												,(seq_categoria != null ? (String.IsNullOrEmpty(seq_categoria.ToString()) ? "''" : seq_categoria.ToString()) : "''")
				,(seq_taxa_tarifa != null ? (String.IsNullOrEmpty(seq_taxa_tarifa.ToString()) ? "''" : seq_taxa_tarifa.ToString()) : "''")
				,(seq_taxa != null ? (String.IsNullOrEmpty(seq_taxa.ToString()) ? "''" : seq_taxa.ToString()) : "''")
				,(seq_taxa_tarifa_faixa != null ? (String.IsNullOrEmpty(seq_taxa_tarifa_faixa.ToString()) ? "''" : seq_taxa_tarifa_faixa.ToString()) : "''")
				,(val_limite_consumo != null ? (String.IsNullOrEmpty(val_limite_consumo.ToString()) ? "''" : val_limite_consumo.ToString()) : "''")
				,(val_valor_tarifa != null ? (String.IsNullOrEmpty(val_valor_tarifa.ToString()) ? "''" : val_valor_tarifa.ToString()) : "''")
				
										
									);
            }
        }

		#endregion
    }
}
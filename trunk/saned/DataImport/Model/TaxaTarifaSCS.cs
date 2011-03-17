using System;
using GDA;
using System.Runtime.Serialization;
using Sinc_DATA.DAL;

namespace Sinc_DATA.Model
{
    /// <summary>
    /// Classe que representa a tabela ONP_TAXA_TARIFA_SCS.
    /// </summary>
    [PersistenceClass("ONP_TAXA_TARIFA_SCS")]
    [PersistenceBaseDAO(typeof(TaxaTarifaSCSDAO))]
    [Serializable]
    public class TaxaTarifaSCS : Persistent
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
	[PersistenceProperty("val_minimo")]
public double? val_minimo
	{get;set;}
	
		#endregion
		
		#region Query Importacao
		        
        public string __ToSQL
        {
            get
            {
                return String.Format(@"
                                        INSERT INTO ONP_TAXA_TARIFA_SCS
										(
												seq_categoria
				,seq_taxa_tarifa
				,seq_taxa
				,val_minimo
				
										)
                                        VALUES
										(
												{0}
					,{1}
					,{2}
					,{3}
					
										)"
												,(seq_categoria != null ? (String.IsNullOrEmpty(seq_categoria.ToString()) ? "''" : seq_categoria.ToString()) : "''")
				,(seq_taxa_tarifa != null ? (String.IsNullOrEmpty(seq_taxa_tarifa.ToString()) ? "''" : seq_taxa_tarifa.ToString()) : "''")
				,(seq_taxa != null ? (String.IsNullOrEmpty(seq_taxa.ToString()) ? "''" : seq_taxa.ToString()) : "''")
				,(val_minimo != null ? (String.IsNullOrEmpty(val_minimo.ToString()) ? "''" : val_minimo.ToString()) : "''")
				
										
									);
            }
        }

		#endregion
    }
}
using System;
using GDA;
using System.Runtime.Serialization;
using Sinc_DATA.DAL;

namespace Sinc_DATA.Model
{
    /// <summary>
    /// Classe que representa a tabela ONP_MOVIMENTO_TAXA_SCS.
    /// </summary>
    [PersistenceClass("ONP_MOVIMENTO_TAXA_SCS")]
    [PersistenceBaseDAO(typeof(MovimentoTaxaSCSDAO))]
    [Serializable]
    public class MovimentoTaxaSCS : Persistent
    {
		#region Metodos
		[PersistenceProperty("seq_taxa", PersistenceParameterType.Key)]
public double seq_taxa
	{get;set;}
	[PersistenceProperty("cod_referencia", PersistenceParameterType.Key)]
public string cod_referencia
	{get;set;}
	[PersistenceProperty("seq_matricula", PersistenceParameterType.Key)]
public double seq_matricula
	{get;set;}
	[PersistenceProperty("seq_categoria", PersistenceParameterType.Key)]
public double seq_categoria
	{get;set;}
	[PersistenceProperty("seq_roteiro", PersistenceParameterType.Key)]
public double seq_roteiro
	{get;set;}
	[PersistenceProperty("val_percentual_desconto")]
public double? val_percentual_desconto
	{get;set;}
	
		#endregion
		
		#region Query Importacao
		        
        public string __ToSQL
        {
            get
            {
                return String.Format(@"
                                        INSERT INTO ONP_MOVIMENTO_TAXA_SCS
										(
												seq_taxa
				,cod_referencia
				,seq_matricula
				,seq_categoria
				,seq_roteiro
				,val_percentual_desconto
				
										)
                                        VALUES
										(
												{0}
					,'{1}'
					,{2}
					,{3}
					,{4}
					,{5}
					
										)"
												,(seq_taxa != null ? (String.IsNullOrEmpty(seq_taxa.ToString()) ? "''" : seq_taxa.ToString()) : "''")
				,(cod_referencia != null ? (String.IsNullOrEmpty(cod_referencia.ToString()) ? "''" : cod_referencia.ToString()) : "''")
				,(seq_matricula != null ? (String.IsNullOrEmpty(seq_matricula.ToString()) ? "''" : seq_matricula.ToString()) : "''")
				,(seq_categoria != null ? (String.IsNullOrEmpty(seq_categoria.ToString()) ? "''" : seq_categoria.ToString()) : "''")
				,(seq_roteiro != null ? (String.IsNullOrEmpty(seq_roteiro.ToString()) ? "''" : seq_roteiro.ToString()) : "''")
				,(val_percentual_desconto != null ? (String.IsNullOrEmpty(val_percentual_desconto.ToString()) ? "''" : val_percentual_desconto.ToString()) : "''")
				
										
									);
            }
        }

		#endregion
    }
}
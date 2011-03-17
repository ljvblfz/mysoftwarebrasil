using System;
using GDA;
using System.Runtime.Serialization;
using Sinc_DATA.DAL;

namespace Sinc_DATA.Model
{
    /// <summary>
    /// Classe que representa a tabela ONP_TAXA.
    /// </summary>
    [PersistenceClass("ONP_TAXA")]
    [PersistenceBaseDAO(typeof(TaxaDAO))]
    [Serializable]
    public class Taxa : Persistent
    {
		#region Metodos
		[PersistenceProperty("seq_taxa", PersistenceParameterType.Key)]
public double seq_taxa
	{get;set;}
	[PersistenceProperty("des_taxa")]
public string des_taxa
	{get;set;}
	
		#endregion
		
		#region Query Importacao
		        
        public string __ToSQL
        {
            get
            {
                return String.Format(@"
                                        INSERT INTO ONP_TAXA
										(
												seq_taxa
				,des_taxa
				
										)
                                        VALUES
										(
												{0}
					,'{1}'
					
										)"
												,(seq_taxa != null ? (String.IsNullOrEmpty(seq_taxa.ToString()) ? "''" : seq_taxa.ToString()) : "''")
				,(des_taxa != null ? (String.IsNullOrEmpty(des_taxa.ToString()) ? "''" : des_taxa.ToString()) : "''")
				
										
									);
            }
        }

		#endregion
    }
}
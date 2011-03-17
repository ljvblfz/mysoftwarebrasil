using System;
using GDA;
using System.Runtime.Serialization;
using Sinc_DATA.DAL;

namespace Sinc_DATA.Model
{
    /// <summary>
    /// Classe que representa a tabela ONP_MATRICULA_SCS.
    /// </summary>
    [PersistenceClass("ONP_MATRICULA_SCS")]
    [PersistenceBaseDAO(typeof(MatriculaSCSDAO))]
    [Serializable]
    public class MatriculaSCS : Persistent
    {
		#region Metodos
		[PersistenceProperty("seq_matricula", PersistenceParameterType.Key)]
public double seq_matricula
	{get;set;}
	[PersistenceProperty("ind_lancamento")]
public string ind_lancamento
	{get;set;}
	
		#endregion
		
		#region Query Importacao
		        
        public string __ToSQL
        {
            get
            {
                return String.Format(@"
                                        INSERT INTO ONP_MATRICULA_SCS
										(
												seq_matricula
				,ind_lancamento
				
										)
                                        VALUES
										(
												{0}
					,'{1}'
					
										)"
												,(seq_matricula != null ? (String.IsNullOrEmpty(seq_matricula.ToString()) ? "''" : seq_matricula.ToString()) : "''")
				,(ind_lancamento != null ? (String.IsNullOrEmpty(ind_lancamento.ToString()) ? "''" : ind_lancamento.ToString()) : "''")
				
										
									);
            }
        }

		#endregion
    }
}
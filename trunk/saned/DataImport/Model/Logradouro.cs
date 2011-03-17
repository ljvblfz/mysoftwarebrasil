using System;
using GDA;
using System.Runtime.Serialization;
using Sinc_DATA.DAL;

namespace Sinc_DATA.Model
{
    /// <summary>
    /// Classe que representa a tabela ONP_LOGRADOURO.
    /// </summary>
    [PersistenceClass("ONP_LOGRADOURO")]
    [PersistenceBaseDAO(typeof(LogradouroDAO))]
    [Serializable]
    public class Logradouro : Persistent
    {
		#region Metodos
		[PersistenceProperty("seq_logradouro", PersistenceParameterType.Key)]
public double seq_logradouro
	{get;set;}
	[PersistenceProperty("des_logradouro")]
public string des_logradouro
	{get;set;}
	
		#endregion
		
		#region Query Importacao
		        
        public string __ToSQL
        {
            get
            {
                return String.Format(@"
                                        INSERT INTO ONP_LOGRADOURO
										(
												seq_logradouro
				,des_logradouro
				
										)
                                        VALUES
										(
												{0}
					,'{1}'
					
										)"
												,(seq_logradouro != null ? (String.IsNullOrEmpty(seq_logradouro.ToString()) ? "''" : seq_logradouro.ToString()) : "''")
				,(des_logradouro != null ? (String.IsNullOrEmpty(des_logradouro.ToString()) ? "''" : des_logradouro.ToString()) : "''")
				
										
									);
            }
        }

		#endregion
    }
}
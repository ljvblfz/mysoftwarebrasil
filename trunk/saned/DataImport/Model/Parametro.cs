using System;
using GDA;
using System.Runtime.Serialization;
using Sinc_DATA.DAL;

namespace Sinc_DATA.Model
{
    /// <summary>
    /// Classe que representa a tabela ONP_PARAMETRO.
    /// </summary>
    [PersistenceClass("ONP_PARAMETRO")]
    [PersistenceBaseDAO(typeof(ParametroDAO))]
    [Serializable]
    public class Parametro : Persistent
    {
		#region Metodos
		[PersistenceProperty("des_nome", PersistenceParameterType.Key)]
public string des_nome
	{get;set;}
	[PersistenceProperty("des_valor")]
public string des_valor
	{get;set;}
	
		#endregion
		
		#region Query Importacao
		        
        public string __ToSQL
        {
            get
            {
                return String.Format(@"
                                        INSERT INTO ONP_PARAMETRO
										(
												des_nome
				,des_valor
				
										)
                                        VALUES
										(
												'{0}'
					,'{1}'
					
										)"
												,(des_nome != null ? (String.IsNullOrEmpty(des_nome.ToString()) ? "''" : des_nome.ToString()) : "''")
				,(des_valor != null ? (String.IsNullOrEmpty(des_valor.ToString()) ? "''" : des_valor.ToString()) : "''")
				
										
									);
            }
        }

		#endregion
    }
}
using System;
using GDA;
using System.Runtime.Serialization;
using Sinc_DATA.DAL;

namespace Sinc_DATA.Model
{
    /// <summary>
    /// Classe que representa a tabela ONP_IMPOSTO_DIADEMA.
    /// </summary>
    [PersistenceClass("ONP_IMPOSTO_DIADEMA")]
    [PersistenceBaseDAO(typeof(ImpostoDiademaDAO))]
    [Serializable]
    public class ImpostoDiadema : Persistent
    {
		#region Metodos
		[PersistenceProperty("cod_imposto", PersistenceParameterType.Key)]
public string cod_imposto
	{get;set;}
	[PersistenceProperty("val_porcentagem")]
public double? val_porcentagem
	{get;set;}
	
		#endregion
		
		#region Query Importacao
		        
        public string __ToSQL
        {
            get
            {
                return String.Format(@"
                                        INSERT INTO ONP_IMPOSTO_DIADEMA
										(
												cod_imposto
				,val_porcentagem
				
										)
                                        VALUES
										(
												'{0}'
					,{1}
					
										)"
												,(cod_imposto != null ? (String.IsNullOrEmpty(cod_imposto.ToString()) ? "''" : cod_imposto.ToString()) : "''")
				,(val_porcentagem != null ? (String.IsNullOrEmpty(val_porcentagem.ToString()) ? "''" : val_porcentagem.ToString()) : "''")
				
										
									);
            }
        }

		#endregion
    }
}
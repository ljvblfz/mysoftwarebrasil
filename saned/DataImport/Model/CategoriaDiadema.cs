using System;
using GDA;
using System.Runtime.Serialization;
using Sinc_DATA.DAL;

namespace Sinc_DATA.Model
{
    /// <summary>
    /// Classe que representa a tabela ONP_CATEGORIA_DIADEMA.
    /// </summary>
    [PersistenceClass("ONP_CATEGORIA_DIADEMA")]
    [PersistenceBaseDAO(typeof(CategoriaDiademaDAO))]
    [Serializable]
    public class CategoriaDiadema : Persistent
    {
		#region Metodos
		[PersistenceProperty("seq_categoria", PersistenceParameterType.Key)]
public double seq_categoria
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
                                        INSERT INTO ONP_CATEGORIA_DIADEMA
										(
												seq_categoria
				,val_minimo
				
										)
                                        VALUES
										(
												{0}
					,{1}
					
										)"
												,(seq_categoria != null ? (String.IsNullOrEmpty(seq_categoria.ToString()) ? "''" : seq_categoria.ToString()) : "''")
				,(val_minimo != null ? (String.IsNullOrEmpty(val_minimo.ToString()) ? "''" : val_minimo.ToString()) : "''")
				
										
									);
            }
        }

		#endregion
    }
}
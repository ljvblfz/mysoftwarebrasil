using System;
using GDA;
using System.Runtime.Serialization;
using Sinc_DATA.DAL;

namespace Sinc_DATA.Model
{
    /// <summary>
    /// Classe que representa a tabela ONP_CATEGORIA.
    /// </summary>
    [PersistenceClass("ONP_CATEGORIA")]
    [PersistenceBaseDAO(typeof(CategoriaDAO))]
    [Serializable]
    public class Categoria : Persistent
    {
		#region Metodos
		[PersistenceProperty("seq_categoria", PersistenceParameterType.Key)]
public double seq_categoria
	{get;set;}
	[PersistenceProperty("des_categoria")]
public string des_categoria
	{get;set;}
	
		#endregion
		
		#region Query Importacao
		        
        public string __ToSQL
        {
            get
            {
                return String.Format(@"
                                        INSERT INTO ONP_CATEGORIA
										(
												seq_categoria
				,des_categoria
				
										)
                                        VALUES
										(
												{0}
					,'{1}'
					
										)"
												,(seq_categoria != null ? (String.IsNullOrEmpty(seq_categoria.ToString()) ? "''" : seq_categoria.ToString()) : "''")
				,(des_categoria != null ? (String.IsNullOrEmpty(des_categoria.ToString()) ? "''" : des_categoria.ToString()) : "''")
				
										
									);
            }
        }

		#endregion
    }
}
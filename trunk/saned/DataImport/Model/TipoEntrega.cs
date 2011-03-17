using System;
using GDA;
using System.Runtime.Serialization;
using Sinc_DATA.DAL;

namespace Sinc_DATA.Model
{
    /// <summary>
    /// Classe que representa a tabela ONP_TIPO_ENTREGA.
    /// </summary>
    [PersistenceClass("ONP_TIPO_ENTREGA")]
    [PersistenceBaseDAO(typeof(TipoEntregaDAO))]
    [Serializable]
    public class TipoEntrega : Persistent
    {
		#region Metodos
		[PersistenceProperty("seq_tipo_entrega", PersistenceParameterType.Key)]
public double seq_tipo_entrega
	{get;set;}
	[PersistenceProperty("des_tipo_entrega")]
public string des_tipo_entrega
	{get;set;}
	
		#endregion
		
		#region Query Importacao
		        
        public string __ToSQL
        {
            get
            {
                return String.Format(@"
                                        INSERT INTO ONP_TIPO_ENTREGA
										(
												seq_tipo_entrega
				,des_tipo_entrega
				
										)
                                        VALUES
										(
												{0}
					,'{1}'
					
										)"
												,(seq_tipo_entrega != null ? (String.IsNullOrEmpty(seq_tipo_entrega.ToString()) ? "''" : seq_tipo_entrega.ToString()) : "''")
				,(des_tipo_entrega != null ? (String.IsNullOrEmpty(des_tipo_entrega.ToString()) ? "''" : des_tipo_entrega.ToString()) : "''")
				
										
									);
            }
        }

		#endregion
    }
}
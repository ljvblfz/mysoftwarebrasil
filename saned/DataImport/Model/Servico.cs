using System;
using GDA;
using System.Runtime.Serialization;
using Sinc_DATA.DAL;

namespace Sinc_DATA.Model
{
    /// <summary>
    /// Classe que representa a tabela ONP_SERVICO.
    /// </summary>
    [PersistenceClass("ONP_SERVICO")]
    [PersistenceBaseDAO(typeof(ServicoDAO))]
    [Serializable]
    public class Servico : Persistent
    {
		#region Metodos
		[PersistenceProperty("seq_servico", PersistenceParameterType.Key)]
public double seq_servico
	{get;set;}
	[PersistenceProperty("des_servico")]
public string des_servico
	{get;set;}
	[PersistenceProperty("val_servico")]
public double val_servico
	{get;set;}
	
		#endregion
		
		#region Query Importacao
		        
        public string __ToSQL
        {
            get
            {
                return String.Format(@"
                                        INSERT INTO ONP_SERVICO
										(
												seq_servico
				,des_servico
				,val_servico
				
										)
                                        VALUES
										(
												{0}
					,'{1}'
					,{2}
					
										)"
												,(seq_servico != null ? (String.IsNullOrEmpty(seq_servico.ToString()) ? "''" : seq_servico.ToString()) : "''")
				,(des_servico != null ? (String.IsNullOrEmpty(des_servico.ToString()) ? "''" : des_servico.ToString()) : "''")
				,(val_servico != null ? (String.IsNullOrEmpty(val_servico.ToString()) ? "''" : val_servico.ToString()) : "''")
				
										
									);
            }
        }

		#endregion
    }
}
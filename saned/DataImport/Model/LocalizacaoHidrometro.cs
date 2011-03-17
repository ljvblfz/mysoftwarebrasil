using System;
using GDA;
using System.Runtime.Serialization;
using Sinc_DATA.DAL;

namespace Sinc_DATA.Model
{
    /// <summary>
    /// Classe que representa a tabela ONP_LOCALIZACAO_HIDROMETRO.
    /// </summary>
    [PersistenceClass("ONP_LOCALIZACAO_HIDROMETRO")]
    [PersistenceBaseDAO(typeof(LocalizacaoHidrometroDAO))]
    [Serializable]
    public class LocalizacaoHidrometro : Persistent
    {
		#region Metodos
		[PersistenceProperty("seq_local", PersistenceParameterType.Key)]
public double seq_local
	{get;set;}
	[PersistenceProperty("des_local")]
public string des_local
	{get;set;}
	
		#endregion
		
		#region Query Importacao
		        
        public string __ToSQL
        {
            get
            {
                return String.Format(@"
                                        INSERT INTO ONP_LOCALIZACAO_HIDROMETRO
										(
												seq_local
				,des_local
				
										)
                                        VALUES
										(
												{0}
					,'{1}'
					
										)"
												,(seq_local != null ? (String.IsNullOrEmpty(seq_local.ToString()) ? "''" : seq_local.ToString()) : "''")
				,(des_local != null ? (String.IsNullOrEmpty(des_local.ToString()) ? "''" : des_local.ToString()) : "''")
				
										
									);
            }
        }

		#endregion
    }
}
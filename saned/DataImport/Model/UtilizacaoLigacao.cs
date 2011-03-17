using System;
using GDA;
using System.Runtime.Serialization;
using Sinc_DATA.DAL;

namespace Sinc_DATA.Model
{
    /// <summary>
    /// Classe que representa a tabela ONP_UTILIZACAO_LIGACAO.
    /// </summary>
    [PersistenceClass("ONP_UTILIZACAO_LIGACAO")]
    [PersistenceBaseDAO(typeof(UtilizacaoLigacaoDAO))]
    [Serializable]
    public class UtilizacaoLigacao : Persistent
    {
		#region Metodos
		[PersistenceProperty("seq_utilizacao_ligacao", PersistenceParameterType.Key)]
public double seq_utilizacao_ligacao
	{get;set;}
	[PersistenceProperty("des_utilizacao_ligacao")]
public string des_utilizacao_ligacao
	{get;set;}
	
		#endregion
		
		#region Query Importacao
		        
        public string __ToSQL
        {
            get
            {
                return String.Format(@"
                                        INSERT INTO ONP_UTILIZACAO_LIGACAO
										(
												seq_utilizacao_ligacao
				,des_utilizacao_ligacao
				
										)
                                        VALUES
										(
												{0}
					,'{1}'
					
										)"
												,(seq_utilizacao_ligacao != null ? (String.IsNullOrEmpty(seq_utilizacao_ligacao.ToString()) ? "''" : seq_utilizacao_ligacao.ToString()) : "''")
				,(des_utilizacao_ligacao != null ? (String.IsNullOrEmpty(des_utilizacao_ligacao.ToString()) ? "''" : des_utilizacao_ligacao.ToString()) : "''")
				
										
									);
            }
        }

		#endregion
    }
}
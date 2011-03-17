using System;
using GDA;
using System.Runtime.Serialization;
using Sinc_DATA.DAL;

namespace Sinc_DATA.Model
{
    /// <summary>
    /// Classe que representa a tabela ONP_AGENTE.
    /// </summary>
    [PersistenceClass("ONP_AGENTE")]
    [PersistenceBaseDAO(typeof(AgenteDAO))]
    [Serializable]
    public class Agente : Persistent
    {
		#region Metodos
		[PersistenceProperty("cod_agente", PersistenceParameterType.Key)]
public double cod_agente
	{get;set;}
	[PersistenceProperty("nom_agente")]
public string nom_agente
	{get;set;}
	[PersistenceProperty("des_senha")]
public string des_senha
	{get;set;}
	
		#endregion
		
		#region Query Importacao
		        
        public string __ToSQL
        {
            get
            {
                return String.Format(@"
                                        INSERT INTO ONP_AGENTE
										(
												cod_agente
				,nom_agente
				,des_senha
				
										)
                                        VALUES
										(
												{0}
					,'{1}'
					,'{2}'
					
										)"
												,(cod_agente != null ? (String.IsNullOrEmpty(cod_agente.ToString()) ? "''" : cod_agente.ToString()) : "''")
				,(nom_agente != null ? (String.IsNullOrEmpty(nom_agente.ToString()) ? "''" : nom_agente.ToString()) : "''")
				,(des_senha != null ? (String.IsNullOrEmpty(des_senha.ToString()) ? "''" : des_senha.ToString()) : "''")
				
										
									);
            }
        }

		#endregion
    }
}
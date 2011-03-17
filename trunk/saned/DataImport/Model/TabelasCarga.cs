using System;
using GDA;
using System.Runtime.Serialization;
using Sinc_DATA.DAL;

namespace Sinc_DATA.Model
{
    /// <summary>
    /// Classe que representa a tabela ONP_TABELAS_CARGA.
    /// </summary>
    [PersistenceClass("ONP_TABELAS_CARGA")]
    [PersistenceBaseDAO(typeof(TabelasCargaDAO))]
    [Serializable]
    public class TabelasCarga : Persistent
    {
		#region Metodos
		[PersistenceProperty("nom_tabela", PersistenceParameterType.Key)]
public string nom_tabela
	{get;set;}
	[PersistenceProperty("ind_carga")]
public string ind_carga
	{get;set;}
	[PersistenceProperty("ind_descarga")]
public string ind_descarga
	{get;set;}
	
		#endregion
		
		#region Query Importacao
		        
        public string __ToSQL
        {
            get
            {
                return String.Format(@"
                                        INSERT INTO ONP_TABELAS_CARGA
										(
												nom_tabela
				,ind_carga
				,ind_descarga
				
										)
                                        VALUES
										(
												'{0}'
					,'{1}'
					,'{2}'
					
										)"
												,(nom_tabela != null ? (String.IsNullOrEmpty(nom_tabela.ToString()) ? "''" : nom_tabela.ToString()) : "''")
				,(ind_carga != null ? (String.IsNullOrEmpty(ind_carga.ToString()) ? "''" : ind_carga.ToString()) : "''")
				,(ind_descarga != null ? (String.IsNullOrEmpty(ind_descarga.ToString()) ? "''" : ind_descarga.ToString()) : "''")
				
										
									);
            }
        }

		#endregion
    }
}
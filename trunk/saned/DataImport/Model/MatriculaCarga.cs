using System;
using GDA;
using System.Runtime.Serialization;
using Sinc_DATA.DAL;

namespace Sinc_DATA.Model
{
    /// <summary>
    /// Classe que representa a tabela ONP_MATRICULAS_CARGA.
    /// </summary>
    [PersistenceClass("ONP_MATRICULAS_CARGA")]
    [PersistenceBaseDAO(typeof(MatriculaCargaDAO))]
    [Serializable]
    public class MatriculaCarga : Persistent
    {
		#region Metodos
		[PersistenceProperty("seq_matricula", PersistenceParameterType.Key)]
public double seq_matricula
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
                                        INSERT INTO ONP_MATRICULAS_CARGA
										(
												seq_matricula
				,ind_carga
				,ind_descarga
				
										)
                                        VALUES
										(
												{0}
					,'{1}'
					,'{2}'
					
										)"
												,(seq_matricula != null ? (String.IsNullOrEmpty(seq_matricula.ToString()) ? "''" : seq_matricula.ToString()) : "''")
				,(ind_carga != null ? (String.IsNullOrEmpty(ind_carga.ToString()) ? "''" : ind_carga.ToString()) : "''")
				,(ind_descarga != null ? (String.IsNullOrEmpty(ind_descarga.ToString()) ? "''" : ind_descarga.ToString()) : "''")
				
										
									);
            }
        }

		#endregion
    }
}
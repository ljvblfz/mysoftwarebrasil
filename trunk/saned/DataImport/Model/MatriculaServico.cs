using System;
using GDA;
using System.Runtime.Serialization;
using Sinc_DATA.DAL;

namespace Sinc_DATA.Model
{
    /// <summary>
    /// Classe que representa a tabela ONP_MATRICULA_SERVICO.
    /// </summary>
    [PersistenceClass("ONP_MATRICULA_SERVICO")]
    [PersistenceBaseDAO(typeof(MatriculaServicoDAO))]
    [Serializable]
    public class MatriculaServico : Persistent
    {
		#region Metodos
		[PersistenceProperty("seq_item", PersistenceParameterType.Key)]
public double seq_item
	{get;set;}
	[PersistenceProperty("seq_matricula", PersistenceParameterType.Key)]
public double seq_matricula
	{get;set;}
	[PersistenceProperty("seq_servico")]
public double? seq_servico
	{get;set;}
	[PersistenceProperty("ind_solicitante")]
public string ind_solicitante
	{get;set;}
	
		#endregion
		
		#region Query Importacao
		        
        public string __ToSQL
        {
            get
            {
                return String.Format(@"
                                        INSERT INTO ONP_MATRICULA_SERVICO
										(
												seq_item
				,seq_matricula
				,seq_servico
				,ind_solicitante
				
										)
                                        VALUES
										(
												{0}
					,{1}
					,{2}
					,'{3}'
					
										)"
												,(seq_item != null ? (String.IsNullOrEmpty(seq_item.ToString()) ? "''" : seq_item.ToString()) : "''")
				,(seq_matricula != null ? (String.IsNullOrEmpty(seq_matricula.ToString()) ? "''" : seq_matricula.ToString()) : "''")
				,(seq_servico != null ? (String.IsNullOrEmpty(seq_servico.ToString()) ? "''" : seq_servico.ToString()) : "''")
				,(ind_solicitante != null ? (String.IsNullOrEmpty(ind_solicitante.ToString()) ? "''" : ind_solicitante.ToString()) : "''")
				
										
									);
            }
        }

		#endregion
    }
}
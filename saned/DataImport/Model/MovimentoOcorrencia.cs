using System;
using GDA;
using System.Runtime.Serialization;
using Sinc_DATA.DAL;

namespace Sinc_DATA.Model
{
    /// <summary>
    /// Classe que representa a tabela ONP_MOVIMENTO_OCORRENCIA.
    /// </summary>
    [PersistenceClass("ONP_MOVIMENTO_OCORRENCIA")]
    [PersistenceBaseDAO(typeof(MovimentoOcorrenciaDAO))]
    [Serializable]
    public class MovimentoOcorrencia : Persistent
    {
		#region Metodos
		[PersistenceProperty("cod_referencia", PersistenceParameterType.Key)]
public string cod_referencia
	{get;set;}
	[PersistenceProperty("seq_matricula", PersistenceParameterType.Key)]
public double seq_matricula
	{get;set;}
	[PersistenceProperty("cod_ocorrencia", PersistenceParameterType.Key)]
public double cod_ocorrencia
	{get;set;}
	[PersistenceProperty("seq_roteiro", PersistenceParameterType.Key)]
public double seq_roteiro
	{get;set;}
	[PersistenceProperty("seq_sequencial", PersistenceParameterType.Key)]
public double seq_sequencial
	{get;set;}
	
		#endregion
		
		#region Query Importacao
		        
        public string __ToSQL
        {
            get
            {
                return String.Format(@"
                                        INSERT INTO ONP_MOVIMENTO_OCORRENCIA
										(
												cod_referencia
				,seq_matricula
				,cod_ocorrencia
				,seq_roteiro
				,seq_sequencial
				
										)
                                        VALUES
										(
												'{0}'
					,{1}
					,{2}
					,{3}
					,{4}
					
										)"
												,(cod_referencia != null ? (String.IsNullOrEmpty(cod_referencia.ToString()) ? "''" : cod_referencia.ToString()) : "''")
				,(seq_matricula != null ? (String.IsNullOrEmpty(seq_matricula.ToString()) ? "''" : seq_matricula.ToString()) : "''")
				,(cod_ocorrencia != null ? (String.IsNullOrEmpty(cod_ocorrencia.ToString()) ? "''" : cod_ocorrencia.ToString()) : "''")
				,(seq_roteiro != null ? (String.IsNullOrEmpty(seq_roteiro.ToString()) ? "''" : seq_roteiro.ToString()) : "''")
				,(seq_sequencial != null ? (String.IsNullOrEmpty(seq_sequencial.ToString()) ? "''" : seq_sequencial.ToString()) : "''")
				
										
									);
            }
        }

		#endregion
    }
}
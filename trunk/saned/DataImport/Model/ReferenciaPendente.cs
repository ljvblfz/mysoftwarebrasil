using System;
using GDA;
using System.Runtime.Serialization;
using Sinc_DATA.DAL;

namespace Sinc_DATA.Model
{
    /// <summary>
    /// Classe que representa a tabela ONP_REFERENCIA_PENDENTE.
    /// </summary>
    [PersistenceClass("ONP_REFERENCIA_PENDENTE")]
    [PersistenceBaseDAO(typeof(ReferenciaPendenteDAO))]
    [Serializable]
    public class ReferenciaPendente : Persistent
    {
		#region Metodos
		[PersistenceProperty("seq_matricula", PersistenceParameterType.Key)]
public double seq_matricula
	{get;set;}
	[PersistenceProperty("seq_fatura", PersistenceParameterType.Key)]
public double seq_fatura
	{get;set;}
	[PersistenceProperty("dat_vencimento")]
public DateTime dat_vencimento
	{get;set;}
	
		#endregion
		
		#region Query Importacao
		        
        public string __ToSQL
        {
            get
            {
                return String.Format(@"
                                        INSERT INTO ONP_REFERENCIA_PENDENTE
										(
												seq_matricula
				,seq_fatura
				,dat_vencimento
				
										)
                                        VALUES
										(
												{0}
					,{1}
					,'{2}'
					
										)"
												,(seq_matricula != null ? (String.IsNullOrEmpty(seq_matricula.ToString()) ? "''" : seq_matricula.ToString()) : "''")
				,(seq_fatura != null ? (String.IsNullOrEmpty(seq_fatura.ToString()) ? "''" : seq_fatura.ToString()) : "''")
				,(dat_vencimento != null ? (String.IsNullOrEmpty(dat_vencimento.ToString()) ? "''" : dat_vencimento.ToString()) : "''")
				
										
									);
            }
        }

		#endregion
    }
}
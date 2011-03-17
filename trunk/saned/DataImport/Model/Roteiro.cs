using System;
using GDA;
using System.Runtime.Serialization;
using Sinc_DATA.DAL;

namespace Sinc_DATA.Model
{
    /// <summary>
    /// Classe que representa a tabela ONP_ROTEIRO.
    /// </summary>
    [PersistenceClass("ONP_ROTEIRO")]
    [PersistenceBaseDAO(typeof(RoteiroDAO))]
    [Serializable]
    public class Roteiro : Persistent
    {
		#region Metodos
		[PersistenceProperty("seq_roteiro", PersistenceParameterType.Key)]
public double seq_roteiro
	{get;set;}
	[PersistenceProperty("seq_grupo_fatura")]
public double? seq_grupo_fatura
	{get;set;}
	[PersistenceProperty("ind_fatura")]
public string ind_fatura
	{get;set;}
	[PersistenceProperty("dat_base")]
public DateTime? dat_base
	{get;set;}
	[PersistenceProperty("cod_referencia")]
public string cod_referencia
	{get;set;}
	[PersistenceProperty("dat_servidor")]
public DateTime? dat_servidor
	{get;set;}
	
		#endregion
		
		#region Query Importacao
		        
        public string __ToSQL
        {
            get
            {
                return String.Format(@"
                                        INSERT INTO ONP_ROTEIRO
										(
												seq_roteiro
				,seq_grupo_fatura
				,ind_fatura
				,dat_base
				,cod_referencia
				,dat_servidor
				
										)
                                        VALUES
										(
												{0}
					,{1}
					,'{2}'
					,'{3}'
					,'{4}'
					,'{5}'
					
										)"
												,(seq_roteiro != null ? (String.IsNullOrEmpty(seq_roteiro.ToString()) ? "''" : seq_roteiro.ToString()) : "''")
				,(seq_grupo_fatura != null ? (String.IsNullOrEmpty(seq_grupo_fatura.ToString()) ? "''" : seq_grupo_fatura.ToString()) : "''")
				,(ind_fatura != null ? (String.IsNullOrEmpty(ind_fatura.ToString()) ? "''" : ind_fatura.ToString()) : "''")
				,(dat_base != null ? (String.IsNullOrEmpty(dat_base.ToString()) ? "''" : dat_base.ToString()) : "''")
				,(cod_referencia != null ? (String.IsNullOrEmpty(cod_referencia.ToString()) ? "''" : cod_referencia.ToString()) : "''")
				,(dat_servidor != null ? (String.IsNullOrEmpty(dat_servidor.ToString()) ? "''" : dat_servidor.ToString()) : "''")
				
										
									);
            }
        }

		#endregion
    }
}
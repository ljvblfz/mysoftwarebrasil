using System;
using GDA;
using System.Runtime.Serialization;
using Sinc_DATA.DAL;

namespace Sinc_DATA.Model
{
    /// <summary>
    /// Classe que representa a tabela ONP_GRUPO_FATURA.
    /// </summary>
    [PersistenceClass("ONP_GRUPO_FATURA")]
    [PersistenceBaseDAO(typeof(GrupoFaturaDAO))]
    [Serializable]
    public class GrupoFatura : Persistent
    {
		#region Metodos
		[PersistenceProperty("seq_grupo_fatura", PersistenceParameterType.Key)]
public double seq_grupo_fatura
	{get;set;}
	[PersistenceProperty("ind_tipo_vencimento")]
public string ind_tipo_vencimento
	{get;set;}
	[PersistenceProperty("num_dias")]
public double? num_dias
	{get;set;}
	[PersistenceProperty("des_dias_vencimento")]
public string des_dias_vencimento
	{get;set;}
	
		#endregion
		
		#region Query Importacao
		        
        public string __ToSQL
        {
            get
            {
                return String.Format(@"
                                        INSERT INTO ONP_GRUPO_FATURA
										(
												seq_grupo_fatura
				,ind_tipo_vencimento
				,num_dias
				,des_dias_vencimento
				
										)
                                        VALUES
										(
												{0}
					,'{1}'
					,{2}
					,'{3}'
					
										)"
												,(seq_grupo_fatura != null ? (String.IsNullOrEmpty(seq_grupo_fatura.ToString()) ? "''" : seq_grupo_fatura.ToString()) : "''")
				,(ind_tipo_vencimento != null ? (String.IsNullOrEmpty(ind_tipo_vencimento.ToString()) ? "''" : ind_tipo_vencimento.ToString()) : "''")
				,(num_dias != null ? (String.IsNullOrEmpty(num_dias.ToString()) ? "''" : num_dias.ToString()) : "''")
				,(des_dias_vencimento != null ? (String.IsNullOrEmpty(des_dias_vencimento.ToString()) ? "''" : des_dias_vencimento.ToString()) : "''")
				
										
									);
            }
        }

		#endregion
    }
}
using System;
using GDA;
using System.Runtime.Serialization;
using Sinc_DATA.DAL;

namespace Sinc_DATA.Model
{
    /// <summary>
    /// Classe que representa a tabela ONP_FATURA_IMPOSTO_DIADEMA.
    /// </summary>
    [PersistenceClass("ONP_FATURA_IMPOSTO_DIADEMA")]
    [PersistenceBaseDAO(typeof(FaturaImporstoDiademaDAO))]
    [Serializable]
    public class FaturaImporstoDiadema : Persistent
    {
		#region Metodos
		[PersistenceProperty("seq_fatura", PersistenceParameterType.Key)]
public double seq_fatura
	{get;set;}
	[PersistenceProperty("cod_referencia", PersistenceParameterType.Key)]
public string cod_referencia
	{get;set;}
	[PersistenceProperty("seq_roteiro", PersistenceParameterType.Key)]
public double seq_roteiro
	{get;set;}
	[PersistenceProperty("seq_matricula", PersistenceParameterType.Key)]
public double seq_matricula
	{get;set;}
	[PersistenceProperty("cod_imposto", PersistenceParameterType.Key)]
public string cod_imposto
	{get;set;}
	[PersistenceProperty("val_valor_calculado")]
public double? val_valor_calculado
	{get;set;}
	
		#endregion
		
		#region Query Importacao
		        
        public string __ToSQL
        {
            get
            {
                return String.Format(@"
                                        INSERT INTO ONP_FATURA_IMPOSTO_DIADEMA
										(
												seq_fatura
				,cod_referencia
				,seq_roteiro
				,seq_matricula
				,cod_imposto
				,val_valor_calculado
				
										)
                                        VALUES
										(
												{0}
					,'{1}'
					,{2}
					,{3}
					,'{4}'
					,{5}
					
										)"
												,(seq_fatura != null ? (String.IsNullOrEmpty(seq_fatura.ToString()) ? "''" : seq_fatura.ToString()) : "''")
				,(cod_referencia != null ? (String.IsNullOrEmpty(cod_referencia.ToString()) ? "''" : cod_referencia.ToString()) : "''")
				,(seq_roteiro != null ? (String.IsNullOrEmpty(seq_roteiro.ToString()) ? "''" : seq_roteiro.ToString()) : "''")
				,(seq_matricula != null ? (String.IsNullOrEmpty(seq_matricula.ToString()) ? "''" : seq_matricula.ToString()) : "''")
				,(cod_imposto != null ? (String.IsNullOrEmpty(cod_imposto.ToString()) ? "''" : cod_imposto.ToString()) : "''")
				,(val_valor_calculado != null ? (String.IsNullOrEmpty(val_valor_calculado.ToString()) ? "''" : val_valor_calculado.ToString()) : "''")
				
										
									);
            }
        }

		#endregion
    }
}
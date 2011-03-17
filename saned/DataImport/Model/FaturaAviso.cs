using System;
using GDA;
using System.Runtime.Serialization;
using Sinc_DATA.DAL;

namespace Sinc_DATA.Model
{
    /// <summary>
    /// Classe que representa a tabela ONP_FATURAS_AVISO.
    /// </summary>
    [PersistenceClass("ONP_FATURAS_AVISO")]
    [PersistenceBaseDAO(typeof(FaturaAvisoDAO))]
    [Serializable]
    public class FaturaAviso : Persistent
    {
		#region Metodos
		[PersistenceProperty("seq_matricula", PersistenceParameterType.Key)]
public double seq_matricula
	{get;set;}
	[PersistenceProperty("seq_fatura", PersistenceParameterType.Key)]
public double seq_fatura
	{get;set;}
	[PersistenceProperty("cod_referencia")]
public string cod_referencia
	{get;set;}
	[PersistenceProperty("dat_vencimento")]
public DateTime? dat_vencimento
	{get;set;}
	[PersistenceProperty("val_valor_fatura")]
public double? val_valor_fatura
	{get;set;}
	
		#endregion
		
		#region Query Importacao
		        
        public string __ToSQL
        {
            get
            {
                return String.Format(@"
                                        INSERT INTO ONP_FATURAS_AVISO
										(
												seq_matricula
				,seq_fatura
				,cod_referencia
				,dat_vencimento
				,val_valor_fatura
				
										)
                                        VALUES
										(
												{0}
					,{1}
					,'{2}'
					,'{3}'
					,{4}
					
										)"
												,(seq_matricula != null ? (String.IsNullOrEmpty(seq_matricula.ToString()) ? "''" : seq_matricula.ToString()) : "''")
				,(seq_fatura != null ? (String.IsNullOrEmpty(seq_fatura.ToString()) ? "''" : seq_fatura.ToString()) : "''")
				,(cod_referencia != null ? (String.IsNullOrEmpty(cod_referencia.ToString()) ? "''" : cod_referencia.ToString()) : "''")
				,(dat_vencimento != null ? (String.IsNullOrEmpty(dat_vencimento.ToString()) ? "''" : dat_vencimento.ToString()) : "''")
				,(val_valor_fatura != null ? (String.IsNullOrEmpty(val_valor_fatura.ToString()) ? "''" : val_valor_fatura.ToString()) : "''")
				
										
									);
            }
        }

		#endregion
    }
}
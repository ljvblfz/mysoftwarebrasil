using System;
using GDA;
using System.Runtime.Serialization;
using Sinc_DATA.DAL;

namespace Sinc_DATA.Model
{
    /// <summary>
    /// Classe que representa a tabela ONP_DESCONTO_DIADEMA.
    /// </summary>
    [PersistenceClass("ONP_DESCONTO_DIADEMA")]
    [PersistenceBaseDAO(typeof(DescontoDiademaDAO))]
    [Serializable]
    public class DescontoDiadema : Persistent
    {
		#region Metodos
		[PersistenceProperty("seq_desconto", PersistenceParameterType.Key)]
public double seq_desconto
	{get;set;}
	[PersistenceProperty("ind_tipo_desconto")]
public string ind_tipo_desconto
	{get;set;}
	[PersistenceProperty("val_limite_inicial")]
public double? val_limite_inicial
	{get;set;}
	[PersistenceProperty("val_valor_desconto")]
public double? val_valor_desconto
	{get;set;}
	
		#endregion
		
		#region Query Importacao
		        
        public string __ToSQL
        {
            get
            {
                return String.Format(@"
                                        INSERT INTO ONP_DESCONTO_DIADEMA
										(
												seq_desconto
				,ind_tipo_desconto
				,val_limite_inicial
				,val_valor_desconto
				
										)
                                        VALUES
										(
												{0}
					,'{1}'
					,{2}
					,{3}
					
										)"
												,(seq_desconto != null ? (String.IsNullOrEmpty(seq_desconto.ToString()) ? "''" : seq_desconto.ToString()) : "''")
				,(ind_tipo_desconto != null ? (String.IsNullOrEmpty(ind_tipo_desconto.ToString()) ? "''" : ind_tipo_desconto.ToString()) : "''")
				,(val_limite_inicial != null ? (String.IsNullOrEmpty(val_limite_inicial.ToString()) ? "''" : val_limite_inicial.ToString()) : "''")
				,(val_valor_desconto != null ? (String.IsNullOrEmpty(val_valor_desconto.ToString()) ? "''" : val_valor_desconto.ToString()) : "''")
				
										
									);
            }
        }

		#endregion
    }
}
using System;
using GDA;
using System.Runtime.Serialization;
using Sinc_DATA.DAL;

namespace Sinc_DATA.Model
{
    /// <summary>
    /// Classe que representa a tabela ONP_HISTORICO.
    /// </summary>
    [PersistenceClass("ONP_HISTORICO")]
    [PersistenceBaseDAO(typeof(HistoricoDAO))]
    [Serializable]
    public class Historico : Persistent
    {
		#region Metodos
		[PersistenceProperty("seq_matricula", PersistenceParameterType.Key)]
public double seq_matricula
	{get;set;}
	[PersistenceProperty("cod_referencia", PersistenceParameterType.Key)]
public string cod_referencia
	{get;set;}
	[PersistenceProperty("val_consumo")]
public double? val_consumo
	{get;set;}
	[PersistenceProperty("cod_ocorrencia")]
public string cod_ocorrencia
	{get;set;}
	
		#endregion
		
		#region Query Importacao
		        
        public string __ToSQL
        {
            get
            {
                return String.Format(@"
                                        INSERT INTO ONP_HISTORICO
										(
												seq_matricula
				,cod_referencia
				,val_consumo
				,cod_ocorrencia
				
										)
                                        VALUES
										(
												{0}
					,'{1}'
					,{2}
					,'{3}'
					
										)"
												,(seq_matricula != null ? (String.IsNullOrEmpty(seq_matricula.ToString()) ? "''" : seq_matricula.ToString()) : "''")
				,(cod_referencia != null ? (String.IsNullOrEmpty(cod_referencia.ToString()) ? "''" : cod_referencia.ToString()) : "''")
				,(val_consumo != null ? (String.IsNullOrEmpty(val_consumo.ToString()) ? "''" : val_consumo.ToString()) : "''")
				,(cod_ocorrencia != null ? (String.IsNullOrEmpty(cod_ocorrencia.ToString()) ? "''" : cod_ocorrencia.ToString()) : "''")
				
										
									);
            }
        }

		#endregion
    }
}
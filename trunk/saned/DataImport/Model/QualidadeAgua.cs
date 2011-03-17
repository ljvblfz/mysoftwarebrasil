using System;
using GDA;
using System.Runtime.Serialization;
using Sinc_DATA.DAL;

namespace Sinc_DATA.Model
{
    /// <summary>
    /// Classe que representa a tabela ONP_QUALIDADE_AGUA.
    /// </summary>
    [PersistenceClass("ONP_QUALIDADE_AGUA")]
    [PersistenceBaseDAO(typeof(QualidadeAguaDAO))]
    [Serializable]
    public class QualidadeAgua : Persistent
    {
		#region Metodos
		[PersistenceProperty("seq_zona_abastecimento", PersistenceParameterType.Key)]
public double seq_zona_abastecimento
	{get;set;}
	[PersistenceProperty("dat_referencia", PersistenceParameterType.Key)]
public DateTime dat_referencia
	{get;set;}
	[PersistenceProperty("seq_parametro", PersistenceParameterType.Key)]
public double seq_parametro
	{get;set;}
	[PersistenceProperty("des_parametro")]
public string des_parametro
	{get;set;}
	[PersistenceProperty("val_previstas")]
public double? val_previstas
	{get;set;}
	[PersistenceProperty("val_realizadas")]
public double? val_realizadas
	{get;set;}
	[PersistenceProperty("val_fora_limite")]
public double? val_fora_limite
	{get;set;}
	[PersistenceProperty("val_media")]
public double? val_media
	{get;set;}
	
		#endregion
		
		#region Query Importacao
		        
        public string __ToSQL
        {
            get
            {
                return String.Format(@"
                                        INSERT INTO ONP_QUALIDADE_AGUA
										(
												seq_zona_abastecimento
				,dat_referencia
				,seq_parametro
				,des_parametro
				,val_previstas
				,val_realizadas
				,val_fora_limite
				,val_media
				
										)
                                        VALUES
										(
												{0}
					,'{1}'
					,{2}
					,'{3}'
					,{4}
					,{5}
					,{6}
					,{7}
					
										)"
												,(seq_zona_abastecimento != null ? (String.IsNullOrEmpty(seq_zona_abastecimento.ToString()) ? "''" : seq_zona_abastecimento.ToString()) : "''")
				,(dat_referencia != null ? (String.IsNullOrEmpty(dat_referencia.ToString()) ? "''" : dat_referencia.ToString()) : "''")
				,(seq_parametro != null ? (String.IsNullOrEmpty(seq_parametro.ToString()) ? "''" : seq_parametro.ToString()) : "''")
				,(des_parametro != null ? (String.IsNullOrEmpty(des_parametro.ToString()) ? "''" : des_parametro.ToString()) : "''")
				,(val_previstas != null ? (String.IsNullOrEmpty(val_previstas.ToString()) ? "''" : val_previstas.ToString()) : "''")
				,(val_realizadas != null ? (String.IsNullOrEmpty(val_realizadas.ToString()) ? "''" : val_realizadas.ToString()) : "''")
				,(val_fora_limite != null ? (String.IsNullOrEmpty(val_fora_limite.ToString()) ? "''" : val_fora_limite.ToString()) : "''")
				,(val_media != null ? (String.IsNullOrEmpty(val_media.ToString()) ? "''" : val_media.ToString()) : "''")
				
										
									);
            }
        }

		#endregion
    }
}
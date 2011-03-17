using System;
using GDA;
using System.Runtime.Serialization;
using Sinc_DATA.DAL;

namespace Sinc_DATA.Model
{
    /// <summary>
    /// Classe que representa a tabela ONP_PARAMETRO_RETENCAO.
    /// </summary>
    [PersistenceClass("ONP_PARAMETRO_RETENCAO")]
    [PersistenceBaseDAO(typeof(ParametroRetencaoDAO))]
    [Serializable]
    public class ParametroRetencao : Persistent
    {
		#region Metodos
		[PersistenceProperty("ind_retencao", PersistenceParameterType.Key)]
public string ind_retencao
	{get;set;}
	[PersistenceProperty("seq_faixa", PersistenceParameterType.Key)]
public double seq_faixa
	{get;set;}
	[PersistenceProperty("val_media_inicial")]
public double? val_media_inicial
	{get;set;}
	[PersistenceProperty("val_media_final")]
public double? val_media_final
	{get;set;}
	[PersistenceProperty("val_variacao_aviso")]
public double? val_variacao_aviso
	{get;set;}
	[PersistenceProperty("val_variacao_retencao")]
public double? val_variacao_retencao
	{get;set;}
	[PersistenceProperty("ind_unidade_variacao")]
public string ind_unidade_variacao
	{get;set;}
	
		#endregion
		
		#region Query Importacao
		        
        public string __ToSQL
        {
            get
            {
                return String.Format(@"
                                        INSERT INTO ONP_PARAMETRO_RETENCAO
										(
												ind_retencao
				,seq_faixa
				,val_media_inicial
				,val_media_final
				,val_variacao_aviso
				,val_variacao_retencao
				,ind_unidade_variacao
				
										)
                                        VALUES
										(
												'{0}'
					,{1}
					,{2}
					,{3}
					,{4}
					,{5}
					,'{6}'
					
										)"
												,(ind_retencao != null ? (String.IsNullOrEmpty(ind_retencao.ToString()) ? "''" : ind_retencao.ToString()) : "''")
				,(seq_faixa != null ? (String.IsNullOrEmpty(seq_faixa.ToString()) ? "''" : seq_faixa.ToString()) : "''")
				,(val_media_inicial != null ? (String.IsNullOrEmpty(val_media_inicial.ToString()) ? "''" : val_media_inicial.ToString()) : "''")
				,(val_media_final != null ? (String.IsNullOrEmpty(val_media_final.ToString()) ? "''" : val_media_final.ToString()) : "''")
				,(val_variacao_aviso != null ? (String.IsNullOrEmpty(val_variacao_aviso.ToString()) ? "''" : val_variacao_aviso.ToString()) : "''")
				,(val_variacao_retencao != null ? (String.IsNullOrEmpty(val_variacao_retencao.ToString()) ? "''" : val_variacao_retencao.ToString()) : "''")
				,(ind_unidade_variacao != null ? (String.IsNullOrEmpty(ind_unidade_variacao.ToString()) ? "''" : ind_unidade_variacao.ToString()) : "''")
				
										
									);
            }
        }

		#endregion
    }
}
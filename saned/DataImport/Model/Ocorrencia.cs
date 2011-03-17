using System;
using GDA;
using System.Runtime.Serialization;
using Sinc_DATA.DAL;

namespace Sinc_DATA.Model
{
    /// <summary>
    /// Classe que representa a tabela ONP_OCORRENCIA.
    /// </summary>
    [PersistenceClass("ONP_OCORRENCIA")]
    [PersistenceBaseDAO(typeof(OcorrenciaDAO))]
    [Serializable]
    public class Ocorrencia : Persistent
    {
		#region Metodos
		[PersistenceProperty("cod_ocorrencia", PersistenceParameterType.Key)]
public double cod_ocorrencia
	{get;set;}
	[PersistenceProperty("des_ocorrencia")]
public string des_ocorrencia
	{get;set;}
	[PersistenceProperty("des_mensagem")]
public string des_mensagem
	{get;set;}
	[PersistenceProperty("ind_grupo")]
public string ind_grupo
	{get;set;}
	[PersistenceProperty("ind_leitura")]
public string ind_leitura
	{get;set;}
	[PersistenceProperty("ind_consumo")]
public string ind_consumo
	{get;set;}
	[PersistenceProperty("ind_emite")]
public string ind_emite
	{get;set;}
	
		#endregion
		
		#region Query Importacao
		        
        public string __ToSQL
        {
            get
            {
                return String.Format(@"
                                        INSERT INTO ONP_OCORRENCIA
										(
												cod_ocorrencia
				,des_ocorrencia
				,des_mensagem
				,ind_grupo
				,ind_leitura
				,ind_consumo
				,ind_emite
				
										)
                                        VALUES
										(
												{0}
					,'{1}'
					,'{2}'
					,'{3}'
					,'{4}'
					,'{5}'
					,'{6}'
					
										)"
												,(cod_ocorrencia != null ? (String.IsNullOrEmpty(cod_ocorrencia.ToString()) ? "''" : cod_ocorrencia.ToString()) : "''")
				,(des_ocorrencia != null ? (String.IsNullOrEmpty(des_ocorrencia.ToString()) ? "''" : des_ocorrencia.ToString()) : "''")
				,(des_mensagem != null ? (String.IsNullOrEmpty(des_mensagem.ToString()) ? "''" : des_mensagem.ToString()) : "''")
				,(ind_grupo != null ? (String.IsNullOrEmpty(ind_grupo.ToString()) ? "''" : ind_grupo.ToString()) : "''")
				,(ind_leitura != null ? (String.IsNullOrEmpty(ind_leitura.ToString()) ? "''" : ind_leitura.ToString()) : "''")
				,(ind_consumo != null ? (String.IsNullOrEmpty(ind_consumo.ToString()) ? "''" : ind_consumo.ToString()) : "''")
				,(ind_emite != null ? (String.IsNullOrEmpty(ind_emite.ToString()) ? "''" : ind_emite.ToString()) : "''")
				
										
									);
            }
        }

		#endregion
    }
}
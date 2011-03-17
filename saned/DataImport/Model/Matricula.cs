using System;
using GDA;
using System.Runtime.Serialization;
using Sinc_DATA.DAL;

namespace Sinc_DATA.Model
{
    /// <summary>
    /// Classe que representa a tabela ONP_MATRICULA.
    /// </summary>
    [PersistenceClass("ONP_MATRICULA")]
    [PersistenceBaseDAO(typeof(MatriculaDAO))]
    [Serializable]
    public class Matricula : Persistent
    {
		#region Metodos
		[PersistenceProperty("seq_matricula", PersistenceParameterType.Key)]
public double seq_matricula
	{get;set;}
	[PersistenceProperty("seq_logradouro")]
public double? seq_logradouro
	{get;set;}
	[PersistenceProperty("seq_utilizacao_ligacao")]
public double? seq_utilizacao_ligacao
	{get;set;}
	[PersistenceProperty("nom_cliente")]
public string nom_cliente
	{get;set;}
	[PersistenceProperty("val_numero_imovel")]
public double? val_numero_imovel
	{get;set;}
	[PersistenceProperty("des_complemento")]
public string des_complemento
	{get;set;}
	[PersistenceProperty("ind_processado")]
public string ind_processado
	{get;set;}
	[PersistenceProperty("seq_rota")]
public double? seq_rota
	{get;set;}
	[PersistenceProperty("seq_leitura")]
public double? seq_leitura
	{get;set;}
	[PersistenceProperty("ind_impresso")]
public string ind_impresso
	{get;set;}
	[PersistenceProperty("des_cep")]
public string des_cep
	{get;set;}
	[PersistenceProperty("seq_zona_abastecimento")]
public double? seq_zona_abastecimento
	{get;set;}
	[PersistenceProperty("val_fotos_minima")]
public double? val_fotos_minima
	{get;set;}
	[PersistenceProperty("val_fotos_maxima")]
public double? val_fotos_maxima
	{get;set;}
	[PersistenceProperty("des_inscricao")]
public string des_inscricao
	{get;set;}
	[PersistenceProperty("des_endereco_alternativo")]
public string des_endereco_alternativo
	{get;set;}
	
		#endregion
		
		#region Query Importacao
		        
        public string __ToSQL
        {
            get
            {
                return String.Format(@"
                                        INSERT INTO ONP_MATRICULA
										(
												seq_matricula
				,seq_logradouro
				,seq_utilizacao_ligacao
				,nom_cliente
				,val_numero_imovel
				,des_complemento
				,ind_processado
				,seq_rota
				,seq_leitura
				,ind_impresso
				,des_cep
				,seq_zona_abastecimento
				,val_fotos_minima
				,val_fotos_maxima
				,des_inscricao
				,des_endereco_alternativo
				
										)
                                        VALUES
										(
												{0}
					,{1}
					,{2}
					,'{3}'
					,{4}
					,'{5}'
					,'{6}'
					,{7}
					,{8}
					,'{9}'
					,'{10}'
					,{11}
					,{12}
					,{13}
					,'{14}'
					,'{15}'
					
										)"
												,(seq_matricula != null ? (String.IsNullOrEmpty(seq_matricula.ToString()) ? "''" : seq_matricula.ToString()) : "''")
				,(seq_logradouro != null ? (String.IsNullOrEmpty(seq_logradouro.ToString()) ? "''" : seq_logradouro.ToString()) : "''")
				,(seq_utilizacao_ligacao != null ? (String.IsNullOrEmpty(seq_utilizacao_ligacao.ToString()) ? "''" : seq_utilizacao_ligacao.ToString()) : "''")
				,(nom_cliente != null ? (String.IsNullOrEmpty(nom_cliente.ToString()) ? "''" : nom_cliente.ToString()) : "''")
				,(val_numero_imovel != null ? (String.IsNullOrEmpty(val_numero_imovel.ToString()) ? "''" : val_numero_imovel.ToString()) : "''")
				,(des_complemento != null ? (String.IsNullOrEmpty(des_complemento.ToString()) ? "''" : des_complemento.ToString()) : "''")
				,(ind_processado != null ? (String.IsNullOrEmpty(ind_processado.ToString()) ? "''" : ind_processado.ToString()) : "''")
				,(seq_rota != null ? (String.IsNullOrEmpty(seq_rota.ToString()) ? "''" : seq_rota.ToString()) : "''")
				,(seq_leitura != null ? (String.IsNullOrEmpty(seq_leitura.ToString()) ? "''" : seq_leitura.ToString()) : "''")
				,(ind_impresso != null ? (String.IsNullOrEmpty(ind_impresso.ToString()) ? "''" : ind_impresso.ToString()) : "''")
				,(des_cep != null ? (String.IsNullOrEmpty(des_cep.ToString()) ? "''" : des_cep.ToString()) : "''")
				,(seq_zona_abastecimento != null ? (String.IsNullOrEmpty(seq_zona_abastecimento.ToString()) ? "''" : seq_zona_abastecimento.ToString()) : "''")
				,(val_fotos_minima != null ? (String.IsNullOrEmpty(val_fotos_minima.ToString()) ? "''" : val_fotos_minima.ToString()) : "''")
				,(val_fotos_maxima != null ? (String.IsNullOrEmpty(val_fotos_maxima.ToString()) ? "''" : val_fotos_maxima.ToString()) : "''")
				,(des_inscricao != null ? (String.IsNullOrEmpty(des_inscricao.ToString()) ? "''" : des_inscricao.ToString()) : "''")
				,(des_endereco_alternativo != null ? (String.IsNullOrEmpty(des_endereco_alternativo.ToString()) ? "''" : des_endereco_alternativo.ToString()) : "''")
				
										
									);
            }
        }

		#endregion
    }
}
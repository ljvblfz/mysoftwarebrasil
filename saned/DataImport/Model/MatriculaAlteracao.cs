using System;
using GDA;
using System.Runtime.Serialization;
using Sinc_DATA.DAL;

namespace Sinc_DATA.Model
{
    /// <summary>
    /// Classe que representa a tabela ONP_MATRICULA_ALTERACAO.
    /// </summary>
    [PersistenceClass("ONP_MATRICULA_ALTERACAO")]
    [PersistenceBaseDAO(typeof(MatriculaAlteracaoDAO))]
    [Serializable]
    public class MatriculaAlteracao : Persistent
    {
		#region Metodos
		[PersistenceProperty("seq_matricula", PersistenceParameterType.Key)]
public double seq_matricula
	{get;set;}
	[PersistenceProperty("ind_dado_alterado", PersistenceParameterType.Key)]
public string ind_dado_alterado
	{get;set;}
	[PersistenceProperty("seq_item", PersistenceParameterType.Key)]
public double seq_item
	{get;set;}
	[PersistenceProperty("des_conteudo_anterior")]
public string des_conteudo_anterior
	{get;set;}
	[PersistenceProperty("des_conteudo_novo")]
public string des_conteudo_novo
	{get;set;}
	
		#endregion
		
		#region Query Importacao
		        
        public string __ToSQL
        {
            get
            {
                return String.Format(@"
                                        INSERT INTO ONP_MATRICULA_ALTERACAO
										(
												seq_matricula
				,ind_dado_alterado
				,seq_item
				,des_conteudo_anterior
				,des_conteudo_novo
				
										)
                                        VALUES
										(
												{0}
					,'{1}'
					,{2}
					,'{3}'
					,'{4}'
					
										)"
												,(seq_matricula != null ? (String.IsNullOrEmpty(seq_matricula.ToString()) ? "''" : seq_matricula.ToString()) : "''")
				,(ind_dado_alterado != null ? (String.IsNullOrEmpty(ind_dado_alterado.ToString()) ? "''" : ind_dado_alterado.ToString()) : "''")
				,(seq_item != null ? (String.IsNullOrEmpty(seq_item.ToString()) ? "''" : seq_item.ToString()) : "''")
				,(des_conteudo_anterior != null ? (String.IsNullOrEmpty(des_conteudo_anterior.ToString()) ? "''" : des_conteudo_anterior.ToString()) : "''")
				,(des_conteudo_novo != null ? (String.IsNullOrEmpty(des_conteudo_novo.ToString()) ? "''" : des_conteudo_novo.ToString()) : "''")
				
										
									);
            }
        }

		#endregion
    }
}
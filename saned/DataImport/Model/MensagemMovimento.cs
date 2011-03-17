using System;
using GDA;
using System.Runtime.Serialization;
using Sinc_DATA.DAL;

namespace Sinc_DATA.Model
{
    /// <summary>
    /// Classe que representa a tabela ONP_MENSAGEM_MOVIMENTO.
    /// </summary>
    [PersistenceClass("ONP_MENSAGEM_MOVIMENTO")]
    [PersistenceBaseDAO(typeof(MensagemMovimentoDAO))]
    [Serializable]
    public class MensagemMovimento : Persistent
    {
		#region Metodos
		[PersistenceProperty("seq_mensagem_movimento", PersistenceParameterType.Key)]
public double seq_mensagem_movimento
	{get;set;}
	[PersistenceProperty("seq_matricula")]
public double? seq_matricula
	{get;set;}
	[PersistenceProperty("seq_roteiro")]
public double? seq_roteiro
	{get;set;}
	[PersistenceProperty("seq_grupo_fatura")]
public double? seq_grupo_fatura
	{get;set;}
	[PersistenceProperty("des_mensagem_movimento")]
public string des_mensagem_movimento
	{get;set;}
	[PersistenceProperty("dat_inicio")]
public DateTime? dat_inicio
	{get;set;}
	[PersistenceProperty("dat_final")]
public DateTime? dat_final
	{get;set;}
	[PersistenceProperty("seq_tipo_documento")]
public double? seq_tipo_documento
	{get;set;}
	
		#endregion
		
		#region Query Importacao
		        
        public string __ToSQL
        {
            get
            {
                return String.Format(@"
                                        INSERT INTO ONP_MENSAGEM_MOVIMENTO
										(
												seq_mensagem_movimento
				,seq_matricula
				,seq_roteiro
				,seq_grupo_fatura
				,des_mensagem_movimento
				,dat_inicio
				,dat_final
				,seq_tipo_documento
				
										)
                                        VALUES
										(
												{0}
					,{1}
					,{2}
					,{3}
					,'{4}'
					,'{5}'
					,'{6}'
					,{7}
					
										)"
												,(seq_mensagem_movimento != null ? (String.IsNullOrEmpty(seq_mensagem_movimento.ToString()) ? "''" : seq_mensagem_movimento.ToString()) : "''")
				,(seq_matricula != null ? (String.IsNullOrEmpty(seq_matricula.ToString()) ? "''" : seq_matricula.ToString()) : "''")
				,(seq_roteiro != null ? (String.IsNullOrEmpty(seq_roteiro.ToString()) ? "''" : seq_roteiro.ToString()) : "''")
				,(seq_grupo_fatura != null ? (String.IsNullOrEmpty(seq_grupo_fatura.ToString()) ? "''" : seq_grupo_fatura.ToString()) : "''")
				,(des_mensagem_movimento != null ? (String.IsNullOrEmpty(des_mensagem_movimento.ToString()) ? "''" : des_mensagem_movimento.ToString()) : "''")
				,(dat_inicio != null ? (String.IsNullOrEmpty(dat_inicio.ToString()) ? "''" : dat_inicio.ToString()) : "''")
				,(dat_final != null ? (String.IsNullOrEmpty(dat_final.ToString()) ? "''" : dat_final.ToString()) : "''")
				,(seq_tipo_documento != null ? (String.IsNullOrEmpty(seq_tipo_documento.ToString()) ? "''" : seq_tipo_documento.ToString()) : "''")
				
										
									);
            }
        }

		#endregion
    }
}
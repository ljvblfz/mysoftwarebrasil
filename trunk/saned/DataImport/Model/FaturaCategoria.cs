using System;
using GDA;
using System.Runtime.Serialization;
using Sinc_DATA.DAL;

namespace Sinc_DATA.Model
{
    /// <summary>
    /// Classe que representa a tabela ONP_FATURA_CATEGORIA.
    /// </summary>
    [PersistenceClass("ONP_FATURA_CATEGORIA")]
    [PersistenceBaseDAO(typeof(FaturaCategoriaDAO))]
    [Serializable]
    public class FaturaCategoria : Persistent
    {
		#region Metodos
		[PersistenceProperty("seq_categoria", PersistenceParameterType.Key)]
        public double seq_categoria
	    {get;set;}
        
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
        
        [PersistenceProperty("val_numero_economia")]
        public double val_numero_economia
        {get;set;}
        
        [PersistenceProperty("val_valor_faturado")]
        public double val_valor_faturado
        {get;set;}
	
		#endregion
		
		#region Query Importacao
		        
        public string __ToSQL
        {
            get
            {
                return String.Format(@"
                                        INSERT INTO ONP_FATURA_CATEGORIA
										(
												seq_categoria
				,seq_fatura
				,cod_referencia
				,seq_roteiro
				,seq_matricula
				,val_numero_economia
				,val_valor_faturado
				
										)
                                        VALUES
										(
												{0}
					,{1}
					,'{2}'
					,{3}
					,{4}
					,{5}
					,{6}
					
										)"
												,(seq_categoria != null ? (String.IsNullOrEmpty(seq_categoria.ToString()) ? "''" : seq_categoria.ToString()) : "''")
				                                ,(seq_fatura != null ? (String.IsNullOrEmpty(seq_fatura.ToString()) ? "''" : seq_fatura.ToString()) : "''")
				                                ,(cod_referencia != null ? (String.IsNullOrEmpty(cod_referencia.ToString()) ? "''" : cod_referencia.ToString()) : "''")
				                                ,(seq_roteiro != null ? (String.IsNullOrEmpty(seq_roteiro.ToString()) ? "''" : seq_roteiro.ToString()) : "''")
				                                ,(seq_matricula != null ? (String.IsNullOrEmpty(seq_matricula.ToString()) ? "''" : seq_matricula.ToString()) : "''")
				                                ,(val_numero_economia != null ? (String.IsNullOrEmpty(val_numero_economia.ToString()) ? "''" : val_numero_economia.ToString()) : "''")
				                                ,(val_valor_faturado != null ? (String.IsNullOrEmpty(val_valor_faturado.ToString()) ? "''" : val_valor_faturado.ToString()) : "''")
				
										
									);
            }
        }

		#endregion
    }
}
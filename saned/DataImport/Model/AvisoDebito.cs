using System;
using GDA;
using System.Runtime.Serialization;
using Sinc_DATA.DAL;

namespace Sinc_DATA.Model
{
    /// <summary>
    /// Classe que representa a tabela ONP_AVISO_DEBITO.
    /// </summary>
    [PersistenceClass("ONP_AVISO_DEBITO")]
    [PersistenceBaseDAO(typeof(AvisoDebitoDAO))]
    [Serializable]
    public class AvisoDebito : Persistent
    {
		#region Metodos
            [PersistenceProperty("seq_matricula", PersistenceParameterType.Key)]
            public double seq_matricula
            {get;set;}

            [PersistenceProperty("dat_emissao")]
            public DateTime dat_emissao
            {get;set;}

            [PersistenceProperty("ind_documento")]
            public string ind_documento
            {get;set;}

            [PersistenceProperty("ind_pagavel")]
            public string ind_pagavel
            {get;set;}

            [PersistenceProperty("val_quantidade_debito")]
            public double val_quantidade_debito
            {get;set;}

            [PersistenceProperty("val_impressoes")]
            public double val_impressoes
            {get;set;}

            [PersistenceProperty("ind_protocolado")]
            public string ind_protocolado
            {get;set;}

            [PersistenceProperty("seq_fatura")]
            public double seq_fatura
            {get;set;}
		#endregion
		
		#region Query Importacao
		        
        public string __ToSQL
        {
            get
            {
                return String.Format(@"
                                        INSERT INTO ONP_AVISO_DEBITO
										(
												seq_matricula
				                                ,dat_emissao
				                                ,ind_documento
				                                ,ind_pagavel
				                                ,val_quantidade_debito
				                                ,val_impressoes
				                                ,ind_protocolado
				                                ,seq_fatura
				
										)
                                        VALUES
										(
												{0}
					                            ,{1}
					                            ,'{2}'
					                            ,{3}
					                            ,{4}
					                            ,{5}
					                            ,'{6}'
					                            ,{7}
					
										)"
                                                , (seq_matricula != null ? (String.IsNullOrEmpty(seq_matricula.ToString()) ? "''" : seq_matricula.ToString()) : "''")
                                                , (dat_emissao != null ? (String.IsNullOrEmpty(dat_emissao.ToString()) ? "''" : "CONVERT(DATETIME,"+String.Format("{0:dd/MM/yyyy}", dat_emissao)+")") : "''")
				                                ,(ind_documento != null ? (String.IsNullOrEmpty(ind_documento.ToString()) ? "''" : ind_documento.ToString()) : "''")
				                                ,(ind_pagavel != null ? (String.IsNullOrEmpty(ind_pagavel.ToString()) ? "''" : ind_pagavel.ToString()) : "''")
				                                ,(val_quantidade_debito != null ? (String.IsNullOrEmpty(val_quantidade_debito.ToString()) ? "''" : val_quantidade_debito.ToString()) : "''")
				                                ,(val_impressoes != null ? (String.IsNullOrEmpty(val_impressoes.ToString()) ? "''" : val_impressoes.ToString()) : "''")
				                                ,(ind_protocolado != null ? (String.IsNullOrEmpty(ind_protocolado.ToString()) ? "''" : ind_protocolado.ToString()) : "''")
				                                ,(seq_fatura != null ? (String.IsNullOrEmpty(seq_fatura.ToString()) ? "''" : seq_fatura.ToString()) : "''")
				
										
									);
            }
        }

		#endregion
    }
}
using System;
using GDA;
using System.Runtime.Serialization;
using Sinc_DATA.DAL;

namespace Sinc_DATA.Model
{
    /// <summary>
    /// Classe que representa a tabela ONP_MOVIMENTO_FOTO.
    /// </summary>
    [PersistenceClass("ONP_MOVIMENTO_FOTO")]
    [PersistenceBaseDAO(typeof(MovimentoFotoDAO))]
    [Serializable]
    public class MovimentoFoto : Persistent
    {
		#region Metodos
		[PersistenceProperty("cod_referencia", PersistenceParameterType.Key)]
public string cod_referencia
	{get;set;}
	[PersistenceProperty("seq_roteiro", PersistenceParameterType.Key)]
public double seq_roteiro
	{get;set;}
	[PersistenceProperty("seq_matricula", PersistenceParameterType.Key)]
public double seq_matricula
	{get;set;}
	[PersistenceProperty("seq_foto", PersistenceParameterType.Key)]
public double seq_foto
	{get;set;}
	[PersistenceProperty("arq_foto")]
public string arq_foto
	{get;set;}
	[PersistenceProperty("des_caminho")]
public string des_caminho
	{get;set;}
	
		#endregion
		
		#region Query Importacao
		        
        public string __ToSQL
        {
            get
            {
                return String.Format(@"
                                        INSERT INTO ONP_MOVIMENTO_FOTO
										(
												cod_referencia
				,seq_roteiro
				,seq_matricula
				,seq_foto
				,arq_foto
				,des_caminho
				
										)
                                        VALUES
										(
												'{0}'
					,{1}
					,{2}
					,{3}
					,'{4}'
					,'{5}'
					
										)"
												,(cod_referencia != null ? (String.IsNullOrEmpty(cod_referencia.ToString()) ? "''" : cod_referencia.ToString()) : "''")
				,(seq_roteiro != null ? (String.IsNullOrEmpty(seq_roteiro.ToString()) ? "''" : seq_roteiro.ToString()) : "''")
				,(seq_matricula != null ? (String.IsNullOrEmpty(seq_matricula.ToString()) ? "''" : seq_matricula.ToString()) : "''")
				,(seq_foto != null ? (String.IsNullOrEmpty(seq_foto.ToString()) ? "''" : seq_foto.ToString()) : "''")
				,(arq_foto != null ? (String.IsNullOrEmpty(arq_foto.ToString()) ? "''" : arq_foto.ToString()) : "''")
				,(des_caminho != null ? (String.IsNullOrEmpty(des_caminho.ToString()) ? "''" : des_caminho.ToString()) : "''")
				
										
									);
            }
        }

		#endregion
    }
}
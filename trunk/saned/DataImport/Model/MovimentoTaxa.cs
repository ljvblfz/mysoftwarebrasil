using System;
using GDA;
using System.Runtime.Serialization;
using Sinc_DATA.DAL;

namespace Sinc_DATA.Model
{
    /// <summary>
    /// Classe que representa a tabela ONP_MOVIMENTO_TAXA.
    /// </summary>
    [PersistenceClass("ONP_MOVIMENTO_TAXA")]
    [PersistenceBaseDAO(typeof(MovimentoTaxaDAO))]
    [Serializable]
    public class MovimentoTaxa : Persistent
    {
		#region Metodos
		[PersistenceProperty("seq_taxa", PersistenceParameterType.Key)]
public double seq_taxa
	{get;set;}
	[PersistenceProperty("cod_referencia", PersistenceParameterType.Key)]
public string cod_referencia
	{get;set;}
	[PersistenceProperty("seq_matricula", PersistenceParameterType.Key)]
public double seq_matricula
	{get;set;}
	[PersistenceProperty("seq_categoria", PersistenceParameterType.Key)]
public double seq_categoria
	{get;set;}
	[PersistenceProperty("seq_roteiro", PersistenceParameterType.Key)]
public double seq_roteiro
	{get;set;}
	[PersistenceProperty("val_economias")]
public double? val_economias
	{get;set;}
	[PersistenceProperty("val_consumo_fixo")]
public double? val_consumo_fixo
	{get;set;}
	[PersistenceProperty("val_consumo_estimado")]
public double? val_consumo_estimado
	{get;set;}
	[PersistenceProperty("ind_situacao")]
public string ind_situacao
	{get;set;}
	
		#endregion
		
		#region Query Importacao
		        
        public string __ToSQL
        {
            get
            {
                return String.Format(@"
                                        INSERT INTO ONP_MOVIMENTO_TAXA
										(
												seq_taxa
				,cod_referencia
				,seq_matricula
				,seq_categoria
				,seq_roteiro
				,val_economias
				,val_consumo_fixo
				,val_consumo_estimado
				,ind_situacao
				
										)
                                        VALUES
										(
												{0}
					,'{1}'
					,{2}
					,{3}
					,{4}
					,{5}
					,{6}
					,{7}
					,'{8}'
					
										)"
												,(seq_taxa != null ? (String.IsNullOrEmpty(seq_taxa.ToString()) ? "''" : seq_taxa.ToString()) : "''")
				,(cod_referencia != null ? (String.IsNullOrEmpty(cod_referencia.ToString()) ? "''" : cod_referencia.ToString()) : "''")
				,(seq_matricula != null ? (String.IsNullOrEmpty(seq_matricula.ToString()) ? "''" : seq_matricula.ToString()) : "''")
				,(seq_categoria != null ? (String.IsNullOrEmpty(seq_categoria.ToString()) ? "''" : seq_categoria.ToString()) : "''")
				,(seq_roteiro != null ? (String.IsNullOrEmpty(seq_roteiro.ToString()) ? "''" : seq_roteiro.ToString()) : "''")
				,(val_economias != null ? (String.IsNullOrEmpty(val_economias.ToString()) ? "''" : val_economias.ToString()) : "''")
				,(val_consumo_fixo != null ? (String.IsNullOrEmpty(val_consumo_fixo.ToString()) ? "''" : val_consumo_fixo.ToString()) : "''")
				,(val_consumo_estimado != null ? (String.IsNullOrEmpty(val_consumo_estimado.ToString()) ? "''" : val_consumo_estimado.ToString()) : "''")
				,(ind_situacao != null ? (String.IsNullOrEmpty(ind_situacao.ToString()) ? "''" : ind_situacao.ToString()) : "''")
				
										
									);
            }
        }

		#endregion
    }
}
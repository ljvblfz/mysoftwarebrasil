using System;
using GDA;
using System.Runtime.Serialization;
using Sinc_DATA.DAL;

namespace Sinc_DATA.Model
{
    /// <summary>
    /// Classe que representa a tabela ONP_HIDROMETRO.
    /// </summary>
    [PersistenceClass("ONP_HIDROMETRO")]
    [PersistenceBaseDAO(typeof(HidrometroDAO))]
    [Serializable]
    public class Hidrometro : Persistent
    {
		#region Metodos
		[PersistenceProperty("cod_hidrometro", PersistenceParameterType.Key)]
public string cod_hidrometro
	{get;set;}
	[PersistenceProperty("seq_matricula", PersistenceParameterType.Key)]
public double seq_matricula
	{get;set;}
	[PersistenceProperty("seq_local")]
public double? seq_local
	{get;set;}
	[PersistenceProperty("cod_marca")]
public string cod_marca
	{get;set;}
	[PersistenceProperty("seq_tamanho_hidrometro")]
public double? seq_tamanho_hidrometro
	{get;set;}
	[PersistenceProperty("val_numero_digitos")]
public double? val_numero_digitos
	{get;set;}
	[PersistenceProperty("seq_diametro_ligacao")]
public double? seq_diametro_ligacao
	{get;set;}
	[PersistenceProperty("dat_fabricacao")]
public DateTime? dat_fabricacao
	{get;set;}
	[PersistenceProperty("dat_aquisicao")]
public DateTime? dat_aquisicao
	{get;set;}
	[PersistenceProperty("des_classe")]
public string des_classe
	{get;set;}
	
		#endregion
		
		#region Query Importacao
		        
        public string __ToSQL
        {
            get
            {
                return String.Format(@"
                                        INSERT INTO ONP_HIDROMETRO
										(
												cod_hidrometro
				,seq_matricula
				,seq_local
				,cod_marca
				,seq_tamanho_hidrometro
				,val_numero_digitos
				,seq_diametro_ligacao
				,dat_fabricacao
				,dat_aquisicao
				,des_classe
				
										)
                                        VALUES
										(
												'{0}'
					,{1}
					,{2}
					,'{3}'
					,{4}
					,{5}
					,{6}
					,'{7}'
					,'{8}'
					,'{9}'
					
										)"
												,(cod_hidrometro != null ? (String.IsNullOrEmpty(cod_hidrometro.ToString()) ? "''" : cod_hidrometro.ToString()) : "''")
				,(seq_matricula != null ? (String.IsNullOrEmpty(seq_matricula.ToString()) ? "''" : seq_matricula.ToString()) : "''")
				,(seq_local != null ? (String.IsNullOrEmpty(seq_local.ToString()) ? "''" : seq_local.ToString()) : "''")
				,(cod_marca != null ? (String.IsNullOrEmpty(cod_marca.ToString()) ? "''" : cod_marca.ToString()) : "''")
				,(seq_tamanho_hidrometro != null ? (String.IsNullOrEmpty(seq_tamanho_hidrometro.ToString()) ? "''" : seq_tamanho_hidrometro.ToString()) : "''")
				,(val_numero_digitos != null ? (String.IsNullOrEmpty(val_numero_digitos.ToString()) ? "''" : val_numero_digitos.ToString()) : "''")
				,(seq_diametro_ligacao != null ? (String.IsNullOrEmpty(seq_diametro_ligacao.ToString()) ? "''" : seq_diametro_ligacao.ToString()) : "''")
				,(dat_fabricacao != null ? (String.IsNullOrEmpty(dat_fabricacao.ToString()) ? "''" : dat_fabricacao.ToString()) : "''")
				,(dat_aquisicao != null ? (String.IsNullOrEmpty(dat_aquisicao.ToString()) ? "''" : dat_aquisicao.ToString()) : "''")
				,(des_classe != null ? (String.IsNullOrEmpty(des_classe.ToString()) ? "''" : des_classe.ToString()) : "''")
				
										
									);
            }
        }

		#endregion
    }
}
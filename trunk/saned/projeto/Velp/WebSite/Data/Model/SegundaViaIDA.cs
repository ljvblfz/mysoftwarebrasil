using System;
using GDA;
using System.Runtime.Serialization;
using Data.DAL;

namespace Data.Model
{
    /// <summary>
    /// Classe que representa a tabela IDA_SEGUNDAS_VIAS.
    /// </summary>
    [PersistenceClass("IDA_SEGUNDAS_VIAS")]
    [PersistenceBaseDAO(typeof(SegundaViaIDADAO))]
    [Serializable]
    public class SegundaViaIDA : Persistent
    {
    	#region Local Variables
		private int  _Grupo;
private int  _CDC;
private DateTime  _Referencia;
private DateTime  _Data_Vencimento;
private DateTime  _Data_Leitura;
private DateTime  _Data_Leitura_Anterior;
private int?  _Leitura_Atual;
private int?  _Leitura_Anterior;
private int?  _Dias_Consumo;
private int?  _Consumo_Faturado;
private int?  _Media;
private DateTime?  _Ref_Cons_1;
private int?  _Cons_1;
private DateTime?  _Ref_Cons_2;
private int?  _Cons_2;
private DateTime?  _Ref_Cons_3;
private int?  _Cons_3;
private DateTime?  _Ref_Cons_4;
private int?  _Cons_4;
private DateTime?  _Ref_Cons_5;
private int?  _Cons_5;
private DateTime?  _Ref_Cons_6;
private int?  _Cons_6;
private string  _Servico_01;
private decimal  _Valor_01;
private string  _Servico_02;
private decimal?  _Valor_02;
private string  _Servico_03;
private decimal?  _Valor_03;
private string  _Servico_04;
private decimal?  _Valor_04;
private string  _Servico_05;
private decimal?  _Valor_05;
private string  _Servico_06;
private decimal?  _Valor_06;
private string  _Servico_07;
private decimal?  _Valor_07;
private string  _Servico_08;
private decimal?  _Valor_08;
private string  _Servico_09;
private decimal?  _Valor_09;
private decimal  _Valor_Total;
private string  _Codigo_Barras;
private int?  _Ocorrencia;

		#endregion

		#region Metodos
		[PersistenceProperty("Grupo")]
public int Grupo { get; set; }

[PersistenceProperty("CDC")]
public int CDC { get; set; }

[PersistenceProperty("Referencia")]
public DateTime Referencia { get; set; }

[PersistenceProperty("Data_Vencimento")]
public DateTime Data_Vencimento { get; set; }

[PersistenceProperty("Data_Leitura")]
public DateTime Data_Leitura { get; set; }

[PersistenceProperty("Data_Leitura_Anterior")]
public DateTime Data_Leitura_Anterior { get; set; }

[PersistenceProperty("Leitura_Atual")]
public int? Leitura_Atual { get; set; }

[PersistenceProperty("Leitura_Anterior")]
public int? Leitura_Anterior { get; set; }

[PersistenceProperty("Dias_Consumo")]
public int? Dias_Consumo { get; set; }

[PersistenceProperty("Consumo_Faturado")]
public int? Consumo_Faturado { get; set; }

[PersistenceProperty("Media")]
public int? Media { get; set; }

[PersistenceProperty("Ref_Cons_1")]
public DateTime? Ref_Cons_1 { get; set; }

[PersistenceProperty("Cons_1")]
public int? Cons_1 { get; set; }

[PersistenceProperty("Ref_Cons_2")]
public DateTime? Ref_Cons_2 { get; set; }

[PersistenceProperty("Cons_2")]
public int? Cons_2 { get; set; }

[PersistenceProperty("Ref_Cons_3")]
public DateTime? Ref_Cons_3 { get; set; }

[PersistenceProperty("Cons_3")]
public int? Cons_3 { get; set; }

[PersistenceProperty("Ref_Cons_4")]
public DateTime? Ref_Cons_4 { get; set; }

[PersistenceProperty("Cons_4")]
public int? Cons_4 { get; set; }

[PersistenceProperty("Ref_Cons_5")]
public DateTime? Ref_Cons_5 { get; set; }

[PersistenceProperty("Cons_5")]
public int? Cons_5 { get; set; }

[PersistenceProperty("Ref_Cons_6")]
public DateTime? Ref_Cons_6 { get; set; }

[PersistenceProperty("Cons_6")]
public int? Cons_6 { get; set; }

[PersistenceProperty("Servico_01")]
public string Servico_01 { get; set; }

[PersistenceProperty("Valor_01")]
public decimal Valor_01 { get; set; }

[PersistenceProperty("Servico_02")]
public string Servico_02 { get; set; }

[PersistenceProperty("Valor_02")]
public decimal? Valor_02 { get; set; }

[PersistenceProperty("Servico_03")]
public string Servico_03 { get; set; }

[PersistenceProperty("Valor_03")]
public decimal? Valor_03 { get; set; }

[PersistenceProperty("Servico_04")]
public string Servico_04 { get; set; }

[PersistenceProperty("Valor_04")]
public decimal? Valor_04 { get; set; }

[PersistenceProperty("Servico_05")]
public string Servico_05 { get; set; }

[PersistenceProperty("Valor_05")]
public decimal? Valor_05 { get; set; }

[PersistenceProperty("Servico_06")]
public string Servico_06 { get; set; }

[PersistenceProperty("Valor_06")]
public decimal? Valor_06 { get; set; }

[PersistenceProperty("Servico_07")]
public string Servico_07 { get; set; }

[PersistenceProperty("Valor_07")]
public decimal? Valor_07 { get; set; }

[PersistenceProperty("Servico_08")]
public string Servico_08 { get; set; }

[PersistenceProperty("Valor_08")]
public decimal? Valor_08 { get; set; }

[PersistenceProperty("Servico_09")]
public string Servico_09 { get; set; }

[PersistenceProperty("Valor_09")]
public decimal? Valor_09 { get; set; }

[PersistenceProperty("Valor_Total")]
public decimal Valor_Total { get; set; }

[PersistenceProperty("Codigo_Barras")]
public string Codigo_Barras { get; set; }

[PersistenceProperty("Ocorrencia")]
public int? Ocorrencia { get; set; }


		#endregion
    }
}
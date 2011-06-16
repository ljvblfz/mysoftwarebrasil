namespace Core.Model
{
	// Business class Anuncio generated from Anuncio
	// alexis [2011-06-13] Created

	using System;
	using System.ComponentModel;
	using Castle.ActiveRecord;
    using System.Collections;
    using System.Collections.Generic;
    using Castle.Components.Validator;

	[ActiveRecord("Anuncio")]
	public partial class Anuncio 
		: ActiveRecordValidationBase<Anuncio> 
	{

		#region Property_Names

		public static string Prop_anuncioId = "anuncioId";
		public static string Prop_anuncioValorHora = "anuncioValorHora";
		public static string Prop_anucioProficional = "anucioProficional";
		public static string Prop_anuncioTitulo = "anuncioTitulo";
		public static string Prop_anuncioTexto = "anuncioTexto";
		public static string Prop_membroId = "membroId";

		#endregion

		#region Private_Variables

		private int _anuncioid;
		private float _anuncioValorHora;
		private bool _anucioProficional;
		private string _anuncioTitulo;
		private string _anuncioTexto;
		private Membro _membroId;


		#endregion

		#region Constructors

		public Anuncio()
		{
		}

		public Anuncio(
			int p_anuncioid,
			float p_anuncioValorHora,
			bool p_anucioProficional,
			string p_anuncioTitulo,
			string p_anuncioTexto,
			Membro p_membroId)
		{
			_anuncioid = p_anuncioid;
			_anuncioValorHora = p_anuncioValorHora;
			_anucioProficional = p_anucioProficional;
			_anuncioTitulo = p_anuncioTitulo;
			_anuncioTexto = p_anuncioTexto;
			_membroId = p_membroId;
		}

		#endregion

		#region Properties

		[PrimaryKey("anuncioId", Access = PropertyAccess.NosetterLowercaseUnderscore)]
		public int anuncioId
		{
			get { return _anuncioid; }
		}

		[Property("anuncioValorHora", Access = PropertyAccess.NosetterCamelcaseUnderscore, NotNull = true)]
		public float anuncioValorHora
		{
			get { return _anuncioValorHora; }
			set { _anuncioValorHora = value; }
		}

		[Property("anucioProficional", Access = PropertyAccess.NosetterCamelcaseUnderscore, NotNull = true)]
		public bool anucioProficional
		{
			get { return _anucioProficional; }
			set { _anucioProficional = value; }
		}

		[Property("anuncioTitulo", Access = PropertyAccess.NosetterCamelcaseUnderscore, NotNull = true, Length = 255), ValidateLength(1, 255)]
		public string anuncioTitulo
		{
			get { return _anuncioTitulo; }
			set { _anuncioTitulo = value; }
		}

		[Property("anuncioTexto", Access = PropertyAccess.NosetterCamelcaseUnderscore, NotNull = true, ColumnType = "StringClob")]
		public string anuncioTexto
		{
			get { return _anuncioTexto; }
			set { _anuncioTexto = value; }
		}

        [BelongsTo("membroId", Type = typeof(Membro), Access = PropertyAccess.NosetterCamelcaseUnderscore)]
		public Membro membroId
		{
			get { return _membroId; }
			set { _membroId = value; }
		}

		#endregion

	} // Anuncio
}


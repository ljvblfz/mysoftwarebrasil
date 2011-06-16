namespace Core.Model
{
	// Business class ComunidadeMembro generated from ComunidadeMembro
	// alexis [2011-06-13] Created

	using System;
	using System.ComponentModel;
	using Castle.ActiveRecord;
    using System.Collections;
    using System.Collections.Generic;
    using Castle.Components.Validator;

	[ActiveRecord("ComunidadeMembro")]
	public partial class ComunidadeMembro 
		: ActiveRecordValidationBase<ComunidadeMembro> 
	{

		#region Property_Names

		public static string Prop_comunidadeId = "comunidadeId";
		public static string Prop_membroId = "membroId";
		public static string Prop_comunidadeMembromediador = "comunidadeMembromediador";

		#endregion

		#region Private_Variables

		private Comunidade _comunidadeid;
		private Membro _membroid;
		private bool _comunidadeMembromediador;


		#endregion

		#region Constructors

		public ComunidadeMembro()
		{
		}

		public ComunidadeMembro(
			Comunidade p_comunidadeid,
			Membro p_membroid,
			bool p_comunidadeMembromediador)
		{
			_comunidadeid = p_comunidadeid;
			_membroid = p_membroid;
			_comunidadeMembromediador = p_comunidadeMembromediador;
		}

		#endregion

		#region Properties

		[PrimaryKey("comunidadeId", Access = PropertyAccess.NosetterLowercaseUnderscore)]
		public Comunidade comunidadeId
		{
			get { return _comunidadeid; }
		}

		[PrimaryKey("membroId", Access = PropertyAccess.NosetterLowercaseUnderscore)]
		public Membro membroId
		{
			get { return _membroid; }
		}

		[Property("comunidadeMembromediador", Access = PropertyAccess.NosetterCamelcaseUnderscore, NotNull = true)]
		public bool comunidadeMembromediador
		{
			get { return _comunidadeMembromediador; }
			set { _comunidadeMembromediador = value; }
		}

		#endregion

	} // ComunidadeMembro
}


namespace Core.Model
{
	// Business class EncontroMembro generated from EncontroMembro
	// alexis [2011-06-13] Created

	using System;
	using System.ComponentModel;
	using Castle.ActiveRecord;
    using System.Collections;
    using System.Collections.Generic;
    using Castle.Components.Validator;

	[ActiveRecord("EncontroMembro")]
	public partial class EncontroMembro 
		: ActiveRecordValidationBase<EncontroMembro> 
	{

		#region Property_Names

		public static string Prop_membroId = "membroId";
		public static string Prop_encontroId = "encontroId";
		public static string Prop_encontroMembroCriador = "encontroMembroCriador";

		#endregion

		#region Private_Variables

		private Membro _membroid;
		private Encontro _encontroid;
		private bool _encontroMembroCriador;


		#endregion

		#region Constructors

		public EncontroMembro()
		{
		}

		public EncontroMembro(
			Membro p_membroid,
			Encontro p_encontroid,
			bool p_encontroMembroCriador)
		{
			_membroid = p_membroid;
			_encontroid = p_encontroid;
			_encontroMembroCriador = p_encontroMembroCriador;
		}

		#endregion

		#region Properties

		[PrimaryKey("membroId", Access = PropertyAccess.NosetterLowercaseUnderscore)]
		public Membro membroId
		{
			get { return _membroid; }
		}

		[PrimaryKey("encontroId", Access = PropertyAccess.NosetterLowercaseUnderscore)]
		public Encontro encontroId
		{
			get { return _encontroid; }
		}

		[Property("encontroMembroCriador", Access = PropertyAccess.NosetterCamelcaseUnderscore, NotNull = true)]
		public bool encontroMembroCriador
		{
			get { return _encontroMembroCriador; }
			set { _encontroMembroCriador = value; }
		}

		#endregion

	} // EncontroMembro
}


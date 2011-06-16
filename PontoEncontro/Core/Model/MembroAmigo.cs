namespace Core.Model
{
	// Business class MembroAmigo generated from MembroAmigo
	// alexis [2011-06-13] Created

	using System;
	using System.ComponentModel;
	using Castle.ActiveRecord;
    using System.Collections;
    using System.Collections.Generic;
    using Castle.Components.Validator;

	[ActiveRecord("MembroAmigo")]
	public partial class MembroAmigo 
		: ActiveRecordValidationBase<MembroAmigo> 
	{

		#region Property_Names

		public static string Prop_membroId = "membroId";
		public static string Prop_amigoId = "amigoId";

		#endregion

		#region Private_Variables

		private Membro _membroid;
		private Amigo _amigoid;


		#endregion

		#region Constructors

		public MembroAmigo()
		{
		}

		public MembroAmigo(
			Membro p_membroid,
			Amigo p_amigoid)
		{
			_membroid = p_membroid;
			_amigoid = p_amigoid;
		}

		#endregion

		#region Properties

		[PrimaryKey("membroId", Access = PropertyAccess.NosetterLowercaseUnderscore)]
		public Membro membroId
		{
			get { return _membroid; }
		}

		[PrimaryKey("amigoId", Access = PropertyAccess.NosetterLowercaseUnderscore)]
		public Amigo amigoId
		{
			get { return _amigoid; }
		}

		#endregion

	} // MembroAmigo
}


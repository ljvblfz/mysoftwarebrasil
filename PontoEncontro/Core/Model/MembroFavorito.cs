namespace Core.Model
{
	// Business class MembroFavorito generated from MembroFavorito
	// alexis [2011-06-13] Created

	using System;
	using System.ComponentModel;
	using Castle.ActiveRecord;
    using System.Collections;
    using System.Collections.Generic;
    using Castle.Components.Validator;

	[ActiveRecord("MembroFavorito")]
	public partial class MembroFavorito 
		: ActiveRecordValidationBase<MembroFavorito> 
	{

		#region Property_Names

		public static string Prop_membroId = "membroId";
		public static string Prop_favoritosId = "favoritosId";

		#endregion

		#region Private_Variables

		private Membro _membroid;
		private Favorito _favoritosid;


		#endregion

		#region Constructors

		public MembroFavorito()
		{
		}

		public MembroFavorito(
			Membro p_membroid,
			Favorito p_favoritosid)
		{
			_membroid = p_membroid;
			_favoritosid = p_favoritosid;
		}

		#endregion

		#region Properties

		[PrimaryKey("membroId", Access = PropertyAccess.NosetterLowercaseUnderscore)]
		public Membro membroId
		{
			get { return _membroid; }
		}

		[PrimaryKey("favoritosId", Access = PropertyAccess.NosetterLowercaseUnderscore)]
		public Favorito favoritosId
		{
			get { return _favoritosid; }
		}

		#endregion

	} // MembroFavorito
}


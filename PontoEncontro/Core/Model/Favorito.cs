namespace Core.Model
{
	// Business class Favorito generated from Favoritos
	// alexis [2011-06-13] Created

	using System;
	using System.ComponentModel;
	using Castle.ActiveRecord;
    using System.Collections;
    using System.Collections.Generic;
    using Castle.Components.Validator;

	[ActiveRecord("Favoritos")]
	public partial class Favorito 
		: ActiveRecordValidationBase<Favorito> 
	{

		#region Property_Names

		public static string Prop_favoritosId = "favoritosId";

		#endregion

		#region Private_Variables

		private int _favoritosid;

		private IList _MembroFavorito = new List<MembroFavorito>();

		#endregion

		#region Constructors

		public Favorito()
		{
		}

		public Favorito(
			int p_favoritosid)
		{
			_favoritosid = p_favoritosid;
		}

		#endregion

		#region Properties

		[PrimaryKey("favoritosId", Access = PropertyAccess.NosetterLowercaseUnderscore)]
		public int favoritosId
		{
			get { return _favoritosid; }
		}

	[HasMany(typeof(MembroFavorito), Table="MembroFavorito", ColumnKey="favoritosId")]
	public IList MembroFavorito
	{
	    get { return _MembroFavorito; }
	    set { _MembroFavorito = value; }
	}
		#endregion

	} // Favorito
}


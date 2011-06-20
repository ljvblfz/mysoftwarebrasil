namespace CorePontoEncontro.Model
{
	// Business class MembroFavorito generated from MembroFavorito
	// alexis [2011-06-13] Created

	using System;
	using System.ComponentModel;
	using Castle.ActiveRecord;
    using System.Collections;
    using System.Collections.Generic;
    using Castle.Components.Validator;
    using Iesi.Collections;

	[ActiveRecord("MembroFavorito")]
	public partial class MembroFavorito : ActiveRecordValidationBase<MembroFavorito> 
	{

		#region Private_Variables

        private ISet _membroid;
        private ISet _favoritosid;
        private int _membroFavoritoId;

		#endregion

        #region Constructors

        public MembroFavorito()
		{
            _membroid = new HybridSet();
            _favoritosid = new HybridSet();
		}

		#endregion

		#region Properties

        [PrimaryKey(PrimaryKeyType.Native, "membroFavoritoId")]
        public int membroFavoritoId
        {
            get { return _membroFavoritoId; }
            set { _membroFavoritoId = value; }
        }

        [HasAndBelongsToMany(typeof(Membro),
        Table = "MembroFavorito",
        CompositeKeyColumnRefs = new string[] { "membroId", "membroId" },
        ColumnKey = "membroFavoritoId",
        Lazy = true,
        Inverse = true,
        Cascade = ManyRelationCascadeEnum.SaveUpdate)]
        public ISet membroId
		{
			get { return _membroid; }
            set { _membroid = value; }
		}

        [HasAndBelongsToMany(typeof(Favorito),
        Table = "MembroFavorito",
        CompositeKeyColumnRefs = new string[] { "favoritosId", "favoritosId" },
        ColumnKey = "membroFavoritoId",
        Lazy = true,
        Inverse = true,
        Cascade = ManyRelationCascadeEnum.SaveUpdate)]
        public ISet favoritosId
		{
			get { return _favoritosid; }
            set { _favoritosid = value; }
		}

		#endregion

	} // MembroFavorito
}


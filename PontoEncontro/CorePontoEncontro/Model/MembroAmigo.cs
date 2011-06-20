namespace CorePontoEncontro.Model
{
	// Business class MembroAmigo generated from MembroAmigo
	// alexis [2011-06-13] Created

	using System;
	using System.ComponentModel;
	using Castle.ActiveRecord;
    using System.Collections;
    using System.Collections.Generic;
    using Castle.Components.Validator;
    using Iesi.Collections;

	[ActiveRecord("MembroAmigo")]
	public partial class MembroAmigo : ActiveRecordValidationBase<MembroAmigo> 
	{

		#region Private_Variables

        private ISet _membroid;
        private ISet _amigoid;
        private int _membroAmigoId;

		#endregion

		#region Constructors

		public MembroAmigo()
		{
            _membroid = new HybridSet();
            _amigoid = new HybridSet();
		}

		#endregion

		#region Properties

        [PrimaryKey(PrimaryKeyType.Native, "membroAmigoId")]
        public int membroAmigoId
        {
            get { return _membroAmigoId; }
            set { _membroAmigoId = value; }
        }

        [HasAndBelongsToMany(typeof(Membro),
        Table = "MembroAmigo",
        CompositeKeyColumnRefs = new string[] { "membroId", "membroId" },
        ColumnKey = "membroAmigoId",
        Lazy = true,
        Inverse = true,
        Cascade = ManyRelationCascadeEnum.SaveUpdate)]
        public ISet membroId
		{
			get { return _membroid; }
            set { _membroid = value; }
		}

        [HasAndBelongsToMany(typeof(Amigo),
        Table = "MembroAmigo",
        CompositeKeyColumnRefs = new string[] { "amigoId", "amigoId" },
        ColumnKey = "membroAmigoId",
        Lazy = true,
        Inverse = true,
        Cascade = ManyRelationCascadeEnum.SaveUpdate)]
        public ISet amigoId
		{
			get { return _amigoid; }
            set { _amigoid = value; }
		}

		#endregion

	} // MembroAmigo
}


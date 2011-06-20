namespace CorePontoEncontro.Model
{
	// Business class EncontroMembro generated from EncontroMembro
	// alexis [2011-06-13] Created

	using System;
	using System.ComponentModel;
	using Castle.ActiveRecord;
    using System.Collections;
    using System.Collections.Generic;
    using Castle.Components.Validator;
    using Iesi.Collections;

	[ActiveRecord("EncontroMembro")]
	public partial class EncontroMembro : ActiveRecordValidationBase<EncontroMembro> 
	{

		#region Private_Variables

        private ISet _membroid;
        private ISet _encontroid;
        private int _encontroMembroId;

		#endregion

		#region Constructors

		public EncontroMembro()
		{
            _membroid = new HybridSet();
            _encontroid = new HybridSet();
		}

		#endregion

		#region Properties

        [PrimaryKey(PrimaryKeyType.Native, "encontroMembroId")]
        public int encontroMembroId
        {
            get { return _encontroMembroId; }
            set { _encontroMembroId = value; }
        }

        [HasAndBelongsToMany(typeof(Membro),
        Table = "EncontroMembro",
        CompositeKeyColumnRefs = new string[] { "membroId", "membroId" },
        ColumnKey = "encontroMembroId",
        Lazy = true,
        Inverse = true,
        Cascade = ManyRelationCascadeEnum.SaveUpdate)]
        public ISet membroId
		{
			get { return _membroid; }
            set { _membroid = value; }
		}

        [HasAndBelongsToMany(typeof(Encontro),
        Table = "EncontroMembro",
        CompositeKeyColumnRefs = new string[] { "encontroId", "encontroId" },
        ColumnKey = "encontroMembroId",
        Lazy = true,
        Inverse = true,
        Cascade = ManyRelationCascadeEnum.SaveUpdate)]
        public ISet encontroId
		{
			get { return _encontroid; }
            set { _encontroid = value; }
		}

		#endregion

	} // EncontroMembro
}


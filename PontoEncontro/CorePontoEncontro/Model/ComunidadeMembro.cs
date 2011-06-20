namespace CorePontoEncontro.Model
{
	// Business class ComunidadeMembro generated from ComunidadeMembro
	// alexis [2011-06-13] Created

	using System;
	using System.ComponentModel;
	using Castle.ActiveRecord;
    using System.Collections;
    using System.Collections.Generic;
    using Castle.Components.Validator;
    using Iesi.Collections;

	[ActiveRecord("ComunidadeMembro")]
	public partial class ComunidadeMembro : ActiveRecordValidationBase<ComunidadeMembro> 
	{

		#region Private_Variables

        private ISet _comunidadeid;
        private ISet _membroid;
        private int _comunidadeMembroId;

        #endregion

		#region Constructors

		public ComunidadeMembro()
		{
            _comunidadeid = new HybridSet();
            _membroid = new HybridSet();
		}

		#endregion

		#region Properties

        [PrimaryKey(PrimaryKeyType.Native, "comunidadeMembroId")]
        public int comunidadeMembroId
        {
            get { return _comunidadeMembroId; }
            set { _comunidadeMembroId = value; }
        }

        [HasAndBelongsToMany(typeof(Comunidade),
        Table = "ComunidadeMembro",
        CompositeKeyColumnRefs = new string[] { "comunidadeId", "comunidadeId" },
        ColumnKey = "ComunidadeMembroId",
        Lazy = true,
        Inverse = true,
        Cascade = ManyRelationCascadeEnum.SaveUpdate)]
        public ISet comunidadeId
		{
			get { return _comunidadeid; }
            set { _comunidadeid = value; }
		}


        [HasAndBelongsToMany(typeof(Membro),
        Table = "ComunidadeMembro",
        CompositeKeyColumnRefs = new string[] { "membroId", "membroId" },
        ColumnKey = "ComunidadeMembroId",
        Lazy = true,
        Inverse = true,
        Cascade = ManyRelationCascadeEnum.SaveUpdate)]
		public ISet membroId
		{
			get { return _membroid; }
            set { _membroid = value; }
		}

		#endregion

	} // ComunidadeMembro
}


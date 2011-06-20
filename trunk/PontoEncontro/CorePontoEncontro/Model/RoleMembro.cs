namespace CorePontoEncontro.Model
{
	// Business class RoleMembro generated from RoleMembro
	// alexis [2011-06-13] Created

	using System;
	using System.ComponentModel;
	using Castle.ActiveRecord;
    using Iesi.Collections;

	[ActiveRecord("RoleMembro")]
	public partial class RoleMembro : ActiveRecordValidationBase<RoleMembro> 
	{

		#region Private_Variables

        private ISet _roleid;
        private ISet _membroid;
        private int _roleMembroId;

		#endregion

		#region Constructors

		public RoleMembro()
		{
            _roleid = new HybridSet();
            _membroid = new HybridSet();
		}

		#endregion

		#region Properties


        [PrimaryKey(PrimaryKeyType.Native, "roleMembroId")]
        public int roleMembroId
        {
            get { return _roleMembroId; }
            set { _roleMembroId = value; }
        }

        [HasAndBelongsToMany(typeof(Role),
        Table = "RoleMembro",
        CompositeKeyColumnRefs = new string[] { "RoleId", "RoleId" },
        ColumnKey = "roleMembroId",
        Lazy = true,
        Inverse = true,
        Cascade = ManyRelationCascadeEnum.SaveUpdate)]
        public ISet RoleId
		{
			get { return _roleid; }
            set { _roleid = value; }
		}

        [HasAndBelongsToMany(typeof(Membro),
        Table = "RoleMembro",
        CompositeKeyColumnRefs = new string[] { "membroId", "membroId" },
        ColumnKey = "roleMembroId",
        Lazy = true,
        Inverse = true,
        Cascade = ManyRelationCascadeEnum.SaveUpdate)]
        public ISet membroId
		{
			get { return _membroid; }
            set { _membroid = value; }
		}

		#endregion

	} // RoleMembro
}


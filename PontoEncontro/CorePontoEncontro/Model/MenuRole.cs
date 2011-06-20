namespace CorePontoEncontro.Model
{
	// Business class MenuRole generated from MenuRole
	// alexis [2011-06-13] Created

	using System;
	using System.ComponentModel;
	using Castle.ActiveRecord;
using Iesi.Collections;

	[ActiveRecord("MenuRole")]
	public partial class MenuRole 
		: ActiveRecordValidationBase<MenuRole> 
	{

		#region Property_Names

		public static string Prop_RoleId = "RoleId";
		public static string Prop_MenuId = "MenuId";

		#endregion

		#region Private_Variables

        private ISet _roleid;
        private ISet _menuid;
        private int _menuRoleId;

		#endregion

		#region Constructors

		public MenuRole()
		{
            _roleid = new HybridSet();
            _menuid = new HybridSet();
		}

		#endregion

		#region Properties

        [PrimaryKey(PrimaryKeyType.Native, "MenuRoleId")]
        public int MenuRoleId
        {
            get { return _menuRoleId; }
            set { _menuRoleId = value; }
        }

        [HasAndBelongsToMany(typeof(Role),
        Table = "MenuRole",
        CompositeKeyColumnRefs = new string[] { "RoleId", "RoleId" },
        ColumnKey = "MenuRoleId",
        Lazy=true,
        Inverse=true,
        Cascade=ManyRelationCascadeEnum.SaveUpdate)]
        public ISet RoleId
        {
            get { return _roleid; }
            set { _roleid = value; }
        }

        [HasAndBelongsToMany(typeof(Menu),
        Table = "MenuRole",
        CompositeKeyColumnRefs = new string[] { "MenuId", "MenuId" },
        ColumnKey = "MenuRoleId",
        Lazy = true,
        Inverse = true,
        Cascade = ManyRelationCascadeEnum.SaveUpdate)]
        public ISet MenuId
		{
			get { return _menuid; }
            set { _menuid = value; }
		}

		#endregion

	} // MenuRole
}


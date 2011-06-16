namespace Core.Model
{
	// Business class MenuRole generated from MenuRole
	// alexis [2011-06-13] Created

	using System;
	using System.ComponentModel;
	using Castle.ActiveRecord;

	[ActiveRecord("MenuRole")]
	public partial class MenuRole 
		: ActiveRecordValidationBase<MenuRole> 
	{

		#region Property_Names

		public static string Prop_RoleId = "RoleId";
		public static string Prop_MenuId = "MenuId";

		#endregion

		#region Private_Variables

		private Role _roleid;
		private Menu _menuid;


		#endregion

		#region Constructors

		public MenuRole()
		{
		}

		public MenuRole(
			Role p_roleid,
			Menu p_menuid)
		{
			_roleid = p_roleid;
			_menuid = p_menuid;
		}

		#endregion

		#region Properties

		[PrimaryKey("RoleId", Access = PropertyAccess.NosetterLowercaseUnderscore)]
		public Role RoleId
		{
			get { return _roleid; }
		}

		[PrimaryKey("MenuId", Access = PropertyAccess.NosetterLowercaseUnderscore)]
		public Menu MenuId
		{
			get { return _menuid; }
		}

		#endregion

	} // MenuRole
}


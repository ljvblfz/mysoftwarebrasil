namespace Core.Model
{
	// Business class RoleMembro generated from RoleMembro
	// alexis [2011-06-13] Created

	using System;
	using System.ComponentModel;
	using Castle.ActiveRecord;

	[ActiveRecord("RoleMembro")]
	public partial class RoleMembro 
		: ActiveRecordValidationBase<RoleMembro> 
	{

		#region Property_Names

		public static string Prop_RoleId = "RoleId";
		public static string Prop_membroId = "membroId";

		#endregion

		#region Private_Variables

		private Role _roleid;
		private int _membroid;


		#endregion

		#region Constructors

		public RoleMembro()
		{
		}

		public RoleMembro(
			Role p_roleid,
			int p_membroid)
		{
			_roleid = p_roleid;
			_membroid = p_membroid;
		}

		#endregion

		#region Properties

		[PrimaryKey("RoleId", Access = PropertyAccess.NosetterLowercaseUnderscore)]
		public Role RoleId
		{
			get { return _roleid; }
		}

		[PrimaryKey("membroId", Access = PropertyAccess.NosetterLowercaseUnderscore)]
		public int membroId
		{
			get { return _membroid; }
		}

		#endregion

	} // RoleMembro
}


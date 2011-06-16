namespace Core.Model
{
    // Business class Role generated from Role
    // alexis [2011-06-13] Created

    using System;
    using System.ComponentModel;
    using Castle.ActiveRecord;
    using System.Collections.Generic;
    using System.Collections;
    using Castle.Components.Validator;

    [ActiveRecord("Role")]
    public partial class Role
        : ActiveRecordValidationBase<Role>
    {

        #region Property_Names

        public static string Prop_RoleId = "RoleId";
        public static string Prop_RoleName = "RoleName";

        #endregion

        #region Private_Variables

        private int _roleid;
        private string _roleName;

        private IList _MenuRole = new List<MenuRole>();
        private IList _RoleMembro = new List<RoleMembro>();

        #endregion

        #region Constructors

        public Role()
        {
        }

        public Role(
            int p_roleid,
            string p_roleName)
        {
            _roleid = p_roleid;
            _roleName = p_roleName;
        }

        #endregion

        #region Properties

        [PrimaryKey("RoleId", Access = PropertyAccess.NosetterLowercaseUnderscore)]
        public int RoleId
        {
            get { return _roleid; }
        }

        [Property("RoleName", Access = PropertyAccess.NosetterCamelcaseUnderscore, NotNull = true, Length = 255), ValidateLength(1, 255)]
        public string RoleName
        {
            get { return _roleName; }
            set { _roleName = value; }
        }

        [HasMany(typeof(MenuRole), Table = "MenuRole", ColumnKey = "RoleId")]
        public IList MenuRole
        {
            get { return _MenuRole; }
            set { _MenuRole = value; }
        }
        [HasMany(typeof(RoleMembro), Table = "RoleMembro", ColumnKey = "RoleId")]
        public IList RoleMembro
        {
            get { return _RoleMembro; }
            set { _RoleMembro = value; }
        }
        #endregion

    } // Role
}


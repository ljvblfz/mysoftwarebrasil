namespace CorePontoEncontro.Model
{
    // Business class Menu generated from Menu
    // alexis [2011-06-13] Created

    using System;
    using Castle.ActiveRecord;
    using System.Collections.Generic;
    using System.Collections;
    using Castle.Components.Validator;

    [ActiveRecord("Menu")]
    public class Menu : ActiveRecordValidationBase<Menu>
    {

        #region Private_Variables

        private int _menuid;
        private Menu _menuIdPai;
        private string _menuName;
        private int _menuOrdem;
        private string _menuPath;

        #endregion

        #region Properties

        [PrimaryKey(PrimaryKeyType.Native, "MenuId")]
        public int MenuId
        {
            get { return _menuid; }
            set { _menuid = value; }
        }

        [BelongsTo("MenuIdPai", Type = typeof(Menu), Access = PropertyAccess.NosetterCamelcaseUnderscore)]
        public Menu MenuIdPai
        {
            get { return _menuIdPai; }
            set { _menuIdPai = value; }
        }

        [Property("MenuName", Access = PropertyAccess.NosetterCamelcaseUnderscore, NotNull = true, Length = 255), ValidateLength(1, 255)]
        public string MenuName
        {
            get { return _menuName; }
            set { _menuName = value; }
        }

        [Property("MenuOrdem", Access = PropertyAccess.NosetterCamelcaseUnderscore, NotNull = true)]
        public int MenuOrdem
        {
            get { return _menuOrdem; }
            set { _menuOrdem = value; }
        }

        [Property("MenuPath", Access = PropertyAccess.NosetterCamelcaseUnderscore, NotNull = true, Length = 255), ValidateLength(1, 255)]
        public string MenuPath
        {
            get { return _menuPath; }
            set { _menuPath = value; }
        }

        #endregion

    } // Menu
}


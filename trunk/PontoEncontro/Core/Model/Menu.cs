namespace Core.Model
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

        #region Property_Names

        //public static string Prop_MenuId = "MenuId";
        //public static string Prop_MenuIdPai = "MenuIdPai";
        //public static string Prop_MenuName = "MenuName";
        //public static string Prop_MenuOrdem = "MenuOrdem";
        //public static string Prop_MenuPath = "MenuPath";

        #endregion

        #region Constructors

        public Menu()
        {

        }

        public Menu(
            int p_menuid,
            Menu p_menuIdPai,
            string p_menuName,
            int p_menuOrdem,
            string p_menuPath)
        {
            MenuId = p_menuid;
            //MenuIdPai = p_menuIdPai;
            //MenuName = p_menuName;
            //MenuOrdem = p_menuOrdem;
            //MenuPath = p_menuPath;
        }

        #endregion

        #region Properties

        [PrimaryKey]
        public int MenuId { get; set; }

        [BelongsTo("MenuIdPai", Type = typeof(Menu), Access = PropertyAccess.NosetterCamelcaseUnderscore)]
        public Menu MenuIdPai { get; set; }

        [Property("MenuName", Access = PropertyAccess.NosetterCamelcaseUnderscore, NotNull = true, Length = 255)]
        [ValidateLength(1, 255, "Nome deve ter no máximo 255 caracteres")]
        public string MenuName { get; set; }

        [Property("MenuOrdem", Access = PropertyAccess.NosetterCamelcaseUnderscore, NotNull = true)]
        public int MenuOrdem { get; set; }

        [Property("MenuPath", Access = PropertyAccess.NosetterCamelcaseUnderscore, NotNull = true, Length = 255)]
        [ValidateLength(1, 255, "URL deve ter no máximo 255 caracteres")]
        public string MenuPath { get; set; }

        [HasMany(typeof(Menu), Table = "Menu", ColumnKey = "MenuIdPai")]
        public IList MenuPai { get; set; }

        [HasMany(typeof(MenuRole), Table = "MenuRole", ColumnKey = "MenuId")]
        public IList MenuRole { get; set; }

        #endregion

    } // Menu
}


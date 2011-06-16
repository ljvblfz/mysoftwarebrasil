namespace Core.Model
{
    // Business class Etinia generated from Etinia
    // alexis [2011-06-13] Created

    using System;
    using System.ComponentModel;
    using Castle.ActiveRecord;
    using System.Collections;
    using System.Collections.Generic;
    using Castle.Components.Validator;

    [ActiveRecord("Etinia")]
    public partial class Etinia
        : ActiveRecordValidationBase<Etinia>
    {

        #region Property_Names

        public static string Prop_etiniaId = "etiniaId";
        public static string Prop_etiniaName = "etiniaName";

        #endregion

        #region Private_Variables

        private int _etiniaid;
        private string _etiniaName;

        private IList _Pessoa = new List<Pessoa>();

        #endregion

        #region Constructors

        public Etinia()
        {
        }

        public Etinia(
            int p_etiniaid,
            string p_etiniaName)
        {
            _etiniaid = p_etiniaid;
            _etiniaName = p_etiniaName;
        }

        #endregion

        #region Properties

        [PrimaryKey("etiniaId", Access = PropertyAccess.NosetterLowercaseUnderscore)]
        public int etiniaId
        {
            get { return _etiniaid; }
        }

        [Property("etiniaName", Access = PropertyAccess.NosetterCamelcaseUnderscore, NotNull = true, Length = 255), ValidateLength(1, 255)]
        public string etiniaName
        {
            get { return _etiniaName; }
            set { _etiniaName = value; }
        }

        [HasMany(typeof(Pessoa), Table = "Pessoa", ColumnKey = "etiniaId")]
        public IList Pessoa
        {
            get { return _Pessoa; }
            set { _Pessoa = value; }
        }

        #endregion

    } // Etinia
}


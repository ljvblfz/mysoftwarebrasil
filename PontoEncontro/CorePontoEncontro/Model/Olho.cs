namespace CorePontoEncontro.Model
{
    // Business class Olho generated from Olhos
    // alexis [2011-06-13] Created

    using System;
    using System.ComponentModel;
    using Castle.ActiveRecord;
    using System.Collections;
    using System.Collections.Generic;
    using Castle.Components.Validator;

    [ActiveRecord("Olhos")]
    public partial class Olho
        : ActiveRecordValidationBase<Olho>
    {

        #region Property_Names

        public static string Prop_olhosId = "olhosId";
        public static string Prop_olhosName = "olhosName";

        #endregion

        #region Private_Variables

        private int _olhosid;
        private string _olhosName;

        private IList _Pessoa = new List<Pessoa>();

        #endregion

        #region Constructors

        public Olho()
        {
        }

        public Olho(
            int p_olhosid,
            string p_olhosName)
        {
            _olhosid = p_olhosid;
            _olhosName = p_olhosName;
        }

        #endregion

        #region Properties

        [PrimaryKey("olhosId", Access = PropertyAccess.NosetterLowercaseUnderscore)]
        public int olhosId
        {
            get { return _olhosid; }
        }

        [Property("olhosName", Access = PropertyAccess.NosetterCamelcaseUnderscore, NotNull = true, Length = 255), ValidateLength(1, 255)]
        public string olhosName
        {
            get { return _olhosName; }
            set { _olhosName = value; }
        }

        [HasMany(typeof(Pessoa), Table = "Pessoa", ColumnKey = "olhosId")]
        public IList Pessoa
        {
            get { return _Pessoa; }
            set { _Pessoa = value; }
        }

        #endregion

    } // Olho
}


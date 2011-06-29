namespace CorePontoEncontro.Model
{
    // Business class Cabelo generated from Cabelos
    // alexis [2011-06-13] Created

    using System;
    using System.ComponentModel;
    using Castle.ActiveRecord;
    using System.Collections;
    using System.Collections.Generic;
    using Castle.Components.Validator;

    [ActiveRecord("Cabelos")]
    public partial class Cabelo
        : ActiveRecordValidationBase<Cabelo>
    {

        #region Property_Names

        public static string Prop_cabelosId = "cabelosId";
        public static string Prop_cabelosName = "cabelosName";

        #endregion

        #region Private_Variables

        private int _cabelosid;
        private string _cabelosName;

        private IList _Pessoa = new List<Pessoa>();

        #endregion

        #region Constructors

        public Cabelo()
        {
        }

        public Cabelo(
            int p_cabelosid,
            string p_cabelosName)
        {
            _cabelosid = p_cabelosid;
            _cabelosName = p_cabelosName;
        }

        #endregion

        #region Properties

        [PrimaryKey("cabelosId", Access = PropertyAccess.NosetterLowercaseUnderscore)]
        public int cabelosId
        {
            get { return _cabelosid; }
            set { _cabelosid = value; }
        }

        [Property("cabelosName", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 255), ValidateLength(1, 255)]
        public string cabelosName
        {
            get { return _cabelosName; }
            set { _cabelosName = value; }
        }

        [HasMany(typeof(Pessoa), Table = "Pessoa", ColumnKey = "cabelosId")]
        public IList Pessoa
        {
            get { return _Pessoa; }
            set { _Pessoa = value; }
        }

        #endregion

    } // Cabelo
}


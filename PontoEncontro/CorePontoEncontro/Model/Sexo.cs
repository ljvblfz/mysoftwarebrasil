namespace CorePontoEncontro.Model
{
    // Business class Sexo generated from Sexo
    // alexis [2011-06-13] Created

    using System;
    using System.ComponentModel;
    using Castle.ActiveRecord;
    using System.Collections;
    using System.Collections.Generic;
    using Castle.Components.Validator;

    [ActiveRecord("Sexo")]
    public partial class Sexo : ActiveRecordValidationBase<Sexo>
    {

        #region Property_Names

        public static string Prop_sexoId = "sexoId";
        public static string Prop_sexoName = "sexoName";

        #endregion

        #region Private_Variables

        private int _sexoid;
        private string _sexoName;

        private IList _Pessoa = new List<Pessoa>();

        #endregion

        #region Constructors

        public Sexo()
        {
        }

        public Sexo(
            int p_sexoid,
            string p_sexoName)
        {
            _sexoid = p_sexoid;
            _sexoName = p_sexoName;
        }

        #endregion

        #region Properties

        [PrimaryKey("sexoId", Access = PropertyAccess.NosetterLowercaseUnderscore)]
        public int sexoId
        {
            get { return _sexoid; }
        }

        [Property("sexoName", Access = PropertyAccess.NosetterCamelcaseUnderscore, NotNull = true, Length = 255), ValidateLength(1, 255)]
        public string sexoName
        {
            get { return _sexoName; }
            set { _sexoName = value; }
        }

        [HasMany(typeof(Pessoa), Table = "Pessoa", ColumnKey = "sexoId")]
        public IList Pessoa
        {
            get { return _Pessoa; }
            set { _Pessoa = value; }
        }

        #endregion

    } // Sexo
}


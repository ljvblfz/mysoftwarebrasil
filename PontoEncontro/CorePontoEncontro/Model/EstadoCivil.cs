namespace CorePontoEncontro.Model
{
    // Business class EstadoCivil generated from EstadoCivil
    // alexis [2011-06-13] Created

    using System;
    using System.ComponentModel;
    using Castle.ActiveRecord;
    using System.Collections;
    using System.Collections.Generic;
    using Castle.Components.Validator;

    [ActiveRecord("EstadoCivil")]
    public partial class EstadoCivil
        : ActiveRecordValidationBase<EstadoCivil>
    {

        #region Property_Names

        public static string Prop_estadoCivilId = "estadoCivilId";
        public static string Prop_estadoCivilName = "estadoCivilName";

        #endregion

        #region Private_Variables

        private int _estadocivilid;
        private string _estadoCivilName;

        private IList _Pessoa = new List<Pessoa>();

        #endregion

        #region Constructors

        public EstadoCivil()
        {
        }

        public EstadoCivil(
            int p_estadocivilid,
            string p_estadoCivilName)
        {
            _estadocivilid = p_estadocivilid;
            _estadoCivilName = p_estadoCivilName;
        }

        #endregion

        #region Properties

        [PrimaryKey("estadoCivilId", Access = PropertyAccess.NosetterLowercaseUnderscore)]
        public int estadoCivilId
        {
            get { return _estadocivilid; }
        }

        [Property("estadoCivilName", Access = PropertyAccess.NosetterCamelcaseUnderscore, NotNull = true, Length = 255), ValidateLength(1, 255)]
        public string estadoCivilName
        {
            get { return _estadoCivilName; }
            set { _estadoCivilName = value; }
        }

        [HasMany(typeof(Pessoa), Table = "Pessoa", ColumnKey = "estadoCivilId")]
        public IList Pessoa
        {
            get { return _Pessoa; }
            set { _Pessoa = value; }
        }

        #endregion

    } // EstadoCivil
}


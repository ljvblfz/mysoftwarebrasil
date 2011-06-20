namespace CorePontoEncontro.Model
{
    // Business class Pai generated from Pais
    // alexis [2011-06-13] Created

    using System;
    using System.ComponentModel;
    using Castle.ActiveRecord;
    using System.Collections;
    using System.Collections.Generic;
    using Castle.Components.Validator;

    [ActiveRecord("Pais")]
    public partial class Pais
        : ActiveRecordValidationBase<Pais>
    {

        #region Property_Names

        public static string Prop_paisId = "paisId";
        public static string Prop_paisName = "paisName";

        #endregion

        #region Private_Variables

        private int _paisid;
        private string _paisName;

        private IList _Estado = new List<Estado>();

        #endregion

        #region Constructors

        public Pais()
        {
        }

        public Pais(
            int p_paisid,
            string p_paisName)
        {
            _paisid = p_paisid;
            _paisName = p_paisName;
        }

        #endregion

        #region Properties

        [PrimaryKey("paisId", Access = PropertyAccess.NosetterLowercaseUnderscore)]
        public int paisId
        {
            get { return _paisid; }
        }

        [Property("paisName", Access = PropertyAccess.NosetterCamelcaseUnderscore, NotNull = true, Length = 255), ValidateLength(1, 255)]
        public string paisName
        {
            get { return _paisName; }
            set { _paisName = value; }
        }

        [HasMany(typeof(Estado), Table = "Estado", ColumnKey = "paisId")]
        public IList Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }

        #endregion

    } // Pai
}


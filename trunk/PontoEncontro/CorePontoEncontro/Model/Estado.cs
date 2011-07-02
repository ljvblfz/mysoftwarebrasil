namespace CorePontoEncontro.Model
{
    // Business class Estado generated from Estado
    // alexis [2011-06-13] Created

    using System;
    using System.ComponentModel;
    using Castle.ActiveRecord;
    using System.Collections;
    using System.Collections.Generic;
    using Castle.Components.Validator;

    [ActiveRecord("Estado")]
    public partial class Estado
        : ActiveRecordValidationBase<Estado>
    {

        #region Property_Names

        public static string Prop_estadoId = "estadoId";
        public static string Prop_estadoName = "estadoName";
        public static string Prop_estadoSigla = "estadoSigla";
        public static string Prop_paisId = "paisId";

        #endregion

        #region Private_Variables

        private int _estadoid;
        private string _estadoName;
        private string _estadoSigla;
        private Pais _paisId;

        private IList _Cidade = new List<Cidade>();

        #endregion

        #region Constructors

        public Estado()
        {
        }

        public Estado(
            int p_estadoid,
            string p_estadoName,
            string p_estadoSigla,
            Pais p_paisId)
        {
            _estadoid = p_estadoid;
            _estadoName = p_estadoName;
            _estadoSigla = p_estadoSigla;
            _paisId = p_paisId;
        }

        #endregion

        #region Properties

        [PrimaryKey("estadoId", Access = PropertyAccess.NosetterLowercaseUnderscore)]
        public int estadoId
        {
            get { return _estadoid; }
            set { _estadoid = value; }
        }

        [Property("estadoName", Access = PropertyAccess.NosetterCamelcaseUnderscore, NotNull = true, Length = 255), ValidateLength(1, 255)]
        public string estadoName
        {
            get { return _estadoName; }
            set { _estadoName = value; }
        }

        [Property("estadoSigla", Access = PropertyAccess.NosetterCamelcaseUnderscore, NotNull = true, Length = 2), ValidateLength(1, 2)]
        public string estadoSigla
        {
            get { return _estadoSigla; }
            set { _estadoSigla = value; }
        }

        [BelongsTo("paisId", Type = typeof(Pais), Access = PropertyAccess.NosetterCamelcaseUnderscore)]
        public Pais paisId
        {
            get { return _paisId; }
            set { _paisId = value; }
        }

        [HasMany(typeof(Cidade), Table = "Cidade", ColumnKey = "estadoId")]
        public IList Cidade
        {
            get { return _Cidade; }
            set { _Cidade = value; }
        }

        #endregion

    } // Estado
}


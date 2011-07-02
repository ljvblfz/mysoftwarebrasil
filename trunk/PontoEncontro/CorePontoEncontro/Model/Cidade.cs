namespace CorePontoEncontro.Model
{
    // Business class Cidade generated from Cidade
    // alexis [2011-06-13] Created

    using System;
    using System.ComponentModel;
    using Castle.ActiveRecord;
    using System.Collections;
    using System.Collections.Generic;
    using Castle.Components.Validator;

    [ActiveRecord("Cidade")]
    public partial class Cidade
        : ActiveRecordValidationBase<Cidade>
    {

        #region Property_Names

        public static string Prop_cidadeId = "cidadeId";
        public static string Prop_cidadeName = "cidadeName";
        public static string Prop_estadoId = "estadoId";

        #endregion

        #region Private_Variables

        private int _cidadeid;
        private string _cidadeName;
        private Estado _estadoId;

        private IList _Endereco = new List<Endereco>();

        #endregion

        #region Constructors

        public Cidade()
        {
        }

        public Cidade(
            int p_cidadeid,
            string p_cidadeName,
            Estado p_estadoId)
        {
            _cidadeid = p_cidadeid;
            _cidadeName = p_cidadeName;
            _estadoId = p_estadoId;
        }

        #endregion

        #region Properties

        [PrimaryKey("cidadeId", Access = PropertyAccess.NosetterLowercaseUnderscore)]
        public int cidadeId
        {
            get { return _cidadeid; }
            set { _cidadeid = value; }
        }

        [Property("cidadeName", Access = PropertyAccess.NosetterCamelcaseUnderscore, NotNull = true, Length = 255), ValidateLength(1, 255)]
        public string cidadeName
        {
            get { return _cidadeName; }
            set { _cidadeName = value; }
        }

        [BelongsTo("estadoId", Type = typeof(Estado), Access = PropertyAccess.NosetterCamelcaseUnderscore)]
        public Estado estadoId
        {
            get { return _estadoId; }
            set { _estadoId = value; }
        }

        [HasMany(typeof(Endereco), Table = "Endereco", ColumnKey = "cidadeId")]
        public IList Endereco
        {
            get { return _Endereco; }
            set { _Endereco = value; }
        }

        #endregion

    } // Cidade
}


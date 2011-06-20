namespace CorePontoEncontro.Model
{
    // Business class Comunidade generated from Comunidade
    // alexis [2011-06-13] Created

    using System;
    using System.ComponentModel;
    using Castle.ActiveRecord;
    using System.Collections;
    using System.Collections.Generic;
    using Castle.Components.Validator;

    [ActiveRecord("Comunidade")]
    public partial class Comunidade
        : ActiveRecordValidationBase<Comunidade>
    {

        #region Property_Names

        public static string Prop_comunidadeId = "comunidadeId";
        public static string Prop_comunidadeName = "comunidadeName";
        public static string Prop_comunidadeDataCreate = "comunidadeDataCreate";
        public static string Prop_comunidadeDescricao = "comunidadeDescricao";

        #endregion

        #region Private_Variables

        private int _comunidadeid;
        private string _comunidadeName;
        private DateTime _comunidadeDataCreate;
        private string _comunidadeDescricao;

        private IList _ComunidadeMembro = new List<ComunidadeMembro>();

        #endregion

        #region Constructors

        public Comunidade()
        {
        }

        public Comunidade(
            int p_comunidadeid,
            string p_comunidadeName,
            DateTime p_comunidadeDataCreate,
            string p_comunidadeDescricao)
        {
            _comunidadeid = p_comunidadeid;
            _comunidadeName = p_comunidadeName;
            _comunidadeDataCreate = p_comunidadeDataCreate;
            _comunidadeDescricao = p_comunidadeDescricao;
        }

        #endregion

        #region Properties

        [PrimaryKey("comunidadeId", Access = PropertyAccess.NosetterLowercaseUnderscore)]
        public int comunidadeId
        {
            get { return _comunidadeid; }
        }

        [Property("comunidadeName", Access = PropertyAccess.NosetterCamelcaseUnderscore, NotNull = true, Length = 255), ValidateLength(1, 255)]
        public string comunidadeName
        {
            get { return _comunidadeName; }
            set { _comunidadeName = value; }
        }

        [Property("comunidadeDataCreate", Access = PropertyAccess.NosetterCamelcaseUnderscore, NotNull = true)]
        public DateTime comunidadeDataCreate
        {
            get { return _comunidadeDataCreate; }
            set { _comunidadeDataCreate = value; }
        }

        [Property("comunidadeDescricao", Access = PropertyAccess.NosetterCamelcaseUnderscore, NotNull = true, ColumnType = "StringClob")]
        public string comunidadeDescricao
        {
            get { return _comunidadeDescricao; }
            set { _comunidadeDescricao = value; }
        }

        [HasMany(typeof(ComunidadeMembro), Table = "ComunidadeMembro", ColumnKey = "comunidadeId")]
        public IList ComunidadeMembro
        {
            get { return _ComunidadeMembro; }
            set { _ComunidadeMembro = value; }
        }

        #endregion

    } // Comunidade
}


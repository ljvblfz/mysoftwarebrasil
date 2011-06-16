namespace Core.Model
{
    // Business class Perfil generated from Perfil
    // alexis [2011-06-13] Created

    using System;
    using System.ComponentModel;
    using Castle.ActiveRecord;
    using System.Collections;
    using System.Collections.Generic;
    using Castle.Components.Validator;

    [ActiveRecord("Perfil")]
    public partial class Perfil
        : ActiveRecordValidationBase<Perfil>
    {

        #region Property_Names

        public static string Prop_perfilId = "perfilId";
        public static string Prop_perfilAltura = "perfilAltura";
        public static string Prop_perfilPeso = "perfilPeso";
        public static string Prop_perfilFumante = "perfilFumante";
        public static string Prop_perfilBebe = "perfilBebe";
        public static string Prop_pessoaInteresseConhecer = "pessoaInteresseConhecer";
        public static string Prop_pessoaFantasiasSexuais = "pessoaFantasiasSexuais";
        public static string Prop_pessoaOutrosInteresses = "pessoaOutrosInteresses";

        #endregion

        #region Private_Variables

        private int _perfilid;
        private int _perfilAltura;
        private int _perfilPeso;
        private bool _perfilFumante;
        private bool _perfilBebe;
        private string _pessoaInteresseConhecer;
        private string _pessoaFantasiasSexuais;
        private string _pessoaOutrosInteresses;

        private IList _Pessoa = new List<Pessoa>();

        #endregion

        #region Constructors

        public Perfil()
        {
        }

        public Perfil(
            int p_perfilid,
            int p_perfilAltura,
            int p_perfilPeso,
            bool p_perfilFumante,
            bool p_perfilBebe,
            string p_pessoaInteresseConhecer,
            string p_pessoaFantasiasSexuais,
            string p_pessoaOutrosInteresses)
        {
            _perfilid = p_perfilid;
            _perfilAltura = p_perfilAltura;
            _perfilPeso = p_perfilPeso;
            _perfilFumante = p_perfilFumante;
            _perfilBebe = p_perfilBebe;
            _pessoaInteresseConhecer = p_pessoaInteresseConhecer;
            _pessoaFantasiasSexuais = p_pessoaFantasiasSexuais;
            _pessoaOutrosInteresses = p_pessoaOutrosInteresses;
        }

        #endregion

        #region Properties

        [PrimaryKey("perfilId", Access = PropertyAccess.NosetterLowercaseUnderscore)]
        public int perfilId
        {
            get { return _perfilid; }
        }

        [Property("perfilAltura", Access = PropertyAccess.NosetterCamelcaseUnderscore, NotNull = true)]
        public int perfilAltura
        {
            get { return _perfilAltura; }
            set { _perfilAltura = value; }
        }

        [Property("perfilPeso", Access = PropertyAccess.NosetterCamelcaseUnderscore, NotNull = true)]
        public int perfilPeso
        {
            get { return _perfilPeso; }
            set { _perfilPeso = value; }
        }

        [Property("perfilFumante", Access = PropertyAccess.NosetterCamelcaseUnderscore, NotNull = true)]
        public bool perfilFumante
        {
            get { return _perfilFumante; }
            set { _perfilFumante = value; }
        }

        [Property("perfilBebe", Access = PropertyAccess.NosetterCamelcaseUnderscore, NotNull = true)]
        public bool perfilBebe
        {
            get { return _perfilBebe; }
            set { _perfilBebe = value; }
        }

        [Property("pessoaInteresseConhecer", Access = PropertyAccess.NosetterCamelcaseUnderscore, ColumnType = "StringClob")]
        public string pessoaInteresseConhecer
        {
            get { return _pessoaInteresseConhecer; }
            set { _pessoaInteresseConhecer = value; }
        }

        [Property("pessoaFantasiasSexuais", Access = PropertyAccess.NosetterCamelcaseUnderscore, ColumnType = "StringClob")]
        public string pessoaFantasiasSexuais
        {
            get { return _pessoaFantasiasSexuais; }
            set { _pessoaFantasiasSexuais = value; }
        }

        [Property("pessoaOutrosInteresses", Access = PropertyAccess.NosetterCamelcaseUnderscore, ColumnType = "StringClob")]
        public string pessoaOutrosInteresses
        {
            get { return _pessoaOutrosInteresses; }
            set { _pessoaOutrosInteresses = value; }
        }

        [HasMany(typeof(Pessoa), Table = "Pessoa", ColumnKey = "perfilId")]
        public IList Pessoa
        {
            get { return _Pessoa; }
            set { _Pessoa = value; }
        }

        #endregion

    } // Perfil
}


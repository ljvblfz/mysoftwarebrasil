namespace CorePontoEncontro.Model
{
    // Business class Endereco generated from Endereco
    // alexis [2011-06-13] Created

    using System;
    using System.ComponentModel;
    using Castle.ActiveRecord;
    using System.Collections;
    using System.Collections.Generic;
    using Castle.Components.Validator;

    [ActiveRecord("Endereco")]
    public partial class Endereco
        : ActiveRecordValidationBase<Endereco>
    {

        #region Property_Names

        public static string Prop_enderecoId = "enderecoId";
        public static string Prop_CEP = "CEP";
        public static string Prop_cidadeId = "cidadeId";

        #endregion

        #region Private_Variables

        private int _enderecoid;
        private string _cEP;
        private Cidade _cidadeId;

        private IList _Encontro = new List<Encontro>();
        private IList _Pessoa = new List<Pessoa>();

        #endregion

        #region Constructors

        public Endereco()
        {
        }

        public Endereco(
            int p_enderecoid,
            string p_cEP,
            Cidade p_cidadeId)
        {
            _enderecoid = p_enderecoid;
            _cEP = p_cEP;
            _cidadeId = p_cidadeId;
        }

        #endregion

        #region Properties

        [PrimaryKey("enderecoId", Access = PropertyAccess.NosetterLowercaseUnderscore)]
        public int enderecoId
        {
            get { return _enderecoid; }
        }

        [Property("CEP", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 20), ValidateLength(1, 20)]
        public string CEP
        {
            get { return _cEP; }
            set { _cEP = value; }
        }

        [BelongsTo("cidadeId", Type = typeof(Cidade), Access = PropertyAccess.NosetterCamelcaseUnderscore)]
        public Cidade cidadeId
        {
            get { return _cidadeId; }
            set { _cidadeId = value; }
        }

        [HasMany(typeof(Encontro), Table = "Encontro", ColumnKey = "enderecoId")]
        public IList Encontro
        {
            get { return _Encontro; }
            set { _Encontro = value; }
        }

        [HasMany(typeof(Pessoa), Table = "Pessoa", ColumnKey = "enderecoId")]
        public IList Pessoa
        {
            get { return _Pessoa; }
            set { _Pessoa = value; }
        }

        #endregion

    } // Endereco
}


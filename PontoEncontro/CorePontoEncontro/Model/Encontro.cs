namespace CorePontoEncontro.Model
{
    // Business class Encontro generated from Encontro
    // alexis [2011-06-13] Created

    using System;
    using System.ComponentModel;
    using Castle.ActiveRecord;
    using System.Collections;
    using System.Collections.Generic;
    using Castle.Components.Validator;

    [ActiveRecord("Encontro")]
    public partial class Encontro
        : ActiveRecordValidationBase<Encontro>
    {

        #region Property_Names

        public static string Prop_encontroId = "encontroId";
        public static string Prop_enderecoId = "enderecoId";
        public static string Prop_encontroTitulo = "encontroTitulo";
        public static string Prop_encontroDescricao = "encontroDescricao";
        public static string Prop_encontroQuantPessoas = "encontroQuantPessoas";
        public static string Prop_encontroData = "encontroData";
        public static string Prop_encontroValor = "encontroValor";

        #endregion

        #region Private_Variables

        private int _encontroid;
        private Endereco _enderecoId;
        private string _encontroTitulo;
        private string _encontroDescricao;
        private int? _encontroQuantPessoas;
        private DateTime _encontroData;
        private float? _encontroValor;

        private IList _EncontroMembro = new List<EncontroMembro>();

        #endregion

        #region Constructors

        public Encontro()
        {
        }

        public Encontro(
            int p_encontroid,
            Endereco p_enderecoId,
            string p_encontroTitulo,
            string p_encontroDescricao,
            int? p_encontroQuantPessoas,
            DateTime p_encontroData,
            float? p_encontroValor)
        {
            _encontroid = p_encontroid;
            _enderecoId = p_enderecoId;
            _encontroTitulo = p_encontroTitulo;
            _encontroDescricao = p_encontroDescricao;
            _encontroQuantPessoas = p_encontroQuantPessoas;
            _encontroData = p_encontroData;
            _encontroValor = p_encontroValor;
        }

        #endregion

        #region Properties

        [PrimaryKey("encontroId", Access = PropertyAccess.NosetterLowercaseUnderscore)]
        public int encontroId
        {
            get { return _encontroid; }
        }

        [BelongsTo("enderecoId", Type = typeof(Endereco), Access = PropertyAccess.NosetterCamelcaseUnderscore)]
        public Endereco enderecoId
        {
            get { return _enderecoId; }
            set { _enderecoId = value; }
        }

        [Property("encontroTitulo", Access = PropertyAccess.NosetterCamelcaseUnderscore, NotNull = true, Length = 50), ValidateLength(1, 50)]
        public string encontroTitulo
        {
            get { return _encontroTitulo; }
            set { _encontroTitulo = value; }
        }

        [Property("encontroDescricao", Access = PropertyAccess.NosetterCamelcaseUnderscore, NotNull = true, ColumnType = "StringClob")]
        public string encontroDescricao
        {
            get { return _encontroDescricao; }
            set { _encontroDescricao = value; }
        }

        [Property("encontroQuantPessoas", Access = PropertyAccess.NosetterCamelcaseUnderscore)]
        public int? encontroQuantPessoas
        {
            get { return _encontroQuantPessoas; }
            set { _encontroQuantPessoas = value; }
        }

        [Property("encontroData", Access = PropertyAccess.NosetterCamelcaseUnderscore, NotNull = true)]
        public DateTime encontroData
        {
            get { return _encontroData; }
            set { _encontroData = value; }
        }

        [Property("encontroValor", Access = PropertyAccess.NosetterCamelcaseUnderscore)]
        public float? encontroValor
        {
            get { return _encontroValor; }
            set { _encontroValor = value; }
        }

        [HasMany(typeof(EncontroMembro), Table = "EncontroMembro", ColumnKey = "encontroId")]
        public IList EncontroMembro
        {
            get { return _EncontroMembro; }
            set { _EncontroMembro = value; }
        }

        #endregion

    } // Encontro
}


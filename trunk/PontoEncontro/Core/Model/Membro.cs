namespace Core.Model
{
    // Business class Membro generated from Membro
    // alexis [2011-06-13] Created

    using System;
    using System.ComponentModel;
    using Castle.ActiveRecord;
    using System.Collections;
    using System.Collections.Generic;
    using Castle.Components.Validator;

    [ActiveRecord("Membro")]
    public partial class Membro
        : ActiveRecordValidationBase<Membro>
    {

        #region Property_Names

        public static string Prop_pessoaId = "pessoaId";
        public static string Prop_membroId = "membroId";
        public static string Prop_membroNickName = "membroNickName";
        public static string Prop_membroUltimoLogin = "membroUltimoLogin";
        public static string Prop_membroSenha = "membroSenha";

        #endregion

        #region Private_Variables

        private Pessoa _pessoaId;
        private int _membroid;
        private string _membroNickName;
        private DateTime _membroUltimoLogin;
        private string _membroSenha;

        private IList _Anuncio = new List<Anuncio>();
        private IList _ComunidadeMembro = new List<ComunidadeMembro>();
        private IList _EncontroMembro = new List<EncontroMembro>();
        private IList _Fotos = new List<Foto>();
        private IList _MembroAmigo = new List<MembroAmigo>();
        private IList _MembroFavorito = new List<MembroFavorito>();

        #endregion

        #region Constructors

        public Membro()
        {
        }

        public Membro(
            Pessoa p_pessoaId,
            int p_membroid,
            string p_membroNickName,
            DateTime p_membroUltimoLogin,
            string p_membroSenha)
        {
            _pessoaId = p_pessoaId;
            _membroid = p_membroid;
            _membroNickName = p_membroNickName;
            _membroUltimoLogin = p_membroUltimoLogin;
            _membroSenha = p_membroSenha;
        }

        #endregion

        #region Properties

        [BelongsTo("pessoaId", Type = typeof(Pessoa), Access = PropertyAccess.NosetterCamelcaseUnderscore)]
        public Pessoa pessoaId
        {
            get { return _pessoaId; }
            set { _pessoaId = value; }
        }

        [PrimaryKey("membroId", Access = PropertyAccess.NosetterLowercaseUnderscore)]
        public int membroId
        {
            get { return _membroid; }
        }

        [Property("membroNickName", Access = PropertyAccess.NosetterCamelcaseUnderscore, NotNull = true, Length = 255), ValidateLength(1, 255)]
        public string membroNickName
        {
            get { return _membroNickName; }
            set { _membroNickName = value; }
        }

        [Property("membroUltimoLogin", Access = PropertyAccess.NosetterCamelcaseUnderscore, NotNull = true)]
        public DateTime membroUltimoLogin
        {
            get { return _membroUltimoLogin; }
            set { _membroUltimoLogin = value; }
        }

        [Property("membroSenha", Access = PropertyAccess.NosetterCamelcaseUnderscore, NotNull = true, Length = 50), ValidateLength(1, 50)]
        public string membroSenha
        {
            get { return _membroSenha; }
            set { _membroSenha = value; }
        }

        [HasMany(typeof(Anuncio), Table = "Anuncio", ColumnKey = "membroId")]
        public IList Anuncio
        {
            get { return _Anuncio; }
            set { _Anuncio = value; }
        }

        [HasMany(typeof(ComunidadeMembro), Table = "ComunidadeMembro", ColumnKey = "membroId")]
        public IList ComunidadeMembro
        {
            get { return _ComunidadeMembro; }
            set { _ComunidadeMembro = value; }
        }

        [HasMany(typeof(EncontroMembro), Table = "EncontroMembro", ColumnKey = "membroId")]
        public IList EncontroMembro
        {
            get { return _EncontroMembro; }
            set { _EncontroMembro = value; }
        }

        [HasMany(typeof(Foto), Table = "Fotos", ColumnKey = "membroId")]
        public IList Fotos
        {
            get { return _Fotos; }
            set { _Fotos = value; }
        }

        [HasMany(typeof(MembroAmigo), Table = "MembroAmigo", ColumnKey = "membroId")]
        public IList MembroAmigo
        {
            get { return _MembroAmigo; }
            set { _MembroAmigo = value; }
        }

        [HasMany(typeof(MembroFavorito), Table = "MembroFavorito", ColumnKey = "membroId")]
        public IList MembroFavorito
        {
            get { return _MembroFavorito; }
            set { _MembroFavorito = value; }
        }

        #endregion

    } // Membro
}


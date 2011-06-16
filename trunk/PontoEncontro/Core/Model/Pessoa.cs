namespace Core.Model
{
    // Business class Pessoa generated from Pessoa
    // alexis [2011-06-13] Created

    using System;
    using System.ComponentModel;
    using Castle.ActiveRecord;
    using System.Collections;
    using System.Collections.Generic;
    using Castle.Components.Validator;

    [ActiveRecord("Pessoa")]
    public partial class Pessoa
        : ActiveRecordValidationBase<Pessoa>
    {

        #region Property_Names

        public static string Prop_sexoId = "sexoId";
        public static string Prop_olhosId = "olhosId";
        public static string Prop_cabelosId = "cabelosId";
        public static string Prop_etiniaId = "etiniaId";
        public static string Prop_perfilId = "perfilId";
        public static string Prop_estadoCivilId = "estadoCivilId";
        public static string Prop_enderecoId = "enderecoId";
        public static string Prop_pessoaId = "pessoaId";
        public static string Prop_pessoaName = "pessoaName";
        public static string Prop_pessoaNascimento = "pessoaNascimento";
        public static string Prop_pessoaProfissao = "pessoaProfissao";
        public static string Prop_pessoaEmail = "pessoaEmail";
        public static string Prop_pessoaMSN = "pessoaMSN";

        #endregion

        #region Private_Variables

        private Sexo _sexoId;
        private Olho _olhosId;
        private Cabelo _cabelosId;
        private Etinia _etiniaId;
        private Perfil _perfilId;
        private EstadoCivil _estadoCivilId;
        private Endereco _enderecoId;
        private int _pessoaid;
        private string _pessoaName;
        private DateTime _pessoaNascimento;
        private string _pessoaProfissao;
        private string _pessoaEmail;
        private string _pessoaMSN;

        private IList _inretessePessoa = new List<inretessePessoa>();
        private IList _Membro = new List<Membro>();

        #endregion

        #region Constructors

        public Pessoa()
        {
        }

        public Pessoa(
            Sexo p_sexoId,
            Olho p_olhosId,
            Cabelo p_cabelosId,
            Etinia p_etiniaId,
            Perfil p_perfilId,
            EstadoCivil p_estadoCivilId,
            Endereco p_enderecoId,
            int p_pessoaid,
            string p_pessoaName,
            DateTime p_pessoaNascimento,
            string p_pessoaProfissao,
            string p_pessoaEmail,
            string p_pessoaMSN)
        {
            _sexoId = p_sexoId;
            _olhosId = p_olhosId;
            _cabelosId = p_cabelosId;
            _etiniaId = p_etiniaId;
            _perfilId = p_perfilId;
            _estadoCivilId = p_estadoCivilId;
            _enderecoId = p_enderecoId;
            _pessoaid = p_pessoaid;
            _pessoaName = p_pessoaName;
            _pessoaNascimento = p_pessoaNascimento;
            _pessoaProfissao = p_pessoaProfissao;
            _pessoaEmail = p_pessoaEmail;
            _pessoaMSN = p_pessoaMSN;
        }

        #endregion

        #region Properties

        [BelongsTo("sexoId", Type = typeof(Sexo), Access = PropertyAccess.NosetterCamelcaseUnderscore)]
        public Sexo sexoId
        {
            get { return _sexoId; }
            set { _sexoId = value; }
        }

        [BelongsTo("olhosId", Type = typeof(Olho), Access = PropertyAccess.NosetterCamelcaseUnderscore)]
        public Olho olhosId
        {
            get { return _olhosId; }
            set { _olhosId = value; }
        }

        [BelongsTo("cabelosId", Type = typeof(Cabelo), Access = PropertyAccess.NosetterCamelcaseUnderscore)]
        public Cabelo cabelosId
        {
            get { return _cabelosId; }
            set { _cabelosId = value; }
        }

        [BelongsTo("etiniaId", Type = typeof(Etinia), Access = PropertyAccess.NosetterCamelcaseUnderscore)]
        public Etinia etiniaId
        {
            get { return _etiniaId; }
            set { _etiniaId = value; }
        }

        [BelongsTo("perfilId", Type = typeof(Perfil), Access = PropertyAccess.NosetterCamelcaseUnderscore)]
        public Perfil perfilId
        {
            get { return _perfilId; }
            set { _perfilId = value; }
        }

        [BelongsTo("estadoCivilId", Type = typeof(EstadoCivil), Access = PropertyAccess.NosetterCamelcaseUnderscore)]
        public EstadoCivil estadoCivilId
        {
            get { return _estadoCivilId; }
            set { _estadoCivilId = value; }
        }

        [BelongsTo("enderecoId", Type = typeof(Endereco), Access = PropertyAccess.NosetterCamelcaseUnderscore)]
        public Endereco enderecoId
        {
            get { return _enderecoId; }
            set { _enderecoId = value; }
        }

        [PrimaryKey("pessoaId", Access = PropertyAccess.NosetterLowercaseUnderscore)]
        public int pessoaId
        {
            get { return _pessoaid; }
        }

        [Property("pessoaName", Access = PropertyAccess.NosetterCamelcaseUnderscore, NotNull = true, Length = 255), ValidateLength(1, 255)]
        public string pessoaName
        {
            get { return _pessoaName; }
            set { _pessoaName = value; }
        }

        [Property("pessoaNascimento", Access = PropertyAccess.NosetterCamelcaseUnderscore, NotNull = true)]
        public DateTime pessoaNascimento
        {
            get { return _pessoaNascimento; }
            set { _pessoaNascimento = value; }
        }

        [Property("pessoaProfissao", Access = PropertyAccess.NosetterCamelcaseUnderscore, NotNull = true, Length = 255), ValidateLength(1, 255)]
        public string pessoaProfissao
        {
            get { return _pessoaProfissao; }
            set { _pessoaProfissao = value; }
        }

        [Property("pessoaEmail", Access = PropertyAccess.NosetterCamelcaseUnderscore, NotNull = true, Length = 255), ValidateLength(1, 255)]
        public string pessoaEmail
        {
            get { return _pessoaEmail; }
            set { _pessoaEmail = value; }
        }

        [Property("pessoaMSN", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 255), ValidateLength(1, 255)]
        public string pessoaMSN
        {
            get { return _pessoaMSN; }
            set { _pessoaMSN = value; }
        }

        [HasMany(typeof(inretessePessoa), Table = "inretessePessoa", ColumnKey = "pessoaId")]
        public IList inretessePessoa
        {
            get { return _inretessePessoa; }
            set { _inretessePessoa = value; }
        }

        [HasMany(typeof(Membro), Table = "Membro", ColumnKey = "pessoaId")]
        public IList Membro
        {
            get { return _Membro; }
            set { _Membro = value; }
        }

        #endregion

    } // Pessoa
}


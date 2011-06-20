namespace CorePontoEncontro.Model
{
    // Business class inretessePessoa generated from inretessePessoa
    // alexis [2011-06-13] Created

    using System;
    using System.ComponentModel;
    using Castle.ActiveRecord;
    using System.Collections;
    using System.Collections.Generic;
    using Castle.Components.Validator;
    using Iesi.Collections;

    [ActiveRecord("inretessePessoa")]
    public partial class inretessePessoa
        : ActiveRecordValidationBase<inretessePessoa>
    {

        #region Property_Names

        public static string Prop_pessoaId = "pessoaId";
        public static string Prop_interresseId = "interresseId";

        #endregion

        #region Private_Variables

        private ISet _pessoaid;
        private ISet _interresseid;
        private int _inretessePessoaId;

        #endregion

        #region Constructors

        public inretessePessoa()
        {
            _pessoaid = new HybridSet();
            _interresseid = new HybridSet();
        }

        #endregion

        #region Properties


        [PrimaryKey(PrimaryKeyType.Native, "inretessePessoaId")]
        public int inretessePessoaId
        {
            get { return _inretessePessoaId; }
            set { _inretessePessoaId = value; }
        }

        [HasAndBelongsToMany(typeof(Pessoa),
        Table = "inretessePessoa",
        CompositeKeyColumnRefs = new string[] { "pessoaId", "pessoaId" },
        ColumnKey = "inretessePessoaId",
        Lazy = true,
        Inverse = true,
        Cascade = ManyRelationCascadeEnum.SaveUpdate)]
        public ISet pessoaId
        {
            get { return _pessoaid; }
            set { _pessoaid = value; }
        }

        [HasAndBelongsToMany(typeof(Role),
        Table = "MenuRole",
        CompositeKeyColumnRefs = new string[] { "interresseId", "interresseId" },
        ColumnKey = "inretessePessoaId",
        Lazy = true,
        Inverse = true,
        Cascade = ManyRelationCascadeEnum.SaveUpdate)]
        public ISet interresseId
        {
            get { return _interresseid; }
            set { _interresseid = value; }
        }

        #endregion

    } // inretessePessoa
}


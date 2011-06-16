namespace Core.Model
{
    // Business class inretessePessoa generated from inretessePessoa
    // alexis [2011-06-13] Created

    using System;
    using System.ComponentModel;
    using Castle.ActiveRecord;
    using System.Collections;
    using System.Collections.Generic;
    using Castle.Components.Validator;

    [ActiveRecord("inretessePessoa")]
    public partial class inretessePessoa
        : ActiveRecordValidationBase<inretessePessoa>
    {

        #region Property_Names

        public static string Prop_pessoaId = "pessoaId";
        public static string Prop_interresseId = "interresseId";

        #endregion

        #region Private_Variables

        private Pessoa _pessoaid;
        private Interess _interresseid;


        #endregion

        #region Constructors

        public inretessePessoa()
        {
        }

        public inretessePessoa(
            Pessoa p_pessoaid,
            Interess p_interresseid)
        {
            _pessoaid = p_pessoaid;
            _interresseid = p_interresseid;
        }

        #endregion

        #region Properties

        [PrimaryKey("pessoaId", Access = PropertyAccess.NosetterLowercaseUnderscore)]
        public Pessoa pessoaId
        {
            get { return _pessoaid; }
        }

        [PrimaryKey("interresseId", Access = PropertyAccess.NosetterLowercaseUnderscore)]
        public Interess interresseId
        {
            get { return _interresseid; }
        }

        #endregion

    } // inretessePessoa
}


namespace Core.Model
{
    // Business class Interess generated from Interesses
    // alexis [2011-06-13] Created

    using System;
    using System.ComponentModel;
    using Castle.ActiveRecord;
    using System.Collections;
    using System.Collections.Generic;
    using Castle.Components.Validator;

    [ActiveRecord("Interesses")]
    public partial class Interess
        : ActiveRecordValidationBase<Interess>
    {

        #region Property_Names

        public static string Prop_interresseId = "interresseId";
        public static string Prop_interresseName = "interresseName";

        #endregion

        #region Private_Variables

        private int _interresseid;
        private string _interresseName;

        private IList _inretessePessoa = new List<inretessePessoa>();

        #endregion

        #region Constructors

        public Interess()
        {
        }

        public Interess(
            int p_interresseid,
            string p_interresseName)
        {
            _interresseid = p_interresseid;
            _interresseName = p_interresseName;
        }

        #endregion

        #region Properties

        [PrimaryKey("interresseId", Access = PropertyAccess.NosetterLowercaseUnderscore)]
        public int interresseId
        {
            get { return _interresseid; }
        }

        [Property("interresseName", Access = PropertyAccess.NosetterCamelcaseUnderscore, NotNull = true, Length = 255), ValidateLength(1, 255)]
        public string interresseName
        {
            get { return _interresseName; }
            set { _interresseName = value; }
        }

        [HasMany(typeof(inretessePessoa), Table = "inretessePessoa", ColumnKey = "interresseId")]
        public IList inretessePessoa
        {
            get { return _inretessePessoa; }
            set { _inretessePessoa = value; }
        }
        #endregion

    } // Interess
}


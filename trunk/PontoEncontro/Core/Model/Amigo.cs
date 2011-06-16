namespace Core.Model
{
    // Business class Amigo generated from Amigos
    // alexis [2011-06-13] Created

    using System;
    using System.ComponentModel;
    using Castle.ActiveRecord;
    using System.Collections;
    using System.Collections.Generic;
    using Castle.Components.Validator;

    [ActiveRecord("Amigos")]
    public partial class Amigo
        : ActiveRecordValidationBase<Amigo>
    {

        #region Property_Names

        public static string Prop_amigoId = "amigoId";

        #endregion

        #region Private_Variables

        private int _amigoid;

        private IList _MembroAmigo = new List<MembroAmigo>();

        #endregion

        #region Constructors

        public Amigo()
        {
        }

        public Amigo(
            int p_amigoid)
        {
            _amigoid = p_amigoid;
        }

        #endregion

        #region Properties

        [PrimaryKey("amigoId", Access = PropertyAccess.NosetterLowercaseUnderscore)]
        public int amigoId
        {
            get { return _amigoid; }
        }

        [HasMany(typeof(MembroAmigo), Table = "MembroAmigo", ColumnKey = "amigoId")]
        public IList MembroAmigo
        {
            get { return _MembroAmigo; }
            set { _MembroAmigo = value; }
        }

        #endregion

    } // Amigo
}


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

        #region Private_Variables

        private int _amigoid;

        private IList _MembroAmigo = new List<MembroAmigo>();

        #endregion

        #region Properties

        [PrimaryKey("amigoId", Access = PropertyAccess.NosetterLowercaseUnderscore)]
        public int amigoId
        {
            get { return _amigoid; }
            set { _amigoid = value; }
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


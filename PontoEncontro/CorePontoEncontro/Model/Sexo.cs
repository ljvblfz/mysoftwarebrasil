namespace CorePontoEncontro.Model
{
    // Business class Sexo generated from Sexo
    // alexis [2011-06-13] Created

    using System;
    using System.ComponentModel;
    using Castle.ActiveRecord;
    using System.Collections;
    using System.Collections.Generic;
    using Castle.Components.Validator;

    [ActiveRecord("Sexo")]
    public class Sexo : ActiveRecordValidationBase<Sexo>
    {

        #region Private_Variables

        private int _sexoid;
        private string _sexoName;

        #endregion

        #region Properties

        [PrimaryKey(PrimaryKeyType.Native, "sexoId")]
        public int sexoId
        {
            get { return _sexoid; }
            set { _sexoid = value; }
        }

        [Property("sexoName", Access = PropertyAccess.NosetterCamelcaseUnderscore, NotNull = true, Length = 255), ValidateLength(1, 255)]
        public string sexoName
        {
            get { return _sexoName; }
            set { _sexoName = value; }
        }

        #endregion

    } // Sexo
}


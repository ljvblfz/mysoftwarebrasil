namespace Model.DIADEMA_ONP
{
    using System;
    using System.Collections.Generic;
    using Castle.ActiveRecord;

    [Serializable, ActiveRecord("dbo.ONP_AGENTE")]
    public partial class ONPAGENTE : ActiveRecordValidationBase<ONPAGENTE>
    {
        #region Constructors

        public ONPAGENTE()
        {
        }

        #endregion

        #region Properties

        [PrimaryKey(Column = "cod_agente")]
        public int cod_agente { get; private set; }

        [Property(Column = "[nom_agente]", NotNull = true, Length = 40)]
        public string nom_agente { get; set; }

        [Property(Column = "[des_senha]", NotNull = true, Length = 40)]
        public string des_senha { get; set; }

        #endregion
    }
}

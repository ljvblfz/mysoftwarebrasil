namespace Model.DIADEMA_ONP
{
    using System;
    using System.Collections.Generic;
    using Castle.ActiveRecord;

    [Serializable, ActiveRecord("dbo.ONP_CATEGORIA")]
    public partial class ONPCATEGORIA : ActiveRecordValidationBase<ONPCATEGORIA>
    {
        #region Constructors

        public ONPCATEGORIA()
        {
        }

        #endregion

        #region Properties

        [PrimaryKey(Column = "seq_categoria")]
        public int seq_categoria { get; private set; }

        [Property(Column = "[des_categoria]", NotNull = true, Length = 30)]
        public string des_categoria { get; set; }

        #endregion
    }
}

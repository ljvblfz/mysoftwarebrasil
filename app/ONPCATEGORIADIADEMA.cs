namespace Model.DIADEMA_ONP
{
    using System;
    using System.Collections.Generic;
    using Castle.ActiveRecord;

    [Serializable, ActiveRecord("dbo.ONP_CATEGORIA_DIADEMA")]
    public partial class ONPCATEGORIADIADEMA : ActiveRecordValidationBase<ONPCATEGORIADIADEMA>
    {
        #region Constructors

        public ONPCATEGORIADIADEMA()
        {
        }

        #endregion

        #region Properties

        [PrimaryKey(Column = "seq_categoria")]
        public int seq_categoria { get; private set; }

        [Property(Column = "[val_minimo]")]
        public System.Decimal? val_minimo { get; set; }

        #endregion
    }
}

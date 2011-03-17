namespace Model.DIADEMA_ONP
{
    using System;
    using System.Collections.Generic;
    using Castle.ActiveRecord;

    [Serializable, ActiveRecord("dbo.ONP_DESCONTO_DIADEMA")]
    public partial class ONPDESCONTODIADEMA : ActiveRecordValidationBase<ONPDESCONTODIADEMA>
    {
        #region Constructors

        public ONPDESCONTODIADEMA()
        {
        }

        #endregion

        #region Properties

        [PrimaryKey(Column = "seq_desconto")]
        public int seq_desconto { get; private set; }

        [Property(Column = "[ind_tipo_desconto]", Length = 1)]
        public string ind_tipo_desconto { get; set; }

        [Property(Column = "[val_limite_inicial]")]
        public System.Decimal? val_limite_inicial { get; set; }

        [Property(Column = "[val_valor_desconto]")]
        public System.Decimal? val_valor_desconto { get; set; }

        #endregion
    }
}

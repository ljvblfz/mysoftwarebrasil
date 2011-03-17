namespace Model.DIADEMA_ONP
{
    using System;
    using System.Collections.Generic;
    using Castle.ActiveRecord;

    [Serializable, ActiveRecord("dbo.ONP_FATURA_IMPOSTO_DIADEMA")]
    public partial class ONPFATURAIMPOSTODIADEMA : ActiveRecordValidationBase<ONPFATURAIMPOSTODIADEMA>
    {
        #region Constructors

        public ONPFATURAIMPOSTODIADEMA()
        {
        }

        #endregion

        #region Properties

        [PrimaryKey(Column = "seq_fatura")]
        public int seq_fatura { get; private set; }

        [Property(Column = "[cod_referencia]", NotNull = true, Length = 8)]
        public string cod_referencia { get; set; }

        [Property(Column = "[seq_roteiro]", NotNull = true)]
        public System.Decimal seq_roteiro { get; set; }

        [Property(Column = "[seq_matricula]", NotNull = true)]
        public System.Decimal seq_matricula { get; set; }

        [Property(Column = "[cod_imposto]", NotNull = true, Length = 16)]
        public string cod_imposto { get; set; }

        [Property(Column = "[val_valor_calculado]")]
        public System.Decimal? val_valor_calculado { get; set; }

        #endregion
    }
}

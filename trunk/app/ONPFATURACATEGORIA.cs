namespace Model.DIADEMA_ONP
{
    using System;
    using System.Collections.Generic;
    using Castle.ActiveRecord;

    [Serializable, ActiveRecord("dbo.ONP_FATURA_CATEGORIA")]
    public partial class ONPFATURACATEGORIA : ActiveRecordValidationBase<ONPFATURACATEGORIA>
    {
        #region Constructors

        public ONPFATURACATEGORIA()
        {
        }

        #endregion

        #region Properties

        [PrimaryKey(Column = "seq_categoria")]
        public int seq_categoria { get; private set; }

        [Property(Column = "[seq_fatura]", NotNull = true)]
        public System.Decimal seq_fatura { get; set; }

        [Property(Column = "[cod_referencia]", NotNull = true, Length = 8)]
        public string cod_referencia { get; set; }

        [Property(Column = "[seq_roteiro]", NotNull = true)]
        public System.Decimal seq_roteiro { get; set; }

        [Property(Column = "[seq_matricula]", NotNull = true)]
        public System.Decimal seq_matricula { get; set; }

        [Property(Column = "[val_numero_economia]")]
        public System.Decimal? val_numero_economia { get; set; }

        [Property(Column = "[val_valor_faturado]")]
        public System.Decimal? val_valor_faturado { get; set; }

        #endregion
    }
}

namespace Model.DIADEMA_ONP
{
    using System;
    using System.Collections.Generic;
    using Castle.ActiveRecord;

    [Serializable, ActiveRecord("dbo.ONP_FATURA_TAXA")]
    public partial class ONPFATURATAXA : ActiveRecordValidationBase<ONPFATURATAXA>
    {
        #region Constructors

        public ONPFATURATAXA()
        {
        }

        #endregion

        #region Properties

        [PrimaryKey(Column = "seq_taxa")]
        public int seq_taxa { get; private set; }

        [Property(Column = "[seq_categoria]", NotNull = true)]
        public System.Decimal seq_categoria { get; set; }

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

        [Property(Column = "[val_consumo_faturado]")]
        public System.Decimal? val_consumo_faturado { get; set; }

        [Property(Column = "[val_valor_calculado]")]
        public System.Decimal? val_valor_calculado { get; set; }

        [Property(Column = "[val_valor_faturado]")]
        public System.Decimal? val_valor_faturado { get; set; }

        [Property(Column = "[ind_situacao]", Length = 1)]
        public string ind_situacao { get; set; }

        [Property(Column = "[ind_tipo_consumo]", Length = 1)]
        public string ind_tipo_consumo { get; set; }

        #endregion
    }
}

namespace Model.DIADEMA_ONP
{
    using System;
    using System.Collections.Generic;
    using Castle.ActiveRecord;

    [Serializable, ActiveRecord("dbo.ONP_FATURA_SERVICO")]
    public partial class ONPFATURASERVICO : ActiveRecordValidationBase<ONPFATURASERVICO>
    {
        #region Constructors

        public ONPFATURASERVICO()
        {
        }

        #endregion

        #region Properties

        [PrimaryKey(Column = "seq_fatura")]
        public int seq_fatura { get; private set; }

        [Property(Column = "[seq_item_servico]", NotNull = true)]
        public System.Decimal seq_item_servico { get; set; }

        [Property(Column = "[cod_referencia]", NotNull = true, Length = 8)]
        public string cod_referencia { get; set; }

        [Property(Column = "[seq_roteiro]", NotNull = true)]
        public System.Decimal seq_roteiro { get; set; }

        [Property(Column = "[seq_matricula]", NotNull = true)]
        public System.Decimal seq_matricula { get; set; }

        [Property(Column = "[des_servico]", Length = 60)]
        public string des_servico { get; set; }

        [Property(Column = "[seq_parcela]")]
        public System.Decimal? seq_parcela { get; set; }

        [Property(Column = "[val_parcela]")]
        public System.Decimal? val_parcela { get; set; }

        [Property(Column = "[ind_credito]", Length = 1)]
        public string ind_credito { get; set; }

        #endregion
    }
}

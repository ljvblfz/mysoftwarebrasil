namespace Model.DIADEMA_ONP
{
    using System;
    using System.Collections.Generic;
    using Castle.ActiveRecord;

    [Serializable, ActiveRecord("dbo.ONP_AVISO_DEBITO")]
    public partial class ONPAVISODEBITO : ActiveRecordValidationBase<ONPAVISODEBITO>
    {
        #region Constructors

        public ONPAVISODEBITO()
        {
        }

        #endregion

        #region Properties

        [PrimaryKey(Column = "seq_matricula")]
        public int seq_matricula { get; private set; }

        [Property(Column = "[dat_emissao]", NotNull = true)]
        public DateTime dat_emissao { get; set; }

        [Property(Column = "[ind_documento]", Length = 1)]
        public string ind_documento { get; set; }

        [Property(Column = "[ind_pagavel]", Length = 1)]
        public string ind_pagavel { get; set; }

        [Property(Column = "[val_quantidade_debito]")]
        public System.Decimal? val_quantidade_debito { get; set; }

        [Property(Column = "[val_impressoes]")]
        public System.Decimal? val_impressoes { get; set; }

        [Property(Column = "[ind_protocolado]", Length = 1)]
        public string ind_protocolado { get; set; }

        [Property(Column = "[seq_fatura]")]
        public System.Decimal? seq_fatura { get; set; }

        #endregion
    }
}

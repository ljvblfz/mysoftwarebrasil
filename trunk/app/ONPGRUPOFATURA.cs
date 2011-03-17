namespace Model.DIADEMA_ONP
{
    using System;
    using System.Collections.Generic;
    using Castle.ActiveRecord;

    [Serializable, ActiveRecord("dbo.ONP_GRUPO_FATURA")]
    public partial class ONPGRUPOFATURA : ActiveRecordValidationBase<ONPGRUPOFATURA>
    {
        #region Constructors

        public ONPGRUPOFATURA()
        {
        }

        #endregion

        #region Properties

        [PrimaryKey(Column = "seq_grupo_fatura")]
        public int seq_grupo_fatura { get; private set; }

        [Property(Column = "[ind_tipo_vencimento]", Length = 1)]
        public string ind_tipo_vencimento { get; set; }

        [Property(Column = "[num_dias]")]
        public System.Decimal? num_dias { get; set; }

        [Property(Column = "[des_dias_vencimento]", Length = 256)]
        public string des_dias_vencimento { get; set; }

        #endregion
    }
}

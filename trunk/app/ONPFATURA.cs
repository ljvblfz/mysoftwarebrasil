namespace Model.DIADEMA_ONP
{
    using System;
    using System.Collections.Generic;
    using Castle.ActiveRecord;

    [Serializable, ActiveRecord("dbo.ONP_FATURA")]
    public partial class ONPFATURA : ActiveRecordValidationBase<ONPFATURA>
    {
        #region Constructors

        public ONPFATURA()
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

        [Property(Column = "[seq_tipo_entrega]")]
        public System.Decimal? seq_tipo_entrega { get; set; }

        [Property(Column = "[cod_hidrometro]", Length = 12)]
        public string cod_hidrometro { get; set; }

        [Property(Column = "[ind_fatura_emitida]", Length = 1)]
        public string ind_fatura_emitida { get; set; }

        [Property(Column = "[dat_vencimento]")]
        public DateTime? dat_vencimento { get; set; }

        [Property(Column = "[val_arredonda_anterior]")]
        public System.Decimal? val_arredonda_anterior { get; set; }

        [Property(Column = "[val_arredonda_atual]")]
        public System.Decimal? val_arredonda_atual { get; set; }

        [Property(Column = "[dat_hora_emissao]")]
        public DateTime? dat_hora_emissao { get; set; }

        [Property(Column = "[val_valor_faturado]")]
        public System.Decimal? val_valor_faturado { get; set; }

        [Property(Column = "[dat_leitura]")]
        public DateTime? dat_leitura { get; set; }

        [Property(Column = "[dat_leitura_anterior]")]
        public DateTime? dat_leitura_anterior { get; set; }

        [Property(Column = "[ind_entrega_especial]", Length = 1)]
        public string ind_entrega_especial { get; set; }

        [Property(Column = "[des_banco_debito]", Length = 30)]
        public string des_banco_debito { get; set; }

        [Property(Column = "[des_banco_agencia_debito]", Length = 20)]
        public string des_banco_agencia_debito { get; set; }

        [Property(Column = "[val_quantidade_pendente]")]
        public System.Decimal? val_quantidade_pendente { get; set; }

        [Property(Column = "[val_consumo_medio]")]
        public System.Decimal? val_consumo_medio { get; set; }

        [Property(Column = "[val_desconto]")]
        public System.Decimal? val_desconto { get; set; }

        [Property(Column = "[des_linha_digitavel]", Length = 48)]
        public string des_linha_digitavel { get; set; }

        [Property(Column = "[des_codigo_barras]", Length = 44)]
        public string des_codigo_barras { get; set; }

        [Property(Column = "[val_consumo_medido]")]
        public System.Decimal? val_consumo_medido { get; set; }

        [Property(Column = "[val_consumo_atribuido]")]
        public System.Decimal? val_consumo_atribuido { get; set; }

        [Property(Column = "[val_consumo_rateado]")]
        public System.Decimal? val_consumo_rateado { get; set; }

        [Property(Column = "[val_leitura_anterior]")]
        public System.Decimal? val_leitura_anterior { get; set; }

        [Property(Column = "[val_leitura_real]")]
        public System.Decimal? val_leitura_real { get; set; }

        [Property(Column = "[val_leitura_atribuida]")]
        public System.Decimal? val_leitura_atribuida { get; set; }

        [Property(Column = "[val_impressoes]")]
        public System.Decimal? val_impressoes { get; set; }

        [Property(Column = "[dat_proxima_leitura]")]
        public DateTime? dat_proxima_leitura { get; set; }

        [Property(Column = "[val_valor_credito]")]
        public System.Decimal? val_valor_credito { get; set; }

        #endregion
    }
}

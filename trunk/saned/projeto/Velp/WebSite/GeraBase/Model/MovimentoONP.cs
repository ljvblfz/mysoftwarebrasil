using System;
using GDA;
using System.Runtime.Serialization;

namespace GeraBase.Model
{
    /// <summary>
    /// Classe que representa a tabela ONP_MOVIMENTO.
    /// </summary>
    [PersistenceClass("ONP_MOVIMENTO")]
    [Serializable]
    public class MovimentoONP : Persistent
    {
		private int _seq_matricula;
        private string _ind_situacao_movimento;
        private int _seq_roteiro;
        private string _cod_referencia;
        private int _cod_agente;
        private string _cod_hidrometro;
        private int _val_numero_leituras;
        private int _dat_vencimento;
        private int _val_consumo_medio;
        private string _des_banco_debito;
        private string _des_banco_agencia_debito;
        private int _ind_entrega_especial;
        private DateTime _dat_leitura_anterior;
        private DateTime _dat_proxima_leitura;
        private int _val_leitura_anterior;
        private DateTime? _dat_troca;
        private int _val_consumo_troca;
        private int _val_quantidade_pendente;
        private string _ind_leitura_divergente;
        private string _ind_fatura_emitida;
        private int _val_impressoes;

        [PersistenceProperty("val_impressoes")]
        public int val_impressoes { get; set; }

        [PersistenceProperty("ind_fatura_emitida")]
        public string ind_fatura_emitida { get; set; }

        [PersistenceProperty("ind_leitura_divergente")]
        public string ind_leitura_divergente { get; set; }

        [PersistenceProperty("seq_matricula")]
        public int seq_matricula { get; set; }

        [PersistenceProperty("ind_situacao_movimento")]
        public string ind_situacao_movimento { get; set; }

        [PersistenceProperty("seq_roteiro")]
        public int seq_roteiro { get; set; }

        [PersistenceProperty("cod_referencia")]
        public string cod_referencia { get; set; }

        [PersistenceProperty("cod_agente")]
        public int cod_agente { get; set; }

        [PersistenceProperty("cod_hidrometro")]
        public string cod_hidrometro { get; set; }

        [PersistenceProperty("val_numero_leituras")]
        public int val_numero_leituras { get; set; }

        [PersistenceProperty("dat_vencimento")]
        public DateTime dat_vencimento { get; set; }

        [PersistenceProperty("val_consumo_medio")]
        public int val_consumo_medio { get; set; }

        [PersistenceProperty("des_banco_debito")]
        public string des_banco_debito { get; set; }

        [PersistenceProperty("des_banco_agencia_debito")]
        public string des_banco_agencia_debito { get; set; }

        [PersistenceProperty("ind_entrega_especial")]
        public int ind_entrega_especial { get; set; }

        [PersistenceProperty("dat_leitura_anterior")]
        public DateTime dat_leitura_anterior { get; set; }

        [PersistenceProperty("dat_proxima_leitura")]
        public DateTime dat_proxima_leitura { get; set; }

        [PersistenceProperty("val_leitura_anterior")]
        public int val_leitura_anterior { get; set; }

        [PersistenceProperty("dat_troca")]
        public DateTime? dat_troca { get; set; }

        [PersistenceProperty("val_consumo_troca")]
        public int val_consumo_troca { get; set; }

        [PersistenceProperty("val_quantidade_pendente")]
        public int val_quantidade_pendente { get; set; }
    }
}




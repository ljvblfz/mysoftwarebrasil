using System;
using GDA;
using System.Runtime.Serialization;
using Data.DAL;

namespace Data.Model
{
    /// <summary>
    /// Classe que não representa nenhuma tabela (criada a otimização de consulta).
    /// </summary>
    [PersistenceBaseDAO(typeof(CriticaDAO))]
    [Serializable]
    public class Critica : Persistent
    {
        #region Local Variables
        private int _Codigo_Logradouro;
        private int? _Numero_Imovel;
        private string _Complemento;
        private string _Inscricao;
        private int _Grupo;
        private int _Setor;
        private int _Rota;
        private int _Sequencia;
        private string _Cachorro;
        private int _CDC;
        private int? _CDC_Pai;
        private int? _Media;
        private string _Medidor;
        private int _Categoria_Imovel;
        private int _Natureza_Ligacao;
        private int? _Eco_Res;
        private int? _Eco_Com;
        private int? _Eco_Ind;
        private int? _Eco_Pub;
        private int? _Eco_Soc;
        private string _Bloqueado;
        private DateTime? _Data_Bloqueio;
        private DateTime? _Data_DesBloqueio;
        private int? _Qtde_Debitos;
        private string _Mensagem1;
        private string _Mensagem2;
        private int? _Qtde_Registros_Fraude;
        private int _Clas_Imovel;
        private int _Ident_Consumidor;
        private string _Ident_Calculo;
        private string _Emite_Conta;
        private DateTime? _Data_Inst_HD;
        private int? _Leitura_Inicial_HD;
        private int? _Qtde_Ponteiros;
        private string _Cortar;
        private string _Nome;
        private int? _Agencia;
        private int? _Banco;
        private DateTime _Data_Vencimento;
        private string _Calcula_Imposto;
        private string _Endereco_Entrega;
        private string _Calcula_Conta;
        private int _Dias_Bloqueio_Tarifa_Ant;
        private int _Dias_Bloqueio_Tarifa_Atual;
        private string _Ident_Ligacao_Nova;

        private int? _Leitura_Ajustada;
        private int? _Leitura_Real;
        private DateTime? _Data_Leitura;
        private int? _Consumo_Ajustado;
        private int? _Esgoto_Ajustado;
        private int? _Dias_Consumo;
        private int? _Ocorrencia;
        private string _Ident_fraude;
        private string _Indic_cortado;
        private int? _Operador;
        private string _Flag_Calculo;
        private string _Flag_Emissao;
        private DateTime _Referencia;
        private DateTime? _Data_Emissao;
        private DateTime? _Vencimento;
        private decimal? _Valor_Agua;
        private decimal? _Valor_Esgoto;
        private decimal? _Valor_Credito;
        private decimal? _Valor_Reducao;
        private decimal? _Valor_IR;
        private decimal? _Valor_CSLL;
        private decimal? _Valor_PIS;
        private decimal? _Valor_COFINS;
        private int _Categoria;
        private int? _Consumo_Rateado;
        private decimal? _Valor_Saldo_Debito;
        private string _Flag_Lido;
        private string _Flag_Faturado;
        private int? _Ocorrencia2;
        private string _Flag_Situacao_Movimento;
        private string _Flag_Repasse;
        private string _Tipo;

        #endregion

        #region Metodos
        [PersistenceProperty("Codigo_Logradouro")]
        public int Codigo_Logradouro { get; set; }

        [PersistenceProperty("Numero_Imovel")]
        public int? Numero_Imovel { get; set; }

        [PersistenceProperty("Complemento")]
        public string Complemento { get; set; }

        [PersistenceProperty("Inscricao")]
        public string Inscricao { get; set; }

        [PersistenceProperty("Grupo")]
        public int Grupo { get; set; }

        [PersistenceProperty("Setor")]
        public int Setor { get; set; }

        [PersistenceProperty("Rota")]
        public int Rota { get; set; }

        [PersistenceProperty("Sequencia")]
        public int Sequencia { get; set; }

        [PersistenceProperty("Cachorro")]
        public string Cachorro { get; set; }

        [PersistenceProperty("CDC")]
        public int CDC { get; set; }

        [PersistenceProperty("CDC_Pai")]
        public int? CDC_Pai { get; set; }

        [PersistenceProperty("Media")]
        public int? Media { get; set; }

        [PersistenceProperty("Medidor")]
        public string Medidor { get; set; }

        [PersistenceProperty("Categoria_Imovel")]
        public int Categoria_Imovel { get; set; }

        [PersistenceProperty("Natureza_Ligacao")]
        public int Natureza_Ligacao { get; set; }

        [PersistenceProperty("Eco_Res")]
        public int? Eco_Res { get; set; }

        [PersistenceProperty("Eco_Com")]
        public int? Eco_Com { get; set; }

        [PersistenceProperty("Eco_Ind")]
        public int? Eco_Ind { get; set; }

        [PersistenceProperty("Eco_Pub")]
        public int? Eco_Pub { get; set; }

        [PersistenceProperty("Eco_Soc")]
        public int? Eco_Soc { get; set; }

        [PersistenceProperty("Bloqueado")]
        public string Bloqueado { get; set; }

        [PersistenceProperty("Data_Bloqueio")]
        public DateTime? Data_Bloqueio { get; set; }

        [PersistenceProperty("Data_DesBloqueio")]
        public DateTime? Data_DesBloqueio { get; set; }

        [PersistenceProperty("Qtde_Debitos")]
        public int? Qtde_Debitos { get; set; }

        [PersistenceProperty("Mensagem1")]
        public string Mensagem1 { get; set; }

        [PersistenceProperty("Mensagem2")]
        public string Mensagem2 { get; set; }

        [PersistenceProperty("Qtde_Registros_Fraude")]
        public int? Qtde_Registros_Fraude { get; set; }

        [PersistenceProperty("Clas_Imovel")]
        public int Clas_Imovel { get; set; }

        [PersistenceProperty("Ident_Consumidor")]
        public int Ident_Consumidor { get; set; }

        [PersistenceProperty("Ident_Calculo")]
        public string Ident_Calculo { get; set; }

        [PersistenceProperty("Emite_Conta")]
        public string Emite_Conta { get; set; }

        [PersistenceProperty("Data_Inst_HD")]
        public DateTime? Data_Inst_HD { get; set; }

        [PersistenceProperty("Leitura_Inicial_HD")]
        public int? Leitura_Inicial_HD { get; set; }

        [PersistenceProperty("Qtde_Ponteiros")]
        public int? Qtde_Ponteiros { get; set; }

        [PersistenceProperty("Cortar")]
        public string Cortar { get; set; }

        [PersistenceProperty("Nome")]
        public string Nome { get; set; }

        [PersistenceProperty("Agencia")]
        public int? Agencia { get; set; }

        [PersistenceProperty("Banco")]
        public int? Banco { get; set; }

        [PersistenceProperty("Data_Vencimento")]
        public DateTime Data_Vencimento { get; set; }

        [PersistenceProperty("Calcula_Imposto")]
        public string Calcula_Imposto { get; set; }

        [PersistenceProperty("Endereco_Entrega")]
        public string Endereco_Entrega { get; set; }

        [PersistenceProperty("Calcula_Conta")]
        public string Calcula_Conta { get; set; }

        [PersistenceProperty("Dias_Bloqueio_Tarifa_Ant")]
        public int Dias_Bloqueio_Tarifa_Ant { get; set; }

        [PersistenceProperty("Dias_Bloqueio_Tarifa_Atual")]
        public int Dias_Bloqueio_Tarifa_Atual { get; set; }

        [PersistenceProperty("Ident_Ligacao_Nova")]
        public string Ident_Ligacao_Nova { get; set; }

        [PersistenceProperty("Leitura_Ajustada")]
        public int? Leitura_Ajustada { get; set; }

        [PersistenceProperty("Leitura_Real")]
        public int? Leitura_Real { get; set; }

        [PersistenceProperty("Data_Leitura")]
        public DateTime? Data_Leitura { get; set; }

        [PersistenceProperty("Consumo_Ajustado")]
        public int? Consumo_Ajustado { get; set; }

        [PersistenceProperty("Esgoto_Ajustado")]
        public int? Esgoto_Ajustado { get; set; }

        [PersistenceProperty("Dias_Consumo")]
        public int? Dias_Consumo { get; set; }

        [PersistenceProperty("Ocorrencia")]
        public int? Ocorrencia { get; set; }

        [PersistenceProperty("Ident_fraude")]
        public string Ident_fraude { get; set; }

        [PersistenceProperty("Indic_cortado")]
        public string Indic_cortado { get; set; }

        [PersistenceProperty("Operador")]
        public int? Operador { get; set; }

        [PersistenceProperty("Flag_Calculo")]
        public string Flag_Calculo { get; set; }

        [PersistenceProperty("Flag_Emissao")]
        public string Flag_Emissao { get; set; }

        [PersistenceProperty("Referencia")]
        public DateTime Referencia
        {
            get
            {
                return _Referencia;
            }
            set
            {
                _Referencia = value;
            }
        }

        [PersistenceProperty("Data_Emissao")]
        public DateTime? Data_Emissao { get; set; }

        [PersistenceProperty("Vencimento")]
        public DateTime? Vencimento { get; set; }

        [PersistenceProperty("Valor_Agua")]
        public decimal? Valor_Agua { get; set; }

        [PersistenceProperty("Valor_Esgoto")]
        public decimal? Valor_Esgoto { get; set; }

        [PersistenceProperty("Valor_Credito")]
        public decimal? Valor_Credito { get; set; }

        [PersistenceProperty("Valor_Reducao")]
        public decimal? Valor_Reducao { get; set; }

        [PersistenceProperty("Valor_IR")]
        public decimal? Valor_IR { get; set; }

        [PersistenceProperty("Valor_CSLL")]
        public decimal? Valor_CSLL { get; set; }

        [PersistenceProperty("Valor_PIS")]
        public decimal? Valor_PIS { get; set; }

        [PersistenceProperty("Valor_COFINS")]
        public decimal? Valor_COFINS { get; set; }

        [PersistenceProperty("Categoria")]
        public int Categoria { get; set; }
        [PersistenceProperty("Consumo_Rateado")]
        public int? Consumo_Rateado { get; set; }

        [PersistenceProperty("Valor_Saldo_Debito")]
        public decimal? Valor_Saldo_Debito { get; set; }

        [PersistenceProperty("Flag_Lido")]
        public string Flag_Lido { get; set; }

        [PersistenceProperty("Flag_Faturado")]
        public string Flag_Faturado { get; set; }

        [PersistenceProperty("Ocorrencia2")]
        public int? Ocorrencia2 { get; set; }

        [PersistenceProperty("Flag_Situacao_Movimento")]
        public string Flag_Situacao_Movimento { get; set; }

        [PersistenceProperty("Flag_Repasse")]
        public string Flag_Repasse { get; set; }

        [PersistenceProperty("Tipo")]
        public string Tipo { get; set; }

        #endregion

        #region Propriedades de Suporte

        /// <summary>
        ///  Extende do campo Natureza_Ligacao
        /// </summary>
        public string Extend_Natureza_Ligacao
        {
            get
            {
                if (Natureza_Ligacao == 1)
                    return "Agua";
                else
                    return "Agua/Esgoto";
            }
        }

        #endregion
    }
}
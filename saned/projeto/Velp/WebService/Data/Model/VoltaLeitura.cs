using System;
using GDA;
using System.Runtime.Serialization;
using Data.DAL;

namespace Data.Model
{
    /// <summary>
    /// Classe que representa a tabela VOLTA_LEITURA.
    /// </summary>
    [PersistenceClass("VOLTA_LEITURA")]
    [PersistenceBaseDAO(typeof(VoltaLeituraDAO))]
    [Serializable]
    public class VoltaLeitura : Persistent
    {
        #region Local Variables
        private int _Grupo;
        private int _Setor;
        private int _Rota;
        private int _CDC;
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
        private int _Eco_Res;
        private int _Eco_Com;
        private int _Eco_Ind;
        private int _Eco_Pub;
        private int _Eco_Soc;
        private int? _Consumo_Rateado;
        private decimal? _Valor_Saldo_Debito;
        private string _Flag_Lido;
        private string _Flag_Faturado;
        private int? _Ocorrencia2;
        private string _Flag_Situacao_Movimento;
        private string _Flag_Repasse;

        #endregion

        #region Metodos
        [PersistenceProperty("Grupo")]
        public int Grupo
        {
            get
            {
                return _Grupo;
            }
            set
            {
                _Grupo = value;
            }

        }
        [PersistenceProperty("Setor")]
        public int Setor
        {
            get
            {
                return _Setor;
            }
            set
            {
                _Setor = value;
            }

        }
        [PersistenceProperty("Rota")]
        public int Rota
        {
            get
            {
                return _Rota;
            }
            set
            {
                _Rota = value;
            }

        }
        [PersistenceProperty("CDC",PersistenceParameterType.Key)]
        public int CDC
        {
            get
            {
                return _CDC;
            }
            set
            {
                _CDC = value;
            }

        }
        [PersistenceProperty("Leitura_Ajustada")]
        public int? Leitura_Ajustada
        {
            get
            {
                return _Leitura_Ajustada;
            }
            set
            {
                _Leitura_Ajustada = value;
            }

        }
        [PersistenceProperty("Leitura_Real")]
        public int? Leitura_Real
        {
            get
            {
                return _Leitura_Real;
            }
            set
            {
                _Leitura_Real = value;
            }

        }
        [PersistenceProperty("Data_Leitura")]
        public DateTime? Data_Leitura
        {
            get
            {
                return _Data_Leitura;
            }
            set
            {
                _Data_Leitura = value;
            }

        }
        [PersistenceProperty("Consumo_Ajustado")]
        public int? Consumo_Ajustado
        {
            get
            {
                return _Consumo_Ajustado;
            }
            set
            {
                _Consumo_Ajustado = value;
            }

        }
        [PersistenceProperty("Esgoto_Ajustado")]
        public int? Esgoto_Ajustado
        {
            get
            {
                return _Esgoto_Ajustado;
            }
            set
            {
                _Esgoto_Ajustado = value;
            }

        }
        [PersistenceProperty("Dias_Consumo")]
        public int? Dias_Consumo
        {
            get
            {
                return _Dias_Consumo;
            }
            set
            {
                _Dias_Consumo = value;
            }

        }
        [PersistenceProperty("Ocorrencia")]
        public int? Ocorrencia
        {
            get
            {
                return _Ocorrencia;
            }
            set
            {
                _Ocorrencia = value;
            }

        }
        [PersistenceProperty("Ident_fraude")]
        public string Ident_fraude
        {
            get
            {
                return _Ident_fraude;
            }
            set
            {
                _Ident_fraude = value;
            }

        }
        [PersistenceProperty("Indic_cortado")]
        public string Indic_cortado
        {
            get
            {
                return _Indic_cortado;
            }
            set
            {
                _Indic_cortado = value;
            }

        }
        [PersistenceProperty("Operador")]
        public int? Operador
        {
            get
            {
                return _Operador;
            }
            set
            {
                _Operador = value;
            }

        }
        [PersistenceProperty("Flag_Calculo")]
        public string Flag_Calculo
        {
            get
            {
                return _Flag_Calculo;
            }
            set
            {
                _Flag_Calculo = value;
            }

        }
        [PersistenceProperty("Flag_Emissao")]
        public string Flag_Emissao
        {
            get
            {
                return _Flag_Emissao;
            }
            set
            {
                _Flag_Emissao = value;
            }

        }
        [PersistenceProperty("Referencia", PersistenceParameterType.Key)]
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
        public DateTime? Data_Emissao
        {
            get
            {
                return _Data_Emissao;
            }
            set
            {
                _Data_Emissao = value;
            }

        }
        [PersistenceProperty("Vencimento")]
        public DateTime? Vencimento
        {
            get
            {
                return _Vencimento;
            }
            set
            {
                _Vencimento = value;
            }

        }
        [PersistenceProperty("Valor_Agua")]
        public decimal? Valor_Agua
        {
            get
            {
                return _Valor_Agua;
            }
            set
            {
                _Valor_Agua = value;
            }

        }
        [PersistenceProperty("Valor_Esgoto")]
        public decimal? Valor_Esgoto
        {
            get
            {
                return _Valor_Esgoto;
            }
            set
            {
                _Valor_Esgoto = value;
            }

        }
        [PersistenceProperty("Valor_Credito")]
        public decimal? Valor_Credito
        {
            get
            {
                return _Valor_Credito;
            }
            set
            {
                _Valor_Credito = value;
            }

        }
        [PersistenceProperty("Valor_Reducao")]
        public decimal? Valor_Reducao
        {
            get
            {
                return _Valor_Reducao;
            }
            set
            {
                _Valor_Reducao = value;
            }

        }
        [PersistenceProperty("Valor_IR")]
        public decimal? Valor_IR
        {
            get
            {
                return _Valor_IR;
            }
            set
            {
                _Valor_IR = value;
            }

        }
        [PersistenceProperty("Valor_CSLL")]
        public decimal? Valor_CSLL
        {
            get
            {
                return _Valor_CSLL;
            }
            set
            {
                _Valor_CSLL = value;
            }

        }
        [PersistenceProperty("Valor_PIS")]
        public decimal? Valor_PIS
        {
            get
            {
                return _Valor_PIS;
            }
            set
            {
                _Valor_PIS = value;
            }

        }
        [PersistenceProperty("Valor_COFINS")]
        public decimal? Valor_COFINS
        {
            get
            {
                return _Valor_COFINS;
            }
            set
            {
                _Valor_COFINS = value;
            }

        }
        [PersistenceProperty("Categoria")]
        public int Categoria
        {
            get
            {
                return _Categoria;
            }
            set
            {
                _Categoria = value;
            }

        }
        [PersistenceProperty("Eco_Res")]
        public int Eco_Res
        {
            get
            {
                return _Eco_Res;
            }
            set
            {
                _Eco_Res = value;
            }

        }
        [PersistenceProperty("Eco_Com")]
        public int Eco_Com
        {
            get
            {
                return _Eco_Com;
            }
            set
            {
                _Eco_Com = value;
            }

        }
        [PersistenceProperty("Eco_Ind")]
        public int Eco_Ind
        {
            get
            {
                return _Eco_Ind;
            }
            set
            {
                _Eco_Ind = value;
            }

        }
        [PersistenceProperty("Eco_Pub")]
        public int Eco_Pub
        {
            get
            {
                return _Eco_Pub;
            }
            set
            {
                _Eco_Pub = value;
            }

        }
        [PersistenceProperty("Eco_Soc")]
        public int Eco_Soc
        {
            get
            {
                return _Eco_Soc;
            }
            set
            {
                _Eco_Soc = value;
            }

        }
        [PersistenceProperty("Consumo_Rateado")]
        public int? Consumo_Rateado
        {
            get
            {
                return _Consumo_Rateado;
            }
            set
            {
                _Consumo_Rateado = value;
            }

        }
        [PersistenceProperty("Valor_Saldo_Debito")]
        public decimal? Valor_Saldo_Debito
        {
            get
            {
                return _Valor_Saldo_Debito;
            }
            set
            {
                _Valor_Saldo_Debito = value;
            }

        }
        [PersistenceProperty("Flag_Lido")]
        public string Flag_Lido
        {
            get
            {
                return _Flag_Lido;
            }
            set
            {
                _Flag_Lido = value;
            }

        }
        [PersistenceProperty("Flag_Faturado")]
        public string Flag_Faturado
        {
            get
            {
                return _Flag_Faturado;
            }
            set
            {
                _Flag_Faturado = value;
            }

        }
        [PersistenceProperty("Ocorrencia2")]
        public int? Ocorrencia2
        {
            get
            {
                return _Ocorrencia2;
            }
            set
            {
                _Ocorrencia2 = value;
            }

        }
        [PersistenceProperty("Flag_Situacao_Movimento")]
        public string Flag_Situacao_Movimento
        {
            get
            {
                return _Flag_Situacao_Movimento;
            }
            set
            {
                _Flag_Situacao_Movimento = value;
            }

        }
        [PersistenceProperty("Flag_Repasse")]
        public string Flag_Repasse
        {
            get
            {
                return _Flag_Repasse;
            }
            set
            {
                _Flag_Repasse = value;
            }

        }

        #endregion
    }
}
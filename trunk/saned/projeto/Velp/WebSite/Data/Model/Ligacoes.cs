using System;
using GDA;
using System.Runtime.Serialization;
using Data.DAL;

namespace Data.Model
{
    /// <summary>
    /// Classe que representa a tabela IDA_LIGACOES.
    /// </summary>
    [PersistenceClass("IDA_LIGACOES")]
    [PersistenceBaseDAO(typeof(LigacoesDAO))]
    [Serializable]
    public class Ligacoes : Persistent
    {
    	#region Local Variables
		private int  _Codigo_Logradouro;
        private int?  _Numero_Imovel;
        private string  _Complemento;
        private string  _Inscricao;
        private int  _Grupo;
        private int  _Setor;
        private int  _Rota;
        private int  _Sequencia;
        private string  _Cachorro;
        private int  _CDC;
        private int?  _CDC_Pai;
        private int?  _Media;
        private string  _Medidor;
        private int  _Categoria_Imovel;
        private int  _Natureza_Ligacao;
        private int?  _Eco_Res;
        private int?  _Eco_Com;
        private int?  _Eco_Ind;
        private int?  _Eco_Pub;
        private int?  _Eco_Soc;
        private string  _Bloqueado;
        private DateTime?  _Data_Bloqueio;
        private DateTime?  _Data_DesBloqueio;
        private int?  _Qtde_Debitos;
        private string  _Mensagem1;
        private string  _Mensagem2;
        private int?  _Qtde_Registros_Fraude;
        private int  _Clas_Imovel;
        private int  _Ident_Consumidor;
        private string  _Ident_Calculo;
        private string  _Emite_Conta;
        private DateTime?  _Data_Inst_HD;
        private int?  _Leitura_Inicial_HD;
        private int?  _Qtde_Ponteiros;
        private string  _Cortar;
        private string  _Nome;
        private int?  _Agencia;
        private int?  _Banco;
        private DateTime  _Data_Vencimento;
        private string  _Calcula_Imposto;
        private string  _Endereco_Entrega;
        private string  _Calcula_Conta;
        private int  _Dias_Bloqueio_Tarifa_Ant;
        private int  _Dias_Bloqueio_Tarifa_Atual;
        private string  _Ident_Ligacao_Nova;

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
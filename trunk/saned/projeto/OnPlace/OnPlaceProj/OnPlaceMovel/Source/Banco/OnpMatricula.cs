using System;
using System.Text;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Strategos.Api.Database.Impl;
using Strategos.Api.Database.Attributes;

namespace OnPlaceMovel.Source.Banco {
    [Table(TableName = "onp_Matricula")]
    public sealed class OnpMatricula : PersistClass<OnpMatricula> {
        #region Atributos e Propriedades
        private int? seqMatricula;
        [Column(ColumnName = "seq_Matricula", Pk = true)]
        public int? SeqMatricula {
            get {
                return seqMatricula;
            }
            set {
                seqMatricula = value;
            }
        }
        private string nomCliente;
        [Column(ColumnName = "nom_Cliente")]
        public string NomCliente {
            get {
                return nomCliente;
            }
            set {
                nomCliente = value;
            }
        }
        private int? seqLogradouro;
        [Column(ColumnName = "seq_Logradouro")]
        public int? SeqLogradouro {
            get {
                return seqLogradouro;
            }
            set {
                seqLogradouro = value;
            }
        }
        private int? seqUtilizacaoLigacao;
        [Column(ColumnName = "seq_Utilizacao_Ligacao")]
        public int? SeqUtilizacaoLigacao {
            get {
                return seqUtilizacaoLigacao;
            }
            set {
                seqUtilizacaoLigacao = value;
            }
        }
        private int? valNumeroImovel;
        [Column(ColumnName = "val_Numero_Imovel")]
        public int? ValNumeroImovel {
            get {
                return valNumeroImovel;
            }
            set {
                valNumeroImovel = value;
            }
        }
        private string desComplemento;
        [Column(ColumnName = "des_Complemento")]
        public string DesComplemento {
            get {
                return desComplemento;
            }
            set {
                desComplemento = value;
            }
        }
        private int? seqRota;
        [Column(ColumnName = "seq_Rota")]
        public int? SeqRota {
            get {
                return seqRota;
            }
            set {
                seqRota = value;
            }
        }
        private int? seqLeitura;
        [Column(ColumnName = "seq_Leitura")]
        public int? SeqLeitura {
            get {
                return seqLeitura;
            }
            set {
                seqLeitura = value;
            }
        }
        private string indProcessado;
        [Column(ColumnName = "ind_Processado")]
        public string IndProcessado {
            get {
                return indProcessado;
            }
            set {
                indProcessado = value;
            }
        }
        private string indImpresso;
        [Column(ColumnName = "ind_Impresso")]
        public string IndImpresso {
            get {
                return indImpresso;
            }
            set {
                indImpresso = value;
            }
        }

        private int? seqZonaAbastecimento;
        [Column(ColumnName = "seq_Zona_Abastecimento")]
        public int? SeqZonaAbastecimento {
            get {
                return seqZonaAbastecimento;
            }
            set {
                seqZonaAbastecimento = value;
            }
        }

        private string desCep;
        [Column(ColumnName = "des_Cep")]
        public string DesCep {
            get {
                return desCep;
            }
            set {
                desCep = value;
            }
        }

        private int? valFotosMinima;
        [Column(ColumnName = "val_Fotos_Minima")]
        public int? ValFotosMinima {
            get {
                return valFotosMinima;
            }
            set {
                valFotosMinima = value;
            }
        }

        private int? valFotosMaxima;
        [Column(ColumnName = "val_Fotos_Maxima")]
        public int? ValFotosMaxima {
            get {
                return valFotosMaxima;
            }
            set {
                valFotosMaxima = value;
            }
        }

        private string desInscricao;
        [Column(ColumnName = "des_inscricao")]
        public string DesInscricao {
            get {
                return desInscricao;
            }
            set {
                desInscricao = value;
            }
        }

        private string desEnderecoAlternativo;
        [Column(ColumnName = "des_endereco_alternativo")]
        public string DesEnderecoAlternativo {
            get {
                return desEnderecoAlternativo;
            }
            set {
                desEnderecoAlternativo = value;
            }
        }

        private OnpMovimento movimento;
        public OnpMovimento Movimento {
            get {
                if (movimento == null) {
                    movimento = new OnpMovimento();
                    movimento.SeqMatricula = this.SeqMatricula;
                    if (!movimento.Select())
                        movimento = null;
                }
                return movimento;
            }
            set {
                movimento = value;
            }
        }

        private OnpLogradouro logradouro;
        public OnpLogradouro Logradouro {
            get {
                if (logradouro == null)
                    logradouro = new OnpLogradouro(this.seqLogradouro.Value);
                return logradouro;
			}
			set {
				logradouro = value;
			}
        }

        private Collection<OnpMatriculaServico> servicos;
        public Collection<OnpMatriculaServico> Servicos {
            get {
                if (servicos == null) {
                    OnpMatriculaServico aux = new OnpMatriculaServico();
                    aux.SeqMatricula = this.SeqMatricula;
                    servicos = aux.SelectCollection();
                }
                return servicos;
			}
			set {
				servicos = value;
			}
        }

        private OnpAvisoDebito aviso;
        public OnpAvisoDebito Aviso {
            get {
                if (aviso == null) {
                    aviso = new OnpAvisoDebito();
                    aviso.SeqMatricula = seqMatricula;
                    if (!aviso.Select())
                        aviso = null;
                }
                return aviso;
			}
			set {
				aviso = value;
			}
        }

        private OnpUtilizacaoLigacao utilizacaoLigacao;
        public OnpUtilizacaoLigacao UtilizacaoLigacao {
            get {
                if (utilizacaoLigacao == null)
                    utilizacaoLigacao = new OnpUtilizacaoLigacao(seqUtilizacaoLigacao.Value);
                return utilizacaoLigacao;
			}
			set {
				utilizacaoLigacao = value;
			}
        }

        private Collection<OnpMatriculaAlteracao> alteracoes;
        public Collection<OnpMatriculaAlteracao> Alteracoes {
            get {
                if (alteracoes == null) {
                    OnpMatriculaAlteracao aux = new OnpMatriculaAlteracao();
                    aux.SeqMatricula = this.SeqMatricula;
                    alteracoes = aux.SelectCollection();
                }
                return alteracoes;
			}
			set {
				alteracoes = value;
			}
        }
        #endregion // Atributos e Propriedades

        public OnpMatricula(int seqMatricula) {
            this.seqMatricula = seqMatricula;
            this.Materialize();
        }

        public OnpMatricula() {
        }

        #region Metodos publicos
        /// <summary>
        /// Verifica se a matricula foi lida ou nao
        /// </summary>
        /// <returns>Retorna true se ja fez a leitura, caso contrario retorna false.</returns>
        public bool Lido() {
            return indProcessado.Equals("S");
        }

        public static OnpMatricula Materialize(int seqMatricula) {
            OnpMatricula result = new OnpMatricula();

            result.seqMatricula = seqMatricula;
            if (!result.Materialize())
                result = null;

            return result;
        }

        /// <summary>
        /// Marca a matricula como processada
        /// </summary>
        public void MarcarProcessado() {
            IndProcessado = "S";
            Persist();
        }
        #endregion // Metodos publicos
    }
}
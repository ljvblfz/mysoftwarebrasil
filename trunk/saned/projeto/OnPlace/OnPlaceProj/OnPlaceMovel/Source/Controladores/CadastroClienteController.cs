using System;
using System.Collections.Generic;
using System.Text;
using OnPlaceMovel.Source.Banco;
using OnPlaceMovel.Source.Forms;
using System.Collections.ObjectModel;

namespace OnPlaceMovel.Source.Controladores {

    public class CadastroClienteController {

        #region ATRIBUTOS

        private NavegacaoCadastroClienteController navCadCliController;
        private OnpCadastroCliente cliente;
        private FormCadastroCliente cadastroCliente;
        private string mensagem;
        private Collection<OnpCategoria> listaCategorias;
        private bool alteracaoCadastro;

        #endregion

        #region GET E SET

        public NavegacaoCadastroClienteController NavCadCliController {
            get { return navCadCliController; }
            set { this.navCadCliController = value; }
        }

        public OnpCadastroCliente Cliente {
            get { return cliente; }
            set { this.cliente = value; }
        }

        public FormCadastroCliente CadastroCliente {
            get { return cadastroCliente; }
            set { this.cadastroCliente = value; }
        }

        public string Mensagem {
            get { return mensagem; }
            set { this.mensagem = value; }
        }

        public bool AlteracaoCadastro {
            get { return alteracaoCadastro; }
            set { this.alteracaoCadastro = value; }
        }

        #endregion

        #region CONSTRUTORES

        /// <summary>
        /// Contrutor do controlador da tela de Cadastro de Cliente
        /// </summary>
		/// <param name="navCadCliController"></param>
        public CadastroClienteController(NavegacaoCadastroClienteController navCadCliController) {
            NavCadCliController = navCadCliController;
            Cliente = new OnpCadastroCliente();
            if (cadastroCliente == null) {
                cadastroCliente = new FormCadastroCliente(this, Cliente);
            }
            PreencheCamposTela();
        }

        #endregion

        #region METODOS PRIVADOS

        /// <summary>
        /// Preenche os campos da tela de Cadastro de Cliente
        /// </summary>
        private void PreencheCamposTela() {
            // Preeche a lista de categorias
            OnpCategoria categorias = new OnpCategoria();
            listaCategorias = new Collection<OnpCategoria>();
            listaCategorias = categorias.SelectCollection();
            cadastroCliente.SetListaCategorias(listaCategorias);

            // Preeche a lista de logradouros
            OnpLogradouro logradouros = new OnpLogradouro();
            System.Collections.ObjectModel.Collection<OnpLogradouro> listaLogradouro = logradouros.SelectCollection();
            cadastroCliente.SetListaLogradouro(listaLogradouro);
        }

        #endregion

        #region METODOS PUBLICOS

        /// <summary>
        /// Seta cliente que foi selecionado na tela de navegação
        /// </summary>
        /// <param name="cliente"></param>
        public void SetaCliente(OnpCadastroCliente cliente) {
            cadastroCliente.LimparCamposTela();
            cadastroCliente.Cliente = this.Cliente = cliente;
            if (cadastroCliente.Cliente.SeqCadastroCliente != null) {
                cadastroCliente.SetaCamposObjetoTela();
            }
        }

        /// <summary>
        /// Grava o cliente na base de dados
        /// </summary>
        public void Gravar(OnpCadastroCliente cliente) {
            Mensagem = "";
            if (cliente.Persist() == 1) {
                foreach (OnpClienteCategoria cate in cliente.Categorias) {
                    cate.SeqCadastroCliente = cliente.SeqCadastroCliente;
                    if (cate.Persist() != 1) {
                        Mensagem += "Falha durante a gravação das categorias, tente novamente!\n";
                    }
                }
                NavCadCliController.AtualizarValores(cliente);
                Mensagem += "Sucesso gravação!\n";
            } else {
                Mensagem += "Falha durante a gravação, tente novamente!\n";
            }
        }

        /// <summary>
        /// Método que valida o preenchimento dos campos
        /// </summary>
        /// <returns></returns>
        public bool validaPreenchimento(OnpCadastroCliente cliente) {
            this.Cliente = cliente;
            Mensagem = "";
            bool gravar = true;
            if (cliente.SeqLogradouro == null) {
                gravar = false;
                Mensagem += "Logradouro deve ser informado!\n";
            }
            return gravar;
        }

        #endregion

    }

}

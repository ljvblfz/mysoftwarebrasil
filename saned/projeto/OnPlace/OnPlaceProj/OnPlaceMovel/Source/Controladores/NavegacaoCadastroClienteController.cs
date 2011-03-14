using System;
using System.Text;
using OnPlaceMovel.Source.Forms;
using OnPlaceMovel.Source.Banco;
using System.Collections.ObjectModel;

namespace OnPlaceMovel.Source.Controladores {

    public class NavegacaoCadastroClienteController {

        #region ATRIBUTOS

        private FormNavegacaoCadastroCliente formCadCli;
        private CadastroClienteController cadastroCliente;
        private OnpCadastroCliente clienteSelecionado;
        private Collection<OnpCadastroCliente> clientesCadastrados;
        private int index;

        #endregion

        #region GET E SET

        public FormNavegacaoCadastroCliente FormCadCli {
            get { return formCadCli; }
            set { this.formCadCli = value; }
        }

        public OnpCadastroCliente ClienteSelecionado {
            get { return clienteSelecionado; }
            set { this.clienteSelecionado = value; }
        }

        public Collection<OnpCadastroCliente> ClientesCadastrados {
            get { return clientesCadastrados; }
            set { this.clientesCadastrados = value; }
        }

        public int Index {
            get { return this.index; }
            set { this.index = value; }
        }

        #endregion

        #region CONTRUTOR

        /// <summary>
        /// Construtor da classe
        /// </summary>
        public NavegacaoCadastroClienteController() {
            clientesCadastrados = (new OnpCadastroCliente()).SelectCollection();
            this.index = clientesCadastrados.Count > 0 ? 0 : -1;
            cadastroCliente = new CadastroClienteController(this);
            if (formCadCli == null) {
                formCadCli = new FormNavegacaoCadastroCliente(this);
            }
            formCadCli.ShowDialog();
        }

        #endregion

        #region METODOS PUBLICOS

        /// <summary>
        /// Abre tela de cadastro de cliente com os dados de um ja cadastrado para alteracao
        /// </summary>
        public void AlterarCadastro() {
            OnpClienteCategoria cliCat = new OnpClienteCategoria();
            cliCat.SeqCadastroCliente = clientesCadastrados[this.index].SeqCadastroCliente;
            clientesCadastrados[this.index].Categorias = cliCat.SelectCollection();
            cadastroCliente.SetaCliente(clientesCadastrados[this.index]);
            cadastroCliente.CadastroCliente.ShowDialog();
        }

        /// <summary>
        /// Abre a tela de cadatro de cliente para cadastro de um novo cliente
        /// </summary>
        public void NovoCadastro() {
            cadastroCliente.SetaCliente(new OnpCadastroCliente());
            cadastroCliente.CadastroCliente.ShowDialog();
        }

        /// <summary>
        /// 
        /// </summary>
        public string ProximoCliente(int index) {
            if (clientesCadastrados.Count == 0) {
                return "NÃO HÁ CLIENTES CADASTRADOS!";
            }
            if (index < 0 && this.index <= 0) {
                return "PRIMEIRO REGISTRO";
            }
            if (index > 0 && this.index == (clientesCadastrados.Count - 1)) {
                return "ULTIMO REGISTRO";
            }
            this.index += index;
            formCadCli.Cliente = clientesCadastrados[this.index];
            return string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cliente"></param>
        public void AtualizarValores(OnpCadastroCliente cliente) {
            clientesCadastrados.Add(cliente);
            ClienteSelecionado = cliente;
            formCadCli.AtualizarTela();
        }

        #endregion

    }

}

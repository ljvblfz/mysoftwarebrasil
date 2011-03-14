using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OnPlaceMovel.Source.Banco;
using OnPlaceMovel.Source.Controladores;
using System.Collections.ObjectModel;

namespace OnPlaceMovel.Source.Forms {

    public partial class FormCadastroCliente : Form {

        /// <summary>
        /// Struct auxiliar para preenchimento da tabela de categorias
        /// </summary>
        public struct sTabela {
            public string categoria;
            public int seqCategoria;
            public bool altCat;
            public string economias;
            public bool altEcon;
            public int indice;
        };

        #region ATRIBUTOS

        private OnpCadastroCliente cliente;
        private CadastroClienteController clienteController;
        private Collection<sTabela> tabelaAtual;
        private Collection<sTabela> tabela;
        private sTabela registro;

        #endregion

        #region GET E SET

        public OnpCadastroCliente Cliente {
            get { return cliente; }
            set { this.cliente = value; }
        }

        public CadastroClienteController ClienteController {
            get { return clienteController; }
            set { this.clienteController = value; }
        }

        public sTabela Registro {
            get { return registro; }
            set { registro = value; }
        }

        #endregion

        #region CONSTRUTORES

		/// <summary>
		/// Contrutor da tela de cadastro de clientes
		/// </summary>
		/// <param name="pClienteController"></param>
		/// <param name="pCliente"></param>
        public FormCadastroCliente(CadastroClienteController pClienteController, OnpCadastroCliente pCliente) {
            InitializeComponent();

            tabela = new Collection<sTabela>();

            registro = new sTabela();
            tabelaAtual = new Collection<sTabela>();
            registro.indice = -1;

            ClienteController = pClienteController;
            Cliente = pCliente;
        }

        #endregion

        #region METODOS PRIVADOS

        /// <summary>
        /// Método para gravar cliente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGravar_Click(object sender, EventArgs e) {
            SetaCamposTelaObjeto();
            if (ClienteController.validaPreenchimento(Cliente)) {
                ClienteController.Gravar(Cliente);
            }
            MessageBox.Show(ClienteController.Mensagem);
        }

        /// <summary>
        /// Copia os valores preenchidos na tela para o objeto cliente
        /// </summary>
        private void SetaCamposTelaObjeto() {
            if (cbLogradouro.Items.Count > 0)
                Cliente.SeqLogradouro = ((OnpLogradouro)cbLogradouro.SelectedItem).SeqLogradouro;
            Cliente.DesNomeCliente = tbNome.Text;
            Cliente.DesComplemento = tbComplemento.Text;
            try {
                Cliente.ValNumeroImovel = int.Parse(tbNImovel.Text);
            } catch (Exception) { }
            Cliente.CodHidrometro = tbNHD.Text;
            try {
                Cliente.ValLeituraAtual = int.Parse(tbLeituraAtual.Text);
            } catch (Exception) { }
            Cliente.DesObservacao = tbObservacao.Text;

            foreach (sTabela Stabela in tabela) {
                OnpClienteCategoria clienteCategoria = new OnpClienteCategoria();
                clienteCategoria.SeqCadastroCliente = Cliente.SeqCadastroCliente;
                clienteCategoria.SeqCategoria = Stabela.seqCategoria;
                try {
                    clienteCategoria.ValNumeroEconomias = int.Parse(Stabela.economias);
                } catch (Exception) { }
                cliente.Categorias.Add(clienteCategoria);
            }

        }

        /// <summary>
        /// Copia os valores do objeto para os campos da tela
        /// </summary>
        public void SetaCamposObjetoTela() {
            OnpLogradouro logradouro = new OnpLogradouro(Cliente.SeqLogradouro);
            cbLogradouro.SelectedItem = logradouro;
            tbNome.Text = Cliente.DesNomeCliente;
            tbComplemento.Text = Cliente.DesComplemento;
            tbNImovel.Text = Cliente.ValNumeroImovel.ToString();
            tbNHD.Text = Cliente.CodHidrometro.ToString();
            tbLeituraAtual.Text = Cliente.ValLeituraAtual.ToString();
            tbObservacao.Text = Cliente.DesObservacao;
            // Seta categorias
            foreach (OnpClienteCategoria cliCat in Cliente.Categorias) {
                ListViewItem item = new ListViewItem();
                OnpCategoria cat = new OnpCategoria(cliCat.SeqCategoria.Value);
                item.Text = cat.DesCategoria;
                item.SubItems.Add(cliCat.ValNumeroEconomias.ToString());
                sTabela registro = new sTabela();
                registro.seqCategoria = cliCat.SeqCategoria.Value;
                registro.categoria = cat.DesCategoria;
                registro.economias = cliCat.ValNumeroEconomias.ToString();
                lvLigacaoCategoria.Items.Add(item);
                tabela.Add(registro);
            }
        }

        /// <summary>
        /// Obriga o preenchimento do campo ser inteiro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbNumeros_TextChanged(object sender, EventArgs e) {
            TextBox textBox = sender as TextBox;
            try {
                int.Parse(textBox.Text);
            } catch {
                textBox.Text = string.Empty;
            }
        }

        /// <summary>
        /// Limpa dados da tabela
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpar_Click(object sender, EventArgs e) {
            while (tabela.Count > 0)
                tabela.RemoveAt(0);

            while (lvLigacaoCategoria.Items.Count > 0)
                lvLigacaoCategoria.Items.RemoveAt(0);

            registro.indice = -1;
        }

        /// <summary>
        /// Inclui categoria na lista
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInclui_Click(object sender, EventArgs e) {
            // Verifica se ja existe categoria com a mesma taxa na lista
            foreach (sTabela tabItem in tabela) {
                if (registro.categoria.Equals(tabItem.categoria)) {
                    System.Windows.Forms.MessageBox.Show("Já existe está categoria.");
                    return;
                }
            }

            // Verifica se os campos estão preenchidos
            if (cbListaCategorias.SelectedItem == null || string.IsNullOrEmpty(tbEconomias.Text)) {
                System.Windows.Forms.MessageBox.Show("Preencha todos os campos.");
                return;
            }

            ListViewItem item = new ListViewItem();

            item.Text = registro.categoria;
            item.SubItems.Add(registro.economias);

            if (registro.indice > -1) {
                lvLigacaoCategoria.Items.RemoveAt(registro.indice);

                int indice = BuscaRegistro(registro, tabela);
                if (indice > -1)
                    tabela.RemoveAt(indice);
            }

            lvLigacaoCategoria.Items.Add(item);

            registro.indice = -1;
            tabela.Add(registro);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="registro"></param>
        /// <param name="lista"></param>
        /// <returns></returns>
        private int BuscaRegistro(sTabela registro, Collection<sTabela> lista) {
            for (int i = 0; i < lista.Count; i++)
                if (registro.categoria.Equals(lista[i].categoria) && registro.economias.Equals(lista[i].economias))
                    return i;
            return -1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="registro"></param>
        /// <param name="lista"></param>
        /// <returns></returns>
        private int BuscaRegistroCat(sTabela registro, Collection<sTabela> lista) {
            for (int i = 0; i < lista.Count; i++)
                if ((registro.categoria == lista[i].categoria))
                    return i;

            return -1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbListaCategorias_SelectedIndexChanged(object sender, EventArgs e) {
            registro.categoria = cbListaCategorias.Text;
            registro.seqCategoria = ((OnpCategoria)cbListaCategorias.SelectedItem).SeqCategoria.Value;
            registro.altCat = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbEconomias_TextChanged(object sender, EventArgs e) {
            TextBox tx = sender as TextBox;
            try {
                int.Parse(tx.Text);
                registro.economias = tx.Text;
                registro.altEcon = true;
            } catch {
                tbEconomias.Text = "0";
            }
        }

        #endregion

        #region METODOS PUBLICOS

        /// <summary>
        /// Preenche a lista de logradouros
        /// </summary>
        /// <param name="lista"></param>
        public void SetListaLogradouro(Collection<OnpLogradouro> lista) {
            for (int i = 0; i < lista.Count; i++) {
                cbLogradouro.Items.Add(lista[i]);
                cbLogradouro.SelectedIndex = i;
            }
        }

        /// <summary>
        /// Preenche a lista de categorias
        /// </summary>
        /// <param name="lista"></param>
        public void SetListaCategorias(Collection<OnpCategoria> lista) {
            for (int i = 0; i < lista.Count; i++)
                cbListaCategorias.Items.Add(lista[i]);
            cbListaCategorias.SelectedIndex = 0;
        }

        /// <summary>
        /// Limpa os capos da tela
        /// </summary>
        public void LimparCamposTela() {
            this.tbObservacao.Text = "";
            this.tbLeituraAtual.Text = "";
            this.tbNHD.Text = "";
            this.tbComplemento.Text = "";
            this.tbNome.Text = "";
            this.tbNImovel.Text = "";
            this.tbEconomias.Text = "0";
            while (this.lvLigacaoCategoria.Items.Count > 0)
                this.lvLigacaoCategoria.Items.RemoveAt(0);
        }

        #endregion

    }

}
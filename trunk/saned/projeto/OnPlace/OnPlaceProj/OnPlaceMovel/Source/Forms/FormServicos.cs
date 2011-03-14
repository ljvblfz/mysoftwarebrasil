using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using OnPlaceMovel.Source.Controladores;

namespace OnPlaceMovel.Source.Forms {
    public partial class FormServicos : Form {
        private bool remocao;
        private ServicosController servicoControl;
        public FormServicos(ServicosController servicoControl) {
            this.servicoControl = servicoControl;
            remocao = false;
            InitializeComponent();
        }

        #region Setters
        public void setNome(string nome) {
            lblNome.Text = "Nome: " + nome;
        }
        public void setHidrometro(string hidrometro) {
            lblHidrometro.Text = "Nº hidrômetro: " + hidrometro;
        }
        public void setEndereco(string endereco) {
            lblEndereco.Text = "Endereço: " + endereco;
        }
        #endregion

        private void btnCancelar_Click(object sender, EventArgs e) {
            Close();
        }

        public void AddListBoxItem(string item) {
            lbServicos.Items.Add(item);
        }

        public void AddClienteListBoxItem(string item) {
            lbServicosCadastrados.Items.Add(item);
        }

        private void button1_Click(object sender, EventArgs e) {
            int matricula;
            try {
                matricula = int.Parse(tbMatricula.Text);
            } catch {
                matricula = 0;
                tbMatricula.Focus();
            }
            LimpaCamposMatricula();
            if (servicoControl.CarregaServicosCliente(matricula)) {
                lbServicos.Enabled = true;
                lbServicosCadastrados.Enabled = true;
            } else {
                lbServicos.Enabled = false;
                lbServicosCadastrados.Enabled = false;
            }
        }

        private void btnGravar_Click(object sender, EventArgs e) {
            Collection<string> listaServicos = new Collection<string>();

            for (int i = 0; i < lbServicosCadastrados.Items.Count; i++)
                listaServicos.Add((string)lbServicosCadastrados.Items[i]);

            servicoControl.GravaListaServicos(listaServicos);
        }

        private void lbServicosCadastrados_SelectedIndexChanged(object sender, EventArgs e) {
            if (remocao == false) {
                remocao = true;
                lbServicosCadastrados.Items.RemoveAt(lbServicosCadastrados.SelectedIndex);
            } else { remocao = false; }
        }

        private void lbServicos_SelectedIndexChanged(object sender, EventArgs e) {
            if (!BuscaItemCadastrado(lbServicos.SelectedItem.ToString()))
                lbServicosCadastrados.Items.Add(lbServicos.SelectedItem);
        }

        private bool BuscaItemCadastrado(string item) {
            for (int i = 0; i < lbServicosCadastrados.Items.Count; i++)
                if (lbServicosCadastrados.Items[i].ToString() == item)
                    return true;
            return false;
        }

        public void LimpaCamposMatricula() {
            setNome(string.Empty);
            setHidrometro(string.Empty);
            setEndereco(string.Empty);
            lbServicosCadastrados.Items.Clear();
        }

        private void Servicos_Activated(object sender, EventArgs e) {
            Controlador.ActiveForm = this;
        }

    }
}
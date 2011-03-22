using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SPCadMobileData.Data.Model;
using SPCadMobileData.Data;
using SPCadMobile.View;

namespace CopasaMobile.View
{
    public partial class frmImpedimentoExecucao : SPCadMobile.View.CustomForm
    {
        long cadastro { get; set; }
        long matricula { get; set; }
        public int? statusExec { get; set; }

        public string recentFotos { get; set; }

        public frmImpedimentoExecucao(CadastroAuxiliar cad)
        {
            InitializeComponent();
            cadastro = cad.Id;
            matricula = cad.Matricula;
            LoadInterface(cad.Id, cad.Matricula);

            DisableComponentes();
        }

        /// <summary>
        /// Carrega a interface
        /// </summary>
        private void LoadInterface(long cadast, long matric)
        {
            try
            {
                cbxMotivoImpedimento.DataSource = ListOcorrcImped.getList();

                bindingSourceCadastroAux.DataSource = SingletonFlow.cadastroFlow.getListCadImp(cadast, matric);

                btnFotos_Click(btnFotos, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        //Método para desabilitar componentes e configurar botões Editar/Salvar e Cancelar/Voltar
        private void DisableComponentes()
        {
            bool status = true;

            StatusComponente(status);
        }

        //Bloquea os componentes e configura o botao editar/salvar e cancelar/voltar.
        private void StatusComponente(bool status)
        {
            cbxMotivoImpedimento.Enabled = !status;
            tbxObservacaoImp.ReadOnly = status;
            btnDesfazer.Enabled = !status;
            btnFotos.Enabled = !status;

            StatusBotaoEditar(!status);
        }

        //Configura botão editar
        private void StatusBotaoEditar(bool status)
        {
            menuItem1.Text = (status) ? "Salvar" : "Editar";
            menuItem2.Text = (status) ? "Cancelar" : "Voltar";
        }

        //Método para botão editar
        private void menuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                bool status = (menuItem1.Text == "Salvar") ? true : false;

                if (status)
                {
                    if (ckbFotos.Checked)
                    {
                        Salvar(1); //parametro 1 para salvar impedimento.                        
                        StatusComponente(status);
                    }
                    else
                    {
                        MessageBox.Show("É necessário registrar foto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    }
                }
                else
                {
                    StatusComponente(status);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        /// Desfaz o impedimento
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDesfazer_Click(object sender, EventArgs e)
        {
            try
            {
                bool status = (menuItem1.Text == "Salvar") ? true : false;

                if (status)
                {
                    if (ckbFotos.Checked)
                    {

                        Salvar(2);//parametro 2 para desfazer impedimento.

                        LoadInterface(cadastro, matricula);

                        StatusComponente(status);

                    }
                    else
                    {
                        MessageBox.Show("É necessário registrar foto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    }
                }
                else
                {
                    StatusComponente(status);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        //Método para comando cancelar/voltar
        private void menuItem2_Click(object sender, EventArgs e)
        {
            bool status = true;
            if (menuItem2.Text == "Cancelar")
            {
                bindingSourceCadastroAux.ResetItem(0);

                StatusComponente(status);
                StatusBotaoEditar(!status);
                return;
            }

            statusExec = ((CadastroAuxiliar)bindingSourceCadastroAux.Current).StatusExecucao;

            //limpa a lista estatica fonte alternativa;            
            this.Close();
        }

        //Salva as informações
        private void Salvar(int op)//op = salvar ou desfazer.
        {
            bindingSourceCadastroAux.EndEdit();

            CadastroAuxiliar cad = (CadastroAuxiliar)bindingSourceCadastroAux.Current;

            if (op == 1) // salva impedimento.
            {
                SingletonFlow.cadastroFlow.UpdateImpedimento(cad);
            }
            else if (op == 2) // desfaz impedimento
            {
                SingletonFlow.cadastroFlow.UpdateImpDesfazer(cad);
            }

            bindingSourceCadastroAux.ResumeBinding();
        }

        private void btnFotos_Click(object sender, EventArgs e)
        {
            try
            {
                bindingSourceCadastroAux.EndEdit();
                CadastroAuxiliar cad = (CadastroAuxiliar)bindingSourceCadastroAux.Current;
                Foto foto = new Foto();

                foto.idCadast = cad.Id;
                foto.numPontoServc = cad.NumeroPontoServico;

                using (FrmListFoto fotoList = new FrmListFoto(foto))
                {
                    this.SuspendLayout();
                    if (e != null) fotoList.ShowDialog();
                    ckbFotos.Checked = (fotoList.qtdFoto > 0) ? true : false;
                    this.ResumeLayout();
                }
                bindingSourceCadastroAux.ResumeBinding();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void ckbFotos_CheckStateChanged(object sender, EventArgs e)
        {
            if (ckbFotos.Checked)
                btnFotos.BackColor = Color.GreenYellow;
            else
                btnFotos.BackColor = Color.Gainsboro;
        }


    }
}


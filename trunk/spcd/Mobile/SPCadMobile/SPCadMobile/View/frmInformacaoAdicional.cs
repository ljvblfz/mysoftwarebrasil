using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SPCadMobileData.Data.Model;
using SPCadMobile.View;
using SPCadMobileData.Data;

namespace CopasaMobile.View
{
    public partial class frmInformacaoAdicional : SPCadMobile.View.CustomForm
    {
        //public frmInformacaoAdicional(CadastroAuxiliar cad)
        //{            
        //    InitializeComponent();



        //    bindingSourceCadastroAux.DataSource = cad;

        //    DisableComponentes();
        //}

        public frmInformacaoAdicional(long idCad)
        {
            InitializeComponent();
            
            bindingSourceCadastroAux.DataSource = SingletonFlow.cadastroFlow.getCadAuxById(idCad);

            DisableComponentes();
        }

        private void DisableComponentes()
        {
            bool status = true;

            StatusComponentes(!status);

            StatusBotaoEditar(!status);
        }

        private void StatusComponentes(bool status)
        {           
            tbxInfComplementar.ReadOnly = !status;
        }

        private void btnFotos_Click(object sender, EventArgs e)
        {
            try
            {
                Foto foto = new Foto();

                bindingSourceCadastroAux.EndEdit();

                CadastroAuxiliar cad = (CadastroAuxiliar)bindingSourceCadastroAux.Current;

                foto.idCadast = cad.Id;
                foto.numPontoServc = cad.NumeroPontoServico;

                using (FrmListFoto fotoList = new FrmListFoto(foto))
                {
                    this.SuspendLayout();
                    fotoList.ShowDialog();
                    this.ResumeLayout();
                }

                bindingSourceCadastroAux.ResumeBinding();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnOcorrencias_Click(object sender, EventArgs e)
        {
            try
            {
                bindingSourceCadastroAux.EndEdit();

                CadastroAuxiliar cad = (CadastroAuxiliar)bindingSourceCadastroAux.Current;

                using (frmRegistroOcorrencias reg = new frmRegistroOcorrencias(cad))
                {
                    this.SuspendLayout();
                    reg.ShowDialog();
                    this.ResumeLayout();
                }

                bindingSourceCadastroAux.ResumeBinding();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void StatusBotaoEditar(bool status)
        {
            menuItem1.Text = (status) ? "Salvar" : "Editar";
            menuItem2.Text = (status) ? "Cancelar" : "Voltar";
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            bool status = true;
            if (menuItem2.Text == "Cancelar")
            {
                bindingSourceCadastroAux.ResetItem(0);

                StatusComponentes(!status);
                StatusBotaoEditar(!status);
                return;
            }

            //limpa a lista estatica fonte alternativa;            
            this.Close();
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                bool status = (menuItem1.Text == "Salvar") ? true : false;

                if (status)
                {
                    Salvar();                    
                }

                StatusComponentes(!status);
                StatusBotaoEditar(!status);
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Salva os dados da interface frmPontoServHidrometro.cs
        private void Salvar()
        {
            try
            {
                bindingSourceCadastroAux.EndEdit();

                CadastroAuxiliar cad = (CadastroAuxiliar)bindingSourceCadastroAux.Current;

                SingletonFlow.cadastroFlow.UpdateObsVisita(cad);

                bindingSourceCadastroAux.ResumeBinding();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }
    }
}


using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SPCadMobileData.Data;
using SPCadMobileData.Data.Model;
using CommonHelpMobile;

namespace SPCadMobile.View
{
    public partial class frmRegistroOcorrencias : CustomForm
    {
        public string ocorrencia { get; set; }
        Cadastro cadastro { get; set; }
        CadastroAuxiliar cadAux { get; set; }
        int construtor = 0;

        public frmRegistroOcorrencias(Cadastro cad)
        {
            InitializeComponent();
            construtor = 1;

            cadastro = cad;

            ocorrencia = cad.VetorOcorrencia;

            carregarTela();
        }

        public frmRegistroOcorrencias(CadastroAuxiliar cad)
        {
            InitializeComponent();
            construtor = 2;

            //cadastro = new Cadastro();
            cadastro = SingletonFlow.cadastroFlow.getCadastroById(cad.Id);
            cadAux = cad;
            ocorrencia = cad.VetorOcorrencia.Trim();
            carregarTela();
        }

        public void carregarTela()
        {
            if (string.IsNullOrEmpty(ocorrencia.Trim())) return;

            bindingSourceOcorrencia.DataSource = SingletonFlow.ocorrenciaFlow.ListOcorrencia(ocorrencia.Trim());
            bindingSourceOcorrencia.ResetBindings(true);
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Adiciona registro de ocorrência.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (string.IsNullOrEmpty(tbxCodigo.Text))
                {
                    MessageBox.Show("Código não informado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    return;
                }
                else if (bindingSourceOcorrencia.Count == 4)
                {
                    MessageBox.Show("É permitido apenas quatro registro de ocorrências.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    tbxCodigo.Text = string.Empty;
                }
                else if (CheckNewCodInList())
                {
                    MessageBox.Show("Códido já existente na lista.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                else if (SingletonFlow.cadastroFlow.ValidaCodVetorOcorrencia(tbxCodigo.Text.Trim()))
                {
                    //se o objeto utilizado no momento for cadastro completo atualiza com o objeto cadastro.
                    if (cadastro.Id > 0)
                    {
                        cadastro.VetorOcorrencia = registroOcorrencia();
                        SingletonFlow.cadastroFlow.Update(cadastro);
                        ocorrencia = cadastro.VetorOcorrencia.Trim();

                        //todo: verificar se a ocorrencia é do tipo impedimento
                        if (SingletonFlow.ocorrenciaFlow.CheckOcorrcImp(cadastro.VetorOcorrencia.Trim()))
                        {
                            //caso alguma ocorrencia seja de impedimento, o cadastro recebe o estatus 2 = impedimento
                            cadastro.StatusExecucao = 2;
                            SingletonFlow.cadastroFlow.UpdateStatusExec(cadastro);
                        }
                    }
                    else if (cadAux.Id > 0)//
                    {
                        cadAux.VetorOcorrencia = registroOcorrencia();
                        SingletonFlow.cadastroFlow.UpdateInfoAdd(cadAux);
                        ocorrencia = cadAux.VetorOcorrencia.Trim();

                        //todo: verificar se a ocorrencia é do tipo impedimento                       
                        if (SingletonFlow.ocorrenciaFlow.CheckOcorrcImp(cadAux.VetorOcorrencia.Trim()))
                        {
                            //caso alguma ocorrencia seja de impedimento, o cadastro recebe o estatus 2 = impedimento
                            cadAux.StatusExecucao = 2;
                            SingletonFlow.cadastroFlow.UpdateStatusExec(cadAux, cadAux.StatusExecucao);
                        }
                    }

                    carregarTela();
                }
                else
                {
                    MessageBox.Show("Código inexistente.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void campo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != '\b')//a segunda expressão habilita a funcionalidade do botão backspace do teclado.
            {
                e.Handled = true;
            }
        }

        private void bindingSource_BindingComplete(object sender, BindingCompleteEventArgs e)
        {
            if (e.ErrorText == "FormatException")
                e.Cancel = false;
        }

        /// <summary>
        /// Retorna a string com a lista de ocorrencia atualizada com o novo codigo
        /// </summary>
        /// <returns></returns>
        private string registroOcorrencia()
        {
            string ocorrenciaReg = string.Empty;
            int p = 0;

            if (bindingSourceOcorrencia.Count == 0)
            {
                ocorrenciaReg = tbxCodigo.Text.PadLeft(3, '0');
            }
            else
            {
                bindingSourceOcorrencia.EndEdit();

                List<ItemCombo> lst = (List<ItemCombo>)bindingSourceOcorrencia.List;

                foreach (ItemCombo item in lst)
                {
                    ocorrenciaReg += item.Value.ToString().PadLeft(3, '0');

                    if (p < (lst.Count - 1))
                    {
                        ocorrenciaReg += ",";
                    }
                    p++;
                }

                ocorrenciaReg += "," + tbxCodigo.Text.PadLeft(3, '0');

                bindingSourceOcorrencia.ResumeBinding();
            }

            return ocorrenciaReg.Trim();
        }

        /// <summary>
        /// Retorna true, caso o código informado existir na lista.
        /// </summary>
        /// <returns></returns>
        private bool CheckNewCodInList()
        {
            if (bindingSourceOcorrencia.Count == 0) return false;
            List<ItemCombo> a = ((List<ItemCombo>)bindingSourceOcorrencia.DataSource).Where(i => i.Value.ToString() == tbxCodigo.Text).ToList();

            if (a.Count > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Remove item da lista de ocorrencias
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemover_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (bindingSourceOcorrencia.Count == 0)
                {
                    MessageBox.Show("Não é possível excluir!\r\nLista vazia.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    return;
                }

                string ocorrenciaReg = string.Empty;
                int p = 0;

                bindingSourceOcorrencia.EndEdit();
                bindingSourceOcorrencia.RemoveCurrent();
                List<ItemCombo> lst = (List<ItemCombo>)bindingSourceOcorrencia.List;

                foreach (ItemCombo item in lst)
                {
                    ocorrenciaReg += item.Value.ToString();

                    if (p < (lst.Count - 1))
                    {
                        ocorrenciaReg += ",";
                    }
                    p++;
                }

                //verifica se a ocorrencia é do tipo impedimento          
                cadastro.VetorOcorrencia = ocorrenciaReg;

                if (string.IsNullOrEmpty(ocorrenciaReg) && cadastro.StatusExecucao == 2)
                {
                    if (!SingletonFlow.ocorrenciaFlow.CheckOcorrcImp(cadastro.VetorOcorrencia.Trim()))
                        cadastro.StatusExecucao = 0;
                }

                SingletonFlow.cadastroFlow.Update(cadastro);
                ocorrencia = cadastro.VetorOcorrencia.Trim();
                carregarTela();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        /// <summary>
        /// Pesquisa uma ocorrência baseada em um parâmetro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lupa_Click(object sender, EventArgs e)
        {
            try
            {
                using (frmPesquisaOcorrencias pesOco = new frmPesquisaOcorrencias())
                {
                    this.SuspendLayout();
                    pesOco.ShowDialog();

                    if (pesOco.ocorrenciaSelected != null)
                        tbxCodigo.Text = pesOco.ocorrenciaSelected.Id.ToString();

                    this.ResumeLayout();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }

        }

        private void btnFoto_Click(object sender, EventArgs e)
        {
            try
            {
                Foto foto = new Foto();

                foto.idCadast = (construtor == 1) ? cadastro.Id : cadAux.Id;
                foto.numPontoServc = (construtor == 1) ? cadastro.NumeroPontoServico : cadAux.NumeroPontoServico;

                if (cadastro.Id > 0)
                {
                    foto.idCadast = cadastro.Id;
                    foto.numPontoServc = cadastro.NumeroPontoServico;
                }
                else
                {
                    foto.idCadast = cadAux.Id;
                    foto.numPontoServc = cadAux.NumeroPontoServico;
                }

                foto.codOcorrc = int.Parse(((ItemCombo)bindingSourceOcorrencia.Current).Value.ToString());

                using (FrmListFoto lstFoto = new FrmListFoto(foto))
                {
                    this.SuspendLayout();
                    lstFoto.ShowDialog();
                    this.ResumeLayout();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }
    }
}
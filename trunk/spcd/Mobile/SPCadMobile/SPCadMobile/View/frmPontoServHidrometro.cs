using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SPCadMobileData.Data;
using CommonHelpMobile;
using SPCadMobileData.Data.Model;

namespace SPCadMobile.View
{
    public partial class frmPontoServHidrometro : CustomFormAba
    {
        public string flagConcluido = "";
        public string leitu = "";
        public string leitu2 = "";

        //indica a aba atual.
        int indexCurret = 0;

        public frmPontoServHidrometro(long cadastro, long matricula)
        {
            InitializeComponent();

            //aba Padrao
            cbxSitPontoServico.DataSource = ListSitPontServ.getList();
            cbxLocalPadrao.DataSource = ListLocalPadrao.getList();
            cbxTipoPadrao.DataSource = ListTipoPadrao.getList();
            cbxPadraoLacrado.DataSource = ListResposta.getList();
            cbxEliminadorAr.DataSource = ListResposta.getList();
            cbxTorneiraPadrao.DataSource = ListResposta.getList();
            cbxPadraoLacrado.DataSource = ListResposta.getList();
            cbxEliminadorAr.DataSource = ListResposta.getList();
            cbxTorneiraPadrao.DataSource = ListResposta.getList();
            cbxPossuiMedidorSN.DataSource = ListResposta.getListSN();
            

            //aba Medidor
            cbxClasseMetrologica.DataSource = ListClasseMetrologica.getList();
            cbxHidrometroLacrado.DataSource = ListResposta.getList();
            cbxPSegLigacao.DataSource = ListResposta.getList();

            //aba Medidor2
            cbxClasseMetrologica2.DataSource = ListClasseMetrologica.getList();
            cbxHidrometroLacrado2.DataSource = ListResposta.getList();

            // Retorna o objeto a ser alimentar o dadaSorce
            Cadastro modelCadastro = SingletonFlow.cadastroFlow.getPontoServicobyMatCadDI(cadastro, matricula);

            // Verifica se o medidor foi gravado no banco se não carrega como "NÃO => 2"
            if (string.IsNullOrEmpty(modelCadastro.ExisteMedidor) || modelCadastro.ExisteMedidor == "0")
            {
                modelCadastro.ExisteMedidor = "2";
            }

            // carrega o dataSource
            bindingSourceCadastro.DataSource = modelCadastro;

            //carrega variáveis para aplicação da máscara.
            leitu = ((Cadastro)bindingSourceCadastro.Current).Leitura.ToString();
            leitu2 = ((Cadastro)bindingSourceCadastro.Current).Leitura2.ToString();

            DisableComponentes();
            tabControl1.SelectedIndex = 0;

            cbxPossuiMedidorSN.SelectedIndex = 0;

            //seta indice da aba utilizada em uma variavel global.
            indexCurret = tabControl1.SelectedIndex;

            // Seta o valor do checkbox
            if (String.IsNullOrEmpty(modelCadastro.SituacaoPontoServicoAlter))
                cbxSitPontoServico.SelectedValue = modelCadastro.SituacaoPontoServicoAlter;
        }

        //bloqueia o acesso a outras abas que não estão em modo de edição ou bloqueia o acesso a aba medidor2 quando sua existência não foi confirmada.
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (menuItem1.Text == "Salvar" && tabControl1.SelectedIndex != indexCurret)
            {
                tabControl1.SelectedIndex = indexCurret;
            }
            else
            {
                //verifica se a aba medidor2 está liberada, caso não bloquea seu acesso.
                if (tabControl1.SelectedIndex == 2 && cbxPSegLigacao.Text != "Sim")
                {
                    tabControl1.SelectedIndex = indexCurret;
                    return;
                }

                indexCurret = tabControl1.SelectedIndex;
            }
        }

        private void DisableComponentes()
        {
            bool status = true;

            StatusAbaPadrao(status);
            StatusAbaMedidor(status);
            StatusAbaMedidor2(status);
            StatusAbaInfAdicional(status);
            StatusBotaoEditar(!status);

            segundaLigacaoStatus();

        }

        private void StatusAbaPadrao(bool status)
        {
            cbxSitPontoServico.Enabled = !status;
            cbxLocalPadrao.Enabled = !status;
            cbxTipoPadrao.Enabled = !status;
            cbxPadraoLacrado.Enabled = !status;
            cbxEliminadorAr.Enabled = !status;
            cbxTorneiraPadrao.Enabled = !status;

            StatusBotaoEditar(!status);
        }

        // ativa/desativa componentes de tela da aba economia.
        private void StatusAbaMedidor(bool status)
        {
            cbxPossuiMedidorSN.Enabled = !status;
            tbxNumMedidor.ReadOnly = status;
            cbxQuantidade.Enabled = !status;
            cbxClasseMetrologica.Enabled = !status;
            cbxHidrometroLacrado.Enabled = !status;
            cbxPSegLigacao.Enabled = !status;
            lupa.Enabled = !status;

            rbNao_CheckedChanged(cbxPossuiMedidorSN, null);
            StatusBotaoEditar(!status);
        }

        // ativa/desativa componentes de tela da aba caracteristica.
        private void StatusAbaMedidor2(bool status)
        {
            tbxNumMedidor2.ReadOnly = status;
            lupa2.Enabled = !status;
            cbxQuantidade2.Enabled = !status;
            cbxClasseMetrologica2.Enabled = !status;
            cbxHidrometroLacrado2.Enabled = !status;

            StatusBotaoEditar(!status);
        }

        // ativa/desativa componentes de tela da aba informação adicional.
        private void StatusAbaInfAdicional(bool status)
        {
            tbxInfComplementar.ReadOnly = status;
            StatusBotaoEditar(!status);
        }

        private void StatusBotaoEditar(bool status)
        {
            menuItem1.Text = (status) ? "Salvar" : "Editar";
            menuItem2.Text = (status) ? "Cancelar" : "Voltar";
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                if (menuItem2.Text == "Cancelar")
                {
                    bindingSourceCadastro.ResetItem(0);

                    SairModoEdicao(true);

                    StatusBotaoEditar(false);
                    return;
                }

                CheckSegundaLigacao();

                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                bool status = (menuItem1.Text == "Salvar") ? true : false;

                if (NomeAbaCorrente() == "tabMedidor" && status && (tbxLeitura.Text.Length != int.Parse(cbxQuantidade.SelectedItem.ToString())))
                {
                    if (tbxLeitura.Text != "")
                    {
                        MessageBox.Show("Quantidades de digitos de leitura diferentes da leitura realizada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        return;
                    }
                }

                if (NomeAbaCorrente() == "tabPadrao" && status)
                {
                    // Colocar mensagem de confirmação ao salvar os dados de medidor, estando informado “Torneira no medidor” ou “Sem Lacre”
                    if (cbxPadraoLacrado.Text == "Não" || cbxTorneiraPadrao.Text == "Sim")
                    {
                        // Caixa de dialogo
                        DialogResult result = MessageBox.Show("Torneira no padrão ou medidor sem Lacre \n Deseja salvar.", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                        // Se a resposta for para não salvar
                        if (result == DialogResult.No)
                        {
                            return;
                        }
                    }
                }

                if (NomeAbaCorrente() == "tabMedidor2" && status && cbxQuantidade2.SelectedItem != "" && (tbxLeitura2.Text.Length != int.Parse(cbxQuantidade2.SelectedItem.ToString())))
                {
                    if (tbxLeitura2.Text != "")
                    {
                        MessageBox.Show("Quantidades de digitos de leitura diferentes da leitura realizada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        return;
                    }
                }

                if (status)
                {
                    Salvar(NomeAbaCorrente());
                }

                SairModoEdicao(status);

                if (status)
                {
                    segundaLigacaoStatus();
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

        //Salva os dados da interface frmPontoServHidrometro.cs
        private void Salvar(string aba)
        {
            try
            {
                bindingSourceCadastro.EndEdit();

                Cadastro cad = (Cadastro)bindingSourceCadastro.Current;

                SingletonFlow.cadastroFlow.UpdatePSHidrometro(aba, cad, ref flagConcluido);

                bindingSourceCadastro.ResumeBinding();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }


        //Habilita modo de edição
        private void SairModoEdicao(bool status)
        {
            switch (NomeAbaCorrente())
            {
                case "tabPadrao": 
                    StatusAbaPadrao(status);
                    break;
                case "tabMedidor": 
                    StatusAbaMedidor(status);
                    break;
                case "tabMedidor2": 
                    StatusAbaMedidor2(status);
                    break;
                case "tabInfAdicional": 
                    StatusAbaInfAdicional(status);
                    break;
            }
        }


        private string NomeAbaCorrente()
        {
            return tabControl1.TabPages[tabControl1.SelectedIndex].Name;
        }

        /// <summary>
        /// Exibe painel caso resposta seja 1 ou 0.(sem resposta ou sim).
        /// </summary> 
        private void rbNao_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxPossuiMedidorSN.SelectedValue.ToString() == "2")
            {
                panelLeitura.Visible = false;
                lblNumMedidor.Visible = false;
                tbxNumMedidor.Visible = false;
            }
            else
            {
                panelLeitura.Visible = true;
                lblNumMedidor.Visible = true;
                tbxNumMedidor.Visible = true;
            }
        }

        private void segundaLigacaoStatus()
        {
            //alexis 03-02-2011
            //bool status = true;

            if (cbxPSegLigacao.Text == "Não" || cbxPSegLigacao.Text == "")
            {
                tabMedidor2.Hide();
            }
            else
            {
                tabMedidor2.Show();
            }
        }

        //Ao salvar, verifica se campo 
        private void LimpaCampos()
        {
            tbxNumMedidor.Text = string.Empty;
            tbxLeitura.Text = string.Empty;
            cbxQuantidade.SelectedIndex = 0;
            cbxClasseMetrologica.SelectedIndex = 0;
            cbxHidrometroLacrado.SelectedIndex = 0;
        }

        private void lupa_Click(object sender, EventArgs e)
        {
            try
            {
                using (frmLeitura leitura = new frmLeitura())
                {
                    this.SuspendLayout();
                    leitura.ShowDialog();
                    leitu = leitura.display;
                    tbxLeitura.Text = (string.IsNullOrEmpty(leitura.display)) ? "0" : leitura.display;
                    this.ResumeLayout();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void tbxNumMedidor_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                string nome = tbxNumMedidor.Text.Substring(0, 1);
                List<ItemCombo> lstFab = ListFabricante.getList();

                ItemCombo vlrFab = lstFab.Find(delegate(ItemCombo item)
                {
                    return item.Value.ToString() == nome;
                });

                tbxFabricante.Text = vlrFab.Description.ToString();
            }
            catch (Exception)
            {
                tbxFabricante.Text = "";
            }

            try
            {
                string nome = tbxNumMedidor.Text.Substring(3, 1);

                List<ItemCombo> lstCap = ListCapacidade.getList();

                ItemCombo vlrCap = lstCap.Find(delegate(ItemCombo item)
                {
                    return item.Value.ToString() == nome;
                });

                tbxCapacidade.Text = vlrCap.Description.ToString();
            }
            catch (Exception)
            {
                tbxCapacidade.Text = "";
            }
        }

        private void tbxNumMedidor2_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                string nome = tbxNumMedidor2.Text.Substring(0, 1);
                List<ItemCombo> lstFab = ListFabricante.getList();

                ItemCombo vlrFab = lstFab.Find(delegate(ItemCombo item)
                {
                    return item.Value.ToString() == nome;
                });

                tbxFabricante2.Text = vlrFab.Description.ToString();

            }
            catch (Exception)
            {
                tbxFabricante2.Text = "";
            }


            try
            {

                string nome = tbxNumMedidor2.Text.Substring(3, 1);

                List<ItemCombo> lstCap = ListCapacidade.getList();

                ItemCombo vlrCap = lstCap.Find(delegate(ItemCombo item)
                {
                    return item.Value.ToString() == nome;
                });

                tbxCapacidade2.Text = vlrCap.Description.ToString();
            }
            catch (Exception)
            {
                tbxCapacidade2.Text = "";
            }
        }

        private void lupa_Click()
        {

        }

        private void lupa2_Click(object sender, EventArgs e)
        {
            try
            {
                using (frmLeitura leitura = new frmLeitura())
                {
                    this.SuspendLayout();
                    leitura.ShowDialog();
                    leitu2 = leitura.display;
                    tbxLeitura2.Text = (string.IsNullOrEmpty(leitura.display)) ? "0" : leitura.display;
                    this.ResumeLayout();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnOcorrencia_Click(object sender, EventArgs e)
        {
            try
            {
                Cadastro regOcorrencia = (Cadastro)bindingSourceCadastro.Current;

                using (frmRegistroOcorrencias reg = new frmRegistroOcorrencias(regOcorrencia))
                {
                    this.SuspendLayout();
                    reg.ShowDialog();
                    ((Cadastro)bindingSourceCadastro.Current).VetorOcorrencia = reg.ocorrencia;
                    this.ResumeLayout();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnFotos_Click(object sender, EventArgs e)
        {
            try
            {
                bindingSourceCadastro.EndEdit();
                Cadastro cad = (Cadastro)bindingSourceCadastro.Current;
                Foto foto = new Foto();

                foto.idCadast = cad.Id;
                foto.numPontoServc = cad.NumeroPontoServico;


                using (FrmListFoto fotoList = new FrmListFoto(foto))
                {
                    this.SuspendLayout();
                    fotoList.ShowDialog();
                    this.ResumeLayout();
                }
                bindingSourceCadastro.ResumeBinding();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void tbxNumMedidor_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxNumMedidor.Text))
            {
                tbxFabricante.Text = string.Empty;
                tbxCapacidade.Text = string.Empty;
            }
        }

        private void tbxNumMedidor2_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxNumMedidor2.Text))
            {
                tbxFabricante2.Text = string.Empty;
                tbxCapacidade2.Text = string.Empty;
            }
        }

        private void tbxLeitura_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (tbxLeitura.Text == "" && string.IsNullOrEmpty(leitu)) return;

                if (leitu == "")
                {
                    tbxLeitura.Text = tbxLeitura.Text.PadLeft(int.Parse(cbxQuantidade.SelectedItem.ToString()), '0');
                }
                else
                {
                    tbxLeitura.Text = leitu.PadLeft(int.Parse(cbxQuantidade.SelectedItem.ToString()), '0');
                }
                return;
            }
            catch (Exception)
            {
            }
        }

        private void tbxLeitura2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (tbxLeitura2.Text == "" && string.IsNullOrEmpty(leitu2)) return;

                if (leitu2 == "")
                {
                    tbxLeitura2.Text = tbxLeitura2.Text.PadLeft(int.Parse(cbxQuantidade2.SelectedItem.ToString()), '0');
                }
                else
                {
                    tbxLeitura2.Text = leitu2.PadLeft(int.Parse(cbxQuantidade2.SelectedItem.ToString()), '0');
                }
                return;
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// validação aba segunda ligação true para valido, false para invalido.
        /// </summary>
        /// <returns></returns>
        public void CheckSegundaLigacao()
        {           
            Cadastro cad = (Cadastro)bindingSourceCadastro.Current;

            //testa se a segunda ligadaçao esta habilitada na aba medidor
            if (cad.SegundaLigacao == "1")
            {
                //validação aba segunda ligação
                if (string.IsNullOrEmpty(cad.NumeroMedidor2) ||
                    (cad.Leitura2 == null || cad.Leitura2 == 0) ||
                    (cad.QtdeDigitosMedidor2 == null || cad.QtdeDigitosMedidor2 == 0) ||
                    string.IsNullOrEmpty(cad.ClasseMetrologica2) ||
                    string.IsNullOrEmpty(cad.MedidorLacrado2))
                {
                    throw new Exception("Dados incompletos na aba \"2° Ligação\"");
                }
            }            
        }
    }
}


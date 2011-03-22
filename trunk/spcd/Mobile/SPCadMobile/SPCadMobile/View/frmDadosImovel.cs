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
    public partial class frmDadosImovel : CustomFormAba
    {
        public String flagConcluido { get; set; }
        public bool flgLigaEvent = false;//false = desligado, true = ligado.
        public int? statusExecucao{get;set;}

        //cadastro e matricula corrente
        long cadastroCurrent = 0;
        long matriculaCurrent = 0;

        //indica a aba atual.
        int indexCurret = 0;

        public frmDadosImovel(long cadastro, long matricula)
        {
            InitializeComponent();

            cadastroCurrent = cadastro;
            matriculaCurrent = matricula;

            chkConfirmado.Visible = true;
            dtpDataTermino.Text = DateTime.Now.ToString();

            cbxFontealter.DataSource = ListFonteAlternativa.getList();
            cbxFontealter.SelectedIndex = 0;
            cbxSitImovel.DataSource = TiposSituacaoImovel.GetList();
            cbxIncompativel.DataSource = ListResposta.getList();
            cbxComplemento.DataSource = ListTipoComplemento.getList();
            cbxCondicao.DataSource = ListCondicaoImovel.getList();
            cbxSitImovel.DataSource = TiposSituacaoImovel.GetList();

            //bindingSourceCadastro.DataSource = SingletonFlow.cadastroFlow.getPontoServicobyMatCadDI(cadastro, matricula);
            loadDataInterface();

            CheckModicacoes();//verifica o estado da confirmação e alteração.
            DisableComponentes();//disabilita edição dos componetes da tela  

            flgLigaEvent = (bindingSourceCadastro.Count > 0) ? true : false;//permite que os eventos de textchange sejam habilitados.

           
            //alexis 15-02-2011
            //seta indice da aba utilizada em uma variavel global.
            tabControl1.SelectedIndex = 0;
            indexCurret = tabControl1.SelectedIndex;
        }

        //carrega a tela com dados de cadastro com base no id cadastro e matricula.
        private void loadDataInterface()
        {
            bindingSourceCadastro.DataSource = SingletonFlow.cadastroFlow.getPontoServicobyMatCadDI(cadastroCurrent, matriculaCurrent);
        }

        /// <summary>
        /// verifica o estado da confirmação e alteração.
        /// </summary>
        private void CheckModicacoes()
        {
            bindingSourceCadastro.EndEdit();

            char[] cad;

            if (!string.IsNullOrEmpty(((Cadastro)bindingSourceCadastro.Current).FlagImovelAba))
            {
                cad = ((Cadastro)bindingSourceCadastro.Current).FlagImovelAba.ToCharArray();

                flagConcluido = ((Cadastro)bindingSourceCadastro.Current).FlagImovelAba;
            }
            else
            {
                return;
            }

            switch (NomeAbaCorrente())
            {
                case "tabImovel":
                    if (cad[0] == (char)FlgAba.ALT)
                    { lblAlterado.Visible = true; }
                    else
                        lblAlterado.Visible = false;

                    if (cad[0] == (char)FlgAba.CNF)
                    { chkConfirmado.Checked = true; }
                    else
                        chkConfirmado.Checked = false;

                    break;
                case "tabEconomias":
                    if (cad[1] == (char)FlgAba.ALT)
                    { lblAlterado.Visible = true; }
                    else
                        lblAlterado.Visible = false;

                    if (cad[1] == (char)FlgAba.CNF)
                    { chkConfirmado.Checked = true; }
                    else
                        chkConfirmado.Checked = false;

                    break;
                case "tabCaracteristicas":
                    if (cad[2] == (char)FlgAba.ALT)
                    { lblAlterado.Visible = true; }
                    else
                        lblAlterado.Visible = false;

                    if (cad[2] == (char)FlgAba.CNF)
                    { chkConfirmado.Checked = true; }
                    else
                        chkConfirmado.Checked = false;

                    break;
                case "tabInfAdicional":
                    if (cad[3] == (char)FlgAba.CNF)
                    { chkConfirmado.Checked = true; }
                    else
                        chkConfirmado.Checked = false;

                    break;
            }

            bindingSourceCadastro.ResumeBinding();
        }

        /// <summary>
        /// Botão Editar/Salvar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                bool status = (menuItem1.Text == "Salvar") ? true : false;

                if (status)
                {
                    Salvar(NomeAbaCorrente());
                }

                SairModoEdicao(status);
                

                HideCtrlCheckalter(status);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                CheckModicacoes();
                Cursor.Current = Cursors.Default;
            }
        }

        //Salva os dados da interface frmDadosImovel.cs
        private void Salvar(string aba)
        {   
            try
            {
                bindingSourceCadastro.EndEdit();
                Cadastro cad = (Cadastro)bindingSourceCadastro.Current;

                char[] FlagImovAba;

                if (!string.IsNullOrEmpty(cad.FlagImovelAba))
                {
                    FlagImovAba = cad.FlagImovelAba.ToCharArray();
                }
                else
                {
                    FlagImovAba = new char[] { '0', '0', '0', '0', '0', '0', '0', '0', '0', '0' };
                }

                char confirma = (char)FlgAba.NEX;

                switch (aba)
                {
                    case "tabImovel":                        

                        if (!string.IsNullOrEmpty(cad.TipoComplementoAlter) && string.IsNullOrEmpty(cad.InformacaoComplementarAlter))
                        {                            
                            throw new Exception("É necessário informar o campo \"Informação Complementar\".");
                        }

                        if(cad.CondicaoImovelAlter.isNullorZero())
                        {
                            throw new Exception("É necessário informar o campo \"Condição \".");
                        }

                        if (cad.checkAltImovel)
                        {
                            confirma = (char)FlgAba.ALT;
                        }
                        else if (chkConfirmado.Checked)
                        {
                            confirma = (char)FlgAba.CNF;
                        }

                        //testa se a seleção foi nula;
                        cad.TipoComplementoAlter = (cad.TipoComplementoAlter == "") ? null : cad.TipoComplementoAlter;

                        //verifica se os campos obrigatorios foram preenchidos.
                        validarImóvel(confirma);
                        FlagImovAba[0] = confirma;
                        break;
                    case "tabEconomias":
                        string[] listaId = new string[4];

                        listaId[0] = (cad.RamoAtividade1Alter.isNullorZero()) ? "0" : cad.RamoAtividade1Alter.ToString();
                        listaId[1] = (cad.RamoAtividade2Alter.isNullorZero()) ? "0" : cad.RamoAtividade2Alter.ToString();
                        listaId[2] = (cad.RamoAtividade3Alter.isNullorZero()) ? "0" : cad.RamoAtividade3Alter.ToString();
                        listaId[3] = (cad.RamoAtividade4Alter.isNullorZero()) ? "0" : cad.RamoAtividade4Alter.ToString();

                        List<RamoAtividade> ativs = SingletonFlow.ramoAtividadeFlow.getListRamoAtivByListId(listaId);

                        string msg = "";

                        int teste = ativs.Where(a => a.Tipo.Trim() == "C").ToList().Count;

                        if (ativs.Where(a => a.Tipo.Trim() == "C").ToList().Count != cad.QtdeEconomiasComercialAlter)
                            msg += "comércio";

                        teste = ativs.Where(a => a.Tipo.Trim() == "I").ToList().Count;

                        if (ativs.Where(a => a.Tipo.Trim() == "I").ToList().Count != cad.QtdeEconomiasIndustrialAlter)
                            msg += string.IsNullOrEmpty(msg) ? "indústria" : ", indústria";

                        teste = ativs.Where(a => a.Tipo.Trim() == "P").ToList().Count;

                        if (ativs.Where(a => a.Tipo.Trim() == "P").ToList().Count != cad.QtdeEconomiasPublicaAlter)
                            msg += string.IsNullOrEmpty(msg) ? "categoria pública" : ", categoria pública";

                        if (msg != "")
                        {                            
                            MessageBox.Show("Divergência entre quantidade de econômias e ramo de atividade para: ", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);                            
                        }

                        if (cad.checkAltEconomia)
                        {
                            confirma = (char)FlgAba.ALT;
                        }
                        else if (chkConfirmado.Checked)
                        {
                            confirma = (char)FlgAba.CNF;
                        }

                        FlagImovAba[1] = confirma;
                        break;
                    case "tabCaracteristicas":
                        if (string.IsNullOrEmpty(cad.ReservatorioAlter) || cad.ReservatorioAlter == "0")
                        {
                            throw new Exception("É necessário informar o campo \"Possui Reservatório\".");
                        }

                        if (string.IsNullOrEmpty(cad.PiscinaAlter) || cad.PiscinaAlter == "0")
                        {
                            throw new Exception("É necessário informar o campo \"Possui piscina\".");
                        }

                        if (string.IsNullOrEmpty(cad.FonteAlternativaAlter) || cad.FonteAlternativaAlter == "0")
                        {
                            throw new Exception("É necessário informar o campo \"Fonte Alternativa\".");
                        }

                        if (string.IsNullOrEmpty(cad.SituacaoImovelAlter) || cad.SituacaoImovelAlter == "0")
                        {
                            throw new Exception("É necessário informar \"Sit. Imóvel\".");
                        }

                        if (cad.checkAltCaracteristica)
                        {
                            confirma = (char)FlgAba.ALT;
                        }
                        else if (chkConfirmado.Checked)
                        {
                            confirma = (char)FlgAba.CNF;
                        }

                        FlagImovAba[2] = confirma;
                        break;
                    case "tabInfAdicional":
                        FlagImovAba[3] = confirma;
                        break;
                }

                cad.FlagImovelAba = new string(FlagImovAba);

                if (cbxCondicao.Text != "OBRA")
                {
                    cad.PrevisaoFimObra = null;
                }

                SingletonFlow.cadastroFlow.Update(cad);

                flagConcluido = cad.FlagImovelAba;
                bindingSourceCadastro.ResumeBinding();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //verifica se o usuário preencheu os campos obrigatórios da aba imóvel.
        private void validarImóvel(char confirma)
        {
            //verifica se a aba imóvel foi alterada ou se está apenas confirmando os dados.
            //Permite a validação quando os dados são alterados.
            if (confirma == (char)FlgAba.ALT)
            {
                if (string.IsNullOrEmpty(tbxNumero.Text))
                {
                    throw new Exception("Campo número do imóvel não informado.");
                }
            }
        }

        /// <summary>
        /// Evento de mudança de aba
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (menuItem1.Text == "Salvar" && tabControl1.SelectedIndex != indexCurret)
            {
                tabControl1.SelectedIndex = indexCurret;
            }
            else
            {
                indexCurret = tabControl1.SelectedIndex;
            }

            if (tabControl1.TabPages[tabControl1.SelectedIndex].Name == "tabInfAdicional")
            {
                chkConfirmado.Visible = false;
                lblAlterado.Visible = false;
            }
            else
            {
                chkConfirmado.Visible = true;
                //lblAlterado.Visible = true;
                CheckModicacoes();
            }            
        }

        #region Status componetes das abas
        // ativa/desativa componentes de tela da aba imóvel.
        private void StatusAbaImóvel(bool status)
        {
            tbxNumero.ReadOnly = status;
            cbxComplemento.Enabled = !status;
            tbxComplemento.ReadOnly = status;
            cbxCondicao.Enabled = !status;

            if (cbxCondicao.Text == "OBRA")
            {
                dtpDataTermino.Enabled = !status;
                dtpDataTermino.Visible = true;
                lblPrevisaoTermino.Visible = true;
            }

            StatusBotaoEditar(!status);
        }

        // ativa/desativa componentes de tela da aba economia.
        private void StatusAbaEconomia(bool status)
        {
            tbxQtdComercial.ReadOnly = status;
            tbxQtdIndustrial.ReadOnly = status;
            tbxQtdPublica.ReadOnly = status;
            tbxQtdResidencial.ReadOnly = status;
            ubtnRamoAtiv1.Enabled = !status;
            ubtnRamoAtiv2.Enabled = !status;
            ubtnRamoAtiv3.Enabled = !status;
            ubtnRamoAtiv4.Enabled = !status;
            ubtnRemove1.Enabled = !status;
            ubtnRemove2.Enabled = !status;
            ubtnRemove3.Enabled = !status;
            ubtnRemove4.Enabled = !status;

            StatusBotaoEditar(!status);
        }

        // ativa/desativa componentes de tela da aba caracteristica.
        private void StatusAbaCaracteristica(bool status)
        {
            if (ckbTarfSocial.Checked)
            {
                cbxIncompativel.Enabled = !status;
            }
            cbxFontealter.Enabled = !status;
            rdPossuiReservatorio.Enabled = !status;
            rdPossuiPiscina.Enabled = !status;
            cbxSitImovel.Enabled = !status;
            StatusBotaoEditar(!status);
            tbxObservacaoTS.Enabled = !status;
        }

        // ativa/desativa componentes de tela da aba informação adicional.
        private void StatusAbaInfAdicional(bool status)
        {
            tbxInfComplementar.ReadOnly = status;
            StatusBotaoEditar(!status);
        }


        /// <summary>
        /// true para Salvar/Cancelar, false para Editar/Voltar
        /// </summary>
        /// <param name="status"></param>
        private void StatusBotaoEditar(bool status)
        {
            menuItem1.Text = (status) ? "Salvar" : "Editar";
            menuItem2.Text = (status) ? "Cancelar" : "Voltar";
        }

        //bloquea todos os componentes das abas
        private void DisableComponentes()
        {
            bool status = true;

            StatusAbaImóvel(status);
            StatusAbaEconomia(status);
            StatusAbaCaracteristica(status);
            StatusAbaInfAdicional(status);
            StatusBotaoEditar(!status);
        }
        #endregion

        #region Adiciona ou remove abas durante edição

        /// <summary>
        /// true para remover, false para adicionar
        /// </summary>
        /// <param name="status"></param>
        private void AddRemoveEconomia(bool status)
        {
            if (status)
                this.tabControl1.Controls.Remove(this.tabEconomias);
            else
                this.tabControl1.Controls.Add(this.tabEconomias);
        }

        private void AddRemoveImovel(bool status)
        {
            if (status)
                this.tabControl1.Controls.Remove(this.tabImovel);
            else
                this.tabControl1.Controls.Add(this.tabImovel);
        }

        private void AddRemoveCaracteristica(bool status)
        {
            if (status)
                this.tabControl1.Controls.Remove(this.tabCaracteristicas);
            else
                this.tabControl1.Controls.Add(this.tabCaracteristicas);
        }

        private void AddRemoveInfAdicional(bool status)
        {
            if (status)
                this.tabControl1.Controls.Remove(this.tabInfAdicional);
            else
                this.tabControl1.Controls.Add(this.tabInfAdicional);
        }

        private string NomeAbaCorrente()
        {
            return tabControl1.TabPages[tabControl1.SelectedIndex].Name;
        }

        #endregion

        /// <summary>
        /// Evento botão Confirmação
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkConfirmado_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Salvar(NomeAbaCorrente());
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                CheckModicacoes();
                Cursor.Current = Cursors.Default;
            }
        }

        private void SairModoEdicao(bool status)
        {
            switch (NomeAbaCorrente())
            {
                case "tabImovel": 
                    StatusAbaImóvel(status);
                    break;
                case "tabEconomias": 
                    StatusAbaEconomia(status);
                    break;
                case "tabCaracteristicas": 
                    StatusAbaCaracteristica(status);
                    break;
                case "tabInfAdicional": 
                    StatusAbaInfAdicional(status);
                    break;
            }
        }

        /// <summary>
        /// Sair da interface frmDadosImovel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                if (menuItem2.Text == "Cancelar")
                {
                    //bindingSourceCadastro.ResetItem(0);

                    Cursor.Current = Cursors.WaitCursor;
                    loadDataInterface();

                    SairModoEdicao(true);

                    StatusBotaoEditar(false);

                    HideCtrlCheckalter(true);
                    return;
                }

                statusExecucao = ((Cadastro)bindingSourceCadastro.Current).StatusExecucao;

                //limpa a lista estatica fonte alternativa;
                this.Close();
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

        #region Pesquisa Ramo Atividades

        private void ubtnRamoAtiv1_Click(object sender, EventArgs e)
        {
            using (FrmPesquisaRamoAtividade ramoAtiv = new FrmPesquisaRamoAtividade())
            {
                ramoAtiv.ShowDialog();
                if (ramoAtiv.ramoAtividadeSelecionada == null)
                {
                    return;
                }
                else
                {
                    this.SuspendLayout();
                    if (CheckDuploRamAtiv(ramoAtiv.ramoAtividadeSelecionada.Descricao))
                    {
                        MessageBox.Show("Este item já foi selecionado", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        return;
                    }

                    ((Cadastro)bindingSourceCadastro.Current).RamoAtividade1Alter = ramoAtiv.ramoAtividadeSelecionada.Id;
                    tbxRamoAtiv1.Text = ramoAtiv.ramoAtividadeSelecionada.Descricao;
                    this.ResumeLayout();
                }
            }
        }

        private void ubtnRamoAtiv2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxRamoAtiv1.Text))
            {
                MessageBox.Show("Selecione um ramo atividade no campo anterior", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }

            using (FrmPesquisaRamoAtividade ramoAtiv = new FrmPesquisaRamoAtividade())
            {
                ramoAtiv.ShowDialog();
                if (ramoAtiv.ramoAtividadeSelecionada == null)
                {
                    return;
                }
                else
                {
                    this.SuspendLayout();

                    if (CheckDuploRamAtiv(ramoAtiv.ramoAtividadeSelecionada.Descricao))
                    {
                        MessageBox.Show("Este item já foi selecionado", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        return;
                    }

                    ((Cadastro)bindingSourceCadastro.Current).RamoAtividade2Alter = ramoAtiv.ramoAtividadeSelecionada.Id;
                    tbxRamoAtiv2.Text = ramoAtiv.ramoAtividadeSelecionada.Descricao;
                    this.ResumeLayout();
                }
            }
        }

        private void ubtnRamoAtiv3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxRamoAtiv2.Text))
            {
                MessageBox.Show("Selecione um ramo atividade no campo anterior", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }

            using (FrmPesquisaRamoAtividade ramoAtiv = new FrmPesquisaRamoAtividade())
            {
                ramoAtiv.ShowDialog();
                if (ramoAtiv.ramoAtividadeSelecionada == null)
                {
                    return;
                }
                else
                {
                    this.SuspendLayout();
                    if (CheckDuploRamAtiv(ramoAtiv.ramoAtividadeSelecionada.Descricao))
                    {
                        MessageBox.Show("Este item já foi selecionado", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        return;
                    }

                    ((Cadastro)bindingSourceCadastro.Current).RamoAtividade3Alter = ramoAtiv.ramoAtividadeSelecionada.Id;
                    tbxRamoAtiv3.Text = ramoAtiv.ramoAtividadeSelecionada.Descricao;
                    this.ResumeLayout();
                }
            }
        }

        private void ubtnRamoAtiv4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxRamoAtiv3.Text))
            {
                MessageBox.Show("Selecione um ramo atividade no campo anterior", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }

            using (FrmPesquisaRamoAtividade ramoAtiv = new FrmPesquisaRamoAtividade())
            {
                ramoAtiv.ShowDialog();
                if (ramoAtiv.ramoAtividadeSelecionada == null)
                {
                    return;
                }
                else
                {
                    this.SuspendLayout();

                    if (CheckDuploRamAtiv(ramoAtiv.ramoAtividadeSelecionada.Descricao))
                    {
                        MessageBox.Show("Este item já foi selecionado", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        return;
                    }

                    ((Cadastro)bindingSourceCadastro.Current).RamoAtividade4Alter = ramoAtiv.ramoAtividadeSelecionada.Id;
                    tbxRamoAtiv4.Text = ramoAtiv.ramoAtividadeSelecionada.Descricao;
                    this.ResumeLayout();
                }
            }
        }

        //retorna true se já houver o ramo atividade selecionado.
        private bool CheckDuploRamAtiv(string valor)
        {
            if (tbxRamoAtiv1.Text == valor)
            {
                return true;
            }

            if (tbxRamoAtiv2.Text == valor)
            {
                return true;
            }

            if (tbxRamoAtiv3.Text == valor)
            {
                return true;
            }

            if (tbxRamoAtiv4.Text == valor)
            {
                return true;
            }

            return false;
        }


        #endregion

        /// <summary>
        /// Evento de mudança opção de resposta da combo imcopatível
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxIncompativel_SelectedValueChanged(object sender, EventArgs e)
        {
            if (((ItemCombo)cbxIncompativel.SelectedItem).Description.ToString() == "Sim")
            {
                tbxObservacaoTS.ReadOnly = false;
                tbxObservacaoTS.Text = "Área superior a 44m²";
            }
            else
            {
                tbxObservacaoTS.ReadOnly = true;
                tbxObservacaoTS.Text = string.Empty;
            }
        }

        private void rbPessoaJuridica_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnOcorrencias_Click(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
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

        /// <summary>
        /// Abilita a caixa de data termino se a opção da condição for obra.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxCondicao_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbxCondicao.Text == "OBRA")
            {
                dtpDataTermino.Enabled = true;
                dtpDataTermino.Visible = true;
                lblPrevisaoTermino.Visible = true;
            }
            else
            {
                dtpDataTermino.Enabled = false;
                dtpDataTermino.Visible = false;
                lblPrevisaoTermino.Visible = false;
            }
        }

        private void tbxNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != '\b')//a segunda expressão habilita a funcionalidade do botão backspace do teclado.
            {
                e.Handled = true;
            }
        }

        private void bindingSourceCadastro_BindingComplete(object sender, BindingCompleteEventArgs e)
        {
            if (e.ErrorText == "FormatException")
            {
                e.Cancel = false;
            };
        }

        private void tbxNumero_TextChanged(object sender, EventArgs e)
        {
            if (flgLigaEvent)
            {
                if (string.IsNullOrEmpty(tbxNumero.Text))
                {
                    ((Cadastro)bindingSourceCadastro.Current).NumeroImovelAlter = null;
                }
            }
        }

        private void tbxQtdResidencial_TextChanged(object sender, EventArgs e)
        {
            if (flgLigaEvent)
            {
                if (string.IsNullOrEmpty(tbxQtdResidencial.Text))
                {
                    ((Cadastro)bindingSourceCadastro.Current).QtdeEconomiasResidencialAlter = null;
                }
            }
        }

        private void tbxQtdComercial_TextChanged(object sender, EventArgs e)
        {
            if (flgLigaEvent)
            {
                if (string.IsNullOrEmpty(tbxQtdComercial.Text))
                {
                    ((Cadastro)bindingSourceCadastro.Current).QtdeEconomiasComercialAlter = null;
                }
            }
        }

        private void tbxQtdIndustrial_TextChanged(object sender, EventArgs e)
        {
            if (flgLigaEvent)
            {
                if (string.IsNullOrEmpty(tbxQtdIndustrial.Text))
                {
                    ((Cadastro)bindingSourceCadastro.Current).QtdeEconomiasIndustrialAlter = null;
                }
            }
        }

        private void tbxQtdPublica_TextChanged(object sender, EventArgs e)
        {
            if (flgLigaEvent)
            {
                if (string.IsNullOrEmpty(tbxQtdPublica.Text))
                {
                    ((Cadastro)bindingSourceCadastro.Current).QtdeEconomiasPublicaAlter = null;
                }
            }
        }

        //remove o ramo atividade escolhido
        private void ubtnRemove1_Click(object sender, EventArgs e)
        {
            ((Cadastro)bindingSourceCadastro.Current).RamoAtividade1Alter = null;
            tbxRamoAtiv1.Text = string.Empty;
        }

        private void ubtnRemove2_Click(object sender, EventArgs e)
        {
            ((Cadastro)bindingSourceCadastro.Current).RamoAtividade2Alter = null;
            tbxRamoAtiv2.Text = string.Empty;
        }

        private void ubtnRemove3_Click(object sender, EventArgs e)
        {
            ((Cadastro)bindingSourceCadastro.Current).RamoAtividade3Alter = null;
            tbxRamoAtiv3.Text = string.Empty;
        }

        private void ubtnRemove4_Click(object sender, EventArgs e)
        {
            ((Cadastro)bindingSourceCadastro.Current).RamoAtividade4Alter = null;
            tbxRamoAtiv4.Text = string.Empty;
        }

        private void HideCtrlCheckalter(bool status)
        {          
            if (tabControl1.TabPages[tabControl1.SelectedIndex].Name == "tabInfAdicional")
            {
                chkConfirmado.Visible = false;
//                lblAlterado.Visible = false;
            }
            else
            {
                chkConfirmado.Visible = status;                
            }
        }
    }
}
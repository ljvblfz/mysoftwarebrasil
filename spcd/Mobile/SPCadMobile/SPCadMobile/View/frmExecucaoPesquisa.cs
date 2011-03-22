using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SPCadMobileData.Data.Model;
using SPCadMobileData.Data;
using CopasaMobile.View;
using CommonHelpMobile;

namespace SPCadMobile.View
{
    public partial class frmExecucaoPesquisa : CustomForm
    {
        List<CadastroAuxiliar> lstCad { get; set; }

        /// <summary>
        ///  Contrutor da tela
        /// </summary>
        /// <param name="cad">List lista de cadastro (Model auxiliar)</param>
        /// <param name="position">int posição que indica o ca</param>
        public frmExecucaoPesquisa(List<CadastroAuxiliar> cad, int position)
        {
            InitializeComponent();
            lstCad = cad;

            //carrega o bindingSource
            bindingSourceCadastro.DataSource = cad;

            //seleciona a posiçao selecionada na interface pesquisa cadastral
            bindingSourceCadastro.Position = position;
            CountQTDPS();

            verificarConclusao();

            // Verifica se esta na aba padão
            if (position <= cad.Count && position >= 0)
            {
                CadastroAuxiliar cadAUX = cad[position];

                // Verifica se a Situação de Ponto de Serviço estiver diferente de "Ativo"
                if (cadAUX != null)
                    if (cadAUX.SituacaoPontoServicoAlter != "A")
                    {
                        MessageBox.Show("ATENÇÃO! Ponto de Serviço não está ativo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    }
            }
        }

        /// <summary>
        /// Verifica se o imóvel está impedido de execução: true para impedido de execução;
        /// </summary>
        /// <returns></returns>
        public void verificaStatus()
        {
            if (((CadastroAuxiliar)bindingSourceCadastro.Current).StatusExecucao == 2)
            {
                NextPS();
            }
        }

        /// <summary>
        /// Busca o próximo Ponto de serviço na lista de Pontos de serviços.
        /// </summary>
        private void NextPS()
        {
            bindingSourceCadastro.MoveNext();

            if (((CadastroAuxiliar)bindingSourceCadastro.Current).StatusExecucao == 2)
            {
                if (bindingSourceCadastro.Count == bindingSourceCadastro.Position + 1)
                {
                    if (((CadastroAuxiliar)bindingSourceCadastro.Current).StatusExecucao == 2)
                    {
                        this.Close();
                        return;
                    }
                }

                NextPS();
            }
            else
            {

                //verifica se os dados estão concluídos.
                verificarConclusao();

                //quantifica o numero de pontos de servico da matrícula corrente.
                CountQTDPS();

                //Verifica se a lista chegou ao fim, se sim botão 'próximo' é desabilitado.
                if (bindingSourceCadastro.Count == bindingSourceCadastro.Position + 1)
                {
                    if (((CadastroAuxiliar)bindingSourceCadastro.Current).StatusExecucao == 2)
                    {
                        this.Close();
                        return;
                    }
                    else
                    {
                        menuItem1.Enabled = false;
                    }
                }
            }
        }

        /// <summary>
        /// Conta o número de Ponto de serviço por Matrícula
        /// </summary>
        private void CountQTDPS()
        {
            int qtd = lstCad.Count(ca => ca.Matricula == ((CadastroAuxiliar)bindingSourceCadastro.Current).Matricula);

            tbxQtdPS.Text = qtd.ToString();
        }

        /// <summary>
        /// Aciona a interface Dados imóvel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImovel_Click(object sender, EventArgs e)
        {
            try
            {
                long matricula = ((CadastroAuxiliar)bindingSourceCadastro.Current).Matricula;
                long cadastro = ((CadastroAuxiliar)bindingSourceCadastro.Current).Id;
                Cursor.Current = Cursors.WaitCursor;
                using (frmDadosImovel imov = new frmDadosImovel(cadastro, matricula))
                {
                    Cursor.Current = Cursors.Default;
                    this.SuspendLayout();
                    imov.ShowDialog();
                    this.ResumeLayout();
                    ((CadastroAuxiliar)bindingSourceCadastro.Current).StatusExecucao = imov.statusExecucao;
                    Cursor.Current = Cursors.WaitCursor;
                    verificarConclusao();
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

        /// <summary>
        /// Aciona a interface P.S Hidrômetro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHidrometro_Click(object sender, EventArgs e)
        {
            try
            {
                long matricula = ((CadastroAuxiliar)bindingSourceCadastro.Current).Matricula;
                long cadastro = ((CadastroAuxiliar)bindingSourceCadastro.Current).Id;
                Cursor.Current = Cursors.WaitCursor;
                using (frmPontoServHidrometro psHid = new frmPontoServHidrometro(cadastro, matricula))
                {
                    this.SuspendLayout();
                    Cursor.Current = Cursors.Default;
                    psHid.ShowDialog();
                    this.ResumeLayout();
                    verificarConclusao();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha inesperada: " + ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

        }

        /// <summary>
        /// Aciona a interface Histórico Comum
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConsumo_Click(object sender, EventArgs e)
        {
            long cadastro = ((CadastroAuxiliar)bindingSourceCadastro.Current).Id;
            long matricula = ((CadastroAuxiliar)bindingSourceCadastro.Current).Matricula;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                using (frmConsumo consumo = new frmConsumo(cadastro, matricula))
                {
                    this.SuspendLayout();
                    Cursor.Current = Cursors.Default;
                    consumo.ShowDialog();
                    this.ResumeLayout();
                    verificarConclusao();
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

        private void btnInfoAdicional_Click(object sender, EventArgs e)
        {
            try
            {
                bindingSourceCadastro.EndEdit();
                CadastroAuxiliar cad = (CadastroAuxiliar)bindingSourceCadastro.Current;

                Cursor.Current = Cursors.WaitCursor;

                using (frmInformacaoAdicional infoAd = new frmInformacaoAdicional(cad.Id))
                {
                    this.SuspendLayout();
                    Cursor.Current = Cursors.Default;
                    infoAd.ShowDialog();
                    verificarConclusao();
                    this.ResumeLayout();
                }

                bindingSourceCadastro.ResumeBinding();
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
        /// Sai da interface Execução Pesquisa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem3_Click(object sender, EventArgs e)
        {
            if (chxImovel.Checked || chxHidrometro.Checked || chxConsumo.Checked)
            {
                SalvaImovelConcluido();

                this.Close();
            }
            else if (MessageBox.Show("Existem atividades a serem feitas. Deseja finalizar?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        /// <summary>
        /// Concluír o ponto de serviço.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;                

                SalvaImovelConcluido();

                if (chxImovel.Checked && chxHidrometro.Checked && chxConsumo.Checked)
                {
                    NextPS();
                    return;
                }               

                if (MessageBox.Show("Existem atividades a serem feitas. Deseja finalizar?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    NextPS();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            { 
                Cursor.Current = Cursors.Default; 
            }
        }

        /// <summary>
        ///  Metodo que verifica o estado dos botões
        /// </summary>
        /// <param name="valorAba">string - valor que indica o estado das abas de cada tela</param>
        /// <example>
        ///     VALOR DA POSIÇÃO
        ///     
        ///     21000000 - numero que gravado no banco
        ///     
        ///     - Primeira posição numero "2"  => corresponde a primeira aba ,imovel,tabImovel;
        ///     - Segunda posição numero  "1"  => corresponde a segunda aba , economias,tabEconomias;
        ///     - Terceira posição numero "0"  => corresponde a terceira aba , caracteristicas,tabCaracteristicas;
        ///     - Quarta posição numero   "0"  => corresponde a quarta aba , inf Adicionais,tabInfAdicional;
        ///     
        ///     VALOR DA NUMERAÇÃO
        ///     
        ///     - "0" => corresponde ñ tem nenhum estado;
        ///     - "1" => corresponde a confirmado;
        ///     - "2" => corresponde a alterado;
        /// </example>
        /// <param name="tela">string - nome da tela</param>
        /// <return>void</return>
        private void VerificaConclusãoBotoes(string valorAbas, string tela)
        {
            // Abas da tela de imovel
            string abaImovel = string.Empty;
            string abaEconomia = string.Empty;
            string abaCaracteristica = string.Empty;

            // Verifica a tela            
            switch (tela)
            {
                // botão imovel
                case "imovel":
                    {
                        // Se foi definido um estado para a tela
                        if (!string.IsNullOrEmpty(valorAbas) && valorAbas != "0")
                        {
                            // Carrega cada aba com seu estado
                            ///     Cada posição representa uma aba:
                            ///     
                            ///     1º => imovel
                            ///     2º => economias
                            ///     3º => caracteristicas
                            abaImovel = valorAbas.Substring(0, 1);
                            abaEconomia = valorAbas.Substring(1, 1);
                            abaCaracteristica = valorAbas.Substring(2, 1);

                            // Regra que define o estado do botão
                            // OBS: 1=>confirmado , 2 =>alterado
                            if (
                                    (abaImovel == "1" || abaImovel == "2")
                                    && (abaEconomia == "1" || abaEconomia == "2") 
                                    && (abaCaracteristica == "1" || abaCaracteristica == "2")
                                )
                            {
                                // Marca como feito
                                chxImovel.Checked = true;
                                btnImovel.BackColor = Color.GreenYellow;
                            }
                            else
                            {
                                // Marca como pendnete
                                chxImovel.Checked = false;
                                btnImovel.BackColor = Color.Gainsboro;
                            }
                        }
                        else // Se não foi definido um estado marca como pendente
                        {
                            chxImovel.Checked = false;
                            btnImovel.BackColor = Color.Gainsboro;
                        }
                    }
                    break;

                // botão ponto de serviço/hidrometro
                case "hidrometro":
                    {
                        //testa se dados de PS Hidrometro está confirmado.
                        if (chxImovel.Checked)
                        {
                            if (valorAbas == "2")
                            {
                                chxHidrometro.Checked = true;
                                btnHidrometro.BackColor = Color.GreenYellow;
                            }
                            else
                            {
                                chxHidrometro.Checked = false;
                                btnHidrometro.BackColor = Color.Gainsboro;
                            }
                        }
                        else
                        {
                            chxHidrometro.Checked = false;
                            btnHidrometro.BackColor = Color.Gainsboro;
                        }

                    }
                    break;
                
                // botão consumo
                case "consumo":
                    {
                        if (chxHidrometro.Checked)
                        {
                            if (valorAbas == "2")
                            {
                                chxConsumo.Checked = true;
                                btnConsumo.Enabled = true;
                                btnConsumo.BackColor = Color.GreenYellow;
                            }
                            else
                            {
                                chxConsumo.Checked = false;
                                btnConsumo.Enabled = true;
                                btnConsumo.BackColor = Color.Gainsboro;
                            }
                        }
                    }
                    break;
                
                // botão informação adicional
                case "infoAdicional":
                    if (string.IsNullOrEmpty(valorAbas))
                    {
                        btnInfoAdicional.BackColor = Color.Gainsboro;
                        chxInfoAdicional.Checked = false;
                    }
                    else
                    {
                        btnInfoAdicional.BackColor = Color.GreenYellow;
                        chxInfoAdicional.Checked = true;
                        ((CadastroAuxiliar)bindingSourceCadastro.Current).ObservacaoVisita = valorAbas;
                    }

                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void verificarConclusao()
        {
            //verifica se os dados estão concluídos.
            VerificaConclusãoBotoes(SingletonFlow.cadastroFlow.getFlagImovel(((CadastroAuxiliar)bindingSourceCadastro.Current).Id, ((CadastroAuxiliar)bindingSourceCadastro.Current).Matricula), "imovel");
            VerificaConclusãoBotoes(SingletonFlow.cadastroFlow.getFlagPSHidro(((CadastroAuxiliar)bindingSourceCadastro.Current).Id, ((CadastroAuxiliar)bindingSourceCadastro.Current).Matricula), "hidrometro");
            VerificaConclusãoBotoes(SingletonFlow.cadastroFlow.verificaConsumo(((CadastroAuxiliar)bindingSourceCadastro.Current).Id), "consumo");
            VerificaConclusãoBotoes(SingletonFlow.cadastroFlow.getObsVista(((CadastroAuxiliar)bindingSourceCadastro.Current).Id, ((CadastroAuxiliar)bindingSourceCadastro.Current).Matricula), "infoAdicional");
        }

        /// <summary>
        /// aciona a interface de impedimento
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mItemImpedimento_Click(object sender, EventArgs e)
        {
            if (bindingSourceCadastro.Count == 0)//testa se existe algum item na lista.
            {
                MessageBox.Show("É necessário escolher um item na lista", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }

            bindingSourceCadastro.EndEdit();
            CadastroAuxiliar cad = (CadastroAuxiliar)bindingSourceCadastro.Current;

            //GPS
            #region Captura Coordenada
            //try
            //{
            //    bool autoriza = true;
            //    if (!string.IsNullOrEmpty(cad.CoordenadaX) || !string.IsNullOrEmpty(cad.CoordenadaY))
            //    {
            //        if (MessageBox.Show("Deseja alterar as coordenadas", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.No)
            //        {
            //            autoriza = false;
            //        }
            //    }

            //    if (autoriza)
            //    {
            //        GetCoordenadaGPS coord = new GetCoordenadaGPS();

            //        CadastroAuxiliar cadGPS = cad;

            //        cad.CoordenadaX = coord.latitude.ToString();
            //        cad.CoordenadaY = coord.longitude.ToString();
            //        cad.DataGPS = coord.data;

            //        SingletonFlow.cadastroFlow.UpdateGPS(cad);

            //        MessageBox.Show("Coordenadas atualizadas.");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            //}

            #endregion

            try
            {

                using (frmImpedimentoExecucao impEx = new frmImpedimentoExecucao(cad))
                {
                    this.SuspendLayout();
                    impEx.ShowDialog();
                    this.ResumeLayout();

                    if (impEx.statusExec == 2)
                    {
                        int pos = bindingSourceCadastro.Position;

                        bindingSourceCadastro.MoveNext();

                        //verifica se os dados estão concluídos.
                        verificarConclusao();

                        //quantifica o numero de pontos de servico da matrícula corrente.
                        CountQTDPS();

                        //Verifica se a lista chegou ao fim, se sim botão 'próximo' é desabilitado.
                        verificaStatus();
                    }
                }

                bindingSourceCadastro.ResumeBinding();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }
        /// <summary>
        /// Atualiza a flag status execução para 1 ou 2, executado ou não executado respectivamente.
        /// </summary>
        public void SalvaImovelConcluido()
        {
            try
            {
                bindingSourceCadastro.EndEdit();
                CadastroAuxiliar cad = (CadastroAuxiliar)bindingSourceCadastro.Current;
                Cadastro cadComp = SingletonFlow.cadastroFlow.getPontoServicobyMatCadDI(cad.Id, cad.Matricula);

                // valida flaLeitura das ocorrências com campo leitura do cadastro.
                List<Ocorrencia> ocorrencias = SingletonFlow.ocorrenciaFlow.getOcorrenciaByCadastro(cadComp);
                if (ocorrencias.Count > 0)
                {
                    if (!cadComp.Leitura.isNullorZero() && ocorrencias.Where(o => o.FlagLeituraEnum == FlgLeitura.Proibida).ToList().Count > 0)
                    {
                        MessageBox.Show("Ocorrência informada não permite leitura.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        return;
                    }
                    if (cadComp.Leitura.isNullorZero() && ocorrencias.Where(o => o.FlagLeituraEnum == FlgLeitura.Obrigatoria).ToList().Count > 0)
                    {
                        MessageBox.Show("Ocorrência informada exige leitura.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        return;
                    }
                }

                if (chxImovel.Checked && chxHidrometro.Checked && chxConsumo.Checked)//se todas as caixas estiverem true o imovel foi concluido.
                {
                    SingletonFlow.cadastroFlow.UpdateStatusExec(cad, 1);
                }
                else if (cad.StatusExecucao == 1)
                {
                    SingletonFlow.cadastroFlow.UpdateStatusExec(cad, 0);
                }

                int? x = SingletonFlow.cadastroFlow.getStatusExecByMatricula(cad.Matricula);

                switch (x)
                {
                    case 0: MessageBox.Show("Cadastro incompleto ou não executado!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        break;

                    case 1: MessageBox.Show("Cadastro Executado com sucesso!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        break;

                    case 2: MessageBox.Show("Cadastro Executado com impedimento!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        break;
                }

                bindingSourceCadastro.ResumeBinding();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

    }
}
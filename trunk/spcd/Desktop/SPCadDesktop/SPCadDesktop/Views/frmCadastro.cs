using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SPCadDesktopData.Data.Model;
using SPCadDesktopData.Data;
using CommonHelpDesktop;
using System.Configuration;
using System.IO;
using SPCadDesktop.Properties;
using System.Text.RegularExpressions;

namespace SPCadDesktop.Views
{
    public enum OperacaoFoto
    {
        Atualizar = 1, Voltar = 2, Proximo = 3
    }

    public partial class frmCadastro : Form
    {
        Cadastro cad = null;
        public int Position { get; set; }
        public frmCadastro(BindingSource cads)
        {
            InitializeComponent();
            bsCadastro.DataSource = cads.DataSource;
            bsCadastro.Position = cads.Position;

            loadRegistro();

            //verifica os campos com dados diferentes do original
            CheckAlterColor(null);
        }

        private void loadGrid(Cadastro cad)
        {
            bsOcorrencia.DataSource = SingletonFlow.ocorrenciaFlow.getOcorrenciaByCadastro(cad);
            bsHistorico.DataSource = SingletonFlow.historicoConsumoFlow.getListHistoricobyCadastro(cad.Id, cad.Matricula);
            bsFotos.DataSource = SingletonFlow.fotoFlow.getListFotoByPS(cad.Id, cad.NumeroPontoServico);
            loadFoto(OperacaoFoto.Atualizar);

            
        }

        private void loadRegistro()
        {
            cad = (Cadastro)bsCadastro.Current;

            loadGrid(cad);

            cboSituacao.DataSource = SituacaoCombo.getList();
            cboCadastrador.DataSource = ListFuncionario.getList(false);

            cboTipoComplemento.DataSource = ListTipoComplemento.getList();
            cboCondicaoAlter.DataSource = ListCondicaoImovel.getList();
            cboTSIncompativel.DataSource = ListResposta.getList();
            cboFonteAlternativaAlter.DataSource = ListFonteAlternativa.getList();
            cboPscinaAlter.DataSource = ListResposta.getList();
            cboReservatorioAlter.DataSource = ListResposta.getList();
            cboSituacaoAlter.DataSource = TiposSituacaoImovel.getList();
            cboSituacaoPSAlter.DataSource = ListSitPontServ.getList();
            cboLocalPadraoAlter.DataSource = ListLocalPadrao.getList();
            cboTipoPadraoAlter.DataSource = ListTipoPadrao.getList();
            cboPadraoLacrado.DataSource = ListResposta.getList();
            cboTorneiraPadrao.DataSource = ListResposta.getList();
            cboEliminadorAr.DataSource = ListResposta.getList();
            cboPSComMedidor.DataSource = ListResposta.getList();
            cboClasseMetroAlter.DataSource = ListClasseMetrologica.getList();
            cboHidrometroLacrado.DataSource = ListResposta.getList();
            cboSegundaLigacao.DataSource = ListResposta.getList();
            cboPSComMedidor2.DataSource = ListResposta.getList();
            cboClasseMetro2.DataSource = ListClasseMetrologica.getList();
            cboHidrometroLacrado2.DataSource = ListResposta.getList();
            cboExpectativaConsumo.DataSource = ListExpectativaConsumo.getList();
            cboIncompatibilidade.DataSource = ListResposta.getList();


        }

        private void salvar()
        {
            bsCadastro.EndEdit();
            Cadastro cad = (Cadastro)bsCadastro.Current;
            #region Validações do cadastro
            string[] dataExec = tbxDataHoraExec.Text.Split('/');
            string[] dataTerm = tbxTerminio.Text.Split('/');

            if (dataExec.Length == 1 && !string.IsNullOrEmpty(tbxDataHoraExec.Text))
            {
                MessageBox.Show("Formato inválido para o campo data de execução.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }

            if (dataTerm.Length == 1 && !string.IsNullOrEmpty(tbxTerminio.Text))
            {
                MessageBox.Show("Formato inválido para o campo data términio.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }

            //TODO: DEVE SER FEITO TODOS OS TRATAMENTOS ANTES DE SALVAR.

            #region valida ramos de atividades.
            // valida ramos de atividades.
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
                MessageBox.Show(string.Format("Divergência entre quantidade de economias e ramo de atividade para: {0}.", msg), "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            #endregion

            #region valida flagLeitura das ocorrências com campo leitura do cadastro.
            // valida flaLeitura das ocorrências com campo leitura do cadastro.
            List<Ocorrencia> ocorrencias = SingletonFlow.ocorrenciaFlow.getOcorrenciaByCadastro(cad);
            if (ocorrencias.Count > 0)
            {
                if (!cad.Leitura.isNullorZero() && ocorrencias.Where(o => o.FlagLeituraEnum == FlgLeitura.Proibida).ToList().Count > 0)
                {
                    MessageBox.Show("Ocorrência informada não permite leitura.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    return;
                }
                if (cad.Leitura.isNullorZero() && ocorrencias.Where(o => o.FlagLeituraEnum == FlgLeitura.Obrigatoria).ToList().Count > 0)
                {
                    MessageBox.Show("Ocorrência informada exige leitura.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    return;
                }
            }
            #endregion

            #endregion
            //Alexis 01-02-2011 11:30
            #region Validação de impedimento

            //Quando a situação é impedimento, verifica-se se alguma ocorrência do tipo impedimento foi adicionada.
            if (cad.StatusExecucao == 2)
            {
                //exibe mensagem quando há 
                if (!SingletonFlow.ocorrenciaFlow.CheckOcorrcImp(cad.VetorOcorrencia))
                {
                    MessageBox.Show("O campo situação exibe um impedimento, favor adicionar o registro de ocorrência de impedimento.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    return;
                }
            }
            else if (SingletonFlow.ocorrenciaFlow.CheckOcorrcImp(cad.VetorOcorrencia))
            {
                cad.StatusExecucao = 2;
            }
            #endregion

            cad.TipoComplementoAlter = cad.TipoComplementoAlter == "" ? null : cad.TipoComplementoAlter;

            // Caixa de dialogo se deseja salvar
            DialogResult resultado = MessageBox.Show("Deseja salvar os dados?", "SALVAR", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            // Se a resposta for OK salva os dados
            if (resultado == DialogResult.OK)
            {
                SingletonFlow.cadastroFlow.Update(cad);
                desabilitar();
            }

        }

        private void button10_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (bsOcorrencia.Count == 0)
            {
                MessageBox.Show("Não é possível excluir!\r\nLista vazia.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
            bsCadastro.EndEdit();
            Cadastro cadastro = (Cadastro)bsCadastro.Current;
            Ocorrencia ocorr = (Ocorrencia)bsOcorrencia.Current;
            string vet = cadastro.VetorOcorrencia;
            cadastro.VetorOcorrencia = vet.Replace("," + ocorr.Id.ToString().PadLeft(2, '0'), "");
            vet = cadastro.VetorOcorrencia;
            cadastro.VetorOcorrencia = vet.Replace(ocorr.Id.ToString().PadLeft(2, '0'), "");
            loadGrid(cadastro);
            bsCadastro.ResumeBinding();

        }

        private void button9_Click(object sender, EventArgs e)
        {
            salvar();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            bsCadastro.MovePrevious();
            loadGrid((Cadastro)bsCadastro.Current);
        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            bsCadastro.MoveNext();
            loadGrid((Cadastro)bsCadastro.Current);
        }

        private void bsCadastro_CurrentChanged(object sender, EventArgs e)
        {
            btnAnterior.Enabled = !(bsCadastro.Position == 0);
            btnProximo.Enabled = !(bsCadastro.Position == bsCadastro.Count - 1);
        }

        /// <summary>
        /// Retorna true, caso o código informado existir na lista.
        /// </summary>
        /// <returns></returns>
        private bool CheckNewCodInList()
        {
            if (bsOcorrencia.Count == 0) return false;
            List<Ocorrencia> a = ((List<Ocorrencia>)bsOcorrencia.List).Where(i => i.Id.ToString() == tbxCodOcorrencia.Text).ToList();

            if (a.Count > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Retorna a string com a lista de ocorrencia atualizada com o novo codigo
        /// </summary>
        /// <returns></returns>
        private string registroOcorrencia(string vetOcorr, string codOcorr)
        {
            string saida = vetOcorr.Trim();
            saida += ((vetOcorr.Trim().Length > 0) ? "," : "") + codOcorr.PadLeft(2, '0');
            return saida;
        }


        private void btnAdicionarOcorr_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxCodOcorrencia.Text))
            {
                MessageBox.Show("Código não informado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
            if (bsOcorrencia.Count == 4)
            {
                MessageBox.Show("É permitido apenas quatro registro de ocorrências.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                tbxCodOcorrencia.Text = string.Empty;
            }
            else if (CheckNewCodInList())
            {
                MessageBox.Show("Códido já existente na lista.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            else if (SingletonFlow.cadastroFlow.ValidaCodVetorOcorrencia(tbxCodOcorrencia.Text.Trim()))
            {
                bsCadastro.EndEdit();
                Cadastro cadastro = (Cadastro)bsCadastro.Current;
                //se o objeto utilizado no momento for cadastro completo atualiza com o objeto cadastro.
                cadastro.VetorOcorrencia = registroOcorrencia(cadastro.VetorOcorrencia, tbxCodOcorrencia.Text);

                loadGrid(cadastro);
                bsCadastro.ResumeBinding();
            }
        }

        private void loadFoto(OperacaoFoto oper)
        {
            if (bsFotos.Count > 0)
            {
                if (oper == OperacaoFoto.Proximo)
                    bsFotos.MoveNext();
                if (oper == OperacaoFoto.Voltar)
                    bsFotos.MovePrevious();

                Foto f = (Foto)bsFotos.Current;
                if (f.codOcorrc != null)
                    lblOcorrencia.Text = "Ocorrência: " + SingletonFlow.ocorrenciaFlow.ListOcorrenciaByVetOcorrencia(f.codOcorrc.ToString())[0].Description;
                else
                    lblOcorrencia.Text = "Ocorrência: ";
                lblLegenda.Text = "Legenda: " + f.descFoto;

                pictureFoto.Image = new Bitmap(ConfigurationSettings.AppSettings["pathImagens"] + ((Foto)bsFotos.Current).nomFoto);
            }
            else
            {
                lblOcorrencia.Text = "Ocorrência: ";
                lblLegenda.Text = "Legenda: ";

                pictureFoto.Image = null;
            }
            lblPagina.Text = (bsFotos.Position + 1).ToString() + " / " + bsFotos.Count.ToString();
        }

        private void btnFotoPosterior_Click(object sender, EventArgs e)
        {
            loadFoto(OperacaoFoto.Proximo);
        }

        private void btnFotoAnterior_Click(object sender, EventArgs e)
        {
            loadFoto(OperacaoFoto.Voltar);
        }

        private Foto IncluirFotoTabela(long idCadastro, string numPontoServico, int? codOcorr, string extensao)
        {
            Foto fotoNew = new Foto();
            int seq = 0;
            fotoNew.idCadast = idCadastro;
            fotoNew.numPontoServc = numPontoServico;
            fotoNew.codOcorrc = codOcorr;
            seq = SingletonFlow.fotoFlow.getNextSequenciafoto(fotoNew);
            fotoNew.sequencia = seq;
            fotoNew.Data = DateTime.Now;

            // Define o nome da foto
            if (fotoNew.codOcorrc.isNullorZero())
            {
                fotoNew.nomFoto = fotoNew.idCadast + "_" + fotoNew.numPontoServc + "_" + seq + ".jpg";
            }
            else
            {
                fotoNew.nomFoto = fotoNew.idCadast + "_" + fotoNew.numPontoServc + "_" + fotoNew.codOcorrc + "_" + seq + ".jpg";
            }
            SingletonFlow.fotoFlow.Insert(fotoNew);
            return fotoNew;
        }

        private void IncluirFoto(int? codOcorr)
        {
            OpenFileDialog openFiledialog = new OpenFileDialog();
            //openFiledialog.Filter = "Image Files|*.jpg;*.gif;*.bmp;*.png;*.jpeg|All Files|*.*";
            openFiledialog.Filter = "Arqruivos de Imagem|*.jpg;*.bmp;*.jpeg|Todos Arquivos|*.*";
            openFiledialog.InitialDirectory = @"C:\";
            openFiledialog.FilterIndex = 1;

            openFiledialog.Title = "Abrir Arquivo";
            if (openFiledialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string fileName = openFiledialog.FileName;
                string pathNameDest = ConfigurationSettings.AppSettings["pathImagens"];
                Cadastro cad = (Cadastro)bsCadastro.Current;
                Foto f = IncluirFotoTabela(cad.Id, cad.NumeroPontoServico, codOcorr, Path.GetExtension(fileName));
                // TODO: Deverá ser implementado com servidor de imagem
                File.Copy(fileName, pathNameDest + f.nomFoto);
                pictureFoto.Image = Image.FromFile(pathNameDest + f.nomFoto);
                loadGrid(cad);
            }
        }

        private void btnAdicionarFoto_Click(object sender, EventArgs e)
        {
            IncluirFoto(null);
        }

        private void btnRemoverFotos_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma exclusão da foto?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                Foto foto = (Foto)bsFotos.Current;
                SingletonFlow.fotoFlow.Delete(foto);
                bsFotos.RemoveCurrent();
                loadGrid((Cadastro)bsCadastro.Current);
            }
        }

        /// <summary>
        ///  Metodo que carrega uma tela para visulaização da imagem ampliada
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            frmVisualizarFoto telaVisualizarFoto = new frmVisualizarFoto(pictureFoto.Image);
            telaVisualizarFoto.ShowDialog();
            return;
        }

        private void btnFotoOcorr_Click(object sender, EventArgs e)
        {
            int codOcorr = ((Ocorrencia)bsOcorrencia.Current).Id;
            IncluirFoto(codOcorr);
        }

        private void dgvOcorrencias_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                // Is this the correct column? (It's actually a DataGridViewImageColumn)
                if (e.ColumnIndex == 3)
                {
                    // Get the row we're formatting
                    DataGridViewRow row = dgvOcorrencias.Rows[e.RowIndex];
                    // Get the enum from the row.
                    bool fotos = ((Ocorrencia)row.DataBoundItem).ExisteFotos;
                    Bitmap cellValueImage = null;

                    cellValueImage = (fotos) ? Resources.Camera15x15 : new Bitmap(15, 15);

                    e.Value = cellValueImage;
                    e.FormattingApplied = true;
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void btnBuscarOcorrencia_Click(object sender, EventArgs e)
        {
            List<ItemCombo> lista = SingletonFlow.ocorrenciaFlow.getListOcorrencia();
            using (frmListAuxPesquisa frm = new frmListAuxPesquisa(lista, "Consulta Ocorrências"))
            {
                frm.ShowDialog();
                tbxCodOcorrencia.Text = ((frm.Item == null) ? "" : frm.Item.Value.ToString());
                if (frm.Item != null)
                    btnAdicionarOcorr_Click(sender, e);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            bsCadastro.EndEdit();
            Cadastro cad = (Cadastro)bsCadastro.Current;
            List<ItemCombo> lista = SingletonFlow.ramoAtividadeFlow.getListRamoAtividade();
            using (frmListAuxPesquisa frm = new frmListAuxPesquisa(lista, "Consulta Atividades"))
            {
                frm.ShowDialog();
                try
                {
                    switch (((PictureBox)sender).Tag.ToString())
                    {
                        case "1": cad.RamoAtividade1Alter = ((frm.Item == null) ? null : (int?)frm.Item.Value);
                            cad.RamoAtivDesc1 = frm.Item.Description.ToString();
                            break;
                        case "2": cad.RamoAtividade2Alter = ((frm.Item == null) ? null : (int?)frm.Item.Value);
                            cad.RamoAtivDesc2 = frm.Item.Description.ToString();
                            break;
                        case "3": cad.RamoAtividade3Alter = ((frm.Item == null) ? null : (int?)frm.Item.Value);
                            cad.RamoAtivDesc3 = frm.Item.Description.ToString();
                            break;
                        case "4": cad.RamoAtividade4Alter = ((frm.Item == null) ? null : (int?)frm.Item.Value);
                            cad.RamoAtivDesc4 = frm.Item.Description.ToString();
                            break;
                    }
                }
                catch (Exception ex)
                {
                }
                finally
                {
                    bsCadastro.ResumeBinding();
                    bsCadastro.ResetItem(0);
                }
            }
        }

        //impede que os campo numericos travem quando estão vazios.
        private void bsCadastro_BindingComplete(object sender, BindingCompleteEventArgs e)
        {
            if (e.ErrorText == "Seqüência não foi reconhecida como DateTime válido." || e.ErrorText == "Seqüência de entrada não estava em um formato incorreto.")
                e.Cancel = false;
        }

        //Força os campos numéricos a não receberem letras, somente números. 
        private void ValidaCampoNumericoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != '\b')//a segunda expressão habilita a funcionalidade do botão backspace do teclado.
            {
                e.Handled = true;
            }
        }

        //impede que seja digitado valores alfanuméricos em campos numéricos.
        private void ValidaCampoData_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != '\b')//a segunda expressão habilita a funcionalidade do botão backspace do teclado.
            {
                e.Handled = true;
            }
        }

        //aplica o formato de data no modelo brasileiro dd/mm/yyyy
        private void tbxDataHoraExec_KeyUp(object sender, KeyEventArgs e)
        {
            tbxDataHoraExec.Text = MaskaraPadrao.MaskData(tbxDataHoraExec.Text);
        }

        //aplica o formato de data no modelo brasileiro dd/mm/yyyy
        private void tbxTerminio_KeyUp(object sender, KeyEventArgs e)
        {
            tbxTerminio.Text = MaskaraPadrao.MaskData(tbxTerminio.Text);
        }

        #region Validações de alteração

        //pinta os campos "alter" em que os dados são diferentes dos campos "originais"
        private void CheckAlterColor(string tag)
        {
            //cor padrão do windows
            Color cor = tbxDataHoraExec.BackColor;
            //cor para campo diferente do original
            Color corAlter = Color.Bisque;

            #region grupo imóvel

            if (tag == "1" || string.IsNullOrEmpty(tag))
            {
                if (tbxNumeroAlter.Text.Trim() != tbxNumero.Text.Trim())
                {
                    tbxNumeroAlter.BackColor = corAlter;
                }
                else
                {
                    tbxNumeroAlter.BackColor = cor;
                }
            }

            if (tag == "2" || string.IsNullOrEmpty(tag))
            {
                string complemento = cboTipoComplemento.Text.Trim() + " " + tbxComplementoAlter.Text.Trim();
                if (tbxComplemento.Text.Trim() != complemento.Trim())
                {
                    tbxComplementoAlter.BackColor = corAlter;
                    cboTipoComplemento.BackColor = corAlter;
                }
                else
                {
                    tbxComplementoAlter.BackColor = cor;
                    cboTipoComplemento.BackColor = cor;
                }
            }

            if (tag == "3" || string.IsNullOrEmpty(tag))
            {
                if (cboCondicaoAlter.Text.Trim() != tbxCondicao.Text.Trim())
                {
                    cboCondicaoAlter.BackColor = corAlter;
                }
                else
                {
                    cboCondicaoAlter.BackColor = cor;
                }
            }
            #endregion

            #region grupo caracteristicas
            if (tag == "4" || string.IsNullOrEmpty(tag))
            {
                if (cboFonteAlternativaAlter.Text.Trim() != tbxFonteAlternativa.Text.Trim())
                {
                    cboFonteAlternativaAlter.BackColor = corAlter;
                }
                else
                {
                    cboFonteAlternativaAlter.BackColor = cor;
                }
            }

            if (tag == "5" || string.IsNullOrEmpty(tag))
            {
                if (cboPscinaAlter.Text.Trim() != tbxPscina.Text.Trim())
                {
                    cboPscinaAlter.BackColor = corAlter;
                }
                else
                {
                    cboPscinaAlter.BackColor = cor;
                }
            }

            if (tag == "6" || string.IsNullOrEmpty(tag))
            {
                if (cboReservatorioAlter.Text.Trim() != tbxReservatorio.Text.Trim())
                {
                    cboReservatorioAlter.BackColor = corAlter;
                }
                else
                {
                    cboReservatorioAlter.BackColor = cor;
                }
            }

            if (tag == "7" || string.IsNullOrEmpty(tag))
            {
                if (cboSituacaoAlter.Text.Trim() != tbxSituacao.Text.Trim())
                {
                    cboSituacaoAlter.BackColor = corAlter;
                }
                else
                {
                    cboSituacaoAlter.BackColor = cor;
                }
            }
            #endregion

            #region grupo economias
            if (tag == "8" || string.IsNullOrEmpty(tag))
            {
                if (tbxResidencialAlter.Text.Trim() != tbxResidencial.Text.Trim())
                {
                    tbxResidencialAlter.BackColor = corAlter;
                }
                else
                {
                    tbxResidencialAlter.BackColor = cor;
                }
            }

            if (tag == "9" || string.IsNullOrEmpty(tag))
            {
                if (tbxComercialAlter.Text.Trim() != tbxComercial.Text.Trim())
                {
                    tbxComercialAlter.BackColor = corAlter;
                }
                else
                {
                    tbxComercialAlter.BackColor = cor;
                }
            }

            if (tag == "10" || string.IsNullOrEmpty(tag))
            {
                if (tbxIndustrialAlter.Text.Trim() != tbxIndustrial.Text.Trim())
                {
                    tbxIndustrialAlter.BackColor = corAlter;
                }
                else
                {
                    tbxIndustrialAlter.BackColor = cor;
                }
            }

            if (tag == "11" || string.IsNullOrEmpty(tag))
            {
                if (tbxPublicaAlter.Text.Trim() != tbxPublica.Text.Trim())
                {
                    tbxPublicaAlter.BackColor = corAlter;
                }
                else
                {
                    tbxPublicaAlter.BackColor = cor;
                }
            }

            if (tag == "12" || string.IsNullOrEmpty(tag))
            {
                if (tbxRamoAtiv1Alter.Text.Trim() != tbxRamoAtiv1.Text.Trim())
                {
                    tbxRamoAtiv1Alter.BackColor = corAlter;
                }
                else
                {
                    tbxRamoAtiv1Alter.BackColor = cor;
                }
            }

            if (tag == "13" || string.IsNullOrEmpty(tag))
            {
                if (tbxRamoAtiv2Alter.Text.Trim() != tbxRamoAtiv2.Text.Trim())
                {
                    tbxRamoAtiv2Alter.BackColor = corAlter;
                }
                else
                {
                    tbxRamoAtiv2Alter.BackColor = cor;
                }
            }

            if (tag == "14" || string.IsNullOrEmpty(tag))
            {
                if (tbxRamoAtiv3Alter.Text.Trim() != tbxRamoAtiv3.Text.Trim())
                {
                    tbxRamoAtiv3Alter.BackColor = corAlter;
                }
                else
                {
                    tbxRamoAtiv3Alter.BackColor = cor;
                }
            }

            if (tag == "15" || string.IsNullOrEmpty(tag))
            {
                if (tbxRamoAtiv4Alter.Text.Trim() != tbxRamoAtiv4.Text.Trim())
                {
                    tbxRamoAtiv4Alter.BackColor = corAlter;
                }
                else
                {
                    tbxRamoAtiv4Alter.BackColor = cor;
                }
            }
            #endregion

            #region grupo padrão
            if (tag == "16" || string.IsNullOrEmpty(tag))
            {
                if (cboSituacaoPSAlter.Text.Trim() != tbxSituacaoPS.Text.Trim())
                {
                    cboSituacaoPSAlter.BackColor = corAlter;
                }
                else
                {
                    cboSituacaoPSAlter.BackColor = cor;
                }
            }

            if (tag == "17" || string.IsNullOrEmpty(tag))
            {
                if (cboLocalPadraoAlter.Text.Trim() != tbxLocalPadrao.Text.Trim())
                {
                    cboLocalPadraoAlter.BackColor = corAlter;
                }
                else
                {
                    cboLocalPadraoAlter.BackColor = cor;
                }
            }

            if (tag == "18" || string.IsNullOrEmpty(tag))
            {
                if (cboTipoPadraoAlter.Text.Trim() != tbxTipoPadrao.Text.Trim())
                {
                    cboTipoPadraoAlter.BackColor = corAlter;
                }
                else
                {
                    cboTipoPadraoAlter.BackColor = cor;
                }
            }

            #endregion

            #region grupo medidor
            if (tag == "19" || string.IsNullOrEmpty(tag))
            {
                if (tbxNumMedidorAlter.Text.Trim().Length > 0)
                {
                    tbxNumMedidorAlter.Text = tbxNumMedidorAlter.Text.ToUpper();
                }

                if (tbxNumMedidorAlter.Text.Trim() != tbxNumMedidor.Text.Trim())
                {
                    tbxNumMedidorAlter.BackColor = corAlter;
                }
                else
                {
                    tbxNumMedidorAlter.BackColor = cor;
                }
            }

            if (tag == "20" || string.IsNullOrEmpty(tag))
            {
                if (tbxQtDigitosAlter.Text.Trim() != tbxQtDigitos.Text.Trim())
                {
                    tbxQtDigitosAlter.BackColor = corAlter;
                }
                else
                {
                    tbxQtDigitosAlter.BackColor = cor;
                }
            }

            if (tag == "21" || string.IsNullOrEmpty(tag))
            {
                if (cboClasseMetroAlter.Text.Trim() != tbxClasseMetro.Text.Trim())
                {
                    cboClasseMetroAlter.BackColor = corAlter;
                }
                else
                {
                    cboClasseMetroAlter.BackColor = cor;
                }
            }

            #endregion
        }

        #endregion

        //método geral para validar os campos originais e alterados.
        private void CheckAlteracaoValidate(object sender, CancelEventArgs e)
        {
            //identifica se o tipo de controle é texbox ou combobox.
            if (sender is TextBox)
            {
                CheckAlterColor(((TextBox)sender).Tag.ToString());
            }
            else if (sender is ComboBox)
            {
                CheckAlterColor(((ComboBox)sender).Tag.ToString());
            }
        }

        //realiza a verificação geral dos campos alterados e originais
        private void frmCadastro_Load(object sender, EventArgs e)
        {
            CheckAlterColor(null);
        }

        /// <summary>
        ///  Evento onClick do botão editar
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void btnEditar_Click(object sender, EventArgs e)
        {
            habilitar();
        }

        /// <summary>
        ///  Metodo que habilita campos da tela para edição
        ///  <regra>
        ///     - Habilita a tela atrasves dos panels
        ///     - Desabilita botoes proximo e anterior e salver
        ///     - Desabilita botão editar
        /// </regra>
        /// </summary>
        public void habilitar()
        {
            // Habilita o botão de salvar
            btnConfirmar.Enabled = true;
            btnConfirmar.Visible = true;

            // Desabilita o botão proximo e anterior
            btnAnterior.Enabled = false;
            btnAnterior.Visible = false;
            btnProximo.Visible = false;
            btnProximo.Enabled = false;

            // habilita os dados para edição (logica habilita os panel da tela)
            collapsableGroupBox1.Enabled = true;
            collapsableGroupBox2.Enabled = true;
            collapsableGroupBox3.Enabled = true;
            collapsableGroupBox4.Enabled = true;
            collapsableGroupBox5.Enabled = true;
            collapsableGroupBox6.Enabled = true;
            collapsableGroupBox7.Enabled = true;
            collapsableGroupBox8.Enabled = true;
            collapsableGroupBox9.Enabled = true;
            collapsableGroupBox10.Enabled = true;
        }

        /// <summary>
        ///  Metodo que desabilita campos da tela para navegação
        /// </summary>
        public void desabilitar()
        {
            // Desabilita o botão de salvar
            btnConfirmar.Enabled = false;
            btnConfirmar.Visible = false;

            // Habilita o botão proximo e anterior
            btnAnterior.Enabled = true;
            btnAnterior.Visible = true;
            btnProximo.Visible = true;
            btnProximo.Enabled = true;

            // Desabilita os dados para edição (logica habilita os panel da tela)
            collapsableGroupBox1.Enabled = false;
            collapsableGroupBox2.Enabled = false;
            collapsableGroupBox3.Enabled = false;
            collapsableGroupBox4.Enabled = false;
            collapsableGroupBox5.Enabled = false;
            collapsableGroupBox6.Enabled = false;
            collapsableGroupBox7.Enabled = false;
            collapsableGroupBox8.Enabled = false;
            collapsableGroupBox9.Enabled = false;
            collapsableGroupBox10.Enabled = false;
        }
    }
}

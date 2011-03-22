using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SPCadMobile.View.AuxiliarClass;
using SPCadMobileData.Data.Model;
using CommonHelpMobile;
using SPCadMobileData.Data;

namespace SPCadMobile.View
{
    public partial class FrmListFoto : Form
    {
        // Ids utilizadados para captura de imagens.
        Foto foto { get; set; }
        public string recentFotos { get; set; }

        // A interface frmImpedimentoExecucao consulta este campo para se informar se houve fotos, 
        //pois é obrigatório ao menos uma foto.
        public int qtdFoto { get; set; }

        /// <summary>
        /// construtor inicializa ids(resposta tecnico, inspeção) para registro da foto.
        /// </summary>
        /// <param name="idRespostaTecnico"></param>
        /// <param name="idInspecao"></param>
        public FrmListFoto(Foto foto)
        {            
            InitializeComponent();
            

            this.foto = foto;

            CarregaFoto();

            qtdFoto = bindingSourceFotos.Count;
        }

        /// <summary>
        /// Exibe a foto capturada
        /// </summary>
        private void CarregaFoto()
        {
            if (foto.codOcorrc.isNullorZero())
            { 
                bindingSourceFotos.DataSource = SingletonFlow.fotoFlow.getListFotoByParam(foto.idCadast, foto.numPontoServc); 
            }
            else
            {
                bindingSourceFotos.DataSource = SingletonFlow.fotoFlow.getListFotoByParam(foto.idCadast, foto.numPontoServc, foto.codOcorrc); //recupera fotos por ocorrência.
            }

            if (bindingSourceFotos.Count > 0)
            {
                try
                {
                    if (System.IO.File.Exists(InfoFiles.GetPathFoto() + ((Foto)bindingSourceFotos.Current).nomFoto))
                    {
                        picBoxFoto.Visible = true;
                        picBoxFoto.Image = new Bitmap(InfoFiles.GetPathFoto() + ((Foto)bindingSourceFotos.Current).nomFoto);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Foto não encontrada! \nErro: " + ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
            }
            else
            {
                picBoxFoto.Visible = false;
            }
        }

        /// <summary>
        /// Aciona camera para captura de imagem.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNovaFoto_Click(object sender, EventArgs e)
        {
            try
            {
                // Captura a imagem e cria uma foto.
                CommonHelpMobile.TaskBarHelper.Show();
                Foto fotoNew = ShootingFoto.CapturaFoto(foto);
                CommonHelpMobile.TaskBarHelper.Hide();

                // Verifica se a foto foi tirada
                if (!(fotoNew == null))
                {
                    using (FrmExibeFoto captureFoto = new FrmExibeFoto(fotoNew))
                    {
                       
                        captureFoto.ShowDialog();
                        
                        if (captureFoto.DialogResult == DialogResult.OK)
                        {
                            bindingSourceFotos.EndEdit();
                            bindingSourceFotos.Add(fotoNew);
                            bindingSourceFotos.ResumeBinding();
                            bindingSourceFotos.ResetBindings(true);
                            CarregaFoto();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro");
            }
        }

        /// <summary>
        /// Carrega a foto da linha selecionada.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGrid1_Click(object sender, EventArgs e)
        {
            if (bindingSourceFotos.Count > 0)
            {
                CarregaFoto();
            }
        }

        /// <summary>
        /// Fecha a tela
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void voltarMenuItem_Click(object sender, EventArgs e)
        {
            qtdFoto = bindingSourceFotos.Count;            
            this.Close();
        }

        /// <summary>
        /// Edita a legenda da foto.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editarMenuItem_Click(object sender, EventArgs e)
        {
            bindingSourceFotos.EndEdit();
            if (bindingSourceFotos.Count > 0)
            {
                using (FrmExibeFoto editaFoto = new FrmExibeFoto((Foto)bindingSourceFotos.Current))
                {
                    editaFoto.ShowDialog();
                }

                bindingSourceFotos.ResetCurrentItem();
                bindingSourceFotos.ResumeBinding();
            }
            else
            {
                MessageBox.Show("É necessário selecionar uma foto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        ///  Exclui a foto corrente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExcluirFoto_Click(object sender, EventArgs e)
        {
            if (bindingSourceFotos.Count > 0)
            {

                try
                {
                    bindingSourceFotos.EndEdit();
                    if (MessageBox.Show("Deseja apagar esta foto?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        Foto delFoto = (Foto)bindingSourceFotos.Current;                                                

                        SingletonFlow.fotoFlow.Delete(delFoto);
                        bindingSourceFotos.RemoveCurrent();
                        bindingSourceFotos.MoveNext();
                        bindingSourceFotos.ResumeBinding();
                        CarregaFoto();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1); ;
                }
            }
            else
            {
                MessageBox.Show("É necessário selecionar uma foto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }

        }
    }
}
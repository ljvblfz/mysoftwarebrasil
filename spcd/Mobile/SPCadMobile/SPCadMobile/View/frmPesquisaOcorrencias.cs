using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CommonHelpMobile;
using SPCadMobileData.Data;
using SPCadMobileData.Data.Model;

namespace SPCadMobile.View
{
    public partial class frmPesquisaOcorrencias : CustomForm
    {
        public Ocorrencia ocorrenciaSelected { get; set; } 

        //denominação / Atividade Econômica
        public string descricaoOcorrencia = null;
        public long idOcorrencia = 0;

        /// <summary>
        /// Contrutor da tela de pesquisa e selecão de atividade.
        /// </summary>
        public frmPesquisaOcorrencias()
        {
            InitializeComponent();            
        }

        /// <summary>
        /// Executa a pesquisa com base nos parametros digitados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lupaBox_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (string.IsNullOrEmpty(tbxDescricaoPesquisa.Text))
                {
                    MessageBox.Show("Campo de pesquisa vazio", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    try
                    {
                        bindingSourceOcorrencia.DataSource = SingletonFlow.ocorrenciaFlow.getOcorrenciaByParam(tbxDescricaoPesquisa.Text);

                        if (bindingSourceOcorrencia.Count == 0)
                        {
                            MessageBox.Show("Nenhum item foi encontrado com o parâmetro informado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);                            
                        }
                    }
                    catch (Exception ex)
                    {
                        bindingSourceOcorrencia.Clear();
                        MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    }
                }
                                
            }
            catch(Exception){}
            finally
            {
                Cursor.Current=Cursors.Default;
            }
            
        } 

        /// <summary>
        /// Seleciona uma atividade em uma lista
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void selecionarMenuItem_Click(object sender, EventArgs e)
        {
            if (bindingSourceOcorrencia.Count == 0)
            {
                MessageBox.Show("Nenhum item foi selecionado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
            bindingSourceOcorrencia.EndEdit();
            ocorrenciaSelected = (Ocorrencia)bindingSourceOcorrencia.Current;            
            this.Close();
        }

        //Fecha tela
        private void cancelarMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void TecladoinputPanel_EnabledChanged_1(object sender, EventArgs e)
        {            
        }
    }
}
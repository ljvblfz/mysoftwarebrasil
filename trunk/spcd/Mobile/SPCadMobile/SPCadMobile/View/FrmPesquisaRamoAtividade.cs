using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SPCadMobileData.Data;
using SPCadMobileData.Data.Model;

namespace SPCadMobile.View
{
    public partial class FrmPesquisaRamoAtividade : Form
    {
        public RamoAtividade ramoAtividadeSelecionada { get; set; } 

        //denominação / Atividade Econômica
        public string descricaoAtividade = null;
        public long idAtividade = 0;

        /// <summary>
        /// Contrutor da tela de pesquisa e selecão de atividade.
        /// </summary>
        public FrmPesquisaRamoAtividade()
        {
            InitializeComponent();
            CarregaTipoPesquisa();
        }

        private void CarregaTipoPesquisa()
        {
            cbxTipoAtividade.DataSource = TipoAtividades.GetList();
        }

        /// <summary>
        /// Executa a pesquisa com base nos parametros digitados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lupaPictureBox_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (string.IsNullOrEmpty(TbxdescricaoBusca.Text) && cbxTipoAtividade.SelectedValue.ToString() != "T")
                {
                    MessageBox.Show("Campo de pesquisa vazio", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    try
                    {                        
                        bindingSourceRamoAtividade.DataSource = SingletonFlow.ramoAtividadeFlow.getRamoAtivByTipo(TbxdescricaoBusca.Text, cbxTipoAtividade.SelectedValue.ToString());

                        if (bindingSourceRamoAtividade.Count == 0)
                        {
                            MessageBox.Show("Nenhum item foi encontrado com o parâmetro informado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);                            
                        }
                    }
                    catch (Exception ex)
                    {
                        bindingSourceRamoAtividade.Clear();
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
            if (bindingSourceRamoAtividade.Count == 0)
            {
                MessageBox.Show("Nenhum item foi selecionado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
            bindingSourceRamoAtividade.EndEdit();                        
            ramoAtividadeSelecionada = (RamoAtividade)bindingSourceRamoAtividade.Current;            
            this.Close();
        }

        //Fecha tela
        private void cancelarMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }                                 
    }
}
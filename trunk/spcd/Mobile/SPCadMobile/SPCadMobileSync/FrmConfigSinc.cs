using System;
using Microsoft.Win32;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CommonHelpMobile;

namespace SPCadMobileSync
{
    public partial class FrmConfigSinc : Form
    {
        //Objeto para configuração do webservice
        ConfigWebService configWebService = new ConfigWebService();

        public FrmConfigSinc()
        {
            InitializeComponent();
            LoadTela();           
        }

        /// <summary>
        /// Carrega a tela com os valores recuperados das chaves no registro.
        /// </summary>
        private void CarregaTela()
        {
            try
            {
                tbxWebService.Text = configWebService.WebServiceCurrent;
                tbxUsuario.Text = configWebService.LoginWebService;
                tbxSenha.Text = configWebService.SenhaWebService;
                tbxTmeOut.Text = configWebService.TimeOutWebService;
                lblDevice.Text = configWebService.SerialDevice;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao acessar propriedades de configuração:" + ex.Message);
            }
        }

        private void LoadTela()
        {
            try
            {
                configWebService.CreateKey();
                configWebService.SetConfigAtual();
                CarregaTela();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }
        }        

        /// <summary>
        /// configura o webservice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mItemConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                //envia dados de configuração do webservice para as chaves do registro local. 
                configWebService.SetWebService(tbxWebService.Text.Trim(), tbxUsuario.Text.Trim(), tbxSenha.Text.Trim(), tbxTmeOut.Text.Trim());

                //recebe os dados de configuração atual.
                configWebService.SetConfigAtual();
                CarregaTela();

                MessageBox.Show("Configuração realizada!", "Configuração webService");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }              
        }

        /// <summary>
        /// Sair da tela
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mItemVoltar_Click(object sender, EventArgs e)
        {            
            this.Close();
        }

        private void tbxTmeOut_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < tbxTmeOut.Text.Length; i++)
            {
                if ("0123456789".IndexOf(tbxTmeOut.Text[i]) < 0)
                {
                    tbxTmeOut.Text = tbxTmeOut.Text.Remove(i, 1);
                }
            }
        }
    }
}
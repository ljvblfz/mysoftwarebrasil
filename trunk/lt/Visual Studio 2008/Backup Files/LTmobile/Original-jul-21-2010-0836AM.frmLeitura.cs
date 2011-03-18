using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LTmobileData.Data.BFL;
using LTmobile.View;
using LTmobileData.Data.Model;

namespace LTmobile.View
{
    public partial class frmLeitura : Form
    {
        /// <summary>
        /// Uc atual
        /// </summary>
        Leitura UC_Atual;

        /// <summary>
        /// Leitura atual
        /// </summary>
        string strLeituraAtual;

        public frmLeitura(Leitura UC)
        {
            InitializeComponent();

            //exibe dados da UC selecionada           
            txbEndereco.Text = UC.ENDER_UC + " " + UC.COMPL_ENDER;
            txbMedidorUc.Text = UC.TIPO_MEDIC + "-" + UC.NUM_MEDIDR;
            txbUc.Text = UC.NUM_UC.ToString();

            UC_Atual = UC;

            
            

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (txbLeitura.Text == "")
            {
                MessageBox.Show("Leitura deve ser informada.", "Execução Leitura", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            else if (!ValidaPadraoLeitura())
            {
                if (strLeituraAtual != txbLeitura.Text)
                {
                    MessageBox.Show("Leitura fora do padrão. Redigite a leitura", "Execução de Leitura", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    strLeituraAtual = txbLeitura.Text;
                    txbLeitura.Text = "";

                }
                else
                {
                    ExecutarLeitura();
                }
            }
            else
            {
                ExecutarLeitura();                
            }
            
        }

        public void ExecutarLeitura()
        {
            try
            {
                UC_Atual.DATA_VISITA = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"));

                UC_Atual.HORA_VISITA = DateTime.Now.ToString("HHmmss");
                UC_Atual.LEITUR_VISITA = int.Parse(txbLeitura.Text);
                UC_Atual.ESTADO_SERVC = 1;
                UC_Atual.DATA_ATLZ = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"));
                UC_Atual.HORA_ATLZ = DateTime.Now.ToString("HHmmss");
                UC_Atual.MATRIC_FUNC = UsuarioFlow.UsuarioCurrent.MATRIC_FUNC;
                UC_Atual.USUAR_ATLZ = UsuarioFlow.UsuarioCurrent.NOME_FUNC;
                UC_Atual.DATA_CALENDARIO = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"));

                LeituraFlow.Update(UC_Atual);

                if (txbObservacao.Text != "")
                {
                    mensagemUc mensagem = new mensagemUc();
                    mensagem.ID_MSG = MensagemUcFlow.getIdMensagem();
                    mensagem.COD_EMPRT = UC_Atual.COD_EMPRT;
                    mensagem.COD_LOCAL = UC_Atual.COD_LOCAL;
                    mensagem.MES_ANO_FATUR = UC_Atual.MES_ANO_FATUR;
                    mensagem.NUM_RAZAO = UC_Atual.NUM_RAZAO;
                    mensagem.NUM_UC = UC_Atual.NUM_UC;
                    mensagem.DESC_MSG = txbObservacao.Text;
                    mensagem.FLAG_SENTIDO = "C";
                    mensagem.DT_MSG = DateTime.Now;
                    mensagem.STATUS_REG = "2";
                    MensagemUcFlow.Insert(mensagem);

                }

                MessageBox.Show("Leitura salva com sucesso.", "Execução de Leitura", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                /*using (frmRotaLeitura rotaLeitura = new frmRotaLeitura())
                {
                    this.Close();
                    rotaLeitura.ShowDialog();
                }*/
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível salvar leitura. Ex "+ex+"", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }


        private void frmLeitura_Load(object sender, EventArgs e)
        {
            txbLeitura.Focus();
        }

        private void frmLeitura_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == System.Windows.Forms.Keys.Up))
            {
                // Up
                txbObservacao.Focus();
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Down))
            {
                // Down
                txbLeitura.Focus();
            }
                       
        }

        /// <summary>
        /// Valida se leitura está fora dos padões
        /// </summary>
        /// <returns></returns>
        public bool ValidaPadraoLeitura()
        {
            if (txbLeitura.Text != "")
            {
                if ((int.Parse(txbLeitura.Text) > UC_Atual.LEITUR_MAX) || (int.Parse(txbLeitura.Text) < UC_Atual.LEITUR_MIN))
                {
                    return false;
                }
                else
                {
                    return true;

                }
            }
            else
            {
                return false;
            }
        }

        private void txbLeitura_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Permite digitar apenas números
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != '\b')//a segunda expressão habilita a funcionalidade do botão backspace do teclado.
            {
                e.Handled = true;
            }
        }

        private void mnFotos_Click(object sender, EventArgs e)
        {
            using (frmCapturarFoto capturarFoto = new frmCapturarFoto(UC_Atual))
            {
                capturarFoto.ShowDialog();
            }
        }

        private void mnOcorrencia_Click(object sender, EventArgs e)
        {
            using (frmOcorrenciaUc ocorrenciaUc = new frmOcorrenciaUc(UC_Atual))
            {
                ocorrenciaUc.ShowDialog();
            }
        }

        private void mnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
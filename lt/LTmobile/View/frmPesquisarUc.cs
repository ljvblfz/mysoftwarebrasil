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
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace LTmobile.View
{
    public partial class frmPesquisarUc : Form
    {
        [DllImport("coredll.dll", EntryPoint = "SetForegroundWindow")]
        private static extern int SetForegroundWindow(IntPtr hWnd);

        int indiceUc = 0;
        BindingSource bindSource;
        int posOriginalBs;

        /// <summary>
        /// Lista de UC
        /// </summary>
        List<Leitura> lstUc;

        string strPesquisar;

        public Leitura UcSelecionada { get; set; }

        public frmPesquisarUc(BindingSource bs)
        {
            bindSource = bs;
            posOriginalBs = bindSource.Position;
            InitializeComponent();
            lblPesquisar.Text = "Medidor:";
            txbPesquisa.MaxLength = 10;
            btnPesquisar.Text = "Pesquisar";
        }

        private void frmPesquisarUc_Load(object sender, EventArgs e)
        {
            txbPesquisa.Focus();
        }

        /// <summary>
        /// Recupera o indice damensagem
        /// </summary>
        /// <returns></returns>
        private string Indice()
        {
            return (bsPesquisar.Position + 1) + "/" + (bsPesquisar.Count);
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            List<Leitura> lstLeitura = (List<Leitura>)bindSource.DataSource;

            
            if (txbPesquisa.Text != "")
            {
                btnPesquisar.Text = "Próximo";
                if (strPesquisar != txbPesquisa.Text)
                {
                    strPesquisar = txbPesquisa.Text;

                    if (cbMedidor.Checked)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        // LeituraFlow.getRotaLeituraFiltroMedidor
                        //lstUc = LeituraFlow.getRotaLeituraFiltroMedidor(txbPesquisa.Text);
                        bsPesquisar.DataSource = lstLeitura.Where(l => l.NUM_MEDIDR.LastIndexOf(txbPesquisa.Text) >= 0).ToList();
                        Cursor.Current = Cursors.Default;
                    }
                    else
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        //lstUc = LeituraFlow.getRotaLeituraFiltroUc(txbPesquisa.Text);
                        bsPesquisar.DataSource = lstLeitura.Where(l => l.NUM_UC.ToString().LastIndexOf(txbPesquisa.Text) >= 0).ToList();
                        Cursor.Current = Cursors.Default;
                    }
                    lblIndice.Text = Indice();
                }
                else
                {

                    //Verifica se é o ultimo registro
                    if ((bsPesquisar.Position + 1) == bsPesquisar.Count)
                    {
                        //Retorna para o primeiro registro
                        bsPesquisar.MoveFirst();
                        lblIndice.Text = Indice();
                    }
                    else
                    {
                        //Vai para proximo registro
                        bsPesquisar.MoveNext();
                        lblIndice.Text = Indice();
                    }
                }
                /*int qtdUc = lstUc.Count;

                if (indiceUc == qtdUc)
                {
                    indiceUc = 0;
                }

                if (lstUc[indiceUc] != null)
                {*/
                  /*  txbEndereco.Text = lstUc[indiceUc].ENDER_UC + " " + lstUc[indiceUc].COMPL_ENDER;
                    txbMedidor.Text = lstUc[indiceUc].TIPO_MEDIC + "-" + lstUc[indiceUc].NUM_MEDIDR;
                    txbUc.Text = lstUc[indiceUc].NUM_UC.ToString();
                    lblIndice.Text = indiceUc + 1 + "/" + qtdUc;*/

               /* }

                indiceUc++;*/
            }
            else
            {
                MessageBox.Show("Campo de pesquisa deve ser informado.", "Pesquisar", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }

           /* if (txbPesquisa.Text != "")
            {
                btnPesquisar.Text = "Próximo";
                if (strPesquisar != txbPesquisa.Text)
                {
                    strPesquisar = txbPesquisa.Text;

                    if (cbMedidor.Checked)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        // LeituraFlow.getRotaLeituraFiltroMedidor
                        lstUc = LeituraFlow.getRotaLeituraFiltroMedidor(txbPesquisa.Text);
                        Cursor.Current = Cursors.Default;
                        


                    }
                    else
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        lstUc = LeituraFlow.getRotaLeituraFiltroUc(txbPesquisa.Text);
                        Cursor.Current = Cursors.Default;
                    }                    

                }

                int qtdUc = lstUc.Count;

                if (indiceUc == qtdUc)
                {
                    indiceUc = 0;
                }

                if (lstUc[indiceUc] != null)
                {
                    txbEndereco.Text = lstUc[indiceUc].ENDER_UC + " " + lstUc[indiceUc].COMPL_ENDER;
                    txbMedidor.Text = lstUc[indiceUc].TIPO_MEDIC + "-" + lstUc[indiceUc].NUM_MEDIDR;
                    txbUc.Text = lstUc[indiceUc].NUM_UC.ToString();
                    lblIndice.Text = indiceUc + 1 + "/" + qtdUc;
                }

                indiceUc++;
            }
            else
            {
                MessageBox.Show(""+lblPesquisar.Text+" deve ser informado.", "Pesquisar", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }*/
        }

        private void mnSelecionar_Click(object sender, EventArgs e)
        {

            //int a = bindSource.Find("NUM_MEDIDR", "168307");

            UcSelecionada = (Leitura)bsPesquisar.Current;

            this.Close();


        }

       /* private void txbPesquisa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cbUc.Checked)
            {
                //Permite digitar apenas números
                if (!char.IsNumber(e.KeyChar) && e.KeyChar != '\b')//a segunda expressão habilita a funcionalidade do botão backspace do teclado.
                {
                    e.Handled = true;
                }
            }
        }*/

        private void TextBox_KeyPressInvertido(object sender, KeyPressEventArgs e)
        {

        }

        private void cbMedidor_Click(object sender, EventArgs e)
        {

                cbUc.Checked = false;
                lblPesquisar.Text = "Medidor:";
                txbPesquisa.MaxLength = 10;
       

            LimpaCampos();
        }



        private void cbUc_Click(object sender, EventArgs e)
        {
      
                cbMedidor.Checked = false;
                lblPesquisar.Text = "Uc:";
                txbPesquisa.MaxLength = 8;
  

            LimpaCampos();
        }

        private void mnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txbPesquisa_TextChanged(object sender, EventArgs e)
        {
            LimpaCampos();
        }

        private void LimpaCampos()
        {
            txbEndereco.Text = "";
            txbMedidor.Text = "";
            txbUc.Text = "";
            lblIndice.Text = "";
            indiceUc = 0;
            btnPesquisar.Text = "Pesquisar";
        }

        private void frmPesquisarUc_KeyDown(object sender, KeyEventArgs e)
        {
            
            if ((e.KeyCode == System.Windows.Forms.Keys.Up))
            {
                // Up
                txbPesquisa.Focus();
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Down))
            {
                // Down
                txbPesquisa.Focus();
            }
            

        }

        private void frmPesquisarUc_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 115 || e.KeyValue == 114)
            {
                Thread.Sleep(1000);
                Process P = Process.GetProcessById(Process.GetCurrentProcess().Id);
                SetForegroundWindow(P.MainWindowHandle);
            }
        }
    }
}
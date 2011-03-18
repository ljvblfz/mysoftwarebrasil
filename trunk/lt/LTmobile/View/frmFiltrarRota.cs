using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LTmobileData.Data.BFL;
using LTmobileData.Data.Model;
using LTmobile.View;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace LTmobile.View
{
    public partial class frmFiltrarRota : Form
    {
        [DllImport("coredll.dll", EntryPoint = "SetForegroundWindow")]
        private static extern int SetForegroundWindow(IntPtr hWnd); 

        #region Variáveis
        /// <summary>
        /// Usuário corrente
        /// </summary>
        int usuario = UsuarioFlow.UsuarioCurrent.MATRIC_FUNC;

        #endregion       

        #region Contrutor
        public frmFiltrarRota()
        {
            InitializeComponent();          
            
//            string webService
            
            //limpa a comboBox
            cmbServico.Items.Clear();
            cmbRota.Items.Clear();
            cmbRazao.Items.Clear();

            //Lista de razão
            List<int> lstServico = new List<int>();

            Cursor.Current = Cursors.WaitCursor;

            bool boTodos = false;

           /* voltar igor if (LeituraFlow.getQtdeRepasse() > 0)
            {
                cmbServico.Items.Add("Repasse");
                boTodos = true;
            }*/

            if (LeituraFlow.getQtdNExecutados() > 0)
            {
                cmbServico.Items.Add("Não Executados");
                boTodos = true;
            }

            if (LeituraFlow.getQtdPriExecucao() > 0)
            {
                cmbServico.Items.Add("Primeira Execução");
                boTodos = true;
            }

            if (boTodos) { 
                //voltar igor cmbServico.Items.Add("Todos");
                
                cmbServico.SelectedIndex = 0;
                cmbServico.Focus();
            }
            Cursor.Current = Cursors.Default;
                        
            

            /* //limpa a comboBox
            cmbRazao.Items.Clear();

            //Lista de razão
            List<int> lstRazao = new List<int>();

            Cursor.Current = Cursors.WaitCursor;

            //Atribui todas no comboBox
          //  cmbRazao.Items.Add("Todas");
            //Carrega a lista com as razões
            lstRazao.AddRange(LeituraFlow.getRazao(usuario));

            if (lstRazao.Count > 0)
            {
                //Carrega o comboBox de razão
                foreach (int item in lstRazao)
                {
                    cmbRazao.Items.Add(item);
                }
                cmbRazao.SelectedIndex = 0;
            }
            Cursor.Current = Cursors.Default;
            cmbRazao.Focus();*/
        }
        #endregion

        #region Eventos

        private void cmbRazao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbServico.Text))
            {

                //           cmbRota.SelectedIndex = 0;
                cmbRota.Items.Clear();

                //Lista de rota
                List<string> lstRota = new List<string>();

                Cursor.Current = Cursors.WaitCursor;

                //Adiciona todas a lista
                // cmbRota.Items.Add("Todas");

                lstRota.AddRange(LeituraFlow.getRota(cmbRazao.Text, usuario, cmbServico.Text));

                if (lstRota.Count > 0)
                {
                    //Carrega lista
                    foreach (string item in lstRota)
                    {
                        cmbRota.Items.Add(item);
                    }
                    cmbRota.SelectedIndex = 0;
                }
                Cursor.Current = Cursors.Default;
            }

        }

        private void frmFiltrarRota_KeyDown(object sender, KeyEventArgs e)
        {
            
            if ((e.KeyCode == System.Windows.Forms.Keys.Up))
            {
                // Up
                cmbRota.Focus();
            }        

            if ((e.KeyCode == System.Windows.Forms.Keys.Down))
            {
                // Down
                cmbServico.Focus();
            }                    
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            //Verifica se razão e rota estão vazio
            if (string.IsNullOrEmpty(cmbServico.Text))
            {
                MessageBox.Show("Serviço deve ser informada.", "Filtrar Rota", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
            else if (string.IsNullOrEmpty(cmbRazao.Text))
            {
                MessageBox.Show("Etapa deve ser informada.", "Filtrar Rota", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
            else if (string.IsNullOrEmpty(cmbRota.Text))
            {
                MessageBox.Show("Rota/Livro deve ser informado.", "Filtrar Rota", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
            else
            {
                LeituraFlow.setFiltro(cmbRazao.Text, cmbRota.Text,cmbServico.Text);

                Thread trd = new Thread(new ThreadStart(ThreadSync));

                trd.IsBackground = true;
                trd.Start();
                

                //Abre tela Rota leitura
                /*using(frmRotaLeitura RotaLeitura = new frmRotaLeitura())
                {
                    RotaLeitura.ShowDialog();
                }*/
                using (frmRotaLeituraIndividual RotaLeituraInd = new frmRotaLeituraIndividual())
                {
                    RotaLeituraInd.ShowDialog();
                }
            }
        }

        /// <summary>
        /// Verifica se está conectado com a internet
        /// </summary>
        /// <returns></returns>
        public static bool estaConectado()
        {
            try
            {                
                System.Net.IPHostEntry obj = System.Net.Dns.GetHostByName("www.velp.com.br");
                return true;
            }
            catch
            {
                try
                {
                    System.Net.IPHostEntry obj = System.Net.Dns.GetHostByName("www.google.com.br");
                    return true;
                }
                catch
                {
                    return false; // host not reachable. 
                }
            } 
        }

        /// <summary>
        /// Thread de sincronização
        /// </summary>
        private static void ThreadSync()
        {
            while (true)
            {                               
                    ConfigWebService configWS = new ConfigWebService();

                    //Se quandidade de leitura executada menor ou igual ao paramentro ou Quantidade de leituras que faltam para finalizar rota

                    if ((int.Parse(configWS.IntervaloWebService) <= LeituraFlow.getQtdLeituraRealizadaCurrent) || ((LeituraFlow.getQtdUc() - LeituraFlow.getQtdUcVisitada()) == (int.Parse(configWS.QuantidadeWebService))))
                    {


                        if (estaConectado())
                        {
                            if (!frmLogin._gps.Opened && ConfigWebService.LigarGpsWebService)
                            {
                                frmLogin._gps.Open();
                            }

                            //Sincroniza
                            Sync sync = new Sync();
                            sync.IniciaSinc();

                            LeituraFlow.ReiniciaQtdLeitReal();

                            //Envia dados para o servidor
                            /* sync.syncSetLeitura();
                             sync.syncSetMensagem();
                             sync.syncSetCorreioEletronico();
                             sync.syncSetFotos();
                             sync.syncSetLeituraProvisoria();

                             //ecupera dados do servidor
                             sync.syncLeitura();
                             sync.syncMensagem();
                             sync.syncGetCorreioEletronico();*/
                        }
                    }

                    //Espera por 60 segundos
                    Thread.Sleep(60000);                
            }
        }

#endregion

        private void cmbServico_SelectedIndexChanged(object sender, EventArgs e)
         {
            //           cmbRota.SelectedIndex = 0;

            //Lista de rota
            cmbRazao.Items.Clear();
            cmbRota.Items.Clear();
            List<int> lstRazao = new List<int>();

            lstRazao.AddRange(LeituraFlow.getRazao(usuario, cmbServico.SelectedItem.ToString()));

            if (lstRazao.Count > 0)
            {
                //Carrega o comboBox de razão
                foreach (int item in lstRazao)
                {
                    cmbRazao.Items.Add(item);
                }
                cmbRazao.SelectedIndex = 0;
            }
            
        }

        private void frmFiltrarRota_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 115 || e.KeyValue == 114)
            {
                Thread.Sleep(1000);
                Process P = Process.GetProcessById(Process.GetCurrentProcess().Id);
                SetForegroundWindow(P.MainWindowHandle);
            }
        }

        private void frmFiltrarRota_Load(object sender, EventArgs e)
        {

        }
    }
}
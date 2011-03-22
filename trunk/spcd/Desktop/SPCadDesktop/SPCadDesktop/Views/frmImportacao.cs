using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using SPCadDesktopData.Data.Model;
using SPCadDesktopData.Data;
using CommonHelpDesktop;

namespace SPCadDesktop.Views
{
    public partial class frmImportacao : Form
    {
        private int quantLinhas = 0;

        public frmImportacao()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    tbxPath.Text = ofd.FileName;
                    FileInfo fi = new FileInfo(tbxPath.Text);
                    using (StreamReader sr = fi.OpenText())
                    {
                        string s;
                        int quantLinhas = 0;
                        // contar quantidade de linhas.
                        while ((s = sr.ReadLine()) != null)
                        {
                            quantLinhas++;
                        }
                        this.quantLinhas = quantLinhas;

                        // reininiciar stream.
                        sr.BaseStream.Seek(0, SeekOrigin.Begin);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void importacao()
        {
            //utilizada em operação ternária.
            int? valorNulo = null;

            progressBar1.Maximum = 100;
            progressBar1.Value = 0;
            try
            {
                Cadastro cadastro = null;

                FileInfo fi = new FileInfo(tbxPath.Text);
                using (StreamReader sr = fi.OpenText())
                {
                    string s;
                    string[] campos;
                    int iProgress = 0;
                    // processo de importação das linhas.
                    while ((s = sr.ReadLine()) != null)
                    {
                        Cadastro cad = new Cadastro();
                        HistoricoConsumo[] hist = new HistoricoConsumo[6];

                        campos = s.Split(';');

                        //coluna 0
                        cad.Matricula = int.Parse(campos[0]);
                        //coluna 1
                        cad.NomeCliente = campos[1].Trim();
                        //coluna 2
                        cad.TipoLogradouro = campos[2].Substring(0, 3).Trim();
                        cad.NomeLogradouro = campos[2].Substring(3, 40).Trim();

                        cad.NumeroImovel = int.Parse(campos[2].Substring(43, 5).Trim());
                        cad.NumeroImovelAlter = cad.NumeroImovel;

                        cad.TipoComplemento = (campos[2].Substring(48, 2).Trim() == "") ? null : campos[2].Substring(48, 2).Trim();
                        cad.TipoComplementoAlter = cad.TipoComplemento;

                        cad.InformacaoComplementar = campos[2].Substring(50, 12).Trim();
                        cad.InformacaoComplementarAlter = cad.InformacaoComplementar;

                        cad.NomeBairro = campos[2].Substring(62, 30).Trim();
                        cad.NomeCidade = campos[2].Substring(92, 30).Trim();
                        

                        cad.CondicaoImovel = (string.IsNullOrEmpty(campos[3].Trim())) ? 0 : int.Parse(campos[3]);
                        cad.CondicaoImovelAlter = cad.CondicaoImovel;
                                                
                        cad.Setor = int.Parse(campos[4].Substring(0, 2).Trim());
                        cad.CodigoRota = int.Parse(campos[4].Substring(2, 2).Trim());                 
                        
                        cad.Face = int.Parse(campos[5].Trim());

                        //todo: mudar para 20, o valor 40 abaixo é apenas para teste de importação.
                        cad.CodigoDistrito = 1;
                        cad.Sequencia = int.Parse(campos[6].Trim());

                        cad.QtdeEconomiasResidencial = int.Parse(campos[7].Substring(1));
                        cad.QtdeEconomiasResidencialAlter = cad.QtdeEconomiasResidencial;

                        cad.QtdeEconomiasComercial = int.Parse(campos[8].Substring(1));
                        cad.QtdeEconomiasComercialAlter = cad.QtdeEconomiasComercial;

                        cad.QtdeEconomiasIndustrial = int.Parse(campos[9].Substring(1));
                        cad.QtdeEconomiasIndustrialAlter = cad.QtdeEconomiasIndustrial;

                        cad.QtdeEconomiasPublica = int.Parse(campos[10].Substring(1));
                        cad.QtdeEconomiasIndustrialAlter = cad.QtdeEconomiasPublica;

                        #region Validação Ramo Atividade

                        //Se algum dos metodos abaixo retornar o valor 0, significa uma incompatibilidade entre codigo e descrição de ramo atividade ou mesmo a inexistência do codigo na tabela de ramo atividade.
                        int? ramoAtiv1 = SingletonFlow.ramoAtividadeFlow.getIdRamoAtivByDesc(campos[12].Trim());
                        int? ramoAtiv2 = SingletonFlow.ramoAtividadeFlow.getIdRamoAtivByDesc(campos[14].Trim());
                        int? ramoAtiv3 = SingletonFlow.ramoAtividadeFlow.getIdRamoAtivByDesc(campos[16].Trim());
                        int? ramoAtiv4 = SingletonFlow.ramoAtividadeFlow.getIdRamoAtivByDesc(campos[18].Trim());

                        //variavel que receberá o ramo atividade com incompatibilidade.
                        string erro = "";

                        //se algum código estiver com zero, a variável erro será preenchida com a informação sobre qual campo está com incompatibilidade.
                        erro = (ramoAtiv1 == 0 || (ramoAtiv1 != int.Parse(campos[11]) && ramoAtiv1 != null)) ? "Ramo atividade 1\n" : "";
                        erro += (ramoAtiv2 == 0 || (ramoAtiv2 != int.Parse(campos[13]) && ramoAtiv2 != null)) ? "Ramo atividade 2\n" : "";
                        erro += (ramoAtiv3 == 0 || (ramoAtiv3 != int.Parse(campos[15]) && ramoAtiv3 != null)) ? "Ramo atividade 3\n" : "";
                        erro += (ramoAtiv4 == 0 || (ramoAtiv4 != int.Parse(campos[17]) && ramoAtiv4 != null)) ? "Ramo atividade 4" : "";

                        //se a variável erro for diferente de vazio, uma exception será lançada, interrompendo a importação de dados.
                        if (erro != "")
                        {
                            throw new Exception("Incompatibilidade em:\n" + erro);
                        }

                        #endregion                        
                        cad.RamoAtividade1 = (int.Parse(campos[11]) == 0) ? valorNulo : int.Parse(campos[11]);
                        cad.RamoAtividade1Alter = cad.RamoAtividade1;

                        cad.RamoAtividade2 = (int.Parse(campos[13]) == 0) ? valorNulo : int.Parse(campos[13]);
                        cad.RamoAtividade2Alter = cad.RamoAtividade2;

                        cad.RamoAtividade3 = (int.Parse(campos[15]) == 0) ? valorNulo : int.Parse(campos[15]);
                        cad.RamoAtividade3Alter = cad.RamoAtividade3;

                        cad.RamoAtividade4 = (int.Parse(campos[17]) == 0) ? valorNulo : int.Parse(campos[17]);
                        cad.RamoAtividade4Alter = cad.RamoAtividade4;

                        cad.TarifaSocialIncompativel = (campos[19].Trim() == "S") ? "S" : "N";

                        cad.FonteAlternativa = (campos[20].Trim() == "") ? null : campos[20].Trim();
                        cad.FonteAlternativaAlter = cad.FonteAlternativa;

                        cad.Reservatorio = (campos[21].Trim() == "") ? null : campos[21].Trim();
                        cad.ReservatorioAlter = cad.Reservatorio;

                        cad.Piscina = (campos[22].Trim() == "") ? null : campos[22].Trim();
                        cad.PiscinaAlter = cad.Piscina;

                        cad.SituacaoImovel = (campos[23].Trim() == "") ? null : campos[23].Trim(); //"RA", "FA", "PA"
                        cad.SituacaoImovelAlter = cad.SituacaoImovel.Trim();

                        cad.NumeroPontoServico = campos[24].Trim();

                        cad.SituacaoPontoServico = campos[25].Trim();
                        cad.SituacaoPontoServicoAlter = cad.SituacaoPontoServico;

                        cad.LocalizacaoPadrao = int.Parse(campos[26].Trim());
                        cad.LocalizacaoPadraoAlter = cad.LocalizacaoPadrao;

                        cad.TipoPadrao = int.Parse(campos[27].Trim()); ;
                        cad.TipoPadraoAlter = cad.TipoPadrao;

                        cad.NumeroMedidor = campos[28];
                        cad.NumeroMedidorAlter = cad.NumeroMedidor;

                        cad.ClasseMetrologica = campos[29]; //"B", "C"
                        cad.ClasseMetrologicaAlter = cad.ClasseMetrologica;

                        cad.QtdeDigitosMedidor = int.Parse(campos[30]);
                        cad.QtdeDigitosMedidorAlter = cad.QtdeDigitosMedidor;

                        cad.DataInstalacao = DateTime.ParseExact(campos[31], "yyyyMMdd", null);                                              
                        cad.StatusExecucao = 0;

                        cad.Observacao_complementar = campos[74].Trim();

                        //TODO: Descomentar alterações
                        //identifica um registro que já foi importado, caso ele esteja não executado(status execução zero), ele poderá ser atualizado,caso contrário a atualização é impedida.
                        /*cadastro = SingletonFlow.cadastroFlow.GetListCadastroByMatriculaPS(cad.Matricula.ToString(), cad.NumeroPontoServico);
                        if (cadastro != null && cadastro.StatusExecucao != 0)
                            continue;
                        if (cadastro != null)
                            cad.Id = cadastro.Id;

                        SingletonFlow.cadastroFlow.InsertOrUpdate(cad);*/

                        SingletonFlow.cadastroFlow.Insert(cad);


                        // historico consumo
                        int b = 0;//percorre volume medido
                        int c = 0;//percorre ocorrencia 1                       

                        SingletonFlow.historicoConsumoFlow.DeleteByCad(cad.Id);
                        for (int a = 0; a < 6; a++)
                        {
                            hist[a] = new HistoricoConsumo();

                            if (campos[32 + b].Trim() != "000000")
                            {
                                hist[a].MesReferencia = DateTime.ParseExact(campos[32 + b] + "01", "yyyyMMdd", null);
                            }

                            b++;
                            hist[a].VolumeMedido = int.Parse(campos[32 + b]);

                            
                            //42 é a posição inicial no arquivo de importação de ocorrencia 1
                            hist[a].Ocorrencia1 = (string.IsNullOrEmpty(campos[44 + c].Trim()) || campos[44 + c] == "00") ? valorNulo : int.Parse(campos[44 + c].Trim());

                            //48 é a posição inicial no arquivo de importação de ocorrencia 2
                            hist[a].Ocorrencia2 = (string.IsNullOrEmpty(campos[50 + c].Trim()) || campos[50 + c] == "00") ? valorNulo : int.Parse(campos[50 + c].Trim());

                            //54 é a posição inicial no arquivo de importação de criterio de apuração
                            hist[a].Criterio = (string.IsNullOrEmpty(campos[56 + c])) ? null : campos[56 + c].ToString();
                            long? valornull = null;
                            hist[a].LeituraApuracao = (string.IsNullOrEmpty(campos[62 + c])) ? valornull : long.Parse(campos[62 + c]);
                            DateTime? valornullb = null;
                            hist[a].DatLeituraFat = (string.IsNullOrEmpty(campos[68 + c].Trim()) || campos[68 + c].Trim() == "00000000") ? valornullb : DateTime.ParseExact(campos[68 + c], "yyyyMMdd", null);

                            hist[a].Cadastro = cad.Id;
                            hist[a].Matricula = cad.Matricula;
                            b++;//seta a próxima columa de data.
                            c++;
                            
                            SingletonFlow.historicoConsumoFlow.Insert(hist[a]);
                        }

                        // historico consumo
                        //int j = 0;
                        //for (int i = 0; i < 6; i++)
                        //{
                        //    hist[i] = new HistoricoConsumo();
                        //    if (campos[29 + j].Length < 6)
                        //    {
                        //        j += 2;
                        //        continue;
                        //    }

                        //    string teste = campos[29 + j];

                        //    if (campos[29 + j].Trim() != "000000")
                        //    {
                        //        hist[i].MesReferencia = DateTime.ParseExact(campos[29 + j] + "01", "yyyyMMdd", null);
                        //    }

                        //    j++;
                        //    hist[i].VolumeMedido = int.Parse(campos[29 + j]);
                        //    j++;
                        //    hist[i].Cadastro = cad.Id;
                        //    hist[i].Matricula = cad.Matricula;
                        //    hist[i].Criterio = 1; // não está no layout                           

                        //    SingletonFlow.historicoConsumoFlow.Insert(hist[i]);
                        //}
                        // update the progress bar
                        iProgress++;
                        double dProgressPercentage = ((double)iProgress / quantLinhas);
                        int iProgressPerc = (int)(dProgressPercentage * 100);
                        bgWorker.ReportProgress(iProgressPerc);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                btnBuscaDistribuicao.Enabled = true;
                btnImportar.Enabled = true;
            }
        }

        private void btnBuscaDistribuicao_Click(object sender, EventArgs e)
        {
            btnBuscaDistribuicao.Enabled = false;
            btnImportar.Enabled = false;
            bgWorker.RunWorkerAsync();
        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            importacao();
        }

        private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("A importação foi completada.");
            btnBuscaDistribuicao.Enabled = true;
            btnImportar.Enabled = true;
        }
    }
}

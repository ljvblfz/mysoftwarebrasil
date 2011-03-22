using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using Microsoft.WindowsMobile.Forms;
using System.Drawing;
using SPCadMobileData.Data.Model;
using CommonHelpMobile;
using SPCadMobileData.Data;
using System.IO;
using GDA;

namespace SPCadMobile.View.AuxiliarClass
{
    public class ShootingFoto
    {
        /// <summary>
        /// captura imagem do ambiente 
        /// </summary>
        /// <returns></returns>
        public static Foto CapturaFoto(Foto foto)
        {
            Foto fotoNew = new Foto();

            fotoNew.idCadast = foto.idCadast;
            fotoNew.numPontoServc = foto.numPontoServc;
            fotoNew.codOcorrc = foto.codOcorrc;
            fotoNew.Data = DateTime.Now;

            //adiciona as coordenadas
            //try
            //{
            //    GetCoordenadaGPS coord = new GetCoordenadaGPS();
            //    fotoNew.CoordenadaX = coord.latitude.ToString();
            //    fotoNew.CoordenadaY = coord.longitude.ToString();
            //    fotoNew.DataGPS = coord.data;                
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            //}

            //instância do objeto que chama a tela de captura de imagens.
            
            CameraCaptureDialog cameraCapture = new CameraCaptureDialog();

            try
            {
                // Tira foto com a melhor qualidade possível
                cameraCapture.StillQuality = CameraCaptureStillQuality.High;

                //Modo de captura de imagem = Foto
                cameraCapture.Mode = CameraCaptureMode.Still;

                // Define a resolução da foto
                cameraCapture.Resolution = new Size(640, 480);

                // Verifica se o arquivo já existe
                if (System.IO.File.Exists(InfoFiles.GetPathFoto() + fotoNew.nomFoto))
                {
                    System.IO.File.Delete(InfoFiles.GetPathFoto() + fotoNew.nomFoto);
                }

                // Abre a tela para tirar foto 
                DialogResult tiraFoto = cameraCapture.ShowDialog();

                CommonHelpMobile.TaskBarHelper.Hide();

                // Verifica se a foto foi tirada
                if (tiraFoto == DialogResult.OK && !string.IsNullOrEmpty(cameraCapture.FileName))
                {
                    try
                    {
                        // Insere o dado
                        SingletonFlow.fotoFlow.Insert(fotoNew);

                        // Move o arquivo da imagem capturada
                        System.IO.File.Move(cameraCapture.FileName, (InfoFiles.GetPathFoto() + fotoNew.nomFoto));
                    }
                    catch (GDAException ex)
                    {
                        throw new Exception("Erro: " + ex.Message);
                    }
                    catch (IOException ex)
                    {
                        // Deleta a foto
                        SingletonFlow.fotoFlow.Delete(foto);
                        throw new Exception("Erro: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("A foto não foi tirada!!!", "ATENÇÂO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível abrir a câmera do aparelho.", ex);
            }

            return fotoNew; 
        }
    }
}

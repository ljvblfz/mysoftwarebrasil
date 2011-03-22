using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
//using MobileTools.GPS;

namespace CommonHelpMobile
{
    //public class CoordenadaGPS
    //{
    //    #region Variáveis Locais

    //    private static Gps gpsDevice = new Gps();

    //    #endregion

    //    public CoordenadaGPS()
    //    {
    //        gpsDevice.DeviceStateChanged += new DeviceStateChangedEventHandler(gpsDevice_DeviceStateChanged);
    //        gpsDevice.LocationChanged += new LocationChangedEventHandler(gpsDevice_LocationChanged);
    //    }

    //    #region Método Públicos

    //    /// <summary>
    //    /// Recupera a posição do GPS.
    //    /// </summary>
    //    /// <returns>Dados da posição caso o Gps esteja ativo, ou nulo.</returns>
    //    public static GpsPosition GetPosition()
    //    {            
    //        return gpsDevice.GetPosition();            
    //    }

    //    /// <summary>
    //    /// Verifica se a posição do GPS é válida.
    //    /// </summary>
    //    /// <returns></returns>
    //    public static bool IsValidGpsPosition()
    //    {
    //        // Recuepra os dados da posição
    //        GpsPosition position = GetPosition();

    //        // Verifica se os dados não foram recuperados
    //        if (position == null)
    //            return false;
    //        else
    //            // Verifica se a posição recuperada é válida
    //            return position.LongitudeValid && position.LatitudeValid && position.TimeValid && position.SatelliteCountValid;
    //    }

    //    /// <summary>
    //    /// Desliga o GPS se estiver ligado.
    //    /// </summary>
    //    /// <returns></returns>
    //    public static void DesavitaGps()
    //    {
    //        // Verifica se a instancia o GPS está ativa
    //        if (gpsDevice != null)
    //        {
    //            try
    //            {
    //                // Fecha a instancia do GPS
    //                gpsDevice.Close();
    //            }
    //            catch
    //            {

    //            }
    //        }
    //    }

    //    /// <summary>
    //    /// Liga o GPS do Aparelho.
    //    /// </summary>
    //    public static void AtivaGPS()
    //    {
    //        try
    //        {
    //            // Abre o dispositivo GPS
    //            gpsDevice.Open();
    //        }
    //        catch (Exception ex)
    //        {
    //            System.Windows.Forms.MessageBox.Show("Erro ao iniciar o GPS do aparelho.");
    //        }
    //    }
    //    /// <summary>
    //    /// Retorna a Data atraves Gps;
    //    /// </summary>
    //    /// <returns></returns>
    //    public static DateTime CapturaHoraGps()
    //    {
    //        DateTime DataGps = gpsDevice.GetPosition().Time.ToLocalTime();
    //        return DataGps;
    //    }
    //    #endregion

    //    #region Métodos do GPS

    //    /// <summary>
    //    /// Método acionado quando a localização captura pelo GPS for alterada.
    //    /// </summary>
    //    /// <param name="sender"></param>
    //    /// <param name="args"></param>
    //    private void gpsDevice_LocationChanged(object sender, LocationChangedEventArgs args)
    //    {

    //    }

    //    /// <summary>
    //    /// Método acionado quando o estado do dispositivo for alterado.
    //    /// </summary>
    //    /// <param name="sender"></param>
    //    /// <param name="args"></param>
    //    private void gpsDevice_DeviceStateChanged(object sender, DeviceStateChangedEventArgs args)
    //    {

    //    }

    //    #endregion
    //}
}

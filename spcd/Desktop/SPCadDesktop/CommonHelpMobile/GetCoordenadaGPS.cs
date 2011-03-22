using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;


namespace CommonHelpMobile
{
    //public class GetCoordenadaGPS
    //{
    //   public double latitude { get; set; }
    //   public double longitude { get; set; }
    //   public DateTime data { get; set; }
                
    //    public GetCoordenadaGPS()
    //    {
    //        // Recupera os dados da posição

    //        try
    //        {
    //            MobileTools.GPS.GpsPosition position = CoordenadaGPS.GetPosition();

    //            bool invalidGps = false;

    //            if (!position.LongitudeValid || !position.LongitudeValid)
    //            {
    //                invalidGps = true;
    //                throw new Exception("As coordenadas do GPS não são validas!");
    //            }
                
    //            if(!invalidGps)                    
    //            {
    //                MobileTools.SystemTimeInfo.UpdateSystemTime(CoordenadaGPS.CapturaHoraGps());

    //                //carrega as propriedades.               
    //                latitude = position.Latitude;
    //                longitude = position.Longitude;
    //                data = DateTime.Now;
    //            }
    //            else
    //            {
    //                throw new Exception("Não foi possível obter as Coordenadas, tente novamente em alguns instantes!");
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            throw new Exception(ex.Message); 
    //        }
    //    }
    //}
}

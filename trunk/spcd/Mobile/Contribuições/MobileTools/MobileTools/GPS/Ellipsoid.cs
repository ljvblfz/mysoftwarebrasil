using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualBasic;

namespace MobileTools.GPS
{
    /// <summary>
    /// Trabalha com conversões de coordenadas geograficas.
    /// Essa classe foi importada apartir de um código VISUALBASIC.
    /// </summary>
    public class Ellipsoid
    {
        public int id;
        public string ellipsoidName;
        public double EquatorialRadius;
        public double eccentricitySquared;
        const double PI = 3.14159265;
        const double FOURTHPI = PI / 4;
        const double deg2rad = PI / 180;
        const double rad2deg = 180.0 / PI;
        const double oneMiles = 1609.344;
        const double oneFoot = 0.3048;
        const double oneDegreeLat = 111044.736;
        const double oneMinuteLat = 1850.7456;
        const double oneSecondLat = 30.84576;
        const double oneDegreeLong = 67592.448;
        const double oneMinuteLong = 1126.5408;
        const double oneSecondLong = 18.77568;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iid">Identificador da elipsoid.</param>
        /// <param name="sname">Nome.</param>
        /// <param name="radius">Raio polar em metros</param>
        /// <param name="ecc"></param>
        public Ellipsoid(int iid, string sname, double radius, double ecc)
        {
            id = iid;
            ellipsoidName = sname;
            EquatorialRadius = radius;
            eccentricitySquared = ecc;
        }
        public Ellipsoid(int iid)
        {
            SetID(iid);
        }

        public void GPS2XY(string gpspos, ref double x, ref double y)
        {
            if (!string.IsNullOrEmpty(gpspos))
            {
                string latdeg = "";
                string longdeg = "";
                string UTMZone = "";
                GPS2LATLONGDeg(gpspos, ref latdeg, ref longdeg);

                double lat = DegMinSec2Deg(latdeg);
                double longi = DegMinSec2Deg(longdeg);

                LLtoUTM(lat, longi, ref x, ref y, ref UTMZone);
                if (Strings.InStr(gpspos, "S", CompareMethod.Text) > 0) y = -1 * Math.Abs(y);
            }
            //If InStr(gpspos, "E") > 0 Then x = -1 * Math.Abs(x)

            else
            {
                x = 0;
                y = 0;
            }
        }

        public void GPS2LATLONGDeg(string gpspos, ref string latdeg, ref string longdeg)
        {
            gpspos = gpspos.Replace(";", "");
            gpspos = gpspos.Replace(":", "");
            string charx = (gpspos.IndexOf('N') > 0 ? "N" : "S");
            string chary = (gpspos.IndexOf('E') > 0 ? "E" : "W");
            latdeg = Strings.Trim(Strings.Mid(gpspos, Strings.InStr(gpspos, charx, CompareMethod.Text) + 1, Strings.InStr(gpspos, chary, CompareMethod.Text) - 2));
            longdeg = Strings.Trim(Strings.Mid(gpspos, Strings.InStr(gpspos, chary, CompareMethod.Text) + 1));
            if (Strings.InStr(gpspos, "S", CompareMethod.Text) > 0) latdeg = "-" + latdeg;
            if (Strings.InStr(gpspos, "W", CompareMethod.Text) > 0) longdeg = "-" + longdeg;

        }

        public double DegMinSec2Deg(string degree)
        {
            double ddegree = 0;
            double dminute = 0;
            double dsecond = 0;
            bool ismin = (Strings.InStr(degree, "-", CompareMethod.Text) > 0);
            double lat = 0;
            if (Strings.InStr(Strings.UCase(degree), "D", CompareMethod.Text) > 0)
            {
                ddegree = double.Parse(Strings.Trim(Strings.Mid(degree, 1, Strings.InStr(Strings.UCase(degree), "D", CompareMethod.Text) - 1)));
                degree = Strings.Trim(Strings.Mid(degree, Strings.InStr(Strings.UCase(degree), "D", CompareMethod.Text) + 1));
            }
            else if (Strings.InStr(degree, "\x176", CompareMethod.Text) > 0)
            {
                ddegree = double.Parse(Strings.Trim(Strings.Mid(degree, 1, Strings.InStr(Strings.UCase(degree), "\x176", CompareMethod.Text) - 1)));
                degree = Strings.Trim(Strings.Mid(degree, Strings.InStr(Strings.UCase(degree), "\x176", CompareMethod.Text) + 1));
            }
            else if (Strings.InStr(degree, "\x186", CompareMethod.Text) > 0)
            {
                ddegree = double.Parse(Strings.Trim(Strings.Mid(degree, 1, Strings.InStr(Strings.UCase(degree), "\x186", CompareMethod.Text) - 1)));
                degree = Strings.Trim(Strings.Mid(degree, Strings.InStr(Strings.UCase(degree), "\x186", CompareMethod.Text) + 1));
            }
            else
            {
                ddegree = 0;
            }
            if (Strings.InStr(Strings.UCase(degree), "'", CompareMethod.Text) > 0)
            {
                dminute = double.Parse(Strings.Trim(Strings.Mid(degree, 1, Strings.InStr(Strings.UCase(degree), "'", CompareMethod.Text) - 1)));
            }
            else
            {
                dminute = 0;
            }
            degree = Strings.Trim(Strings.Mid(degree, Strings.InStr(Strings.UCase(degree), "'", CompareMethod.Text) + 1));
            if (Strings.InStr(Strings.UCase(degree), "\"", CompareMethod.Text) > 0)
            {
                dsecond = double.Parse(Strings.Trim(Strings.Mid(degree, 1, Strings.InStr(Strings.UCase(degree), "\"", CompareMethod.Text) - 1)));
            }
            else if (Strings.InStr(Strings.UCase(degree), "''", CompareMethod.Text) > 0)
            {
                dsecond = double.Parse(Strings.Trim(Strings.Mid(degree, 1, Strings.InStr(Strings.UCase(degree), "''", CompareMethod.Text) - 1)));
            }
            else
            {
                dsecond = 0;
            }

            lat = Math.Abs(ddegree) + (Math.Abs(dminute) / 60) + (Math.Abs(dsecond) / 3600);
            if (ismin)
            {
                lat = lat * -1;
            }

            return lat;
        }

        public void SetValue(int iid, string sname, double radius, double ecc)
        {
            id = iid;
            ellipsoidName = sname;
            EquatorialRadius = radius;
            eccentricitySquared = ecc;
        }

        public void SetID(int id)
        {
            if (id == -1)
            {
                SetValue(-1, "Placeholder", 0, 0);
            }
            else if (id == 1)
            {
                SetValue(1, "Airy", 6377563, 0.00667054);
            }
            else if (id == 2)
            {
                SetValue(2, "Australian National", 6378160, 0.006694542);
            }
            else if (id == 3)
            {
                SetValue(3, "Bessel 1841", 6377397, 0.006674372);
            }
            else if (id == 4)
            {
                SetValue(4, "Bessel 1841 (Nambia) ", 6377484, 0.006674372);
            }
            else if (id == 5)
            {
                SetValue(5, "Clarke 1866", 6378206, 0.006768658);
            }
            else if (id == 6)
            {
                SetValue(6, "Clarke 1880", 6378249, 0.006803511);
            }
            else if (id == 7)
            {
                SetValue(7, "Everest", 6377276, 0.006637847);
            }
            else if (id == 8)
            {
                SetValue(8, "Fischer 1960 (Mercury) ", 6378166, 0.006693422);
            }
            else if (id == 9)
            {
                SetValue(9, "Fischer 1968", 6378150, 0.006693422);
            }
            else if (id == 10)
            {
                SetValue(10, "GRS 1967", 6378160, 0.006694605);
            }
            else if (id == 11)
            {
                SetValue(11, "GRS 1980", 6378137, 0.00669438);
            }
            else if (id == 12)
            {
                SetValue(12, "Helmert 1906", 6378200, 0.006693422);
            }
            else if (id == 13)
            {
                SetValue(13, "Hough", 6378270, 0.00672267);
            }
            else if (id == 14)
            {
                SetValue(14, "International", 6378388, 0.00672267);
            }
            else if (id == 15)
            {
                SetValue(15, "Krassovsky", 6378245, 0.006693422);
            }
            else if (id == 16)
            {
                SetValue(16, "Modified Airy", 6377340, 0.00667054);
            }
            else if (id == 17)
            {
                SetValue(17, "Modified Everest", 6377304, 0.006637847);
            }
            else if (id == 18)
            {
                SetValue(18, "Modified Fischer 1960", 6378155, 0.006693422);
            }
            else if (id == 19)
            {
                SetValue(19, "South American 1969", 6378160, 0.006694542);
            }
            else if (id == 20)
            {
                SetValue(20, "WGS 60", 6378165, 0.006693422);
            }
            else if (id == 21)
            {
                SetValue(21, "WGS 66", 6378145, 0.006694542);
            }
            else if (id == 22)
            {
                SetValue(22, "WGS-72", 6378135, 0.006694318);
            }
            else if (id == 23)
            {
                SetValue(23, "WGS-84", 6378137, 0.00669438);
            }
        }

        public char UTMLetterDesignator(double Lat)
        {
            char LetterDesignator = '\0';
            if (((84 >= Lat) & (Lat >= 72)))
            {
                LetterDesignator = 'X';
            }
            else if (((72 > Lat) & (Lat >= 64)))
            {
                LetterDesignator = 'W';
            }
            else if (((64 > Lat) & (Lat >= 56)))
            {
                LetterDesignator = 'V';
            }
            else if (((56 > Lat) & (Lat >= 48)))
            {
                LetterDesignator = 'U';
            }
            else if (((48 > Lat) & (Lat >= 40)))
            {
                LetterDesignator = 'T';
            }
            else if (((40 > Lat) & (Lat >= 32)))
            {
                LetterDesignator = 'S';
            }
            else if (((32 > Lat) & (Lat >= 24)))
            {
                LetterDesignator = 'R';
            }
            else if (((24 > Lat) & (Lat >= 16)))
            {
                LetterDesignator = 'Q';
            }
            else if (((16 > Lat) & (Lat >= 8)))
            {
                LetterDesignator = 'P';
            }
            else if (((8 > Lat) & (Lat >= 0)))
            {
                LetterDesignator = 'N';
            }
            else if (((0 > Lat) & (Lat >= -8)))
            {
                LetterDesignator = 'M';
            }
            else if (((-8 > Lat) & (Lat >= -16)))
            {
                LetterDesignator = 'L';
            }
            else if (((-16 > Lat) & (Lat >= -24)))
            {
                LetterDesignator = 'K';
            }
            else if (((-24 > Lat) & (Lat >= -32)))
            {
                LetterDesignator = 'J';
            }
            else if (((-32 > Lat) & (Lat >= -40)))
            {
                LetterDesignator = 'H';
            }
            else if (((-40 > Lat) & (Lat >= -48)))
            {
                LetterDesignator = 'G';
            }
            else if (((-48 > Lat) & (Lat >= -56)))
            {
                LetterDesignator = 'F';
            }
            else if (((-56 > Lat) & (Lat >= -64)))
            {
                LetterDesignator = 'E';
            }
            else if (((-64 > Lat) & (Lat >= -72)))
            {
                LetterDesignator = 'D';
            }
            else if (((-72 > Lat) & (Lat >= -80)))
            {
                LetterDesignator = 'C';
            }
            else
            {
                LetterDesignator = 'Z';
            }
            return LetterDesignator;
        }

        public void LLtoUTM(double Lat, double Longi, ref double UTMeast, ref double UTMnorth, ref string UTMzone)
        {
            double eccSquared = eccentricitySquared;

            double k0 = 0.9996;
            double longorigin = 0;
            double eccPrimeSquared = 0;
            double longtemp = (Longi + 180) - Conversion.Int((Longi + 180) / 360) * 360 - 180;
            double LatRad = Lat * deg2rad;
            double LongRad = longtemp * deg2rad;
            double LongOriginRad = 0;
            int ZoneNumber = 0;

            ZoneNumber = (int)((longtemp + 180) / 6) + 1;

            if ((Lat >= 56.0 & Lat < 64.0 & longtemp >= 3.0 & longtemp < 12.0)) ZoneNumber = 32;
            if ((Lat >= 72.0 & Lat < 84.0))
            {
                if ((longtemp >= 0.0 & longtemp < 9.0))
                {
                    ZoneNumber = 31;
                }
                else if ((longtemp >= 9.0 & longtemp < 21.0))
                {
                    ZoneNumber = 33;
                }
                else if ((longtemp >= 21.0 & longtemp < 33.0))
                {
                    ZoneNumber = 35;
                }
                else if ((longtemp >= 33.0 & longtemp < 42.0))
                {
                    ZoneNumber = 37;
                }
            }
            longorigin = (ZoneNumber - 1) * 6 - 180 + 3;
            //+3 puts origin in middle of zone
            LongOriginRad = longorigin * deg2rad;

            //sprintf(UTMZone, "%d%c", ZoneNumber, UTMLetterDesignator(Lat));
            UTMzone = Conversion.Str(ZoneNumber) + UTMLetterDesignator(Lat);

            eccPrimeSquared = (eccentricitySquared) / (1 - eccentricitySquared);

            double n = EquatorialRadius / Math.Sqrt(1 - eccentricitySquared * Math.Sin(LatRad) * Math.Sin(LatRad));
            double t = Math.Tan(LatRad) * Math.Tan(LatRad);
            double c = eccPrimeSquared * Math.Cos(LatRad) * Math.Cos(LatRad);
            double a = Math.Cos(LatRad) * (LongRad - LongOriginRad);

            double m = EquatorialRadius * ((1 - eccentricitySquared / 4 - 3 * eccentricitySquared * eccentricitySquared / 64 - 5 * eccentricitySquared * eccentricitySquared * eccentricitySquared / 256) * LatRad - (3 * eccentricitySquared / 8 + 3 * eccentricitySquared * eccentricitySquared / 32 + 45 * eccentricitySquared * eccentricitySquared * eccentricitySquared / 1024) * Math.Sin(2 * LatRad) + (15 * eccentricitySquared * eccentricitySquared / 256 + 45 * eccentricitySquared * eccentricitySquared * eccentricitySquared / 1024) * Math.Sin(4 * LatRad) - (35 * eccentricitySquared * eccentricitySquared * eccentricitySquared / 3072) * Math.Sin(6 * LatRad));

            UTMeast = (k0 * n * (a + (1 - t + c) * a * a * a / 6 + (5 - 18 * t + t * t + 72 * c - 58 * eccPrimeSquared) * a * a * a * a * a / 120) + 500000.0);

            UTMnorth = (k0 * (m + n * Math.Tan(LatRad) * (a * a / 2 + (5 - t + 9 * c + 4 * c * c) * a * a * a * a / 24 + (61 - 58 * t + t * t + 600 * c - 330 * eccPrimeSquared) * a * a * a * a * a * a / 720)));
            if ((Lat < 0))
            {
                UTMnorth += 10000000.0;
                //10000000 meter offset for southern hemisphere
            }

        }

        public void UTMtoLL(int ReferenceEllipsoid, double UTMNorth, double UTMEast, char UTMZone, ref double Lat, ref double Longi)
        {
            //converts UTM coords to lat/long.  Equations from USGS Bulletin 1532
            //East Longitudes are positive, West longitudes are negative.
            //North latitudes are positive, South latitudes are negative
            //Lat and Long are in decimal degrees.
            //Written by Chuck Gantz- chuck.gantz@globalstar.com

            double k0 = 0.9996;
            double a = EquatorialRadius;
            double eccSquared = eccentricitySquared;
            double eccPrimeSquared = 0;
            double e1 = (1 - Math.Sqrt(1 - eccSquared)) / (1 + Math.Sqrt(1 - eccSquared));

            double LongOrigin = 0;

            double x = 0;
            double y = 0;
            int ZoneNumber = 0;
            string ZoneLetter = null;
            int NorthernHemisphere = 0;
            //1 for northern hemispher, 0 for southern

            x = UTMEast - 500000.0;
            //remove 500,000 meter offset for longitude
            y = UTMNorth;

            string uZone = UTMZone.ToString();

            ZoneNumber = int.Parse(Strings.Mid(uZone, 1, Strings.Len(uZone) - 1));
            ZoneLetter = Strings.Mid(uZone, Strings.Len(uZone) - 1);
            // strtoul(UTMZone, &ZoneLetter, 10)

            if (((Strings.Asc(ZoneLetter) - Strings.Asc("N")) >= 0))
            {
                NorthernHemisphere = 1;
                //point is in northern hemisphere
            }
            else
            {
                NorthernHemisphere = 0;
                //point is in southern hemisphere
                y -= 10000000.0;
                //remove 10,000,000 meter offset used for southern hemisphere
            }

            LongOrigin = (ZoneNumber - 1) * 6 - 180 + 3;
            //+3 puts origin in middle of zone

            eccPrimeSquared = (eccSquared) / (1 - eccSquared);

            double M = y / k0;
            double mu = M / (a * (1 - eccSquared / 4 - 3 * eccSquared * eccSquared / 64 - 5 * eccSquared * eccSquared * eccSquared / 256));

            double phi1Rad = mu + (3 * e1 / 2 - 27 * e1 * e1 * e1 / 32) * Math.Sin(2 * mu) + (21 * e1 * e1 / 16 - 55 * e1 * e1 * e1 * e1 / 32) * Math.Sin(4 * mu) + (151 * e1 * e1 * e1 / 96) * Math.Sin(6 * mu);
            double phi1 = phi1Rad * rad2deg;

            double N1 = a / Math.Sqrt(1 - eccSquared * Math.Sin(phi1Rad) * Math.Sin(phi1Rad));
            double T1 = Math.Tan(phi1Rad) * Math.Tan(phi1Rad);
            double C1 = eccPrimeSquared * Math.Cos(phi1Rad) * Math.Cos(phi1Rad);
            double R1 = a * (1 - eccSquared) / Math.Pow(1 - eccSquared * Math.Sin(phi1Rad) * Math.Sin(phi1Rad), 1.5);
            double D = x / (N1 * k0);

            Lat = phi1Rad - (N1 * Math.Tan(phi1Rad) / R1) * (D * D / 2 - (5 + 3 * T1 + 10 * C1 - 4 * C1 * C1 - 9 * eccPrimeSquared) * D * D * D * D / 24 + (61 + 90 * T1 + 298 * C1 + 45 * T1 * T1 - 252 * eccPrimeSquared - 3 * C1 * C1) * D * D * D * D * D * D / 720);
            Lat = Lat * rad2deg;

            Longi = (D - (1 + 2 * T1 + C1) * D * D * D / 6 + (5 - 2 * C1 + 28 * T1 - 3 * C1 * C1 + 8 * eccPrimeSquared + 24 * T1 * T1) * D * D * D * D * D / 120) / Math.Cos(phi1Rad);
            Longi = LongOrigin + Longi * rad2deg;

        }
    }


}

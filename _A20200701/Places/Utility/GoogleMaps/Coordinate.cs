using GMap.NET;
using Google.Maps;
using Google.Maps.Geocoding;
using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.GoogleMaps
{
   //座標
    public class Coordinate
    {
      

        /// <summary>
        /// Decode google style polyline coordinates.
        /// </summary>
        /// <param name="encodedPoints"></param>
        /// <returns></returns>
        public static IEnumerable<PointLatLng> Decode(string encodedPoints)
        {
            if (string.IsNullOrEmpty(encodedPoints))
                throw new ArgumentNullException("encodedPoints");

            char[] polylineChars = encodedPoints.ToCharArray();
            int index = 0;

            int currentLat = 0;
            int currentLng = 0;
            int next5bits;
            int sum;
            int shifter;

            while (index < polylineChars.Length)
            {
                // calculate next latitude
                sum = 0;
                shifter = 0;
                do
                {
                    next5bits = (int)polylineChars[index++] - 63;
                    sum |= (next5bits & 31) << shifter;
                    shifter += 5;
                } while (next5bits >= 32 && index < polylineChars.Length);

                if (index >= polylineChars.Length)
                    break;

                currentLat += (sum & 1) == 1 ? ~(sum >> 1) : (sum >> 1);

                //calculate next longitude
                sum = 0;
                shifter = 0;
                do
                {
                    next5bits = (int)polylineChars[index++] - 63;
                    sum |= (next5bits & 31) << shifter;
                    shifter += 5;
                } while (next5bits >= 32 && index < polylineChars.Length);

                if (index >= polylineChars.Length && next5bits >= 32)
                    break;

                currentLng += (sum & 1) == 1 ? ~(sum >> 1) : (sum >> 1);

                yield return new PointLatLng
                {
                    Lat = Convert.ToDouble(currentLat) / 1E5,
                    Lng = Convert.ToDouble(currentLng) / 1E5
                };
            }
        }

      













        public string Address { get; set; }     


        /// <summary>
        /// 必須提供address, language的建構函數
        /// </summary>
        /// <param name="address"></param>       
        public Coordinate(string address)
        {
            //always need to use YOUR_API_KEY for requests.  Do this in App_Start.
            string authKey = "AIzaSyDi9t-vPKn-xXNP9swFQk3wdeE5mU4IDj4";
            GoogleSigned.AssignAllServices(new GoogleSigned(authKey));

            this.Address = address;         
        }



        /// <summary>
        /// 取得座標位置(經度、緯度)
        /// </summary>    
        /// <returns>經緯度位置</returns>
        public double[] GetCoordinate()
        {
            double[] location=new double[2];

            GeocodingRequest geocodingRequest = new GeocodingRequest();
            geocodingRequest.Address = Address;
            geocodingRequest.Language = "zh-tw";
            GeocodeResponse geocodeResponse = new GeocodingService().GetResponse(geocodingRequest);
            Result[] geocodeResult = geocodeResponse.Results;
           
            
            foreach (var g in geocodeResult)
            {                
                location[0]= g.Geometry.Location.Latitude;//緯度
                location[1] = g.Geometry.Location.Longitude;//經度
            }
            return location;
        }
    }
}

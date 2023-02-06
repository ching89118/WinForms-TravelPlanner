using Google.Maps;
using Google.Maps.Geocoding;


namespace Utility.GoogleMaps
{
   //座標
    public class Coordinate
    {
        public string Address { get; set; }     


        /// <summary>
        /// 必須提供address, language的建構函數
        /// </summary>
        /// <param name="address"></param>       
        public Coordinate(string address)
        {
            //always need to use YOUR_API_KEY for requests.  Do this in App_Start.
            string authKey = "AIzaSyDi9t-vPKn-xXNP9swFQk3wd**********";
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

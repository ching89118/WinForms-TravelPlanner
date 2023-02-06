using Google.Maps.Places;
using Google.Maps.Places.Details;
using System.Windows.Forms;
using System.Reflection;
using System.Drawing;
using System.Data;
using System.Collections.Generic;

namespace Utility.GoogleMaps
{
    public class PlaceAPI
    {

        public static string Keyword { get; set; } 

        /// <summary>
        /// 取得目的地資訊陣列
        /// </summary>      
        /// <returns>PlaceResult陣列</returns>
        public static PlacesResult[] GetPlaceResults(string keyword)
        {          
            TextSearchRequest txtSearchRequest = new TextSearchRequest();//Query屬性 is set.
            txtSearchRequest.Language = "zh-tw";
            txtSearchRequest.Query = keyword;
            PlacesResult[] placesResult = new PlacesService().GetResponse(txtSearchRequest).Results;
          
            return placesResult;
        }



        /// <summary>
        /// 取得目的地詳細資訊
        /// </summary>
        /// <param name="placeId">PlcaeId</param>
        /// <returns>PlaceDetailsResult</returns>
        public static PlaceDetailsResult GetPlaceDetails(string placeId)
        {
            PlaceDetailsRequest placeDetailsRequest = new PlaceDetailsRequest();
            placeDetailsRequest.Language = "zh-tw";
            placeDetailsRequest.PlaceID = placeId;//PlaceID屬性 is set.


            PlaceDetailsResponse placeDetailsResponse = new PlaceDetailsService().GetResponse(placeDetailsRequest);
            PlaceDetailsResult result = placeDetailsResponse.Result;

            return result;
        }
       

    }
}


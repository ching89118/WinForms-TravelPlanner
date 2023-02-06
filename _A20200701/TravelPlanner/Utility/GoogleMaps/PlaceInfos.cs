using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Maps;
using Google.Maps.Places;
using Google.Maps.Places.Details;


namespace Utility.GoogleMaps
{
   public class PlaceInfos
    {
        string authKey = "AIzaSyDi9t-vPKn-xXNP9swFQk3wdeE5mU4IDj4";

        public PlaceInfos()
        {
            //always need to use YOUR_API_KEY for requests.  Do this in App_Start.           
            GoogleSigned.AssignAllServices(new GoogleSigned(authKey));
        }

        public string Keyword { get; set; }
        public string Language { get; set; }
        public string pName { get; set; }
        public string pFormattedAddress { get; set; }
        public double pRating { get; set; }      
        public string pPriceLevel { get; set; }
        public string pOpentime { get; set; }
        public string pCloseTime { get; set; }
        public string pPhoneNumber { get; set; }

        //目標取得：NearbySearch、OpeningHours、Ratings、PriceLevel、InternationalPhoneNumber       
        
        /// <summary>
        /// 取得目的地相關資訊
        /// </summary>
        /// <param name="keyword">目的地或周邊式搜尋</param>
        /// <param name="language">取得資料的語系</param>
        public void SearchPlace(string keyword, string language)
        {
            TextSearchRequest txtSearchRequest = new TextSearchRequest();//Query屬性 is set.
            txtSearchRequest.Language = language;
            txtSearchRequest.Query = keyword;
            PlacesResult[] placesResult = new PlacesService().GetResponse(txtSearchRequest).Results;


            foreach (var p in placesResult)
            {
                //取得周邊的Name, FormattedAddress,Rating
                NearbySearchRequest searchRequest = new NearbySearchRequest(); //Location屬性 is set.                 
                searchRequest.Location = p.Geometry.Location;
                pName = p.Name;
                pRating = p.Rating;
                pFormattedAddress = p.FormattedAddress;

                //取得周邊的PriceLevel,OpeningHours,PhoneNumber
                PlaceDetailsRequest placeDetailsRequest = new PlaceDetailsRequest();
                placeDetailsRequest.PlaceID = p.PlaceId;//PlaceID屬性 is set.             
                PlaceDetailsResponse placeDetailsResponse = new PlaceDetailsService().GetResponse(placeDetailsRequest);
              

             pPriceLevel= placeDetailsResponse.Result.PriceLevel.ToString();
             pPhoneNumber = placeDetailsResponse.Result.InternationalPhoneNumber;

                try
                {
                    foreach (var op in placeDetailsResponse.Result.OpeningHours.Periods)
                    {
                        pOpentime = op.Open.Time.ToString();
                        pCloseTime = op.Close.Time.ToString();
                        break;
                    }
                }
                catch (NullReferenceException ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }                 
            }

        }
    }
} 

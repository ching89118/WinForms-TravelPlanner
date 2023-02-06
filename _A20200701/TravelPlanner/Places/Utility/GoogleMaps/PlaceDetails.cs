using Google.Maps.Places.Details;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;

namespace Utility.GoogleMaps
{
    public class PlaceDetails
    {
        [DisplayName("PlaceName")]
        public string PlaceName { get; set; }
        [DisplayName("Address")]
        public string Address { get; set; }
        [DisplayName("Rating")]
        public float Rating { get; set; }

        [DisplayName("PriceLevel")]
        public string PriceLevel { get; set; }
        [DisplayName("PhoneNumber")]
        public string PhoneNumber { get; set; }
        [DisplayName("OpeningPeriods")]
        public string OpeningPeriods { get; set; }





        public void SetDetailsValues(PlaceDetailsResult result, PlaceDetails placeDetails)
        {

            try
            {

                /* 呼叫擴充方法將其他標點都替換成 "_" (檔名需要) */
                placeDetails.PlaceName = result.Name.ReplaceSpecifierInString();
                placeDetails.Address = result.FormattedAddress.Replace(',', '/');
                placeDetails.Rating = result.Rating;
                placeDetails.PriceLevel = result.PriceLevel.ToString();
                placeDetails.PhoneNumber = result.InternationalPhoneNumber;

                StringBuilder sb = new StringBuilder();

                /* 防止此異常拋出：System.NullReferenceException: 並未將物件參考設定為物件的執行個體 */
                if (result.OpeningHours != null)
                {
                    foreach (var weekday in result.OpeningHours.WeekdayText)
                    {
                        string day = weekday.Replace(',', '/');

                        sb.Append(day + ";");

                    }

                    placeDetails.OpeningPeriods = sb.ToString();

                }
                else
                {
                    /* 若為null，就回傳空字串 */
                    placeDetails.OpeningPeriods = string.Empty;
                }

            }
            catch
            {

                MessageBox.Show("無相似的搜尋結果，請重新搜尋！");
            }


        }
    }



}

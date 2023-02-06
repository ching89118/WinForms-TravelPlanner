using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Google.Maps.Places;


namespace Utility.GoogleMaps
{
   public class PlaceOverviews
    {
       // public bool Selected { get; set; }
        public string PlaceName { get; set; }
        public string Address { get; set; }
        public double Rating { get; set; }
        public string PlaceId { get; set; }

        public void SetOverviewsValues(PlacesResult results, PlaceOverviews placeOverviews)
        {
            try
            {

                /* 呼叫擴充方法將其他標點都替換成 "_" (檔名需要) */
                placeOverviews.PlaceName = results.Name.ReplaceSpecifierInString();
                placeOverviews.Address = results.FormattedAddress.Replace(',', '/');
                placeOverviews.Rating = results.Rating;
                placeOverviews.PlaceId = results.PlaceId;
            }
            catch 
            {

                MessageBox.Show("無相似的搜尋結果，請重新搜尋！");
            }
            
        }



    }

}



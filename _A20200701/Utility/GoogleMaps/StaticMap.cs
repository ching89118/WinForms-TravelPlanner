using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Maps;
using Google.Maps.StaticMaps;
using System.Drawing;
using System.IO;

namespace Utility.GoogleMaps
{

   public class StaticMap
    {
        StaticMapRequest staticMapRequest = new StaticMapRequest();
        string authKey = "AIzaSyDi9t-vPKn-xXNP9swFQk3wdeE5mU4IDj4";


        public string Center { get; set; }  


     /// <summary>
     /// 必須提供center, language的建構函數
     /// </summary>
     /// <param name="center"></param>    
        public StaticMap(string center)
        {
            //always need to use YOUR_API_KEY for requests.  Do this in App_Start.           
            GoogleSigned.AssignAllServices(new GoogleSigned(authKey));
            this.Center = center;       
        }

        /// <summary>
        /// 取得地圖圖片
        /// </summary>        
        /// <returns>地圖圖片</returns>
        public Image GenerateMap()
        {           
            staticMapRequest.Center = new Location(Center);
            staticMapRequest.Language = "zh-tw";
            staticMapRequest.Size= new Size(400, 400);
            staticMapRequest.Zoom = 14;
            
            byte[] imageBytes = new StaticMapService().GetImage(staticMapRequest);
            //呼叫Byte[]轉Image方法
            Image staticMap = BufferToImage(imageBytes);

            return staticMap;
        }        


        /// <summary>
        /// 將 Byte 陣列轉換為 Image
        /// </summary>
        /// <param name="Buffer">Byte 陣列</param>
        /// <returns></returns>
        public static Image BufferToImage(byte[] Buffer)
        {
            if (Buffer == null || Buffer.Length == 0) { return null; }
            byte[] data = null;
            Image oImage = null;
            Bitmap oBitmap = null;
            //建立副本
            data = (byte[])Buffer.Clone();
            try
            {
                MemoryStream oMemoryStream = new MemoryStream(Buffer);
                //設定資料流位置
                oMemoryStream.Position = 0;
                oImage = System.Drawing.Image.FromStream(oMemoryStream);
                //建立副本
                oBitmap = new Bitmap(oImage);
            }
            catch
            {
                throw;
            }         
            
            return oBitmap;
        }



        /// <summary>
        /// 取得地圖網址 + Google API 驗證碼 回傳
        /// </summary>
        /// <param name="center">要查詢的目的地</param>
        /// <returns>地圖Url+Key</returns>
        public string GenerateMapUrl(string center)
        {
            staticMapRequest.Center = center;
            string mapUrl = staticMapRequest.ToUriString() +"&key="+ authKey;

            return mapUrl;
        }
    }
}

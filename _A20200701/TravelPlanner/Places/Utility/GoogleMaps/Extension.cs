using Google.Maps.Places.Details;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;


namespace Utility.GoogleMaps
{
    public static class Extension
    {


        /// <summary>
        /// PlaceDetailsResult的擴充方法：取得照片Url+驗證碼
        /// </summary>
        /// <param name="result">PlaceDetailsResult result</param>
        /// <returns>photoUrl序列</returns>
        public static List<string> GetPhotoUrl(this PlaceDetailsResult result)
        {

            string authKey = "AIzaSyDi9t-vPKn-xXNP9swFQk3wdeE5mU4IDj4";

            List<string> photoList = new List<string>();

            foreach (var p in result.Photos)
            {
                string photoRf = p.PhotoReference;
                string photoUrl = $"https://maps.googleapis.com/maps/api/place/photo?maxwidth=400&photoreference={photoRf}&key={authKey}";
                photoList.Add(photoUrl);
            }

            return photoList;
        }



        /// <summary>
        /// 按下搜尋鍵後隱藏一些按鍵
        /// </summary>
        /// <param name="picBox1"></param>
        /// <param name="picBox2"></param>
        /// <param name="txtAttr"></param>
        public static void HideControls(this PictureBox picBox, TextBox txtAttr)
        {
            picBox.Visible = false;
            txtAttr.Visible = false;
        }


        /// <summary>
        /// TextBox選字自動完成
        /// </summary>
        /// <param name="form"></param>
        /// <param name="filePath"></param>
        /// <param name="textBox"></param>
        public static void TextBoxAutoComplete(this Form form, string filePath, TextBox textBox)
        {
            AutoCompleteStringCollection autoData = new AutoCompleteStringCollection();//自動完成輸入
            bool folder = Directory.Exists(filePath);
            if (!folder)//如果此路徑不存在
            {
                //新創此路徑
                Directory.CreateDirectory($@"C:\Users\ching\source\repos\_A20200701 - 複製\temp");

            }

            string[] directories = Directory.GetDirectories(filePath);//得到此路徑下面的所有目錄=>單字資料夾


            foreach (var directory in directories)
            {
                DirectoryInfo folderN = new DirectoryInfo(directory);
                //Console.WriteLine(folderN.Name);
                autoData.Add(folderN.Name);//把資料夾名稱一一存入"自動完成輸入集合"
            }

            textBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox.AutoCompleteCustomSource = autoData;
        }


        public static string ReplaceSpecifierInString(this string str)
        {
            string[] specifier = { ",", ";", "/", "|", "~", "!", "@", "#", "$", "%", "^", "&", "*", "(", ")" };

            for (int i = 0; i < specifier.Length; i++)
            {
                if (str.Contains(specifier[i])) str.Replace(specifier[i], "_");
            }

            return str;
        }

        public static string TobeVisableLine(this Label label, List<FlowLayoutPanel> panelList)
        {
            /* 判斷哪個label被按下前，把全部的線先隱藏 */
            for (int i = 1; i < panelList.Count; i++)
            {
                panelList[i].Visible = false;
            }          

          /* 找到被按下的label是哪一個 */
            string sender = label.Tag.ToString();
            int whichDay = int.Parse(sender);

            for (int j = 0; j < panelList.Count; j++)
            {
                if ((whichDay - 1) != 0) panelList[0].Visible = false;             
                panelList[whichDay - 1].Visible = true;
            }

            return "Day"+sender; 

        }


     


    }
}

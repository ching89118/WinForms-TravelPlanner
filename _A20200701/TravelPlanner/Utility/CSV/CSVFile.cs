using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Data;
using Utility.GoogleMaps;
using System.Reflection;
using System.Collections.Generic;

namespace Utility.CSV
{

    public class CSVFile
    {

        /// <summary>
        /// PlanOverview的datagridview
        /// 儲存成Csv
        /// </summary>
        /// <param name="planName"></param>
        /// <param name="gridView"></param>
        public static void SavePlanOverviewToCsv(string planName, DataGridView gridView)
        {
            string completePath = $@"C:\Users\ching\source\repos\_A20200701 - 複製\TravelPlanner\{planName}\Overview\{planName}.csv";

            //先判斷CSV檔案路徑是否存在

            bool file = File.Exists(completePath);

            if (file)//存在，是否覆蓋
            {

                DialogResult Result = MessageBox.Show("PlanOverview CSV file has existed, Do you want to OVERRIDE?", "OVERRIDE[覆蓋]",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Result == DialogResult.OK)
                {
                    /* 呼叫CreateCSV方法 */
                    CSVFile.ExportDgvToCsv(planName, gridView);                  
                }
                else
                {
                    return;
                }

            }
            else//不存在，先建立路徑再輸出CSV
            {
                Directory.CreateDirectory($@"C:\Users\ching\source\repos\_A20200701 - 複製\TravelPlanner\{planName}\Overview");
                CSVFile.ExportDgvToCsv(planName, gridView);                
            }
        }



        /// <summary>
        /// 先檢查檔案路徑
        /// 再呼叫CreateCSV方法
        /// for單個景點
        /// </summary>
        /// <param name="place"></param>
        /// <param name="dataGridView"></param>
        /// <param name="label"></param>
        public static void SaveCSV(string place, Label label, PlaceDetails placeDetails)
        {
            string completePath = $@"C:\Users\ching\source\repos\_A20200701 - 複製\temp\{place}\{place}.csv";

            //先判斷CSV檔案路徑是否存在

            bool file = File.Exists(completePath);

            if (file)//存在，是否覆蓋
            {

                DialogResult Result = MessageBox.Show("Spot CSV file has existed, Do you want to OVERRIDE?", "OVERRIDE[覆蓋]",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Result == DialogResult.OK)
                {
                    /* 呼叫CreateCSV方法 */
                    CSVFile.CreateCSV(place, placeDetails);
                    label.Text = "Saved!";
                }
                else
                {
                    return;
                }

            }
            else//不存在，先建立路徑再輸出CSV
            {
                Directory.CreateDirectory($@"C:\Users\ching\source\repos\_A20200701 - 複製\temp\{place}");
                CSVFile.CreateCSV(place, placeDetails);
                label.Text = "Saved!";
            }

        }


        /// <summary>
        /// 將從Gmap撈到的資料寫成CSV檔案
        /// for單個景點
        /// </summary>
        /// <param name="place"></param>
        /// <param name="scannerDataGridView"></param>
        private static void CreateCSV(string place, PlaceDetails placeDetails)
        {

            string completePath = $@"C:\Users\ching\source\repos\_A20200701 - 複製\temp\{place}\{place}.csv";
            string delimiter = ",";
            string header = "";
            string context = "";

            StreamWriter csvStreamWriter = new StreamWriter(completePath, false, System.Text.Encoding.UTF8);

            /* 將PlaceDetails類別所有的屬性寫入CSV */
            PropertyInfo[] propertyInfos = placeDetails.GetType().GetProperties();

            foreach (var prop in propertyInfos)
            {
                header += prop.Name + delimiter;
            }
            header = header.Substring(0, header.Length - 1);

            csvStreamWriter.WriteLine(header);


            /* 將PlaceDetails屬性的"值"寫入CSV */

            context = $"{placeDetails.PlaceName},{placeDetails.Address},{placeDetails.Rating},{placeDetails.PriceLevel}," +
                $"{placeDetails.PhoneNumber},{placeDetails.OpeningPeriods}";

            csvStreamWriter.WriteLine(context);
            csvStreamWriter.Close();

        }






        /// <summary>
        ///PlanOverview的datagridview
        ///寫成Csv
        /// </summary>
        /// <param name="planName"></param>
        /// <param name="gridView"></param>
        private static void ExportDgvToCsv(string planName, DataGridView gridView)
        {
            string delimiter = ",";

            string completePath = $@"C:\Users\ching\source\repos\_A20200701 - 複製\TravelPlanner\{planName}\Overview\{planName}.csv";

            StreamWriter csvStreamWriter = new StreamWriter(completePath, false, System.Text.Encoding.UTF8);

            //output header data
            string strHeader = "";
            for (int i = 0; i < gridView.Rows.Count; i++)/* userControl屬性Columns*/
            {
                strHeader += gridView.Rows[i].HeaderCell.Value + delimiter;
            }
            strHeader = strHeader.Substring(0, strHeader.Length - 1);
            csvStreamWriter.WriteLine(strHeader);

            string strRowValue = "";
            //output rows data
            for (int j = 0; j < gridView.Rows.Count; j++)/* userControl屬性Rows*/
            {
                
                strRowValue += gridView.Rows[j].Cells[0].Value + delimiter;     
            }
            strRowValue = strRowValue.Substring(0, strRowValue.Length - 1);
            csvStreamWriter.WriteLine(strRowValue);

            csvStreamWriter.Close();
        }



        /// <summary>
        /// for PlaceAllData
        /// for Day1, Day2,........
        /// 寫成Csv完整檔
        /// </summary>
        /// <param name="placeAllList"></param>
        /// <param name="planName"></param>
        /// <param name="labelSender"></param>
        /// <param name="placeDetails"></param>
        public static void CSVGenerator(List<PlaceAllData> placeAllList, string planName, string labelSender, PlaceDetails placeDetails)
        {

            string delimiter = ",";
            string header = "";
            string context = "";

            string completePath = $@"C:\Users\ching\source\repos\_A20200701 - 複製\TravelPlanner\{planName}\{labelSender}\{labelSender}.csv";
            using (var file = new StreamWriter(completePath, false, System.Text.Encoding.UTF8))
            {
              
                /* 先得到PlaceDetails的屬性名稱 */
                PropertyInfo[] propertyInfos = placeDetails.GetType().GetProperties();

                foreach (var prop in propertyInfos)
                {
                    header += prop.Name + delimiter;
                }

                /* 再得到PlaceAllData的其他屬性名稱 */
                propertyInfos = placeAllList[0].GetType().GetProperties();
                header += string.Join(delimiter, propertyInfos.Where(i => i.Name != "Details").Select(i => i.Name));

                file.WriteLine(header);

                foreach (var allData in placeAllList)
                {                   
                    context +=
                        $"{allData.Details.PlaceName},{allData.Details.Address},{allData.Details.Rating},{allData.Details.PriceLevel}," +
                        $"{allData.Details.PhoneNumber},{allData.Details.OpeningPeriods},{allData.Details.PlaceId},{allData.StartTime}," +
                        $"{allData.EndTime},{allData.Cost}\r\n";
                    
                }

                context = context.Substring(0, context.Length - 2);
                file.WriteLine(context);


            }

        }




        /// <summary>
        /// 新增CSV資料列
        /// 附加景點到已存在的CSV
        /// 只附加景點列
        /// </summary>
        /// <param name="placeAllList"></param>
        /// <param name="planName"></param>
        /// <param name="labelSender"></param>
        /// <param name="placeDetails"></param>
        public static void CSVGeneratorFileExsited(List<PlaceAllData> placeAllList, string planName, string labelSender)
        {
           
            string context = "";

            string completePath = $@"C:\Users\ching\source\repos\_A20200701 - 複製\TravelPlanner\{planName}\{labelSender}\{labelSender}.csv";
            using (var file = new StreamWriter(completePath, true, System.Text.Encoding.UTF8))
            {

             
                foreach (var allData in placeAllList)
                {
                    context +=
                        $"{allData.Details.PlaceName},{allData.Details.Address},{allData.Details.Rating},{allData.Details.PriceLevel}," +
                        $"{allData.Details.PhoneNumber},{allData.Details.OpeningPeriods},{allData.Details.PlaceId},{allData.StartTime}," +
                        $"{allData.EndTime},{allData.Cost}\r\n";

                }

                context = context.Substring(0, context.Length - 2);
                file.WriteLine(context);


            }

        }




        /// <summary>
        /// for PlaceAllData
        /// for Day1, Day2,........
        /// 儲存成Csv完整檔
        /// </summary>
        /// <param name="labelSender"></param>
        /// <param name="planName"></param>
        /// <param name="placeAllList"></param>
        /// <param name="placeDetails"></param>
        /// <param name="label_saved2"></param>
        public static void SavePlaceAllDataToCsv(string labelSender, string planName, List<PlaceAllData> placeAllList, PlaceDetails placeDetails)
        {

            string completePath = string.Empty;

        

                completePath = $@"C:\Users\ching\source\repos\_A20200701 - 複製\TravelPlanner\{planName}\{labelSender}\{labelSender}.csv";
                //先判斷CSV檔案路徑是否存在

                bool file = File.Exists(completePath);

                if (file)//存在，是否附加
                {

                    DialogResult Result = MessageBox.Show($"{labelSender} CSV file has existed, Do you want to APPEND data row(s)?", "APPEND[附加資料列]",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (Result == DialogResult.Yes)
                    {

                        CSVFile.CSVGeneratorFileExsited(placeAllList, planName, labelSender);                        

                    }
                    else
                    {
                        CSVFile.CSVGenerator(placeAllList, planName, labelSender, placeDetails);                      
                    }

                }
                else//不存在，先建立路徑再輸出CSV
                {
                    Directory.CreateDirectory($@"C:\Users\ching\source\repos\_A20200701 - 複製\TravelPlanner\{planName}\{labelSender}");
                    CSVFile.CSVGenerator(placeAllList, planName, labelSender, placeDetails);                  

                }
        }



      
    }
}






using Google.Maps;
using Google.Maps.Places;
using Google.Maps.Places.Details;
using System;
using System.Windows.Forms;
using Utility.GoogleMaps;
using Utility.CSV;
using System.Drawing;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _A20200701
{
    public partial class Form1 : Form
    {
        string authKey = "AIzaSyDi9t-vPKn-xXNP9swFQk3wdeE5mU4IDj4";      
        FlowLayoutPanel flowLayoutPanel;
        DataGridView overviewsDGV;
        List<FlowLayoutPanel> panelList;
        List<PlaceOverviews> overviewsList;
        PlaceDetails placeDetails;  
        PlacesResult[] results;
        AddPlan addPlan;
        string fileName = "";
        int index;
        string labelSender;      
         GMapsNET mapsNET;
        double[] coordinate;     
        bool isRequary = false;
        Label[] labels;
        bool isSaved = false;


        #region 儲存單次搜尋勾選結果之變數
        List<PlaceDetails> detailsList;
        List<SpotControl> userControlList; 
        List<double[]> cooList; 
        List<string> keywordList;
        List<PlaceAllData> placeAllList;
        #endregion

       
     


        public Form1()
        {
            //always need to use YOUR_API_KEY for requests.  Do this in App_Start.
            GoogleSigned.AssignAllServices(new GoogleSigned(authKey));
            InitializeComponent();
            this.TabControls.Width = this.Width;         
            /* 不能修改儲存格 */
            dataGridView_plan.ReadOnly = true;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //picBox_saved.Visible = false;
            //picBox_saved2.Visible = false;

            #region 隱藏按下picturbox_Search前不能出現的控制項

            btn_requary.Visible = false;
            btn_save.Visible = false;
            btn_save.Enabled = false;

            #endregion

            #region 隱藏Day1....與下面的一條線，按下相對應的label才會出現
            panelList = new List<FlowLayoutPanel>()
            { flowLP_line1, flowLP_line2, flowLP_line3, flowLP_line4, flowLP_line5, flowLP_line6, flowLP_line7 };
            labels = new Label[7] { lb_day1, lb_day2, lb_day3, lb_day4, lb_day5, lb_day6, lb_day7 };         

            for (int i = 0; i < labels.Length; i++)
            {
                labels[i].Visible = false;
            }

            /* 一開始Day1, Day2,....不可按 */
            for (int i = 0; i < labels.Length; i++)
            {
                labels[i].Enabled = false;
            }
          


            for (int j = 0; j <panelList.Count; j++)
            {
                panelList[j].Visible = false;
            }

            #endregion

            #region datagridview_plan 新增列


            /* 把儲存格的值設成DateTime */
            index = dataGridView_plan.Rows.Add();


            DataGridViewRow row2 = new DataGridViewRow();
            /* datagridviewRow新增儲存格 */
            DataGridViewTextBoxCell textBoxCell1 = new DataGridViewTextBoxCell();
            textBoxCell1.Value = "旅遊計畫簡介";
            row2.Cells.Add(textBoxCell1);
            dataGridView_plan.Rows.Add(row2);

            DataGridViewRow row3 = new DataGridViewRow();
            /* datagridviewRow新增儲存格 */
            DataGridViewTextBoxCell textBoxCell2 = new DataGridViewTextBoxCell();
            textBoxCell2.Value = "備註";
            row3.Cells.Add(textBoxCell2);
            dataGridView_plan.Rows.Add(row3);

            #endregion



          


            //////取得地圖圖片
            //StaticMap stM = new StaticMap("六合夜市");

            ////pictureBox1.Image = stM.GenerateMap();

            //// 呼叫GenerateMapUrl方法進一步加載圖片
            //string mapUrl = stM.GenerateMapUrl(stM.Center);
            //picBox_searchPDetails.Load(mapUrl);



        }
        //webBrowser1.Navigate("https://maps.googleapis.com/maps/api/place/nearbysearch/json?location=48.830216,2.806147&rankby=distance&name=franprix&key=AIzaSyDi9t-vPKn-xXNP9swFQk3wdeE5mU4IDj4");






        /// <summary>
        /// 點擊textBox清空文字(Places)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_SearchAttr_Click(object sender, EventArgs e)
        {
            txt_SearchAttr.Text = string.Empty;
        }




        /// <summary>
        /// 按下requary按鍵
        /// 隱藏的控件再次出現(Places)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_requary_Click(object sender, EventArgs e)
        {

            isRequary = true;
            tabPage_addSpot.Controls.Remove(flowLayoutPanel);
            txt_SearchAttr.Visible = true;
            picBox_searchSinglePDetails.Visible = true;
        }




        /// <summary>
        /// 單一/相似目的地搜尋(Places)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picBox_placeSearch_Click(object sender, EventArgs e)
        {

            /* 呼叫隱藏控件的控件的擴充方法 */
            picBox_searchSinglePDetails.HideControls(txt_SearchAttr);

            btn_requary.Visible = true;
            btn_save.Visible = true;

            /* 放datagridview */
            flowLayoutPanel = new FlowLayoutPanel();
            flowLayoutPanel.Width = tabPage_addSpot.Width;
            flowLayoutPanel.Height = tabPage_addSpot.Height;
            flowLayoutPanel.FlowDirection = FlowDirection.TopDown;

            /* 放景點概覽的DGV*/
            overviewsDGV = new DataGridView();
            overviewsDGV.Size = new Size(933, tabPage_addSpot.Height);
            overviewsDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            overviewsDGV.DataBindingComplete += OverviewsDGV_DataBindingComplete;
            overviewsDGV.CellClick += OverviewsDGV_CellClick;

            overviewsList = new List<PlaceOverviews>();

            PlaceAPI.Keyword = txt_SearchAttr.Text;
            /* API */
            results = PlaceAPI.GetPlaceResults(PlaceAPI.Keyword);

            foreach (var res in results)
            {

                PlaceOverviews placeOverviews = new PlaceOverviews();
                /* set值 *//* 得到各景點概覽 */
                placeOverviews.SetOverviewsValues(res, placeOverviews);
                overviewsList.Add(placeOverviews);
            }

            /* 資料繫結 */
            overviewsDGV.DataSource = overviewsList;

            /* 少了它輸出的CSV是空的 */
            flowLayoutPanel.Controls.Add(overviewsDGV);

            this.tabPage_addSpot.Controls.Add(flowLayoutPanel);

        }




        /// <summary>
        /// 預設用戶點選景點後
        /// 可以按save鍵
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OverviewsDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btn_save.Enabled = true;
        }



        /// <summary>
        /// cell異動/ 應使用此event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OverviewsDGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            overviewsDGV.Columns[0].HeaderText = "Name";
            overviewsDGV.Columns[1].HeaderText = "Address";
            overviewsDGV.Columns[2].HeaderText = "Rating";
            overviewsDGV.Columns[3].Visible = false;

            DataGridViewColumn ckColumn = new DataGridViewCheckBoxColumn();
            //ckColumn.HeaderText = "Selected";
            overviewsDGV.Columns.Insert(0, ckColumn);

        }




        /// <summary>
        /// 將選中的景點/ 擷取Name與PlaceId/ 傳到Gmap搜尋細節資訊
        /// 單一景點資訊物件傳入方法，再輸出CSV        
        /// placeDetail物件加入detailsList景點庫
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_save_Click(object sender, EventArgs e)
        {
            
            string placeId = "";
            isSaved = true;

            
            detailsList = new List<PlaceDetails>();

                for (int i = 0; i < overviewsDGV.RowCount; i++)
                {
                    /* 若找到checkBox被勾選的那個儲存格 */
                    if (overviewsDGV.Rows[i].Cells[0].Value != null && overviewsDGV.Rows[i].Cells[0].Value.Equals(true))
                    {

                        /* 取得景點名稱 、PlaceId */
                        PlaceAPI.Keyword = overviewsDGV.Rows[i].Cells[1].Value.ToString();
                        placeId = overviewsDGV.Rows[i].Cells[4].Value.ToString();

                        fileName = txt_SearchAttr.Text + "_" + PlaceAPI.Keyword;

                        /* 取得細節資訊，需傳入PlaceId */
                        PlaceDetailsResult detailsResult = PlaceAPI.GetPlaceDetails(placeId);
                        placeDetails = new PlaceDetails();

                        /* set值  */
                        placeDetails.SetDetailsValues(detailsResult, placeDetails);

                    /* datatable新增至我的景點庫 */
                    detailsList.Add(placeDetails);


                        /* 儲存CSV檔案 */
                        CSVFile.SaveCSV(fileName, label_saveSuccess, placeDetails);

                    }

                }

        }




        /// <summary>
        /// 優先判斷上一個操作是否儲存成Csv
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lb_day1_Click(object sender, EventArgs e)
        {
          
            Label label = (Label)sender;

            /* 擴充方法，判斷此次觸發事件sender是哪一個*/
            labelSender = label.TobeVisableLine(panelList);


            /* 讀檔前先判斷路徑是否存在，若不存在，請用戶先新增景點 */
            var path = $@"C:\Users\ching\source\repos\_A20200701 - 複製\TravelPlanner\{addPlan.PlanName}\{labelSender}\{labelSender}.csv";
            bool file = File.Exists(path);

            if (!file && detailsList.Count == 0)
            {
                MessageBox.Show("請先在Places頁面搜尋並選擇景點！");

                /* 將flowlayoutpanel清空 */
                this.detailsPanel.Controls.Clear();
                return;
            }         
            else
            {

                #region ReadLines，將資料自動生成至新的userControl

                /* 將flowlayoutpanel清空 */
                this.detailsPanel.Controls.Clear();

                List<string> lines = File.ReadLines(path).ToList();
                

                for (int i = 1; i <lines.Count ; i++)
                {
                    string[] result = lines[i].Split(',');

                    PlaceDetails placeDetails2 = new PlaceDetails();
                    placeDetails2.PlaceName = result[0];
                    placeDetails2.Address = result[1];
                    placeDetails2.Rating = float.Parse(result[2]);
                    placeDetails2.PriceLevel = result[3];
                    placeDetails2.PhoneNumber = result[4];
                    placeDetails2.OpeningPeriods = result[5];        

                    FlowLayoutPanel controlPanel = new FlowLayoutPanel();
                    controlPanel.Width = this.flowLayoutPanel1.Width;
                    
                    SpotControl spotControl2 = new SpotControl();
                    spotControl2.Width = controlPanel.Width;
                    spotControl2.BringToFront();
                    spotControl2.DataSource = new List<PlaceDetails>() { placeDetails2};
                    spotControl2.StartTime = result[6];
                    spotControl2.EndTime = result[7];
                    spotControl2.Cost = result[8];
                    

                    controlPanel.Controls.Add(spotControl2);
                    this.detailsPanel.Controls.Add(controlPanel);
                }
                #endregion

            }
        }





        /// <summary>
        /// My Itinerary頁面被點選後要做的事
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabControls_Selected(object sender, TabControlEventArgs e)
        {


            #region 關於 e
            /* EventArgs e:就是 event source，當TabControls被點選後要做什麼事情來響應 */
            /* 首先我們要必須取得與此事件相關的信息：是TabControls中哪個TabPage被選中了？ */
            #endregion

          

            if (e.TabPage.Text.Equals("My Itinerary"))
            {
                // init
                this.TabControls.Width = this.Width;
                this.flowLayoutPanel_myItinerary.Width = this.TabControls.Width;
                this.flowLayoutPanel1.Width = this.flowLayoutPanel_myItinerary.Width / 2;
                this.flowLayoutPanel2.Width = this.flowLayoutPanel_myItinerary.Width / 2;
                this.detailsPanel.Width = this.flowLayoutPanel1.Width;
                mapsNET = new GMapsNET(flowLayoutPanel2.Width, flowLayoutPanel2.Height);


                if (isRequary==false)
                {
                    addPlan = new AddPlan();
                    addPlan.ShowDialog();
                    #region 將AddPlan表單編輯的資訊匯入
                    /* 匯入計畫名稱 */
                    dataGridView_plan.Rows[index].Cells[0].Value = addPlan.PlanName;
                    /* 匯入起訖日期 */
                    dataGridView_plan.Rows[index].Cells[1].Value =
                    addPlan.StartTime.ToString("dd/ MM/ yyyy") + " - " + addPlan.EndTime.ToString("dd/ MM/ yyyy");

                    #region 天數差計算
                    int days = addPlan.EndTime.DayOfYear - addPlan.StartTime.DayOfYear;


                    for (int i = 0; i < days + 1; i++)
                    {
                        labels[i].Visible = true;
                    }


                    #endregion

                    /* 匯入計畫簡介 */
                    dataGridView_plan.Rows[1].Cells[1].Value = addPlan.PlanOverView;
                    /* 匯入計畫備註 */
                    dataGridView_plan.Rows[2].Cells[1].Value = addPlan.OptionInfo;
                    #endregion
                                       
                  
                    panelList[0].Visible = true;
                }
                isRequary = false;



                /* 考量用戶在未經選取景點時，就切至此頁面 */
                if (detailsList == null)
                {
                    MessageBox.Show("請先在Places頁面搜尋並選擇景點！");
                }
                else
                {
                    #region 將每個景點自動生成單一UserControl到flowlayoutpanel

                    userControlList = new List<SpotControl>();
                    cooList = new List<double[]>();
                    keywordList = new List<string>();
                    placeAllList = new List<PlaceAllData>();

                        foreach (var placeDetails in detailsList)
                        {
                            /* 為了只裝1個placeDetails而存在 */
                            List<PlaceDetails> details = new List<PlaceDetails>() { placeDetails };                            

                            /* 每個placeDetails對應1個UserControl */
                            FlowLayoutPanel controlPanel = new FlowLayoutPanel();
                            controlPanel.Width = this.flowLayoutPanel1.Width;
                            SpotControl spotControl = new SpotControl();

                            spotControl.Width = controlPanel.Width;
                            spotControl.BringToFront();


                            /* 資料繫結1個景點 */
                            spotControl.DataSource = details;



                            //取得座標位置
                            Coordinate coo = new Coordinate(placeDetails.Address);
                            coordinate = coo.GetCoordinate();
                            Console.WriteLine(coordinate[0]);//緯度
                            Console.WriteLine(coordinate[1]);//經度
                                                             //24.7097995,121.8040447
                                                             //22.6786156,120.485006
                                                             //23.5563014,119.5942633


                            cooList.Add(coordinate);
                            keywordList.Add(placeDetails.PlaceName);

                            /* 在Form類別觸發UerControl裡面的PictureBox的Click事件 */
                            spotControl.PictureBoxClick += SpotControl_PictureBoxClick;


                            /* 為了將textBox設值，需要儲存spotControl到List */
                            userControlList.Add(spotControl);                       
                         

                            /* 生成PlaceAllData物件作為輸出CSV的依據 */

                            #region PlaceAllData設值
                            PlaceAllData allData = new PlaceAllData();
                            allData.details = placeDetails;
                            #endregion

                            /* PlaceAllData物件放入List */
                            placeAllList.Add(allData);

                            /* 勾選多個景點就有多個userControl */
                            controlPanel.Controls.Add(spotControl);
                            this.detailsPanel.Controls.Add(controlPanel);
                        }


                    flowLayoutPanel2.Controls.Add(mapsNET.getMap());

                    #endregion                  

                }
            }         
        }





        /// <summary>
        /// 在地圖上放圖標
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SpotControl_PictureBoxClick(object sender, EventArgs e)
        {         
                      
                for (int j = 0; j < userControlList.Count; j++)
                {                    
                    if (sender == userControlList[j])                    
                        mapsNET.AddMaker(cooList[j][0], cooList[j][1], keywordList[j]);                    
                }      
        }




        private void dataGridView_plan_Click(object sender, EventArgs e)
        {
            /* 每次重填旅遊計畫名稱前要先將Day1,Day2,....藏起來 */
            /* Day1下面那條線預設顯示 */
            flowLP_line1.Visible = true;

            for (int i = 0; i < labels.Length; i++) labels[i].Visible = false;

            addPlan = new AddPlan();
            addPlan.ShowDialog();

            #region 將AddPlan表單編輯的資訊匯入
            /* 匯入計畫名稱 */
            dataGridView_plan.Rows[index].Cells[0].Value = addPlan.PlanName;
            /* 匯入起訖日期 */
            dataGridView_plan.Rows[index].Cells[1].Value =
            addPlan.StartTime.ToString("dd/ MM/ yyyy") + " - " + addPlan.EndTime.ToString("dd/ MM/ yyyy");

            #region 天數差計算
            int days = addPlan.EndTime.DayOfYear - addPlan.StartTime.DayOfYear;
                      
            /* 選擇完旅遊期間後顯示Day1,Day2,.....*/
            for (int i = 0; i < days+1; i++) labels[i].Visible = true;

            #endregion

            /* 匯入計畫簡介 */
            dataGridView_plan.Rows[1].Cells[1].Value = addPlan.PlanOverView;
            /* 匯入計畫備註 */
            dataGridView_plan.Rows[2].Cells[1].Value = addPlan.OptionInfo;
            #endregion

           
        }




        private void 存檔ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView_plan.Rows[index].Cells[0].Value.ToString()==string.Empty)
            {
                MessageBox.Show("旅遊計畫名稱不能為空！");
                return;
            }
            else CSVFile.SavePlanOverviewToCsv(addPlan.PlanName, dataGridView_plan);


            #region 將其他PlaceAllData的屬性設值


            for (int i = 0; i < placeAllList.Count; i++)
            {
                placeAllList[i].StartTime = userControlList[i].StartTime;
                placeAllList[i].EndTime = userControlList[i].EndTime;
                placeAllList[i].Cost = userControlList[i].Cost;

            }


            #endregion

            string[] dayArray = new string[7] { "Day1", "Day2", "Day3", "Day4", "Day5", "Day6", "Day7" };

            /* 若用戶未選擇Day的任一天則預設Day1 */
           string completePath = $@"C:\Users\ching\source\repos\_A20200701 - 複製\TravelPlanner\{addPlan.PlanName}";
            string[] directories = Directory.GetDirectories(completePath);

            for (int i = 0; i < directories.Length; i++)
            {
                if (directories[i]==null)
                {
                    labelSender ="Day1";
                    CSVFile.SavePlaceAllDataToCsv(labelSender, addPlan.PlanName, placeAllList, placeDetails, label_saved2);
                    labels[0].Enabled = true;
                    labels[1].Enabled = true;
                }
                DirectoryInfo folder = new DirectoryInfo(directories[i]);
                if (folder.Name == dayArray[i])
                {
                    labelSender = dayArray[i];
                    CSVFile.SavePlaceAllDataToCsv(labelSender, addPlan.PlanName, placeAllList, placeDetails, label_saved2);

                    int idx = Convert.ToInt32(labelSender.Substring(labelSender.Length - 1, 1));
                    labels[idx - 1].Enabled = true;
                    labels[idx].Enabled = true;
                }
            }
            

            /* 存檔後就清空List的資料 */
            detailsList.Clear();         
           
        }





    
    }
}










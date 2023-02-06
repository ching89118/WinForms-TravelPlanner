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
using System.Globalization;
using Microsoft.VisualBasic.ApplicationServices;
using GMap.NET;

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
        PlaceDetails placeDetails2;
        PlacesResult[] results;
        AddPlan addPlan;
        string fileName = "";    
        string labelSender;     
         GMapsNET mapsNET;
        double[] coordinate;
        Label[] labels;
        bool isSaved = false;
        FlowLayoutPanel controlPanel;
        string planName = "";
        bool doNotSaved = false;
       
        #region 物件替換用
        List<SpotControl> usersList;
        PlaceDetails pd;
        List<PlaceDetails> pdList;
        List<PlaceAllData> adList;
        List<double[]> coorList;
        List<string> keyList;
        #endregion



        #region 儲存單次搜尋勾選結果之變數
        List<PlaceDetails> detailsList;
        List<SpotControl> userControlList;
        List<FlowLayoutPanel> controlPanelList;
        List<double[]> cooList;
        List<double[]> cooList2;
        List<string> keywordList;
        List<string> placeIdList;
        List<string> keywordList2;
        List<string> placeIdList2;
        List<PlaceAllData> placeAllList;
        List<PlaceDetails> detailsList2;
        List<PlaceAllData> placeAllList2;
        List<SpotControl> userControlList2;
        #endregion





        public Form1()
        {
            //always need to use YOUR_API_KEY for requests.  Do this in App_Start.
            GoogleSigned.AssignAllServices(new GoogleSigned(authKey));
            InitializeComponent();
            this.TabControls.Width = this.Width;         
            /* 不能修改儲存格 */
            dataGridView_plan.ReadOnly = true;

            addPlan = new AddPlan();
            addPlan.Hide();

            picBox_newPlan.Visible = false;

        }

        private void Form1_Load(object sender, EventArgs e)
        {          

            #region 隱藏按下picturbox_Search前不能出現的控制項

            btn_requary.Visible = false;
            btn_save.Visible = false;
            btn_save.Enabled = false;

            #endregion

            #region 隱藏Day1....與下面的一條線
            panelList = new List<FlowLayoutPanel>()
            { flowLP_line1, flowLP_line2, flowLP_line3, flowLP_line4, flowLP_line5, flowLP_line6, flowLP_line7 };
            labels = new Label[7] { lb_day1, lb_day2, lb_day3, lb_day4, lb_day5, lb_day6, lb_day7 };

            /* Day1, Day2, Day3....全部隱藏 */
            /* 隱藏全部Day1, Day2,...下面的一條線 */   
            for (int i = 0; i < labels.Length; i++)
            {
                labels[i].Visible = false;
                panelList[i].Visible = false;
            }

            #endregion

            #region datagridview_plan 新增列
            DataGridViewColumn column1 = new DataGridViewTextBoxColumn();
            dataGridView_plan.Columns.Add(column1);
            
            DataGridViewRow row1 = new DataGridViewRow();  
            row1.HeaderCell.Value = "旅遊計畫名稱";
            DataGridViewTextBoxCell textBoxCell1 = new DataGridViewTextBoxCell();
            row1.Cells.Add(textBoxCell1);
            dataGridView_plan.Rows.Add(row1);

            DataGridViewRow row2 = new DataGridViewRow();
            row2.HeaderCell.Value = "旅遊期間(yyyy-MM-dd)";
            DataGridViewTextBoxCell textBoxCell2 = new DataGridViewTextBoxCell();
            row2.Cells.Add(textBoxCell2);
            dataGridView_plan.Rows.Add(row2);

            DataGridViewRow row3 = new DataGridViewRow();
            row3.HeaderCell.Value = "旅遊計畫簡介";
            DataGridViewTextBoxCell textBoxCell3 = new DataGridViewTextBoxCell();
            row3.Cells.Add(textBoxCell3);
            dataGridView_plan.Rows.Add(row3);

            DataGridViewRow row4 = new DataGridViewRow();
            row4.HeaderCell.Value = "備註";
            DataGridViewTextBoxCell textBoxCell4 = new DataGridViewTextBoxCell();
            row4.Cells.Add(textBoxCell4);
            dataGridView_plan.Rows.Add(row4);
            #endregion          

        }
     






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

            /* overviewsDGV的dataSource資料來源 */
            overviewsList = new List<PlaceOverviews>();

            #region 取得Google API景點的概覽資訊(overviews)
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
            #endregion

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
            overviewsDGV.Columns[3].Visible = false;//隱藏PlaceId欄位

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

            #region 被勾選的景點進一步搜尋詳細資訊(details)，儲存成Csv
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
            #endregion
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

           
            #region 取得planName(沒有填寫addPlan的情況)
            if (dataGridView_plan.Rows[0].Cells[0].Value != null)
            {
                if (addPlan.PlanName == string.Empty) planName = dataGridView_plan.Rows[0].Cells[0].Value.ToString();
                else planName = addPlan.PlanName;
            } 
            #endregion


            /* 讀檔前先判斷路徑是否存在，若不存在，請用戶先新增景點 */
            var path = $@"C:\Users\ching\source\repos\_A20200701 - 複製\TravelPlanner\{planName}\{labelSender}\{labelSender}.csv";
            bool file = File.Exists(path);

            if (!file)
            {
                    if(detailsList != null && detailsList.Count==0)
                         MessageBox.Show("請先在Places頁籤搜尋並選擇景點！");

                /* 將flowlayoutpanel清空 */
                this.detailsPanel.Controls.Clear();
                return;
            }         
            else
            {
                #region ReadLines讀檔，將資料自動生成至新的userControl

                /* 將flowlayoutpanel清空 */
                this.detailsPanel.Controls.Clear();
                this.flowLayoutPanel2.Controls.Clear();

                mapsNET = new GMapsNET(flowLayoutPanel2.Width, flowLayoutPanel2.Height);

                List<string> lines = File.ReadLines(path).ToList();
                detailsList2 = new List<PlaceDetails>();
                placeAllList2=new List<PlaceAllData>();
                userControlList2 = new List<SpotControl>();
                cooList2 = new List<double[]>();
                keywordList2 = new List<string>();
                placeIdList2 = new List<string>();

                for (int i = 1; i <lines.Count ; i++)
                {
                    string[] result = lines[i].Split(',');
                    /***************************************/
                    placeDetails2 = new PlaceDetails();
                    placeDetails2.PlaceName = result[0];
                    placeDetails2.Address = result[1];
                    placeDetails2.Rating = float.Parse(result[2]);
                    placeDetails2.PriceLevel = result[3];
                    placeDetails2.PhoneNumber = result[4];
                    placeDetails2.OpeningPeriods = result[5];
                    placeDetails2.PlaceId = result[6];
                    detailsList2.Add(placeDetails2);
                    /***************************************/
                    FlowLayoutPanel controlPanel2 = new FlowLayoutPanel();
                    controlPanel2.Width = this.flowLayoutPanel1.Width;
                    
                    SpotControl spotControl2 = new SpotControl();
                    spotControl2.Width = controlPanel2.Width;
                    spotControl2.BringToFront();
                    spotControl2.DataSource = new List<PlaceDetails>() { placeDetails2};
                    spotControl2.StartTime = result[7];
                    spotControl2.EndTime = result[8];
                    spotControl2.Cost = result[9];


                    //取得座標位置
                    Coordinate coo = new Coordinate(placeDetails2.Address);
                    coordinate = coo.GetCoordinate();

                    cooList2.Add(coordinate);
                    keywordList2.Add(placeDetails2.PlaceName);
                    placeIdList2.Add(placeDetails2.PlaceId);

                    /* 在Form類別觸發UerControl裡面的PictureBox的Click事件 */
                    spotControl2.PictureBoxClick += SpotControl_PictureBoxClick;
                    spotControl2.PictureBox_DelClick += SpotControl_PictureBox_DelClick;
                    spotControl2.PictureBox_RouteClick += SpotControl_PictureBox_RouteClick;

                    userControlList2.Add(spotControl2);
                    /***************************************/
                    PlaceAllData AllData2 = new PlaceAllData();
                    AllData2.Details = placeDetails2;                   
                    placeAllList2.Add(AllData2);
                    /***************************************/

                    controlPanel2.Controls.Add(spotControl2);
                    this.detailsPanel.Controls.Add(controlPanel2);
                }
                #endregion
                flowLayoutPanel2.Controls.Add(mapsNET.getMap());
            }
        }





        /// <summary>
        /// My Itinerary頁面被點選後要做的事
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabControls_Selected(object sender, TabControlEventArgs e)
        {
            label_saveSuccess.Text="";
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
                picBox_newPlan.Visible = true;


                /* 將flowlayoutpanel清空(Day?景點資料已存檔) */
                this.detailsPanel.Controls.Clear();
                this.flowLayoutPanel2.Controls.Clear();

                /* 考量用戶在未經選取景點時，就切至此頁面 */
                if (detailsList==null)
                {                    
                        MessageBox.Show("請先在Places頁籤搜尋並選擇景點！");
                        return;  
                }
                else
                {
                    label1.Text = "若編輯完成，請先點選景點資料要儲存到哪個Day，再點選Places頁籤存檔！";
                    detailsPanel.Controls.Add(label1);

                    #region 將每個景點自動生成單一UserControl到flowlayoutpanel  
                    
                    userControlList = new List<SpotControl>();
                    cooList = new List<double[]>();
                    keywordList = new List<string>();
                    placeIdList = new List<string>();
                    placeAllList = new List<PlaceAllData>();
                    controlPanelList = new List<FlowLayoutPanel>();

                    foreach (var placeDetails in detailsList)
                    {

                        /* 每個placeDetails對應1個UserControl */
                        controlPanel = new FlowLayoutPanel();
                        controlPanel.Width = this.flowLayoutPanel1.Width;
                        SpotControl spotControl = new SpotControl();

                        spotControl.Width = controlPanel.Width;
                        spotControl.BringToFront();


                        /* 資料繫結1個景點 *//* 為了只裝1個placeDetails而存在 */
                        spotControl.DataSource = new List<PlaceDetails>() { placeDetails };


                        //取得座標位置
                        Coordinate coo = new Coordinate(placeDetails.Address);
                        coordinate = coo.GetCoordinate();

                        cooList.Add(coordinate);
                        keywordList.Add(placeDetails.PlaceName);
                        placeIdList.Add(placeDetails.PlaceId);

                        /* 在Form類別觸發UerControl裡面的PictureBox的Click事件 */
                        spotControl.PictureBoxClick += SpotControl_PictureBoxClick;
                        spotControl.PictureBox_DelClick += SpotControl_PictureBox_DelClick;
                        spotControl.PictureBox_RouteClick += SpotControl_PictureBox_RouteClick;

                        /* 為了將textBox設值，需要儲存spotControl到List */
                        userControlList.Add(spotControl);


                        /* 生成PlaceAllData物件作為輸出CSV的依據 */

                        #region PlaceAllData設值
                        PlaceAllData allData = new PlaceAllData();
                        allData.Details = placeDetails;
                        #endregion

                        /* PlaceAllData物件放入List */
                         placeAllList.Add(allData);

                        /* 勾選多個景點就有多個userControl */
                        controlPanel.Controls.Add(spotControl);
                        this.detailsPanel.Controls.Add(controlPanel);
                        controlPanelList.Add(controlPanel);
                    }


                 

                    #endregion 
                }


                if (isSaved)
                {
                    
                    if (labelSender == null)
                    {
                        if (dataGridView_plan.Rows[0].Cells[0].Value==null)
                        {
                            addPlan.ShowDialog();
                            #region 將AddPlan表單編輯的資訊匯入
                            /* 匯入計畫名稱 */
                            dataGridView_plan.Rows[0].Cells[0].Value = addPlan.PlanName;
                            /* 匯入起訖日期 */
                            dataGridView_plan.Rows[1].Cells[0].Value =
                            addPlan.StartTime.ToString("yyyy-MM-dd") + "~" + addPlan.EndTime.ToString("yyyy-MM-dd");

                            #region 天數差計算
                            int days = addPlan.EndTime.DayOfYear - addPlan.StartTime.DayOfYear;

                            for (int i = 0; i < days + 1; i++)
                            {
                                labels[i].Visible = true;
                            }


                            #endregion

                            /* 匯入計畫簡介 */
                            dataGridView_plan.Rows[2].Cells[0].Value = addPlan.PlanOverView;
                            /* 匯入計畫備註 */
                            dataGridView_plan.Rows[3].Cells[0].Value = addPlan.OptionInfo;
                            #endregion

                        }
                    }
                  
                }

                #region 取得planName(沒有填寫addPlan的情況)
                if (dataGridView_plan.Rows[0].Cells[0].Value != null)
                {
                    if (addPlan.PlanName == string.Empty) planName = dataGridView_plan.Rows[0].Cells[0].Value.ToString();
                    else planName = addPlan.PlanName;
                }
                #endregion

                flowLayoutPanel2.Controls.Add(mapsNET.getMap());


            }


          

            /* 按Places頁籤自動存檔 */
            if (e.TabPage.Text.Equals("Places"))
            {
                #region 卡控Day1, Day2,.....存檔

                if (isSaved || dataGridView_plan.Rows[0].Cells[0].Value!=null)
                {
             

                if (dataGridView_plan.Rows[0].Cells[0].Value.ToString() == string.Empty)
                {
                    MessageBox.Show("旅遊計畫名稱不能為空！");
                    return;
                }
                else CSVFile.SavePlanOverviewToCsv(planName, dataGridView_plan);

                    #region 將其他PlaceAllData的屬性設值

                    if (placeAllList!=null && placeAllList.Count!=0)
                    { 
                        for (int i = 0; i < placeAllList.Count; i++)
                        {
                            placeAllList[i].StartTime = userControlList[i].StartTime;
                            placeAllList[i].EndTime = userControlList[i].EndTime;
                            placeAllList[i].Cost = userControlList[i].Cost;

                        }
                    }
                    else
                    {
                       
                        if(placeAllList2 == null) return;
                       else if (placeAllList2.Count == 0) return;
                        for (int j = 0; j < placeAllList2.Count; j++)
                        {
                            placeAllList2[j].StartTime = userControlList2[j].StartTime;
                            placeAllList2[j].EndTime = userControlList2[j].EndTime;
                            placeAllList2[j].Cost = userControlList2[j].Cost;
                        }
                    }


                    #endregion

                    #region 物件替換                    
                    if (placeDetails == null) pd = placeDetails2;                 
                    else pd = placeDetails;
                  
                    if (placeAllList == null) adList = placeAllList2;                  
                    else if (placeAllList.Count == 0) adList = placeAllList2;
                    else adList = placeAllList;
                    #endregion

                    if (labelSender == null)
                    {
                        MessageBox.Show("請先點選景點資料要儲存到哪個Day，再點選Places頁籤存檔！");
                        return;
                    }              
                    else if (doNotSaved)
                    {
                        doNotSaved = false;
                        return;
                    }
                    else CSVFile.SavePlaceAllDataToCsv(labelSender, planName, adList, pd);
                MessageBox.Show($"{labelSender}景點資料已存檔");
                
                }
                /* 存檔後就清空List的資料 */
               if(detailsList!=null) detailsList.Clear();
                detailsPanel.Controls.Clear();
                /* 改回為預設 */
                isSaved = false;

                #endregion
            }


            if (e.TabPage.Text.Equals("My Trips"))
            {

                FlowLayoutPanel btnsPanel = new FlowLayoutPanel();
                btnsPanel.Width = tabPage_showPlans.Width;
                btnsPanel.Height = tabPage_showPlans.Height;
                btnsPanel.FlowDirection = FlowDirection.TopDown;
                btnsPanel.AutoScroll = true;
               

                #region 旅遊計畫名稱目錄資料夾=>自動生成按鈕
                string[] directories = Directory.GetDirectories($@"C:\Users\ching\source\repos\_A20200701 - 複製\TravelPlanner");
                foreach (var directory in directories)
                {
                    DirectoryInfo folder = new DirectoryInfo(directory);
                    DateTime createTime = File.GetCreationTime(directory);
                    Button btn = new Button();
                    btn.AutoSize = true;
                    btn.Text = $"旅遊計畫名稱：{folder.Name}\r\n建立日期：{createTime.ToString()}";
                    btn.Tag = folder.Name;
                    btn.Click += Btn_Click;
                    btn.DoubleClick += Btn_DoubleClick;//Delete plan

                    PictureBox picBox = new PictureBox();
                    picBox.Width = 200;
                    picBox.Height = 130;
                    picBox.SizeMode = PictureBoxSizeMode.StretchImage;

                    string path = $@"C:\Users\ching\source\repos\_A20200701 - 複製\TravelPlanner\{folder.Name}\image\{folder.Name}.jpg";

                    //按下搜尋，顯示圖片：先判斷檔案是否存在才能取得
                    bool file = File.Exists(path);//需要完整路徑   
                    if (file)
                    {
                        Bitmap bitmap = new Bitmap(path);
                        picBox.Image = bitmap;
                    }
                    else
                    {
                        MessageBox.Show("IMG File is not existed.");
                    }
                  
                    btnsPanel.Controls.Add(picBox);
                    btnsPanel.Controls.Add(btn);
                } 
                #endregion

                tabPage_showPlans.Controls.Add(btnsPanel);
            }
        }





        private void SpotControl_PictureBox_RouteClick(object sender, EventArgs e)
        {
            #region 物件替換
            List<string> placeIDs;
            if (placeIdList == null) placeIDs = placeIdList2;
           else if(placeIdList.Count==0) placeIDs = placeIdList2;
            else placeIDs = placeIdList;

            if (userControlList == null) usersList = userControlList2;
            else if (userControlList.Count == 0) usersList = userControlList2;
            else usersList = userControlList;
            #endregion

            Button reRoute = new Button();
            reRoute.AutoSize = true;
            reRoute.Text = "移除路徑";
            reRoute.Click += DelRoute_Click;
            reRoute.Anchor = AnchorStyles.Bottom;
            this.flowLayoutPanel_myItinerary.Controls.Add(reRoute);


            for (int j = 0; j < usersList.Count; j++)
            {
                if (sender == usersList[j])
                {
                    if (j == placeIDs.Count - 1) return;
                    else
                    {
                        mapsNET.getRoute(placeIDs[j], placeIDs[j + 1]);
                        return;
                    }
                }

            } 
        }






        private void DelRoute_Click(object sender, EventArgs e)
        {
            mapsNET.removeRoute();
        }





        /// <summary>
        /// 刪除旅遊計畫
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_DoubleClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }






        /// <summary>
        /// PlanOverview/ Day?,......
        /// Csv檔案讀檔
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
           

            #region PlanOverview Csv讀檔
            string path = $@"C:\Users\ching\source\repos\_A20200701 - 複製\TravelPlanner\{btn.Tag}\Overview\{btn.Tag}.csv";
            List<string> lines = File.ReadLines(path).ToList();
            string[] line = lines[1].Split(',');

            dataGridView_plan.Rows[0].Cells[0].Value = line[0];
            dataGridView_plan.Rows[1].Cells[0].Value = line[1];
            dataGridView_plan.Rows[2].Cells[0].Value = line[2];
            dataGridView_plan.Rows[3].Cells[0].Value = line[3];
            #endregion

            string[] dates = dataGridView_plan.Rows[1].Cells[0].Value.ToString().Split('~');
          
           int Days = DateTime.Parse(dates[1]).DayOfYear - DateTime.Parse(dates[0]).DayOfYear;
            for (int i = 0; i < Days + 1; i++)
            {
                labels[i].Visible = true;
            }


        }




        /// <summary>
        /// 刪除spotControl
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SpotControl_PictureBox_DelClick(object sender, EventArgs e)
        {
            #region 物件替換
            if (userControlList == null)
            {
                usersList = userControlList2;
                MessageBox.Show("已儲存的景點無法刪除！");
                return;
            }
            else usersList = userControlList;

            if (placeAllList == null) adList = placeAllList2;
            else adList = placeAllList;

            if (detailsList == null) pdList = detailsList2;
            else pdList = detailsList; 
            #endregion

            for (int j = usersList.Count-1; j >-1; j--)
            {
                if (sender == usersList[j])
                {
                    this.detailsPanel.Controls.Remove(controlPanelList[j]);
                    if (detailsPanel.Controls.Count == 1) doNotSaved = true;
                    MessageBox.Show($"{pdList[j].PlaceName}已刪除！");

                    adList.RemoveAt(j);
                    adList.Add(new PlaceAllData());                    
                    return;
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
            #region 物件替換
            if (userControlList == null) usersList = userControlList2;
            else if (userControlList.Count==0) usersList = userControlList2;            
            else usersList = userControlList;

            if(cooList==null) coorList = cooList2;
            else if (cooList.Count==0) coorList = cooList2;
            else coorList = cooList;

            if(keywordList==null) keyList = keywordList2;
            else if (keywordList.Count==0) keyList = keywordList2;
            else keyList = keywordList;
            #endregion

            for (int j = 0; j < usersList.Count; j++)
            {                    
                if (sender == usersList[j])
                {
                    
                    mapsNET.AddMaker(coorList[j][0], coorList[j][1], keyList[j]);
                    return;
                }                 
            }
       }




        private void dataGridView_plan_Click(object sender, EventArgs e)
        {

            if (dataGridView_plan.Rows[0].Cells[0].Value == null && detailsList == null) return;

            /* 每次重填旅遊計畫名稱前要先將Day1,Day2,....藏起來 */
            for (int i = 0; i < labels.Length; i++)
            {
                labels[i].Visible = false;
                panelList[i].Visible = false;
            }

            #region 更新旅遊計畫還是編輯新的旅遊計畫？
            DialogResult Result = MessageBox.Show("Do you want to UPDATE PlanOverview?", "UPDATE[不更換旅遊計畫名稱]",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (Result == DialogResult.Yes)
                {
                
                if (addPlan.PlanName == string.Empty) planName = dataGridView_plan.Rows[0].Cells[0].Value.ToString();
                else planName = addPlan.PlanName;

                /* 刪除已儲存的PlanOverview Csv檔案*/
                string path = $@"C:\Users\ching\source\repos\_A20200701 - 複製\TravelPlanner\{planName}\Overview";
                    string[] file = Directory.GetFiles(path);

                    foreach (var item in file)
                    {
                        if (File.Exists(item))
                        {
                            File.SetAttributes(item, FileAttributes.Directory);
                            File.Delete(item);
                        }
                        break;
                    }

                    addPlan.ShowDialog();

                }
                else/* 更換旅遊計畫名稱*/
                {
                    addPlan = null;
                    addPlan = new AddPlan();
                    addPlan.ShowDialog();
                }


            #region 將AddPlan表單編輯的資訊匯入
            /* 匯入計畫名稱 */
            dataGridView_plan.Rows[0].Cells[0].Value = addPlan.PlanName;
            /* 匯入起訖日期 */
            dataGridView_plan.Rows[1].Cells[0].Value =
            addPlan.StartTime.ToString("yyyy-MM-dd") + "~" + addPlan.EndTime.ToString("yyyy-MM-dd");

            #region 天數差計算
            int days = addPlan.EndTime.DayOfYear - addPlan.StartTime.DayOfYear;

            for (int i = 0; i < days + 1; i++)
            {
                labels[i].Visible = true;
            }


            #endregion

            /* 匯入計畫簡介 */
            dataGridView_plan.Rows[2].Cells[0].Value = addPlan.PlanOverView;
            /* 匯入計畫備註 */
            dataGridView_plan.Rows[3].Cells[0].Value = addPlan.OptionInfo;
            #endregion

            #endregion


        }




        private void picBox_newPlan_Click(object sender, EventArgs e)
        {
            /* 將flowlayoutpanel清空 */
            this.detailsPanel.Controls.Clear();

            addPlan = null;
            addPlan = new AddPlan();
            addPlan.ShowDialog();

            /* 每次重填旅遊計畫名稱前要先將Day1,Day2,....藏起來 */
            for (int i = 0; i < labels.Length; i++)
            {
                labels[i].Visible = false;
                panelList[i].Visible = false;
            }

            #region 將AddPlan表單編輯的資訊匯入
            /* 匯入計畫名稱 */
            dataGridView_plan.Rows[0].Cells[0].Value = addPlan.PlanName;
            /* 匯入起訖日期 */
            dataGridView_plan.Rows[1].Cells[0].Value =
            addPlan.StartTime.ToString("yyyy-MM-dd") + "~" + addPlan.EndTime.ToString("yyyy-MM-dd");

            #region 天數差計算
            int days = addPlan.EndTime.DayOfYear - addPlan.StartTime.DayOfYear;

            for (int i = 0; i < days + 1; i++)
            {
                labels[i].Visible = true;
            }


            #endregion

            /* 匯入計畫簡介 */
            dataGridView_plan.Rows[2].Cells[0].Value = addPlan.PlanOverView;
            /* 匯入計畫備註 */
            dataGridView_plan.Rows[3].Cells[0].Value = addPlan.OptionInfo;
            #endregion
        }






    }
}










using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace _A20200701
{
    public partial class AddPlan : Form
    {


        #region Properties      

        public DateTime StartTime
        {
            get { return dateTimePicker_start.Value; }
            set { dateTimePicker_start.Value = value; }
        }

        public DateTime EndTime
        {
            get { return dateTimePicker_end.Value; }
            set { dateTimePicker_end.Value = value; }
        }

        public string PlanName
        {
            get { return txt_planName.Text; }
            set { txt_planName.Text = value; }
        }

        public string PlanOverView
        {
            get { return richBox_planOverview.Text; }
            set { richBox_planOverview.Text = value; }
        }

        public string OptionInfo
        {
            get { return richBox_optionInfo.Text; }
            set { richBox_optionInfo.Text = value; }
        }


        #endregion



        bool isClick = false;
        bool needNew = false;
        public AddPlan()
        {

            InitializeComponent();

            /* AddPlan窗體關閉前事件 */
            this.FormClosing += new FormClosingEventHandler(this.memberFormClosing);
        }



        /// <summary>
        /// 窗體關閉時提示是否關閉
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void memberFormClosing(object sender, FormClosingEventArgs e)
        {

            /* 若新增計畫按鍵未使用 */
            if (!isClick)
            {
                DialogResult key = MessageBox.Show(" You haven't saved PlanOverview, do you want to GIVE UP here？ ",
                    " GIVE UP[捨棄] ", MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);

                /* 窗體不要關閉e.Cancel  = true */
                if (key == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
            else if(isClick && needNew)
            {
                DialogResult key = MessageBox.Show(" You haven't reset PlanName, do you want to REUSE the PlanOverview which saved last time and close window？ ",
                    " REUSE[續用上次儲存的PlanOverview檔案] ", MessageBoxButtons.YesNo,
              MessageBoxIcon.Question);

                
                if (key == DialogResult.No)/* 不續用 - 必須更改旅遊計畫名稱*/
                {/* 窗體不要關閉e.Cancel  = true */
                    e.Cancel = true;
                    MessageBox.Show("請點選旅遊計畫表格編輯新計畫名稱！");
                }
            }

            isClick = false;
            needNew = false;
            MessageBox.Show("有任何更動，請按Places儲存！");
        }

     
      


        /// <summary>
        /// 按下送出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_addPlan_Click(object sender, EventArgs e)
        {
            isClick = true;

            #region 過濾旅遊計畫名稱不重複
            string[] directories = Directory.GetDirectories($@"C:\Users\ching\source\repos\_A20200701 - 複製\TravelPlanner");

            foreach (var directory in directories)
            {
                DirectoryInfo folder = new DirectoryInfo(directory);
                if (txt_planName.Text == folder.Name)
                {
                    if (File.Exists($@"C:\Users\ching\source\repos\_A20200701 - 複製\TravelPlanner\{folder.Name}\Overview\{folder.Name}.csv"))
                    {
                        needNew = true;
                        MessageBox.Show("此旅遊計畫名稱已存在，請重新編輯！");
                        return;
                    }
                }
            }
            #endregion

            Directory.CreateDirectory($@"C:\Users\ching\source\repos\_A20200701 - 複製\TravelPlanner\{PlanName}\image");
            string path = $@"C:\Users\ching\source\repos\_A20200701 - 複製\TravelPlanner\{PlanName}\image\{PlanName}.jpg";

            //先判斷資料夾目錄路徑是否存在
            bool file = File.Exists(path);//需要完整路徑
            if (file)//存在，是否覆蓋
            {
                DialogResult Result = MessageBox.Show("Image file has existed, Do you want to OVERRIDE?",
                    "OVERRIDE[覆蓋]", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Result == DialogResult.OK)
                {
                  
                    File.Copy(showImagePath.Text, Path.Combine(
                        $@"C:\Users\ching\source\repos\_A20200701 - 複製\TravelPlanner\{PlanName}\image",
                        Path.GetFileName(showImagePath.Text)),true);
                    
                }
                else
                {
                    return;
                }
            }
            else//不存在，建立路徑與檔案
            {
             
                File.Copy(showImagePath.Text, Path.Combine(
                    $@"C:\Users\ching\source\repos\_A20200701 - 複製\TravelPlanner\{PlanName}\image", 
                    Path.GetFileName(showImagePath.Text)));
                
            }
           

        }


        /// <summary>
        /// 用戶設定起始日期的限制條件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dateTimePicker_start_CloseUp(object sender, EventArgs e)
        {
            dateTimePicker_start.MinDate = DateTime.Now.Date;

        }


        /// <summary>
        /// 用戶設定終止日期的限制條件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dateTimePicker_end_CloseUp(object sender, EventArgs e)
        {
            dateTimePicker_end.MinDate = DateTime.Now.Date;
            dateTimePicker_end.MaxDate = dateTimePicker_start.Value.AddDays(6);

        }

        private void pictureBox_UploadIMG_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Image Files(*.jpg;*.jpeg;)|*.jpg;*.jpeg;";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                showImagePath.Text = openFile.FileName;
                drawImage.Image = new Bitmap(openFile.FileName);
            }
        }
    }
}


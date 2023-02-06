using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace _A20200701
{
    public partial class AddPlan : Form
    {

        bool isClick = false;

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
                DialogResult key = MessageBox.Show(" 您尚未儲存編輯資料，您要捨棄資料並關閉嗎？ ", " confim ", MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);

                /* 窗體不要關閉e.Cancel  = true */
                if (key == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }

            isClick = false;
        }


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


        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks button")]
        public event EventHandler ButtonClick;






        /// <summary>
        /// 已按下送出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_addPlan_Click(object sender, EventArgs e)
        {
            isClick = true;

            //bubble the event up to the parent
            if (this.ButtonClick != null)
                this.ButtonClick(this, e);


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
            dateTimePicker_end.MaxDate = dateTimePicker_start.Value.AddDays(6);

        }
    }
}


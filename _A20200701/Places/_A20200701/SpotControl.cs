using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Utility.GoogleMaps;

namespace _A20200701
{
    public partial class SpotControl : UserControl
    {
        #region Properties


        private string _startTime;
        private string _endTime;
        private string _cost;




        [Category("Custom Props")]
        public List<PlaceDetails> DataSource
        {
            set { dataGridView_eachSpot1.DataSource = value; }
        }



        [Category("Custom Props")]
        public DataGridViewColumnCollection Columns
        {
            get { return dataGridView_eachSpot1.Columns; }
        }


        [Category("Custom Props")]
        public DataGridViewRowCollection Rows
        {
            get { return dataGridView_eachSpot1.Rows; }
        }


        [Category("Custom Props")]
        public string StartTime
        {
            get { return _startTime; } 
            set { txt_startTime.Text = value; _startTime = value; }
        }


        [Category("Custom Props")]
        public string EndTime
        {
            get { return _endTime; }
            set { txt_endTime.Text = value; _endTime = value; }
        }


        [Category("Custom Props")]
        public string Cost
        {
            get { return _cost; }
            set { txt_expectedSpend.Text = value; _cost = value; }
        }

        #endregion



        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks pictureBox")]
        public event EventHandler PictureBoxClick;

        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks pictureBox")]
        public event EventHandler PictureBox_DelClick;

        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks pictureBox")]
        public event EventHandler PictureBox_RouteClick;

        public SpotControl()
        {
            InitializeComponent();
            dataGridView_eachSpot1.BringToFront();          
            
        }




        /// <summary>
        /// 當textBox輸入完畢取值將欄位重新設值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_endTime_KeyUp(object sender, KeyEventArgs e)
        {
            _startTime = txt_startTime.Text;
            _endTime = txt_endTime.Text;
            _cost = txt_expectedSpend.Text;
            

        }

        private void pictureBox1_Click(object sender, System.EventArgs e)
        {
            //bubble the event up to the parent(SpotControl)
            if (this.PictureBoxClick != null)
                this.PictureBoxClick(this, e);

        }



        private void pictureBox2_Del_DoubleClick(object sender, EventArgs e)
        {
            //bubble the event up to the parent(SpotControl)
            if (this.PictureBox_DelClick != null)
                this.PictureBox_DelClick(this, e);
        }



        private void picBox_route_Click(object sender, EventArgs e)
        {
            //bubble the event up to the parent(SpotControl)
            if (this.PictureBox_RouteClick != null)
                this.PictureBox_RouteClick(this, e);
           
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utility.GoogleMaps;


namespace _A20200701
{
    public partial class UserControl1 : UserControl
    {


        #region Properties

        private DataTable _dataSource;
       
        DataTable dt;
        DataRow row1;
        DataRow row2;

        [Category("Custom Props")]
        public DataTable DataSource
        {
            get { return _dataSource; }
            set { dataGridView_eachSpot1.DataSource = value; }
        }

        #endregion     

        public UserControl1()
        {
            InitializeComponent();

    }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker timePicker = (DateTimePicker)sender;
            int findIndex = timePicker.Value.ToString().IndexOf('午');
            string startTime = timePicker.Value.ToString().Substring(findIndex + 1, 6);
            row2[0] = startTime;            
        }



        public void CreateUnboundRows()
        {

            dt = dataGridView_eachSpot1.DataSource as DataTable;

            row1 = dt.NewRow();
            row1[0] = "出發時間";
            row1[1] = "結束時間";
            row1[2] = "預計花費";
            row1[3] = "備註";

            dt.Rows.Add(row1);

            row2 = dt.NewRow();
            row2[0] = "00:00";
            row2[1] = "00:00";
            row2[2] = "$";
            row2[3] = "※";

            dt.Rows.Add(row2);

        
        }
    }

}




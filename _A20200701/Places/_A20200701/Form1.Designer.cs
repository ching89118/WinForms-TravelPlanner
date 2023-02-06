namespace _A20200701
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TabControls = new System.Windows.Forms.TabControl();
            this.tabPage_showPlans = new System.Windows.Forms.TabPage();
            this.tabPage_addSpot = new System.Windows.Forms.TabPage();
            this.picBox_searchSinglePDetails = new System.Windows.Forms.PictureBox();
            this.txt_SearchAttr = new System.Windows.Forms.TextBox();
            this.tabPage_spots = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel_myItinerary = new System.Windows.Forms.FlowLayoutPanel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.存檔ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lb_day6 = new System.Windows.Forms.Label();
            this.lb_day2 = new System.Windows.Forms.Label();
            this.lb_day3 = new System.Windows.Forms.Label();
            this.lb_day4 = new System.Windows.Forms.Label();
            this.flowLP_line7 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLP_line6 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLP_line5 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLP_line4 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLP_line3 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLP_line2 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLP_line1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lb_day5 = new System.Windows.Forms.Label();
            this.lb_day7 = new System.Windows.Forms.Label();
            this.lb_day1 = new System.Windows.Forms.Label();
            this.picBox_newPlan = new System.Windows.Forms.PictureBox();
            this.dataGridView_plan = new System.Windows.Forms.DataGridView();
            this.detailsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.picBox_importCSV5 = new System.Windows.Forms.PictureBox();
            this.tabPage_suggest = new System.Windows.Forms.TabPage();
            this.旅遊計畫名稱 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.旅遊期間 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label_saveSuccess = new System.Windows.Forms.Label();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_requary = new System.Windows.Forms.Button();
            this.TabControls.SuspendLayout();
            this.tabPage_addSpot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_searchSinglePDetails)).BeginInit();
            this.tabPage_spots.SuspendLayout();
            this.flowLayoutPanel_myItinerary.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_newPlan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_plan)).BeginInit();
            this.detailsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_importCSV5)).BeginInit();
            this.SuspendLayout();
            // 
            // TabControls
            // 
            this.TabControls.Controls.Add(this.tabPage_showPlans);
            this.TabControls.Controls.Add(this.tabPage_addSpot);
            this.TabControls.Controls.Add(this.tabPage_spots);
            this.TabControls.Controls.Add(this.tabPage_suggest);
            this.TabControls.Location = new System.Drawing.Point(12, 12);
            this.TabControls.Name = "TabControls";
            this.TabControls.SelectedIndex = 0;
            this.TabControls.Size = new System.Drawing.Size(1300, 643);
            this.TabControls.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.TabControls.TabIndex = 0;
            this.TabControls.Tag = "3";
            this.TabControls.Selected += new System.Windows.Forms.TabControlEventHandler(this.TabControls_Selected);
            // 
            // tabPage_showPlans
            // 
            this.tabPage_showPlans.Location = new System.Drawing.Point(4, 28);
            this.tabPage_showPlans.Name = "tabPage_showPlans";
            this.tabPage_showPlans.Size = new System.Drawing.Size(1292, 611);
            this.tabPage_showPlans.TabIndex = 2;
            this.tabPage_showPlans.Text = "My Trips";
            this.tabPage_showPlans.UseVisualStyleBackColor = true;
            // 
            // tabPage_addSpot
            // 
            this.tabPage_addSpot.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabPage_addSpot.BackgroundImage")));
            this.tabPage_addSpot.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage_addSpot.Controls.Add(this.picBox_searchSinglePDetails);
            this.tabPage_addSpot.Controls.Add(this.txt_SearchAttr);
            this.tabPage_addSpot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPage_addSpot.Location = new System.Drawing.Point(4, 28);
            this.tabPage_addSpot.Name = "tabPage_addSpot";
            this.tabPage_addSpot.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_addSpot.Size = new System.Drawing.Size(1292, 611);
            this.tabPage_addSpot.TabIndex = 0;
            this.tabPage_addSpot.Text = "Places";
            this.tabPage_addSpot.UseVisualStyleBackColor = true;
            // 
            // picBox_searchSinglePDetails
            // 
            this.picBox_searchSinglePDetails.Image = ((System.Drawing.Image)(resources.GetObject("picBox_searchSinglePDetails.Image")));
            this.picBox_searchSinglePDetails.Location = new System.Drawing.Point(274, 21);
            this.picBox_searchSinglePDetails.Name = "picBox_searchSinglePDetails";
            this.picBox_searchSinglePDetails.Size = new System.Drawing.Size(50, 50);
            this.picBox_searchSinglePDetails.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBox_searchSinglePDetails.TabIndex = 1;
            this.picBox_searchSinglePDetails.TabStop = false;
            this.picBox_searchSinglePDetails.Tag = "single";
            this.picBox_searchSinglePDetails.Click += new System.EventHandler(this.picBox_placeSearch_Click);
            // 
            // txt_SearchAttr
            // 
            this.txt_SearchAttr.Font = new System.Drawing.Font("PMingLiU", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txt_SearchAttr.Location = new System.Drawing.Point(12, 30);
            this.txt_SearchAttr.Name = "txt_SearchAttr";
            this.txt_SearchAttr.Size = new System.Drawing.Size(256, 31);
            this.txt_SearchAttr.TabIndex = 0;
            this.txt_SearchAttr.Text = "input City_Spot";
            this.txt_SearchAttr.Click += new System.EventHandler(this.txt_SearchAttr_Click);
            // 
            // tabPage_spots
            // 
            this.tabPage_spots.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage_spots.Controls.Add(this.flowLayoutPanel_myItinerary);
            this.tabPage_spots.Controls.Add(this.picBox_importCSV5);
            this.tabPage_spots.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tabPage_spots.Location = new System.Drawing.Point(4, 28);
            this.tabPage_spots.Name = "tabPage_spots";
            this.tabPage_spots.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_spots.Size = new System.Drawing.Size(1292, 611);
            this.tabPage_spots.TabIndex = 1;
            this.tabPage_spots.Text = "My Itinerary";
            this.tabPage_spots.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel_myItinerary
            // 
            this.flowLayoutPanel_myItinerary.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("flowLayoutPanel_myItinerary.BackgroundImage")));
            this.flowLayoutPanel_myItinerary.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.flowLayoutPanel_myItinerary.ContextMenuStrip = this.contextMenuStrip1;
            this.flowLayoutPanel_myItinerary.Controls.Add(this.flowLayoutPanel1);
            this.flowLayoutPanel_myItinerary.Controls.Add(this.flowLayoutPanel2);
            this.flowLayoutPanel_myItinerary.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel_myItinerary.Location = new System.Drawing.Point(-6, 2);
            this.flowLayoutPanel_myItinerary.Name = "flowLayoutPanel_myItinerary";
            this.flowLayoutPanel_myItinerary.Size = new System.Drawing.Size(1317, 614);
            this.flowLayoutPanel_myItinerary.TabIndex = 3;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.存檔ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(117, 34);
            // 
            // 存檔ToolStripMenuItem
            // 
            this.存檔ToolStripMenuItem.Name = "存檔ToolStripMenuItem";
            this.存檔ToolStripMenuItem.Size = new System.Drawing.Size(116, 30);
            this.存檔ToolStripMenuItem.Text = "存檔";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.ContextMenuStrip = this.contextMenuStrip1;
            this.flowLayoutPanel1.Controls.Add(this.tableLayoutPanel1);
            this.flowLayoutPanel1.Controls.Add(this.dataGridView_plan);
            this.flowLayoutPanel1.Controls.Add(this.detailsPanel);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(4, 4);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(723, 557);
            this.flowLayoutPanel1.TabIndex = 8;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.Controls.Add(this.lb_day6, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.lb_day2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lb_day3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lb_day4, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLP_line7, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLP_line6, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLP_line5, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLP_line4, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLP_line3, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLP_line2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLP_line1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lb_day5, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.lb_day7, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.lb_day1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.picBox_newPlan, 7, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(651, 70);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // lb_day6
            // 
            this.lb_day6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_day6.Font = new System.Drawing.Font("Futura-Bold", 9.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_day6.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lb_day6.Location = new System.Drawing.Point(408, 0);
            this.lb_day6.Name = "lb_day6";
            this.lb_day6.Size = new System.Drawing.Size(75, 60);
            this.lb_day6.TabIndex = 0;
            this.lb_day6.Tag = "6";
            this.lb_day6.Text = "Day 6";
            this.lb_day6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_day6.Click += new System.EventHandler(this.lb_day1_Click);
            // 
            // lb_day2
            // 
            this.lb_day2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_day2.Font = new System.Drawing.Font("Futura-Bold", 9.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_day2.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lb_day2.Location = new System.Drawing.Point(84, 0);
            this.lb_day2.Name = "lb_day2";
            this.lb_day2.Size = new System.Drawing.Size(75, 60);
            this.lb_day2.TabIndex = 0;
            this.lb_day2.Tag = "2";
            this.lb_day2.Text = "Day 2";
            this.lb_day2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_day2.Click += new System.EventHandler(this.lb_day1_Click);
            // 
            // lb_day3
            // 
            this.lb_day3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_day3.Font = new System.Drawing.Font("Futura-Bold", 9.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_day3.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lb_day3.Location = new System.Drawing.Point(165, 0);
            this.lb_day3.Name = "lb_day3";
            this.lb_day3.Size = new System.Drawing.Size(75, 60);
            this.lb_day3.TabIndex = 0;
            this.lb_day3.Tag = "3";
            this.lb_day3.Text = "Day 3";
            this.lb_day3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_day3.Click += new System.EventHandler(this.lb_day1_Click);
            // 
            // lb_day4
            // 
            this.lb_day4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_day4.Font = new System.Drawing.Font("Futura-Bold", 9.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_day4.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lb_day4.Location = new System.Drawing.Point(246, 0);
            this.lb_day4.Name = "lb_day4";
            this.lb_day4.Size = new System.Drawing.Size(75, 60);
            this.lb_day4.TabIndex = 0;
            this.lb_day4.Tag = "4";
            this.lb_day4.Text = "Day 4";
            this.lb_day4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_day4.Click += new System.EventHandler(this.lb_day1_Click);
            // 
            // flowLP_line7
            // 
            this.flowLP_line7.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.flowLP_line7.BackColor = System.Drawing.SystemColors.HighlightText;
            this.flowLP_line7.Location = new System.Drawing.Point(501, 64);
            this.flowLP_line7.Name = "flowLP_line7";
            this.flowLP_line7.Size = new System.Drawing.Size(51, 3);
            this.flowLP_line7.TabIndex = 1;
            // 
            // flowLP_line6
            // 
            this.flowLP_line6.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.flowLP_line6.BackColor = System.Drawing.SystemColors.HighlightText;
            this.flowLP_line6.Location = new System.Drawing.Point(420, 64);
            this.flowLP_line6.Name = "flowLP_line6";
            this.flowLP_line6.Size = new System.Drawing.Size(50, 3);
            this.flowLP_line6.TabIndex = 1;
            // 
            // flowLP_line5
            // 
            this.flowLP_line5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.flowLP_line5.BackColor = System.Drawing.SystemColors.HighlightText;
            this.flowLP_line5.Location = new System.Drawing.Point(339, 64);
            this.flowLP_line5.Name = "flowLP_line5";
            this.flowLP_line5.Size = new System.Drawing.Size(50, 3);
            this.flowLP_line5.TabIndex = 1;
            // 
            // flowLP_line4
            // 
            this.flowLP_line4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.flowLP_line4.BackColor = System.Drawing.SystemColors.HighlightText;
            this.flowLP_line4.Location = new System.Drawing.Point(258, 64);
            this.flowLP_line4.Name = "flowLP_line4";
            this.flowLP_line4.Size = new System.Drawing.Size(50, 3);
            this.flowLP_line4.TabIndex = 1;
            // 
            // flowLP_line3
            // 
            this.flowLP_line3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.flowLP_line3.BackColor = System.Drawing.SystemColors.HighlightText;
            this.flowLP_line3.Location = new System.Drawing.Point(177, 64);
            this.flowLP_line3.Name = "flowLP_line3";
            this.flowLP_line3.Size = new System.Drawing.Size(50, 3);
            this.flowLP_line3.TabIndex = 1;
            // 
            // flowLP_line2
            // 
            this.flowLP_line2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.flowLP_line2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.flowLP_line2.Location = new System.Drawing.Point(96, 64);
            this.flowLP_line2.Name = "flowLP_line2";
            this.flowLP_line2.Size = new System.Drawing.Size(50, 3);
            this.flowLP_line2.TabIndex = 1;
            // 
            // flowLP_line1
            // 
            this.flowLP_line1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.flowLP_line1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.flowLP_line1.Location = new System.Drawing.Point(16, 64);
            this.flowLP_line1.Name = "flowLP_line1";
            this.flowLP_line1.Size = new System.Drawing.Size(49, 3);
            this.flowLP_line1.TabIndex = 1;
            // 
            // lb_day5
            // 
            this.lb_day5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_day5.Font = new System.Drawing.Font("Futura-Bold", 9.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_day5.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lb_day5.Location = new System.Drawing.Point(327, 0);
            this.lb_day5.Name = "lb_day5";
            this.lb_day5.Size = new System.Drawing.Size(75, 60);
            this.lb_day5.TabIndex = 0;
            this.lb_day5.Tag = "5";
            this.lb_day5.Text = "Day 5";
            this.lb_day5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_day5.Click += new System.EventHandler(this.lb_day1_Click);
            // 
            // lb_day7
            // 
            this.lb_day7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_day7.Font = new System.Drawing.Font("Futura-Bold", 9.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_day7.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lb_day7.Location = new System.Drawing.Point(489, 0);
            this.lb_day7.Name = "lb_day7";
            this.lb_day7.Size = new System.Drawing.Size(75, 60);
            this.lb_day7.TabIndex = 0;
            this.lb_day7.Tag = "7";
            this.lb_day7.Text = "Day 7";
            this.lb_day7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_day7.Click += new System.EventHandler(this.lb_day1_Click);
            // 
            // lb_day1
            // 
            this.lb_day1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_day1.Font = new System.Drawing.Font("Futura-Bold", 9.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_day1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lb_day1.Location = new System.Drawing.Point(3, 0);
            this.lb_day1.Name = "lb_day1";
            this.lb_day1.Size = new System.Drawing.Size(75, 60);
            this.lb_day1.TabIndex = 0;
            this.lb_day1.Tag = "1";
            this.lb_day1.Text = "Day 1";
            this.lb_day1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_day1.Click += new System.EventHandler(this.lb_day1_Click);
            // 
            // picBox_newPlan
            // 
            this.picBox_newPlan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBox_newPlan.Image = ((System.Drawing.Image)(resources.GetObject("picBox_newPlan.Image")));
            this.picBox_newPlan.Location = new System.Drawing.Point(570, 3);
            this.picBox_newPlan.Name = "picBox_newPlan";
            this.picBox_newPlan.Size = new System.Drawing.Size(78, 54);
            this.picBox_newPlan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBox_newPlan.TabIndex = 2;
            this.picBox_newPlan.TabStop = false;
            this.picBox_newPlan.Click += new System.EventHandler(this.picBox_newPlan_Click);
            // 
            // dataGridView_plan
            // 
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView_plan.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridView_plan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridView_plan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_plan.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView_plan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_plan.ColumnHeadersVisible = false;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_plan.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridView_plan.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView_plan.Location = new System.Drawing.Point(3, 79);
            this.dataGridView_plan.Name = "dataGridView_plan";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_plan.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridView_plan.RowHeadersWidth = 200;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView_plan.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridView_plan.RowTemplate.Height = 31;
            this.dataGridView_plan.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridView_plan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView_plan.Size = new System.Drawing.Size(708, 124);
            this.dataGridView_plan.TabIndex = 5;
            this.dataGridView_plan.Click += new System.EventHandler(this.dataGridView_plan_Click);
            // 
            // detailsPanel
            // 
            this.detailsPanel.AutoScroll = true;
            this.detailsPanel.BackColor = System.Drawing.Color.Transparent;
            this.detailsPanel.Controls.Add(this.label1);
            this.detailsPanel.Location = new System.Drawing.Point(3, 209);
            this.detailsPanel.Name = "detailsPanel";
            this.detailsPanel.Size = new System.Drawing.Size(708, 333);
            this.detailsPanel.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("PMingLiU", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.ForeColor = System.Drawing.Color.Firebrick;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(705, 23);
            this.label1.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.flowLayoutPanel2.AutoScroll = true;
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(735, 4);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(556, 542);
            this.flowLayoutPanel2.TabIndex = 9;
            // 
            // picBox_importCSV5
            // 
            this.picBox_importCSV5.Image = ((System.Drawing.Image)(resources.GetObject("picBox_importCSV5.Image")));
            this.picBox_importCSV5.Location = new System.Drawing.Point(1672, 802);
            this.picBox_importCSV5.Name = "picBox_importCSV5";
            this.picBox_importCSV5.Size = new System.Drawing.Size(70, 70);
            this.picBox_importCSV5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBox_importCSV5.TabIndex = 2;
            this.picBox_importCSV5.TabStop = false;
            this.picBox_importCSV5.Tag = "5";
            // 
            // tabPage_suggest
            // 
            this.tabPage_suggest.Location = new System.Drawing.Point(4, 28);
            this.tabPage_suggest.Name = "tabPage_suggest";
            this.tabPage_suggest.Size = new System.Drawing.Size(1292, 611);
            this.tabPage_suggest.TabIndex = 3;
            this.tabPage_suggest.Text = "其他旅遊網推薦";
            this.tabPage_suggest.UseVisualStyleBackColor = true;
            // 
            // 旅遊計畫名稱
            // 
            this.旅遊計畫名稱.HeaderText = "旅遊計畫名稱";
            this.旅遊計畫名稱.MinimumWidth = 8;
            this.旅遊計畫名稱.Name = "旅遊計畫名稱";
            this.旅遊計畫名稱.Width = 150;
            // 
            // 旅遊期間
            // 
            this.旅遊期間.HeaderText = "旅遊期間(dd/ MM/ yyyy)";
            this.旅遊期間.MinimumWidth = 8;
            this.旅遊期間.Name = "旅遊期間";
            this.旅遊期間.Width = 150;
            // 
            // label_saveSuccess
            // 
            this.label_saveSuccess.Font = new System.Drawing.Font("Sarasa Mono CL", 10F, System.Drawing.FontStyle.Bold);
            this.label_saveSuccess.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label_saveSuccess.Location = new System.Drawing.Point(1302, 1);
            this.label_saveSuccess.Name = "label_saveSuccess";
            this.label_saveSuccess.Size = new System.Drawing.Size(81, 36);
            this.label_saveSuccess.TabIndex = 2;
            // 
            // btn_save
            // 
            this.btn_save.Font = new System.Drawing.Font("PMingLiU", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_save.Location = new System.Drawing.Point(1206, 0);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(94, 36);
            this.btn_save.TabIndex = 3;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_requary
            // 
            this.btn_requary.Font = new System.Drawing.Font("PMingLiU", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_requary.Location = new System.Drawing.Point(1104, 1);
            this.btn_requary.Name = "btn_requary";
            this.btn_requary.Size = new System.Drawing.Size(94, 36);
            this.btn_requary.TabIndex = 1;
            this.btn_requary.Text = "Requary";
            this.btn_requary.UseVisualStyleBackColor = true;
            this.btn_requary.Click += new System.EventHandler(this.btn_requary_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1385, 681);
            this.Controls.Add(this.label_saveSuccess);
            this.Controls.Add(this.btn_requary);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.TabControls);
            this.MaximumSize = new System.Drawing.Size(1489, 872);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.TabControls.ResumeLayout(false);
            this.tabPage_addSpot.ResumeLayout(false);
            this.tabPage_addSpot.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_searchSinglePDetails)).EndInit();
            this.tabPage_spots.ResumeLayout(false);
            this.flowLayoutPanel_myItinerary.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBox_newPlan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_plan)).EndInit();
            this.detailsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBox_importCSV5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabControls;
        private System.Windows.Forms.TabPage tabPage_spots;
        private System.Windows.Forms.TabPage tabPage_showPlans;
        private System.Windows.Forms.TabPage tabPage_suggest;
        private System.Windows.Forms.PictureBox picBox_importCSV5;
        private System.Windows.Forms.TabPage tabPage_addSpot;
        private System.Windows.Forms.Label label_saveSuccess;
        private System.Windows.Forms.Button btn_requary;
        private System.Windows.Forms.PictureBox picBox_searchSinglePDetails;
        private System.Windows.Forms.TextBox txt_SearchAttr;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_myItinerary;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLP_line7;
        private System.Windows.Forms.FlowLayoutPanel flowLP_line6;
        private System.Windows.Forms.FlowLayoutPanel flowLP_line5;
        private System.Windows.Forms.FlowLayoutPanel flowLP_line4;
        private System.Windows.Forms.FlowLayoutPanel flowLP_line3;
        private System.Windows.Forms.FlowLayoutPanel flowLP_line2;
        private System.Windows.Forms.FlowLayoutPanel flowLP_line1;
        private System.Windows.Forms.Label lb_day2;
        private System.Windows.Forms.Label lb_day3;
        private System.Windows.Forms.Label lb_day4;
        private System.Windows.Forms.Label lb_day5;
        private System.Windows.Forms.Label lb_day6;
        private System.Windows.Forms.Label lb_day7;
        private System.Windows.Forms.Label lb_day1;
        private System.Windows.Forms.DataGridView dataGridView_plan;
        internal System.Windows.Forms.FlowLayoutPanel detailsPanel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;      
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.ToolStripMenuItem 存檔ToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 旅遊計畫名稱;
        private System.Windows.Forms.DataGridViewTextBoxColumn 旅遊期間;
        private System.Windows.Forms.PictureBox picBox_newPlan;
    }
}


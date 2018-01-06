namespace PlayApparatus
{
    partial class Frm_Play
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        public void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Play));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.timer_ShowTime = new System.Windows.Forms.Timer(this.components);
            this.timer_Bend = new System.Windows.Forms.Timer(this.components);
            this.label_Time = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.FileList_treeView = new System.Windows.Forms.TreeView();
            this.listView1 = new System.Windows.Forms.ListView();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.myChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.changeFont = new System.Windows.Forms.PictureBox();
            this.saveVoice = new System.Windows.Forms.PictureBox();
            this.panel_Trough = new System.Windows.Forms.Panel();
            this.pictureBox_Hold = new System.Windows.Forms.PictureBox();
            this.pictureBox_Bar = new System.Windows.Forms.PictureBox();
            this.pictureBox_Rest = new System.Windows.Forms.PictureBox();
            this.panel_Sound = new System.Windows.Forms.Panel();
            this.pictureBox_SoundHold = new System.Windows.Forms.PictureBox();
            this.pictureBox_SoundBar = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox_Down = new System.Windows.Forms.PictureBox();
            this.pictureBox_Play = new System.Windows.Forms.PictureBox();
            this.pictureBox_Stop = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myChart)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.changeFont)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saveVoice)).BeginInit();
            this.panel_Trough.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Hold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Rest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_SoundHold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_SoundBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Down)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Play)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Stop)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // timer_ShowTime
            // 
            this.timer_ShowTime.Tick += new System.EventHandler(this.timer_ShowTime_Tick);
            // 
            // timer_Bend
            // 
            this.timer_Bend.Interval = 1000;
            this.timer_Bend.Tick += new System.EventHandler(this.timer_Bend_Tick);
            // 
            // label_Time
            // 
            this.label_Time.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Time.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label_Time.Location = new System.Drawing.Point(388, 27);
            this.label_Time.Name = "label_Time";
            this.label_Time.Size = new System.Drawing.Size(71, 23);
            this.label_Time.TabIndex = 9;
            this.label_Time.Text = "00:00";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(10, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 23);
            this.label1.TabIndex = 10;
            this.label1.Text = "00:00";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(468, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 23);
            this.label2.TabIndex = 11;
            this.label2.Text = "00:00";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 94);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(890, 243);
            this.splitContainer1.SplitterDistance = 294;
            this.splitContainer1.TabIndex = 12;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.FileList_treeView);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.listView1);
            this.splitContainer2.Size = new System.Drawing.Size(294, 243);
            this.splitContainer2.SplitterDistance = 117;
            this.splitContainer2.TabIndex = 0;
            // 
            // FileList_treeView
            // 
            this.FileList_treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FileList_treeView.Location = new System.Drawing.Point(0, 0);
            this.FileList_treeView.Name = "FileList_treeView";
            this.FileList_treeView.Size = new System.Drawing.Size(290, 113);
            this.FileList_treeView.TabIndex = 0;
            this.FileList_treeView.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.FileList_treeView_AfterExpand);
            this.FileList_treeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.FileList_treeView_NodeMouseClick);
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(290, 118);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick);
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.myChart);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.textBox1);
            this.splitContainer3.Size = new System.Drawing.Size(588, 239);
            this.splitContainer3.SplitterDistance = 72;
            this.splitContainer3.TabIndex = 1;
            // 
            // myChart
            // 
            chartArea5.Name = "ChartArea1";
            this.myChart.ChartAreas.Add(chartArea5);
            this.myChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend5.Name = "Legend1";
            this.myChart.Legends.Add(legend5);
            this.myChart.Location = new System.Drawing.Point(0, 0);
            this.myChart.Name = "myChart";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            this.myChart.Series.Add(series5);
            this.myChart.Size = new System.Drawing.Size(588, 72);
            this.myChart.TabIndex = 0;
            this.myChart.Text = "chart1";
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(588, 163);
            this.textBox1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label_Time);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.panel_Trough);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(890, 94);
            this.panel1.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(54, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(313, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "label3";
            // 
            // changeFont
            // 
            this.changeFont.Image = global::PlayApparatus.Properties.Resources.字体;
            this.changeFont.Location = new System.Drawing.Point(276, 45);
            this.changeFont.Name = "changeFont";
            this.changeFont.Size = new System.Drawing.Size(31, 32);
            this.changeFont.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.changeFont.TabIndex = 13;
            this.changeFont.TabStop = false;
            this.changeFont.Click += new System.EventHandler(this.changeFont_Click);
            // 
            // saveVoice
            // 
            this.saveVoice.Image = global::PlayApparatus.Properties.Resources.stock_save;
            this.saveVoice.InitialImage = global::PlayApparatus.Properties.Resources.stock_save;
            this.saveVoice.Location = new System.Drawing.Point(315, 45);
            this.saveVoice.Name = "saveVoice";
            this.saveVoice.Size = new System.Drawing.Size(32, 32);
            this.saveVoice.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.saveVoice.TabIndex = 4;
            this.saveVoice.TabStop = false;
            this.saveVoice.Click += new System.EventHandler(this.saveVoice_Click);
            // 
            // panel_Trough
            // 
            this.panel_Trough.BackColor = System.Drawing.Color.Transparent;
            this.panel_Trough.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel_Trough.BackgroundImage")));
            this.panel_Trough.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_Trough.Controls.Add(this.pictureBox_Hold);
            this.panel_Trough.Controls.Add(this.pictureBox_Bar);
            this.panel_Trough.Location = new System.Drawing.Point(79, 65);
            this.panel_Trough.Name = "panel_Trough";
            this.panel_Trough.Size = new System.Drawing.Size(365, 9);
            this.panel_Trough.TabIndex = 3;
            // 
            // pictureBox_Hold
            // 
            this.pictureBox_Hold.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_Hold.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_Hold.Image")));
            this.pictureBox_Hold.Location = new System.Drawing.Point(0, 1);
            this.pictureBox_Hold.Name = "pictureBox_Hold";
            this.pictureBox_Hold.Size = new System.Drawing.Size(30, 9);
            this.pictureBox_Hold.TabIndex = 1;
            this.pictureBox_Hold.TabStop = false;
            this.pictureBox_Hold.LocationChanged += new System.EventHandler(this.pictureBox_Hold_LocationChanged);
            this.pictureBox_Hold.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_Hold_MouseDown);
            this.pictureBox_Hold.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_Hold_MouseMove);
            this.pictureBox_Hold.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_Hold_MouseUp);
            // 
            // pictureBox_Bar
            // 
            this.pictureBox_Bar.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_Bar.Image")));
            this.pictureBox_Bar.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_Bar.Name = "pictureBox_Bar";
            this.pictureBox_Bar.Size = new System.Drawing.Size(0, 9);
            this.pictureBox_Bar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Bar.TabIndex = 0;
            this.pictureBox_Bar.TabStop = false;
            // 
            // pictureBox_Rest
            // 
            this.pictureBox_Rest.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_Rest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_Rest.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_Rest.Image")));
            this.pictureBox_Rest.Location = new System.Drawing.Point(153, 52);
            this.pictureBox_Rest.Name = "pictureBox_Rest";
            this.pictureBox_Rest.Size = new System.Drawing.Size(19, 19);
            this.pictureBox_Rest.TabIndex = 3;
            this.pictureBox_Rest.TabStop = false;
            this.pictureBox_Rest.Tag = "";
            this.pictureBox_Rest.Click += new System.EventHandler(this.pictureBox_Rest_Click);
            // 
            // panel_Sound
            // 
            this.panel_Sound.BackColor = System.Drawing.Color.Transparent;
            this.panel_Sound.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel_Sound.BackgroundImage")));
            this.panel_Sound.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_Sound.Location = new System.Drawing.Point(187, 57);
            this.panel_Sound.Name = "panel_Sound";
            this.panel_Sound.Size = new System.Drawing.Size(83, 9);
            this.panel_Sound.TabIndex = 2;
            // 
            // pictureBox_SoundHold
            // 
            this.pictureBox_SoundHold.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_SoundHold.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_SoundHold.Image")));
            this.pictureBox_SoundHold.Location = new System.Drawing.Point(253, 57);
            this.pictureBox_SoundHold.Name = "pictureBox_SoundHold";
            this.pictureBox_SoundHold.Size = new System.Drawing.Size(17, 9);
            this.pictureBox_SoundHold.TabIndex = 1;
            this.pictureBox_SoundHold.TabStop = false;
            this.pictureBox_SoundHold.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_SoundHold_MouseDown);
            this.pictureBox_SoundHold.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_SoundHold_MouseMove);
            this.pictureBox_SoundHold.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_SoundHold_MouseUp);
            // 
            // pictureBox_SoundBar
            // 
            this.pictureBox_SoundBar.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_SoundBar.Image")));
            this.pictureBox_SoundBar.Location = new System.Drawing.Point(187, 56);
            this.pictureBox_SoundBar.Name = "pictureBox_SoundBar";
            this.pictureBox_SoundBar.Size = new System.Drawing.Size(67, 10);
            this.pictureBox_SoundBar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_SoundBar.TabIndex = 0;
            this.pictureBox_SoundBar.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(13, 47);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(28, 28);
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Tag = "7";
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            this.pictureBox2.MouseEnter += new System.EventHandler(this.pictureBox_Min_MouseEnter);
            this.pictureBox2.MouseLeave += new System.EventHandler(this.pictureBox_Min_MouseLeave);
            // 
            // pictureBox_Down
            // 
            this.pictureBox_Down.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_Down.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_Down.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_Down.Image")));
            this.pictureBox_Down.Location = new System.Drawing.Point(114, 47);
            this.pictureBox_Down.Name = "pictureBox_Down";
            this.pictureBox_Down.Size = new System.Drawing.Size(28, 28);
            this.pictureBox_Down.TabIndex = 8;
            this.pictureBox_Down.TabStop = false;
            this.pictureBox_Down.Tag = "10";
            this.pictureBox_Down.Click += new System.EventHandler(this.pictureBox2_Click);
            this.pictureBox_Down.MouseEnter += new System.EventHandler(this.pictureBox_Min_MouseEnter);
            this.pictureBox_Down.MouseLeave += new System.EventHandler(this.pictureBox_Min_MouseLeave);
            // 
            // pictureBox_Play
            // 
            this.pictureBox_Play.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_Play.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_Play.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_Play.Image")));
            this.pictureBox_Play.Location = new System.Drawing.Point(46, 47);
            this.pictureBox_Play.Name = "pictureBox_Play";
            this.pictureBox_Play.Size = new System.Drawing.Size(28, 28);
            this.pictureBox_Play.TabIndex = 0;
            this.pictureBox_Play.TabStop = false;
            this.pictureBox_Play.Tag = "8";
            this.pictureBox_Play.Click += new System.EventHandler(this.pictureBox_Play_Click);
            this.pictureBox_Play.MouseEnter += new System.EventHandler(this.pictureBox_Min_MouseEnter);
            this.pictureBox_Play.MouseLeave += new System.EventHandler(this.pictureBox_Min_MouseLeave);
            // 
            // pictureBox_Stop
            // 
            this.pictureBox_Stop.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_Stop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_Stop.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_Stop.Image")));
            this.pictureBox_Stop.Location = new System.Drawing.Point(80, 47);
            this.pictureBox_Stop.Name = "pictureBox_Stop";
            this.pictureBox_Stop.Size = new System.Drawing.Size(28, 28);
            this.pictureBox_Stop.TabIndex = 1;
            this.pictureBox_Stop.TabStop = false;
            this.pictureBox_Stop.Tag = "9";
            this.pictureBox_Stop.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox_Stop.MouseEnter += new System.EventHandler(this.pictureBox_Min_MouseEnter);
            this.pictureBox_Stop.MouseLeave += new System.EventHandler(this.pictureBox_Min_MouseLeave);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.pictureBox_SoundHold);
            this.panel2.Controls.Add(this.changeFont);
            this.panel2.Controls.Add(this.saveVoice);
            this.panel2.Controls.Add(this.pictureBox_SoundBar);
            this.panel2.Controls.Add(this.pictureBox_Rest);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.pictureBox_Play);
            this.panel2.Controls.Add(this.pictureBox_Stop);
            this.panel2.Controls.Add(this.panel_Sound);
            this.panel2.Controls.Add(this.pictureBox_Down);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(530, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(360, 94);
            this.panel2.TabIndex = 14;
            // 
            // Frm_Play
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(890, 337);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.KeyPreview = true;
            this.Name = "Frm_Play";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "听写";
            this.TransparencyKey = System.Drawing.Color.Maroon;
            this.Activated += new System.EventHandler(this.Frm_Play_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_Play_FormClosing);
            this.Load += new System.EventHandler(this.Frm_Play_Load);
            this.Shown += new System.EventHandler(this.Frm_Play_Shown);
            this.Resize += new System.EventHandler(this.Frm_Play_Resize);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myChart)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.changeFont)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saveVoice)).EndInit();
            this.panel_Trough.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Hold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Rest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_SoundHold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_SoundBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Down)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Play)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Stop)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox pictureBox_Play;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox pictureBox_Stop;
        public System.Windows.Forms.Timer timer_ShowTime;
        private System.Windows.Forms.Timer timer_Bend;
        private System.Windows.Forms.Panel panel_Sound;
        private System.Windows.Forms.PictureBox pictureBox_SoundBar;
        private System.Windows.Forms.PictureBox pictureBox_SoundHold;
        private System.Windows.Forms.PictureBox pictureBox_Rest;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox_Down;
        private System.Windows.Forms.Panel panel_Trough;
        public System.Windows.Forms.PictureBox pictureBox_Hold;
        private System.Windows.Forms.PictureBox pictureBox_Bar;
        private System.Windows.Forms.Label label_Time;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TreeView FileList_treeView;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox saveVoice;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.DataVisualization.Charting.Chart myChart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.PictureBox changeFont;
        private System.Windows.Forms.Panel panel2;

    }
}


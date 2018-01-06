using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;//sleep的命名空间
using System.IO;//文件及文件夹的命名空间
using System.Collections;//为ArrayList添加命名空间
using System.Windows.Forms.DataVisualization.Charting;
using System.Linq;
using System.Xml;

namespace PlayApparatus
{
    public partial class Frm_Play : Form
    {
        public Frm_Play()
        {
            InitializeComponent();
            //绘制波形
            InitializeChart();
        }

        #region  公共变量
        public string fname_part = null;      //在文件列表显示时用到

        //存储文件目录

        //存储音频数据时使用
        const int byteSample = 2;
        const int dataPosition = 40;
        //0x16 2byte 0002  双声道  
        //0x22 2byte 0010  16位  
        //0x18 4byte 0000AC44   44100采样率


        FrmClass Cla_FrmClass = new FrmClass();

        public static Size form_Size;

        public static int Example_PlayPause = 0;
        public static int Example_NoncePause = 0;
        public static Point Example_BarPoint;

        public static double Example_UpD = 0;
        public static double Example_DownD = 0;
        public static string Example_UpS = "";

        public static bool Example_BarMove = false;//播放进度条是否移动

        public static bool Example_LyMove = false;
        public static bool Example_Tly = true;
        public static int Example_BendC = 0;

        public static Point Example_MusicBarPoint;//鼠标在音量按钮的位置
        public static double Example_MusicToler = 0;//声间的度量单位
        public static bool Example_MusicBarMove = false;

        public static bool Example_Rest = false;//是否静音
        public static int Example_FormShow = 0;//窗体显示
        Random rand = new Random();//定义随机变量
        #endregion

        #region  "播放"窗体接收的消息
        /// <summary>
        /// "播放"窗体接收的消息
        /// </summary>
        /// <param FileN="string">播放文件的路径</param>
        public void FrmMessage(int Sign, string Tem_Str)
        {
            switch (Sign)
            {

                case 0:
                    {
                        string plainText=Tem_Str+".txt";
                        if (File.Exists(plainText))
                        {
                            StreamReader st;
                            st = new System.IO.StreamReader(plainText, System.Text.Encoding.UTF8);
                            //UTF-8通用编码
                            this.textBox1.Clear();
                            this.textBox1.Text = st.ReadToEnd();
                            st.Close();

                        }
                        else
                        {
                            this.textBox1.Clear();
                        }

                        timer_Bend.Enabled = false;
                        timer_ShowTime.Enabled = false;
                        Example_PlayPause = 1;
                        pictureBox_Play.Image = null;
                        pictureBox_Play.Image = (Image)Properties.Resources.播放按钮;
                        pictureBox_Play.Tag = 8;

                        ((Frm_Libretto)FrmClass.F_Libretto).FrmMessage(0, 0);
                        string Tem_Lyric = FrmClass.Example_PlayPath;
                        Tem_Lyric = Tem_Lyric.Substring(0, Tem_Lyric.LastIndexOf(Convert.ToChar("."))) + ".lrc";
                        FileInfo SFInfo = new FileInfo(Tem_Lyric);

                        if (SFInfo.Exists == true)
                        {
                            FrmClass.Example_ifLy = true;
                            Cla_FrmClass.ArrayList_Close(FrmClass.Example_ArrLyric);
                            FrmClass.Example_ArrLyric = new System.Collections.ArrayList(Cla_FrmClass.LRC_Lyric(Tem_Lyric));

                            FrmClass.Example_LyC = 0;
                            string Tem_upArr = FrmClass.Example_ArrLyric[FrmClass.Example_LyC].ToString();
                            Example_UpD = Convert.ToInt32(Tem_upArr.Substring(0, Tem_upArr.IndexOf(Convert.ToChar("|")))) / 1000;
                            Example_UpS = Tem_upArr.Substring(Tem_upArr.IndexOf(Convert.ToChar("|")) + 1, Tem_upArr.Length - Tem_upArr.IndexOf(Convert.ToChar("|")) - 1);
                            Tem_upArr = FrmClass.Example_ArrLyric[FrmClass.Example_LyC + 1].ToString();
                            Example_DownD = Convert.ToInt32(Tem_upArr.Substring(0, Tem_upArr.IndexOf(Convert.ToChar("|")))) / 1000;

                            ((Frm_Libretto)FrmClass.F_Libretto).FrmMessage(Cla_FrmClass.LRC_Lyric(Tem_Lyric));
                        }
                        Example_NoncePause = 2;
                        ((Frm_Screen)FrmClass.F_Screen).FrmMessage(0, FrmClass.Example_PlayPath, this);
                        Show_BendInfo(FrmClass.Example_PlayPath);
                        Bend_State(2);
                        break;
                    }
                case 1:
                    {
                        Show_BendInfo(FrmClass.Example_PlayPath);
                        break;
                    }
            }
        }
        #endregion

        #region  显示当前文件的基本信息
        /// <summary>
        /// 显示当前文件的基本信息
        /// </summary>
        /// <param FileN="string">播放文件的路径</param>
        public void Show_BendInfo(string FileN)
        {
            Example_BendC = 0;
            ArrayList Tem_ArrayBend = new ArrayList(Cla_FrmClass.GetFileDouble(FileN));
            for (int i = 0; i < Tem_ArrayBend.Count; i++)
            {
            }
            timer_Bend.Enabled = true;
        }
        #endregion

        #region  显示当前的播放状态
        /// <summary>
        /// 显示当前的播放状态
        /// </summary>
        /// <param n="int">标识</param>
        public void Bend_State(int n)
        {
            switch (n)
            {
                case 0:
                case 2:
                    {
                        break;
                    }
                case 1:
                    {
                        break;
                    }
                case 3:
                    {
                        break;
                    }
            }
        }
        #endregion

        #region  播放文件的上下移动
        /// <summary>
        /// 播放文件的上下移动
        /// </summary>
        /// <param n="int">标识是前进按钮还是后退按钮</param>
        public void MovePlayFile(int n)
        {
            int Tem_n = 0;
            int Tem_count = this.listView1.Items.Count - 1;
            if (!(n == 7 || n == 10))
                return;
            if (n == 7)
            {
                Tem_n = FrmClass.Example_ListMark - 1;
                if (Tem_n < 0)
                    return;
            }
            if (n == 10)
            {
                Tem_n = FrmClass.Example_ListMark + 1;
                if (Tem_n > Tem_count)
                    return;
            }
            timer_Bend.Enabled = false;
            timer_ShowTime.Enabled = false;
            if (FrmClass.Example_ListMark < 0)
                FrmClass.Example_ListMark = 0;
            if (FrmClass.Example_ListMark > this.listView1.Items.Count-1)
                FrmClass.Example_ListMark = this.listView1.Items.Count - 1;
            this.listView1.Items[FrmClass.Example_ListMark].Selected = false;
            this.listView1.Items[Tem_n].Selected = true;
            FrmClass.Example_PlayPath = fname_part.Substring(5) + "\\"+this.listView1.SelectedItems[0].Text.Trim();
            
            if (!File.Exists(FrmClass.Example_PlayPath))
            {
                MessageBox.Show("没有找到该媒体文件。");
                FrmClass.Example_ListMark = ((Frm_ListBox)FrmClass.F_List).listView_List.SelectedItems[0].Index;
                return;
            }

            ((Frm_Libretto)FrmClass.F_Libretto).FrmMessage(0, 0);
            string Tem_Lyric = FrmClass.Example_PlayPath;
            Tem_Lyric = Tem_Lyric.Substring(0, Tem_Lyric.LastIndexOf(Convert.ToChar("."))) + ".lrc";
            FileInfo SFInfo = new FileInfo(Tem_Lyric);
            if (SFInfo.Exists == true)
            {
                FrmClass.Example_ifLy = true;
                Cla_FrmClass.ArrayList_Close(FrmClass.Example_ArrLyric);
                FrmClass.Example_ArrLyric = new System.Collections.ArrayList(Cla_FrmClass.LRC_Lyric(Tem_Lyric));

                FrmClass.Example_LyC = 0;
                ((Frm_Libretto)FrmClass.F_Libretto).FrmMessage(Cla_FrmClass.LRC_Lyric(Tem_Lyric));
            }
            else
                FrmClass.Example_ifLy = false;

            FrmClass.Example_LyC = 0;
            ((Frm_Play)FrmClass.F_MPlay).FrmMessage(0, FrmClass.Example_PlayPath);
            ((Frm_Play)FrmClass.F_MPlay).Show_BendInfo(FrmClass.Example_PlayPath);
            //Bend_State(2);
            FrmClass.Example_ListMark = this.listView1.SelectedItems[0].Index;
        }
        #endregion

        public void SetPlayMode(int n)
        {
            switch (n)
            {
                case 2:
                    {
                        FrmMessage(0, FrmClass.Example_PlayPath);
                        break;
                    }
                case 3:
                case 4:
                    {
                        ListView Tem_List = this.listView1;
                        int tem_n = 0;
                        if (FrmClass.Example_ListMark < 0)
                            tem_n = 0;
                        else
                            tem_n = FrmClass.Example_ListMark;
                        if (FrmClass.Example_ListMark < (Tem_List.Items.Count - 1))
                        {
                            Tem_List.Items[tem_n].Selected = false;
                            Tem_List.Items[tem_n].Focused = false;
                            if (FrmClass.Example_ListMark < 0)
                                tem_n = -1;
                            Tem_List.Items[tem_n + 1].Selected = true;
                            Tem_List.Items[tem_n + 1].Focused = true;

                            //保存txt文件
                            SaveFileDialog sfd = new SaveFileDialog();
                            sfd.InitialDirectory = fname_part.Substring(5);
                            sfd.Filter = "txt文件(*.txt)|*.txt|全部文件(*.*)|*.*";
                            sfd.FileName = Path.GetFileName(FrmClass.Example_PlayPath)+".txt";
                            if (sfd.ShowDialog() == DialogResult.OK)
                            {
                                StreamWriter sw = new StreamWriter(sfd.FileName);
                                sw.WriteLine(textBox1.Text);
                                sw.Flush();//文件流
                                sw.Close();//最后要关闭写入状态
                            }


                            ListView.SelectedIndexCollection c = Tem_List.SelectedIndices;
                            FrmClass.Example_PlayPath = fname_part.Substring(5) + "\\" + Tem_List.Items[c[0]].SubItems[0].Text;
                            if (FrmClass.Example_ListMark < 0)
                                FrmClass.Example_ListMark = 0;
                            else
                                FrmClass.Example_ListMark = FrmClass.Example_ListMark + 1;

                            ////保存音频数据
                            //string voiDataPath=saveVoiceData(FrmClass.Example_PlayPath);
                            //showWaveform(voiDataPath);

                            //存储文件路径，作为历史文件
                            StreamWriter historySw = new StreamWriter("history.ini");
                            historySw.WriteLine(FrmClass.Example_PlayPath);
                            historySw.Flush();//文件流
                            historySw.Close();//最后要关闭写入状态

                            FrmMessage(0, FrmClass.Example_PlayPath);
                        }
                        //播放到最后一个
                        if (n == 4 && FrmClass.Example_ListMark == (Tem_List.Items.Count - 1))
                        {
                            /*Tem_List.Items[tem_n].Selected = false;
                            Tem_List.Items[tem_n].Focused = false;
                            Tem_List.Items[0].Selected = true;
                            Tem_List.Items[0].Focused = true;
                            FrmClass.Example_PlayPath = Tem_List.SelectedItems[0].Text.Trim();
                            FrmClass.Example_ListMark = 0;
                            FrmMessage(0, FrmClass.Example_PlayPath);*/
                        }
                        break;
                    }
                case 5:
                    {
                        ListView Tem_List = ((Frm_ListBox)FrmClass.F_List).listView_List;
                        int Tem_RD = rand.Next(0, Tem_List.Items.Count - 1);
                        if (Tem_RD == FrmClass.Example_ListMark)
                        {
                            FrmMessage(0, FrmClass.Example_PlayPath);
                        }
                        else
                        {
                            Tem_List.Items[FrmClass.Example_ListMark].BackColor = Color.DarkSeaGreen;
                            Tem_List.Items[FrmClass.Example_ListMark].Selected = false;
                            Tem_List.Items[FrmClass.Example_ListMark].Focused = false;
                            Tem_List.Items[Tem_RD].Selected = true;
                            Tem_List.Items[Tem_RD].Focused = true;
                            Tem_List.SelectedItems[0].BackColor = Color.DarkGreen;
                            FrmClass.Example_PlayPath = Tem_List.SelectedItems[0].SubItems[3].Text.Trim();
                            FrmClass.Example_ListMark = Tem_RD;
                            FrmMessage(0, FrmClass.Example_PlayPath);

                        }
                        break;
                    }
            }
            if (n >= 2 && n <= 5)
                Bend_State(2);
        }

        public void AddDirectories(TreeNode node)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(node.Tag.ToString());
                DirectoryInfo[] directories = dir.GetDirectories();
                foreach (DirectoryInfo item in directories)
                {
                    TreeNode childnode = node.Nodes.Add(item.Name);
                    childnode.Tag = item.FullName;
                    childnode.ImageIndex = 1;
                }

            }
            catch { }
        }

        private void Frm_Play_Load(object sender, EventArgs e)
        {
            //窗体位置的初始化
            Cla_FrmClass.ImageDir();
            FrmClass.ImgDir =  FrmClass.ImgDir+ "\\Image";
            Cla_FrmClass.FrmInitialize(this);
            FrmClass.F_MPlay = this;
            Example_MusicToler = 100.0 / (panel_Sound.Width - pictureBox_SoundHold.Width);

            InitTreeView();
        }
        private void InitTreeView()
        {
            TreeNode node = FileList_treeView.Nodes.Add("我的电脑");
            DriveInfo[] driveries = DriveInfo.GetDrives();
            foreach (DriveInfo dri in driveries)
            {
                if (dri.IsReady)
                {
                    TreeNode childnode = node.Nodes.Add(dri.Name);
                    childnode.Tag = dri.Name;
                    childnode.ImageIndex = 3;
                    AddDirectories(childnode);
                }
            }
            listView1.TileSize = new Size(150, 60);
            listView1.View = View.Details;
            listView1.Columns.Add("文件名", 240, HorizontalAlignment.Center);
            listView1.Columns.Add("文件大小", 240, HorizontalAlignment.Center);
            listView1.Columns.Add("创建时间", 300, HorizontalAlignment.Center);

            //是否存在历史树
            if (File.Exists("history.ini"))
            {
                //读取文件路径，构造树
                StreamReader historySw = new StreamReader("history.ini");
                string histPath = historySw.ReadLine();
                historySw.Close();//最后要关闭写入状态

                string[] dirSplit = histPath.Split('\\');
                dirSplit[0] = dirSplit[0] + "\\";
                TreeNode treeNode = FileList_treeView.Nodes[0];
                treeNode.Expand();
                for (int i = 0; i < dirSplit.Length - 1; i++)
                {
                    int number = 0;
                    if (dirSplit[i] != "")
                    {
                        foreach (TreeNode subNode in treeNode.Nodes)
                        {
                            if (subNode.Text == dirSplit[i])
                            {
                                treeNode = treeNode.Nodes[number];
                                treeNode.Expand();
                            }
                            number++;
                        }
                    }
                }
                //listView1
                listView1.Items.Clear();
                listView1.FullRowSelect = true;
                int count = 0;
                // State_filecount.Text = "文件个数：";
                fname_part = treeNode.FullPath;
                FileInfo[] files = new DirectoryInfo(treeNode.Tag.ToString()).GetFiles();
                for (int i = 0; i < files.Length; i++)
                {
                    //不显示听写结果(.txt)和音频数据(.temp)
                    string fileName = files[i].Name;
                    string[] fileSplit = fileName.Split('.');
                    if (fileSplit[fileSplit.Length - 1] != "txt" && fileSplit[fileSplit.Length - 1] != "temp")
                    {
                        ListViewItem item = new ListViewItem();
                        item.Text = files[i].Name;
                        item.ImageIndex = 0;
                        string size = string.Format("{0:f4}KB", (Convert.ToSingle(files[i].Length)) / 1024);
                        item.SubItems.Add(size);
                        item.SubItems.Add(files[i].CreationTime.ToString());
                        count++;
                        listView1.Items.Add(item);
                    }
                }
            }
        }

        private void Frm_Play_FormClosing(object sender, FormClosingEventArgs e)
        {
            savePath(FrmClass.Example_PlayPath);
        }

        private void panel_Title_MouseDown(object sender, MouseEventArgs e)
        {
            int Tem_Y = 0;
            if (e.Button == MouseButtons.Left)
            {
                Cla_FrmClass.FrmBackCheck();
                Tem_Y = e.Y;
                FrmClass.FrmPoint = new Point(e.X, Tem_Y);
                FrmClass.CPoint = new Point(-e.X, -Tem_Y);
                if (FrmClass.Example_List_AdhereTo)
                {
                    Cla_FrmClass.FrmDistanceJob(this, FrmClass.F_List);
                    if (FrmClass.Example_Assistant_AdhereTo)
                    {
                        Cla_FrmClass.FrmDistanceJob(this, FrmClass.F_Libretto);
                    }
                }
                if (FrmClass.Example_Libretto_AdhereTo)
                {
                    Cla_FrmClass.FrmDistanceJob(this, FrmClass.F_Libretto);
                    if (FrmClass.Example_Assistant_AdhereTo)
                    {
                        Cla_FrmClass.FrmDistanceJob(this, FrmClass.F_List);
                    }
                }
                if (!(this.Focused == true || FrmClass.F_List.Focused == true || FrmClass.F_Libretto.Focused == true))
                {
                    FrmClass.F_Screen.Focus();
                    FrmClass.F_List.Focus();
                    FrmClass.F_Libretto.Focus();
                    this.Focus();
                }
            }
        }

        private void panel_Title_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

                Cla_FrmClass.FrmMove(this, e);
                if (FrmClass.Example_List_AdhereTo)
                {

                    Cla_FrmClass.ManyFrmMove(this, e, FrmClass.F_List);
                    Cla_FrmClass.FrmInitialize(FrmClass.F_List);
                    if (FrmClass.Example_Assistant_AdhereTo)
                    {
                        Cla_FrmClass.ManyFrmMove(this, e, FrmClass.F_Libretto);
                        Cla_FrmClass.FrmInitialize(FrmClass.F_Libretto);
                    }
                }

                if (FrmClass.Example_Libretto_AdhereTo)
                {
                    Cla_FrmClass.ManyFrmMove(this, e, FrmClass.F_Libretto);
                    Cla_FrmClass.FrmInitialize(FrmClass.F_Libretto);
                    if (FrmClass.Example_Assistant_AdhereTo)
                    {
                        Cla_FrmClass.ManyFrmMove(this, e, FrmClass.F_List);
                        Cla_FrmClass.FrmInitialize(FrmClass.F_List);
                    }
                }
                Cla_FrmClass.FrmInitialize(this);
            }
        }

        private void panel_Title_MouseUp(object sender, MouseEventArgs e)
        {
            Cla_FrmClass.FrmPlace(this);
        }

        private void pictureBox_Close_Click(object sender, EventArgs e)
        {
            timer_ShowTime.Enabled = false;
            FrmClass.F_List.Close();
            FrmClass.F_List.Dispose();
            FrmClass.F_Libretto.Close();
            FrmClass.F_Libretto.Dispose();
            FrmClass.F_Screen.Close();
            FrmClass.F_Screen.Dispose();
            timer_Bend.Enabled = false;
            this.Close();
            this.Dispose();
        }

        private void pictureBox_List_Click(object sender, EventArgs e)
        {
            Cla_FrmClass.Frm_ShowAndHide(FrmClass.F_List);
        }

        private void pictureBox_Libretto_Click(object sender, EventArgs e)
        {
            Cla_FrmClass.Frm_ShowAndHide(FrmClass.F_Libretto);
        }

        private void Frm_Play_Shown(object sender, EventArgs e)
        {
            //显示列表窗体
            FrmClass.F_List = new Frm_ListBox();
            FrmClass.F_List.ShowInTaskbar = false;
            FrmClass.Example_ListShow = true;
            //FrmClass.F_List.Show();
            //显示歌词窗体
            FrmClass.F_Libretto = new Frm_Libretto();
            FrmClass.F_Libretto.ShowInTaskbar = false;
            FrmClass.Example_LibrettoShow = true;
            //FrmClass.F_Libretto.Show();
            FrmClass.F_Libretto.Left = this.Left + this.Width;
            FrmClass.F_Libretto.Top = this.Top;
            //显示影象窗体
            FrmClass.F_Screen = new Frm_Screen();
            FrmClass.Example_ScreenShow = false;
            FrmClass.F_Screen.Hide();
            //FrmClass.F_Screen.Show();
            //各窗体位置的初始化
            Cla_FrmClass.FrmInitialize(FrmClass.F_List);
            Cla_FrmClass.FrmInitialize(FrmClass.F_Libretto);
        }

        private void pictureBox_File_Click(object sender, EventArgs e)
        {
            FrmClass.Example_ifLy = false;
            openFileDialog1.Filter = "AVI文件(*.AVI)|*.avi|MP3文件(*.MP3)|*.mp3|DAT文件(*.DAT)|*.dat|WAV文件(*.WAV)|*.wav|RMVB文件(*.RMVB)|*.rmvb|RM文件(*.RM)|*.rm|ALL文件(*.*)|*.*";
            openFileDialog1.Title = "请选择播放文件";
            openFileDialog1.FileName = "";
            if (FrmClass.Example_ListMark < 0)
                FrmClass.Example_ListMark = 0;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ((Frm_Libretto)FrmClass.F_Libretto).FrmMessage(0, 0);
                string Tem_Lyric = openFileDialog1.FileName;
                if (!File.Exists(Tem_Lyric))
                {
                    MessageBox.Show("没有找到该媒体文件。");
                    return;
                }
                Tem_Lyric = Tem_Lyric.Substring(0, Tem_Lyric.LastIndexOf(Convert.ToChar("."))) + ".lrc";
                FileInfo SFInfo = new FileInfo(Tem_Lyric);
                if (SFInfo.Exists == true)
                {
                    FrmClass.Example_ifLy = true;
                    Cla_FrmClass.ArrayList_Close(FrmClass.Example_ArrLyric);
                    FrmClass.Example_ArrLyric = new System.Collections.ArrayList(Cla_FrmClass.LRC_Lyric(Tem_Lyric));

                    FrmClass.Example_LyC = 0;
                    ((Frm_Libretto)FrmClass.F_Libretto).FrmMessage(Cla_FrmClass.LRC_Lyric(Tem_Lyric));
                }
                else
                    FrmClass.Example_ifLy = false;
                FrmClass.Example_AddFileSign = 1;
                ((Frm_ListBox)FrmClass.F_List).FrmMessage(0, openFileDialog1.FileName);
                FrmClass.Example_PlayPath = openFileDialog1.FileName;
                Example_PlayPause = 0;

                pictureBox_Play_Click(sender, e);
                Bend_State(2);
                if (FrmClass.Example_PlayPath.Substring(FrmClass.Example_PlayPath.LastIndexOf("."), FrmClass.Example_PlayPath.Length - FrmClass.Example_PlayPath.LastIndexOf(".")).ToLower() != ".rmvb".ToLower() && FrmClass.Example_PlayPath.Substring(FrmClass.Example_PlayPath.LastIndexOf("."), FrmClass.Example_PlayPath.Length - FrmClass.Example_PlayPath.LastIndexOf(".")).ToLower() != ".rm".ToLower())
                    Show_BendInfo(openFileDialog1.FileName);
            }
        }

        private void pictureBox_Play_Click(object sender, EventArgs e)
        {
            if (FrmClass.Example_PlayPath == "")
            {
                if (this.listView1.Items.Count > 0)
                {
                    if (listView1.SelectedIndices.Count == 0)
                    {
                        listView1.Select();
                        listView1.Items[0].Selected = true;
                        ListView.SelectedIndexCollection c = listView1.SelectedIndices;
                        FrmClass.Example_PlayPath = fname_part.Substring(5) + "\\" + listView1.Items[c[0]].SubItems[0].Text;
                        ////保存音频数据
                        //string voiDataPath = saveVoiceData(FrmClass.Example_PlayPath);
                        //showWaveform(voiDataPath);

                        //存储文件路径，作为历史文件
                        StreamWriter historySw = new StreamWriter("history.ini");
                        historySw.WriteLine(FrmClass.Example_PlayPath);
                        historySw.Flush();//文件流
                        historySw.Close();//最后要关闭写入状态

                        ((Frm_Play)FrmClass.F_MPlay).FrmMessage(0, FrmClass.Example_PlayPath);
                    }
                }
                else
                {
                    pictureBox_File_Click(sender, e);
                    return;
                }
            }
            if (pictureBox_Hold.Left==0)
                Example_PlayPause = 0;
            Example_NoncePause = Example_PlayPause;

            if (!File.Exists(FrmClass.Example_PlayPath))
            {
                MessageBox.Show("没有找到该媒体文件。");
                return;
            }

            if (timer_Bend.Enabled == false)
            {
                Show_BendInfo(FrmClass.Example_PlayPath);
                ((Frm_Screen)FrmClass.F_Screen).FrmMessage(0, FrmClass.Example_PlayPath, this);
            }

            if (Example_PlayPause == 0)
                Example_PlayPause = 1;
            else
            {
                if (Example_PlayPause == 1)
                {
                    pictureBox_Play.Tag = 12;
                    pictureBox_Play.Image = null;
                    pictureBox_Play.Image = Properties.Resources.暂停按钮变;

                    Example_PlayPause = 2;
                }
                else
                {
                    pictureBox_Play.Tag = 8;
                    pictureBox_Play.Image = null;
                    pictureBox_Play.Image = Properties.Resources.播放按钮变;

                    Example_PlayPause = 1;
                }
            }
            if (Example_NoncePause == 0)
            {
                string Tem_Lyric = FrmClass.Example_PlayPath;
                Tem_Lyric = Tem_Lyric.Substring(0, Tem_Lyric.LastIndexOf(Convert.ToChar("."))) + ".lrc";
                FileInfo SFInfo = new FileInfo(Tem_Lyric);

                if (SFInfo.Exists == true)
                {
                    FrmClass.Example_ifLy = true;
                    Cla_FrmClass.ArrayList_Close(FrmClass.Example_ArrLyric);
                    FrmClass.Example_ArrLyric = new System.Collections.ArrayList(Cla_FrmClass.LRC_Lyric(Tem_Lyric));
                    FrmClass.Example_LyC = 0;
                    ((Frm_Libretto)FrmClass.F_Libretto).FrmMessage(Cla_FrmClass.LRC_Lyric(Tem_Lyric));
                }
            }
            Bend_State(Example_NoncePause);
            ((Frm_Screen)FrmClass.F_Screen).FrmMessage(Example_NoncePause, FrmClass.Example_PlayPath, this);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FrmClass.Example_ifLy = false;

            timer_Bend.Enabled = false;

            ((Frm_Libretto)FrmClass.F_Libretto).FrmMessage(0, 0);
            ((Frm_Screen)FrmClass.F_Screen).FrmMessage(3, FrmClass.Example_PlayPath, this);
            Example_PlayPause = 0;
            Example_NoncePause = 3;
            label_Time.Text = "00:00";
            pictureBox_Hold.Left = 0;
            Bend_State(Example_NoncePause);
            FrmClass.Example_ifLy = false;
            if (((Frm_ListBox)FrmClass.F_List).listView_List.Items.Count == 0)
                FrmClass.Example_PlayPath = "";
        }

        private void pictureBox_Hold_MouseDown(object sender, MouseEventArgs e)
        {
            Example_BarMove = true;
            Example_BarPoint = new Point(e.X, e.Y);
        }

        private void pictureBox_Hold_MouseMove(object sender, MouseEventArgs e)
        {
            Point Tem_BPoint;
            Point Tem_BPoint1;
            if (e.Button == MouseButtons.Left)
            {
                if (Example_NoncePause == 3)
                    return;
                if (Example_BarMove == false)
                    return;
                if (Example_BarMove)
                {
                    Tem_BPoint1 = Example_BarPoint;
                    Tem_BPoint = new Point(e.X, e.Y);

                    if (pictureBox_Hold.Left >= 0 && pictureBox_Hold.Left <= (panel_Trough.Width - pictureBox_Hold.Width))
                    {
                        pictureBox_Hold.Left = pictureBox_Hold.Left + Tem_BPoint.X - Tem_BPoint1.X;
                    }
                    else
                    {
                        if (pictureBox_Hold.Left < 0)
                        {
                            pictureBox_Hold.Left = 0;
                            pictureBox_Bar.Width = 0;
                        }
                        if (pictureBox_Hold.Left > (panel_Trough.Width - pictureBox_Hold.Width))
                        {
                            pictureBox_Hold.Left = (panel_Trough.Width - pictureBox_Hold.Width);
                            pictureBox_Bar.Width = (panel_Trough.Width - pictureBox_Hold.Width);
                        }
                        Example_BarMove = false;
                    }
                }
                Example_LyMove = true;
            }
        }

        private void pictureBox_Hold_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Example_LyMove == true)
                    Example_LyMove = true;
                else
                    Example_LyMove = false;

                if (FrmClass.Example_PlayPath == "" || Example_NoncePause == 3)
                {
                    Example_BarMove = false;
                    FrmClass.Example_BarLeft = 0;
                    pictureBox_Hold.Left = 0;
                    pictureBox_Bar.Width = 0;
                    return;
                }
                Example_BarMove = false;
                FrmClass.Example_BarLeft = pictureBox_Hold.Left;
                if (pictureBox_Hold.Left < 0)
                {
                    pictureBox_Hold.Left = 0;
                    pictureBox_Bar.Width = 0;
                }
                if (pictureBox_Hold.Left > (panel_Trough.Width - pictureBox_Hold.Width))
                {
                    pictureBox_Hold.Left = (panel_Trough.Width - pictureBox_Hold.Width);
                    pictureBox_Bar.Width = (panel_Trough.Width - pictureBox_Hold.Width);
                }
                ((Frm_Screen)FrmClass.F_Screen).FrmMessage(4, Example_NoncePause.ToString(), this);
                FrmClass.Example_LyC = 0;
                Example_LyMove = false;
            }
        }

        private void timer_ShowTime_Tick(object sender, EventArgs e)
        {
            if (((Frm_Screen)FrmClass.F_Screen).axWindowsMediaPlayer1.currentMedia == null)
                return;
            if (((Frm_Screen)FrmClass.F_Screen).axWindowsMediaPlayer1.currentMedia.duration == 0)
            {
                return;
            }
            if (FrmClass.Example_TimeSizeD == 0)
            {
                FrmClass.Example_Barframe = 0;
                FrmClass.Example_TimeSizeD = ((Frm_Screen)FrmClass.F_Screen).axWindowsMediaPlayer1.currentMedia.duration;
                label_Time.Text = ((Frm_Screen)FrmClass.F_Screen).axWindowsMediaPlayer1.Ctlcontrols.currentPositionString;
                FrmClass.Example_Barframe = (FrmClass.Example_TimeSizeD / (panel_Trough.Width - pictureBox_Hold.Width));
            }
            else
            {
                if (FrmClass.Example_Barframe == 0)
                {
                    FrmClass.Example_Barframe = (FrmClass.Example_TimeSizeD / (panel_Trough.Width - pictureBox_Hold.Width));
                }
                if (FrmClass.Example_TimeSizeD != ((Frm_Screen)FrmClass.F_Screen).axWindowsMediaPlayer1.currentMedia.duration)
                {
                    FrmClass.Example_TimeSizeD = ((Frm_Screen)FrmClass.F_Screen).axWindowsMediaPlayer1.currentMedia.duration;
                    FrmClass.Example_Barframe = (FrmClass.Example_TimeSizeD / (panel_Trough.Width - pictureBox_Hold.Width));
                }

                string Tem_upArr = "";
                if (Example_BarMove==false)
                {
                    for (int i = FrmClass.Example_LyC; i < FrmClass.Example_ArrLyric.Count - 1; i++)
                    {
                        Tem_upArr = FrmClass.Example_ArrLyric[i].ToString();
                        Example_UpD = Convert.ToDouble(Tem_upArr.Substring(0, Tem_upArr.IndexOf(Convert.ToChar("|")))) / 1000;
                        if ((i + 1) == FrmClass.Example_ArrLyric.Count)
                            Tem_upArr = FrmClass.Example_ArrLyric[i].ToString();
                        else
                            Tem_upArr = FrmClass.Example_ArrLyric[i + 1].ToString();
                        Example_DownD = Convert.ToDouble(Tem_upArr.Substring(0, Tem_upArr.IndexOf(Convert.ToChar("|")))) / 1000;


                        if (FrmClass.Example_ifLy)
                        {
                            if (((Frm_Screen)FrmClass.F_Screen).axWindowsMediaPlayer1.Ctlcontrols.currentPosition >= Example_UpD && ((Frm_Screen)FrmClass.F_Screen).axWindowsMediaPlayer1.Ctlcontrols.currentPosition < Example_DownD)
                            {
                                ((Frm_Libretto)FrmClass.F_Libretto).FrmMessage(1, i);
                                FrmClass.Example_LyC = i;
                                break;
                            }

                            Tem_upArr = FrmClass.Example_ArrLyric[FrmClass.Example_ArrLyric.Count - 1].ToString();
                            Example_DownD = Convert.ToDouble(Tem_upArr.Substring(0, Tem_upArr.IndexOf(Convert.ToChar("|")))) / 1000;
                            if (((Frm_Screen)FrmClass.F_Screen).axWindowsMediaPlayer1.Ctlcontrols.currentPosition > Example_DownD)
                            {
                                ((Frm_Libretto)FrmClass.F_Libretto).FrmMessage(1, FrmClass.Example_ArrLyric.Count - 1);
                                FrmClass.Example_LyC = FrmClass.Example_ArrLyric.Count - 1;
                                break;
                            }
                        }
                    }
                }

                label_Time.Text = ((Frm_Screen)FrmClass.F_Screen).axWindowsMediaPlayer1.Ctlcontrols.currentPositionString;
                pictureBox_Hold.Left = (int)Math.Floor(((Frm_Screen)FrmClass.F_Screen).axWindowsMediaPlayer1.Ctlcontrols.currentPosition / FrmClass.Example_Barframe);
                if (((Frm_Screen)FrmClass.F_Screen).axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsStopped)
                {
                    FrmClass.Example_ifLy = false;
                    ((Frm_Libretto)FrmClass.F_Libretto).FrmMessage(0, 0);
                    pictureBox_Hold.Left = 0;
                    pictureBox_Bar.Width = 0;
                    timer_ShowTime.Enabled = false;
                    timer_Bend.Enabled = false;
                    Bend_State(3);
                    SetPlayMode(4);

                }
            }
            
        }

        private void pictureBox_Hold_LocationChanged(object sender, EventArgs e)
        {
            pictureBox_Bar.Width = pictureBox_Hold.Left;
        }

        private void timer_Bend_Tick(object sender, EventArgs e)
        {
        }

        private void pictureBox_SoundHold_MouseDown(object sender, MouseEventArgs e)
        {
            Example_MusicBarPoint = new Point(e.X, e.Y);
            Example_MusicBarMove = true;
        }

        private void pictureBox_SoundHold_MouseMove(object sender, MouseEventArgs e)
        {
            Point Tem_BPoint;
            Point Tem_BPoint1;
            if (e.Button == MouseButtons.Left)
            {
                if (Example_MusicBarMove == false)
                    return;
                if (Example_MusicBarMove)
                {
                    Tem_BPoint1 = Example_MusicBarPoint;
                    Tem_BPoint = new Point(e.X, e.Y);

                    if (pictureBox_SoundHold.Left >= 0 && pictureBox_SoundHold.Left <= (panel_Sound.Width - pictureBox_SoundHold.Width))
                    {
                        pictureBox_SoundHold.Left = pictureBox_SoundHold.Left + Tem_BPoint.X - Tem_BPoint1.X;
                        pictureBox_SoundBar.Width = pictureBox_SoundHold.Left;
                    }
                    else
                    {
                        if (pictureBox_SoundHold.Left < 0)
                        {
                            pictureBox_SoundHold.Left = 0;
                            pictureBox_SoundBar.Width = 0;
                        }
                        if (pictureBox_SoundHold.Left > (panel_Sound.Width - pictureBox_SoundHold.Width))
                        {
                            pictureBox_SoundHold.Left = (panel_Sound.Width - pictureBox_SoundHold.Width);
                            pictureBox_SoundBar.Width = (panel_Sound.Width - pictureBox_SoundHold.Width);
                        }
                        Example_MusicBarMove = false;
                    }
                }
                ((Frm_Screen)FrmClass.F_Screen).axWindowsMediaPlayer1.settings.volume = (int)Math.Floor(Example_MusicToler * pictureBox_SoundHold.Left);
            }
        }

        private void pictureBox_SoundHold_MouseUp(object sender, MouseEventArgs e)
        {
            Example_MusicBarMove = false;
        }

        private void pictureBox_Rest_Click(object sender, EventArgs e)
        {
            ((PictureBox)sender).Image = null;
            if (Example_Rest)
            {
                Example_Rest = false;
                ((PictureBox)sender).Image = Properties.Resources.音量按钮;
            }
            else
            {
                Example_Rest = true;
                ((PictureBox)sender).Image = Properties.Resources.音量按钮变色;
            }
            ((Frm_Screen)FrmClass.F_Screen).axWindowsMediaPlayer1.settings.mute = Example_Rest;
        }

        private void pictureBox_Min_MouseEnter(object sender, EventArgs e)
        {
            Cla_FrmClass.ButtonChange((PictureBox)sender, Convert.ToInt16(((PictureBox)sender).Tag.ToString()), true);
        }

        private void pictureBox_Min_MouseLeave(object sender, EventArgs e)
        {
            Cla_FrmClass.ButtonChange((PictureBox)sender, Convert.ToInt16(((PictureBox)sender).Tag.ToString()), false);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MovePlayFile(Convert.ToInt16(((PictureBox)sender).Tag.ToString()));
        }

        private void pictureBox_Min_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            ((Frm_ListBox)FrmClass.F_List).WindowState = FormWindowState.Minimized;
            ((Frm_Libretto)FrmClass.F_Libretto).WindowState = FormWindowState.Minimized;
            Example_FormShow = 1;
        }

        private void Frm_Play_Activated(object sender, EventArgs e)
        {
            if (Example_FormShow == 1)
            {
                ((Frm_ListBox)FrmClass.F_List).WindowState = FormWindowState.Normal;
                ((Frm_Libretto)FrmClass.F_Libretto).WindowState = FormWindowState.Normal;
                this.WindowState = FormWindowState.Normal;
                Example_FormShow = 0;
            }
        }

        private void pictureBox_WF_Click(object sender, EventArgs e)
        {
            Cla_FrmClass.Frm_ShowAndHide(FrmClass.F_Screen);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        #region 选择文件

        /// Description:ListView控件排序比较器
        /// </summary>
        class ListViewSort : IComparer
        {
            private int col;
            private bool descK;
            public ListViewSort()
            {
                col = 0;
            }
            public ListViewSort(int column, object Desc)
            {
                descK = (bool)Desc;
                col = column; //当前列,0,1,2...,参数由ListView控件的ColumnClick事件传递 
            }
            public int Compare(object x, object y)
            {
                int tempInt = String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
                if (descK) return -tempInt;
                else return tempInt;
            }
        }

        private void FileList_treeView_AfterExpand(object sender, TreeViewEventArgs e)
        {
            foreach (TreeNode node in e.Node.Nodes)
            {
                if (node.Nodes.Count == 0)
                {
                    AddDirectories(node);
                }
            }
        }

        private void FileList_treeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            listView1.Items.Clear();
            listView1.FullRowSelect = true;
            int count = 0;
            // State_filecount.Text = "文件个数：";
            fname_part = e.Node.FullPath;
            try
            {

                FileInfo[] files = new DirectoryInfo(e.Node.Tag.ToString()).GetFiles();
                for (int i = 0; i < files.Length; i++)
                {
                    //不显示听写结果(.txt)和音频数据(.temp)
                    string fileName = files[i].Name;
                    string[] fileSplit = fileName.Split('.');
                    if (fileSplit[fileSplit.Length - 1] != "txt" && fileSplit[fileSplit.Length - 1] != "temp")
                    {
                        ListViewItem item = new ListViewItem();
                        item.Text = files[i].Name;
                        item.ImageIndex = 0;
                        string size = string.Format("{0:f4}KB", (Convert.ToSingle(files[i].Length)) / 1024);
                        item.SubItems.Add(size);
                        item.SubItems.Add(files[i].CreationTime.ToString());
                        count++;
                        listView1.Items.Add(item);
                    }
                }
                //DirectoryInfo dir = new DirectoryInfo(e.Node.Tag.ToString());
                //DirectoryInfo[] directories = dir.GetDirectories();
                //foreach (DirectoryInfo dirs in directories)
                //{
                //    ListViewItem item = new ListViewItem();
                //    item.Text = dirs.Name;
                //    item.ImageIndex = 1;
                //    item.SubItems.Add("");
                //    item.SubItems.Add(dirs.CreationTime.ToString());
                //    count++;
                //    listView1.Items.Add(item);
                //}
                //// State_filecount.Text += count.ToString();
            }
            catch { }
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (this.listView1.Columns[e.Column].Tag == null)
                this.listView1.Columns[e.Column].Tag = true;
            bool flag = (bool)this.listView1.Columns[e.Column].Tag;
            if (flag)
                this.listView1.Columns[e.Column].Tag = false;
            else
                this.listView1.Columns[e.Column].Tag = true;
            this.listView1.ListViewItemSorter = new ListViewSort(e.Column, this.listView1.Columns[e.Column].Tag);
            this.listView1.Sort();//对列表进行自定义排序  
        }
        #endregion

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices != null && listView1.SelectedIndices.Count > 0)
            {
                ListView.SelectedIndexCollection c = listView1.SelectedIndices;
                FrmClass.Example_PlayPath = fname_part.Substring(5) + "\\" + listView1.Items[c[0]].SubItems[0].Text;
                ////存储音频数据
                //string voiDataPath = saveVoiceData(FrmClass.Example_PlayPath);
                //showWaveform(voiDataPath);

                //存储文件路径，作为历史文件
                StreamWriter historySw = new StreamWriter("history.ini");
                historySw.WriteLine(FrmClass.Example_PlayPath);
                historySw.Flush();//文件流
                historySw.Close();//最后要关闭写入状态

                ((Frm_Play)FrmClass.F_MPlay).FrmMessage(0, FrmClass.Example_PlayPath);
                FrmClass.Example_ListMark = listView1.SelectedItems[0].Index;
            }
        }

        private void saveVoice_Click(object sender, EventArgs e)
        {
            //保存txt文件
            string txtFileName = FrmClass.Example_PlayPath + ".txt";
            StreamWriter sw = new StreamWriter(txtFileName);
            sw.WriteLine(textBox1.Text);
            sw.Flush();//文件流
            sw.Close();//最后要关闭写入状态
        }
        #region 显示波形
        private void InitializeChart()
        {
            myChart.ChartAreas.Clear();
            myChart.Series.Clear();


            #region 设置图表的属性
            //图表的背景色
            myChart.BackColor = Color.FromArgb(211, 223, 240);
            //图表背景色的渐变方式
            myChart.BackGradientStyle = GradientStyle.TopBottom;
            //图表的边框颜色、
            myChart.BorderlineColor = Color.FromArgb(26, 59, 105);
            //图表的边框线条样式
            myChart.BorderlineDashStyle = ChartDashStyle.Solid;
            //图表边框线条的宽度
            myChart.BorderlineWidth = 2;
            //图表边框的皮肤
            myChart.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
            #endregion


            #region 设置图表区属性
            ChartArea chartArea = new ChartArea("Default");
            //设置Y轴刻度间隔大小
            chartArea.AxisY.Interval = 1;
            //设置Y轴的数据类型格式
            //chartArea.AxisY.LabelStyle.Format = "C";
            //设置背景色
            chartArea.BackColor = Color.FromArgb(64, 165, 191, 228);
            //设置背景渐变方式
            chartArea.BackGradientStyle = GradientStyle.TopBottom;
            //设置渐变和阴影的辅助背景色
            chartArea.BackSecondaryColor = Color.White;
            //设置边框颜色
            chartArea.BorderColor = Color.FromArgb(64, 64, 64, 64);
            //设置阴影颜色
            chartArea.ShadowColor = Color.Transparent;
            //设置X轴和Y轴线条的颜色
            chartArea.AxisX.LineColor = Color.FromArgb(64, 64, 64, 64);
            chartArea.AxisY.LineColor = Color.FromArgb(64, 64, 64, 64);
            //设置X轴和Y轴线条的宽度
            chartArea.AxisX.LineWidth = 1;
            chartArea.AxisY.LineWidth = 1;
            //设置图表区网格横纵线条的颜色
            chartArea.AxisX.MajorGrid.LineColor = Color.FromArgb(64, 64, 64, 64);
            chartArea.AxisY.MajorGrid.LineColor = Color.FromArgb(64, 64, 64, 64);
            //设置图表区网格横纵线条的宽度
            chartArea.AxisX.MajorGrid.LineWidth = 1;
            chartArea.AxisY.MajorGrid.LineWidth = 1;
            //设置坐标轴刻度线不延长出来
            chartArea.AxisX.MajorTickMark.Enabled = false;
            chartArea.AxisY.MajorTickMark.Enabled = false;
            //开启下面两句能够隐藏网格线条
            //chartArea.AxisX.MajorGrid.Enabled = false;
            //chartArea.AxisY.MajorGrid.Enabled = false;
            //设置X轴的显示类型及显示方式
            chartArea.AxisX.Interval = 0; //设置为0表示由控件自动分配
            chartArea.AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
            chartArea.AxisX.LabelStyle.IsStaggered = true;
            //chartArea.AxisX.MajorGrid.IntervalType = DateTimeIntervalType.Minutes;
            //chartArea.AxisX.LabelStyle.IntervalType = DateTimeIntervalType.Minutes;
            //设置文本角度
            //chartArea.AxisX.LabelStyle.Angle = 45;
            //设置文本自适应
            chartArea.AxisX.IsLabelAutoFit = true;
            //设置X轴允许拖动放大
            chartArea.CursorX.IsUserEnabled = true;
            chartArea.CursorX.IsUserSelectionEnabled = true;
            chartArea.CursorX.Interval = 0;
            chartArea.CursorX.IntervalOffset = 0;
            chartArea.AxisX.ScaleView.Zoomable = true;
            chartArea.AxisX.ScrollBar.IsPositionedInside = false;

            myChart.ChartAreas.Add(chartArea);
            #endregion

            //线条2：主要曲线
            Series series = new Series("Default");
            //设置线条类型
            series.ChartType = SeriesChartType.Line;
            //线条宽度
            series.BorderWidth = 1;
            //阴影宽度
            series.ShadowOffset = 0;
            //是否显示在图例集合Legends
            series.IsVisibleInLegend = false;
            //线条上数据点上是否有数据显示
            series.IsValueShownAsLabel = false;
            //线条颜色
            series.Color = Color.MediumPurple;
            //设置曲线X轴的显示类型
            //series.XValueType = ChartValueType.DateTime;
            ////设置数据点的类型
            //series.MarkerStyle = MarkerStyle.Circle;
            ////线条数据点的大小
            //series.MarkerSize = 5;
            myChart.Series.Add(series);


        }
        private void showWaveform(string filePath)
        {
            List<double> listY = new List<double>();
            StreamReader sr = new StreamReader(filePath, Encoding.Default);
            while (!sr.EndOfStream)
            {
                listY.Add(double.Parse(sr.ReadLine()));
            }
            sr.Close();
            List<int> listX = new List<int>();
            for (int i = 0; i < listY.Count; i++)
            {
                listX.Add(i);
            }

            //设置X轴的最小值为第一个点的X坐标值
            myChart.ChartAreas[0].AxisX.Minimum = listX[0];
            //开始画线
            for (int i = 0; i < listX.Count; i = i + 20)
            {
                myChart.Series[0].Points.AddXY(listX[i], listY[i]);
            }
        }
        #endregion

        #region 保存音频数据点
        private string saveVoiceData(string FilePath)
        { 
            byte[] length = new byte[4];
            FileStream fs = new FileStream(FilePath, FileMode.Open, FileAccess.Read);
            fs.Position = dataPosition;
            fs.Read(length, 0, 4);
            byte[] content = new byte[getHexToInt(length)];
            string[] sample = new string[content.Length / byteSample];
            fs.Read(content, 0, content.Length);
            getHex(content);
            sample = getSample(content);
            string voiceDataPath = FilePath + ".temp";
            if (!File.Exists(voiceDataPath))
            {
                StreamWriter sw = new StreamWriter(voiceDataPath, true, Encoding.Default);
                foreach (string i in sample)
                {
                    sw.Flush();
                    sw.WriteLine(i);
                }
                sw.Close();
            }
            return voiceDataPath;
        }

        static int getHexToInt(byte[] x)
        {
            string retValue = "";
            for (int i = x.Length - 1; i >= 0; i--)
            {
                retValue += x[i].ToString("X");
            }
            return Convert.ToInt32(retValue, 16);
        }

        static void getHex(byte[] x)
        {
            byte tmp;
            for (int i = 0; i < x.Length; i++)
            {
                tmp = Convert.ToByte(x[i].ToString("X"), 16);
                x[i] = tmp;
            }
        }

        static string[] getSample(byte[] x)
        {
            string[] retValue = new string[x.Length / byteSample];

            for (int i = 0; i < retValue.Length; i++)
            {
                for (int j = (i + 1) * byteSample - 1; j >= i * byteSample; j--)
                {
                    retValue[i] += x[j].ToString("X");
                }
                retValue[i] = ((double)Convert.ToInt16(retValue[i], 16) / 32768).ToString("F4");
            }
            return retValue;
        }  
        #endregion

        #region 快进快退
        private void Frm_Play_KeyDown(object sender, KeyEventArgs e)
        {

        }
        #endregion

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)//取消方向键对控件的焦点的控件，用自己自定义的函数处理各个方向键的处理函数
        {
            switch (keyData)
            {
                case Keys.Up:
                    ((Frm_Screen)FrmClass.F_Screen).axWindowsMediaPlayer1.settings.volume += 5;
                    pictureBox_SoundHold.Left = (int)Math.Floor(((Frm_Screen)FrmClass.F_Screen).axWindowsMediaPlayer1.settings.volume / Example_MusicToler);
                    return true;
                case Keys.Down:
                    ((Frm_Screen)FrmClass.F_Screen).axWindowsMediaPlayer1.settings.volume -= 5;
                    pictureBox_SoundHold.Left = (int)Math.Floor(((Frm_Screen)FrmClass.F_Screen).axWindowsMediaPlayer1.settings.volume / Example_MusicToler);
                    return true;
                case Keys.Left:
                    ((Frm_Screen)FrmClass.F_Screen).axWindowsMediaPlayer1.Ctlcontrols.currentPosition -= 5;
                    return true;
                case Keys.Right:
                    ((Frm_Screen)FrmClass.F_Screen).axWindowsMediaPlayer1.Ctlcontrols.currentPosition += 5;
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Frm_Play_Resize(object sender, EventArgs e)
        {
        }
        #region 保存文件目录
        private void savePath(string filePath)
        {

        }
        #endregion

        //修改编辑框的字体
        private void changeFont_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();//此方法用于弹出字体对话框
            this.textBox1.Font = fontDialog1.Font;
        }


    }
}
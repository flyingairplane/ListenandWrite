using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;//��ӿؼ�������������ռ�
using System.Drawing;//���Point�������ռ�
using System.Collections;//ΪArrayList��������ռ�
using System.Runtime.InteropServices;//API�����������ռ�
using System.IO;//�ļ������������ռ�
//Ӧ��Scripting,�ڡ�������á��Ի�����ѡ��"COM"ѡ���Ȼ��ѡ��Microsoft Scripting Runtime��������ȷ������ť
//Ӧ��Shell32,�ڡ�������á��Ի�����ѡ��"COM"ѡ���Ȼ��ѡ��Microsoft Shell Controls And Automation��������ȷ������ť


namespace PlayApparatus
{
    class FrmClass
    {
        #region  ��¼�����ʵ������Ϣ-��������
        public static Form F_List = new Form();
        public static Form F_Libretto = new Form();
        public static Form F_Screen = new Form();
        public static Form F_MPlay = new Form();
        #endregion

        #region  ���Դ���-��������
        //��¼�������������ʾ
        public static bool Example_ListShow = false;
        public static bool Example_LibrettoShow = false;
        public static bool Example_ScreenShow = false;

        //��¼���ĵ�ǰλ��
        public static Point CPoint;  //��������ռ�using System.Drawing;
        public static Point FrmPoint;
        public static int Example_FSpace = 10;//���ô����ľ���

        //Frm_Play�����λ�ü���С
        public static int Example_Play_Top = 0;
        public static int Example_Play_Left = 0;
        public static int Example_Play_Width = 0;
        public static int Example_Play_Height = 0;
        public static bool Example_Assistant_AdhereTo = false;//���������Ƿ������һ��

        //Frm_ListBos�����λ�ü���С
        public static int Example_List_Top = 0;
        public static int Example_List_Left = 0;
        public static int Example_List_Width = 0;
        public static int Example_List_Height = 0;
        public static bool Example_List_AdhereTo = false;//���������Ƿ��������������һ��

        //Frm_Libretto�����λ�ü���С
        public static int Example_Libretto_Top = 0;
        public static int Example_Libretto_Left = 0;
        public static int Example_Libretto_Width = 0;
        public static int Example_Libretto_Height = 0;
        public static bool Example_Libretto_AdhereTo = false;//���������Ƿ��������������һ��

        //����֮��ľ����
        public static int Example_List_space_Top = 0;
        public static int Example_List_space_Left = 0;
        public static int Example_Libretto_space_Top = 0;
        public static int Example_Libretto_space_Left = 0;
        #endregion

        #region  ��Ƶ����-��������
        public static bool Example_Size = false;
        public static int Example_X = 0;
        public static int Example_Y = 0;
        public static int Example_CursotX = 0;
        public static int Example_CursotY = 0;
        public static int Example_Width = 0;
        public static int Example_Height = 0;
        public static int Example_Right = 0;
        public static string Example_File_Size = "";
        public static double Example_TimeSizeD = 0;
        public static string Example_TimeSizeS = "";
        public static double Example_Barframe = 0;//�ƶ�����֡��
        public static int Example_BarLeft = 0;
        public static string Example_PlayPath = "";//�����ļ���·��
        public static ArrayList Example_ArrLyric = new ArrayList();
        public static int Example_LyC = 0;//�洢��Ļ������λ��
        public static bool Example_ifLy = false;//�Ƿ��и���ļ�
        public static ArrayList Example_FileInfoL = new ArrayList();
        public static int Example_Mode = 3;//����ģʽ�����
        public static int Example_ListMark = 0;//��ǰ�б�Ĳ������
        public static int Example_ListNameNark = 0;//�б��е��б�����
        public static string Example_ListNameDir = "";//��ǰm3u�ļ���·��
        public static string ImgDir = "";//ͼƬ��·��
        public static int Example_AddFileSign = 0;//����ļ��ı�ʶ
        public static int Example_ListFClick = -1;//ɾ����ȡ������б�����
        #endregion

        #region  ���������Ƿ�������һ��
        /// <summary>
        /// ���������Ƿ�������һ��
        /// </summary>
        public void FrmBackCheck()
        {
            bool Tem_Magnetism = false;
            //Frm_ListBos��������
            Tem_Magnetism = false;
            if ((Example_Play_Top - Example_List_Top) == 0)
                Tem_Magnetism = true;
            if ((Example_Play_Left - Example_List_Left) == 0)
                Tem_Magnetism = true;
            if ((Example_Play_Left - Example_List_Left - Example_List_Width) == 0)
                Tem_Magnetism = true;
            if ((Example_Play_Left - Example_List_Left + Example_List_Width) == 0)
                Tem_Magnetism = true;
            if ((Example_Play_Top - Example_List_Top - Example_List_Height) == 0)
                Tem_Magnetism = true;
            if ((Example_Play_Top - Example_List_Top + Example_List_Height) == 0)
                Tem_Magnetism = true;
            if (Tem_Magnetism)
                Example_List_AdhereTo = true;

            //Frm_Libretto��������
            Tem_Magnetism = false;
            if ((Example_Play_Top - Example_Libretto_Top) == 0)
                Tem_Magnetism = true;
            if ((Example_Play_Left - Example_Libretto_Left) == 0)
                Tem_Magnetism = true;
            if ((Example_Play_Left - Example_Libretto_Left - Example_Libretto_Width) == 0)
                Tem_Magnetism = true;
            if ((Example_Play_Left - Example_Libretto_Left + Example_Libretto_Width) == 0)
                Tem_Magnetism = true;
            if ((Example_Play_Top - Example_Libretto_Top - Example_Libretto_Height) == 0)
                Tem_Magnetism = true;
            if ((Example_Play_Top - Example_Libretto_Top + Example_Libretto_Height) == 0)
                Tem_Magnetism = true;
            if (Tem_Magnetism)
                Example_Libretto_AdhereTo = true;

            //����������
            Tem_Magnetism = false;
            if ((Example_List_Top - Example_Libretto_Top) == 0)
                Tem_Magnetism = true;
            if ((Example_List_Left - Example_Libretto_Left) == 0)
                Tem_Magnetism = true;
            if ((Example_List_Left - Example_Libretto_Left - Example_Libretto_Width) == 0)
                Tem_Magnetism = true;
            if ((Example_List_Left - Example_Libretto_Left + Example_Libretto_Width) == 0)
                Tem_Magnetism = true;
            if ((Example_List_Top - Example_Libretto_Top - Example_Libretto_Height) == 0)
                Tem_Magnetism = true;
            if ((Example_List_Top - Example_Libretto_Top + Example_Libretto_Height) == 0)
                Tem_Magnetism = true;
            if (Tem_Magnetism)
                Example_Assistant_AdhereTo = true;
        }
        #endregion

        #region  ���ô����ϵĿؼ��ƶ�����
        /// <summary>
        /// ���ÿؼ��ƶ�����
        /// </summary>
        /// <param Frm="Form">����</param>
        /// <param e="MouseEventArgs">�ؼ����ƶ��¼�</param>
        public void FrmMove(Form Frm, MouseEventArgs e)  //Form��MouseEventArgs��������ռ�using System.Windows.Forms;
        {
            if (e.Button == MouseButtons.Left)
            {
                Point myPosittion = Control.MousePosition;//��ȡ��ǰ������Ļ����
                myPosittion.Offset(CPoint.X, CPoint.Y);//���ص�ǰ����λ��
                Frm.DesktopLocation = myPosittion;//���õ�ǰ��������Ļ�ϵ�λ��
            }
        }
        #endregion

        #region  ���㴰��֮��ľ����
        /// <summary>
        /// ���㴰��֮��ľ����
        /// </summary>
        /// <param Frm="Form">����</param>
        /// <param Follow="Form">���洰��</param>
        public void FrmDistanceJob(Form Frm, Form Follow)
        {
            switch (Follow.Name)
            {
                case "Frm_ListBox"://"�б�"����
                    {
                        Example_List_space_Top = Follow.Top - Frm.Top;
                        Example_List_space_Left = Follow.Left - Frm.Left;
                        break;
                    }
                case "Frm_Libretto"://"���"����
                    {
                        Example_Libretto_space_Top = Follow.Top - Frm.Top;
                        Example_Libretto_space_Left = Follow.Left - Frm.Left;
                        break;
                    }
            }
        }
        #endregion

        #region  ���Դ�����ƶ�
        /// <summary>
        /// ���Դ�����ƶ�
        /// </summary>
        /// <param Frm="Form">����</param>
        /// <param e="MouseEventArgs">�ؼ����ƶ��¼�</param>
        /// <param Follow="Form">���洰��</param>
        public void ManyFrmMove(Form Frm, MouseEventArgs e, Form Follow)  //Form��MouseEventArgs��������ռ�using System.Windows.Forms;
        {
            if (e.Button == MouseButtons.Left)
            {
                int Tem_Left = 0;
                int Tem_Top = 0;
                Point myPosittion = Control.MousePosition;//��ȡ��ǰ������Ļ����
                switch (Follow.Name)
                {
                    case "Frm_ListBox":
                        {
                            Tem_Top = Example_List_space_Top - FrmPoint.Y;
                            Tem_Left = Example_List_space_Left - FrmPoint.X;
                            break;
                        }
                    case "Frm_Libretto":
                        {
                            Tem_Top = Example_Libretto_space_Top - FrmPoint.Y;
                            Tem_Left = Example_Libretto_space_Left - FrmPoint.X;
                            break;
                        }
                }
                myPosittion.Offset(Tem_Left, Tem_Top);
                Follow.DesktopLocation = myPosittion;
            }
        }
        #endregion

        #region  �Դ����λ�ý��г�ʼ��
        /// <summary>
        /// �Դ����λ�ý��г�ʼ��
        /// </summary>
        /// <param Frm="Form">����</param>
        public void FrmInitialize(Form Frm)
        {
            switch (Frm.Name)
            {
                case "Frm_Play":
                    {
                        Example_Play_Top = Frm.Top;
                        Example_Play_Left = Frm.Left;
                        Example_Play_Width = Frm.Width;
                        Example_Play_Height = Frm.Height;
                        break;
                    }
                case "Frm_ListBox":
                    {
                        Example_List_Top = Frm.Top;
                        Example_List_Left = Frm.Left;
                        Example_List_Width = Frm.Width;
                        Example_List_Height = Frm.Height;
                        break;
                    }
                case "Frm_Libretto":
                    {
                        Example_Libretto_Top = Frm.Top;
                        Example_Libretto_Left = Frm.Left;
                        Example_Libretto_Width = Frm.Width;
                        Example_Libretto_Height = Frm.Height;
                        break;
                    }
            }

        }
        #endregion

        #region  �洢������ĵ�ǰ��Ϣ
        /// <summary>
        /// �洢������ĵ�ǰ��Ϣ
        /// </summary>
        /// <param Frm="Form">����</param>
        /// <param e="MouseEventArgs">�ؼ����ƶ��¼�</param>
        public void FrmPlace(Form Frm)
        {
            FrmInitialize(Frm);
            FrmMagnetism(Frm);
        }
        #endregion

        #region  ����Ĵ�������
        /// <summary>
        /// ����Ĵ�������
        /// </summary>
        /// <param Frm="Form">����</param>
        public void FrmMagnetism(Form Frm)
        {
            if (Frm.Name != "Frm_Play")
            {
                FrmMagnetismCount(Frm, Example_Play_Top, Example_Play_Left, Example_Play_Width, Example_Play_Height, "Frm_Play");
            }
            if (Frm.Name != "Frm_ListBox")
            {
                FrmMagnetismCount(Frm, Example_List_Top, Example_List_Left, Example_List_Width, Example_List_Height, "Frm_ListBox");
            }
            if (Frm.Name != "Frm_Libretto")
            {
                FrmMagnetismCount(Frm, Example_Libretto_Top, Example_Libretto_Left, Example_Libretto_Width, Example_Libretto_Height, "Frm_Libretto");
            }
            FrmInitialize(Frm);
        }
        #endregion

        #region  ���Դ���ļ���
        /// <summary>
        /// ���Դ���ļ���
        /// </summary>
        /// <param Frm="Form">�Ӵ���</param>
        /// <param top="int">�������ϱ߾�</param>
        /// <param left="int">��������߾�</param>
        /// <param width="int">������Ŀ��</param>
        /// <param height="int">������ĸ߶�</param>
        /// <param Mforms="string">������</param>
        public void FrmMagnetismCount(Form Frm, int top, int left, int width, int height, string Mforms)
        {
            bool Tem_Magnetism = false;//�ж��Ƿ��д��Է���
            string Tem_MainForm = "";//��ʱ��¼������
            string Tem_AssistForm = "";//��ʱ��¼������

            //������д��Դ���
            if ((Frm.Top + Frm.Height - top) <= Example_FSpace && (Frm.Top + Frm.Height - top) >= -Example_FSpace)
            {
                //��һ�������岻����������ʱ
                if ((Frm.Left >= left && Frm.Left <= (left + width)) || ((Frm.Left + Frm.Width) >= left && (Frm.Left + Frm.Width) <= (left + width)))
                {
                    Frm.Top = top - Frm.Height;
                    if ((Frm.Left - left) <= Example_FSpace && (Frm.Left - left) >= -Example_FSpace)
                        Frm.Left = left;
                    Tem_Magnetism = true;
                }
                //��һ�����������������ʱ
                if (Frm.Left <= left && (Frm.Left + Frm.Width) >= (left + width))
                {
                    Frm.Top = top - Frm.Height;
                    if ((Frm.Left - left) <= Example_FSpace && (Frm.Left - left) >= -Example_FSpace)
                        Frm.Left = left;
                    Tem_Magnetism = true;
                }

                if (Tem_Magnetism == true)
                {
                    if (Frm.Left == left)
                        Tem_Magnetism = false;
                }

            }
            else
                Tem_Magnetism = false;

            //������д��Դ���
            if ((Frm.Top - (top + height)) <= Example_FSpace && (Frm.Top - (top + height)) >= -Example_FSpace)
            {
                //��һ�������岻����������ʱ
                if ((Frm.Left >= left && Frm.Left <= (left + width)) || ((Frm.Left + Frm.Width) >= left && (Frm.Left + Frm.Width) <= (left + width)))
                {
                    Frm.Top = top + height;
                    if ((Frm.Left - left) <= Example_FSpace && (Frm.Left - left) >= -Example_FSpace)
                        Frm.Left = left;
                    Tem_Magnetism = true;
                }
                //��һ�����������������ʱ
                if (Frm.Left <= left && (Frm.Left + Frm.Width) >= (left + width))
                {
                    Frm.Top = top + height;
                    if ((Frm.Left - left) <= Example_FSpace && (Frm.Left - left) >= -Example_FSpace)
                        Frm.Left = left;
                    Tem_Magnetism = true;
                }

                if (Tem_Magnetism == true)
                {
                    if (Frm.Left == left)
                        Tem_Magnetism = false;
                }
            }
            else
                Tem_Magnetism = false;

            //������д��Դ���
            if ((Frm.Left + Frm.Width - left) <= Example_FSpace && (Frm.Left + Frm.Width - left) >= -Example_FSpace)
            {
                //��һ�������岻����������ʱ
                if ((Frm.Top > top && Frm.Top <= (top + height)) || ((Frm.Top + Frm.Height) >= top && (Frm.Top + Frm.Height) <= (top + height)))
                {
                    Frm.Left = left - Frm.Width;
                    if ((Frm.Top - top) <= Example_FSpace && (Frm.Top - top) >= -Example_FSpace)
                        Frm.Top = top;
                    Tem_Magnetism = true;
                }
                //��һ�����������������ʱ
                if (Frm.Top <= top && (Frm.Top + Frm.Height) >= (top + height))
                {
                    Frm.Left = left - Frm.Width;
                    if ((Frm.Top - top) <= Example_FSpace && (Frm.Top - top) >= -Example_FSpace)
                        Frm.Top = top;
                    Tem_Magnetism = true;
                }
            }
            else
                Tem_Magnetism = false;

            //������д��Դ���
            if ((Frm.Left - (left + width)) <= Example_FSpace && (Frm.Left - (left + width)) >= -Example_FSpace)
            {
                //��һ�������岻����������ʱ
                if ((Frm.Top > top && Frm.Top <= (top + height)) || ((Frm.Top + Frm.Height) >= top && (Frm.Top + Frm.Height) <= (top + height)))
                {
                    Frm.Left = left + width;
                    if ((Frm.Top - top) <= Example_FSpace && (Frm.Top - top) >= -Example_FSpace)
                        Frm.Top = top;
                    Tem_Magnetism = true;
                }
                //��һ�����������������ʱ
                if (Frm.Top <= top && (Frm.Top + Frm.Height) >= (top + height))
                {
                    Frm.Left = left + width;
                    if ((Frm.Top - top) <= Example_FSpace && (Frm.Top - top) >= -Example_FSpace)
                        Frm.Top = top;
                    Tem_Magnetism = true;
                }
            }
            else
                Tem_Magnetism = false;

            //if (Frm.Left == (left-Frm.Width) || Frm.Left == ((left + width)))
            //{
            //    if ((Frm.Top + Frm.Height - top) > Example_FSpace || (Frm.Top + Frm.Height - top) < -Example_FSpace)
            //        Tem_Magnetism = false;
            //}

            //if (Frm.Top == (top-Frm.Height) || Frm.Top == ((top + height)))
            //{
            //    if ((Frm.Left + Frm.Width - left) > Example_FSpace || (Frm.Left + Frm.Width - left) < -Example_FSpace)
            //        Tem_Magnetism = false;
            //}


            if (Frm.Name == "Frm_Play")
                Tem_MainForm = "Frm_Play";
            else
                Tem_AssistForm = Frm.Name;
            if (Mforms == "Frm_Play")
                Tem_MainForm = "Frm_Play";
            else
                Tem_AssistForm = Mforms;
            if (Tem_MainForm == "")
            {
                Example_Assistant_AdhereTo = Tem_Magnetism;
            }
            else
            {
                switch (Tem_AssistForm)
                {
                    case "Frm_ListBox":
                        Example_List_AdhereTo = Tem_Magnetism;
                        break;
                    case "Frm_Libretto":
                        Example_Libretto_AdhereTo = Tem_Magnetism;
                        break;
                }
            }
        }
        #endregion

        #region  ��ȡ���Ŵ������Ϣ
        /// <summary>
        /// ��ȡ���Ŵ������Ϣ(�������İ����¼�)
        /// </summary>
        /// <param Frm="Form">����</param>
        /// <param e="MouseEventArgs">�������й�����һЩ��Ϣ</param>
        public void FrmScreen_SizeInfo(Form Frm, Panel Pan, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Example_Size = true;
                Example_X = e.X;
                Example_Y = e.Y;
                Example_Width = Frm.Width;
                Example_Height = Frm.Height;
                Example_CursotX = Cursor.Position.X;
                Example_CursotY = Cursor.Position.Y;
                Example_Right = Frm.Width + Frm.Left;
            }
        }
        #endregion

        #region  �ı䲥�Ŵ���Ĵ�С
        /// <summary>
        /// �ı䲥�Ŵ���Ĵ�С(���������ƶ��¼�)
        /// </summary>
        /// <param Frm="Form">����</param>
        /// <param e="MouseEventArgs">�������й�����һЩ��Ϣ</param>
        public void FrmScreen_EnlargeSize(Form Frm, Panel Pan, MouseEventArgs e, int PWidth, int PHeight)
        {
            string panelName = "";
            if (e.Button == MouseButtons.Left)
            {
                if (Example_Size == false)
                    return;
                panelName = Pan.Name;
                if (Pan.Name == "panel_BL" || Pan.Name == "panel_BZ" || Pan.Name == "panel_BR")
                    panelName = "panel_Bottom";
                switch (panelName)
                {
                    case "panel_Right":
                        {
                            if (Frm.Width >= PWidth)
                            {
                                Frm.Width = Cursor.Position.X - Frm.Left + (Pan.Width - Example_X);
                                Frm.Height = PHeight + Frm.Width - PWidth;
                                Example_CursotX = Cursor.Position.X;

                            }
                            else
                            {
                                if (Cursor.Position.X > Example_CursotX)
                                {
                                    Frm.Width = Cursor.Position.X - Frm.Left + (Pan.Width - Example_X);
                                    Frm.Height = PHeight + Frm.Width - PWidth;
                                    Example_CursotX = Cursor.Position.X;
                                }
                                else
                                {
                                    Frm.Width = PWidth;
                                    Frm.Height = PHeight;
                                    Example_Size = false;
                                }
                            }
                            break;
                        }
                    case "panel_Bottom":
                        {
                            if (Frm.Height >= PHeight)
                            {
                                Frm.Height = Cursor.Position.Y - Frm.Top + (Pan.Height - Example_Y);
                                Frm.Width = 300 + Frm.Height - PHeight;
                                Example_CursotY = Cursor.Position.Y;
                            }
                            else
                            {
                                if (Cursor.Position.Y > Example_CursotY)
                                {
                                    Frm.Height = Cursor.Position.Y - Frm.Top + (Pan.Height - Example_Y);
                                    Frm.Width = PWidth + Frm.Height - PHeight;
                                    Example_CursotY = Cursor.Position.Y;
                                }
                                else
                                {
                                    Frm.Height = PHeight;
                                    Frm.Width = PWidth;
                                    Example_Size = false;
                                }
                            }
                            break;
                        }
                }

            }
        }
        #endregion

        #region  �ָ�����ĳ�ʼ��С
        /// <summary>
        /// �ָ�����ĳ�ʼ��С(���ɿ����ʱ���������Ĵ�СС��300*200,�ָ���ʼ״̬)
        /// </summary>
        /// <param Frm="Form">����</param>
        public void FrmScreen_FormerlySize(Form Frm, int PWidth, int PHeight)
        {
            if (Frm.Width < PWidth || Frm.Height < PHeight)
            {
                Frm.Width = PWidth;
                Frm.Height = PHeight;
                Example_Size = false;
            }
        }
        #endregion

        #region  �������������ʾ
        /// <summary>
        /// �������������ʾ
        /// </summary>
        /// <param Frm="Form">����</param>
        public void Frm_ShowAndHide(Form Frm)
        {
            
            bool Tem_Bool = false;
            if (Frm.Name == "Frm_ListBox")
                Tem_Bool = Example_ListShow;
            if (Frm.Name == "Frm_Libretto")
                Tem_Bool = Example_LibrettoShow;
            if (Frm.Name == "Frm_Screen")
                Tem_Bool = Example_ScreenShow;
            if (Tem_Bool)
            {
                if (Frm.Name != "Frm_Screen")
                    for (double d = 1; d > 0; d -= 0.2)
                    {
                        System.Threading.Thread.Sleep(1);
                        Application.DoEvents();
                        Frm.Opacity = d;
                        Frm.Refresh();
                    }
                Frm.Opacity = 0;

                Frm.Hide();
                Tem_Bool = false;
            }
            else
            {
                Frm.Opacity = 0;
                Frm.Show();
                if (Frm.Name != "Frm_Screen")
                    for (double d = 0.01; d < 1; d += 0.2)
                    {
                        System.Threading.Thread.Sleep(1);
                        Application.DoEvents();
                        Frm.Opacity = d;
                        Frm.Refresh();
                    }
                Frm.Opacity = 1;
                Tem_Bool = true;
            }
            if (Frm.Name == "Frm_ListBox")
                Example_ListShow = Tem_Bool;
            if (Frm.Name == "Frm_Libretto")
                Example_LibrettoShow = Tem_Bool;
            if (Frm.Name == "Frm_Screen")
                Example_ScreenShow = Tem_Bool;
        }
        #endregion

        #region  ���б���и�ʽ��
        /// <summary>
        ///  ���б���и�ʽ��
        /// </summary>
        /// <param LV="ListView">ListView�ؼ�</param>
        public void Format_ListV(ListView LV)
        {
            LV.Items.Clear();//���������ļ���
            LV.Columns.Clear();//��������еļ���
            LV.View = View.Details;//��ʾ������

            LV.HeaderStyle= ColumnHeaderStyle.None;//�����б���
            LV.ForeColor = Color.White;
            LV.FullRowSelect = true;//�ڵ���ĳ��ʱ���������ѡ��
            LV.Columns.Add("", 18, HorizontalAlignment.Left);//����ͷ��
            LV.Columns.Add("������", LV.Width - 80, HorizontalAlignment.Left);//����ͷ��
            LV.Columns.Add("ʱ��", 57, HorizontalAlignment.Right);//����ͷ��
            LV.Columns.Add("", 0, HorizontalAlignment.Right);
        }

        /// <summary>
        ///  ���б��ʽ���и�ʽ��
        /// </summary>
        /// <param LV="ListView">ListView�ؼ�</param>
        public void Format_ListN(ListView LV)
        {
            LV.Items.Clear();//���������ļ���
            LV.Columns.Clear();//��������еļ���
            LV.View = View.Details;//��ʾ������

            LV.HeaderStyle = ColumnHeaderStyle.None;//�����б���
            LV.ForeColor = Color.White;
            LV.FullRowSelect = true;//�ڵ���ĳ��ʱ���������ѡ��
            LV.Columns.Add("", LV.Width-2, HorizontalAlignment.Left);//��ʾ����
            LV.Columns.Add("", 0, HorizontalAlignment.Right);//·��
        }

        /// <summary>
        ///  �����б���б���Ĵ�С
        /// </summary>
        /// <param LV="ListView">ListView�ؼ�</param>
        public void Format_ListSize(ListView LV)
        {
            LV.Columns[0].Width = 18;
            LV.Columns[1].Width = LV.Width - 80;
            LV.Columns[2].Width = 57;
            LV.Columns[3].Width = 0;
        }
        #endregion

        #region  ���б�����Ӹ�����Ϣ
        /// <summary>
        /// ���б�����Ӹ�����Ϣ
        /// </summary>
        /// <param LV="ListView">ListView�ؼ�</param>
        /// <param DS="DataSet">���ز��ҵ����ݼ�</param>
        public void Data_List(ListView LV, string Local_Name, string Local_Time, string Local_Path)  //Form��MouseEventArgs��������ռ�using System.Windows.Forms;
        {
            int Tem_Count = 0;
            if (LV.Items.Count == 0)
                Tem_Count = 1;
            else
                Tem_Count = LV.Items.Count + 1;
            ListViewItem item = new ListViewItem(Tem_Count.ToString());
            item.SubItems.Add(Local_Name);
            item.SubItems.Add(Local_Time);
            item.SubItems.Add(Local_Path);
            LV.Items.Add(item);
            LV.Items[LV.Items.Count - 1].BackColor = Color.DarkSeaGreen;
            if (Example_AddFileSign == 1)
            {
                Local_Time = BuildSec(Local_Time);
                m3uWrite(Local_Name, Local_Time, Local_Path, Example_ListNameDir);
                Example_AddFileSign = 0;
            }
        }

        /// <summary>
        /// ���б�������б�����
        /// </summary>
        /// <param LV="ListView">ListView�ؼ�</param>
        /// <param DS="DataSet">���ز��ҵ����ݼ�</param>
        public void Data_List(ListView LV, string Local_Name, string Local_Path)  //Form��MouseEventArgs��������ռ�using System.Windows.Forms;
        {
            ListViewItem item = new ListViewItem(Local_Name);
            item.SubItems.Add(Local_Path);
            LV.Items.Add(item);
            LV.Items[LV.Items.Count - 1].BackColor = Color.DarkSeaGreen;
            //LV.Items[0].BackColor = Color.DarkGreen;
        }

        /// <summary>
        /// ��m3u�ļ�����Ϣ��ӵ��б���
        /// </summary>
        /// <param LV="ListView">ListView�ؼ�</param>
        /// <param Local_Name="string[]">���ز��ҵ����ݼ�</param>
        public void ListAddFile(ListView LV, ListView LVFile, ArrayList Array_LName)  //Form��MouseEventArgs��������ռ�using System.Windows.Forms;
        {
            int i=0;
            string Tem_name = "";//�ļ�����
            string Tem_Time = "";//����ʱ��
            string Tem_dir = "";//����·��
            string Tem_info = "";//��ʱ��¼
            string[] Array_Name = new string[Array_LName.Count];
            foreach (string str in Array_LName)					//����ArrayList�����е�Ԫ�ز����
            {
                Array_Name[i] = str;
                i = i + 1;
            }
            i=0;

            while (true)
            {
                if (Array_Name[i] == "#EXTM3U")
                {
                    i = i + 1;
                    continue;
                }
                if (i > Array_Name.Length - 1)
                    break;
                if (Array_Name.Length < 2)
                    break;
                if (Array_Name[i].Substring(0, 7) == "#EXTINF")
                {
                    Tem_info = Array_Name[i];
                    Tem_Time = Tem_info.Substring(Tem_info.IndexOf(':') + 1, Tem_info.LastIndexOf(',') - Tem_info.IndexOf(':') - 1);
                    if (Tem_Time.IndexOf(',') > 0)
                        Tem_Time = Convert.ToString(InterceptFig(Tem_Time));
                    if (Tem_Time.Trim().Length > 0)
                        Tem_Time = GetFileTimeSec(Convert.ToInt32(Tem_Time));
                    Tem_name = Tem_info.Substring(Tem_info.LastIndexOf(',') + 1, Tem_info.Length - Tem_info.LastIndexOf(',') - 1);
                    Tem_dir = Array_Name[i + 1];
                    Data_List(LVFile, Tem_name, Tem_Time, Tem_dir);
                    i = i + 2;
                }
                if (i > Array_Name.Length - 2)
                    break;
            }

        }

        #endregion

        #region  ��ȡ�����ļ���������Ϣ
        /// <summary>
        /// ��ȡ�����ļ��ĵ�����Ϣ
        /// </summary>
        /// <param strF1="string">�ļ�·��</param>
        /// <param iIndex="int">��Ϣ������</param>
        public string GetFileInfo(string strF1, int iIndex)
        {
            //Ӧ��Scripting,�ڡ�������á��Ի�����ѡ��"COM"ѡ���Ȼ��ѡ��Microsoft Scripting Runtime��������ȷ������ť
            Scripting.FileSystemObject fso = new Scripting.FileSystemObject();
            Scripting.File fl;
            string pth = "";
            string flname = "";

            //Ӧ��Shell32,�ڡ�������á��Ի�����ѡ��"COM"ѡ���Ȼ��ѡ��Microsoft Shell Controls And Automation��������ȷ������ť
            Shell32.Shell shl = new Shell32.Shell();
            Shell32.Folder shfd;
            string s = "";

            fl = fso.GetFile(strF1);
            pth = fl.ParentFolder.Path;
            flname = fl.Name;

            shfd = shl.NameSpace(pth);

            if (shfd.GetDetailsOf(0, iIndex) != "" || shfd.GetDetailsOf(shfd.Items().Item(flname), iIndex) != "")
                if (shfd.GetDetailsOf(shfd.Items().Item(flname), iIndex) != "")
                    s = shfd.GetDetailsOf(shfd.Items().Item(flname), iIndex);
                    //s = shfd.GetDetailsOf(0, iIndex) + "�� " + shfd.GetDetailsOf(shfd.Items().Item(flname), iIndex);
                else
                    s = "";
                return s;
        }

        /// <summary>
        /// ��ȡ�����ļ��Ļ�����Ϣ
        /// </summary>
        /// <param strF1="string">�ļ�·��</param>
        public ArrayList GetFileDouble(string strF1)
        {
            ArrayList List = new ArrayList();
            int[] tem_ArrInt ={ 0, 10, 16, 17, 33, 22, 21, 1 };
            string[] tem_AStr ={ "", "", "", "", "", "", "", "" };
            string[] tem_ArrStr ={ "", "����: ", "������: ", "ר��: ", "��ʽ: ", "����: " };
            string mp = "";
            for (int i = 0; i < tem_ArrInt.Length; i++)
            {
                tem_AStr[i] = GetFileInfo(strF1.Trim(), tem_ArrInt[i]);
            }

            if (tem_AStr[0] != "")
                mp = tem_AStr[0].Substring(tem_AStr[0].Length - 3, 3);
            if (tem_AStr[1] != "" && tem_AStr[2] != "")
                List.Add(tem_AStr[2] + "-" + tem_AStr[1]);
            else
                List.Add(tem_AStr[0]);
            if (tem_AStr[1] != "")
                List.Add(tem_ArrStr[1] + tem_AStr[1]);
            if (tem_AStr[2] != "")
                List.Add(tem_ArrStr[2] + tem_AStr[2]);
            if (tem_AStr[3] != "")
                List.Add(tem_ArrStr[3] + tem_AStr[3]);
            if (tem_AStr[4] != "" || tem_AStr[5] != "")
                List.Add(tem_ArrStr[4] + mp + " " + tem_ArrStr[4] + tem_AStr[5]);
            List.Add(tem_ArrStr[5] + GetFileTime(LongTime(strF1)));
            if (tem_AStr[7] != "")
            {
                float Tem_Size = InterceptFig(tem_AStr[7]);
                if (Tem_Size != 0)
                {
                    Example_File_Size = FormatMB(Tem_Size);
                }
            }
            return List;
        }
        #endregion

        #region  ���ַ����н�ȡ����
        /// <summary>
        /// ���ַ����н�ȡ����
        /// </summary>
        /// <param Istr="string">�������ֵ��ַ���</param>
        public int InterceptFig(string Istr)
        {
            string Tem_Sint = "";
            int Tem_Value=0;
            CharEnumerator Tem_CharEnum = Istr.GetEnumerator();
            while (Tem_CharEnum.MoveNext())
            {
                byte[] Tem_byte = new byte[1];
                Tem_byte = System.Text.Encoding.ASCII.GetBytes(Tem_CharEnum.Current.ToString());
                int Tem_ASCII_Code = (short)(Tem_byte[0]);
                if (Tem_ASCII_Code >= 48 && Tem_ASCII_Code <= 57)
                    Tem_Sint += Tem_CharEnum.Current.ToString();
            }
            if (Tem_Sint != "")
                Tem_Value = Convert.ToInt32(Tem_Sint.Trim());
            return Tem_Value;
        }
        #endregion

        #region  ��KBת����MB
        /// <summary>
        /// ��KBת����MB
        /// </summary>
        /// <param Istr="string">�������ֵ��ַ���</param>
        public string FormatMB(float Mb)
        {
            string Tem_MB = "";
            Mb = Mb / 1024;
            if (Mb > 1)
            {
                Tem_MB = Mb.ToString();
                Tem_MB = Tem_MB.Substring(0, Tem_MB.IndexOf(",") + 1) + "MB";
            }
            else
                Tem_MB = Mb.ToString() + "KB";

            return Tem_MB;
        }
        #endregion

        #region  ��ȡ�ļ��Ĳ���ʱ�䣬�����б��н�����ʾ
        /// <summary>
        /// ��ȡ�ļ��Ĳ���ʱ�䣬�����б��н�����ʾ
        /// </summary>
        /// <param Millisecond="int">������</param>
        //���using System.Runtime.InteropServices;API�����������ռ�
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern int GetShortPathName(string lpszLongPath, string shortFile, int cchBuffer);

        [DllImport("winmm.dll", EntryPoint = "mciSendString", CharSet = CharSet.Auto)]
        public static extern int mciSendString(string lpstrCommand, string lpstrReturnString, int uReturnLength, int hwndCallback);

        public int LongTime(string Spath)
        {
            string Pname = "";
            string TemStr = "";
            int ilong = 0;
            string tem_str = "";
            int t = 0;
            TemStr = TemStr.PadLeft(128, Convert.ToChar(" "));
            ilong = GetShortPathName(Spath, TemStr, TemStr.Length);
            Pname = "open " + Convert.ToChar(34) + Spath + Convert.ToChar(34) + " alias media";
            t = mciSendString(Pname, TemStr, TemStr.Length, 0);
            t = mciSendString("status " + Spath + " length", TemStr, 128, 0);
            tem_str = TemStr.Substring(0, TemStr.IndexOf("\0"));
            if (tem_str.Trim() == "")
                t = 0;
            else
                t = Convert.ToInt32(tem_str);
            return t;
        }
        #endregion

        #region  ��ȡ�ļ��Ĳ���ʱ�䣬����ָ����ʽ������ʾ
        /// <summary>
        /// ��ȡ�ļ��Ĳ���ʱ�䣬����ָ����ʽ������ʾ
        /// </summary>
        /// <param Millisecond="int">������</param>
        public string GetFileTime(int Millisecond)
        {
            string Tem_Time = "";
            //double Tem_hour = 0;
            double Tem_min = 0;
            double Tem_sec = 0;
            double Tem_millisec = 0;

            Tem_min = Millisecond / 1000;
            Tem_min = Tem_min / 60.0;

            Tem_sec = Tem_min - (int)Tem_min;
            Tem_min = (int)Tem_min;
            Tem_sec = (60 * Tem_sec) / 100.0;
            Tem_sec = (int)(Tem_sec * 100);
            Tem_millisec = (int)((Millisecond - Tem_min * 60 * 1000 - Tem_sec * 1000) / 1000 * 100);
            //string Tem_Digit="";
            if (Tem_min >= 100)
            {
                Tem_Time = Tem_min.ToString("000") + ":" + Tem_sec.ToString("00");
            }
            else
                Tem_Time = Tem_min.ToString("00") + ":" + Tem_sec.ToString("00");
            return Tem_Time;
        }

        /// <summary>
        /// ��ȡ�ļ��Ĳ���ʱ�䣬����ָ����ʽ������ʾ
        /// </summary>
        /// <param Millisecond="int">����</param>
        public string GetFileTimeSec(int Millisecond)
        {
            string Tem_Time = "";
            //double Tem_hour = 0;
            double Tem_min = 0;
            double Tem_sec = 0;

            Tem_min = Millisecond / 60.0;

            Tem_sec = Tem_min - (int)Tem_min;
            Tem_min = (int)Tem_min;
            Tem_sec = (60 * Tem_sec) / 100.0;
            Tem_sec = (int)(Tem_sec * 100);
            if (Tem_min >= 100)
            {
                Tem_Time = Tem_min.ToString("000") + ":" + Tem_sec.ToString("00");
            }
            else
                Tem_Time = Tem_min.ToString("00") + ":" + Tem_sec.ToString("00");
            return Tem_Time;
        }
        #endregion

        #region  ��ȡMP3�ĸ��
        /// <summary>
        /// ��ȡMP3�ĸ��
        /// </summary>
        /// <param FileName="string">���·��</param>
        public string[]  LRC_Lyric(string FileName)
        {
            ArrayList ArrLyric = new ArrayList();
            FileStream fs = new FileStream(@FileName, FileMode.Open, FileAccess.Read, FileShare.None);
            StreamReader sr = new StreamReader(fs, System.Text.Encoding.Default);
            sr.BaseStream.Seek(0, SeekOrigin.Begin);
            string Tem_strLine = sr.ReadLine();
            string Tem_Str = "";
            string sp = "";
            int Tem_p = 0;//��¼��ǰ[��λ��
            int Tem_q = 0;//��¼��ǰ]��λ��
            string Tem_Time = "";//ʱ��
            string Tem_Slyrec = "";//���
            bool Tem_bool = true;//ѭ������

            while (Tem_strLine != null)
            {
                Tem_bool = true;
                Tem_Str = Tem_strLine;
                sp = Tem_strLine;
                if (sp.IndexOf(Convert.ToChar("[")) == -1 || sp.Trim() == "")
                {
                    Tem_strLine = sr.ReadLine();
                    continue;
                }

                sp = sp.Substring(sp.IndexOf(Convert.ToChar("[")) + 1, 1);
                Tem_Slyrec = Tem_Str.Substring(Tem_Str.LastIndexOf(Convert.ToChar("]")) + 1, Tem_Str.Length - (Tem_Str.LastIndexOf(Convert.ToChar("]")) + 1));
                if (EstimateFig(sp))
                {
                    while (Tem_bool)
                    {
                        Tem_p = Tem_Str.IndexOf(Convert.ToChar("["));
                        Tem_q = Tem_Str.IndexOf(Convert.ToChar("]"));
                        Tem_Time = Tem_Str.Substring(Tem_p + 1, Tem_q - Tem_p - 1);
                        ArrLyric.Add(Tem_Time + "|" + Tem_Slyrec);
                        if (Tem_q != Tem_Str.LastIndexOf(Convert.ToChar("]")))
                            Tem_Str = Tem_Str.Substring(Tem_q + 1, Tem_Str.Length - Tem_q - 1);
                        else
                            Tem_bool = false;
                    }
                }
                Tem_strLine = sr.ReadLine();
            }
            sr.Dispose();
            fs.Dispose();

            int Tem_DatetimeUp;//��¼ǰһ��ʱ��
            int Tem_DstetimeDown;//��¼��һ��ʱ��
            string Tem_taxisTime = "";//�ǵ���ȡ���ʱ���ַ���
            string Tem_Transitorily = "";//����ʱ��ʱ�洢���ַ���
            string[] ArrayStr = new string[ArrLyric.Count];
            for (int i = 0; i < ArrayStr.Length; i++)
            {
                Tem_Str = ArrLyric[i].ToString();
                Tem_taxisTime = Tem_Str.Substring(0, Tem_Str.LastIndexOf(Convert.ToChar("|")));
                Tem_taxisTime = BuildMillisecond(Tem_taxisTime);
                ArrayStr[i] = Tem_taxisTime + "|" + Tem_Str.Substring(Tem_Str.LastIndexOf(Convert.ToChar("|")) + 1, Tem_Str.Length - Tem_Str.LastIndexOf(Convert.ToChar("|")) - 1);
            }
            string iStr = "";
            string jStr = "";
            for (int i = 0; i < ArrayStr.Length - 2; i++)
            {
                for (int j = 0; j < ArrayStr.Length - 1 - i; j++)
                {
                    iStr = ArrayStr[j];
                    jStr = ArrayStr[j + 1];
                    Tem_taxisTime = iStr.Substring(0, iStr.LastIndexOf(Convert.ToChar("|")));
                    Tem_DatetimeUp = Convert.ToInt32(Tem_taxisTime);
                    Tem_taxisTime = jStr.Substring(0, jStr.LastIndexOf(Convert.ToChar("|")));
                    Tem_DstetimeDown = Convert.ToInt32(Tem_taxisTime);
                    if (Tem_DstetimeDown < Tem_DatetimeUp)
                    {
                        Tem_Transitorily = ArrayStr[j];
                        ArrayStr[j] = ArrayStr[j + 1];
                        ArrayStr[j + 1] = Tem_Transitorily;
                    }
                }
            }
            return ArrayStr;
        }
        #endregion

        #region  ���ַ����н�ȡ����
        /// <summary>
        /// ���ַ����н�ȡ����
        /// </summary>
        /// <param Istr="string">�������ֵ��ַ���</param>
        public bool EstimateFig(string Istr)
        {
            string Tem_Sint = "";
            bool Tem_Bool = false;
            CharEnumerator Tem_CharEnum = Istr.GetEnumerator();
            while (Tem_CharEnum.MoveNext())
            {
                byte[] Tem_byte = new byte[1];
                Tem_byte = System.Text.Encoding.ASCII.GetBytes(Tem_CharEnum.Current.ToString());
                int Tem_ASCII_Code = (short)(Tem_byte[0]);
                if (Tem_ASCII_Code >= 48 && Tem_ASCII_Code <= 57)
                    Tem_Sint += Tem_CharEnum.Current.ToString();
            }
            if (Tem_Sint != "")
                Tem_Bool = true;
            return Tem_Bool;
        }
        #endregion

        #region  ����ʱ��ĺ�����
        /// <summary>
        /// ����ʱ��ĺ�����
        /// </summary>
        /// <param Istr="string">ʱ��</param>
        public string BuildMillisecond(string Istr)
        {
            string Tem_Value = "";
            int Tem_Cent = 0;
            int Tem_Sec = 0;
            int Tem_Mill = 0;
            Tem_Cent = Convert.ToInt32(Istr.Substring(0, Istr.IndexOf(Convert.ToChar(":"))));
            Tem_Sec = Convert.ToInt32(Istr.Substring(Istr.IndexOf(Convert.ToChar(":")) + 1, Istr.IndexOf(Convert.ToChar(".")) - Istr.IndexOf(Convert.ToChar(":")) - 1));
            Tem_Mill = Convert.ToInt32(Istr.Substring(Istr.IndexOf(Convert.ToChar(".")) + 1, Istr.Length - Istr.IndexOf(Convert.ToChar(".")) - 1));
            Tem_Cent = Tem_Cent * 60000 + Tem_Sec * 1000 + Tem_Mill;
            Tem_Value = Tem_Cent.ToString();
            return Tem_Value;
        }
        #endregion

        #region  ����ʱ�������
        /// <summary>
        /// ����ʱ��ĺ�����
        /// </summary>
        /// <param Istr="string">ʱ��</param>
        public string BuildSec(string Istr)
        {
            string Tem_Value = "";
            if (Istr == "")
                return Tem_Value;
            int Tem_Cent = 0;
            int Tem_Sec = 0;
            Tem_Cent = Convert.ToInt32(Istr.Substring(0, Istr.IndexOf(Convert.ToChar(":"))));
            Tem_Sec = Convert.ToInt32(Istr.Substring(Istr.IndexOf(Convert.ToChar(":")) + 1, Istr.Length - Istr.IndexOf(Convert.ToChar(":")) - 1));
            Tem_Cent = Tem_Cent * 60 + Tem_Sec;
            Tem_Value = Tem_Cent.ToString();
            return Tem_Value;
        }
        #endregion

        #region  �������
        /// <summary>
        /// �������
        /// </summary>
        /// <param Arr_List="ArrayList">������</param>
        public void ArrayList_Close( ArrayList Arr_List)
        {
            if (Arr_List.Count > 0)
            {
                for (int i = 0; i < Arr_List.Count; i++)
                    Arr_List.RemoveAt(0);
            }
        }
        #endregion

        #region  ������һ��Ŀ¼
        /// <summary>
        /// ������һ��Ŀ¼
        /// </summary>
        /// <param dir="string">Ŀ¼</param>
        /// <returns>����String����</returns>
        public string UpAndDown_Dir(string dir)
        {
            string Change_dir = "";
            if (dir.Length > 4)
                Change_dir = Directory.GetParent(dir).FullName;
            else
                Change_dir = dir;
            return Change_dir;
        }
        #endregion

        #region  ��ȡͼƬ·��
        /// <summary>
        /// ��ȡͼƬ·��
        /// </summary>
        public void ImageDir()
        {
            string Tem_Imadir = "";
            Tem_Imadir = UpAndDown_Dir(System.AppDomain.CurrentDomain.BaseDirectory);
            Tem_Imadir = UpAndDown_Dir(Tem_Imadir);
            Tem_Imadir = UpAndDown_Dir(Tem_Imadir);
            ImgDir = Tem_Imadir;
        }
        #endregion

        #region  �ı䰴ť�Ķ�̬ͼƬ
        /// <summary>
        /// �ı䰴ť�Ķ�̬ͼƬ
        /// </summary>
        /// <param PicBox="PictureBox">PictureBox�ؼ�</param>
        /// <param n="Int16">�л���ʽ�ı�ʶ</param>
        /// <param Bn="Boolean">�ж��л���ͼƬ��TrueΪ��ͼƬ��FalseΪԭʼͼƬ</param>
        public void ButtonChange(PictureBox PicBox,Int16 n,Boolean Bn)
        {
            if (n > 0 && n <= 12)
                PicBox.Image = null;
            switch (n)
            {
                case 1://��������С����ť
                    {
                        if (Bn)
                            PicBox.Image = (Image)Properties.Resources.��С����ť��ɫ;
                        else
                            PicBox.Image = (Image)Properties.Resources.��С����ť;
                        break;
                    }
                case 2://������رհ�ť
                    {
                        if (Bn)
                            PicBox.Image = (Image)Properties.Resources.�رհ�ť��ɫ;
                        else
                            PicBox.Image = (Image)Properties.Resources.�رհ�ť;
                        break;
                    }
                case 3://���ļ���ť
                    {
                        if (Bn)
                            PicBox.Image = (Image)Properties.Resources.���ļ��б��;
                        else
                            PicBox.Image = (Image)Properties.Resources.���ļ��б�;
                        break;
                    }
                case 4://��ʾ�ļ��б��尴ť
                    {
                        if (Bn)
                            PicBox.Image = (Image)Properties.Resources.PL��;
                        else
                            PicBox.Image = (Image)Properties.Resources.PL;
                        break;
                    }
                case 5://��ʾ��ʴ��尴ť
                    {
                        if (Bn)
                            PicBox.Image = (Image)Properties.Resources.LRC��;
                        else
                            PicBox.Image = (Image)Properties.Resources.LRC;
                        break;
                    }
                case 6://��ʾ��Ƶ���尴ť
                    {
                        if (Bn)
                            PicBox.Image = (Image)Properties.Resources.WF��;
                        else
                            PicBox.Image = (Image)Properties.Resources.WF;
                        break;
                    }
                case 7://������һ���ļ���ť
                    {
                        if (Bn)
                            PicBox.Image = (Image)Properties.Resources.ǰ����ť��;
                        else
                            PicBox.Image = (Image)Properties.Resources.ǰ����ť;
                        break;
                    }
                case 8://�ļ����Ű�ť
                    {
                        if (Bn)
                            PicBox.Image = (Image)Properties.Resources.���Ű�ť��;
                        else
                            PicBox.Image = (Image)Properties.Resources.���Ű�ť;
                        break;
                    }
                case 9://�ļ�ֹͣ��ť
                    {
                        if (Bn)
                            PicBox.Image = (Image)Properties.Resources.ֹͣ��ť��;
                        else
                            PicBox.Image = (Image)Properties.Resources.ֹͣ��ť;
                        break;
                    }
                case 10://������һ���ļ���ť
                    {
                        if (Bn)
                            PicBox.Image = (Image)Properties.Resources.���˰�ť��;
                        else
                            PicBox.Image = (Image)Properties.Resources.���˰�ť;
                        break;
                    }
                case 11:
                    {
                        if (Bn)
                            PicBox.Image = (Image)Properties.Resources.�����б�رհ�ť��;
                        else
                            PicBox.Image = (Image)Properties.Resources.�����б�Ĺرհ�ťԭ;
                        break;
                    }
                case 12:
                    {
                        if (Bn)
                            PicBox.Image = (Image)Properties.Resources.��ͣ��ť��;
                        else
                            PicBox.Image = (Image)Properties.Resources.��ͣ��ť;
                        break;
                    }
            }
        }
        #endregion


        #region  ����m3u�ļ�
        /// <summary>
        /// ����m3u�ļ�
        /// </summary>
        /// <param FileDir="string">Ŀ¼</param>
        public void m3uCreate(string FileDir)
        {
            FileStream fs;
            Byte[] info;
            if (File.Exists(FileDir)) //����ļ�����,���˳�����
            {
                MessageBox.Show("�ļ��Ѵ��ڣ������������ļ�����");
                return;
            }
            else    //����ļ�������,�򴴽�File.CreateText����
            {
                fs = File.Create(FileDir);
            }
            info = new UTF8Encoding(true).GetBytes("#EXTM3U");
            fs.Write(info, 0, info.Length);
            fs.Close();
            fs.Dispose();
        }
        #endregion

        #region  д��m3u�ļ�
        /// <summary>
        /// д��m3u�ļ�
        /// </summary>
        /// <param FileDir="string">Ŀ¼</param>
        public void m3uWrite(string FName, string FTime, string FDir, string FileDir)
        {
            if (!File.Exists(FileDir))
            {
                MessageBox.Show("�ļ������ڡ�");
                return;
            }
            StreamWriter ASW = new StreamWriter(FileDir,true,Encoding.Default);
            ASW.WriteLine();
            ASW.Write("#EXTINF:" + FTime + "," + FName);
            ASW.WriteLine();
            ASW.Write(FDir, Encoding.Default);
            ASW.Flush();
            ASW.Close();
            ASW.Dispose();
        }
        #endregion

        #region  ɾ��m3u�ļ�
        /// <summary>
        /// ɾ��m3u�ļ�
        /// </summary>
        /// <param FileDir="string">Ŀ¼</param>
        public void m3uDelete(string FileDir)
        {
            if (!File.Exists(FileDir))
            {
                MessageBox.Show("�ļ������ڡ�");
                return;
            }
            File.Delete(FileDir);

        }
        #endregion

        public static ArrayList AList = new ArrayList();
        #region  ��ȡm3u�ļ�
        /// <summary>
        /// ��ȡm3u�ļ�
        /// </summary>
        /// <param FileDir="string">Ŀ¼</param>
        public void m3uRead(string FileDir)
        {
            if (!File.Exists(FileDir))
            {
                MessageBox.Show("�ļ������ڡ�");
                return;
            }
            AList.Clear();
            string S;
            StreamReader SR =new StreamReader(FileDir,Encoding.Default);
            S = SR.ReadLine();
            AList.Add(S);
            while (S != null)
            {
                S = SR.ReadLine();
                if (S == null)
                    break;
                AList.Add(S);
            }
            SR.Close();
            SR.Dispose();
        }
        #endregion

        #region  �б����ز���
        /// <summary>
        /// �б����ز���
        /// </summary>
        /// <param LV="ListView">ListView�ؼ�</param>
        /// <param n="int">��ʶ</param>
        public void List_ADDName(ListView LV,int n)
        {
            string tem_n="";
            switch (n)
            {
                case 1://�½��б�
                    {

                        int tem_i = 0;
                        for (int i = 0; i < LV.Items.Count; i++)
                        {
                            tem_n = LV.Items[i].SubItems[0].Text;
                            if (tem_n.IndexOf("�½�") > -1)
                            {
                                if (tem_n.Length == 3)
                                {
                                    if (tem_i <= Convert.ToInt16(tem_n.Substring(2, 1)))
                                        tem_i = Convert.ToInt16(tem_n.Substring(2, 1));
                                }
                            }
                        }
                        tem_i = tem_i + 1;
                        Data_List(LV, "�½�" + tem_i.ToString(), UpAndDown_Dir(System.AppDomain.CurrentDomain.BaseDirectory) + "\\�½�" + tem_i.ToString() + ".m3u");
                        m3uCreate(UpAndDown_Dir(System.AppDomain.CurrentDomain.BaseDirectory) + "\\�½�" + tem_i.ToString() + ".m3u");
                        break;
                    }
                case 2://����б�
                    {
                        string tem_newName = "";
                        OpenFileDialog FileD = new OpenFileDialog();
                        if (FileD.ShowDialog() == DialogResult.OK)
                        {
                            tem_n = FileD.FileName;
                            tem_newName = Folder_Handle(tem_n, "", "", n);
                            if (tem_newName.IndexOf('\\') >= 0)
                                Data_List(LV, File_Name(tem_newName, false), tem_newName);
                        }
                        break;
                    }
                case 3://���б�
                    {
                        string tem_newName = "";
                        OpenFileDialog FileD = new OpenFileDialog();
                        FileD.Filter = "M3U�ļ�(*.M3U)|*.m3u";
                        if (FileD.ShowDialog() == DialogResult.OK)
                        {
                            tem_n = FileD.FileName;
                            tem_newName = Folder_Handle(tem_n, "", "", 2);
                            if (tem_newName.IndexOf('\\') >= 0)
                                Data_List(LV, File_Name(tem_newName, false), tem_newName);

                            int tem_n2 = 0;
                            if ((LV.Items.Count - 1) > FrmClass.Example_ListNameNark)
                            {
                                tem_n2 = LV.Items.Count - 1;
                                Format_ListN(((Frm_ListBox)FrmClass.F_List).listView_List);
                                Format_ListV(((Frm_ListBox)FrmClass.F_List).listView_List);

                                LV.Items[Example_ListNameNark].Selected = true;
                                LV.SelectedItems[0].BackColor = Color.DarkSeaGreen;
                                LV.Items[Example_ListNameNark].Selected = false;

                                Example_ListNameNark = tem_n2;
                                LV.Items[Example_ListNameNark].Selected = true;
                                LV.Items[Example_ListNameNark].Focused = true;

                                LV.SelectedItems[0].BackColor = Color.DarkGreen;

                                Example_ListNameDir = LV.Items[Example_ListNameNark].SubItems[1].Text;
                                m3uRead(LV.Items[FrmClass.Example_ListNameNark].SubItems[1].Text);
                                if (FrmClass.AList.Count > 1)
                                {
                                    ListAddFile(LV, ((Frm_ListBox)FrmClass.F_List).listView_List, AList);
                                }
                                Example_ListMark = -1;
                            }

                        }
                        FileD.Dispose();
                        break;
                    }
                case 4://���Ϊ
                    {
                        //Example_ListFClick
                        FolderBrowserDialog FileD = new FolderBrowserDialog();
                        if (FileD.ShowDialog() == DialogResult.OK)
                        {
                            tem_n = FileD.SelectedPath;
                            Folder_Handle(tem_n, LV.Items[Example_ListNameNark].SubItems[1].Text, "", n);
                        }
                        FileD.Dispose();
                        break;
                    }
                case 5://ɾ��
                    {
                        if (Example_ListFClick < 0)
                        {
                            MessageBox.Show("��ѡ��Ҫɾ�����б��ļ���");
                            break;
                        }
                        if (LV.Items[Example_ListFClick].SubItems[0].Text == "Ĭ��")
                        {
                            //MessageBox.Show("��������Ĭ���ļ��б���ɾ����");
                            break;
                            return;
                        }
                        if (Folder_Handle(LV.Items[Example_ListFClick].SubItems[1].Text, "", "", n) != "")
                        {
                            LV.Items[Example_ListNameNark].Selected = false;
                            LV.Items[Example_ListNameNark].Focused = false;

                            Format_ListN(((Frm_ListBox)FrmClass.F_List).listView_List);
                            Format_ListV(((Frm_ListBox)FrmClass.F_List).listView_List);

                            if (Example_ListFClick <= Example_ListNameNark)
                            {
                                int LVCount = (((Frm_ListBox)FrmClass.F_List).listView_List.Items.Count - 1);
                                LV.Items[Example_ListFClick].Remove();
                                LVCount = LVCount - 1;
                                if (Example_ListFClick < Example_ListNameNark)
                                {
                                    Example_ListNameNark = Example_ListNameNark - 1;
                                }
                                else if (Example_ListFClick == Example_ListNameNark)
                                {

                                    if ((LV.Items.Count-1) <= Example_ListFClick)
                                        Example_ListNameNark = 0;
                                }
                                LV.Items[Example_ListNameNark].Selected = true;
                                LV.Items[Example_ListNameNark].Focused = true;

                                LV.SelectedItems[0].BackColor = Color.DarkGreen;

                                Example_ListNameDir = LV.Items[Example_ListNameNark].SubItems[1].Text;
                                m3uRead(LV.Items[FrmClass.Example_ListNameNark].SubItems[1].Text);
                                if (FrmClass.AList.Count > 1)
                                {
                                    ListAddFile(LV, ((Frm_ListBox)FrmClass.F_List).listView_List, AList);
                                }
                            }
                            else
                            {
                                if (Example_ListFClick > Example_ListNameNark)
                                {
                                    LV.Items[Example_ListFClick].Remove();
                                    LV.Items[Example_ListNameNark].Selected = true;
                                    LV.Items[Example_ListNameNark].Focused = true;
                                }
                            }
                            Example_ListFClick = Example_ListNameNark;
                            
                        }
                        break;
                    }
            }
        }
        #endregion

        #region  �ļ���
        /// <summary>
        /// �ļ���
        /// </summary>
        /// <param dir="string">Ŀ¼</param>
        /// <param n="bool">�ж��Ƿ����չ��</param>
        public string File_Name(string dir, bool n)
        {
            if (dir.IndexOf('\\') < 0)
                return "";
            string Tem_FName = dir;
            Tem_FName = Tem_FName.Substring(Tem_FName.LastIndexOf('\\') + 1, Tem_FName.Length - Tem_FName.LastIndexOf('\\') - 1);
            if (!n)
                Tem_FName = Tem_FName.Substring(0, Tem_FName.LastIndexOf('.'));
            return Tem_FName;

        }
        #endregion

        #region  �ļ��Ĳ���
        /// <summary>
        /// �ļ��Ĳ���
        /// </summary>
        /// <param dir="string">Ŀ��Ŀ¼</param>
        /// <param Sdir="string">ԭĿ¼</param>
        /// <param NewName="string">�޸ĵ��ļ�����</param>
        /// <param n="int">��ʶ</param>
        /// <returns>����string����</returns>
        public string Folder_Handle(string dir, string Sdir, string NewName, int n)
        {

            string F_Name = "";//����һ���ַ������������ڼ�¼��ǰ���������ļ��У������ļ�
            string t = "";//����һ�����ͱ���
            if (dir.IndexOf('\\') < 0)
                return t;
            if (UpAndDown_Dir(System.AppDomain.CurrentDomain.BaseDirectory) == UpAndDown_Dir(dir) && n < 4)
            {
                MessageBox.Show("������ͬһ��Ŀ¼�½��в�����");
                return t;
            }

            switch (n)
            {
                case 2://����б��ļ�
                    {
                        try
                        {
                            FileInfo FInfo = new FileInfo(dir);//�����ļ���·����ʵ����һ��FileInfo��
                            string tem_AddFile = UpAndDown_Dir(System.AppDomain.CurrentDomain.BaseDirectory) + "\\" + File_Name(dir, true);
                            if (File.Exists(tem_AddFile))
                            {
                                string tem_add = File_Name(dir, false);
                                bool tem_have = true;
                                while (tem_have)
                                {
                                    tem_add = tem_add + "(1)";
                                    F_Name = UpAndDown_Dir(System.AppDomain.CurrentDomain.BaseDirectory) + "\\" + tem_add + ".m3u";
                                    if (!File.Exists(F_Name))
                                    {
                                        tem_have=false;
                                    }
                                }
                            }
                            else
                            {
                                F_Name = UpAndDown_Dir(System.AppDomain.CurrentDomain.BaseDirectory) + "\\" + File_Name(dir, true);
                            }
                            FInfo.CopyTo(F_Name, true);
                            t = F_Name;
                        }
                        catch (Exception ex)
                        {
                            t = "";//��ʶ������tΪ�ձ�ʾ����ʧ��
                            MessageBox.Show("�ļ����ʧ�ܡ�");
                            break;
                        }
                        break;
                    }
                case 4:
                    {
                        try
                        {
                            FileInfo FInfo = new FileInfo(Sdir);//�����ļ���·����ʵ����һ��FileInfo��
                            string tem_AddFile = dir + "\\" + File_Name(Sdir, true);
                            if (File.Exists(tem_AddFile))
                            {
                                string tem_add = File_Name(tem_AddFile, false);
                                bool tem_have = true;
                                while (tem_have)
                                {
                                    tem_add = tem_add + "(1)";
                                    F_Name = UpAndDown_Dir(tem_AddFile) + "\\" + tem_add + ".m3u";
                                    if (!File.Exists(F_Name))
                                    {
                                        tem_have = false;
                                    }
                                }
                            }
                            else
                            {
                                F_Name = dir + "\\" + File_Name(Sdir, true);
                            }
                            FInfo.CopyTo(F_Name, true);
                            t = F_Name;
                        }
                        catch (Exception ex)
                        {
                            t = "";//��ʶ������tΪ�ձ�ʾ����ʧ��
                            MessageBox.Show("�ļ�����ʧ�ܡ�");
                            break;
                        }
                        break;
                    }
                case 5:
                    {
                        try
                        {
                            FileInfo FInfo = new FileInfo(dir);//�����ļ���·����ʵ����һ��FileInfo��
                            FInfo.Delete();
                            t = dir;
                            break;
                        }
                        catch (Exception ex)
                        {
                            t = "";//��ʶ������tΪ�ձ�ʾ����ʧ��
                            MessageBox.Show("�ļ�ɾ��ʧ�ܡ�");
                            break;
                        }
                        break;
                    }
                case 6:
                    {
                        try
                        {
                            FileInfo FInfo = new FileInfo(dir);//�����ļ���·����ʵ����һ��FileInfo��
                            F_Name = UpAndDown_Dir(dir) + "//" + NewName + ".m3u";
                            FInfo.MoveTo(F_Name);
                            t = F_Name;
                            break;
                        }
                        catch (Exception ex)
                        {
                            t = "";//��ʶ������tΪ�ձ�ʾ����ʧ��
                            MessageBox.Show("�ļ�ɾ��ʧ�ܡ�");
                            break;
                        }
                        break;
                    }

            }
            return t;
        }
        #endregion








    }
}

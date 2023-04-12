using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using System.Reflection.Emit;
using static System.Net.Mime.MediaTypeNames;
using EasyModbus;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

using Emgu;
using Emgu.CV;
using Emgu.CV.Util;
using Emgu.CV.OCR;
using Emgu.CV.Structure;
using Emgu.Util;
using Emgu.CV.CvEnum;


namespace TCP_LISTENER_Delta
{

    public partial class Form_Listener : Form
    {
        ModbusClient modbus = new ModbusClient();
        System.Timers.Timer aTimer = new System.Timers.Timer();
        System.Timers.Timer bTimer = new System.Timers.Timer();

        // Set up the controls and events to be used and update the device list.

        public delegate void InvokeDelegate();

        private Thread n_server;
        private Thread n_shot;
        private TcpListener listener;
        string out1 = "0";
        string out2 = "0";
        string position = "";


        int step = 30;
        int ReadModbus;
        int motorSpeed;
        int numshots;
        int txt1;
        int txt2;
        int txt3;
        int txt4;
        int txt5;
        int txt6;
        int txt7;
        int i;
        Int64 result;
        private int imageIndex;
        private string[] imageList;
        private bool[] M;
        private Int32[] D = new Int32[7];
        bool[] Abool = new bool[14];
        private string[] files;
        private bool M1 = false;
        private bool M2 = false;
        private bool M3 = false;
        private bool M4 = false;
        private bool M5 = false;
        private bool M6 = false;
        private bool M7 = false;
        private bool M8 = false;
        private bool M9 = false;
        private bool M10 = false;
        private bool M11 = false;
        private bool M12 = false;
        private bool F = false;
        private bool R = false;
        string sub = "";
        double IntPosition;
        double PosDiff;
        double Pos_Prev;

        

        public Form_Listener()
        {
            InitializeComponent();
            imageIndex = 0;
            aTimer.Elapsed += ReadMDBS;
            aTimer.Interval = 50;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
            bTimer.Elapsed += WriteMDBS;
            bTimer.Interval = 50;
            bTimer.AutoReset = true;
            bTimer.Enabled = true;
            btnStart.MouseEnter += OnMouseEnterButton1;
            btnStart.MouseLeave += OnMouseLeaveButton1;

        }
        private void OnMouseEnterButton1(object sender, EventArgs e)
        {
            btnStart.BackColor = System.Drawing.Color.FromArgb(218,67,60); // or Color.Red or whatever you want
        }
        private void OnMouseLeaveButton1(object sender, EventArgs e)
        {
            btnStart.BackColor = System.Drawing.Color.FromArgb(115, 115, 115);
        }



        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            step = Step_TrackBar.Value;
            labelStepValue.Text = Convert.ToString(Step_TrackBar.Value);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            modbus.Disconnect();
            lblStat.Text = "Status: Disconnected";
        }

        private void Message()
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            modbus.IPAddress = Convert.ToString(txtIPAdress.Text);
            modbus.Port = Convert.ToInt32(txtPort.Text);
            if (modbus.Connected == false)
            { 
            try
            {
                modbus.Connect();
            }
                catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            if (modbus.Connected == true)
                lblStat.Text = "Status: Connected";
                this.btnStart.Image = global::TCP_LISTENER_Delta.Properties.Resources.Group_10;
            }
            else if (modbus.Connected == true)
            {
                try
                {
                    modbus.Disconnect();
                    if (modbus.Connected == false)
                    lblStat.Text = "Status: Disconnected";
                    this.btnStart.Image = global::TCP_LISTENER_Delta.Properties.Resources.Group_9;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }

        }

        private void button_Motor_Stop_Click(object sender, EventArgs e)
        {
            motorSpeed = 0;
        }

        private void buttonMotorStart_Click(object sender, EventArgs e)
        {
            motorSpeed = MotorSpeedSliderControl.Value;
        }

        private void MotorSpeedSliderControl_Scroll(object sender, EventArgs e)
        {
            motorSpeed = MotorSpeedSliderControl.Value;
        }


        private void txt1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog newOpenFile = new OpenFileDialog();
            if (newOpenFile.ShowDialog(this) == DialogResult.OK)
            {
                pictureBox1.Load(newOpenFile.FileName);
                label2.Text = "Name: " + pictureBox1.ImageLocation.Substring(pictureBox1.ImageLocation.LastIndexOf("\\") + 1);
                sub = pictureBox1.ImageLocation.Substring(0, pictureBox1.ImageLocation.LastIndexOf("\\") + 1);
                label3.Text = "Path: " + sub;
                imageList = Directory.GetFiles(sub);
            }
        }
        private void closeDialog(object sender, EventArgs e)
        {
            
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            sub = "";
            label2.Text = "Name: ";
            label3.Text = "Path: ";
            richTextBox1.Text = "";
            pictureBox1.ImageLocation = "";
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (sub != "")
            {
                files = Directory.GetFiles(sub);
                if (i < files.Length - 1)
                {
                    i++;
                    pictureBox1.Load(files[i]);
                    label2.Text = "Name: " + pictureBox1.ImageLocation.Substring(pictureBox1.ImageLocation.LastIndexOf("\\") + 1);
                    sub = pictureBox1.ImageLocation.Substring(0, pictureBox1.ImageLocation.LastIndexOf("\\") + 1);
                    label3.Text = "Path: " + sub;
                    imageList = Directory.GetFiles(sub);
                }
                else if (i == files.Length - 1)
                {
                    i = 0;
                    pictureBox1.Load(files[i]);
                    label2.Text = "Name: " + pictureBox1.ImageLocation.Substring(pictureBox1.ImageLocation.LastIndexOf("\\") + 1);
                    sub = pictureBox1.ImageLocation.Substring(0, pictureBox1.ImageLocation.LastIndexOf("\\") + 1);
                    label3.Text = "Path: " + sub;
                    imageList = Directory.GetFiles(sub);
                }
            }

            //imageIndex--;
            //if (imageIndex < 0)
            //    imageIndex = imageList.Length - 1;
            //
            //pictureBox1.Image = System.Drawing.Image.FromFile(imageList[imageIndex]);

        }
        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (sub != "")
            {
                files = Directory.GetFiles(sub);
                if (i == 0)
                {
                    i = files.Length - 1;
                    pictureBox1.Load(files[i]);
                    label2.Text = "Name: " + pictureBox1.ImageLocation.Substring(pictureBox1.ImageLocation.LastIndexOf("\\") + 1);
                    sub = pictureBox1.ImageLocation.Substring(0, pictureBox1.ImageLocation.LastIndexOf("\\") + 1);
                    label3.Text = "Path: " + sub;
                    imageList = Directory.GetFiles(sub);
                }
                else if (i > 0)
                {
                    i--;
                    pictureBox1.Load(files[i]);
                    label2.Text = "Name: " + pictureBox1.ImageLocation.Substring(pictureBox1.ImageLocation.LastIndexOf("\\") + 1);
                    sub = pictureBox1.ImageLocation.Substring(0, pictureBox1.ImageLocation.LastIndexOf("\\") + 1);
                    label3.Text = "Path: " + sub;
                    imageList = Directory.GetFiles(sub);
                }
            }
        }

   

        public static byte[] Combine(byte[] first, byte[] second)
        {
            return first.Concat(second).ToArray();
        }

        void ReadMDBS(object sender, EventArgs e)
        {
            if (modbus.Connected == true)
             {
            try
            {
           //         if(btnUP_Click = 1)
            //Abool[0] = true;

            //Abool[1] = checkBox1.Checked;
           // Abool[2] = checkBox2.Checked;
            //Abool[3] = checkBox3.Checked;
           // Abool[4] = checkBox4.Checked;
            //Abool[5] = checkBox5.Checked;
           // Abool[6] = checkBox6.Checked;
            //Abool[7] = checkBox7.Checked;
           // Abool[8] = checkBox8.Checked;
            //Abool[9] = checkBox9.Checked;
            //Abool[10] = checkBox10.Checked;
            //Abool[11] = checkBox11.Checked;
           // Abool[12] = checkBox12.Checked;
            //Abool[13] = checkBox13.Checked;

                
                modbus.WriteSingleRegister(53, txt1);
                modbus.WriteSingleRegister(52, Convert.ToInt32(motorSpeed));
                modbus.WriteSingleRegister(54, txt2);
                modbus.WriteSingleRegister(55, txt3);
                modbus.WriteSingleRegister(56, txt4);
                modbus.WriteSingleRegister(57, txt5);
                modbus.WriteSingleRegister(58, txt6);

            

                modbus.WriteMultipleCoils(147, Abool);

            

          
                 D = modbus.ReadHoldingRegisters(52, 7);

                    //Int16 value1 = Convert.ToInt16(D[1]);
                    //Int16 value2 = Convert.ToInt16(D[0]);
                    //result = int Abs (D[0]);
                    if (D[0] < 0)
                        result = (unchecked((uint)D[0]) - 4294901762);
                    if (D[0] >= 0)
                        result = (unchecked((uint)D[0]));
                    //result = (Int64)(Int32)D[0];
                    //(value2 << 16) | value1;





                M = modbus.ReadCoils(147, 14);
                M1 = M[0];
                M2 = M[1];
                M3 = M[2];
                M4 = M[3];
                M5 = M[4];
                M6 = M[5];
                M7 = M[6];
                M8 = M[7];
                M9 = M[8];
                M10 = M[9];
                M11 = M[10];
                M12 = M[11];
                F = M[12];
                R = M[13];

            
            

           if (M1 == true)
            {
                   this.label28.BackColor = System.Drawing.Color.Green;
            }
           else if (M1 == false)
           {
                   this.label28.BackColor = System.Drawing.Color.WhiteSmoke;
           }
            //    if (M2 == true)
            //    {
           //         this.lbl2.BackColor = System.Drawing.Color.Green;
           //     }
           //     else if (M2 == false)
           //     {
           //         this.lbl2.BackColor = System.Drawing.Color.WhiteSmoke;
           //     }
           //     if (M3 == true)
           //     {
           //         this.lbl3.BackColor = System.Drawing.Color.Green;
           //     }
           //     else if (M3 == false)
           //     {
           //         this.lbl3.BackColor = System.Drawing.Color.WhiteSmoke;
           //     }
           //     if (M4 == true)
           //     {
           //         this.lbl4.BackColor = System.Drawing.Color.Green;
            //    }
           //     else if (M4 == false)
           //     {
           //         this.lbl4.BackColor = System.Drawing.Color.WhiteSmoke;
           //     }
           //     if (M5 == true)
           //     {
           //         this.lbl5.BackColor = System.Drawing.Color.Green;
           //     }
           //     else if (M5 == false)
           //     {
           //         this.lbl5.BackColor = System.Drawing.Color.WhiteSmoke;
           //     }
           //     if (M6 == true)
           //     {
           //         this.lbl6.BackColor = System.Drawing.Color.Green;
           //     }
           //     else if (M6 == false)
           //     {
           //         this.lbl6.BackColor = System.Drawing.Color.WhiteSmoke;
           //     }
           //     if (M7 == true)
           //     {
           //         this.lbl7.BackColor = System.Drawing.Color.Green;
           //     }
           //     else if (M7 == false)
           //     {
           //         this.lbl7.BackColor = System.Drawing.Color.WhiteSmoke;
           //     }
           //     if (M8 == true)
           //     {
           //         this.lbl8.BackColor = System.Drawing.Color.Green;
           //     }
           //     else if (M8 == false)
           //     {
           //         this.lbl8.BackColor = System.Drawing.Color.WhiteSmoke;
           //     }
           //     if (M9 == true)
           //     {
           //         this.lbl9.BackColor = System.Drawing.Color.Green;
           //     }
           //     else if (M9 == false)
           //     {
           //         this.lbl9.BackColor = System.Drawing.Color.WhiteSmoke;
           //     }
           //     if (M10 == true)
           //     {
           //         this.lbl10.BackColor = System.Drawing.Color.Green;
           //     }
           //     else if (M10 == false)
           //     {
           //         this.lbl10.BackColor = System.Drawing.Color.WhiteSmoke;
           //     }
           //     if (M11 == true)
           //     {
           //         this.lbl11.BackColor = System.Drawing.Color.Green;
           //     }
           //     else if (M11 == false)
           //     {
           //         this.lbl11.BackColor = System.Drawing.Color.WhiteSmoke;
           //     }
           //     if (M12 == true)
           //     {
           //         this.lbl12.BackColor = System.Drawing.Color.Green;
          //      }
          //     else if (M12 == false)
           //     {
           //         this.lbl12.BackColor = System.Drawing.Color.WhiteSmoke;
           //     }
           //     if (F == true)
           //     {
           //         this.lblFront.BackColor = System.Drawing.Color.Green;
           //     }
           //     else if (F == false)
           //     {
           //         this.lblFront.BackColor = System.Drawing.Color.WhiteSmoke;
           //     }
           //     if (R == true)
           //     {
           //         this.lblRear.BackColor = System.Drawing.Color.Green;
           //     }
            //    else if (R == false)
            //    {
           //         this.lblRear.BackColor = System.Drawing.Color.WhiteSmoke;
           //     }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
                 }
            }
        void WriteMDBS(object sender, EventArgs e)
        {
            if (modbus.Connected == true)
            {
                try
                {
                    if (InvokeRequired)
                    {
                        Invoke(new Action(() =>
                        {
                            textBox1.Text = result.ToString() ;
                            textBox7.Text = D[1].ToString();
                            textBox6.Text = D[2].ToString();
                            textBox5.Text = D[3].ToString();
                            textBox2.Text = D[4].ToString();
                            textBox4.Text = D[5].ToString();
                            textBox3.Text = D[6].ToString();

                        }));
                    }
                    else
                    {
                        textBox1.Text = result.ToString();
                        textBox7.Text = D[1].ToString();
                        textBox6.Text = D[2].ToString();
                        textBox5.Text = D[3].ToString();
                        textBox2.Text = D[4].ToString();
                        textBox4.Text = D[5].ToString();
                        textBox3.Text = D[6].ToString();

                    }

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
        }
        private void textBox45_TextChanged(object sender, EventArgs e)
        {
            if (textBox45.Text == "")
            {
                textBox45.Text = "0";
                txt1 = 0;
            }
            else if (textBox45.Text != "")
            {
                txt1 = Convert.ToInt32(textBox45.Text);
            }
        }
        private void textBox44_TextChanged(object sender, EventArgs e)
        {
            if (textBox44.Text == "")
            {
                textBox44.Text = "0";
                txt2 = 0;
            }
            else if (textBox44.Text != "")
            {
                txt2 = Convert.ToInt32(textBox44.Text);
            }
        }

        private void textBox43_TextChanged(object sender, EventArgs e)
        {
            if (textBox43.Text == "")
            {
                textBox43.Text = "0";
                txt3 = 0;
            }
            else if (textBox43.Text != "")
            {
                txt3 = Convert.ToInt32(textBox43.Text);
            }
        }

        private void textBox42_TextChanged(object sender, EventArgs e)
        {
            if (textBox42.Text == "")
            {
                textBox42.Text = "0";
                txt4 = 0;
            }
            else if (textBox42.Text != "")
            {
                txt4 = Convert.ToInt32(textBox42.Text);
            }
        }

        private void textBox41_TextChanged(object sender, EventArgs e)
        {
            if (textBox41.Text == "")
            {
                textBox41.Text = "0";
                txt5 = 0;
            }
            else if (textBox41.Text != "")
            {
                txt5 = Convert.ToInt32(textBox41.Text);
            }
        }

        private void textBox40_TextChanged(object sender, EventArgs e)
        {
            if (textBox40.Text == "")
            {
                textBox40.Text = "0";
                txt6 = 0;
            }
            else if (textBox40.Text != "")
            {
                txt6 = Convert.ToInt32(textBox40.Text);
            }
        }

        private void txtEvents_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form_Listener_Load(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void labelSpeed_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void btnUP_Click(object sender, EventArgs e)
        {
            if (true)
            Abool[0] = true;
            else if (false)
            Abool[0] = false;
        }

        private void btnRIGHT_Click(object sender, EventArgs e)
        {

        }

        private void btnLEFT_Click(object sender, EventArgs e)
        {

        }

        private void btnDWN_Click(object sender, EventArgs e)
        {

        }

        private void btnTXT_Click(object sender, EventArgs e)
        {
            try 
            {
            Tesseract tesseract = new Tesseract(@"C:\Users\HIAS\Desktop\TCP_LISTENER_Delta\bin\Debug\testdata", "eng", OcrEngineMode.TesseractLstmCombined);
            tesseract.SetImage(new Image<Bgr, byte>(pictureBox1.ImageLocation));
            tesseract.Recognize();
            richTextBox1.Text = tesseract.GetUTF8Text();
            tesseract.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}





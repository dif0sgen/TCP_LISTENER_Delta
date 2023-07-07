using EasyModbus;
using Emgu.CV;
using Emgu.CV.OCR;
using Emgu.CV.Structure;
using System;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.NetworkInformation;

using System.Collections.Generic;
using EOSDigital.API;
using EOSDigital.SDK;
using System.Drawing.Imaging;
using System.Collections.Generic;
using System.Security.Cryptography;
using Emgu.CV.CvEnum;
using System.Drawing;
using Emgu.CV.Util;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Resources.ResXFileRef;
using System.Runtime.InteropServices.ComTypes;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using MySqlX.XDevAPI.Relational;
using Org.BouncyCastle.Utilities;
using System.Collections;

//using MySql.Data.MySqlClient;

namespace TCP_LISTENER_Delta
{
    //class DB
    //{
    //    MySqlConnection connection = new MySqlConnection("server =");
    //
    //}
    public partial class Form_Listener : Form
    {
        #region Variables

        CanonAPI APIHandler;
        Camera MainCamera;
        CameraValue[] AvList;
        CameraValue[] TvList;
        CameraValue[] ISOList;
        List<Camera> CamList;
        bool IsInit = false;
        Bitmap Evf_Bmp;
        int LVBw, LVBh, w, h;
        float LVBratio, LVration;

        int ErrCount;
        object ErrLock = new object();
        object LvLock = new object();

        #endregion

        ModbusClient modbus = new ModbusClient();
        System.Timers.Timer aTimer = new System.Timers.Timer();
        System.Timers.Timer bTimer = new System.Timers.Timer();

        // Set up the controls and events to be used and update the device list.

        public delegate void InvokeDelegate();
        private Thread thread1;
        private Thread thread2;
        private Thread thread3;
        private Thread n_server;
        private Thread n_shot;
        private TcpListener listener;
        string out1 = "0";
        string out2 = "0";
        string position = "";

        static string picture_path;
        static string filename;

        private Stopwatch stopWatch = new Stopwatch();



        public int ACC_X_MAN;
        string step;
        int step2;
        int step3;
        int ReadModbus;
        int motorSpeed;
        int motorSpeedX;
        int motorSpeedY;
        int numshots;
        int txt1;
        int txt2;
        int txt3;
        int txt4;
        int txt5;
        int txt6;
        int txt7;
        int txt8;
        int txt9;
        int txt10;
        int txt11;
        int Scan_TMR;
        int Grab_TMR;
        int Release_TMR;
        int i;
        int milliseconds = 300;
        Int32 posXtab1;
        Int32 posXtab2;
        Int32 posYtab1;
        Int32 posYtab2;
        Int32 Hi;
        private int imageIndex;
        private string[] imageList;
        private bool[] M = new bool[6];
        private Int32[] D = new Int32[56];
        private Int32[] SPDX = new Int32[56];
        private Int32[] SPDY = new Int32[1];
        private Int32[] ACCX = new Int32[1];
        private Int32[] ACCY = new Int32[1];
        bool[] Abool = new bool[18];
        private bool[] CONTROL = new bool[11];
        private bool[] Mcontrol = new bool[11];
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
        private bool BTNCon;
        private bool UP;
        private bool DOWN;
        private bool LEFT;
        private bool RIGHT;
        private bool START;
        private bool STOP;
        private bool HOME;
        private bool Solenoid;
        private bool UpLim;
        private bool DownLim;
        private bool RightLim;
        private bool LeftLim;
        private bool PapLim;
        private bool PresLim;
        private bool check1 = false;
        private bool check2 = false;

        string sub = "";
        string tesser;
        double IntPosition;
        double PosDiff;
        double Pos_Prev;

        Bitmap bitmap;
        Image<Hsv, byte> img;
        Image<Bgr, byte> imge;
        Image<Bgr, byte> imgInput;


        private bool read = false;
        Hsv imgLower;
        Hsv imgHigher;
        int Hmin;
        int Hmax;
        int Vmim;
        int Vmax;
        int Smin;
        int Smax;
        int Sizemin;
        int Sizemax;
        int Armin;
        int Armax;
        int size;

        public Camera camera = new Camera();

        int a;
        int b;
        int c;
        int d;
        int ina;
        string cama;

        DataSet ds;
        SqlDataAdapter adapter;
        SqlCommandBuilder commandBuilder;


        SqlConnection sqlConn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\HOPE.mdf;Integrated Security=True;Connect Timeout=30");
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\HOPE.mdf;Integrated Security=True;";
        string sql = "SELECT * FROM HOPETable";
        int irow;
        SqlCommand cmd;
        /// 
        /// Init Form
        /// 
        public Form_Listener()
        {
            InitializeComponent();

            thread1 = new Thread(() => ReadMDBS("MDBS"));
            thread2 = new Thread(() => WriteMDBS("WRITE"));
            //thread3 = new Thread(() => btnOpen_Click("IMAGE"));
            thread1.Start();
            thread2.Start();

            try
            {
                InitializeComponent();
                APIHandler = new CanonAPI();
                APIHandler.CameraAdded += APIHandler_CameraAdded;
                ErrorHandler.SevereErrorHappened += ErrorHandler_SevereErrorHappened;
                ErrorHandler.NonSevereErrorHappened += ErrorHandler_NonSevereErrorHappened;
                SavePathTextBox.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), "RemotePhoto");
                SaveFolderBrowser.Description = "Save Images To...";
                LiveViewPicBox.Paint += LiveViewPicBox_Paint;
                LVBw = LiveViewPicBox.Width;
                LVBh = LiveViewPicBox.Height;
                RefreshCamera();
                IsInit = true;
            }
            catch (DllNotFoundException) { ReportError("Canon DLLs not found!", true); }
            catch (Exception ex) { ReportError(ex.Message, true); }

            imageIndex = 0;
            //aTimer.Elapsed += ReadMDBS; //CYCLE VOID
            //aTimer.Interval = 50;
            //aTimer.AutoReset = true;
            //aTimer.Enabled = true;
            //bTimer.Elapsed += WriteMDBS;//CYCLE VOID
            //bTimer.Interval = 50;
            //bTimer.AutoReset = true;
            //bTimer.Enabled = true;
            this.Closing += new CancelEventHandler(this.Form_Listener_Closing);
            btnUP.MouseUp += btnUP_Up;
            btnUP.MouseDown += btnUP_Down;
            btnUP.MouseEnter += btnUp_ENTER;
            btnDWN.MouseDown += btnDWN_Down;
            btnDWN.MouseUp += btnDWN_Up;
            btnDWN.MouseEnter += btnDWN_ENTER;
            btnStart.MouseEnter += OnMouseEnterButton1;
            btnStart.MouseLeave += OnMouseLeaveButton1;
            button5.MouseDown += SOL_Down;
            button5.MouseUp += SOL_Up;
            button5.MouseEnter += SOL_ENTER;

            ///
            /// GET SAVED VALUES
            ///
            textBox45.Text = Properties.Settings.Default.ACC_X_MAN;
            textBox44.Text = Properties.Settings.Default.DEC_X_MAN;
            txtPort.Text = Properties.Settings.Default.Port;
            txtIPAdress.Text = Properties.Settings.Default.IP;
            textBox16.Text = Properties.Settings.Default.SpeedY1;
            textBox17.Text = Properties.Settings.Default.SpeedY2;
            textBox24.Text = Properties.Settings.Default.POS1;
            textBox23.Text = Properties.Settings.Default.POS2;
            textBox22.Text = Properties.Settings.Default.POS3;
            textBox27.Text = Properties.Settings.Default.GrabTMR;
            textBox26.Text = Properties.Settings.Default.ScanTMR;
            textBox28.Text = Properties.Settings.Default.ReleaseTMR;
            textBox5.Text = Properties.Settings.Default.tesPath;
            textBox2.Text = Properties.Settings.Default.Height;
         

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                adapter = new SqlDataAdapter(sql, connection);

                ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                // делаем недоступным столбец id для изменения
                //dataGridView1.Columns["Id"].ReadOnly = true;
            }

            textBox12.Text = "Row count: 0";
            // Disable all buttons.
            //EnableButtons(false, false);

            /// 
            /// Camera emulator
            /// 

            // Register for the events of the image provider needed for proper operation.
            //camera.ConnectionLost += OnConnectionLost;
            //camera.CameraOpened += OnCameraOpened;
            //camera.CameraClosed += OnCameraClosed;
            //camera.StreamGrabber.GrabStarted += OnGrabStarted;
            //camera.StreamGrabber.ImageGrabbed += OnImageGrabbed;
            // camera.StreamGrabber.GrabStopped += OnGrabStopped;
            //camera.Open();
            //camera.Parameters[PLCamera.PixelFormat].SetValue(PLCamera.PixelFormat.);
            // ** Custom Test Images **
            // Disable standard test images
            //camera.Parameters[PLCamera.TestImageSelector].SetValue(PLCamera.TestImageSelector.Off);
            // Enable custom test images
            //camera.Parameters[PLCamera.ImageFileMode].SetValue(PLCamera.ImageFileMode.On);
            // Load custom test image from disk
            //camera.Parameters[PLCamera.ImageFilename].SetValue("D:\\Serhii\\Cherry_Samples");
            // ** Force Failed Buffer **
            // Set the number of failed buffers to generate to 40
            //camera.Parameters[PLCamera.ForceFailedBufferCount].SetValue(40);
            // Generate 40 failed buffers
            //camera.Parameters[PLCamera.ForceFailedBuffer].Execute();
            // Determine the current sensor shutter mode
            //string shutterMode = camera.Parameters[PLCamera.SensorShutterMode].GetValue();
            // Set the sensor shutter mode to Rolling
            //camera.Parameters[PLCamera.SensorShutterMode].SetValue(PLCamera.SensorShutterMode.Rolling);

        }
        //private void tableBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        //{
        //   this.Validate();
        //   this.tableBindingSource.EndEdit();
        //   this.tableAdapterManager.UpdateAll(this.database1DataSet);
        //
        //  }

        // private void Form1_Load(object sender, EventArgs e)
        // {
        // TODO: This line of code loads data into the 'database1DataSet.Table' table. You can move, or remove it, as needed.
        //     this.tableTableAdapter.Fill(this.database1DataSet.Table);

        // }

        // кнопка добавления
        private void Add_Click(object sender, EventArgs e)
        {
            DataRow row = ds.Tables[0].NewRow(); // добавляем новую строку в DataTable
            ds.Tables[0].Rows.Add(row);
            ina++;
            row["Id"] = ina;
            row["UserID"] = DBNull.Value;
            row["Camera"] = DBNull.Value;
            row["Time"] = DBNull.Value;

        }
        // кнопка удаления
        private void Del_Click(object sender, EventArgs e)
        {
            sqlConn.Open();
            // удаляем выделенные строки из dataGridView1
            foreach (DataGridViewRow rowa in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.Remove(rowa);
            }
            DataRow row = ds.Tables[0].NewRow();
            string sql = "INSERT INTO HOPETable (Id, Camera,Time) VALUES(@Id, @Camera,@Time)";
            row["Id"] = null;
            row["UserID"] = null;
            row["Camera"] = null;
            row["Time"] = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //connection.Open();
                adapter = new SqlDataAdapter(sql, connection);
                commandBuilder = new SqlCommandBuilder(adapter);
                adapter.InsertCommand = new SqlCommand("sp_HOPE", connection);
                adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@UserID", SqlDbType.Int, 0, "UserID"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@Camera", SqlDbType.Text, 0, "Camera"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@Time", SqlDbType.Text, 0, "Time"));

                SqlParameter parameter = adapter.InsertCommand.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");
                parameter.Direction = ParameterDirection.Output;

                adapter.Update(ds);
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM HOPETable", sqlConn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    textBox14.Text = "Row count: " + reader[0].ToString();
                }
            }

            MessageBox.Show("Data Inserted Successfully.");
            sqlConn.Close();
        }
        private void Save_Click(object sender, EventArgs e)
        {
            sqlConn.Open();

            DataRow row = ds.Tables[0].NewRow();
            string sql = "INSERT INTO HOPETable (Id, Camera,Time) VALUES(@Id, @Camera,@Time)";
            row["Id"] = null;
            row["UserID"] = null;
            row["Camera"] = null;
            row["Time"] = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //connection.Open();
                adapter = new SqlDataAdapter(sql, connection);
                commandBuilder = new SqlCommandBuilder(adapter);
                adapter.InsertCommand = new SqlCommand("sp_HOPE", connection);
                adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@UserID", SqlDbType.Int, 0, "UserID"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@Camera", SqlDbType.Text, 0, "Camera"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@Time", SqlDbType.Text, 0, "Time"));

                SqlParameter parameter = adapter.InsertCommand.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");
                parameter.Direction = ParameterDirection.Output;

                adapter.Update(ds);
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM HOPETable", sqlConn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    textBox14.Text = "Row count: " + reader[0].ToString();
                }
            }

            MessageBox.Show("Data Inserted Successfully.");
            sqlConn.Close();
        }
        private void btn_save_Click()
        {
            DateTime currentDateTime = DateTime.Now;
            sqlConn.Open();
            DataRow row = ds.Tables[0].NewRow(); // добавляем новую строку в DataTable
            ds.Tables[0].Rows.Add(row);
            string Id = Convert.ToString(ina);
            ina++;
            string Camera = "Cameraaaaa";
            string Time = currentDateTime.ToString("dd.MM.yyyy HH:mm:ss:fff");
            string sql = "INSERT INTO HOPETable (Id, Camera,Time) VALUES(@Id, @Camera,@Time)";
            row["Id"] = ina;
            row["UserID"] = ina;
            row["Camera"] = "Kris";
            row["Time"] = Time;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //connection.Open();
                adapter = new SqlDataAdapter(sql, connection);
                commandBuilder = new SqlCommandBuilder(adapter);
                adapter.InsertCommand = new SqlCommand("sp_HOPE", connection);
                adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@UserID", SqlDbType.Int, 0, "UserID"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@Camera", SqlDbType.Text, 0, "Camera"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@Time", SqlDbType.Text, 0, "Time"));

                SqlParameter parameter = adapter.InsertCommand.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");
                parameter.Direction = ParameterDirection.Output;

                adapter.Update(ds);
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM HOPETable", sqlConn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    textBox14.Text = "Row count: " + reader[0].ToString();
                }
            }

            MessageBox.Show("Data Inserted Successfully.");
            sqlConn.Close();
            //try
            //{
            //    sqlConn.Open();
            //    SqlCommand sqlComm = new SqlCommand("INSERT INTO HOPETable(Id, Camera, Time)   VALUES(@param1,@param2,@param3", sqlConn);
            //    sqlComm.ExecuteNonQuery();
            //    MessageBox.Show("Data Inserted Successfully.");
            //    sqlConn.Close();
            //}
            //catch (Exception ex)
            //{
            //   MessageBox.Show(ex.Message);
            //}


            //using (SqlCommand sqlComm = new SqlCommand("insert into Table values ('" + Id + "','" + cam + "','" + time + "')",sqlConn))//
            //{

            //    if (sqlComm.Connection.State == ConnectionState.Closed)
            //        sqlComm.Connection.Open();
            //
            //
            //   sqlComm.Parameters.AddWithValue("@Id", Id);
            //    sqlComm.Parameters.AddWithValue("@Camera", cam);
            //   sqlComm.Parameters.AddWithValue("@Time", time);
            //   sqlComm.ExecuteNonQuery();
            //    MessageBox.Show("Transition Updatet Sucessfully");
            //}

        }
        private void button8_Click(object sender, EventArgs e)
        {
          try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand("select UserID,Camera,Time from HOPETable WHERE UserID = " + textBox10.Text, sqlConn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    textBox6.Text = reader[0].ToString();
                   textBox7.Text = reader[1].ToString();
                    textBox8.Text = reader[2].ToString();
                }
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {

                
                sqlConn.Open();
                if (comboBox1.Text == "UserID")
                {
                    cmd = new SqlCommand("select UserID,Camera,Time from HOPETable WHERE UserID = " + textBox11.Text, sqlConn);
                }
                if (comboBox1.Text == "Camera")
                {
                    cmd = new SqlCommand("select UserID,Camera,Time from HOPETable WHERE [Camera] = " + "[" + textBox11.Text + "]", sqlConn);
                }
                if (comboBox1.Text == "Time")
                {
                    cmd = new SqlCommand("select UserID,Camera,Time from HOPETable WHERE [Time] = " + "[" +textBox11.Text + "]", sqlConn);
                }
                SqlDataReader reader = cmd.ExecuteReader();

                // Set the column header names.
                dataGridView2.Columns[0].Name = "UserID";
                dataGridView2.Columns[1].Name = "Camera";
                dataGridView2.Columns[2].Name = "Time";


                while (reader.Read())
                {
                    dataGridView2.Rows.Add(reader[0], reader[1], reader[2]);
                }
                textBox12.Text = "Row count: " + Convert.ToString(dataGridView2.RowCount);
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                sqlConn.Close();
            }
        }
        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                
                dataGridView2.RowCount = 0;
                sqlConn.Open();
                if (comboBox1.Text == "UserID")
                { 
                cmd = new SqlCommand("select UserID,Camera,Time from HOPETable WHERE " + comboBox1.Text + " = " + textBox11.Text, sqlConn);
                }
                if (comboBox1.Text == "Camera" | comboBox1.Text == "Time")
                {
                    cmd = new SqlCommand("select UserID,Camera,Time from HOPETable WHERE " + comboBox1.Text + " = " + textBox11.Text, sqlConn);
                }
                SqlDataReader reader = cmd.ExecuteReader();

                // Set the column header names.
                dataGridView2.Columns[0].Name = "UserID";
                dataGridView2.Columns[1].Name = "Camera";
                dataGridView2.Columns[2].Name = "Time";


                while (reader.Read())
                {
                    dataGridView2.Rows.Add(reader[0], reader[1], reader[2]);
                }
                textBox12.Text = "Row count: " + Convert.ToString(dataGridView2.RowCount);
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                sqlConn.Close();
            }
        }
        private void button12_Click(object sender, EventArgs e)
        {
            dataGridView2.RowCount = 0;
            textBox12.Text = "Row count: " + Convert.ToString(dataGridView2.RowCount);
        }
        /// 
        /// Grab on button click
        /// 

        public static Bitmap ByteToImage(byte[] blob)
        {
            MemoryStream mStream = new MemoryStream();
            byte[] pData = blob;
            mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
            Bitmap bm = new Bitmap(mStream, false);
            mStream.Dispose();
            return bm;
        }


        // private void button4_Click(object sender, EventArgs e)
        // {
        //     try
        //     {
        //         byte[] buffer = new byte[12000000];
        //
        //         if (camera.IsOpen)
        //         {
        //             camera.StreamGrabber.Start();
        //             // Grab a number of images.
        //             for (int i = 0; i < 10; ++i)
        //             {
        //
        //
        //                 
        //                 // Wait for an image and then retrieve it. A timeout of 5000 ms is used.
        //                 IGrabResult grabResult = camera.StreamGrabber.RetrieveResult(5000, TimeoutHandling.ThrowException);
        //                 using (grabResult)
        //                 {
        //                     // Image grabbed successfully?
        //                     if (grabResult.GrabSucceeded)
        //                     {
        //                         // Access the image data.
        //
        //                         buffer = grabResult.PixelData as byte[];
        //
        //                         // Display the grabbed image.
        //                       ImageWindow.DisplayImage(0, grabResult);
        //                         //pictureBox4.Image = ImageFromRawBgraArray(buffer, 1920, 1200, PixelFormat.Format32bppArgb);
        //
        //                         // pictureBox4.Image =  ;
        //
        //                         Bitmap bitmap = new Bitmap(grabResult.Width, grabResult.Height, PixelFormat.Format32bppRgb);
        //                         // Lock the bits of the bitmap.
        //                         BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, bitmap.PixelFormat);
        //                         // Place the pointer to the buffer of the bitmap.
        //                         converter.OutputPixelFormat = PixelType.BGRA8packed;
        //                         IntPtr ptrBmp = bmpData.Scan0;
        //                         converter.Convert(ptrBmp, bmpData.Stride * bitmap.Height, grabResult);
        //                         bitmap.UnlockBits(bmpData);
        //
        //                         // Assign a temporary variable to dispose the bitmap after assigning the new bitmap to the display control.
        //                         Bitmap bitmapOld = pictureBox4.Image as Bitmap;
        //                         // Provide the display control with the new bitmap. This action automatically updates the display.
        //                         pictureBox4.Image = bitmap;
        //                         if (bitmapOld != null)
        //                         {
        //                             // Dispose the bitmap.
        //                             bitmapOld.Dispose();
        //                         }
        //
        //                     }
        //                     else
        //                     {
        //                     }
        //                     
        //                 }
        //
        //
        //             }
        //
        //         }
        //
        //     }
        //     catch (Exception ex)
        //     {
        //         MessageBox.Show("One Shot: " + ex.Message);
        //     }
        //
        //     camera.StreamGrabber.Stop();
        //
        //
        // }

        // Occurs when a device with an opened connection is removed.
        private void OnConnectionLost(Object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                // If called from a different thread, we must use the Invoke method to marshal the call to the proper thread.
                BeginInvoke(new EventHandler<EventArgs>(OnConnectionLost), sender, e);
                return;
            }

        }


        // Occurs when the connection to a camera device is opened.
        private void OnCameraOpened(Object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                // If called from a different thread, we must use the Invoke method to marshal the call to the proper thread.
                BeginInvoke(new EventHandler<EventArgs>(OnCameraOpened), sender, e);
                return;
            }


        }


        // Occurs when the connection to a camera device is closed.
        private void OnCameraClosed(Object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                // If called from a different thread, we must use the Invoke method to marshal the call to the proper thread.
                BeginInvoke(new EventHandler<EventArgs>(OnCameraClosed), sender, e);
                return;
            }

        }

        // Occurs when a camera starts grabbing.
        private void OnGrabStarted(Object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                // If called from a different thread, we must use the Invoke method to marshal the call to the proper thread.
                BeginInvoke(new EventHandler<EventArgs>(OnGrabStarted), sender, e);
                return;
            }

            // Reset the stopwatch used to reduce the amount of displayed images. The camera may acquire images faster than the images can be displayed.

            stopWatch.Reset();


        }

   
        public static void SaveImageCapture(System.Drawing.Image image)
        {

            //SaveFileDialog s = new SaveFileDialog();
            //s.FileName = "Image";// Default file name
            //s.DefaultExt = ".Jpg";// Default file extension
            //s.Filter = "Image (.jpg)|*.jpg"; // Filter files by extension
            //


            // Show save file dialog box
            // Process save file dialog box results

            string hh = DateTime.Now.Hour.ToString();
            string mm = DateTime.Now.Minute.ToString();
            string ss = DateTime.Now.Second.ToString();

            // Save Image
            //string filename = "C:\\Users\\Processing1\\Desktop\\HIAS\\Pics\\" + hh +"-" + mm + "-" + ss  + ".jpg";

            filename = picture_path + hh + "-" + mm + "-" + ss + ".jpg";
            FileStream fstream = new FileStream(filename, FileMode.Create);
            image.Save(fstream, System.Drawing.Imaging.ImageFormat.Jpeg);
            fstream.Close();



        }



        

        /// 
        /// array to bitmap
        /// 
        public System.Drawing.Image ImageFromRawBgraArray(byte[] arr, int width, int height, PixelFormat pixelFormat)
        {
            var output = new Bitmap(width, height, pixelFormat);
            var rect = new Rectangle(0, 0, width, height);
            var bmpData = output.LockBits(rect, ImageLockMode.ReadWrite, output.PixelFormat);

            // Row-by-row copy
            var arrRowLength = width * System.Drawing.Image.GetPixelFormatSize(output.PixelFormat) / 8;
            var ptr = bmpData.Scan0;
            for (var i = 0; i < height; i++)
            {
                Marshal.Copy(arr, i * arrRowLength, ptr, arrRowLength);
                ptr += bmpData.Stride;
            }

            output.UnlockBits(bmpData);
            return output;
        }


        /// 
        /// STOP
        /// 
        private void button2_Click(object sender, EventArgs e)
        {
            if (modbus.Connected == true)
            {
                CONTROL[5] = false;
                CONTROL[6] = true;
            }
            else if (modbus.Connected == false)
            {
                MessageBox.Show("PLC disabled");
            }
        }
        /// 
        /// START
        /// 
        private void button1_Click(object sender, EventArgs e)
        {
            if (modbus.Connected == true)
            {
                if (txt9 == txt10 || txt10 == txt11 || txt11 == txt9)
                {
                    MessageBox.Show("Incorrect position value. Coordinates have the same values");
                }
                else if (txt9 != txt10 & txt10 != txt11 & txt11 != txt9)
                {
                    if (motorSpeed > 0 & D[40] > 0 & D[42] > 0 & D[44] > 0 & D[46] > 0)
                    {
                        CONTROL[5] = true;
                    }
                    else if (motorSpeed == 0 || D[40] == 0 || D[42] == 0 || D[44] == 0 || D[46] == 0)
                    {
                        CONTROL[5] = false;
                        MessageBox.Show("Speed is 0, set higher value");
                    }
                }
            }
            else if (modbus.Connected == false)
            {
                MessageBox.Show("PLC disabled");
            }
        }
        /// 
        /// HOME
        ///
        private void button3_Click_1(object sender, EventArgs e)
        {
            if (modbus.Connected == true)
            {
                if (motorSpeed > 0 & D[40] > 0 & D[42] > 0 & D[44] > 0 & D[46] > 0)
                {
                    CONTROL[7] = true;
                }
                else if (motorSpeed == 0 || D[40] == 0 || D[42] == 0 || D[44] == 0 || D[46] == 0)
                {
                    CONTROL[7] = false;
                    MessageBox.Show("Speed is 0, set higher value");
                }
            }
            else if (modbus.Connected == false)
            {
                MessageBox.Show("PLC disabled");
            }
        }
        /// 
        /// Set color on mouse BTN_Connect
        /// 
        private void OnMouseEnterButton1(object sender, EventArgs e)
        {
            btnStart.BackColor = System.Drawing.Color.FromArgb(218, 67, 60); // or Color.Red or whatever you want
        }
        private void OnMouseLeaveButton1(object sender, EventArgs e)
        {
            btnStart.BackColor = System.Drawing.Color.FromArgb(115, 115, 115);
        }


        /// 
        /// Speed track bar
        /// 
        private void MotorSpeedSliderControl_Scroll(object sender, EventArgs e)
        {
            motorSpeed = MotorSpeedSliderControl.Value;
            Properties.Settings.Default.SpeedPERC = MotorSpeedSliderControl.Value;
            Properties.Settings.Default.Save();
        }
        /// 
        /// Speed track bar
        /// 
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            motorSpeedY = trackBar2.Value;
            Properties.Settings.Default.SPEED_Y_MAN = trackBar2.Value;
            Properties.Settings.Default.Save();
        }
        /// 
        /// Connect to PLC
        /// 
        private void btnStart_Click(object sender, EventArgs e)
        {
            modbus.IPAddress = Convert.ToString(txtIPAdress.Text);
            modbus.Port = Convert.ToInt32(txtPort.Text);
            if (modbus.Connected == false)
            {
                try
                {
                    modbus.Connect();
                    check1 = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Connect Modbus" + ex.Message);
                }
                if (modbus.Connected == true)
                    lblStat.Text = "Status: Connected";
                this.btnStart.Image = global::TCP_LISTENER_Delta.Properties.Resources.Group_10;
                //this.lblStat.ForeColor = System.Drawing.Color.Green;
            }
            else if (modbus.Connected == true)
            {
                try
                {

                    check1 = false;
                    this.btnStart.Image = global::TCP_LISTENER_Delta.Properties.Resources.Group_9;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Disconnect Modbus: " + ex.Message);

                }
            }
        }
        /// 
        /// Open file dialog
        /// 
        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog newOpenFile = new OpenFileDialog();
            newOpenFile.Filter = ".jpg, .jpeg, .bmp, .gif, .png|*.jpg;*.jpeg;*bmp;*gif;*.png";
            if (newOpenFile.ShowDialog(this) == DialogResult.OK)
            {
                pictureBox1.Load(newOpenFile.FileName);
                label2.Text = "Name: " + pictureBox1.ImageLocation.Substring(pictureBox1.ImageLocation.LastIndexOf("\\") + 1);
                sub = pictureBox1.ImageLocation.Substring(0, pictureBox1.ImageLocation.LastIndexOf("\\") + 1);
                label3.Text = "Path: " + sub;
                imageList = Directory.GetFiles(sub);
            }
        }
        /// 
        /// CLOSE FILE + RESET ALL STRINGS
        /// 
        private void btnClose_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            sub = "";
            label2.Text = "Name: ";
            label3.Text = "Path: ";
            richTextBox1.Text = "";
            pictureBox1.ImageLocation = "";
        }
        /// 
        /// Next file
        /// 
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (sub != "")
            {
                try
                {
                    files = Directory.GetFiles(sub);
                    if (i < files.Length - 1)
                    {
                        i++;
                        pictureBox1.Load(files[i]);
                        label2.Text = "Name: " + pictureBox1.ImageLocation.Substring(pictureBox1.ImageLocation.LastIndexOf("\\") + 1);
                        sub = pictureBox1.ImageLocation.Substring(0, pictureBox1.ImageLocation.LastIndexOf("\\") + 1);
                        label3.Text = "Path: " + sub;
                    }
                    else if (i == files.Length - 1)
                    {
                        i = 0;
                        pictureBox1.Load(files[i]);
                        label2.Text = "Name: " + pictureBox1.ImageLocation.Substring(pictureBox1.ImageLocation.LastIndexOf("\\") + 1);
                        sub = pictureBox1.ImageLocation.Substring(0, pictureBox1.ImageLocation.LastIndexOf("\\") + 1);
                        label3.Text = "Path: " + sub;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Next picture: " + ex.Message);
                }

            }
            /// 
            /// Previous file
            /// 
        }
        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (sub != "")
            {
                try
                {
                    files = Directory.GetFiles(sub); // GET ARRAY OF FILES
                    if (i == 0)
                    {
                        i = files.Length - 1;
                        pictureBox1.Load(files[i]); // LOAD FILE #I FROM ARRAY
                        label2.Text = "Name: " + pictureBox1.ImageLocation.Substring(pictureBox1.ImageLocation.LastIndexOf("\\") + 1); //NAME
                        sub = pictureBox1.ImageLocation.Substring(0, pictureBox1.ImageLocation.LastIndexOf("\\") + 1); //PATH
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
                catch (Exception ex)
                {
                    MessageBox.Show("Prev picture: " + ex.Message);
                }
            }
        }

        /// 
        /// Read/Write Modbus cycle
        /// 
        void ReadMDBS(string name)
        {
            while (true)
            {
                if (modbus.Connected == true)
                {
                    try
                    {

                        SPDX[2] = Convert.ToInt32(motorSpeedX); //Write Manual Speed X
                        SPDX[10] = Convert.ToInt32(motorSpeedY);//Write Manual Speed Y
                        SPDX[30] = Convert.ToInt32(motorSpeed); //Write Main Speed Percent
                        SPDX[4] = txt1; //ACC X
                        SPDX[12] = txt3; //ACC Y
                        SPDX[28] = txt2; //ACC X
                        SPDX[26] = txt4; //ACC Y
                        SPDX[32] = txt5; //SPD X1
                        SPDX[34] = txt6; //SPD X2
                        SPDX[36] = txt7; //SPD Y1
                        SPDX[38] = txt8; //SPD Y2
                        SPDX[48] = txt9; //POSITION 1
                        SPDX[50] = txt10; //POSITION 2
                        SPDX[52] = txt11; //POSITION 3
                        SPDX[16] = Grab_TMR; //Grab_TMR
                        SPDX[18] = Scan_TMR; //Scan_TMR
                        SPDX[20] = Release_TMR; //Release_TMR
                        SPDX[54] = Hi;

                        //modbus.WriteMultipleCoils(147, Abool);
                        try
                        {
                            modbus.WriteMultipleCoils(11, CONTROL); // WRITE ALL BITS
                        }

                        catch (Exception ex)
                        {
                            MessageBox.Show("Write mulriple coils: " + ex.Message);
                        }
                        //Thread.Sleep(milliseconds);

                        try
                        {
                            modbus.WriteMultipleRegisters(0, SPDX); ;  // WRITE ALL WORDS
                        }

                        catch (Exception ex)
                        {
                            MessageBox.Show("Write mulriple registers: " + ex.Message);
                        }
                        CONTROL[7] = false;// RESET "HOME" AFTER WRITING
                        CONTROL[6] = false;// RESET "STOP" AFTER WRITING
                        if (check1 == true)
                        {
                            try
                            {
                                D = modbus.ReadHoldingRegisters(0, 56); //READ ALL WORDS
                                posXtab1 = EasyModbus.ModbusClient.ConvertRegistersToInt(modbus.ReadHoldingRegisters(24, 2));
                                posYtab1 = EasyModbus.ModbusClient.ConvertRegistersToInt(modbus.ReadHoldingRegisters(22, 2));
                            }

                            catch (Exception ex)
                            {
                                MessageBox.Show("Read words MDBS: " + ex.Message);
                            }

                            //Thread.Sleep(milliseconds);
                            try
                            {
                                Mcontrol = modbus.ReadCoils(11, 11);
                                M = modbus.ReadCoils(22, 6);
                            }

                            catch (Exception ex)
                            {
                                MessageBox.Show("Read bits MDBS: " + ex.Message);
                            }

                            CONTROL[10] = Mcontrol[10];
                            UP = Mcontrol[0];
                            DOWN = Mcontrol[1];
                            LEFT = Mcontrol[2];
                            RIGHT = Mcontrol[3];
                            START = Mcontrol[5];
                            HOME = Mcontrol[8];
                            Solenoid = Mcontrol[9];
                            RightLim = M[0];
                            LeftLim = M[1];
                            UpLim = M[2];
                            DownLim = M[3];
                            PresLim = M[4];
                            PapLim = M[5];
                            //Thread.Sleep(milliseconds);


                            if (UP == true) // GREEN UP
                            {
                                this.label28.BackColor = System.Drawing.Color.Green;
                            }
                            else if (UP == false) // STANDART UP
                            {
                                this.label28.BackColor = System.Drawing.Color.White;
                            }
                            if (DOWN == true) // GREEN DOWN
                            {
                                this.label29.BackColor = System.Drawing.Color.Green;
                            }
                            else if (DOWN == false) // STANDART DOWN
                            {
                                this.label29.BackColor = System.Drawing.Color.White;
                            }
                            if (START == true & HOME == false) // GREEN START, STANDART STOP, STANDART HOME
                            {
                                this.button1.Image = global::TCP_LISTENER_Delta.Properties.Resources.Group_23;
                                this.button2.Image = global::TCP_LISTENER_Delta.Properties.Resources.Group_22;
                                this.button3.Image = global::TCP_LISTENER_Delta.Properties.Resources.Group_26;
                            }
                            if (START == false) // RED STOP, STANDART START,STANDART HOME
                            {
                                this.button1.Image = global::TCP_LISTENER_Delta.Properties.Resources.Group_21;
                                this.button2.Image = global::TCP_LISTENER_Delta.Properties.Resources.Group_24;
                                this.button3.Image = global::TCP_LISTENER_Delta.Properties.Resources.Group_26;
                            }
                            if (HOME == true & START == false) // GREEN HOME, STANDART STOP, STANDART START
                            {
                                this.button2.Image = global::TCP_LISTENER_Delta.Properties.Resources.Group_22;
                                this.button3.Image = global::TCP_LISTENER_Delta.Properties.Resources.Group_27;
                                this.button1.Image = global::TCP_LISTENER_Delta.Properties.Resources.Group_21;
                            }
                            if (InvokeRequired)
                            {
                                Invoke(new Action(() =>
                                {
                                    if (tabControl1.Controls[0] == tabControl1.SelectedTab) // AUTO MODE ON
                                        CONTROL[4] = true;
                                    if (tabControl1.Controls[1] == tabControl1.SelectedTab) // AUTO MODE OFF
                                        CONTROL[4] = false;
                                    if (tabControl1.Controls[2] == tabControl1.SelectedTab) // AUTO MODE OFF
                                        CONTROL[4] = false;
                                }));
                            }
                            else
                            {
                                if (tabControl1.Controls[0] == tabControl1.SelectedTab) // AUTO MODE ON
                                    CONTROL[4] = true;
                                if (tabControl1.Controls[1] == tabControl1.SelectedTab) // AUTO MODE OFF
                                    CONTROL[4] = false;
                                if (tabControl1.Controls[2] == tabControl1.SelectedTab) // AUTO MODE OFF
                                    CONTROL[4] = false;
                            }
                            if (Solenoid == true) // GREEN RIGHT
                            {
                                this.label8.BackColor = System.Drawing.Color.Green;
                            }
                            else if (Solenoid == false) // STANDART RIGHT
                            {
                                this.label8.BackColor = System.Drawing.Color.White;
                            }
                            if (UpLim == true) // GREEN RIGHT
                            {
                                this.label11.BackColor = System.Drawing.Color.Green;
                            }
                            else if (UpLim == false) // STANDART RIGHT
                            {
                                this.label11.BackColor = System.Drawing.Color.White;
                            }
                            if (DownLim == true) // GREEN RIGHT
                            {
                                this.label12.BackColor = System.Drawing.Color.Green;
                            }
                            else if (DownLim == false) // STANDART RIGHT
                            {
                                this.label12.BackColor = System.Drawing.Color.White;
                            }
                            if (PapLim == true) // GREEN RIGHT
                            {
                                this.label14.BackColor = System.Drawing.Color.Green;
                                this.label15.BackColor = System.Drawing.Color.Green;
                            }
                            else if (PapLim == false) // STANDART RIGHT
                            {
                                this.label14.BackColor = System.Drawing.Color.White;
                                this.label15.BackColor = System.Drawing.Color.White;
                            }
                            if (PresLim == true) // GREEN RIGHT
                            {
                                this.label13.BackColor = System.Drawing.Color.Green;
                                this.label16.BackColor = System.Drawing.Color.Green;
                            }
                            else if (PresLim == false) // STANDART RIGHT
                            {
                                this.label13.BackColor = System.Drawing.Color.White;
                                this.label16.BackColor = System.Drawing.Color.White;
                            }
                        }
                        else if (check1 == false)
                        {
                            modbus.Disconnect();
                        }
                    }
                    catch (Exception ex) when (ex.Source == "mscorlib")
                    {
                        return;
                    }
                    catch (Exception ex)
                    {
                        string msg = Convert.ToString(ex.InnerException);
                        MessageBox.Show("Read MDBS: " + ex.Message);
                    }
                }

            }
        }
        /// 
        /// Write data to box, from modbus
        /// 
        void WriteMDBS(string name)
        {
            while (true)
            {
                try
                {

                    if (InvokeRequired)
                    {
                        Invoke(new Action(() =>
                    {
                        MotorSpeedSliderControl.Value = Properties.Settings.Default.SpeedPERC;// PERCENT OF MAIN SPEED = SAVED VALUE
                        motorSpeed = MotorSpeedSliderControl.Value;                           //
                        trackBar2.Value = Properties.Settings.Default.SPEED_Y_MAN;            // MANUAL SPEED Y = SAVED VALUE
                        motorSpeedY = trackBar2.Value;

                        if (modbus.Connected == false)
                        {
                            lblStat.Text = "Status: Disconnected";
                            textBox13.Text = "";
                            textBox1.Text = "";
                            textBox20.Text = "";
                            textBox21.Text = "";
                            textBox4.Text = "";
                            textBox9.Text = "";
                        }
                    }));
                    }
                    else
                    {
                        MotorSpeedSliderControl.Value = Properties.Settings.Default.SpeedPERC;
                        motorSpeed = MotorSpeedSliderControl.Value;
                        trackBar2.Value = Properties.Settings.Default.SPEED_Y_MAN;
                        motorSpeedY = trackBar2.Value;

                        if (modbus.Connected == false)
                        {
                            lblStat.Text = "Status: Disconnected";
                            textBox13.Text = "";
                            textBox1.Text = "";
                            textBox20.Text = "";
                            textBox21.Text = "";
                            textBox4.Text = "";
                            textBox9.Text = "";
                        }
                    }
                }
                catch (Exception ex) when (ex.Source == "mscorlib")
                {
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Write trackbar from memory: " + ex.Message);
                }
                if (modbus.Connected == true)
                {
                    try
                    {

                        //if (D[2] < 0)
                        //    resultX = (unchecked((uint)D[2]) - 4294901762);
                        //if (D[2] >= 0)
                        //    resultX = (unchecked((uint)D[2]));
                        //if (D[30] < 0)
                        //   result = (unchecked((uint)D[30]) - 4294901762);
                        //if (D[30] >= 0)
                        //    result = (unchecked((uint)D[30]));
                        //if (D[10] < 0)
                        //    resultY = (unchecked((uint)D[10]) - 4294901762);
                        //if (D[10] >= 0)
                        //    resultY = (unchecked((uint)D[10]));

                        if (InvokeRequired)
                        {
                            Invoke(new Action(() =>
                            {
                                textBox9.Text = D[10].ToString(); //M1 SPEED (Manual Speed Y)
                                textBox1.Text = D[30].ToString() + "%"; // PERCENT OF MAIN SPEED
                                textBox4.Text = posXtab1.ToString(); //position Y Tab2
                                textBox13.Text = posXtab1.ToString(); //position Y Tab1
                                textBox20.Text = D[44].ToString(); //SPD Y1 Tab1
                                textBox21.Text = D[46].ToString(); //SPD Y2 Tab1


                            }));
                        }

                        else
                        {
                            textBox9.Text = D[10].ToString(); //M1 SPEED (Manual Speed Y)
                            textBox1.Text = D[30].ToString() + "%"; // PERCENT OF MAIN SPEED  
                            textBox4.Text = posXtab1.ToString(); //position Y Tab2
                            textBox13.Text = posXtab1.ToString(); //position Y Tab1
                            textBox20.Text = D[44].ToString(); //SPD Y1 Tab1
                            textBox21.Text = D[46].ToString(); //SPD Y2 Tab1


                        }

                    }
                    catch (Exception ex) when (ex.Source == "mscorlib")
                    {
                        return;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Positions from modbus: " + ex.Message);
                    }
                }
            }
        }
        /// 
        /// Write X ACC
        /// 
        private void textBox45_TextChanged_1(object sender, EventArgs e)
        {
            if (textBox45.Text == "")
            {
                return;
            }
            else if (textBox45.Text != "")
            {
                Int32 txt = Convert.ToInt32(textBox45.Text);
                if (txt > 1000)
                {
                    MessageBox.Show("Set value from 0 to 1000");
                    txt1 = 1000;
                    textBox45.Text = "1000";
                }
                else if (txt <= 1000)
                    txt1 = txt;
            }
            Properties.Settings.Default.ACC_X_MAN = textBox45.Text;
            Properties.Settings.Default.Save();
        }
        private void CheckEnter(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9') || (e.KeyChar == '.') || (e.KeyChar == (char)Keys.Back)) //|| (e.KeyChar == '-')
            {
                return;
            }
            e.Handled = true;
        }
        /// 
        /// Write X DEC
        /// 
        private void textBox44_TextChanged_1(object sender, EventArgs e)
        {
            if (textBox44.Text == "")
            {
                return;
            }
            else if (textBox44.Text != "")
            {
                Int32 txt = Convert.ToInt32(textBox44.Text);
                if (txt > 1000)
                {
                    MessageBox.Show("Set value from 0 to 1000");
                    txt2 = 1000;
                    textBox44.Text = "1000";
                }
                else if (txt <= 1000)
                    txt2 = txt;
            }
            Properties.Settings.Default.DEC_X_MAN = textBox44.Text;
            Properties.Settings.Default.Save();
        }
        /// 
        /// BTN UP
        /// 
        private void btnUP_Down(object sender, EventArgs e)
        {
            if (modbus.Connected == true)
            {
                if (motorSpeedY > 0)
                {
                    CONTROL[0] = true;
                }
                else if (motorSpeedY == 0)
                {
                    CONTROL[0] = false;
                    MessageBox.Show("Set speed Y greater than 0");
                }
            }
            else if (modbus.Connected == false)
            {
                MessageBox.Show("PLC disabled");
            }

        }
        private void btnUP_Up(object sender, EventArgs e)
        {
            CONTROL[0] = false;
        }
        /// 
        /// BTN RIGHT
        /// 
        private void btnRIGHT_Down(object sender, EventArgs e)
        {
            if (modbus.Connected == true)
            {
                if (motorSpeedX > 0)
                {
                    CONTROL[3] = true;
                }
                else if (motorSpeedX == 0)
                {
                    CONTROL[3] = false;
                    MessageBox.Show("Set speed X greater than 0");
                }
            }
            else if (modbus.Connected == false)
            {
                MessageBox.Show("PLC disabled");
            }
        }
        private void btnRIGHT_Up(object sender, EventArgs e)
        {
            CONTROL[3] = false;
        }
        /// 
        /// BTN LEFT
        /// 
        private void btnLEFT_Down(object sender, EventArgs e)
        {
            if (modbus.Connected == true)
            {
                if (motorSpeedX > 0)
                {
                    CONTROL[2] = true;
                }
                else if (motorSpeedX == 0)
                {
                    CONTROL[2] = false;
                    MessageBox.Show("Set speed X greater than 0");
                }
            }
            else if (modbus.Connected == false)
            {
                MessageBox.Show("PLC disabled");
            }
        }
        private void btnLEFT_Up(object sender, EventArgs e)
        {
            CONTROL[2] = false;
        }
        /// 
        /// BTN DOWN
        /// 
        private void btnDWN_Down(object sender, EventArgs e)
        {
            if (modbus.Connected == true)
            {
                if (motorSpeedY > 0)
                {
                    CONTROL[1] = true;
                }
                else if (motorSpeedY == 0)
                {
                    CONTROL[1] = false;
                    MessageBox.Show("Set speed Y greater than 0");
                }
            }
            else if (modbus.Connected == false)
            {
                MessageBox.Show("PLC disabled");
            }

        }
        private void btnDWN_Up(object sender, EventArgs e)
        {
            CONTROL[1] = false;
        }
        /// 
        /// WHITE BACKGROUND IF MOUSE ENTER
        /// 
        private void btnDWN_ENTER(object sender, EventArgs e)
        {
            btnDWN.BackColor = System.Drawing.Color.White;
        }
        /// 
        /// WHITE BACKGROUND IF MOUSE ENTER
        /// 
        private void btnUp_ENTER(object sender, EventArgs e)
        {
            btnUP.BackColor = System.Drawing.Color.White;
        }
        /// 
        /// READ TXT FROM PICTURE
        /// 
        private void btnTXT_Click(object sender, EventArgs e)
        {
            try
            {
                Tesseract tesseract = new Tesseract(@tesser, "eng", OcrEngineMode.TesseractLstmCombined);
                tesseract.SetImage(new Image<Bgr, byte>(pictureBox1.ImageLocation));
                tesseract.Recognize();
                richTextBox1.Text = tesseract.GetUTF8Text();
                tesseract.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("tesseract" + ex.Message);
            }
        }
        /// 
        /// MAIN SPEED Y1
        /// 
        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            {

                if (textBox16.Text == "")
                {
                    return;
                }
                else if (textBox16.Text != "")
                {
                    Int32 txt = Convert.ToInt32(textBox16.Text);
                    if (txt > 20000)
                    {
                        MessageBox.Show("Set value from 0 to 20000");
                        txt7 = 20000;
                        textBox16.Text = "20000";
                    }
                    else if (txt <= 20000)
                        txt7 = txt;
                }
            }
            Properties.Settings.Default.SpeedY1 = textBox16.Text;
            Properties.Settings.Default.Save();
        }
        /// 
        /// RELEASE TIMER INPUT
        /// 
        private void textBox17_TextChanged(object sender, EventArgs e)
        {
            {

                if (textBox17.Text == "")
                {
                    return;
                }
                else if (textBox17.Text != "")
                {
                    Int32 txt = Convert.ToInt32(textBox17.Text);
                    if (txt > 20000)
                    {
                        MessageBox.Show("Set value from 0 to 20000");
                        txt8 = 20000;
                        textBox17.Text = "20000";
                    }
                    else if (txt <= 20000)
                        txt8 = txt;
                }
            }
            Properties.Settings.Default.SpeedY2 = textBox17.Text;
            Properties.Settings.Default.Save();
        }
        /// 
        /// RELEASE POSITION Y INPUT
        /// 
        private void textBox24_TextChanged(object sender, EventArgs e)
        {
            if (textBox24.Text == "")
            {
                return;
            }
            else if (textBox24.Text != "")
            {
                Int32 txt = Convert.ToInt32(textBox24.Text);
                if (txt > 20000)
                {
                    MessageBox.Show("Set value from 0 to 20000");
                    txt9 = 20000;
                    textBox24.Text = "20000";
                }
                else if (txt <= 20000)
                    txt9 = txt;
            }
            Properties.Settings.Default.POS1 = textBox24.Text;
            Properties.Settings.Default.Save();
        }
        /// 
        /// SCAN POSITION Y INPUT
        /// 
        private void textBox23_TextChanged(object sender, EventArgs e)
        {
            if (textBox23.Text == "")
            {
                return;
            }
            else if (textBox23.Text != "")
            {
                Int32 txt = Convert.ToInt32(textBox23.Text);
                if (txt > 20000)
                {
                    MessageBox.Show("Set value from 0 to 20000");
                    txt10 = 20000;
                    textBox23.Text = "20000";
                }
                else if (txt <= 20000)
                    txt10 = txt;
            }
            Properties.Settings.Default.POS2 = textBox23.Text;
            Properties.Settings.Default.Save();
        }
        /// 
        /// GRAB POSITION Y INPUT
        /// 
        private void textBox22_TextChanged(object sender, EventArgs e)
        {
            if (textBox22.Text == "")
            {
                return;
            }
            else if (textBox22.Text != "")
            {
                Int32 txt = Convert.ToInt32(textBox22.Text);
                if (txt > 20000)
                {
                    MessageBox.Show("Set value from 0 to 20000");
                    txt11 = 20000;
                    textBox22.Text = "20000";
                }
                else if (txt <= 20000)
                    txt11 = txt;
            }
            Properties.Settings.Default.POS3 = textBox22.Text;
            Properties.Settings.Default.Save();
        }
        /// 
        /// PORT INPUT
        /// 
        private void txtPort_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Port = txtPort.Text;
            Properties.Settings.Default.Save();
        }
        /// 
        /// IP INPUT
        /// 
        private void txtIPAdress_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.IP = txtIPAdress.Text;
            Properties.Settings.Default.Save();
        }
        /// 
        /// GRAB TIMER INPUT
        /// 
        private void textBox27_TextChanged(object sender, EventArgs e)
        {
            if (textBox27.Text == "")
            {
                return;
            }
            else if (textBox27.Text != "")
            {
                Int32 txt = Convert.ToInt32(textBox27.Text);
                if (txt > 20000)
                {
                    MessageBox.Show("Set value from 0 to 20000");
                    Grab_TMR = 20000;
                    textBox27.Text = "20000";
                }
                else if (txt <= 20000)
                    Grab_TMR = txt;
            }
            Properties.Settings.Default.GrabTMR = textBox27.Text;
            Properties.Settings.Default.Save();
        }
        /// 
        /// SCAN TIMER INPUT
        /// 
        private void textBox26_TextChanged(object sender, EventArgs e)
        {
            if (textBox26.Text == "")
            {
                return;
            }
            else if (textBox26.Text != "")
            {
                Int32 txt = Convert.ToInt32(textBox26.Text);
                if (txt > 20000)
                {
                    MessageBox.Show("Set value from 0 to 20000");
                    Scan_TMR = 20000;
                    textBox26.Text = "20000";
                }
                else if (txt <= 20000)
                    Scan_TMR = txt;
            }
            Properties.Settings.Default.ScanTMR = textBox26.Text;
            Properties.Settings.Default.Save();
        }
        /// 
        /// RELEASE TIMER INPUT
        /// 
        private void textBox28_TextChanged(object sender, EventArgs e)
        {
            if (textBox28.Text == "")
            {
                return;
            }
            else if (textBox22.Text != "")
            {
                Int32 txt = Convert.ToInt32(textBox28.Text);
                if (txt > 20000)
                {
                    MessageBox.Show("Set value from 0 to 20000");
                    Release_TMR = 20000;
                    textBox28.Text = "20000";
                }
                else if (txt <= 20000)
                    Release_TMR = txt;
            }
            Properties.Settings.Default.ReleaseTMR = textBox28.Text;
            Properties.Settings.Default.Save();
        }


        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            tesser = textBox5.Text;
            Properties.Settings.Default.tesPath = textBox5.Text;
            Properties.Settings.Default.Save();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (modbus.Connected == true)
            {
                //if (Solenoid == false)
                //{
                CONTROL[9] = !CONTROL[9];
                //}
                //if (Solenoid == true)
                //{
                //    CONTROL[9] = false;
                // }

            }
            else if (modbus.Connected == false)
            {
                MessageBox.Show("PLC disabled");
            }
        }
        private void SOL_ENTER(object sender, EventArgs e)
        {
            button5.BackColor = System.Drawing.Color.White;
        }
        private void SOL_Down(object sender, EventArgs e)
        {
            //  if (modbus.Connected == true)
            //  {
            //
            //          CONTROL[9] = true;
            //  }
            //  else if (modbus.Connected == false)
            //  {
            //      MessageBox.Show("PLC disabled");
            //  }
        }
        private void SOL_Up(object sender, EventArgs e)
        {
            //  CONTROL[9] = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                return;
            }
            else if (textBox2.Text != "")
            {
                Int32 txt = Convert.ToInt32(textBox2.Text);
                if (txt > 20000 | txt < -20000)
                {
                    MessageBox.Show("Set value from -20000 to 20000");
                    Hi = 0;
                    textBox2.Text = "0";
                }
                else if (txt > -20000 | txt < 20000)
                    Hi = txt;
            }
            Properties.Settings.Default.Height = textBox2.Text;
            Properties.Settings.Default.Save();
        }

        private void Form_Listener_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                check1 = false;
                modbus.Disconnect();
                thread1.Abort(); ;
                thread2.Abort();
            }
            catch
            {
                return;
            }
        }


        private void button7_Click(object sender, EventArgs e)
        {
            using (var opnFLd = new FolderBrowserDialog()) //ANY dialog
            {
                //opnDlg.Filter = "Png Files (*.png)|*.png";
                //opnDlg.Filter = "Excel Files (*.xls, *.xlsx)|*.xls;*.xlsx|CSV Files (*.csv)|*.csv"

                if (opnFLd.ShowDialog() == DialogResult.OK)
                {
                    //opnDlg.SelectedPath -- your result
                    picture_path = Convert.ToString(opnFLd.SelectedPath);
                    textBox3.Text = Convert.ToString(opnFLd.SelectedPath);

                }
            }
        }


        private void hOPETableBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            sqlConn.Close();
        }

        private void Form_Listener_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hOPEDataSet11.HOPETable' table. You can move, or remove it, as needed.
            this.hOPETableTableAdapter2.Fill(this.hOPEDataSet11.HOPETable);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView2.SelectedRows)
            {
                dataGridView2.Rows.Remove(row);
                textBox12.Text = "Row count: " + Convert.ToString(dataGridView2.RowCount);
            }
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {

        }

        private void SaveToRdButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void RecordVideoButton_Click(object sender, EventArgs e)
        {

        }

        private void TakePhotoButton_Click(object sender, EventArgs e)
        {

        }

        private void ISOCoBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TvCoBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AvCoBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FocusFar3Button_Click(object sender, EventArgs e)
        {

        }

        private void FocusFar2Button_Click(object sender, EventArgs e)
        {

        }

        private void FocusFar1Button_Click(object sender, EventArgs e)
        {

        }

        private void FocusNear1Button_Click(object sender, EventArgs e)
        {

        }

        private void FocusNear2Button_Click(object sender, EventArgs e)
        {

        }

        private void FocusNear3Button_Click(object sender, EventArgs e)
        {

        }

        private void LiveViewPicBox_SizeChanged(object sender, EventArgs e)
        {

        }

        private void LiveViewButton_Click(object sender, EventArgs e)
        {

        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {

        }

        private void SessionButton_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                IsInit = false;
            }
            catch (Exception ex) { ReportError(ex.Message, false); }
        }

        #region API Events

        private void APIHandler_CameraAdded(CanonAPI sender)
        {
            try { Invoke((Action)delegate { RefreshCamera(); }); }
            catch (Exception ex) { ReportError(ex.Message, false); }
        }

        private void MainCamera_StateChanged(Camera sender, StateEventID eventID, int parameter)
        {
            try { if (eventID == StateEventID.Shutdown && IsInit) { Invoke((Action)delegate { CloseSession(); }); } }
            catch (Exception ex) { ReportError(ex.Message, false); }
        }

        private void MainCamera_ProgressChanged(object sender, int progress)
        {
            try { Invoke((Action)delegate { MainProgressBar.Value = progress; }); }
            catch (Exception ex) { ReportError(ex.Message, false); }
        }

        private void MainCamera_LiveViewUpdated(Camera sender, Stream img)
        {
            try
            {
                lock (LvLock)
                {
                    Evf_Bmp?.Dispose();
                    Evf_Bmp = new Bitmap(img);
                }
                LiveViewPicBox.Invalidate();
            }
            catch (Exception ex) { ReportError(ex.Message, false); }
        }

        private void MainCamera_DownloadReady(Camera sender, DownloadInfo Info)
        {
            try
            {
                string dir = null;
                Invoke((Action)delegate { dir = SavePathTextBox.Text; });
                sender.DownloadFile(Info, dir);
                Invoke((Action)delegate { MainProgressBar.Value = 0; });
            }
            catch (Exception ex) { ReportError(ex.Message, false); }
        }

        private void ErrorHandler_NonSevereErrorHappened(object sender, ErrorCode ex)
        {
            ReportError($"SDK Error code: {ex} ({((int)ex).ToString("X")})", false);
        }

        private void ErrorHandler_SevereErrorHappened(object sender, Exception ex)
        {
            ReportError(ex.Message, true);
        }

        #endregion

        #region Session

        private void SessionButton_Click_1(object sender, EventArgs e)
        {
            if (MainCamera?.SessionOpen == true) CloseSession();
            else OpenSession();
        }

        private void RefreshButton_Click_1(object sender, EventArgs e)
        {
            try { RefreshCamera(); }
            catch (Exception ex) { ReportError(ex.Message, false); }
        }

        #endregion

        #region Settings

        private void TakePhotoButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                if ((string)TvCoBox.SelectedItem == "Bulb") MainCamera.TakePhotoBulbAsync((int)BulbUpDo.Value);
                else MainCamera.TakePhotoShutterAsync();
            }
            catch (Exception ex) { ReportError(ex.Message, false); }
        }

        private void RecordVideoButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                Recording state = (Recording)MainCamera.GetInt32Setting(PropertyID.Record);
                if (state != Recording.On)
                {
                    MainCamera.StartFilming(true);
                    RecordVideoButton.Text = "Stop Video";
                }
                else
                {
                    bool save = STComputerRdButton.Checked || STBothRdButton.Checked;
                    MainCamera.StopFilming(save);
                    RecordVideoButton.Text = "Record Video";
                }
            }
            catch (Exception ex) { ReportError(ex.Message, false); }
        }

        private void BrowseButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (Directory.Exists(SavePathTextBox.Text)) SaveFolderBrowser.SelectedPath = SavePathTextBox.Text;
                if (SaveFolderBrowser.ShowDialog() == DialogResult.OK)
                {
                    SavePathTextBox.Text = SaveFolderBrowser.SelectedPath;
                }
            }
            catch (Exception ex) { ReportError(ex.Message, false); }
        }

        private void AvCoBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (AvCoBox.SelectedIndex < 0) return;
                MainCamera.SetSetting(PropertyID.Av, AvValues.GetValue((string)AvCoBox.SelectedItem).IntValue);
            }
            catch (Exception ex) { ReportError(ex.Message, false); }
        }

        private void TvCoBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (TvCoBox.SelectedIndex < 0) return;

                MainCamera.SetSetting(PropertyID.Tv, TvValues.GetValue((string)TvCoBox.SelectedItem).IntValue);
                BulbUpDo.Enabled = (string)TvCoBox.SelectedItem == "Bulb";
            }
            catch (Exception ex) { ReportError(ex.Message, false); }
        }

        private void ISOCoBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (ISOCoBox.SelectedIndex < 0) return;
                MainCamera.SetSetting(PropertyID.ISO, ISOValues.GetValue((string)ISOCoBox.SelectedItem).IntValue);
            }
            catch (Exception ex) { ReportError(ex.Message, false); }
        }

        private void SaveToRdButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (IsInit)
                {
                    if (STCameraRdButton.Checked)
                    {
                        MainCamera.SetSetting(PropertyID.SaveTo, (int)SaveTo.Camera);
                        BrowseButton.Enabled = false;
                        SavePathTextBox.Enabled = false;
                    }
                    else
                    {
                        if (STComputerRdButton.Checked) MainCamera.SetSetting(PropertyID.SaveTo, (int)SaveTo.Host);
                        else if (STBothRdButton.Checked) MainCamera.SetSetting(PropertyID.SaveTo, (int)SaveTo.Both);

                        MainCamera.SetCapacity(4096, int.MaxValue);
                        BrowseButton.Enabled = true;
                        SavePathTextBox.Enabled = true;
                    }
                }
            }
            catch (Exception ex) { ReportError(ex.Message, false); }
        }

        #endregion

        #region Live view

        private void LiveViewButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (!MainCamera.IsLiveViewOn) { MainCamera.StartLiveView(); LiveViewButton.Text = "Stop LV"; }
                else { MainCamera.StopLiveView(); LiveViewButton.Text = "Start LV"; }
            }
            catch (Exception ex) { ReportError(ex.Message, false); }
        }

        private void LiveViewPicBox_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                LVBw = LiveViewPicBox.Width;
                LVBh = LiveViewPicBox.Height;
                LiveViewPicBox.Invalidate();
            }
            catch (Exception ex) { ReportError(ex.Message, false); }
        }

        private void LiveViewPicBox_Paint(object sender, PaintEventArgs e)
        {
            if (MainCamera == null || !MainCamera.SessionOpen) return;

            if (!MainCamera.IsLiveViewOn) e.Graphics.Clear(BackColor);
            else
            {
                lock (LvLock)
                {
                    if (Evf_Bmp != null)
                    {
                        LVBratio = LVBw / (float)LVBh;
                        LVration = Evf_Bmp.Width / (float)Evf_Bmp.Height;
                        if (LVBratio < LVration)
                        {
                            w = LVBw;
                            h = (int)(LVBw / LVration);
                        }
                        else
                        {
                            w = (int)(LVBh * LVration);
                            h = LVBh;
                        }
                        e.Graphics.DrawImage(Evf_Bmp, 0, 0, w, h);
                    }
                }
            }
        }

        private void FocusNear3Button_Click(object sender, EventArgs e)
        {
            try { MainCamera.SendCommand(CameraCommand.DriveLensEvf, (int)DriveLens.Near3); }
            catch (Exception ex) { ReportError(ex.Message, false); }
        }

        private void FocusNear2Button_Click(object sender, EventArgs e)
        {
            try { MainCamera.SendCommand(CameraCommand.DriveLensEvf, (int)DriveLens.Near2); }
            catch (Exception ex) { ReportError(ex.Message, false); }
        }

        private void FocusNear1Button_Click(object sender, EventArgs e)
        {
            try { MainCamera.SendCommand(CameraCommand.DriveLensEvf, (int)DriveLens.Near1); }
            catch (Exception ex) { ReportError(ex.Message, false); }
        }

        private void FocusFar1Button_Click(object sender, EventArgs e)
        {
            try { MainCamera.SendCommand(CameraCommand.DriveLensEvf, (int)DriveLens.Far1); }
            catch (Exception ex) { ReportError(ex.Message, false); }
        }

        private void FocusFar2Button_Click(object sender, EventArgs e)
        {
            try { MainCamera.SendCommand(CameraCommand.DriveLensEvf, (int)DriveLens.Far2); }
            catch (Exception ex) { ReportError(ex.Message, false); }
        }

        private void FocusFar3Button_Click(object sender, EventArgs e)
        {
            try { MainCamera.SendCommand(CameraCommand.DriveLensEvf, (int)DriveLens.Far3); }
            catch (Exception ex) { ReportError(ex.Message, false); }
        }

        #endregion

        #region Subroutines

        private void CloseSession()
        {
            MainCamera.CloseSession();
            AvCoBox.Items.Clear();
            TvCoBox.Items.Clear();
            ISOCoBox.Items.Clear();
            SettingsGroupBox.Enabled = false;
            LiveViewGroupBox.Enabled = false;
            SessionButton.Text = "Open Session";
            SessionLabel.Text = "No open session";
            LiveViewButton.Text = "Start LV";
        }

        private void RefreshCamera()
        {
            CameraListBox.Items.Clear();
            CamList = APIHandler.GetCameraList();
            foreach (Camera cam in CamList) CameraListBox.Items.Add(cam.DeviceName);
            if (MainCamera?.SessionOpen == true) CameraListBox.SelectedIndex = CamList.FindIndex(t => t.ID == MainCamera.ID);
            else if (CamList.Count > 0) CameraListBox.SelectedIndex = 0;
        }

        private void OpenSession()
        {
            if (CameraListBox.SelectedIndex >= 0)
            {
                MainCamera = CamList[CameraListBox.SelectedIndex];
                MainCamera.OpenSession();
                MainCamera.LiveViewUpdated += MainCamera_LiveViewUpdated;
                MainCamera.ProgressChanged += MainCamera_ProgressChanged;
                MainCamera.StateChanged += MainCamera_StateChanged;
                MainCamera.DownloadReady += MainCamera_DownloadReady;

                SessionButton.Text = "Close Session";
                SessionLabel.Text = MainCamera.DeviceName;
                AvList = MainCamera.GetSettingsList(PropertyID.Av);
                TvList = MainCamera.GetSettingsList(PropertyID.Tv);
                ISOList = MainCamera.GetSettingsList(PropertyID.ISO);
                foreach (var Av in AvList) AvCoBox.Items.Add(Av.StringValue);
                foreach (var Tv in TvList) TvCoBox.Items.Add(Tv.StringValue);
                foreach (var ISO in ISOList) ISOCoBox.Items.Add(ISO.StringValue);
                AvCoBox.SelectedIndex = AvCoBox.Items.IndexOf(AvValues.GetValue(MainCamera.GetInt32Setting(PropertyID.Av)).StringValue);
                TvCoBox.SelectedIndex = TvCoBox.Items.IndexOf(TvValues.GetValue(MainCamera.GetInt32Setting(PropertyID.Tv)).StringValue);
                ISOCoBox.SelectedIndex = ISOCoBox.Items.IndexOf(ISOValues.GetValue(MainCamera.GetInt32Setting(PropertyID.ISO)).StringValue);
                SettingsGroupBox.Enabled = true;
                LiveViewGroupBox.Enabled = true;
            }
        }

        private void ReportError(string message, bool lockdown)
        {
            int errc;
            lock (ErrLock) { errc = ++ErrCount; }

            if (lockdown) EnableUI(false);

            if (errc < 4) MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (errc == 4) MessageBox.Show("Many errors happened!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            lock (ErrLock) { ErrCount--; }
        }

        private void EnableUI(bool enable)
        {
            if (InvokeRequired) Invoke((Action)delegate { EnableUI(enable); });
            else
            {
                SettingsGroupBox.Enabled = enable;
                InitGroupBox.Enabled = enable;
                LiveViewGroupBox.Enabled = enable;
            }
        }
        #endregion
    }
}

    
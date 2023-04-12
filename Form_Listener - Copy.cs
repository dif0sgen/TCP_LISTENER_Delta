//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Drawing.Imaging;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using Basler.Pylon;
//using Emgu.CV;
//using System.IO;
//using System.Net;
//using System.Net.Sockets;
//using System.Diagnostics;


//namespace TCP_LISTENER_Delta
//{
//    public partial class Form_Listener : Form
//    {
//		public Camera camera = null;
//		//Image conversion
//		private PixelDataConverter converter = new PixelDataConverter();
//		//measure time 
//		private Stopwatch stopWatch = new Stopwatch();

//		// Set up the controls and events to be used and update the device list.

//		public delegate void InvokeDelegate();

//		private Thread n_server;
//		private Thread n_message;
//		private Thread n_client;
//		private Thread n_send_server;
//		private Thread n_shot;
//		private TcpListener listener;
//		private Socket socket;
//		private string message;
//		string out1 = "0";
//		string out2 = "0";
//		string position = "";
//		int Old_POS = 0;


//		int step = 30;

//		// Occurs when the connection to a camera device is opened.
//		public void OnCameraOpened(Object sender, EventArgs e)
//		{
//			if (InvokeRequired)
//			{
//			// If called from a different thread, we must use the Invoke method to marshal the call to the proper thread.
//			BeginInvoke(new EventHandler<EventArgs>(OnCameraOpened), sender, e);
//			return;
//			}

//			 //The image provider is ready to grab. Enable the grab buttons.
//			EnableButtons(true, false);
//		}


//		// Occurs when the connection to a camera device is closed.
//		public void OnCameraClosed(Object sender, EventArgs e)
//		{
//			if (InvokeRequired)
//			{
//			// If called from a different thread, we must use the Invoke method to marshal the call to the proper thread.
//			BeginInvoke(new EventHandler<EventArgs>(OnCameraClosed), sender, e);
//			return;
//		}

//			// The camera connection is closed. Disable all buttons.
//			EnableButtons(false, false);
//		}


//		// Occurs when a camera starts grabbing.
//		public void OnGrabStarted(Object sender, EventArgs e)
//		{
//			if (InvokeRequired)
//			{
//			// If called from a different thread, we must use the Invoke method to marshal the call to the proper thread.
//			BeginInvoke(new EventHandler<EventArgs>(OnGrabStarted), sender, e);
//			return;
//			}

//			// Reset the stopwatch used to reduce the amount of displayed images. The camera may acquire images faster than the images can be displayed.

//			stopWatch.Reset();

//			// Do not update the device list while grabbing to reduce jitter. Jitter may occur because the GUI thread is blocked for a short time when enumerating.
//			UpdateDeviceList();//**

//			// The camera is grabbing. Disable the grab buttons. Enable the stop button.
//			EnableButtons(false, true);
//		}



//		// Occurs when an image has been acquired and is ready to be processed.
//		public void OnImageGrabbed(Object sender, ImageGrabbedEventArgs e)
//		{ 
//			//Cross-thread access control
//			if (InvokeRequired)
//			{
//			// If called from a different thread, we must use the Invoke method to marshal the call to the proper GUI thread.
//			// The grab result will be disposed after the event call. Clone the event arguments for marshaling to the GUI thread.
//			BeginInvoke(new EventHandler<ImageGrabbedEventArgs>(OnImageGrabbed), sender, e.Clone());
//			return;
//			}

//			try
//			{
//				// Acquire the image from the camera. Only show the latest image. The camera may acquire images faster than the images can be displayed.

//				// Get the grab result.
//				IGrabResult grabResult = e.GrabResult;

//				// Check if the image can be displayed.
//				if (grabResult.IsValid)
//				{
//					// Reduce the number of displayed images to a reasonable amount if the camera is acquiring images very fast.
//					if (!stopWatch.IsRunning || stopWatch.ElapsedMilliseconds > 33)
//					{
//						stopWatch.Restart();

//						Bitmap bitmap = new Bitmap(grabResult.Width, grabResult.Height, PixelFormat.Format32bppRgb);
//						// Lock the bits of the bitmap.
//						BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, bitmap.PixelFormat);
//						// Place the pointer to the buffer of the bitmap.
//						converter.OutputPixelFormat = PixelType.BGRA8packed;
//						IntPtr ptrBmp = bmpData.Scan0;
//						converter.Convert(ptrBmp, bmpData.Stride * bitmap.Height, grabResult); //Exception handling TODO
//						bitmap.UnlockBits(bmpData);

//						// Assign a temporary variable to dispose the bitmap after assigning the new bitmap to the display control.
//						Bitmap bitmapOld = pictureBox.Image as Bitmap;

//						bitmap.Save("D://HIAS/Projects/MP/Saved_Images/" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss-ff") + ".jpg", ImageFormat.Jpeg);
//						// Provide the display control with the new bitmap. This action automatically updates the display.
//						pictureBox.Image = bitmap;

//						if (bitmapOld != null)
//						{
//							// Dispose the bitmap.
//							bitmapOld.Dispose();
//						}
//					}
//				}
//			}
//			catch (Exception exception)
//			{
//				ShowException(exception);
//			}
//			finally
//			{
//				// Dispose the grab result if needed for returning it to the grab loop.
//				e.DisposeGrabResultIfClone();
//			}
//		}


//		// Occurs when a camera has stopped grabbing.
//		public void OnGrabStopped(Object sender, GrabStopEventArgs e)
//		{
//			if (InvokeRequired)
//			{
//				// If called from a different thread, we must use the Invoke method to marshal the call to the proper thread.
//				BeginInvoke(new EventHandler<GrabStopEventArgs>(OnGrabStopped), sender, e);
//				return;
//			}

//			// Reset the stopwatch.
//			stopWatch.Reset();

//			// Re-enable the updating of the device list.
//			UpdateDeviceList();//**

//			// The camera stopped grabbing. Enable the grab buttons. Disable the stop button.
//			EnableButtons(true, false);

//			// If the grabbed stop due to an error, display the error message.
//			if (e.Reason != GrabStopReason.UserRequest)
//			{
//				MessageBox.Show("A grab error occured:\n" + e.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//			}

//		}





//		// Stops the grabbing of images and handles exceptions.
//		public void Stop()
//		{
//			// Stop the grabbing.
//			try
//			{
//				camera.StreamGrabber.Stop();
//			}
//			catch (Exception exception)
//			{
//				ShowException(exception);
//			}
//		}


//		// Closes the camera object and handles exceptions.
//		public void DestroyCamera()
//		{
//			// Disable all parameter controls.
//			try
//			{
//				if (camera != null)
//				{

//					WhiteBalanceControl.Text = null;
//					pixelFormatControl.Text = null;
//					widthSliderControl.Text = null;
//					heightSliderControl.Text = null;
//					gainSliderControl.Text = null;
//					exposureTimeSliderControl.Text = null;

//					WhiteBalanceControl.SelectedItem = null;
//					pixelFormatControl.SelectedItem = null;
//					widthSliderControl.Value = 0;
//					heightSliderControl.Value = 0;
//					gainSliderControl.Value = 0;
//					exposureTimeSliderControl.Value = 0;
//				}
//			}
//			catch (Exception exception)
//			{
//				ShowException(exception);
//			}

//			// Destroy the camera object.
//			try
//			{
//				if (camera != null)
//				{
//					camera.Close();
//					camera.Dispose();
//					camera = null;
//				}
//			}
//			catch (Exception exception)
//			{
//				ShowException(exception);
//			}
//		}


//		// Starts the grabbing of a single image and handles exceptions.
//		public void OneShot()
//		{
//			try
//			{
//				// Starts the grabbing of one image.
//				camera.Parameters[PLCamera.AcquisitionMode].SetValue(PLCamera.AcquisitionMode.SingleFrame);
//				camera.StreamGrabber.Start(1, GrabStrategy.OneByOne, GrabLoop.ProvidedByStreamGrabber);
//			}
//			catch (Exception exception)
//			{
//				ShowException(exception);
//			}
//		}


//		// Starts the continuous grabbing of images and handles exceptions.
//		public void ContinuousShot()
//		{
//			try
//			{
//				// Start the grabbing of images until grabbing is stopped.
//				camera.Parameters[PLCamera.AcquisitionMode].SetValue(PLCamera.AcquisitionMode.Continuous);
//				camera.StreamGrabber.Start(GrabStrategy.OneByOne, GrabLoop.ProvidedByStreamGrabber);
//			}
//			catch (Exception exception)
//			{
//				ShowException(exception);
//			}
//		}


//		// Updates the list of available camera devices.
//		public void UpdateDeviceList()
//		{
//			try
//			{
//				// Ask the camera finder for a list of camera devices.
//				//Enumerate all available devices on the computer
//				List<ICameraInfo> allCameras = CameraFinder.Enumerate();

//				//Current camera list
//				ListView.ListViewItemCollection items = deviceListView.Items;

//				// Loop over all cameras found.
//				//Cycle all available device information
//				foreach (ICameraInfo cameraInfo in allCameras)
//				{
//					// Loop over all cameras in the list of cameras.
//					bool newitem = true;
//					foreach (ListViewItem item in items)
//					{
//						ICameraInfo tag = item.Tag as ICameraInfo;

//						// Is the camera found already in the list of cameras?
//						//Check if the currently found camera is already in the camera list
//						if (tag[CameraInfoKey.FullName] == cameraInfo[CameraInfoKey.FullName])
//						{
//							tag = cameraInfo;
//							newitem = false;
//							break;
//						}
//					}

//					// If the camera is not in the list, add it to the list.
//					//If the camera is not added to the list in the current list
//					if (newitem)
//					{
//						// Create the item to display.
//						//Create an Item whose content is the FriendlyName of the current camera
//						ListViewItem item = new ListViewItem(cameraInfo[CameraInfoKey.FriendlyName]);

//						// Create the tool tip text.
//						string toolTipText = "";
//						foreach (KeyValuePair<string, string> kvp in cameraInfo)
//						{
//							toolTipText += kvp.Key + ": " + kvp.Value + "\n";
//						}
//						item.ToolTipText = toolTipText;

//						// Store the camera info in the displayed item.
//						item.Tag = cameraInfo;

//						// Attach the device data.
//						//Add Item to List
//						deviceListView.Items.Add(item);
//					}
//				}



//				// Remove old camera devices that have been disconnected.
//				//Remove the non-existing camera from the camera list
//				foreach (ListViewItem item in items)
//				{
//					bool exists = false;

//					// For each camera in the list, check whether it can be found by enumeration.
//					foreach (ICameraInfo cameraInfo in allCameras)
//					{
//						if (((ICameraInfo)item.Tag)[CameraInfoKey.FullName] == cameraInfo[CameraInfoKey.FullName])
//						{
//							exists = true;
//							break;
//						}
//					}
//					// If the camera has not been found, remove it from the list view.
//					if (!exists)
//					{
//						deviceListView.Items.Remove(item);
//					}
//				}
//			}
//			catch (Exception exception)
//			{
//				ShowException(exception);
//			}
//		}


//		// Shows exceptions in a message box.
//		public void ShowException(Exception exception)
//		{
//			//When an error message occurs, a MessageBox pops up to prompt the error message
//			MessageBox.Show("Exception caught:\n" + exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//		}
//		// Occurs when a device with an opened connection is removed.
//		public void OnConnectionLost(Object sender, EventArgs e)
//		{
//			//if (InvokeRequired)
//			//{
//			//// If called from a different thread, we must use the Invoke method to marshal the call to the proper thread.
//			//BeginInvoke(new EventHandler<EventArgs>(OnConnectionLost), sender, e);
//			//return;
//			//}

//			// Close the camera object.
//			DestroyCamera();
//			// Because one device is gone, the list needs to be updated.
//			UpdateDeviceList();
//		}

//		public Form_Listener()
//        {
//            InitializeComponent();

//            // Set the default names for the controls.
//            //Set the name of each combination control
//            WhiteBalanceControl.Name = "Test Image Selector";
//            pixelFormatControl.Name = "Pixel Format";
//            widthSliderControl.Name = "Width";
//            heightSliderControl.Name = "Height";
//            gainSliderControl.Name = "Gain";
//            exposureTimeSliderControl.Name = "Exposure Time";

//			timer2.Start();

//			// Update the list of available camera devices in the upper left area.
//			//Update camera device information

//			UpdateDeviceList();

//			// Disable all buttons.
//			EnableButtons(false, false);

//			if (InvokeRequired) { };
//        }

//		// Helps to set the states of all buttons.
//		public void EnableButtons(bool canGrab, bool canStop)
//		{
//			toolStripButtonContinuousShot.Enabled = canGrab;
//			toolStripButtonOneShot.Enabled = canGrab;
//			toolStripButtonStop.Enabled = canStop;
//		}

//		// Occurs when the single frame acquisition button is clicked.
//		private void toolStripButtonOneShot_Click_1(object sender, EventArgs e)
//        {
//			OneShot(); // Start the grabbing of one image.
//            labelTemperature.Text = camera.Parameters[PLCamera.DeviceTemperature].GetValue().ToString();

//        }

//        private void Form1_Load(object sender, EventArgs e)
//        {
//            // Set the TcpListener on port 13000.


//            // TcpListener server = new TcpListener(port);
//            //server = new TcpListener(localAddr, port);
//        }
//		// Occurs when the continuous frame acquisition button is clicked.

//		private void toolStripButtonContinuousShot_Click_1(object sender, EventArgs e)
//		{
//			ContinuousShot(); // Start the grabbing of images until grabbing is stopped.

//		}

//		// Occurs when the stop frame acquisition button is clicked.
//		private void toolStripButtonStop_Click_1(object sender, EventArgs e)
//		{
//			Stop(); // Stop the grabbing of images.

//		}

//		// Closes the camera object when the window is closed.
//		private void MainForm_FormClosing(object sender, FormClosingEventArgs ev)
//		{
//			// Close the camera object.
//			//Turn off the camera and release the camera resources. This step is necessary. If the procedure is not executed by the shutdown program, the camera will be occupied
//			DestroyCamera();
//		}

//		// Occurs when a new camera has been selected in the list. Destroys the object of the currently opened camera device and
//		// creates a new object for the selected camera device. After that, the connection to the selected camera device is opened.
//		private void deviceListView_SelectedIndexChanged_1(object sender, EventArgs e)
//		{

//			// Destroy the old camera object.
//			if (camera != null)
//			{
//				DestroyCamera();
//			}

//			// Open the connection to the selected camera device.
//			//if (deviceListView.SelectedItems.Count > 0)
//			if (deviceListView.Items.Count > 0)
//			{
//				// Get the first selected item.
//				ListViewItem item = deviceListView.SelectedItems[0];
//				// Get the attached device data.
//				ICameraInfo selectedCamera = item.Tag as ICameraInfo;
//				try
//				{
//					// Create a new camera object.
//					camera = new Camera(selectedCamera);

//					camera.CameraOpened += Configuration.AcquireContinuous;


//					// Register for the events of the image provider needed for proper operation.
//					//Register the corresponding event handler function for the camera
//					camera.ConnectionLost += OnConnectionLost ;
//					camera.CameraOpened += OnCameraOpened;
//					camera.CameraClosed += OnCameraClosed;
//					camera.StreamGrabber.GrabStarted += OnGrabStarted;
//					camera.StreamGrabber.ImageGrabbed += OnImageGrabbed;//Acquisition image processing function, it will be triggered when the camera.StreamGrabber.Start function is called
//					camera.StreamGrabber.GrabStopped += OnGrabStopped;


//					// Open the connection to the camera device.
//					camera.Open();

//					// Set the parameter for the controls.
//					IEnumerable<string> BslLightSourcePresetValues = camera.Parameters[PLCamera.BslLightSourcePreset].GetAllValues();

//					foreach (string BslLightSourcePresetValue in BslLightSourcePresetValues)
//					{
//						WhiteBalanceControl.Items.Add(BslLightSourcePresetValue);
//					}

//					IEnumerable<string> PixelCodingValues = camera.Parameters[PLGigECamera.PixelFormat].GetAllValues();

//					foreach (string PixelCodingValue in PixelCodingValues)
//					{
//						pixelFormatControl.Items.Add(PixelCodingValue);
//					}



//					//WhiteBalanceControl.Items.Add(camera.Parameters[PLCamera.LightSourceSelector.GetValues()]);
//					//WhiteBalanceControl.Items.AddRange(camera.Parameters[PLGigECamera.LightSourceSelector], item);
//					//IEnumerable<string> LSValues = camera.Parameters[PLGigECamera.LightSourceSelector].GetAllValues();
//					//WhiteBalanceControl = camera.Parameters[PLGigECamera.].ToString();
//					//pixelFormatControl.Items.Add(camera.Parameters[PLCamera.PixelFormat].());

//					// WhiteBalanceControl.Items.Add(camera.Parameters[PLCamera.LightSourceSelectorEnum.Name]);

//					//var name = Enum.GetValues(typeof(PLGigECamera.LightSourceSelectorEnum));
//					//foreach (int i in Enum.GetValues(typeof(PLCamera.LightSourceSelectorEnum)))
//					//{
//					//	White += PLCamera.LightSourceSelector.ToString();
//					//}
//					//string name = nameof(camera.Parameters[PLCamera.LightSourceSelector.ToString]);
//					//camera.Parameters[PLCamera.DeviceTemperature]
//					//

//					//camera.Parameters.Contains[PLGigECamera.TemperatureAbs
//					//camera.Parameters.Contains[PLGigECamera.ResultingFrameRateAbs
//					//camera.Parameters.Contains[PLGigECamera.LightSourceSelector].GetValue());
//					//camera.Parameters.Contains[PLGigECamera.GevTimestampValue
//					//
//					//						camera.Parameters.Contains[PLGigECamera.GevTimestampTickFrequency
//					//
//					//camera.Parameters.Contains[PLGigECamera.GevLinkSpeed]
//					//
//					//
//					//long CameraWidth = camera.Parameters[PLCamera.Width].GetValue();
//					//widthSliderControl.Value = Convert.ToInt32(CameraWidth);

//					if (labelTemperature.Text == "")
//					{
//						labelTemperature.Text = camera.Parameters[PLCamera.DeviceTemperature].GetValue().ToString();
//					}

//					long CameraWidth = camera.Parameters[PLCamera.Width].GetValue();
//					widthSliderControl.Value = Convert.ToInt32(CameraWidth);

//					if (labelWidthValue.Text == "")
//					{
//						labelWidthValue.Text = Convert.ToString(widthSliderControl.Value);
//					}

//					long CameraHeight = camera.Parameters[PLCamera.Height].GetValue();
//					heightSliderControl.Value = Convert.ToInt32(CameraHeight);


//					if (labelCameraHeight.Text == "")
//					{
//						labelCameraHeight.Text = Convert.ToString(heightSliderControl.Value);
//					}

//					if (camera.Parameters.Contains(PLCamera.GainAbs))
//					{
//						double GainAbs = camera.Parameters[PLCamera.GainAbs].GetValue();
//						gainSliderControl.Value = Convert.ToInt32(GainAbs);
//						labelGainValue.Text = Convert.ToString(gainSliderControl.Value);
//					}
//					else
//					{
//						double Gain = camera.Parameters[PLCamera.Gain].GetValue();
//						gainSliderControl.Value = Convert.ToInt32(Gain);

//						if (labelGainValue.Text == "")
//						{
//							labelGainValue.Text = Convert.ToString(gainSliderControl.Value);
//						}

//					}
//					if (camera.Parameters.Contains(PLCamera.ExposureTimeAbs))
//					{
//						double ExposureTimeAbs = camera.Parameters[PLCamera.ExposureTimeAbs].GetValue();
//						exposureTimeSliderControl.Value = Convert.ToInt32(ExposureTimeAbs);

//						if (labelExposureValue.Text == "")
//						{
//							labelExposureValue.Text = Convert.ToString(exposureTimeSliderControl.Value);
//						}

//					}
//					else
//					{
//						double ExposureTime = camera.Parameters[PLCamera.ExposureTime].GetValue();
//						exposureTimeSliderControl.Value = Convert.ToInt32(ExposureTime);
//						labelExposureValue.Text = Convert.ToString(exposureTimeSliderControl.Value);
//					}
//				}
//				catch (Exception exception)
//				{
//					ShowException(exception);
//				}
//			}
//		}


//		// If the F5 key has been pressed, update the list of devices.
//		private void deviceListView_KeyDown(object sender, KeyEventArgs ev)
//		{
//			if (ev.KeyCode == Keys.F5)
//			{
//				ev.Handled = true;
//				// Update the list of available camera devices.
//				UpdateDeviceList();
//			}
//		}


//		// Timer callback used to periodically check whether displayed camera devices are still attached to the PC.
//		private void updateDeviceListTimer_Tick(object sender, EventArgs e)
//		{
//			UpdateDeviceList();
//		}

//		private void trackBar1_Scroll(object sender, EventArgs e)
//		{
//			step = Step_TrackBar.Value;
//			labelStepValue.Text = Convert.ToString(Step_TrackBar.Value);

//		}

//		private void exposureTimeSliderControl_Scroll(object sender, EventArgs e)
//		{
//			try
//			{
//				double a = camera.Parameters[PLCamera.ExposureTime].GetMinimum();
//				double b = camera.Parameters[PLCamera.ExposureTime].GetMaximum();
//				camera.Parameters[PLCamera.ExposureTime].SetValue(exposureTimeSliderControl.Value);
//				labelExposureValue.Text = Convert.ToString(exposureTimeSliderControl.Value);
//			}
//			catch (Exception exception)
//			{
//				ShowException(exception);
//			}


//		}

//		private void heightSliderControl_Scroll(object sender, EventArgs e)
//		{
//			try
//			{
//				long a = camera.Parameters[PLCamera.Height].GetMinimum();
//			long b = camera.Parameters[PLCamera.Height].GetMaximum();
//			camera.Parameters[PLCamera.Height].SetValue(heightSliderControl.Value);
//			labelCameraHeight.Text = Convert.ToString(heightSliderControl.Value);
//			}
//			catch (Exception exception)
//			{
//				ShowException(exception);
//			}
//		}

//		private void widthSliderControl_Scroll(object sender, EventArgs e)
//		{
//            try
//			{
//				long a = camera.Parameters[PLCamera.Width].GetMinimum();
//				long b = camera.Parameters[PLCamera.Width].GetMaximum();
//				camera.Parameters[PLCamera.Width].SetValue(widthSliderControl.Value);
//				labelWidthValue.Text = Convert.ToString(widthSliderControl.Value);
//			}
//			catch (Exception exception)
//			{
//				ShowException(exception);
//			}

//		}

//		private void gainSliderControl_Scroll(object sender, EventArgs e)
//		{
//			try
//			{
//				double a = camera.Parameters[PLCamera.Gain].GetMinimum();
//			double b = camera.Parameters[PLCamera.Gain].GetMaximum();
//			camera.Parameters[PLCamera.Gain].SetValue(gainSliderControl.Value);
//			labelGainValue.Text = Convert.ToString(gainSliderControl.Value);
//			}
//			catch (Exception exception)
//			{
//				ShowException(exception);
//			}

//		}



//		private void Form1_Click(object sender, EventArgs e)
//		{
//			UpdateDeviceList();

//		}

//		private void WhiteBalanceControl_SelectedIndexChanged(object sender, EventArgs e)
//		{
//			try
//			{
//				camera.Parameters[PLCamera.BslLightSourcePreset].SetValue(WhiteBalanceControl.SelectedItem.ToString());

//			}
//			catch (Exception exception)
//			{
//				ShowException(exception);
//			}
//		}

//		private void pixelFormatControl_SelectedIndexChanged(object sender, EventArgs e)
//		{

//		}

//		private void shot_Taking (int step, string PLC_position) 
//		{
//			int IntPosition = Int16.Parse(position);
//			int result1 = 0;
//			double rest = IntPosition % step;
//			if ( rest == 0)
//            {
//				OneShot();
//			}


//			//if (IntPosition >= 500 && IntPosition <= 540)
//			//{
//			//	out1 = "1";
//			//}
//			//else
//			//{
//			//	out1 = "0";
//			//}
//		}

//		public void PLC_Server()
//		{
//			Int32 port = Convert.ToInt32(txtPort.Text);
//			IPAddress localAddr = IPAddress.Parse(txtIPAdress.Text);
//			listener = new TcpListener(IPAddress.Any, port);
//			listener.Start();
//			try
//			{
//				TcpClient client = listener.AcceptTcpClient();
//				if (client.Connected)
//				{
//					txtEvents.Invoke((MethodInvoker)delegate { txtEvents.Text += "Client: " + client.Client.RemoteEndPoint.ToString() + Environment.NewLine; });
//				}

//				int i;

//				// Get a stream object for reading and writing
//				NetworkStream stream = client.GetStream();


//				byte[] data = new byte[512];


//				while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
//				{
				
//					int bytes = stream.Read(data, 0, data.Length); // get num of bytes in the message
				
//					// Translate data bytes to a ASCII string.
				
//					string message = System.Text.Encoding.UTF8.GetString(data, 0, bytes);

//					//byte[] data = PLC_Message;
//					string response = "777";
//					string year = System.Text.Encoding.UTF8.GetString(data, 0, 2);
//					string month = System.Text.Encoding.UTF8.GetString(data, 2, 2);
//					string day = System.Text.Encoding.UTF8.GetString(data, 4, 2);
//					string hour = System.Text.Encoding.UTF8.GetString(data, 6, 2);
//					string minute = System.Text.Encoding.UTF8.GetString(data, 8, 2);
//					string second = System.Text.Encoding.UTF8.GetString(data, 10, 2);
//					string milisecond = System.Text.Encoding.UTF8.GetString(data, 12, 3);
//					position = System.Text.Encoding.UTF8.GetString(data, 16, 3);



//					txtEvents.Invoke((MethodInvoker)delegate ()
//					{
//						txtMessages.Text = "";
//						txtMessages.Text += Environment.NewLine + "Year:" + year;
//						txtMessages.Text += Environment.NewLine + "month:" + month;
//						txtMessages.Text += Environment.NewLine + "day:" + day;
//						txtMessages.Text += Environment.NewLine + "hour:" + hour;
//						txtMessages.Text += Environment.NewLine + "minute:" + minute;
//						txtMessages.Text += Environment.NewLine + "second:" + second;
//						txtMessages.Text += Environment.NewLine + "milisecond:" + milisecond;
//						txtMessages.Text += Environment.NewLine + "position:" + position;

//						string respond = MotorSpeedSliderControl.Value.ToString() + "0" + out1 + "0" + out2;
//						byte[] msg = System.Text.Encoding.ASCII.GetBytes(respond);
//						stream.Write(msg, 0, msg.Length);
//						// Send back a response.
//						txtMessages.Text += Environment.NewLine + "sent:" + respond;
						
//					});


//				}

//				//return data;

//			}
//			catch (Exception ex)
//			{
//				MessageBox.Show("Error : " + ex.Message);
//				//return null;
//			}

//		}
//		//private void update_text(byte[] PLC_Message)
//		//{
//		//	byte[] data = PLC_Message;
//		//	//string response = "777";
//		//	string year = System.Text.Encoding.UTF8.GetString(data, 0, 2);
//		//	string month = System.Text.Encoding.UTF8.GetString(data, 2, 2);
//		//	string day = System.Text.Encoding.UTF8.GetString(data, 4, 2);
//		//	string hour = System.Text.Encoding.UTF8.GetString(data, 6, 2);
//		//	string minute = System.Text.Encoding.UTF8.GetString(data, 8, 2);
//		//	string second = System.Text.Encoding.UTF8.GetString(data, 10, 2);
//		//	string milisecond = System.Text.Encoding.UTF8.GetString(data, 12, 3);
//		//	string position = System.Text.Encoding.UTF8.GetString(data, 16, 3);
//		//
//		//
//		//
//		//	txtEvents.Invoke((MethodInvoker)delegate ()
//		//	{
//		//	txtMessages.Text = "";
//		//	txtMessages.Text += Environment.NewLine + "Year:" + year;
//		//	txtMessages.Text += Environment.NewLine + "month:" + month;
//		//	txtMessages.Text += Environment.NewLine + "day:" + day;
//		//	txtMessages.Text += Environment.NewLine + "hour:" + hour;
//		//	txtMessages.Text += Environment.NewLine + "minute:" + minute;
//		//	txtMessages.Text += Environment.NewLine + "second:" + second;
//		//	txtMessages.Text += Environment.NewLine + "milisecond:" + milisecond;
//		//	txtMessages.Text += Environment.NewLine + "position:" + position;
//		//
//		//	//string respond = MotorSpeedSliderControl.Value.ToString() + "0" + out1 + "0" + out2;
//		//	//byte[] msg = System.Text.Encoding.ASCII.GetBytes(respond);
//		//	////stream.Write(msg, 0, msg.Length);
//		//	//// Send back a response.
//		//	//txtMessages.Text += Environment.NewLine + "sent:" + respond;
//		//	});
//		//
//		//}

//		TcpListener server = null;
//		// Buffer for reading data
//		Byte[] bytes = new Byte[256];
//		String data = null;
//		String NewData = null;

//		private void btnStop_Click(object sender, EventArgs e)
//		{
//			listener.Stop();
//			txtEvents.Text += "Server down" + Environment.NewLine;
//		}

//		private void Message()
//		{

//		}

//		private void btnStart_Click(object sender, EventArgs e)
//		{
//			n_server = new Thread(new ThreadStart(PLC_Server));
//			n_server.IsBackground = true;
//			n_server.Start();

//			//byte[] From_PLC = new byte [512];
//			//Thread n_server = new Thread(() => { From_PLC = PLC_Server(); });
//			//n_server.IsBackground = true;
//			//n_server.Start();
//			//
//			//int bytes1 = From_PLC.Length; // get num of bytes in the message
//			//
//			//string message1 = System.Text.Encoding.UTF8.GetString(From_PLC, 0, bytes1);



//			//Form_Listener text = new 
		
//			//Thread n_update = new Thread(new ParameterizedThreadStart(update_text) );
		
//			//n_message = new Thread(new ThreadStart(Message));
//			//n_message.IsBackground = true;
//			//n_message.Start();

//			txtEvents.Text += "Server up" + Environment.NewLine;
//		}
		




//		private void check()
//		{
			
		
		
		
//				//var t = Task.Run(() => shot_Taking(step, position));
		
		
//				//n_shot = new Thread(() => shot_Taking(step, position));
//				//n_shot.IsBackground = true;
//				//n_shot.Start();
		
//				//BeginInvoke(new InvokeDelegate(shot_Taking(step, position)));
		
			
		
//		}

//        private void button1_Click(object sender, EventArgs e)
//        {
//			//try
//			//{
//			//	if (checkBoxAutoShot.Checked)
//			//	{
//			//		var t = Task.Run(() => shot_Taking(step, position));
//			//		
//			//
//			//		//n_shot = new Thread(() => shot_Taking(step, position));
//			//		//n_shot.IsBackground = true;
//			//		//n_shot.Start();
//			//
//			//	}
//			//	else
//			//	{
//			//		n_shot.Suspend();
//			//	}
//			//
//			//}
//			//catch (Exception ex)
//			//{
//			//	MessageBox.Show("Error : " + ex.Message);
//			//	//return null;
//			//}
//		}

//        private void timer2_Tick(object sender, EventArgs e)
//        {
//			if (checkBoxAutoShot.Checked)
//			{
//				n_shot = new Thread(() => shot_Taking(step, position));
//				n_shot.IsBackground = true;
//				n_shot.Start();
//			}
//		}
//	}
//}




       



       












//        //        while (true)
//        //        {
//        //            txtEvents.Invoke((MethodInvoker)delegate ()
//        //            {
//        //                txtEvents.Text += "Waiting for the connection... ";
//        //            });

//        //            // Perform a blocking call to accept requests.
//        //            // You could also use server.AcceptSocket() here.
//        //            TcpClient client = server.AcceptTcpClient();

//        //            txtEvents.Invoke((MethodInvoker)delegate ()
//        //            {
//        //                txtEvents.Text += "Connected!";
//        //            });

//        //            data = null;

//        //            // Get a stream object for reading and writing
//        //            NetworkStream stream = client.GetStream();

//        //            int i;


//        //            // Loop to receive all the data sent by the client.
//        //            while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
//        //            {
//        //                // Translate data bytes to a ASCII string.
//        //                data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);

//        //                txtEvents.Invoke((MethodInvoker)delegate ()
//        //                {
//        //                    txtEvents.Text += "Received: {0}" + data;
//        //                });

//        //                // Process the data sent by the client.
//        //                data = data.ToUpper();

//        //                byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);

//        //                // Send back a response.
//        //                stream.Write(msg, 0, msg.Length);

//        //                txtEvents.Invoke((MethodInvoker)delegate ()
//        //                {
//        //                    txtEvents.Text += "Sent: {0}" + data;
//        //                });
//        //            }

  


using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using Basler.Pylon;
using System.Windows.Forms;


namespace TCP_LISTENER_Delta
{
	public class MyBasler
	{
        // The number of camera connections
        public int CameraNumber = CameraFinder.Enumerate().Count();

        // delegate + event = callback function to pass the image captured by the camera
        public delegate void CameraImage(Bitmap bmp);
        public event CameraImage CameraImageEvent;

        // The pylon camera object.
        private Camera camera;

        // Grab statistical values.
        private int imageCount = 0;
        private int errorCount = 0;

        // Monitor object for managing concurrent thread access to latestFrame.
        private Object monitor = new Object();
        // Buffer for latest image.
        private Bitmap latestFrame = null;

        //basler is used to convert the image captured by the camera into a bitmap
        PixelDataConverter pxConvert = new PixelDataConverter();

        // Control the process of camera acquisition of images
        bool GrabOver = false;

        // These events forward the events of the camera object.
        public event EventHandler GuiCameraOpenedCamera;
        public event EventHandler GuiCameraClosedCamera;
        public event EventHandler GuiCameraGrabStarted;
        public event EventHandler GuiCameraGrabStopped;
        public event EventHandler GuiCameraConnectionToCameraLost;
        public event EventHandler GuiCameraFrameReadyForDisplay;


        // Camera initialization
        public void CameraInit(ICameraInfo selectedCamera)
        {
            camera = new Camera(selectedCamera);
            //Free running mode
            //camera.CameraOpened += Configuration.AcquireContinuous;


            // disconnect event
            camera.ConnectionLost += Camera_ConnectionLost;

            // Grab the start event
            //camera.StreamGrabber.GrabStarted += StreamGrabber_GrabStarted;

            // Grab the picture event
           // camera.StreamGrabber.ImageGrabbed += StreamGrabber_ImageGrabbed;

            // End the crawl event
            camera.StreamGrabber.GrabStopped += StreamGrabber_GrabStopped;


            camera.StreamGrabber.ImageGrabbed += OnImageGrabbed;


            // Set the acquisition mode to software triggered continuous acquisition when the camera is opened.
            camera.CameraOpened += Configuration.SoftwareTrigger;

            //turn on camera 
            camera.Open();


        }

        public void setTrigger(int i)
        {
            if (i == 0)
            {
                camera.Parameters[PLCamera.TriggerSource].SetValue(PLCamera.TriggerSource.Software);
            }
            else if (i == 1)
            {
                camera.Parameters[PLCamera.TriggerSource].SetValue(PLCamera.TriggerSource.Line1);
            }

        }



        public void StreamGrabber_GrabStarted(object sender, EventArgs e)
        {
            GrabOver = true;
        }
        public void StreamGrabber_ImageGrabbed(object sender, ImageGrabbedEventArgs e)
        {
            try
            {
                    IGrabResult grabResult = e.GrabResult;
                if (grabResult.IsValid)
                {
                    if (GrabOver)
                        CameraImageEvent(GrabResult2Bmp(grabResult));
            }
            }
            catch (Exception exception)
            {
                ShowException(exception);
            }
        }

        public void StreamGrabber_GrabStopped(object sender, GrabStopEventArgs e)
        {
            GrabOver = false;
        }

        public void Camera_ConnectionLost(object sender, EventArgs e)
        {
            camera.StreamGrabber.Stop();
            DestroyCamera();
        }

        public void GrabStart() 
        {
            camera.StreamGrabber.Start(GrabStrategy.OneByOne, GrabLoop.ProvidedByStreamGrabber);

        }

        public void SoftwareSignal()
        {
            try
            {
                // Execute the software trigger. Wait up to 1000 ms until the camera is ready for trigger.
                if (camera.WaitForFrameTriggerReady(1000, TimeoutHandling.ThrowException))
            {

                // Set a handler for processing the images.
                //camera.StreamGrabber.ImageGrabbed += OnImageGrabbed;

                // Start grabbing using the grab loop thread. This is done by setting the grabLoopType parameter
                // to GrabLoop.ProvidedByStreamGrabber. The grab results are delivered to the image event handler OnImageGrabbed.
                // The default grab strategy (GrabStrategy_OneByOne) is used.


                camera.ExecuteSoftwareTrigger();
            }
            }
            catch (Exception exception)
            {
                ShowException(exception);
            }

        }

        public void AcquisitionStart()
        {
            try
            {

                camera.Parameters[PLCamera.AcquisitionStart].Execute();
                while (camera.Parameters[PLCamera.AcquisitionStatus].GetValue() == true)
                {
                    //camera.StreamGrabber.GrabOne(10, );
                    camera.ExecuteSoftwareTrigger();
                    //camera.Parameters[PLCamera.TriggerSoftware].Execute();
                    camera.StreamGrabber.Stop();
                
                }
            }
            catch (Exception exception)
            {
                ShowException(exception);
            }
            //camera.Parameters.
            //camera.StreamGrabber.Start(1);
            //

 

        }

        public void AcquisitionStop()
        {
            //camera.Parameters[PLCamera.AcquisitionStop].Execute();
            camera.StreamGrabber.Stop();

        }
        // Starts the grabbing of a single image and handles exceptions.
        public void OneShot()
        {
            try
            {
                if (camera != null)
                {
                    // Starts the grabbing of one image.
                    camera.Parameters[PLCamera.AcquisitionMode].SetValue(PLCamera.AcquisitionMode.SingleFrame);

                   //// Select the Frame Start trigger
                   camera.Parameters[PLCamera.TriggerSelector].SetValue(PLCamera.TriggerSelector.FrameStart);
                   //// Enable triggered image acquisition for the Frame Start trigger
                   camera.Parameters[PLCamera.TriggerMode].SetValue(PLCamera.TriggerMode.On);
                   //
                   //// Set the trigger source to Line 1
                   camera.Parameters[PLCamera.TriggerSource].SetValue(PLCamera.TriggerSource.Software);
                    //camera.Parameters[PLCamera.SoftwareSignalSelector].SetValue(PLCamera.SoftwareSignalSelector.SoftwareSignal1);


                }
            }
            catch (Exception exception)
            {
                ShowException(exception);
            }
        }



        public void Stop()
        {
            try
            {
                if (camera != null)
                {
                    camera.StreamGrabber.Stop();
                }
            }
            catch (Exception exception)
            {
                ShowException(exception);
            }
        }

        // Convert the image captured by the camera into a Bitmap bitmap
        Bitmap GrabResult2Bmp(IGrabResult grabResult)
        {
            //using (Bitmap b = new Bitmap(grabResult.Width, grabResult.Height, PixelFormat.Format32bppRgb))
            //{
            Bitmap b = new Bitmap(grabResult.Width, grabResult.Height, PixelFormat.Format32bppRgb);
            BitmapData bmpData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, b.PixelFormat);
            pxConvert.OutputPixelFormat = PixelType.BGRA8packed;
            IntPtr bmpIntpr = bmpData.Scan0;
            pxConvert.Convert(bmpIntpr, bmpData.Stride * b.Height, grabResult);
            b.UnlockBits(bmpData);
            return b;
            //}
        }

        static void OnImageGrabbed(Object sender, ImageGrabbedEventArgs e)
        {
            // The grab result is automatically disposed when the event call back returns.
            // The grab result can be cloned using IGrabResult.Clone if you want to keep a copy of it (not shown in this sample).
            IGrabResult grabResult = e.GrabResult;
            // Image grabbed successfully?
            if (grabResult.GrabSucceeded)
            {
                // Access the image data.
                byte[] buffer = grabResult.PixelData as byte[];

                // Display the grabbed image.

                ImageWindow.DisplayImage(0, grabResult);
                //ImagePersistence.Save(ImageFileFormat.Bmp, "test.bmp", grabResult);
            }
            else
            {
                Console.WriteLine("Error: {0} {1}", grabResult.ErrorCode, grabResult.ErrorDescription);
            }
        }

        public string GetCameraData()
        {
            if (camera != null)
            {
                string fps = camera.Parameters[PLCamera.AcquisitionFrameRate].GetValue().ToString();

                return fps;
            }

            return "0";

        }


        // release the camera
        public void DestroyCamera()
        {
            try
            {
                if (camera != null)
                {
                    camera.Close();
                    camera.Dispose();
                    camera = null;
                }
            }
            catch (Exception exception)
            {
                ShowException(exception);
            }
        }

        // Shows exceptions in a message box.
        public void ShowException(Exception exception)
        {
            //When an error message occurs, a MessageBox pops up to prompt the error message
            MessageBox.Show("Exception caught:\n" + exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Getter for image count.
        public int ImageCount
        {
            get
            {
                return imageCount;
            }
        }

        // Getter for error count.
        public int ErrorCount
        {
            get
            {
                return errorCount;
            }
        }

        // Checks whether a camera is grabbing.
        public bool IsGrabbing
        {
            get
            {
                return IsOpen && camera.StreamGrabber.IsGrabbing;
            }
        }

        // Thread-safe getter for latest frame. Returns latest frame to display or null if no frame is present.
        public Bitmap GetLatestFrame()
        {
            lock (monitor)
            {
                if (latestFrame != null)
                {
                    Bitmap returnedBitmap = latestFrame;
                    latestFrame = null;
                    return returnedBitmap;
                }
                return null;
            }
        }

        // Checks whether a camera has been created.
        public bool IsCreated
        {
            get
            {
                return camera != null;
            }
        }

        // Checks whether a camera is open.
        public bool IsOpen
        {
            get
            {
                return IsCreated && camera.IsOpen;
            }
        }
    }
}
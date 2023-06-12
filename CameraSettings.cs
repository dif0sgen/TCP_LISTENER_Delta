using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Basler.Pylon;

namespace TCP_LISTENER_Delta
{
    public partial class CameraSettings : Form
    {
        public MyBasler myBasler = new MyBasler();

        public Camera camera = null;
        public CameraSettings()
        {
            InitializeComponent();

            // Set the default names for the controls.
            //Set the name of each combination control
            WhiteBalanceControl.Name = "Test Image Selector";
            pixelFormatControl.Name = "Pixel Format";
            widthSliderControl.Name = "Width";
            heightSliderControl.Name = "Height";
            gainSliderControl.Name = "Gain";
            exposureTimeSliderControl.Name = "Exposure Time";
        }

        private void CameraSettings_Load(object sender, EventArgs e)
        {

          // if (camera == null)
          // {
          //     // Get the first selected item.
          //     ListViewItem item = deviceListView.SelectedItems[0];
          //     // Get the attached device data.
          //     ICameraInfo selectedCamera = item.Tag as ICameraInfo;
          //
          //     myBasler.CameraInit(selectedCamera);
          //
          //     // Create a new camera object.
          //     camera = new Camera(selectedCamera);
          // }

    




        }


        private void heightSliderControl_Scroll(object sender, EventArgs e)
        {
            try
            {
                long a = camera.Parameters[PLCamera.Height].GetMinimum();
                long b = camera.Parameters[PLCamera.Height].GetMaximum();
                camera.Parameters[PLCamera.Height].SetValue(heightSliderControl.Value);
                labelCameraHeight.Text = Convert.ToString(heightSliderControl.Value);
            }
            catch (Exception exception)
            {
                myBasler.ShowException(exception);
            }
        }

        private void widthSliderControl_Scroll(object sender, EventArgs e)
        {
            try
            {
                long a = camera.Parameters[PLCamera.Width].GetMinimum();
                long b = camera.Parameters[PLCamera.Width].GetMaximum();
                camera.Parameters[PLCamera.Width].SetValue(widthSliderControl.Value);
                labelWidthValue.Text = Convert.ToString(widthSliderControl.Value);
            }
            catch (Exception exception)
            {
                myBasler.ShowException(exception);
            }

        }

        private void exposureTimeSliderControl_Scroll(object sender, EventArgs e)
        {
            try
            {
                double a = camera.Parameters[PLCamera.ExposureTime].GetMinimum();
                double b = camera.Parameters[PLCamera.ExposureTime].GetMaximum();
                camera.Parameters[PLCamera.ExposureTime].SetValue(exposureTimeSliderControl.Value);
                labelExposureValue.Text = Convert.ToString(exposureTimeSliderControl.Value);
            }
            catch (Exception exception)
            {
                myBasler.ShowException(exception);
            }


        }

        private void gainSliderControl_Scroll(object sender, EventArgs e)
        {
            try
            {
                double a = camera.Parameters[PLCamera.Gain].GetMinimum();
                double b = camera.Parameters[PLCamera.Gain].GetMaximum();
                camera.Parameters[PLCamera.Gain].SetValue(gainSliderControl.Value);
                labelGainValue.Text = Convert.ToString(gainSliderControl.Value);
            }
            catch (Exception exception)
            {
                myBasler.ShowException(exception);
            }

        }

        private void WhiteBalanceControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                camera.Parameters[PLCamera.BslLightSourcePreset].SetValue(WhiteBalanceControl.SelectedItem.ToString());

            }
            catch (Exception exception)
            {
                myBasler.ShowException(exception);
            }
        }

        private void pixelFormatControl_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

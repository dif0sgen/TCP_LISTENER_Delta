namespace TCP_LISTENER_Delta
{
    partial class CameraSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CameraSettings));
            this.labelExposute = new System.Windows.Forms.Label();
            this.labelWhiteBalance = new System.Windows.Forms.Label();
            this.labelWidthValue = new System.Windows.Forms.Label();
            this.labelExposureValue = new System.Windows.Forms.Label();
            this.labelCameraHeight = new System.Windows.Forms.Label();
            this.labelTemperature = new System.Windows.Forms.Label();
            this.labelTemp = new System.Windows.Forms.Label();
            this.labelExposure = new System.Windows.Forms.Label();
            this.labelHeight = new System.Windows.Forms.Label();
            this.labelWidth = new System.Windows.Forms.Label();
            this.exposureTimeSliderControl = new System.Windows.Forms.TrackBar();
            this.gainSliderControl = new System.Windows.Forms.TrackBar();
            this.heightSliderControl = new System.Windows.Forms.TrackBar();
            this.pixelFormatControl = new System.Windows.Forms.ComboBox();
            this.WhiteBalanceControl = new System.Windows.Forms.ComboBox();
            this.widthSliderControl = new System.Windows.Forms.TrackBar();
            this.labelGainValue = new System.Windows.Forms.Label();
            this.labelGain = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonContinuousShot = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonOneShot = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonStop = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.exposureTimeSliderControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gainSliderControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightSliderControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.widthSliderControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelExposute
            // 
            this.labelExposute.AutoSize = true;
            this.labelExposute.Location = new System.Drawing.Point(60, 73);
            this.labelExposute.Name = "labelExposute";
            this.labelExposute.Size = new System.Drawing.Size(64, 13);
            this.labelExposute.TabIndex = 58;
            this.labelExposute.Text = "Pixel Format";
            // 
            // labelWhiteBalance
            // 
            this.labelWhiteBalance.AutoSize = true;
            this.labelWhiteBalance.Location = new System.Drawing.Point(60, 25);
            this.labelWhiteBalance.Name = "labelWhiteBalance";
            this.labelWhiteBalance.Size = new System.Drawing.Size(77, 13);
            this.labelWhiteBalance.TabIndex = 57;
            this.labelWhiteBalance.Text = "White Balance";
            // 
            // labelWidthValue
            // 
            this.labelWidthValue.AutoSize = true;
            this.labelWidthValue.Location = new System.Drawing.Point(95, 128);
            this.labelWidthValue.Name = "labelWidthValue";
            this.labelWidthValue.Size = new System.Drawing.Size(13, 13);
            this.labelWidthValue.TabIndex = 56;
            this.labelWidthValue.Text = "0";
            // 
            // labelExposureValue
            // 
            this.labelExposureValue.AutoSize = true;
            this.labelExposureValue.Location = new System.Drawing.Point(95, 286);
            this.labelExposureValue.Name = "labelExposureValue";
            this.labelExposureValue.Size = new System.Drawing.Size(13, 13);
            this.labelExposureValue.TabIndex = 55;
            this.labelExposureValue.Text = "0";
            // 
            // labelCameraHeight
            // 
            this.labelCameraHeight.AutoSize = true;
            this.labelCameraHeight.Location = new System.Drawing.Point(95, 179);
            this.labelCameraHeight.Name = "labelCameraHeight";
            this.labelCameraHeight.Size = new System.Drawing.Size(13, 13);
            this.labelCameraHeight.TabIndex = 54;
            this.labelCameraHeight.Text = "0";
            // 
            // labelTemperature
            // 
            this.labelTemperature.AutoSize = true;
            this.labelTemperature.Location = new System.Drawing.Point(95, 350);
            this.labelTemperature.Name = "labelTemperature";
            this.labelTemperature.Size = new System.Drawing.Size(13, 13);
            this.labelTemperature.TabIndex = 53;
            this.labelTemperature.Text = "0";
            // 
            // labelTemp
            // 
            this.labelTemp.AutoSize = true;
            this.labelTemp.Location = new System.Drawing.Point(12, 350);
            this.labelTemp.Name = "labelTemp";
            this.labelTemp.Size = new System.Drawing.Size(67, 13);
            this.labelTemp.TabIndex = 52;
            this.labelTemp.Text = "Temperature";
            // 
            // labelExposure
            // 
            this.labelExposure.AutoSize = true;
            this.labelExposure.Location = new System.Drawing.Point(12, 286);
            this.labelExposure.Name = "labelExposure";
            this.labelExposure.Size = new System.Drawing.Size(77, 13);
            this.labelExposure.TabIndex = 51;
            this.labelExposure.Text = "Exposure Time";
            // 
            // labelHeight
            // 
            this.labelHeight.AutoSize = true;
            this.labelHeight.Location = new System.Drawing.Point(12, 179);
            this.labelHeight.Name = "labelHeight";
            this.labelHeight.Size = new System.Drawing.Size(38, 13);
            this.labelHeight.TabIndex = 50;
            this.labelHeight.Text = "Height";
            // 
            // labelWidth
            // 
            this.labelWidth.AutoSize = true;
            this.labelWidth.Location = new System.Drawing.Point(12, 128);
            this.labelWidth.Name = "labelWidth";
            this.labelWidth.Size = new System.Drawing.Size(35, 13);
            this.labelWidth.TabIndex = 49;
            this.labelWidth.Text = "Width";
            // 
            // exposureTimeSliderControl
            // 
            this.exposureTimeSliderControl.LargeChange = 950;
            this.exposureTimeSliderControl.Location = new System.Drawing.Point(12, 302);
            this.exposureTimeSliderControl.Maximum = 95000;
            this.exposureTimeSliderControl.Minimum = 19;
            this.exposureTimeSliderControl.Name = "exposureTimeSliderControl";
            this.exposureTimeSliderControl.Size = new System.Drawing.Size(202, 45);
            this.exposureTimeSliderControl.SmallChange = 475;
            this.exposureTimeSliderControl.TabIndex = 48;
            this.exposureTimeSliderControl.TickFrequency = 475;
            this.exposureTimeSliderControl.Value = 19;
            // 
            // gainSliderControl
            // 
            this.gainSliderControl.Location = new System.Drawing.Point(12, 246);
            this.gainSliderControl.Maximum = 48;
            this.gainSliderControl.Name = "gainSliderControl";
            this.gainSliderControl.Size = new System.Drawing.Size(202, 45);
            this.gainSliderControl.TabIndex = 47;
            // 
            // heightSliderControl
            // 
            this.heightSliderControl.LargeChange = 100;
            this.heightSliderControl.Location = new System.Drawing.Point(12, 195);
            this.heightSliderControl.Maximum = 1214;
            this.heightSliderControl.Minimum = 4;
            this.heightSliderControl.Name = "heightSliderControl";
            this.heightSliderControl.Size = new System.Drawing.Size(202, 45);
            this.heightSliderControl.SmallChange = 20;
            this.heightSliderControl.TabIndex = 46;
            this.heightSliderControl.TickFrequency = 20;
            this.heightSliderControl.Value = 4;
            // 
            // pixelFormatControl
            // 
            this.pixelFormatControl.FormattingEnabled = true;
            this.pixelFormatControl.Location = new System.Drawing.Point(12, 94);
            this.pixelFormatControl.Name = "pixelFormatControl";
            this.pixelFormatControl.Size = new System.Drawing.Size(202, 21);
            this.pixelFormatControl.TabIndex = 44;
            // 
            // WhiteBalanceControl
            // 
            this.WhiteBalanceControl.FormattingEnabled = true;
            this.WhiteBalanceControl.Location = new System.Drawing.Point(12, 41);
            this.WhiteBalanceControl.Name = "WhiteBalanceControl";
            this.WhiteBalanceControl.Size = new System.Drawing.Size(202, 21);
            this.WhiteBalanceControl.TabIndex = 43;
            // 
            // widthSliderControl
            // 
            this.widthSliderControl.LargeChange = 40;
            this.widthSliderControl.Location = new System.Drawing.Point(12, 144);
            this.widthSliderControl.Maximum = 1928;
            this.widthSliderControl.Minimum = 4;
            this.widthSliderControl.Name = "widthSliderControl";
            this.widthSliderControl.Size = new System.Drawing.Size(202, 45);
            this.widthSliderControl.SmallChange = 4;
            this.widthSliderControl.TabIndex = 45;
            this.widthSliderControl.TickFrequency = 4;
            this.widthSliderControl.Value = 4;
            // 
            // labelGainValue
            // 
            this.labelGainValue.AutoSize = true;
            this.labelGainValue.Location = new System.Drawing.Point(148, 188);
            this.labelGainValue.Name = "labelGainValue";
            this.labelGainValue.Size = new System.Drawing.Size(13, 13);
            this.labelGainValue.TabIndex = 60;
            this.labelGainValue.Text = "0";
            // 
            // labelGain
            // 
            this.labelGain.AutoSize = true;
            this.labelGain.Location = new System.Drawing.Point(65, 188);
            this.labelGain.Name = "labelGain";
            this.labelGain.Size = new System.Drawing.Size(29, 13);
            this.labelGain.TabIndex = 59;
            this.labelGain.Text = "Gain";
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(352, 130);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(834, 481);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 61;
            this.pictureBox.TabStop = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Right;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonContinuousShot,
            this.toolStripButtonOneShot,
            this.toolStripButtonStop});
            this.toolStrip1.Location = new System.Drawing.Point(1464, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(74, 740);
            this.toolStrip1.TabIndex = 62;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonContinuousShot
            // 
            this.toolStripButtonContinuousShot.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonContinuousShot.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonContinuousShot.Image")));
            this.toolStripButtonContinuousShot.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonContinuousShot.Name = "toolStripButtonContinuousShot";
            this.toolStripButtonContinuousShot.Size = new System.Drawing.Size(71, 19);
            this.toolStripButtonContinuousShot.Text = "Continuous";
            // 
            // toolStripButtonOneShot
            // 
            this.toolStripButtonOneShot.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonOneShot.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonOneShot.Image")));
            this.toolStripButtonOneShot.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonOneShot.Name = "toolStripButtonOneShot";
            this.toolStripButtonOneShot.Size = new System.Drawing.Size(71, 19);
            this.toolStripButtonOneShot.Text = "OneShot";
            // 
            // toolStripButtonStop
            // 
            this.toolStripButtonStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonStop.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonStop.Image")));
            this.toolStripButtonStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonStop.Name = "toolStripButtonStop";
            this.toolStripButtonStop.Size = new System.Drawing.Size(71, 19);
            this.toolStripButtonStop.Text = "Stop";
            // 
            // CameraSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1538, 740);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.labelGainValue);
            this.Controls.Add(this.labelGain);
            this.Controls.Add(this.labelExposute);
            this.Controls.Add(this.labelWhiteBalance);
            this.Controls.Add(this.labelWidthValue);
            this.Controls.Add(this.labelExposureValue);
            this.Controls.Add(this.labelCameraHeight);
            this.Controls.Add(this.labelTemperature);
            this.Controls.Add(this.labelTemp);
            this.Controls.Add(this.labelExposure);
            this.Controls.Add(this.labelHeight);
            this.Controls.Add(this.labelWidth);
            this.Controls.Add(this.exposureTimeSliderControl);
            this.Controls.Add(this.gainSliderControl);
            this.Controls.Add(this.heightSliderControl);
            this.Controls.Add(this.pixelFormatControl);
            this.Controls.Add(this.WhiteBalanceControl);
            this.Controls.Add(this.widthSliderControl);
            this.Name = "CameraSettings";
            this.Text = "CameraSettings";
            this.Load += new System.EventHandler(this.CameraSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.exposureTimeSliderControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gainSliderControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightSliderControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.widthSliderControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelExposute;
        private System.Windows.Forms.Label labelWhiteBalance;
        private System.Windows.Forms.Label labelWidthValue;
        private System.Windows.Forms.Label labelExposureValue;
        private System.Windows.Forms.Label labelCameraHeight;
        private System.Windows.Forms.Label labelTemperature;
        private System.Windows.Forms.Label labelTemp;
        private System.Windows.Forms.Label labelExposure;
        private System.Windows.Forms.Label labelHeight;
        private System.Windows.Forms.Label labelWidth;
        private System.Windows.Forms.TrackBar exposureTimeSliderControl;
        private System.Windows.Forms.TrackBar gainSliderControl;
        private System.Windows.Forms.TrackBar heightSliderControl;
        private System.Windows.Forms.ComboBox pixelFormatControl;
        private System.Windows.Forms.ComboBox WhiteBalanceControl;
        private System.Windows.Forms.TrackBar widthSliderControl;
        private System.Windows.Forms.Label labelGainValue;
        private System.Windows.Forms.Label labelGain;
        public System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonContinuousShot;
        private System.Windows.Forms.ToolStripButton toolStripButtonOneShot;
        private System.Windows.Forms.ToolStripButton toolStripButtonStop;
    }
}
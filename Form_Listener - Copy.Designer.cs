//namespace TCP_LISTENER_Delta
//{
//    partial class Form_Listener
//    {
//        /// <summary>
//        /// Required designer variable.
//        /// </summary>
//        private System.ComponentModel.IContainer components = null;

//        /// <summary>
//        /// Clean up any resources being used.
//        /// </summary>
//        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null))
//            {
//                components.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        #region Windows Form Designer generated code

//        /// <summary>
//        /// Required method for Designer support - do not modify
//        /// the contents of this method with the code editor.
//        /// </summary>
//        private void InitializeComponent()
//        {
//            this.components = new System.ComponentModel.Container();
//            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Listener));
//            this.btnStart = new System.Windows.Forms.Button();
//            this.lblPort = new System.Windows.Forms.Label();
//            this.txtPort = new System.Windows.Forms.TextBox();
//            this.txtIPAdress = new System.Windows.Forms.TextBox();
//            this.lblAdress = new System.Windows.Forms.Label();
//            this.lblEvents = new System.Windows.Forms.Label();
//            this.label1 = new System.Windows.Forms.Label();
//            this.txtEvents = new System.Windows.Forms.TextBox();
//            this.btnStop = new System.Windows.Forms.Button();
//            this.txtMessages = new System.Windows.Forms.TextBox();
//            this.MotorSpeedSliderControl = new System.Windows.Forms.TrackBar();
//            this.pictureBox = new System.Windows.Forms.PictureBox();
//            this.labelTemp = new System.Windows.Forms.Label();
//            this.labelExposure = new System.Windows.Forms.Label();
//            this.labelGain = new System.Windows.Forms.Label();
//            this.labelHeight = new System.Windows.Forms.Label();
//            this.deviceListView = new System.Windows.Forms.ListView();
//            this.labelWidth = new System.Windows.Forms.Label();
//            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
//            this.toolStripButtonContinuousShot = new System.Windows.Forms.ToolStripButton();
//            this.toolStripButtonOneShot = new System.Windows.Forms.ToolStripButton();
//            this.toolStripButtonStop = new System.Windows.Forms.ToolStripButton();
//            this.exposureTimeSliderControl = new System.Windows.Forms.TrackBar();
//            this.gainSliderControl = new System.Windows.Forms.TrackBar();
//            this.heightSliderControl = new System.Windows.Forms.TrackBar();
//            this.pixelFormatControl = new System.Windows.Forms.ComboBox();
//            this.WhiteBalanceControl = new System.Windows.Forms.ComboBox();
//            this.widthSliderControl = new System.Windows.Forms.TrackBar();
//            this.labelTemperature = new System.Windows.Forms.Label();
//            this.labelExposureValue = new System.Windows.Forms.Label();
//            this.labelGainValue = new System.Windows.Forms.Label();
//            this.labelCameraHeight = new System.Windows.Forms.Label();
//            this.labelWidthValue = new System.Windows.Forms.Label();
//            this.labelSpeed = new System.Windows.Forms.Label();
//            this.labelWhiteBalance = new System.Windows.Forms.Label();
//            this.labelExposute = new System.Windows.Forms.Label();
//            this.Step_TrackBar = new System.Windows.Forms.TrackBar();
//            this.labelStep = new System.Windows.Forms.Label();
//            this.labelStepValue = new System.Windows.Forms.Label();
//            this.button1 = new System.Windows.Forms.Button();
//            this.checkBoxAutoShot = new System.Windows.Forms.CheckBox();
//            this.timer2 = new System.Windows.Forms.Timer(this.components);
//            ((System.ComponentModel.ISupportInitialize)(this.MotorSpeedSliderControl)).BeginInit();
//            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
//            this.toolStrip1.SuspendLayout();
//            ((System.ComponentModel.ISupportInitialize)(this.exposureTimeSliderControl)).BeginInit();
//            ((System.ComponentModel.ISupportInitialize)(this.gainSliderControl)).BeginInit();
//            ((System.ComponentModel.ISupportInitialize)(this.heightSliderControl)).BeginInit();
//            ((System.ComponentModel.ISupportInitialize)(this.widthSliderControl)).BeginInit();
//            ((System.ComponentModel.ISupportInitialize)(this.Step_TrackBar)).BeginInit();
//            this.SuspendLayout();
//            // 
//            // btnStart
//            // 
//            this.btnStart.Location = new System.Drawing.Point(15, 25);
//            this.btnStart.Name = "btnStart";
//            this.btnStart.Size = new System.Drawing.Size(103, 23);
//            this.btnStart.TabIndex = 0;
//            this.btnStart.Text = "Start";
//            this.btnStart.UseVisualStyleBackColor = true;
//            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
//            // 
//            // lblPort
//            // 
//            this.lblPort.AutoSize = true;
//            this.lblPort.Location = new System.Drawing.Point(12, 57);
//            this.lblPort.Name = "lblPort";
//            this.lblPort.Size = new System.Drawing.Size(29, 13);
//            this.lblPort.TabIndex = 1;
//            this.lblPort.Text = "Port:";
//            // 
//            // txtPort
//            // 
//            this.txtPort.Location = new System.Drawing.Point(68, 54);
//            this.txtPort.Name = "txtPort";
//            this.txtPort.Size = new System.Drawing.Size(189, 20);
//            this.txtPort.TabIndex = 2;
//            this.txtPort.Text = "8910";
//            // 
//            // txtIPAdress
//            // 
//            this.txtIPAdress.Location = new System.Drawing.Point(68, 80);
//            this.txtIPAdress.Name = "txtIPAdress";
//            this.txtIPAdress.Size = new System.Drawing.Size(189, 20);
//            this.txtIPAdress.TabIndex = 4;
//            this.txtIPAdress.Text = "127.0.0.1";
//            // 
//            // lblAdress
//            // 
//            this.lblAdress.AutoSize = true;
//            this.lblAdress.Location = new System.Drawing.Point(12, 83);
//            this.lblAdress.Name = "lblAdress";
//            this.lblAdress.Size = new System.Drawing.Size(61, 13);
//            this.lblAdress.TabIndex = 3;
//            this.lblAdress.Text = "IP Address:";
//            // 
//            // lblEvents
//            // 
//            this.lblEvents.AutoSize = true;
//            this.lblEvents.Location = new System.Drawing.Point(112, 162);
//            this.lblEvents.Name = "lblEvents";
//            this.lblEvents.Size = new System.Drawing.Size(40, 13);
//            this.lblEvents.TabIndex = 5;
//            this.lblEvents.Text = "Events";
//            // 
//            // label1
//            // 
//            this.label1.AutoSize = true;
//            this.label1.Location = new System.Drawing.Point(97, 297);
//            this.label1.Name = "label1";
//            this.label1.Size = new System.Drawing.Size(55, 13);
//            this.label1.TabIndex = 6;
//            this.label1.Text = "Messages";
//            // 
//            // txtEvents
//            // 
//            this.txtEvents.Location = new System.Drawing.Point(15, 183);
//            this.txtEvents.Multiline = true;
//            this.txtEvents.Name = "txtEvents";
//            this.txtEvents.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
//            this.txtEvents.Size = new System.Drawing.Size(245, 95);
//            this.txtEvents.TabIndex = 7;
//            // 
//            // btnStop
//            // 
//            this.btnStop.Location = new System.Drawing.Point(154, 25);
//            this.btnStop.Name = "btnStop";
//            this.btnStop.Size = new System.Drawing.Size(103, 23);
//            this.btnStop.TabIndex = 8;
//            this.btnStop.Text = "Stop";
//            this.btnStop.UseVisualStyleBackColor = true;
//            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
//            // 
//            // txtMessages
//            // 
//            this.txtMessages.Location = new System.Drawing.Point(15, 324);
//            this.txtMessages.Multiline = true;
//            this.txtMessages.Name = "txtMessages";
//            this.txtMessages.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
//            this.txtMessages.Size = new System.Drawing.Size(244, 182);
//            this.txtMessages.TabIndex = 9;
//            // 
//            // MotorSpeedSliderControl
//            // 
//            this.MotorSpeedSliderControl.LargeChange = 100;
//            this.MotorSpeedSliderControl.Location = new System.Drawing.Point(15, 130);
//            this.MotorSpeedSliderControl.Maximum = 5000;
//            this.MotorSpeedSliderControl.Minimum = 1000;
//            this.MotorSpeedSliderControl.Name = "MotorSpeedSliderControl";
//            this.MotorSpeedSliderControl.Size = new System.Drawing.Size(245, 45);
//            this.MotorSpeedSliderControl.SmallChange = 100;
//            this.MotorSpeedSliderControl.TabIndex = 10;
//            this.MotorSpeedSliderControl.TickFrequency = 100;
//            this.MotorSpeedSliderControl.Value = 1000;
//            // 
//            // pictureBox
//            // 
//            this.pictureBox.Location = new System.Drawing.Point(500, 25);
//            this.pictureBox.Name = "pictureBox";
//            this.pictureBox.Size = new System.Drawing.Size(834, 481);
//            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
//            this.pictureBox.TabIndex = 15;
//            this.pictureBox.TabStop = false;
//            // 
//            // labelTemp
//            // 
//            this.labelTemp.AutoSize = true;
//            this.labelTemp.Location = new System.Drawing.Point(278, 439);
//            this.labelTemp.Name = "labelTemp";
//            this.labelTemp.Size = new System.Drawing.Size(67, 13);
//            this.labelTemp.TabIndex = 34;
//            this.labelTemp.Text = "Temperature";
//            // 
//            // labelExposure
//            // 
//            this.labelExposure.AutoSize = true;
//            this.labelExposure.Location = new System.Drawing.Point(278, 375);
//            this.labelExposure.Name = "labelExposure";
//            this.labelExposure.Size = new System.Drawing.Size(77, 13);
//            this.labelExposure.TabIndex = 33;
//            this.labelExposure.Text = "Exposure Time";
//            // 
//            // labelGain
//            // 
//            this.labelGain.AutoSize = true;
//            this.labelGain.Location = new System.Drawing.Point(278, 324);
//            this.labelGain.Name = "labelGain";
//            this.labelGain.Size = new System.Drawing.Size(29, 13);
//            this.labelGain.TabIndex = 32;
//            this.labelGain.Text = "Gain";
//            // 
//            // labelHeight
//            // 
//            this.labelHeight.AutoSize = true;
//            this.labelHeight.Location = new System.Drawing.Point(278, 268);
//            this.labelHeight.Name = "labelHeight";
//            this.labelHeight.Size = new System.Drawing.Size(38, 13);
//            this.labelHeight.TabIndex = 31;
//            this.labelHeight.Text = "Height";
//            // 
//            // deviceListView
//            // 
//            this.deviceListView.HideSelection = false;
//            this.deviceListView.Location = new System.Drawing.Point(278, 25);
//            this.deviceListView.Name = "deviceListView";
//            this.deviceListView.Size = new System.Drawing.Size(202, 75);
//            this.deviceListView.TabIndex = 30;
//            this.deviceListView.UseCompatibleStateImageBehavior = false;
//            this.deviceListView.View = System.Windows.Forms.View.List;
//            this.deviceListView.SelectedIndexChanged += new System.EventHandler(this.deviceListView_SelectedIndexChanged_1);
//            // 
//            // labelWidth
//            // 
//            this.labelWidth.AutoSize = true;
//            this.labelWidth.Location = new System.Drawing.Point(278, 217);
//            this.labelWidth.Name = "labelWidth";
//            this.labelWidth.Size = new System.Drawing.Size(35, 13);
//            this.labelWidth.TabIndex = 29;
//            this.labelWidth.Text = "Width";
//            // 
//            // toolStrip1
//            // 
//            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Right;
//            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
//            this.toolStripButtonContinuousShot,
//            this.toolStripButtonOneShot,
//            this.toolStripButtonStop});
//            this.toolStrip1.Location = new System.Drawing.Point(1337, 0);
//            this.toolStrip1.Name = "toolStrip1";
//            this.toolStrip1.Size = new System.Drawing.Size(74, 605);
//            this.toolStrip1.TabIndex = 28;
//            this.toolStrip1.Text = "toolStrip1";
//            // 
//            // toolStripButtonContinuousShot
//            // 
//            this.toolStripButtonContinuousShot.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
//            this.toolStripButtonContinuousShot.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonContinuousShot.Image")));
//            this.toolStripButtonContinuousShot.ImageTransparentColor = System.Drawing.Color.Magenta;
//            this.toolStripButtonContinuousShot.Name = "toolStripButtonContinuousShot";
//            this.toolStripButtonContinuousShot.Size = new System.Drawing.Size(71, 19);
//            this.toolStripButtonContinuousShot.Text = "Continuous";
//            this.toolStripButtonContinuousShot.Click += new System.EventHandler(this.toolStripButtonContinuousShot_Click_1);
//            // 
//            // toolStripButtonOneShot
//            // 
//            this.toolStripButtonOneShot.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
//            this.toolStripButtonOneShot.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonOneShot.Image")));
//            this.toolStripButtonOneShot.ImageTransparentColor = System.Drawing.Color.Magenta;
//            this.toolStripButtonOneShot.Name = "toolStripButtonOneShot";
//            this.toolStripButtonOneShot.Size = new System.Drawing.Size(71, 19);
//            this.toolStripButtonOneShot.Text = "OneShot";
//            this.toolStripButtonOneShot.Click += new System.EventHandler(this.toolStripButtonOneShot_Click_1);
//            // 
//            // toolStripButtonStop
//            // 
//            this.toolStripButtonStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
//            this.toolStripButtonStop.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonStop.Image")));
//            this.toolStripButtonStop.ImageTransparentColor = System.Drawing.Color.Magenta;
//            this.toolStripButtonStop.Name = "toolStripButtonStop";
//            this.toolStripButtonStop.Size = new System.Drawing.Size(71, 19);
//            this.toolStripButtonStop.Text = "Stop";
//            this.toolStripButtonStop.Click += new System.EventHandler(this.toolStripButtonStop_Click_1);
//            // 
//            // exposureTimeSliderControl
//            // 
//            this.exposureTimeSliderControl.LargeChange = 950;
//            this.exposureTimeSliderControl.Location = new System.Drawing.Point(278, 391);
//            this.exposureTimeSliderControl.Maximum = 95000;
//            this.exposureTimeSliderControl.Minimum = 19;
//            this.exposureTimeSliderControl.Name = "exposureTimeSliderControl";
//            this.exposureTimeSliderControl.Size = new System.Drawing.Size(202, 45);
//            this.exposureTimeSliderControl.SmallChange = 475;
//            this.exposureTimeSliderControl.TabIndex = 27;
//            this.exposureTimeSliderControl.TickFrequency = 475;
//            this.exposureTimeSliderControl.Value = 19;
//            this.exposureTimeSliderControl.Scroll += new System.EventHandler(this.exposureTimeSliderControl_Scroll);
//            // 
//            // gainSliderControl
//            // 
//            this.gainSliderControl.Location = new System.Drawing.Point(278, 335);
//            this.gainSliderControl.Maximum = 48;
//            this.gainSliderControl.Name = "gainSliderControl";
//            this.gainSliderControl.Size = new System.Drawing.Size(202, 45);
//            this.gainSliderControl.TabIndex = 26;
//            this.gainSliderControl.Scroll += new System.EventHandler(this.gainSliderControl_Scroll);
//            // 
//            // heightSliderControl
//            // 
//            this.heightSliderControl.LargeChange = 100;
//            this.heightSliderControl.Location = new System.Drawing.Point(278, 284);
//            this.heightSliderControl.Maximum = 1214;
//            this.heightSliderControl.Minimum = 4;
//            this.heightSliderControl.Name = "heightSliderControl";
//            this.heightSliderControl.Size = new System.Drawing.Size(202, 45);
//            this.heightSliderControl.SmallChange = 20;
//            this.heightSliderControl.TabIndex = 25;
//            this.heightSliderControl.TickFrequency = 20;
//            this.heightSliderControl.Value = 4;
//            this.heightSliderControl.Scroll += new System.EventHandler(this.heightSliderControl_Scroll);
//            // 
//            // pixelFormatControl
//            // 
//            this.pixelFormatControl.FormattingEnabled = true;
//            this.pixelFormatControl.Location = new System.Drawing.Point(278, 183);
//            this.pixelFormatControl.Name = "pixelFormatControl";
//            this.pixelFormatControl.Size = new System.Drawing.Size(202, 21);
//            this.pixelFormatControl.TabIndex = 23;
//            this.pixelFormatControl.SelectedIndexChanged += new System.EventHandler(this.pixelFormatControl_SelectedIndexChanged);
//            // 
//            // WhiteBalanceControl
//            // 
//            this.WhiteBalanceControl.FormattingEnabled = true;
//            this.WhiteBalanceControl.Location = new System.Drawing.Point(278, 130);
//            this.WhiteBalanceControl.Name = "WhiteBalanceControl";
//            this.WhiteBalanceControl.Size = new System.Drawing.Size(202, 21);
//            this.WhiteBalanceControl.TabIndex = 22;
//            this.WhiteBalanceControl.SelectedIndexChanged += new System.EventHandler(this.WhiteBalanceControl_SelectedIndexChanged);
//            // 
//            // widthSliderControl
//            // 
//            this.widthSliderControl.LargeChange = 40;
//            this.widthSliderControl.Location = new System.Drawing.Point(278, 233);
//            this.widthSliderControl.Maximum = 1928;
//            this.widthSliderControl.Minimum = 4;
//            this.widthSliderControl.Name = "widthSliderControl";
//            this.widthSliderControl.Size = new System.Drawing.Size(202, 45);
//            this.widthSliderControl.SmallChange = 4;
//            this.widthSliderControl.TabIndex = 24;
//            this.widthSliderControl.TickFrequency = 4;
//            this.widthSliderControl.Value = 4;
//            this.widthSliderControl.Scroll += new System.EventHandler(this.widthSliderControl_Scroll);
//            // 
//            // labelTemperature
//            // 
//            this.labelTemperature.AutoSize = true;
//            this.labelTemperature.Location = new System.Drawing.Point(361, 439);
//            this.labelTemperature.Name = "labelTemperature";
//            this.labelTemperature.Size = new System.Drawing.Size(13, 13);
//            this.labelTemperature.TabIndex = 35;
//            this.labelTemperature.Text = "0";
//            // 
//            // labelExposureValue
//            // 
//            this.labelExposureValue.AutoSize = true;
//            this.labelExposureValue.Location = new System.Drawing.Point(361, 375);
//            this.labelExposureValue.Name = "labelExposureValue";
//            this.labelExposureValue.Size = new System.Drawing.Size(13, 13);
//            this.labelExposureValue.TabIndex = 38;
//            this.labelExposureValue.Text = "0";
//            // 
//            // labelGainValue
//            // 
//            this.labelGainValue.AutoSize = true;
//            this.labelGainValue.Location = new System.Drawing.Point(361, 324);
//            this.labelGainValue.Name = "labelGainValue";
//            this.labelGainValue.Size = new System.Drawing.Size(13, 13);
//            this.labelGainValue.TabIndex = 37;
//            this.labelGainValue.Text = "0";
//            // 
//            // labelCameraHeight
//            // 
//            this.labelCameraHeight.AutoSize = true;
//            this.labelCameraHeight.Location = new System.Drawing.Point(361, 268);
//            this.labelCameraHeight.Name = "labelCameraHeight";
//            this.labelCameraHeight.Size = new System.Drawing.Size(13, 13);
//            this.labelCameraHeight.TabIndex = 36;
//            this.labelCameraHeight.Text = "0";
//            // 
//            // labelWidthValue
//            // 
//            this.labelWidthValue.AutoSize = true;
//            this.labelWidthValue.Location = new System.Drawing.Point(361, 217);
//            this.labelWidthValue.Name = "labelWidthValue";
//            this.labelWidthValue.Size = new System.Drawing.Size(13, 13);
//            this.labelWidthValue.TabIndex = 39;
//            this.labelWidthValue.Text = "0";
//            // 
//            // labelSpeed
//            // 
//            this.labelSpeed.AutoSize = true;
//            this.labelSpeed.Location = new System.Drawing.Point(97, 114);
//            this.labelSpeed.Name = "labelSpeed";
//            this.labelSpeed.Size = new System.Drawing.Size(68, 13);
//            this.labelSpeed.TabIndex = 40;
//            this.labelSpeed.Text = "Motor Speed";
//            // 
//            // labelWhiteBalance
//            // 
//            this.labelWhiteBalance.AutoSize = true;
//            this.labelWhiteBalance.Location = new System.Drawing.Point(326, 114);
//            this.labelWhiteBalance.Name = "labelWhiteBalance";
//            this.labelWhiteBalance.Size = new System.Drawing.Size(77, 13);
//            this.labelWhiteBalance.TabIndex = 41;
//            this.labelWhiteBalance.Text = "White Balance";
//            // 
//            // labelExposute
//            // 
//            this.labelExposute.AutoSize = true;
//            this.labelExposute.Location = new System.Drawing.Point(326, 162);
//            this.labelExposute.Name = "labelExposute";
//            this.labelExposute.Size = new System.Drawing.Size(64, 13);
//            this.labelExposute.TabIndex = 42;
//            this.labelExposute.Text = "Pixel Format";
//            // 
//            // Step_TrackBar
//            // 
//            this.Step_TrackBar.LargeChange = 1;
//            this.Step_TrackBar.Location = new System.Drawing.Point(278, 483);
//            this.Step_TrackBar.Maximum = 60;
//            this.Step_TrackBar.Minimum = 25;
//            this.Step_TrackBar.Name = "Step_TrackBar";
//            this.Step_TrackBar.Size = new System.Drawing.Size(202, 45);
//            this.Step_TrackBar.TabIndex = 43;
//            this.Step_TrackBar.Value = 40;
//            this.Step_TrackBar.Scroll += new System.EventHandler(this.trackBar1_Scroll);
//            // 
//            // labelStep
//            // 
//            this.labelStep.AutoSize = true;
//            this.labelStep.Location = new System.Drawing.Point(278, 467);
//            this.labelStep.Name = "labelStep";
//            this.labelStep.Size = new System.Drawing.Size(29, 13);
//            this.labelStep.TabIndex = 44;
//            this.labelStep.Text = "Step";
//            // 
//            // labelStepValue
//            // 
//            this.labelStepValue.AutoSize = true;
//            this.labelStepValue.Location = new System.Drawing.Point(361, 467);
//            this.labelStepValue.Name = "labelStepValue";
//            this.labelStepValue.Size = new System.Drawing.Size(13, 13);
//            this.labelStepValue.TabIndex = 45;
//            this.labelStepValue.Text = "0";
//            // 
//            // button1
//            // 
//            this.button1.Location = new System.Drawing.Point(142, 542);
//            this.button1.Name = "button1";
//            this.button1.Size = new System.Drawing.Size(103, 23);
//            this.button1.TabIndex = 47;
//            this.button1.Text = "Start";
//            this.button1.UseVisualStyleBackColor = true;
//            // 
//            // checkBoxAutoShot
//            // 
//            this.checkBoxAutoShot.AutoSize = true;
//            this.checkBoxAutoShot.Location = new System.Drawing.Point(38, 542);
//            this.checkBoxAutoShot.Name = "checkBoxAutoShot";
//            this.checkBoxAutoShot.Size = new System.Drawing.Size(70, 17);
//            this.checkBoxAutoShot.TabIndex = 46;
//            this.checkBoxAutoShot.Text = "AutoShot";
//            this.checkBoxAutoShot.UseVisualStyleBackColor = true;
//            // 
//            // timer2
//            // 
//            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
//            // 
//            // Form_Listener
//            // 
//            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.BackColor = System.Drawing.Color.WhiteSmoke;
//            this.ClientSize = new System.Drawing.Size(1411, 605);
//            this.Controls.Add(this.button1);
//            this.Controls.Add(this.checkBoxAutoShot);
//            this.Controls.Add(this.labelStepValue);
//            this.Controls.Add(this.labelStep);
//            this.Controls.Add(this.Step_TrackBar);
//            this.Controls.Add(this.labelExposute);
//            this.Controls.Add(this.labelWhiteBalance);
//            this.Controls.Add(this.labelSpeed);
//            this.Controls.Add(this.labelWidthValue);
//            this.Controls.Add(this.labelExposureValue);
//            this.Controls.Add(this.labelGainValue);
//            this.Controls.Add(this.labelCameraHeight);
//            this.Controls.Add(this.labelTemperature);
//            this.Controls.Add(this.txtMessages);
//            this.Controls.Add(this.txtEvents);
//            this.Controls.Add(this.label1);
//            this.Controls.Add(this.lblEvents);
//            this.Controls.Add(this.labelTemp);
//            this.Controls.Add(this.labelExposure);
//            this.Controls.Add(this.labelGain);
//            this.Controls.Add(this.labelHeight);
//            this.Controls.Add(this.deviceListView);
//            this.Controls.Add(this.labelWidth);
//            this.Controls.Add(this.toolStrip1);
//            this.Controls.Add(this.exposureTimeSliderControl);
//            this.Controls.Add(this.gainSliderControl);
//            this.Controls.Add(this.heightSliderControl);
//            this.Controls.Add(this.pixelFormatControl);
//            this.Controls.Add(this.WhiteBalanceControl);
//            this.Controls.Add(this.widthSliderControl);
//            this.Controls.Add(this.pictureBox);
//            this.Controls.Add(this.MotorSpeedSliderControl);
//            this.Controls.Add(this.btnStop);
//            this.Controls.Add(this.txtIPAdress);
//            this.Controls.Add(this.lblAdress);
//            this.Controls.Add(this.txtPort);
//            this.Controls.Add(this.lblPort);
//            this.Controls.Add(this.btnStart);
//            this.Name = "Form_Listener";
//            this.Text = "Form1";
//            this.Load += new System.EventHandler(this.Form1_Load);
//            ((System.ComponentModel.ISupportInitialize)(this.MotorSpeedSliderControl)).EndInit();
//            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
//            this.toolStrip1.ResumeLayout(false);
//            this.toolStrip1.PerformLayout();
//            ((System.ComponentModel.ISupportInitialize)(this.exposureTimeSliderControl)).EndInit();
//            ((System.ComponentModel.ISupportInitialize)(this.gainSliderControl)).EndInit();
//            ((System.ComponentModel.ISupportInitialize)(this.heightSliderControl)).EndInit();
//            ((System.ComponentModel.ISupportInitialize)(this.widthSliderControl)).EndInit();
//            ((System.ComponentModel.ISupportInitialize)(this.Step_TrackBar)).EndInit();
//            this.ResumeLayout(false);
//            this.PerformLayout();

//        }

//        #endregion

//        private System.Windows.Forms.Button btnStart;
//        private System.Windows.Forms.Label lblPort;
//        private System.Windows.Forms.TextBox txtPort;
//        private System.Windows.Forms.TextBox txtIPAdress;
//        private System.Windows.Forms.Label lblAdress;
//        private System.Windows.Forms.Label lblEvents;
//        private System.Windows.Forms.Label label1;
//        private System.Windows.Forms.TextBox txtEvents;
//        private System.Windows.Forms.Button btnStop;
//        private System.Windows.Forms.TextBox txtMessages;
//        private System.Windows.Forms.TrackBar MotorSpeedSliderControl;
//        private System.Windows.Forms.PictureBox pictureBox;
//        private System.Windows.Forms.Label labelTemp;
//        private System.Windows.Forms.Label labelExposure;
//        private System.Windows.Forms.Label labelGain;
//        private System.Windows.Forms.Label labelHeight;
//        private System.Windows.Forms.ListView deviceListView;
//        private System.Windows.Forms.Label labelWidth;
//        private System.Windows.Forms.ToolStrip toolStrip1;
//        private System.Windows.Forms.ToolStripButton toolStripButtonContinuousShot;
//        private System.Windows.Forms.ToolStripButton toolStripButtonOneShot;
//        private System.Windows.Forms.ToolStripButton toolStripButtonStop;
//        private System.Windows.Forms.TrackBar exposureTimeSliderControl;
//        private System.Windows.Forms.TrackBar gainSliderControl;
//        private System.Windows.Forms.TrackBar heightSliderControl;
//        private System.Windows.Forms.ComboBox pixelFormatControl;
//        private System.Windows.Forms.ComboBox WhiteBalanceControl;
//        private System.Windows.Forms.TrackBar widthSliderControl;
//        private System.Windows.Forms.Label labelTemperature;
//        private System.Windows.Forms.Label labelExposureValue;
//        private System.Windows.Forms.Label labelGainValue;
//        private System.Windows.Forms.Label labelCameraHeight;
//        private System.Windows.Forms.Label labelWidthValue;
//        private System.Windows.Forms.Label labelSpeed;
//        private System.Windows.Forms.Label labelWhiteBalance;
//        private System.Windows.Forms.Label labelExposute;
//        private System.Windows.Forms.TrackBar Step_TrackBar;
//        private System.Windows.Forms.Label labelStep;
//        private System.Windows.Forms.Label labelStepValue;
//        private System.Windows.Forms.Button button1;
//        private System.Windows.Forms.CheckBox checkBoxAutoShot;
//        private System.Windows.Forms.Timer timer2;
//    }
//}


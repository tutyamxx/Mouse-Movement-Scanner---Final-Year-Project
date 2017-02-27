namespace MouseMovementScanner
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ScannerTimer = new System.Windows.Forms.Timer(this.components);
            this.btn_StartScanner = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.chkBox_Startup = new System.Windows.Forms.CheckBox();
            this.chkBox_Alert = new System.Windows.Forms.CheckBox();
            this.chkBox_Lock = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkBox_Idle = new System.Windows.Forms.CheckBox();
            this.chkBox_StartMin = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox_StartSelection = new System.Windows.Forms.ComboBox();
            this.btn_ForceStop = new System.Windows.Forms.Button();
            this.grpBox_AutoStartTime = new System.Windows.Forms.GroupBox();
            this.comboBox_IdleTime = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkBox_Keyboard = new System.Windows.Forms.CheckBox();
            this.chckBox_Mouse = new System.Windows.Forms.CheckBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.pictureBox2_Scanner = new System.Windows.Forms.PictureBox();
            this.IdleChekTimer = new System.Windows.Forms.Timer(this.components);
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grpBox_AutoStartTime.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2_Scanner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // ScannerTimer
            // 
            this.ScannerTimer.Interval = 1000;
            this.ScannerTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btn_StartScanner
            // 
            this.btn_StartScanner.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_StartScanner.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_StartScanner.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_StartScanner.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_StartScanner.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_StartScanner.Location = new System.Drawing.Point(19, 374);
            this.btn_StartScanner.Name = "btn_StartScanner";
            this.btn_StartScanner.Size = new System.Drawing.Size(157, 43);
            this.btn_StartScanner.TabIndex = 0;
            this.btn_StartScanner.Text = "Start Scanner";
            this.toolTip.SetToolTip(this.btn_StartScanner, "Start Mouse Scanner Application");
            this.btn_StartScanner.UseVisualStyleBackColor = false;
            this.btn_StartScanner.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::MouseMovementScanner.Properties.Resources.mousemovement;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(133, 97);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.toolTip.SetToolTip(this.pictureBox1, "Click to find out more!");
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // chkBox_Startup
            // 
            this.chkBox_Startup.AutoSize = true;
            this.chkBox_Startup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBox_Startup.Location = new System.Drawing.Point(7, 19);
            this.chkBox_Startup.Name = "chkBox_Startup";
            this.chkBox_Startup.Size = new System.Drawing.Size(167, 17);
            this.chkBox_Startup.TabIndex = 2;
            this.chkBox_Startup.Text = "Run on Windows Startup";
            this.toolTip.SetToolTip(this.chkBox_Startup, "Run the program when Windows Starts");
            this.chkBox_Startup.UseVisualStyleBackColor = true;
            this.chkBox_Startup.CheckedChanged += new System.EventHandler(this.chkBox_Startup_CheckedChanged);
            // 
            // chkBox_Alert
            // 
            this.chkBox_Alert.AutoSize = true;
            this.chkBox_Alert.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBox_Alert.Location = new System.Drawing.Point(7, 65);
            this.chkBox_Alert.Name = "chkBox_Alert";
            this.chkBox_Alert.Size = new System.Drawing.Size(163, 17);
            this.chkBox_Alert.TabIndex = 3;
            this.chkBox_Alert.Text = "Play sound on detection";
            this.toolTip.SetToolTip(this.chkBox_Alert, "Play a sound on movement detection (quite loud)");
            this.chkBox_Alert.UseVisualStyleBackColor = true;
            // 
            // chkBox_Lock
            // 
            this.chkBox_Lock.AutoSize = true;
            this.chkBox_Lock.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBox_Lock.Location = new System.Drawing.Point(6, 88);
            this.chkBox_Lock.Name = "chkBox_Lock";
            this.chkBox_Lock.Size = new System.Drawing.Size(245, 17);
            this.chkBox_Lock.TabIndex = 4;
            this.chkBox_Lock.Text = "Lock Windows on movement detection";
            this.toolTip.SetToolTip(this.chkBox_Lock, "Locks the Workstation on movement detection");
            this.chkBox_Lock.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(320, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(28, 25);
            this.button2.TabIndex = 5;
            this.button2.Text = "_";
            this.toolTip.SetToolTip(this.button2, "Minimise application to system tray");
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.OrangeRed;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(354, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(27, 25);
            this.button3.TabIndex = 6;
            this.button3.Text = "X";
            this.toolTip.SetToolTip(this.button3, "Close application");
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // toolTip
            // 
            this.toolTip.IsBalloon = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkBox_Idle);
            this.groupBox1.Controls.Add(this.chkBox_StartMin);
            this.groupBox1.Controls.Add(this.chkBox_Startup);
            this.groupBox1.Controls.Add(this.chkBox_Lock);
            this.groupBox1.Controls.Add(this.chkBox_Alert);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(12, 150);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(256, 140);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            this.toolTip.SetToolTip(this.groupBox1, "Configure application settings");
            // 
            // chkBox_Idle
            // 
            this.chkBox_Idle.AutoSize = true;
            this.chkBox_Idle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBox_Idle.Location = new System.Drawing.Point(7, 111);
            this.chkBox_Idle.Name = "chkBox_Idle";
            this.chkBox_Idle.Size = new System.Drawing.Size(173, 17);
            this.chkBox_Idle.TabIndex = 6;
            this.chkBox_Idle.Text = "Auto-Start if system is idle";
            this.toolTip.SetToolTip(this.chkBox_Idle, "Auto-Start the scanner if program detects that system is idle (not used)");
            this.chkBox_Idle.UseVisualStyleBackColor = true;
            this.chkBox_Idle.CheckedChanged += new System.EventHandler(this.chkBox_Idle_CheckedChanged);
            // 
            // chkBox_StartMin
            // 
            this.chkBox_StartMin.AutoSize = true;
            this.chkBox_StartMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBox_StartMin.Location = new System.Drawing.Point(7, 42);
            this.chkBox_StartMin.Name = "chkBox_StartMin";
            this.chkBox_StartMin.Size = new System.Drawing.Size(112, 17);
            this.chkBox_StartMin.TabIndex = 5;
            this.chkBox_StartMin.Text = "Start Minimized";
            this.toolTip.SetToolTip(this.chkBox_StartMin, "Starts Minimized to Windows Tray");
            this.chkBox_StartMin.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox_StartSelection);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 303);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(170, 54);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Scanner Start Delay";
            this.toolTip.SetToolTip(this.groupBox2, "Select the time delay for Scanner to start after pressing \"Start Scanner\"");
            // 
            // comboBox_StartSelection
            // 
            this.comboBox_StartSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_StartSelection.Items.AddRange(new object[] {
            "Instant Start (Not Recommended)",
            "5 Seconds",
            "15 Seconds",
            "30 seconds",
            "1 Minute",
            "5 Minutes",
            "10 Minutes",
            "20 Minutes"});
            this.comboBox_StartSelection.Location = new System.Drawing.Point(7, 19);
            this.comboBox_StartSelection.Name = "comboBox_StartSelection";
            this.comboBox_StartSelection.Size = new System.Drawing.Size(157, 23);
            this.comboBox_StartSelection.TabIndex = 0;
            this.comboBox_StartSelection.SelectedIndexChanged += new System.EventHandler(this.comboBox_StartSelection_SelectedIndexChanged);
            // 
            // btn_ForceStop
            // 
            this.btn_ForceStop.BackColor = System.Drawing.Color.OrangeRed;
            this.btn_ForceStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ForceStop.Location = new System.Drawing.Point(217, 374);
            this.btn_ForceStop.Name = "btn_ForceStop";
            this.btn_ForceStop.Size = new System.Drawing.Size(158, 43);
            this.btn_ForceStop.TabIndex = 10;
            this.btn_ForceStop.Text = "Stop Scanner";
            this.toolTip.SetToolTip(this.btn_ForceStop, "Stop the current Scanner");
            this.btn_ForceStop.UseVisualStyleBackColor = false;
            this.btn_ForceStop.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // grpBox_AutoStartTime
            // 
            this.grpBox_AutoStartTime.Controls.Add(this.comboBox_IdleTime);
            this.grpBox_AutoStartTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBox_AutoStartTime.Location = new System.Drawing.Point(211, 303);
            this.grpBox_AutoStartTime.Name = "grpBox_AutoStartTime";
            this.grpBox_AutoStartTime.Size = new System.Drawing.Size(170, 54);
            this.grpBox_AutoStartTime.TabIndex = 11;
            this.grpBox_AutoStartTime.TabStop = false;
            this.grpBox_AutoStartTime.Text = "Idle Control";
            this.toolTip.SetToolTip(this.grpBox_AutoStartTime, "Select after how many minutes you want the scanner to check if the system is idle" +
        "");
            // 
            // comboBox_IdleTime
            // 
            this.comboBox_IdleTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_IdleTime.Items.AddRange(new object[] {
            "1 Minute",
            "5 Minutes",
            "10 Minutes",
            "15 Minutes",
            "20 Minutes",
            "30 Minutes",
            "1 Hour",
            "2 Hours",
            "5 Hours"});
            this.comboBox_IdleTime.Location = new System.Drawing.Point(6, 19);
            this.comboBox_IdleTime.Name = "comboBox_IdleTime";
            this.comboBox_IdleTime.Size = new System.Drawing.Size(158, 23);
            this.comboBox_IdleTime.TabIndex = 0;
            this.comboBox_IdleTime.SelectedIndexChanged += new System.EventHandler(this.comboBox_IdleTime_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkBox_Keyboard);
            this.groupBox3.Controls.Add(this.chckBox_Mouse);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(274, 216);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(107, 74);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Device Detection";
            this.toolTip.SetToolTip(this.groupBox3, "Select what device movement should Scanner detect");
            // 
            // chkBox_Keyboard
            // 
            this.chkBox_Keyboard.AutoSize = true;
            this.chkBox_Keyboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBox_Keyboard.Location = new System.Drawing.Point(11, 46);
            this.chkBox_Keyboard.Name = "chkBox_Keyboard";
            this.chkBox_Keyboard.Size = new System.Drawing.Size(79, 17);
            this.chkBox_Keyboard.TabIndex = 1;
            this.chkBox_Keyboard.Text = "Keyboard";
            this.toolTip.SetToolTip(this.chkBox_Keyboard, "Select this if you want Keyboard detection");
            this.chkBox_Keyboard.UseVisualStyleBackColor = true;
            this.chkBox_Keyboard.CheckedChanged += new System.EventHandler(this.chkBox_Keyboard_CheckedChanged);
            // 
            // chckBox_Mouse
            // 
            this.chckBox_Mouse.AutoSize = true;
            this.chckBox_Mouse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chckBox_Mouse.Location = new System.Drawing.Point(11, 23);
            this.chckBox_Mouse.Name = "chckBox_Mouse";
            this.chckBox_Mouse.Size = new System.Drawing.Size(63, 17);
            this.chckBox_Mouse.TabIndex = 0;
            this.chckBox_Mouse.Text = "Mouse";
            this.toolTip.SetToolTip(this.chckBox_Mouse, "Select this if you want Mouse detection");
            this.chckBox_Mouse.UseVisualStyleBackColor = true;
            this.chckBox_Mouse.CheckedChanged += new System.EventHandler(this.chckBox_Mouse_CheckedChanged);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "Running on background";
            this.notifyIcon1.BalloonTipTitle = "Mouse Movement Scanner";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Mouse Movement Scanner";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // pictureBox2_Scanner
            // 
            this.pictureBox2_Scanner.Image = global::MouseMovementScanner.Properties.Resources.Radar2;
            this.pictureBox2_Scanner.Location = new System.Drawing.Point(274, 108);
            this.pictureBox2_Scanner.Name = "pictureBox2_Scanner";
            this.pictureBox2_Scanner.Size = new System.Drawing.Size(107, 101);
            this.pictureBox2_Scanner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2_Scanner.TabIndex = 8;
            this.pictureBox2_Scanner.TabStop = false;
            // 
            // IdleChekTimer
            // 
            this.IdleChekTimer.Tick += new System.EventHandler(this.IdleChekTimer_Tick);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::MouseMovementScanner.Properties.Resources.mackeyboard;
            this.pictureBox3.Location = new System.Drawing.Point(12, 58);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(256, 86);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox3.TabIndex = 13;
            this.pictureBox3.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(393, 429);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.grpBox_AutoStartTime);
            this.Controls.Add(this.btn_ForceStop);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.pictureBox2_Scanner);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_StartScanner);
            this.Controls.Add(this.pictureBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mouse Movement Scanner";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.grpBox_AutoStartTime.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2_Scanner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer ScannerTimer;
        private System.Windows.Forms.Button btn_StartScanner;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox chkBox_Startup;
        private System.Windows.Forms.CheckBox chkBox_Alert;
        private System.Windows.Forms.CheckBox chkBox_Lock;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBox_StartSelection;
        private System.Windows.Forms.Button btn_ForceStop;
        private System.Windows.Forms.CheckBox chkBox_StartMin;
        private System.Windows.Forms.Timer IdleChekTimer;
        private System.Windows.Forms.GroupBox grpBox_AutoStartTime;
        private System.Windows.Forms.ComboBox comboBox_IdleTime;
        public System.Windows.Forms.CheckBox chkBox_Idle;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkBox_Keyboard;
        private System.Windows.Forms.CheckBox chckBox_Mouse;
        private System.Windows.Forms.PictureBox pictureBox3;
        public System.Windows.Forms.PictureBox pictureBox2_Scanner;
    }
}


namespace MouseMovementScanner
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_CloseAbout = new System.Windows.Forms.Button();
            this.grpBox_Madefor = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpBox_Auth = new System.Windows.Forms.GroupBox();
            this.txtbox_Auth = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.grpBox_Madefor.SuspendLayout();
            this.grpBox_Auth.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MouseMovementScanner.Properties.Resources.uni_hud_logo;
            this.pictureBox1.Location = new System.Drawing.Point(6, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(273, 115);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btn_CloseAbout
            // 
            this.btn_CloseAbout.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btn_CloseAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CloseAbout.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CloseAbout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_CloseAbout.Location = new System.Drawing.Point(217, 336);
            this.btn_CloseAbout.Name = "btn_CloseAbout";
            this.btn_CloseAbout.Size = new System.Drawing.Size(74, 26);
            this.btn_CloseAbout.TabIndex = 1;
            this.btn_CloseAbout.Text = "Close";
            this.toolTip1.SetToolTip(this.btn_CloseAbout, "Close the window");
            this.btn_CloseAbout.UseVisualStyleBackColor = false;
            this.btn_CloseAbout.Click += new System.EventHandler(this.button1_Click);
            // 
            // grpBox_Madefor
            // 
            this.grpBox_Madefor.Controls.Add(this.label1);
            this.grpBox_Madefor.Controls.Add(this.pictureBox1);
            this.grpBox_Madefor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBox_Madefor.Location = new System.Drawing.Point(12, 12);
            this.grpBox_Madefor.Name = "grpBox_Madefor";
            this.grpBox_Madefor.Size = new System.Drawing.Size(285, 187);
            this.grpBox_Madefor.TabIndex = 2;
            this.grpBox_Madefor.TabStop = false;
            this.grpBox_Madefor.Text = "Made for:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(29, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "University of Hudderfield Web Page";
            this.toolTip1.SetToolTip(this.label1, "Visit the University of Huddersfield Webpage!");
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // grpBox_Auth
            // 
            this.grpBox_Auth.Controls.Add(this.txtbox_Auth);
            this.grpBox_Auth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBox_Auth.Location = new System.Drawing.Point(12, 205);
            this.grpBox_Auth.Name = "grpBox_Auth";
            this.grpBox_Auth.Size = new System.Drawing.Size(285, 115);
            this.grpBox_Auth.TabIndex = 3;
            this.grpBox_Auth.TabStop = false;
            this.grpBox_Auth.Text = "Author:";
            // 
            // txtbox_Auth
            // 
            this.txtbox_Auth.BackColor = System.Drawing.SystemColors.ControlDark;
            this.txtbox_Auth.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtbox_Auth.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtbox_Auth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbox_Auth.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtbox_Auth.Location = new System.Drawing.Point(6, 19);
            this.txtbox_Auth.Multiline = true;
            this.txtbox_Auth.Name = "txtbox_Auth";
            this.txtbox_Auth.ReadOnly = true;
            this.txtbox_Auth.Size = new System.Drawing.Size(273, 85);
            this.txtbox_Auth.TabIndex = 0;
            this.txtbox_Auth.Text = "\r\nAlexandru-Dumitru Maxim\r\nU1467822\r\nUni-Mail: U1467822@unimail.hud.ac.uk\r\nYear: " +
    "2016-2017\r\n";
            this.txtbox_Auth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(310, 374);
            this.ControlBox = false;
            this.Controls.Add(this.grpBox_Auth);
            this.Controls.Add(this.grpBox_Madefor);
            this.Controls.Add(this.btn_CloseAbout);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About Project";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.grpBox_Madefor.ResumeLayout(false);
            this.grpBox_Madefor.PerformLayout();
            this.grpBox_Auth.ResumeLayout(false);
            this.grpBox_Auth.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_CloseAbout;
        private System.Windows.Forms.GroupBox grpBox_Madefor;
        private System.Windows.Forms.GroupBox grpBox_Auth;
        private System.Windows.Forms.TextBox txtbox_Auth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
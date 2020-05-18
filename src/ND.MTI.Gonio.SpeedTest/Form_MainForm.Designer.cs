namespace ND.MTI.Gonio.SpeedTest
{
    partial class Form_MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_MainForm));
            this.buttonStartX = new System.Windows.Forms.Button();
            this.buttonStartY = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.groupBoxData = new System.Windows.Forms.GroupBox();
            this.textBoxTime = new System.Windows.Forms.TextBox();
            this.textBoxSpeedMinute = new System.Windows.Forms.TextBox();
            this.textBoxSpeedSec = new System.Windows.Forms.TextBox();
            this.labelTime = new System.Windows.Forms.Label();
            this.labelSpeedMin = new System.Windows.Forms.Label();
            this.labelSpeedSec = new System.Windows.Forms.Label();
            this.buttonExit = new System.Windows.Forms.Button();
            this.labelProSec = new System.Windows.Forms.Label();
            this.labelProMinute = new System.Windows.Forms.Label();
            this.groupBoxData.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonStartX
            // 
            this.buttonStartX.Location = new System.Drawing.Point(12, 12);
            this.buttonStartX.Name = "buttonStartX";
            this.buttonStartX.Size = new System.Drawing.Size(75, 23);
            this.buttonStartX.TabIndex = 0;
            this.buttonStartX.Text = "Start X test";
            this.buttonStartX.UseVisualStyleBackColor = true;
            this.buttonStartX.Click += new System.EventHandler(this.buttonStartX_Click);
            // 
            // buttonStartY
            // 
            this.buttonStartY.Location = new System.Drawing.Point(93, 12);
            this.buttonStartY.Name = "buttonStartY";
            this.buttonStartY.Size = new System.Drawing.Size(75, 23);
            this.buttonStartY.TabIndex = 1;
            this.buttonStartY.Text = "Start Y test";
            this.buttonStartY.UseVisualStyleBackColor = true;
            this.buttonStartY.Click += new System.EventHandler(this.buttonStartY_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Enabled = false;
            this.buttonStop.Location = new System.Drawing.Point(174, 12);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(75, 23);
            this.buttonStop.TabIndex = 3;
            this.buttonStop.Text = "Stop test";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // groupBoxData
            // 
            this.groupBoxData.Controls.Add(this.labelProMinute);
            this.groupBoxData.Controls.Add(this.labelProSec);
            this.groupBoxData.Controls.Add(this.textBoxTime);
            this.groupBoxData.Controls.Add(this.textBoxSpeedMinute);
            this.groupBoxData.Controls.Add(this.textBoxSpeedSec);
            this.groupBoxData.Controls.Add(this.labelTime);
            this.groupBoxData.Controls.Add(this.labelSpeedMin);
            this.groupBoxData.Controls.Add(this.labelSpeedSec);
            this.groupBoxData.Location = new System.Drawing.Point(12, 41);
            this.groupBoxData.Name = "groupBoxData";
            this.groupBoxData.Size = new System.Drawing.Size(237, 113);
            this.groupBoxData.TabIndex = 4;
            this.groupBoxData.TabStop = false;
            this.groupBoxData.Text = "Speed";
            // 
            // textBoxTime
            // 
            this.textBoxTime.Enabled = false;
            this.textBoxTime.Location = new System.Drawing.Point(56, 74);
            this.textBoxTime.Name = "textBoxTime";
            this.textBoxTime.ReadOnly = true;
            this.textBoxTime.Size = new System.Drawing.Size(100, 20);
            this.textBoxTime.TabIndex = 5;
            this.textBoxTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxSpeedMinute
            // 
            this.textBoxSpeedMinute.Enabled = false;
            this.textBoxSpeedMinute.Location = new System.Drawing.Point(56, 48);
            this.textBoxSpeedMinute.Name = "textBoxSpeedMinute";
            this.textBoxSpeedMinute.ReadOnly = true;
            this.textBoxSpeedMinute.Size = new System.Drawing.Size(100, 20);
            this.textBoxSpeedMinute.TabIndex = 4;
            this.textBoxSpeedMinute.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxSpeedSec
            // 
            this.textBoxSpeedSec.Enabled = false;
            this.textBoxSpeedSec.Location = new System.Drawing.Point(56, 22);
            this.textBoxSpeedSec.Name = "textBoxSpeedSec";
            this.textBoxSpeedSec.ReadOnly = true;
            this.textBoxSpeedSec.Size = new System.Drawing.Size(100, 20);
            this.textBoxSpeedSec.TabIndex = 3;
            this.textBoxSpeedSec.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(6, 77);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(30, 13);
            this.labelTime.TabIndex = 2;
            this.labelTime.Text = "Time";
            // 
            // labelSpeedMin
            // 
            this.labelSpeedMin.AutoSize = true;
            this.labelSpeedMin.Location = new System.Drawing.Point(6, 51);
            this.labelSpeedMin.Name = "labelSpeedMin";
            this.labelSpeedMin.Size = new System.Drawing.Size(38, 13);
            this.labelSpeedMin.TabIndex = 1;
            this.labelSpeedMin.Text = "Speed";
            // 
            // labelSpeedSec
            // 
            this.labelSpeedSec.AutoSize = true;
            this.labelSpeedSec.Location = new System.Drawing.Point(6, 25);
            this.labelSpeedSec.Name = "labelSpeedSec";
            this.labelSpeedSec.Size = new System.Drawing.Size(38, 13);
            this.labelSpeedSec.TabIndex = 0;
            this.labelSpeedSec.Text = "Speed";
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(174, 160);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 23);
            this.buttonExit.TabIndex = 5;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // labelProSec
            // 
            this.labelProSec.AutoSize = true;
            this.labelProSec.Location = new System.Drawing.Point(162, 25);
            this.labelProSec.Name = "labelProSec";
            this.labelProSec.Size = new System.Drawing.Size(33, 13);
            this.labelProSec.TabIndex = 6;
            this.labelProSec.Text = "°/sec";
            // 
            // labelProMinute
            // 
            this.labelProMinute.AutoSize = true;
            this.labelProMinute.Location = new System.Drawing.Point(159, 51);
            this.labelProMinute.Name = "labelProMinute";
            this.labelProMinute.Size = new System.Drawing.Size(47, 13);
            this.labelProMinute.TabIndex = 7;
            this.labelProMinute.Text = "°/minute";
            // 
            // Form_MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 198);
            this.ControlBox = false;
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.groupBoxData);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonStartY);
            this.Controls.Add(this.buttonStartX);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GONIO::Speed test";
            this.groupBoxData.ResumeLayout(false);
            this.groupBoxData.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonStartX;
        private System.Windows.Forms.Button buttonStartY;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.GroupBox groupBoxData;
        private System.Windows.Forms.TextBox textBoxTime;
        private System.Windows.Forms.TextBox textBoxSpeedMinute;
        private System.Windows.Forms.TextBox textBoxSpeedSec;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Label labelSpeedMin;
        private System.Windows.Forms.Label labelSpeedSec;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Label labelProSec;
        private System.Windows.Forms.Label labelProMinute;
    }
}


namespace ND.MTI.Gonio.RawPosition
{
    partial class RawPositionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RawPositionForm));
            this.ButtonIncXSlow = new System.Windows.Forms.Button();
            this.ButtonStopX = new System.Windows.Forms.Button();
            this.GroupBoxX = new System.Windows.Forms.GroupBox();
            this.TextBoxX_Normal = new System.Windows.Forms.TextBox();
            this.TextBoxX_Angle = new System.Windows.Forms.TextBox();
            this.TextBoxX_Raw = new System.Windows.Forms.TextBox();
            this.LabelX_Normalised = new System.Windows.Forms.Label();
            this.LabelX_Angle = new System.Windows.Forms.Label();
            this.LabelX_Raw = new System.Windows.Forms.Label();
            this.ButtonDecXSlow = new System.Windows.Forms.Button();
            this.GroupBoxY = new System.Windows.Forms.GroupBox();
            this.TextBoxY_Normal = new System.Windows.Forms.TextBox();
            this.TextBoxY_Angle = new System.Windows.Forms.TextBox();
            this.TextBoxY_Raw = new System.Windows.Forms.TextBox();
            this.LabelY_Normalised = new System.Windows.Forms.Label();
            this.LabelY_Angle = new System.Windows.Forms.Label();
            this.LabelY_Raw = new System.Windows.Forms.Label();
            this.ButtonDecYSlow = new System.Windows.Forms.Button();
            this.ButtonIncYSlow = new System.Windows.Forms.Button();
            this.ButtonStopY = new System.Windows.Forms.Button();
            this.ButtonExit = new System.Windows.Forms.Button();
            this.ButtonIncYFast = new System.Windows.Forms.Button();
            this.ButtonDecYFast = new System.Windows.Forms.Button();
            this.ButtonDecXFast = new System.Windows.Forms.Button();
            this.ButtonIncXFast = new System.Windows.Forms.Button();
            this.GroupBoxX.SuspendLayout();
            this.GroupBoxY.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonIncXSlow
            // 
            this.ButtonIncXSlow.Location = new System.Drawing.Point(6, 136);
            this.ButtonIncXSlow.Name = "ButtonIncXSlow";
            this.ButtonIncXSlow.Size = new System.Drawing.Size(91, 23);
            this.ButtonIncXSlow.TabIndex = 2;
            this.ButtonIncXSlow.Text = "+X SLOW (Q)";
            this.ButtonIncXSlow.UseVisualStyleBackColor = true;
            this.ButtonIncXSlow.Click += new System.EventHandler(this.ButtonIncXSlow_Click);
            // 
            // ButtonStopX
            // 
            this.ButtonStopX.Location = new System.Drawing.Point(6, 194);
            this.ButtonStopX.Name = "ButtonStopX";
            this.ButtonStopX.Size = new System.Drawing.Size(188, 23);
            this.ButtonStopX.TabIndex = 4;
            this.ButtonStopX.Text = "Stop";
            this.ButtonStopX.UseVisualStyleBackColor = true;
            this.ButtonStopX.Click += new System.EventHandler(this.ButtonStopX_Click);
            // 
            // GroupBoxX
            // 
            this.GroupBoxX.Controls.Add(this.ButtonIncXFast);
            this.GroupBoxX.Controls.Add(this.ButtonDecXFast);
            this.GroupBoxX.Controls.Add(this.TextBoxX_Normal);
            this.GroupBoxX.Controls.Add(this.TextBoxX_Angle);
            this.GroupBoxX.Controls.Add(this.TextBoxX_Raw);
            this.GroupBoxX.Controls.Add(this.LabelX_Normalised);
            this.GroupBoxX.Controls.Add(this.LabelX_Angle);
            this.GroupBoxX.Controls.Add(this.LabelX_Raw);
            this.GroupBoxX.Controls.Add(this.ButtonDecXSlow);
            this.GroupBoxX.Controls.Add(this.ButtonIncXSlow);
            this.GroupBoxX.Controls.Add(this.ButtonStopX);
            this.GroupBoxX.Location = new System.Drawing.Point(12, 12);
            this.GroupBoxX.Name = "GroupBoxX";
            this.GroupBoxX.Size = new System.Drawing.Size(200, 231);
            this.GroupBoxX.TabIndex = 6;
            this.GroupBoxX.TabStop = false;
            this.GroupBoxX.Text = "X angle";
            // 
            // TextBoxX_Normal
            // 
            this.TextBoxX_Normal.Enabled = false;
            this.TextBoxX_Normal.Location = new System.Drawing.Point(6, 110);
            this.TextBoxX_Normal.Name = "TextBoxX_Normal";
            this.TextBoxX_Normal.ReadOnly = true;
            this.TextBoxX_Normal.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TextBoxX_Normal.Size = new System.Drawing.Size(188, 20);
            this.TextBoxX_Normal.TabIndex = 10;
            this.TextBoxX_Normal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TextBoxX_Angle
            // 
            this.TextBoxX_Angle.Enabled = false;
            this.TextBoxX_Angle.Location = new System.Drawing.Point(6, 71);
            this.TextBoxX_Angle.Name = "TextBoxX_Angle";
            this.TextBoxX_Angle.ReadOnly = true;
            this.TextBoxX_Angle.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TextBoxX_Angle.Size = new System.Drawing.Size(188, 20);
            this.TextBoxX_Angle.TabIndex = 9;
            this.TextBoxX_Angle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TextBoxX_Raw
            // 
            this.TextBoxX_Raw.Enabled = false;
            this.TextBoxX_Raw.Location = new System.Drawing.Point(6, 32);
            this.TextBoxX_Raw.Name = "TextBoxX_Raw";
            this.TextBoxX_Raw.ReadOnly = true;
            this.TextBoxX_Raw.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TextBoxX_Raw.Size = new System.Drawing.Size(188, 20);
            this.TextBoxX_Raw.TabIndex = 7;
            this.TextBoxX_Raw.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LabelX_Normalised
            // 
            this.LabelX_Normalised.AutoSize = true;
            this.LabelX_Normalised.Location = new System.Drawing.Point(6, 94);
            this.LabelX_Normalised.Name = "LabelX_Normalised";
            this.LabelX_Normalised.Size = new System.Drawing.Size(88, 13);
            this.LabelX_Normalised.TabIndex = 8;
            this.LabelX_Normalised.Text = "X NORMALISED";
            // 
            // LabelX_Angle
            // 
            this.LabelX_Angle.AutoSize = true;
            this.LabelX_Angle.Location = new System.Drawing.Point(6, 55);
            this.LabelX_Angle.Name = "LabelX_Angle";
            this.LabelX_Angle.Size = new System.Drawing.Size(53, 13);
            this.LabelX_Angle.TabIndex = 7;
            this.LabelX_Angle.Text = "X ANGLE";
            // 
            // LabelX_Raw
            // 
            this.LabelX_Raw.AutoSize = true;
            this.LabelX_Raw.Location = new System.Drawing.Point(6, 16);
            this.LabelX_Raw.Name = "LabelX_Raw";
            this.LabelX_Raw.Size = new System.Drawing.Size(43, 13);
            this.LabelX_Raw.TabIndex = 6;
            this.LabelX_Raw.Text = "X RAW";
            // 
            // ButtonDecXSlow
            // 
            this.ButtonDecXSlow.Location = new System.Drawing.Point(103, 136);
            this.ButtonDecXSlow.Name = "ButtonDecXSlow";
            this.ButtonDecXSlow.Size = new System.Drawing.Size(91, 23);
            this.ButtonDecXSlow.TabIndex = 5;
            this.ButtonDecXSlow.Text = "-X SLOW (W)";
            this.ButtonDecXSlow.UseVisualStyleBackColor = true;
            this.ButtonDecXSlow.Click += new System.EventHandler(this.ButtonDecXSlow_Click);
            // 
            // GroupBoxY
            // 
            this.GroupBoxY.Controls.Add(this.ButtonDecYFast);
            this.GroupBoxY.Controls.Add(this.ButtonIncYFast);
            this.GroupBoxY.Controls.Add(this.TextBoxY_Normal);
            this.GroupBoxY.Controls.Add(this.TextBoxY_Angle);
            this.GroupBoxY.Controls.Add(this.TextBoxY_Raw);
            this.GroupBoxY.Controls.Add(this.LabelY_Normalised);
            this.GroupBoxY.Controls.Add(this.LabelY_Angle);
            this.GroupBoxY.Controls.Add(this.LabelY_Raw);
            this.GroupBoxY.Controls.Add(this.ButtonDecYSlow);
            this.GroupBoxY.Controls.Add(this.ButtonIncYSlow);
            this.GroupBoxY.Controls.Add(this.ButtonStopY);
            this.GroupBoxY.Location = new System.Drawing.Point(218, 12);
            this.GroupBoxY.Name = "GroupBoxY";
            this.GroupBoxY.Size = new System.Drawing.Size(200, 231);
            this.GroupBoxY.TabIndex = 11;
            this.GroupBoxY.TabStop = false;
            this.GroupBoxY.Text = "Y angle";
            // 
            // TextBoxY_Normal
            // 
            this.TextBoxY_Normal.Enabled = false;
            this.TextBoxY_Normal.Location = new System.Drawing.Point(6, 110);
            this.TextBoxY_Normal.Name = "TextBoxY_Normal";
            this.TextBoxY_Normal.ReadOnly = true;
            this.TextBoxY_Normal.Size = new System.Drawing.Size(188, 20);
            this.TextBoxY_Normal.TabIndex = 10;
            this.TextBoxY_Normal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TextBoxY_Angle
            // 
            this.TextBoxY_Angle.Enabled = false;
            this.TextBoxY_Angle.Location = new System.Drawing.Point(6, 71);
            this.TextBoxY_Angle.Name = "TextBoxY_Angle";
            this.TextBoxY_Angle.ReadOnly = true;
            this.TextBoxY_Angle.Size = new System.Drawing.Size(188, 20);
            this.TextBoxY_Angle.TabIndex = 9;
            this.TextBoxY_Angle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TextBoxY_Raw
            // 
            this.TextBoxY_Raw.Enabled = false;
            this.TextBoxY_Raw.Location = new System.Drawing.Point(6, 32);
            this.TextBoxY_Raw.Name = "TextBoxY_Raw";
            this.TextBoxY_Raw.ReadOnly = true;
            this.TextBoxY_Raw.Size = new System.Drawing.Size(188, 20);
            this.TextBoxY_Raw.TabIndex = 7;
            this.TextBoxY_Raw.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LabelY_Normalised
            // 
            this.LabelY_Normalised.AutoSize = true;
            this.LabelY_Normalised.Location = new System.Drawing.Point(6, 94);
            this.LabelY_Normalised.Name = "LabelY_Normalised";
            this.LabelY_Normalised.Size = new System.Drawing.Size(88, 13);
            this.LabelY_Normalised.TabIndex = 8;
            this.LabelY_Normalised.Text = "Y NORMALISED";
            // 
            // LabelY_Angle
            // 
            this.LabelY_Angle.AutoSize = true;
            this.LabelY_Angle.Location = new System.Drawing.Point(6, 55);
            this.LabelY_Angle.Name = "LabelY_Angle";
            this.LabelY_Angle.Size = new System.Drawing.Size(53, 13);
            this.LabelY_Angle.TabIndex = 7;
            this.LabelY_Angle.Text = "Y ANGLE";
            // 
            // LabelY_Raw
            // 
            this.LabelY_Raw.AutoSize = true;
            this.LabelY_Raw.Location = new System.Drawing.Point(6, 16);
            this.LabelY_Raw.Name = "LabelY_Raw";
            this.LabelY_Raw.Size = new System.Drawing.Size(43, 13);
            this.LabelY_Raw.TabIndex = 6;
            this.LabelY_Raw.Text = "Y RAW";
            // 
            // ButtonDecYSlow
            // 
            this.ButtonDecYSlow.Location = new System.Drawing.Point(103, 136);
            this.ButtonDecYSlow.Name = "ButtonDecYSlow";
            this.ButtonDecYSlow.Size = new System.Drawing.Size(91, 23);
            this.ButtonDecYSlow.TabIndex = 5;
            this.ButtonDecYSlow.Text = "-Y SLOW (S)";
            this.ButtonDecYSlow.UseVisualStyleBackColor = true;
            this.ButtonDecYSlow.Click += new System.EventHandler(this.ButtonDecYSlow_Click);
            // 
            // ButtonIncYSlow
            // 
            this.ButtonIncYSlow.Location = new System.Drawing.Point(6, 136);
            this.ButtonIncYSlow.Name = "ButtonIncYSlow";
            this.ButtonIncYSlow.Size = new System.Drawing.Size(91, 23);
            this.ButtonIncYSlow.TabIndex = 2;
            this.ButtonIncYSlow.Text = "+Y SLOW (A)";
            this.ButtonIncYSlow.UseVisualStyleBackColor = true;
            this.ButtonIncYSlow.Click += new System.EventHandler(this.ButtonIncYSlow_Click);
            // 
            // ButtonStopY
            // 
            this.ButtonStopY.Location = new System.Drawing.Point(6, 194);
            this.ButtonStopY.Name = "ButtonStopY";
            this.ButtonStopY.Size = new System.Drawing.Size(188, 23);
            this.ButtonStopY.TabIndex = 4;
            this.ButtonStopY.Text = "Stop";
            this.ButtonStopY.UseVisualStyleBackColor = true;
            this.ButtonStopY.Click += new System.EventHandler(this.ButtonStopY_Click);
            // 
            // ButtonExit
            // 
            this.ButtonExit.Location = new System.Drawing.Point(343, 249);
            this.ButtonExit.Name = "ButtonExit";
            this.ButtonExit.Size = new System.Drawing.Size(75, 23);
            this.ButtonExit.TabIndex = 12;
            this.ButtonExit.Text = "Exit";
            this.ButtonExit.UseVisualStyleBackColor = true;
            this.ButtonExit.Click += new System.EventHandler(this.ButtonExit_Click);
            // 
            // ButtonIncYFast
            // 
            this.ButtonIncYFast.Location = new System.Drawing.Point(6, 165);
            this.ButtonIncYFast.Name = "ButtonIncYFast";
            this.ButtonIncYFast.Size = new System.Drawing.Size(91, 23);
            this.ButtonIncYFast.TabIndex = 11;
            this.ButtonIncYFast.Text = "+Y SLOW (D)";
            this.ButtonIncYFast.UseVisualStyleBackColor = true;
            this.ButtonIncYFast.Click += new System.EventHandler(this.ButtonIncYFast_Click);
            // 
            // ButtonDecYFast
            // 
            this.ButtonDecYFast.Location = new System.Drawing.Point(103, 165);
            this.ButtonDecYFast.Name = "ButtonDecYFast";
            this.ButtonDecYFast.Size = new System.Drawing.Size(91, 23);
            this.ButtonDecYFast.TabIndex = 12;
            this.ButtonDecYFast.Text = "-Y FAST (F)";
            this.ButtonDecYFast.UseVisualStyleBackColor = true;
            this.ButtonDecYFast.Click += new System.EventHandler(this.ButtonDecYFast_Click);
            // 
            // ButtonDecXFast
            // 
            this.ButtonDecXFast.Location = new System.Drawing.Point(103, 165);
            this.ButtonDecXFast.Name = "ButtonDecXFast";
            this.ButtonDecXFast.Size = new System.Drawing.Size(91, 23);
            this.ButtonDecXFast.TabIndex = 11;
            this.ButtonDecXFast.Text = "-X FAST (R)";
            this.ButtonDecXFast.UseVisualStyleBackColor = true;
            this.ButtonDecXFast.Click += new System.EventHandler(this.ButtonDecXFast_Click);
            // 
            // ButtonIncXFast
            // 
            this.ButtonIncXFast.Location = new System.Drawing.Point(6, 165);
            this.ButtonIncXFast.Name = "ButtonIncXFast";
            this.ButtonIncXFast.Size = new System.Drawing.Size(91, 23);
            this.ButtonIncXFast.TabIndex = 12;
            this.ButtonIncXFast.Text = "+X FAST (E)";
            this.ButtonIncXFast.UseVisualStyleBackColor = true;
            this.ButtonIncXFast.Click += new System.EventHandler(this.ButtonIncXFast_Click);
            // 
            // RawPositionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 284);
            this.ControlBox = false;
            this.Controls.Add(this.ButtonExit);
            this.Controls.Add(this.GroupBoxY);
            this.Controls.Add(this.GroupBoxX);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RawPositionForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GONIO::RawPos";
            this.GroupBoxX.ResumeLayout(false);
            this.GroupBoxX.PerformLayout();
            this.GroupBoxY.ResumeLayout(false);
            this.GroupBoxY.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button ButtonIncXSlow;
        private System.Windows.Forms.Button ButtonStopX;
        private System.Windows.Forms.GroupBox GroupBoxX;
        private System.Windows.Forms.Button ButtonDecXSlow;
        private System.Windows.Forms.TextBox TextBoxX_Normal;
        private System.Windows.Forms.TextBox TextBoxX_Angle;
        private System.Windows.Forms.TextBox TextBoxX_Raw;
        private System.Windows.Forms.Label LabelX_Normalised;
        private System.Windows.Forms.Label LabelX_Angle;
        private System.Windows.Forms.Label LabelX_Raw;
        private System.Windows.Forms.GroupBox GroupBoxY;
        private System.Windows.Forms.TextBox TextBoxY_Normal;
        private System.Windows.Forms.TextBox TextBoxY_Angle;
        private System.Windows.Forms.TextBox TextBoxY_Raw;
        private System.Windows.Forms.Label LabelY_Normalised;
        private System.Windows.Forms.Label LabelY_Angle;
        private System.Windows.Forms.Label LabelY_Raw;
        private System.Windows.Forms.Button ButtonDecYSlow;
        private System.Windows.Forms.Button ButtonIncYSlow;
        private System.Windows.Forms.Button ButtonStopY;
        private System.Windows.Forms.Button ButtonExit;
        private System.Windows.Forms.Button ButtonIncXFast;
        private System.Windows.Forms.Button ButtonDecXFast;
        private System.Windows.Forms.Button ButtonDecYFast;
        private System.Windows.Forms.Button ButtonIncYFast;
    }
}


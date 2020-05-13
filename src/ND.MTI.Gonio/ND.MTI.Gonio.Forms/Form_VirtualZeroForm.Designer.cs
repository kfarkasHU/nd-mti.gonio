using System;

namespace ND.MTI.Gonio.Forms
{
    partial class Form_VirtualZeroForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_VirtualZeroForm));
            this.groupBoxCurrentPosition = new System.Windows.Forms.GroupBox();
            this.textBoxYCoord = new System.Windows.Forms.TextBox();
            this.textBoxXCoord = new System.Windows.Forms.TextBox();
            this.labelYCoord = new System.Windows.Forms.Label();
            this.labelXCoord = new System.Windows.Forms.Label();
            this.groupBoxControl = new System.Windows.Forms.GroupBox();
            this.buttonIncrementYFast = new System.Windows.Forms.Button();
            this.buttonDecrementXFast = new System.Windows.Forms.Button();
            this.buttonIncrementXFast = new System.Windows.Forms.Button();
            this.buttonDecrementYSlow = new System.Windows.Forms.Button();
            this.buttonStopX = new System.Windows.Forms.Button();
            this.buttonStopY = new System.Windows.Forms.Button();
            this.buttonIncrementYSlow = new System.Windows.Forms.Button();
            this.buttonDecrementYFast = new System.Windows.Forms.Button();
            this.buttonIncrementXSlow = new System.Windows.Forms.Button();
            this.buttonDecrementXSlow = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.groupBoxSetPosition = new System.Windows.Forms.GroupBox();
            this.buttonGo = new System.Windows.Forms.Button();
            this.textBoxSetPositionY = new System.Windows.Forms.TextBox();
            this.textBoxSetPositionX = new System.Windows.Forms.TextBox();
            this.labelSetPositionY = new System.Windows.Forms.Label();
            this.labelSetPositionX = new System.Windows.Forms.Label();
            this.groupBoxCurrentPosition.SuspendLayout();
            this.groupBoxControl.SuspendLayout();
            this.groupBoxSetPosition.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxCurrentPosition
            // 
            this.groupBoxCurrentPosition.Controls.Add(this.textBoxYCoord);
            this.groupBoxCurrentPosition.Controls.Add(this.textBoxXCoord);
            this.groupBoxCurrentPosition.Controls.Add(this.labelYCoord);
            this.groupBoxCurrentPosition.Controls.Add(this.labelXCoord);
            this.groupBoxCurrentPosition.Location = new System.Drawing.Point(12, 12);
            this.groupBoxCurrentPosition.Name = "groupBoxCurrentPosition";
            this.groupBoxCurrentPosition.Size = new System.Drawing.Size(262, 100);
            this.groupBoxCurrentPosition.TabIndex = 0;
            this.groupBoxCurrentPosition.TabStop = false;
            this.groupBoxCurrentPosition.Text = "Current position";
            // 
            // textBoxYCoord
            // 
            this.textBoxYCoord.Cursor = System.Windows.Forms.Cursors.No;
            this.textBoxYCoord.Enabled = false;
            this.textBoxYCoord.Location = new System.Drawing.Point(29, 54);
            this.textBoxYCoord.Name = "textBoxYCoord";
            this.textBoxYCoord.Size = new System.Drawing.Size(218, 20);
            this.textBoxYCoord.TabIndex = 3;
            this.textBoxYCoord.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxXCoord
            // 
            this.textBoxXCoord.Cursor = System.Windows.Forms.Cursors.No;
            this.textBoxXCoord.Enabled = false;
            this.textBoxXCoord.Location = new System.Drawing.Point(29, 27);
            this.textBoxXCoord.Name = "textBoxXCoord";
            this.textBoxXCoord.Size = new System.Drawing.Size(218, 20);
            this.textBoxXCoord.TabIndex = 2;
            this.textBoxXCoord.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelYCoord
            // 
            this.labelYCoord.AutoSize = true;
            this.labelYCoord.Location = new System.Drawing.Point(6, 57);
            this.labelYCoord.Name = "labelYCoord";
            this.labelYCoord.Size = new System.Drawing.Size(17, 13);
            this.labelYCoord.TabIndex = 1;
            this.labelYCoord.Text = "Y:";
            // 
            // labelXCoord
            // 
            this.labelXCoord.AutoSize = true;
            this.labelXCoord.Location = new System.Drawing.Point(6, 30);
            this.labelXCoord.Name = "labelXCoord";
            this.labelXCoord.Size = new System.Drawing.Size(17, 13);
            this.labelXCoord.TabIndex = 0;
            this.labelXCoord.Text = "X:";
            // 
            // groupBoxControl
            // 
            this.groupBoxControl.Controls.Add(this.buttonIncrementYFast);
            this.groupBoxControl.Controls.Add(this.buttonDecrementXFast);
            this.groupBoxControl.Controls.Add(this.buttonIncrementXFast);
            this.groupBoxControl.Controls.Add(this.buttonDecrementYSlow);
            this.groupBoxControl.Controls.Add(this.buttonStopX);
            this.groupBoxControl.Controls.Add(this.buttonStopY);
            this.groupBoxControl.Controls.Add(this.buttonIncrementYSlow);
            this.groupBoxControl.Controls.Add(this.buttonDecrementYFast);
            this.groupBoxControl.Controls.Add(this.buttonIncrementXSlow);
            this.groupBoxControl.Controls.Add(this.buttonDecrementXSlow);
            this.groupBoxControl.Location = new System.Drawing.Point(12, 240);
            this.groupBoxControl.Name = "groupBoxControl";
            this.groupBoxControl.Size = new System.Drawing.Size(257, 137);
            this.groupBoxControl.TabIndex = 1;
            this.groupBoxControl.TabStop = false;
            this.groupBoxControl.Text = "Control";
            // 
            // buttonIncrementYFast
            // 
            this.buttonIncrementYFast.Location = new System.Drawing.Point(87, 109);
            this.buttonIncrementYFast.Name = "buttonIncrementYFast";
            this.buttonIncrementYFast.Size = new System.Drawing.Size(75, 23);
            this.buttonIncrementYFast.TabIndex = 9;
            this.buttonIncrementYFast.Text = "+Y fast (F)";
            this.buttonIncrementYFast.UseVisualStyleBackColor = true;
            this.buttonIncrementYFast.Click += new System.EventHandler(this.ButtonIncrementYFast_Click);
            // 
            // buttonDecrementXFast
            // 
            this.buttonDecrementXFast.Location = new System.Drawing.Point(6, 48);
            this.buttonDecrementXFast.Name = "buttonDecrementXFast";
            this.buttonDecrementXFast.Size = new System.Drawing.Size(75, 23);
            this.buttonDecrementXFast.TabIndex = 8;
            this.buttonDecrementXFast.Text = "-X fast (E)";
            this.buttonDecrementXFast.UseVisualStyleBackColor = true;
            this.buttonDecrementXFast.Click += new System.EventHandler(this.ButtonDecrementXFast_Click);
            // 
            // buttonIncrementXFast
            // 
            this.buttonIncrementXFast.Location = new System.Drawing.Point(87, 48);
            this.buttonIncrementXFast.Name = "buttonIncrementXFast";
            this.buttonIncrementXFast.Size = new System.Drawing.Size(75, 23);
            this.buttonIncrementXFast.TabIndex = 7;
            this.buttonIncrementXFast.Text = "+X fast (R)";
            this.buttonIncrementXFast.UseVisualStyleBackColor = true;
            this.buttonIncrementXFast.Click += new System.EventHandler(this.ButtonIncrementXFast_Click);
            // 
            // buttonDecrementYSlow
            // 
            this.buttonDecrementYSlow.Location = new System.Drawing.Point(6, 80);
            this.buttonDecrementYSlow.Name = "buttonDecrementYSlow";
            this.buttonDecrementYSlow.Size = new System.Drawing.Size(75, 23);
            this.buttonDecrementYSlow.TabIndex = 6;
            this.buttonDecrementYSlow.Text = "-Y slow (A)";
            this.buttonDecrementYSlow.UseVisualStyleBackColor = true;
            this.buttonDecrementYSlow.Click += new System.EventHandler(this.ButtonDecrementYSlow_Click);
            // 
            // buttonStopX
            // 
            this.buttonStopX.Location = new System.Drawing.Point(176, 19);
            this.buttonStopX.Name = "buttonStopX";
            this.buttonStopX.Size = new System.Drawing.Size(75, 23);
            this.buttonStopX.TabIndex = 5;
            this.buttonStopX.Text = "Stop X";
            this.buttonStopX.UseVisualStyleBackColor = true;
            this.buttonStopX.Click += new System.EventHandler(this.ButtonStopX_Click);
            // 
            // buttonStopY
            // 
            this.buttonStopY.Location = new System.Drawing.Point(176, 80);
            this.buttonStopY.Name = "buttonStopY";
            this.buttonStopY.Size = new System.Drawing.Size(75, 23);
            this.buttonStopY.TabIndex = 4;
            this.buttonStopY.Text = "Stop Y";
            this.buttonStopY.UseVisualStyleBackColor = true;
            this.buttonStopY.Click += new System.EventHandler(this.ButtonStopY_Click);
            // 
            // buttonIncrementYSlow
            // 
            this.buttonIncrementYSlow.Location = new System.Drawing.Point(87, 80);
            this.buttonIncrementYSlow.Name = "buttonIncrementYSlow";
            this.buttonIncrementYSlow.Size = new System.Drawing.Size(75, 23);
            this.buttonIncrementYSlow.TabIndex = 3;
            this.buttonIncrementYSlow.Text = "+Y slow (S)";
            this.buttonIncrementYSlow.UseVisualStyleBackColor = true;
            this.buttonIncrementYSlow.Click += new System.EventHandler(this.ButtonIncrementYSlow_Click);
            // 
            // buttonDecrementYFast
            // 
            this.buttonDecrementYFast.Location = new System.Drawing.Point(6, 109);
            this.buttonDecrementYFast.Name = "buttonDecrementYFast";
            this.buttonDecrementYFast.Size = new System.Drawing.Size(75, 23);
            this.buttonDecrementYFast.TabIndex = 2;
            this.buttonDecrementYFast.Text = "-Y fast (A)";
            this.buttonDecrementYFast.UseVisualStyleBackColor = true;
            this.buttonDecrementYFast.Click += new System.EventHandler(this.ButtonDecrementYFast_Click);
            // 
            // buttonIncrementXSlow
            // 
            this.buttonIncrementXSlow.Location = new System.Drawing.Point(87, 19);
            this.buttonIncrementXSlow.Name = "buttonIncrementXSlow";
            this.buttonIncrementXSlow.Size = new System.Drawing.Size(75, 23);
            this.buttonIncrementXSlow.TabIndex = 1;
            this.buttonIncrementXSlow.Text = "+X slow (W)";
            this.buttonIncrementXSlow.UseVisualStyleBackColor = true;
            this.buttonIncrementXSlow.Click += new System.EventHandler(this.ButtonIncrementXSlow_Click);
            // 
            // buttonDecrementXSlow
            // 
            this.buttonDecrementXSlow.Location = new System.Drawing.Point(6, 19);
            this.buttonDecrementXSlow.Name = "buttonDecrementXSlow";
            this.buttonDecrementXSlow.Size = new System.Drawing.Size(75, 23);
            this.buttonDecrementXSlow.TabIndex = 0;
            this.buttonDecrementXSlow.Text = "-X slow (Q)";
            this.buttonDecrementXSlow.UseVisualStyleBackColor = true;
            this.buttonDecrementXSlow.Click += new System.EventHandler(this.ButtonDecrementXSlow_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(194, 383);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 5;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(12, 383);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 6;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // groupBoxSetPosition
            // 
            this.groupBoxSetPosition.Controls.Add(this.buttonGo);
            this.groupBoxSetPosition.Controls.Add(this.textBoxSetPositionY);
            this.groupBoxSetPosition.Controls.Add(this.textBoxSetPositionX);
            this.groupBoxSetPosition.Controls.Add(this.labelSetPositionY);
            this.groupBoxSetPosition.Controls.Add(this.labelSetPositionX);
            this.groupBoxSetPosition.Location = new System.Drawing.Point(12, 118);
            this.groupBoxSetPosition.Name = "groupBoxSetPosition";
            this.groupBoxSetPosition.Size = new System.Drawing.Size(262, 116);
            this.groupBoxSetPosition.TabIndex = 4;
            this.groupBoxSetPosition.TabStop = false;
            this.groupBoxSetPosition.Text = "Set position";
            // 
            // buttonGo
            // 
            this.buttonGo.Location = new System.Drawing.Point(9, 80);
            this.buttonGo.Name = "buttonGo";
            this.buttonGo.Size = new System.Drawing.Size(238, 23);
            this.buttonGo.TabIndex = 7;
            this.buttonGo.Text = "Go";
            this.buttonGo.UseVisualStyleBackColor = true;
            this.buttonGo.Click += new System.EventHandler(this.ButtonGo_Click);
            // 
            // textBoxSetPositionY
            // 
            this.textBoxSetPositionY.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxSetPositionY.Location = new System.Drawing.Point(29, 54);
            this.textBoxSetPositionY.Name = "textBoxSetPositionY";
            this.textBoxSetPositionY.Size = new System.Drawing.Size(218, 20);
            this.textBoxSetPositionY.TabIndex = 3;
            this.textBoxSetPositionY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxSetPositionX
            // 
            this.textBoxSetPositionX.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxSetPositionX.Location = new System.Drawing.Point(29, 27);
            this.textBoxSetPositionX.Name = "textBoxSetPositionX";
            this.textBoxSetPositionX.Size = new System.Drawing.Size(218, 20);
            this.textBoxSetPositionX.TabIndex = 2;
            this.textBoxSetPositionX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelSetPositionY
            // 
            this.labelSetPositionY.AutoSize = true;
            this.labelSetPositionY.Location = new System.Drawing.Point(6, 57);
            this.labelSetPositionY.Name = "labelSetPositionY";
            this.labelSetPositionY.Size = new System.Drawing.Size(17, 13);
            this.labelSetPositionY.TabIndex = 1;
            this.labelSetPositionY.Text = "Y:";
            // 
            // labelSetPositionX
            // 
            this.labelSetPositionX.AutoSize = true;
            this.labelSetPositionX.Location = new System.Drawing.Point(6, 30);
            this.labelSetPositionX.Name = "labelSetPositionX";
            this.labelSetPositionX.Size = new System.Drawing.Size(17, 13);
            this.labelSetPositionX.TabIndex = 0;
            this.labelSetPositionX.Text = "X:";
            // 
            // Form_VirtualZeroForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 418);
            this.ControlBox = false;
            this.Controls.Add(this.groupBoxSetPosition);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.groupBoxControl);
            this.Controls.Add(this.groupBoxCurrentPosition);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_VirtualZeroForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GONIO::Set virtual zero";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form_VirtualZeroForm_Load);
            this.groupBoxCurrentPosition.ResumeLayout(false);
            this.groupBoxCurrentPosition.PerformLayout();
            this.groupBoxControl.ResumeLayout(false);
            this.groupBoxSetPosition.ResumeLayout(false);
            this.groupBoxSetPosition.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxCurrentPosition;
        private System.Windows.Forms.GroupBox groupBoxControl;
        private System.Windows.Forms.Label labelYCoord;
        private System.Windows.Forms.Label labelXCoord;
        private System.Windows.Forms.TextBox textBoxYCoord;
        private System.Windows.Forms.TextBox textBoxXCoord;
        private System.Windows.Forms.Button buttonIncrementYSlow;
        private System.Windows.Forms.Button buttonDecrementYFast;
        private System.Windows.Forms.Button buttonIncrementXSlow;
        private System.Windows.Forms.Button buttonDecrementXSlow;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonStopX;
        private System.Windows.Forms.Button buttonStopY;
        private System.Windows.Forms.GroupBox groupBoxSetPosition;
        private System.Windows.Forms.TextBox textBoxSetPositionY;
        private System.Windows.Forms.TextBox textBoxSetPositionX;
        private System.Windows.Forms.Label labelSetPositionY;
        private System.Windows.Forms.Label labelSetPositionX;
        private System.Windows.Forms.Button buttonGo;
        private System.Windows.Forms.Button buttonIncrementYFast;
        private System.Windows.Forms.Button buttonDecrementXFast;
        private System.Windows.Forms.Button buttonIncrementXFast;
        private System.Windows.Forms.Button buttonDecrementYSlow;
    }
}

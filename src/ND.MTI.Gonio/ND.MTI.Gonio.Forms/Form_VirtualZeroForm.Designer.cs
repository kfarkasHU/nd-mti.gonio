﻿using System;

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
            this.groupBoxCurrentPosition = new System.Windows.Forms.GroupBox();
            this.textBoxYCoord = new System.Windows.Forms.TextBox();
            this.textBoxXCoord = new System.Windows.Forms.TextBox();
            this.labelYCoord = new System.Windows.Forms.Label();
            this.labelXCoord = new System.Windows.Forms.Label();
            this.groupBoxControl = new System.Windows.Forms.GroupBox();
            this.comboBoxStep = new System.Windows.Forms.ComboBox();
            this.labelStep = new System.Windows.Forms.Label();
            this.buttonIncrementY = new System.Windows.Forms.Button();
            this.buttonDecrementY = new System.Windows.Forms.Button();
            this.buttonIncrementX = new System.Windows.Forms.Button();
            this.buttonDecrementX = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.groupBoxCurrentPosition.SuspendLayout();
            this.groupBoxControl.SuspendLayout();
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
            this.groupBoxCurrentPosition.Size = new System.Drawing.Size(172, 100);
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
            this.textBoxYCoord.Size = new System.Drawing.Size(137, 20);
            this.textBoxYCoord.TabIndex = 3;
            this.textBoxYCoord.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxXCoord
            // 
            this.textBoxXCoord.Cursor = System.Windows.Forms.Cursors.No;
            this.textBoxXCoord.Enabled = false;
            this.textBoxXCoord.Location = new System.Drawing.Point(29, 27);
            this.textBoxXCoord.Name = "textBoxXCoord";
            this.textBoxXCoord.Size = new System.Drawing.Size(137, 20);
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
            this.groupBoxControl.Controls.Add(this.comboBoxStep);
            this.groupBoxControl.Controls.Add(this.labelStep);
            this.groupBoxControl.Controls.Add(this.buttonIncrementY);
            this.groupBoxControl.Controls.Add(this.buttonDecrementY);
            this.groupBoxControl.Controls.Add(this.buttonIncrementX);
            this.groupBoxControl.Controls.Add(this.buttonDecrementX);
            this.groupBoxControl.Location = new System.Drawing.Point(12, 118);
            this.groupBoxControl.Name = "groupBoxControl";
            this.groupBoxControl.Size = new System.Drawing.Size(172, 118);
            this.groupBoxControl.TabIndex = 1;
            this.groupBoxControl.TabStop = false;
            this.groupBoxControl.Text = "Control";
            // 
            // comboBoxStep
            // 
            this.comboBoxStep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStep.FormattingEnabled = true;
            this.comboBoxStep.Items.AddRange(new object[] {
            "1",
            "10",
            "20",
            "25",
            "5",
            "50"});
            this.comboBoxStep.Location = new System.Drawing.Point(6, 33);
            this.comboBoxStep.Name = "comboBoxStep";
            this.comboBoxStep.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.comboBoxStep.Size = new System.Drawing.Size(160, 21);
            this.comboBoxStep.TabIndex = 5;
            // 
            // labelStep
            // 
            this.labelStep.AutoSize = true;
            this.labelStep.Location = new System.Drawing.Point(6, 18);
            this.labelStep.Name = "labelStep";
            this.labelStep.Size = new System.Drawing.Size(29, 13);
            this.labelStep.TabIndex = 4;
            this.labelStep.Text = "Step";
            // 
            // buttonIncrementY
            // 
            this.buttonIncrementY.Location = new System.Drawing.Point(91, 89);
            this.buttonIncrementY.Name = "buttonIncrementY";
            this.buttonIncrementY.Size = new System.Drawing.Size(75, 23);
            this.buttonIncrementY.TabIndex = 3;
            this.buttonIncrementY.Text = "+Y (S)";
            this.buttonIncrementY.UseVisualStyleBackColor = true;
            this.buttonIncrementY.Click += new System.EventHandler(this.ButtonIncrementY_Click);
            // 
            // buttonDecrementY
            // 
            this.buttonDecrementY.Location = new System.Drawing.Point(6, 89);
            this.buttonDecrementY.Name = "buttonDecrementY";
            this.buttonDecrementY.Size = new System.Drawing.Size(75, 23);
            this.buttonDecrementY.TabIndex = 2;
            this.buttonDecrementY.Text = "-Y (A)";
            this.buttonDecrementY.UseVisualStyleBackColor = true;
            this.buttonDecrementY.Click += new System.EventHandler(this.ButtonDecrementY_Click);
            // 
            // buttonIncrementX
            // 
            this.buttonIncrementX.Location = new System.Drawing.Point(91, 60);
            this.buttonIncrementX.Name = "buttonIncrementX";
            this.buttonIncrementX.Size = new System.Drawing.Size(75, 23);
            this.buttonIncrementX.TabIndex = 1;
            this.buttonIncrementX.Text = "+X (W)";
            this.buttonIncrementX.UseVisualStyleBackColor = true;
            this.buttonIncrementX.Click += new System.EventHandler(this.ButtonIncrementX_Click);
            // 
            // buttonDecrementX
            // 
            this.buttonDecrementX.Location = new System.Drawing.Point(6, 60);
            this.buttonDecrementX.Name = "buttonDecrementX";
            this.buttonDecrementX.Size = new System.Drawing.Size(75, 23);
            this.buttonDecrementX.TabIndex = 0;
            this.buttonDecrementX.Text = "-X (Q)";
            this.buttonDecrementX.UseVisualStyleBackColor = true;
            this.buttonDecrementX.Click += new System.EventHandler(this.ButtonDecrementX_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(109, 242);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 5;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(12, 242);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 6;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // Form_VirtualZeroForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(194, 272);
            this.ControlBox = false;
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.groupBoxControl);
            this.Controls.Add(this.groupBoxCurrentPosition);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form_VirtualZeroForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GONIO::Set virtual zero";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form_VirtualZeroForm_Load);
            this.groupBoxCurrentPosition.ResumeLayout(false);
            this.groupBoxCurrentPosition.PerformLayout();
            this.groupBoxControl.ResumeLayout(false);
            this.groupBoxControl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxCurrentPosition;
        private System.Windows.Forms.GroupBox groupBoxControl;
        private System.Windows.Forms.Label labelYCoord;
        private System.Windows.Forms.Label labelXCoord;
        private System.Windows.Forms.TextBox textBoxYCoord;
        private System.Windows.Forms.TextBox textBoxXCoord;
        private System.Windows.Forms.Label labelStep;
        private System.Windows.Forms.Button buttonIncrementY;
        private System.Windows.Forms.Button buttonDecrementY;
        private System.Windows.Forms.Button buttonIncrementX;
        private System.Windows.Forms.Button buttonDecrementX;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.ComboBox comboBoxStep;
    }
}
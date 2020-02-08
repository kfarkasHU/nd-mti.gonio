namespace ND.MTI.Gonio.Forms
{
    partial class Form_ConnectionForm
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
            this.labelMotorX = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.comboBoxMotorX = new System.Windows.Forms.ComboBox();
            this.comboBoxMotorY = new System.Windows.Forms.ComboBox();
            this.labelMotorY = new System.Windows.Forms.Label();
            this.comboBoxEncoderX = new System.Windows.Forms.ComboBox();
            this.labelEncoderX = new System.Windows.Forms.Label();
            this.comboBoxEncoderY = new System.Windows.Forms.ComboBox();
            this.labelEncoderY = new System.Windows.Forms.Label();
            this.comboBoxFsmGonio = new System.Windows.Forms.ComboBox();
            this.labelFsmGonio = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelMotorX
            // 
            this.labelMotorX.AutoSize = true;
            this.labelMotorX.Location = new System.Drawing.Point(12, 9);
            this.labelMotorX.Name = "labelMotorX";
            this.labelMotorX.Size = new System.Drawing.Size(47, 13);
            this.labelMotorX.TabIndex = 0;
            this.labelMotorX.Text = "Motor X:";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(12, 141);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(142, 141);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // comboBoxMotorX
            // 
            this.comboBoxMotorX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMotorX.FormattingEnabled = true;
            this.comboBoxMotorX.Location = new System.Drawing.Point(96, 6);
            this.comboBoxMotorX.Name = "comboBoxMotorX";
            this.comboBoxMotorX.Size = new System.Drawing.Size(121, 21);
            this.comboBoxMotorX.TabIndex = 3;
            // 
            // comboBoxMotorY
            // 
            this.comboBoxMotorY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMotorY.FormattingEnabled = true;
            this.comboBoxMotorY.Location = new System.Drawing.Point(96, 33);
            this.comboBoxMotorY.Name = "comboBoxMotorY";
            this.comboBoxMotorY.Size = new System.Drawing.Size(121, 21);
            this.comboBoxMotorY.TabIndex = 5;
            // 
            // labelMotorY
            // 
            this.labelMotorY.AutoSize = true;
            this.labelMotorY.Location = new System.Drawing.Point(12, 36);
            this.labelMotorY.Name = "labelMotorY";
            this.labelMotorY.Size = new System.Drawing.Size(47, 13);
            this.labelMotorY.TabIndex = 4;
            this.labelMotorY.Text = "Motor Y:";
            // 
            // comboBoxEncoderX
            // 
            this.comboBoxEncoderX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEncoderX.FormattingEnabled = true;
            this.comboBoxEncoderX.Location = new System.Drawing.Point(96, 60);
            this.comboBoxEncoderX.Name = "comboBoxEncoderX";
            this.comboBoxEncoderX.Size = new System.Drawing.Size(121, 21);
            this.comboBoxEncoderX.TabIndex = 7;
            // 
            // labelEncoderX
            // 
            this.labelEncoderX.AutoSize = true;
            this.labelEncoderX.Location = new System.Drawing.Point(12, 63);
            this.labelEncoderX.Name = "labelEncoderX";
            this.labelEncoderX.Size = new System.Drawing.Size(60, 13);
            this.labelEncoderX.TabIndex = 6;
            this.labelEncoderX.Text = "Encoder X:";
            // 
            // comboBoxEncoderY
            // 
            this.comboBoxEncoderY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEncoderY.FormattingEnabled = true;
            this.comboBoxEncoderY.Location = new System.Drawing.Point(96, 87);
            this.comboBoxEncoderY.Name = "comboBoxEncoderY";
            this.comboBoxEncoderY.Size = new System.Drawing.Size(121, 21);
            this.comboBoxEncoderY.TabIndex = 9;
            // 
            // labelEncoderY
            // 
            this.labelEncoderY.AutoSize = true;
            this.labelEncoderY.Location = new System.Drawing.Point(12, 90);
            this.labelEncoderY.Name = "labelEncoderY";
            this.labelEncoderY.Size = new System.Drawing.Size(60, 13);
            this.labelEncoderY.TabIndex = 8;
            this.labelEncoderY.Text = "Encoder Y:";
            // 
            // comboBoxFsmGonio
            // 
            this.comboBoxFsmGonio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFsmGonio.FormattingEnabled = true;
            this.comboBoxFsmGonio.Location = new System.Drawing.Point(96, 114);
            this.comboBoxFsmGonio.Name = "comboBoxFsmGonio";
            this.comboBoxFsmGonio.Size = new System.Drawing.Size(121, 21);
            this.comboBoxFsmGonio.TabIndex = 11;
            // 
            // labelFsmGonio
            // 
            this.labelFsmGonio.AutoSize = true;
            this.labelFsmGonio.Location = new System.Drawing.Point(12, 117);
            this.labelFsmGonio.Name = "labelFsmGonio";
            this.labelFsmGonio.Size = new System.Drawing.Size(78, 13);
            this.labelFsmGonio.TabIndex = 10;
            this.labelFsmGonio.Text = "FSM Gonio 01:";
            // 
            // Form_ConnectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(227, 171);
            this.ControlBox = false;
            this.Controls.Add(this.comboBoxFsmGonio);
            this.Controls.Add(this.labelFsmGonio);
            this.Controls.Add(this.comboBoxEncoderY);
            this.Controls.Add(this.labelEncoderY);
            this.Controls.Add(this.comboBoxEncoderX);
            this.Controls.Add(this.labelEncoderX);
            this.Controls.Add(this.comboBoxMotorY);
            this.Controls.Add(this.labelMotorY);
            this.Controls.Add(this.comboBoxMotorX);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.labelMotorX);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form_ConnectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GONIO::Connection";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form_ConnectionForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelMotorX;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.ComboBox comboBoxMotorX;
        private System.Windows.Forms.ComboBox comboBoxMotorY;
        private System.Windows.Forms.Label labelMotorY;
        private System.Windows.Forms.ComboBox comboBoxEncoderX;
        private System.Windows.Forms.Label labelEncoderX;
        private System.Windows.Forms.ComboBox comboBoxEncoderY;
        private System.Windows.Forms.Label labelEncoderY;
        private System.Windows.Forms.ComboBox comboBoxFsmGonio;
        private System.Windows.Forms.Label labelFsmGonio;
    }
}
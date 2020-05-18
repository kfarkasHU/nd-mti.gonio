namespace ND.MTI.Gonio.Forms
{
    partial class Form_Finished
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Finished));
            this.labelFinished = new System.Windows.Forms.Label();
            this.pictureBoxFinished = new System.Windows.Forms.PictureBox();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonExcelExport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFinished)).BeginInit();
            this.SuspendLayout();
            // 
            // labelFinished
            // 
            this.labelFinished.AutoSize = true;
            this.labelFinished.BackColor = System.Drawing.Color.Transparent;
            this.labelFinished.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelFinished.ForeColor = System.Drawing.Color.White;
            this.labelFinished.Location = new System.Drawing.Point(179, 9);
            this.labelFinished.Name = "labelFinished";
            this.labelFinished.Size = new System.Drawing.Size(136, 33);
            this.labelFinished.TabIndex = 1;
            this.labelFinished.Text = "We did it!";
            this.labelFinished.Click += new System.EventHandler(this.LabelFinished_Click);
            // 
            // pictureBoxFinished
            // 
            this.pictureBoxFinished.Image = global::ND.MTI.Gonio.Forms.Properties.Resources.ezgif_5_017d2c77cf11;
            this.pictureBoxFinished.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxFinished.Name = "pictureBoxFinished";
            this.pictureBoxFinished.Size = new System.Drawing.Size(500, 202);
            this.pictureBoxFinished.TabIndex = 2;
            this.pictureBoxFinished.TabStop = false;
            this.pictureBoxFinished.Click += new System.EventHandler(this.PictureBoxFinished_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(413, 208);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 3;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // buttonExcelExport
            // 
            this.buttonExcelExport.Location = new System.Drawing.Point(332, 208);
            this.buttonExcelExport.Name = "buttonExcelExport";
            this.buttonExcelExport.Size = new System.Drawing.Size(75, 23);
            this.buttonExcelExport.TabIndex = 4;
            this.buttonExcelExport.Text = "Excel export";
            this.buttonExcelExport.UseVisualStyleBackColor = true;
            this.buttonExcelExport.Click += new System.EventHandler(this.ButtonExcelExport_Click);
            // 
            // Form_Finished
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(500, 238);
            this.ControlBox = false;
            this.Controls.Add(this.buttonExcelExport);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.pictureBoxFinished);
            this.Controls.Add(this.labelFinished);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Finished";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GONIO::Finished";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFinished)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelFinished;
        private System.Windows.Forms.PictureBox pictureBoxFinished;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonExcelExport;
    }
}

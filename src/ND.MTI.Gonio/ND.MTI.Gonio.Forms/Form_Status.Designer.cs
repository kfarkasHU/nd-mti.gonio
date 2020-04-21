namespace ND.MTI.Gonio.Forms
{
    partial class Form_Status
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Status));
            this.buttonClose = new System.Windows.Forms.Button();
            this.labelFSMGonioName = new System.Windows.Forms.Label();
            this.pictureBoxFSMGonio = new System.Windows.Forms.PictureBox();
            this.labelPokeysName = new System.Windows.Forms.Label();
            this.labelSSIName = new System.Windows.Forms.Label();
            this.pictureBoxPokeys57U = new System.Windows.Forms.PictureBox();
            this.pictureBoxSSIPanel = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFSMGonio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPokeys57U)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSSIPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(54, 85);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 0;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // labelFSMGonioName
            // 
            this.labelFSMGonioName.AutoSize = true;
            this.labelFSMGonioName.Location = new System.Drawing.Point(12, 9);
            this.labelFSMGonioName.Name = "labelFSMGonioName";
            this.labelFSMGonioName.Size = new System.Drawing.Size(75, 13);
            this.labelFSMGonioName.TabIndex = 1;
            this.labelFSMGonioName.Text = "FSM Gonio 01";
            // 
            // pictureBoxFSMGonio
            // 
            this.pictureBoxFSMGonio.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxFSMGonio.Image")));
            this.pictureBoxFSMGonio.Location = new System.Drawing.Point(93, 6);
            this.pictureBoxFSMGonio.Name = "pictureBoxFSMGonio";
            this.pictureBoxFSMGonio.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxFSMGonio.TabIndex = 2;
            this.pictureBoxFSMGonio.TabStop = false;
            // 
            // labelPokeysName
            // 
            this.labelPokeysName.AutoSize = true;
            this.labelPokeysName.Location = new System.Drawing.Point(12, 34);
            this.labelPokeysName.Name = "labelPokeysName";
            this.labelPokeysName.Size = new System.Drawing.Size(66, 13);
            this.labelPokeysName.TabIndex = 3;
            this.labelPokeysName.Text = "PoKeys 57U";
            // 
            // labelSSIName
            // 
            this.labelSSIName.AutoSize = true;
            this.labelSSIName.Location = new System.Drawing.Point(12, 57);
            this.labelSSIName.Name = "labelSSIName";
            this.labelSSIName.Size = new System.Drawing.Size(54, 13);
            this.labelSSIName.TabIndex = 4;
            this.labelSSIName.Text = "SSI Panel";
            // 
            // pictureBoxPokeys57U
            // 
            this.pictureBoxPokeys57U.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxPokeys57U.Image")));
            this.pictureBoxPokeys57U.Location = new System.Drawing.Point(93, 31);
            this.pictureBoxPokeys57U.Name = "pictureBoxPokeys57U";
            this.pictureBoxPokeys57U.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxPokeys57U.TabIndex = 5;
            this.pictureBoxPokeys57U.TabStop = false;
            // 
            // pictureBoxSSIPanel
            // 
            this.pictureBoxSSIPanel.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxSSIPanel.Image")));
            this.pictureBoxSSIPanel.Location = new System.Drawing.Point(93, 54);
            this.pictureBoxSSIPanel.Name = "pictureBoxSSIPanel";
            this.pictureBoxSSIPanel.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxSSIPanel.TabIndex = 6;
            this.pictureBoxSSIPanel.TabStop = false;
            // 
            // Form_Status
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(141, 120);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBoxSSIPanel);
            this.Controls.Add(this.pictureBoxPokeys57U);
            this.Controls.Add(this.labelSSIName);
            this.Controls.Add(this.labelPokeysName);
            this.Controls.Add(this.pictureBoxFSMGonio);
            this.Controls.Add(this.labelFSMGonioName);
            this.Controls.Add(this.buttonClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Status";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "GONIO::Status";
            this.Load += new System.EventHandler(this.Form_Status_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFSMGonio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPokeys57U)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSSIPanel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label labelFSMGonioName;
        private System.Windows.Forms.PictureBox pictureBoxFSMGonio;
        private System.Windows.Forms.Label labelPokeysName;
        private System.Windows.Forms.Label labelSSIName;
        private System.Windows.Forms.PictureBox pictureBoxPokeys57U;
        private System.Windows.Forms.PictureBox pictureBoxSSIPanel;
    }
}

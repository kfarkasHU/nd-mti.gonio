namespace ND.MTI.Gonio.Forms
{
    partial class Form_AdvancedForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_AdvancedForm));
            this.buttonSave = new System.Windows.Forms.Button();
            this.groupBoxOptions = new System.Windows.Forms.GroupBox();
            this.labelOffset = new System.Windows.Forms.Label();
            this.textBoxOffset = new System.Windows.Forms.TextBox();
            this.buttonStatus = new System.Windows.Forms.Button();
            this.buttonEncZero = new System.Windows.Forms.Button();
            this.numericUpDownAmplifier = new System.Windows.Forms.NumericUpDown();
            this.labelAmplifier = new System.Windows.Forms.Label();
            this.labelUseCorrection = new System.Windows.Forms.Label();
            this.checkBoxUseCorrection = new System.Windows.Forms.CheckBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBoxExternalRoute = new System.Windows.Forms.GroupBox();
            this.buttonClearExternalRoute = new System.Windows.Forms.Button();
            this.buttonBrowseExternalRoute = new System.Windows.Forms.Button();
            this.textBoxExternalRoute = new System.Windows.Forms.TextBox();
            this.labelReset0 = new System.Windows.Forms.Label();
            this.checkBoxReset0 = new System.Windows.Forms.CheckBox();
            this.labelResetV0 = new System.Windows.Forms.Label();
            this.checkBoxResetV0 = new System.Windows.Forms.CheckBox();
            this.groupBoxOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAmplifier)).BeginInit();
            this.groupBoxExternalRoute.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(173, 288);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 0;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // groupBoxOptions
            // 
            this.groupBoxOptions.Controls.Add(this.labelResetV0);
            this.groupBoxOptions.Controls.Add(this.checkBoxResetV0);
            this.groupBoxOptions.Controls.Add(this.labelReset0);
            this.groupBoxOptions.Controls.Add(this.checkBoxReset0);
            this.groupBoxOptions.Controls.Add(this.labelOffset);
            this.groupBoxOptions.Controls.Add(this.textBoxOffset);
            this.groupBoxOptions.Controls.Add(this.buttonStatus);
            this.groupBoxOptions.Controls.Add(this.buttonEncZero);
            this.groupBoxOptions.Controls.Add(this.numericUpDownAmplifier);
            this.groupBoxOptions.Controls.Add(this.labelAmplifier);
            this.groupBoxOptions.Controls.Add(this.labelUseCorrection);
            this.groupBoxOptions.Controls.Add(this.checkBoxUseCorrection);
            this.groupBoxOptions.Location = new System.Drawing.Point(12, 12);
            this.groupBoxOptions.Name = "groupBoxOptions";
            this.groupBoxOptions.Size = new System.Drawing.Size(236, 187);
            this.groupBoxOptions.TabIndex = 1;
            this.groupBoxOptions.TabStop = false;
            this.groupBoxOptions.Text = "Options";
            // 
            // labelOffset
            // 
            this.labelOffset.AutoSize = true;
            this.labelOffset.Location = new System.Drawing.Point(6, 71);
            this.labelOffset.Name = "labelOffset";
            this.labelOffset.Size = new System.Drawing.Size(35, 13);
            this.labelOffset.TabIndex = 6;
            this.labelOffset.Text = "Offset";
            // 
            // textBoxOffset
            // 
            this.textBoxOffset.Location = new System.Drawing.Point(146, 68);
            this.textBoxOffset.Name = "textBoxOffset";
            this.textBoxOffset.Size = new System.Drawing.Size(69, 20);
            this.textBoxOffset.TabIndex = 5;
            // 
            // buttonStatus
            // 
            this.buttonStatus.Location = new System.Drawing.Point(6, 158);
            this.buttonStatus.Name = "buttonStatus";
            this.buttonStatus.Size = new System.Drawing.Size(75, 23);
            this.buttonStatus.TabIndex = 4;
            this.buttonStatus.Text = "Status";
            this.buttonStatus.UseVisualStyleBackColor = true;
            this.buttonStatus.Click += new System.EventHandler(this.ButtonStatus_Click);
            // 
            // buttonEncZero
            // 
            this.buttonEncZero.Location = new System.Drawing.Point(155, 158);
            this.buttonEncZero.Name = "buttonEncZero";
            this.buttonEncZero.Size = new System.Drawing.Size(75, 23);
            this.buttonEncZero.TabIndex = 3;
            this.buttonEncZero.Text = "ENC ZERO";
            this.buttonEncZero.UseVisualStyleBackColor = true;
            this.buttonEncZero.Click += new System.EventHandler(this.ButtonEncZero_Click);
            // 
            // numericUpDownAmplifier
            // 
            this.numericUpDownAmplifier.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numericUpDownAmplifier.Location = new System.Drawing.Point(148, 42);
            this.numericUpDownAmplifier.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownAmplifier.Name = "numericUpDownAmplifier";
            this.numericUpDownAmplifier.Size = new System.Drawing.Size(67, 20);
            this.numericUpDownAmplifier.TabIndex = 3;
            // 
            // labelAmplifier
            // 
            this.labelAmplifier.AutoSize = true;
            this.labelAmplifier.Location = new System.Drawing.Point(6, 44);
            this.labelAmplifier.Name = "labelAmplifier";
            this.labelAmplifier.Size = new System.Drawing.Size(46, 13);
            this.labelAmplifier.TabIndex = 2;
            this.labelAmplifier.Text = "Amplifier";
            // 
            // labelUseCorrection
            // 
            this.labelUseCorrection.AutoSize = true;
            this.labelUseCorrection.Location = new System.Drawing.Point(6, 20);
            this.labelUseCorrection.Name = "labelUseCorrection";
            this.labelUseCorrection.Size = new System.Drawing.Size(106, 13);
            this.labelUseCorrection.TabIndex = 1;
            this.labelUseCorrection.Text = "Calibration correction";
            // 
            // checkBoxUseCorrection
            // 
            this.checkBoxUseCorrection.AutoSize = true;
            this.checkBoxUseCorrection.Location = new System.Drawing.Point(172, 19);
            this.checkBoxUseCorrection.Name = "checkBoxUseCorrection";
            this.checkBoxUseCorrection.Size = new System.Drawing.Size(43, 17);
            this.checkBoxUseCorrection.TabIndex = 0;
            this.checkBoxUseCorrection.Text = "use";
            this.checkBoxUseCorrection.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(12, 288);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // groupBoxExternalRoute
            // 
            this.groupBoxExternalRoute.Controls.Add(this.buttonClearExternalRoute);
            this.groupBoxExternalRoute.Controls.Add(this.buttonBrowseExternalRoute);
            this.groupBoxExternalRoute.Controls.Add(this.textBoxExternalRoute);
            this.groupBoxExternalRoute.Location = new System.Drawing.Point(12, 205);
            this.groupBoxExternalRoute.Name = "groupBoxExternalRoute";
            this.groupBoxExternalRoute.Size = new System.Drawing.Size(236, 77);
            this.groupBoxExternalRoute.TabIndex = 3;
            this.groupBoxExternalRoute.TabStop = false;
            this.groupBoxExternalRoute.Text = "External route";
            // 
            // buttonClearExternalRoute
            // 
            this.buttonClearExternalRoute.Enabled = false;
            this.buttonClearExternalRoute.Location = new System.Drawing.Point(74, 45);
            this.buttonClearExternalRoute.Name = "buttonClearExternalRoute";
            this.buttonClearExternalRoute.Size = new System.Drawing.Size(75, 23);
            this.buttonClearExternalRoute.TabIndex = 2;
            this.buttonClearExternalRoute.Text = "Clear";
            this.buttonClearExternalRoute.UseVisualStyleBackColor = true;
            this.buttonClearExternalRoute.Click += new System.EventHandler(this.ButtonClearExternalRoute_Click);
            // 
            // buttonBrowseExternalRoute
            // 
            this.buttonBrowseExternalRoute.Location = new System.Drawing.Point(155, 45);
            this.buttonBrowseExternalRoute.Name = "buttonBrowseExternalRoute";
            this.buttonBrowseExternalRoute.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowseExternalRoute.TabIndex = 1;
            this.buttonBrowseExternalRoute.Text = "Browse";
            this.buttonBrowseExternalRoute.UseVisualStyleBackColor = true;
            this.buttonBrowseExternalRoute.Click += new System.EventHandler(this.ButtonBrowseExternalRoute_Click);
            // 
            // textBoxExternalRoute
            // 
            this.textBoxExternalRoute.Enabled = false;
            this.textBoxExternalRoute.Location = new System.Drawing.Point(6, 19);
            this.textBoxExternalRoute.Name = "textBoxExternalRoute";
            this.textBoxExternalRoute.Size = new System.Drawing.Size(224, 20);
            this.textBoxExternalRoute.TabIndex = 0;
            // 
            // labelReset0
            // 
            this.labelReset0.AutoSize = true;
            this.labelReset0.Location = new System.Drawing.Point(6, 95);
            this.labelReset0.Name = "labelReset0";
            this.labelReset0.Size = new System.Drawing.Size(124, 13);
            this.labelReset0.TabIndex = 8;
            this.labelReset0.Text = "Reset to 0 when finished";
            // 
            // checkBoxReset0
            // 
            this.checkBoxReset0.AutoSize = true;
            this.checkBoxReset0.Location = new System.Drawing.Point(172, 94);
            this.checkBoxReset0.Name = "checkBoxReset0";
            this.checkBoxReset0.Size = new System.Drawing.Size(43, 17);
            this.checkBoxReset0.TabIndex = 7;
            this.checkBoxReset0.Text = "use";
            this.checkBoxReset0.UseVisualStyleBackColor = true;
            // 
            // labelResetV0
            // 
            this.labelResetV0.AutoSize = true;
            this.labelResetV0.Location = new System.Drawing.Point(6, 118);
            this.labelResetV0.Name = "labelResetV0";
            this.labelResetV0.Size = new System.Drawing.Size(131, 13);
            this.labelResetV0.TabIndex = 10;
            this.labelResetV0.Text = "Reset to V0 when finished";
            // 
            // checkBoxResetV0
            // 
            this.checkBoxResetV0.AutoSize = true;
            this.checkBoxResetV0.Location = new System.Drawing.Point(172, 117);
            this.checkBoxResetV0.Name = "checkBoxResetV0";
            this.checkBoxResetV0.Size = new System.Drawing.Size(43, 17);
            this.checkBoxResetV0.TabIndex = 9;
            this.checkBoxResetV0.Text = "use";
            this.checkBoxResetV0.UseVisualStyleBackColor = true;
            // 
            // Form_AdvancedForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 323);
            this.ControlBox = false;
            this.Controls.Add(this.groupBoxExternalRoute);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.groupBoxOptions);
            this.Controls.Add(this.buttonSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_AdvancedForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "GONIO::Advanced";
            this.groupBoxOptions.ResumeLayout(false);
            this.groupBoxOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAmplifier)).EndInit();
            this.groupBoxExternalRoute.ResumeLayout(false);
            this.groupBoxExternalRoute.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.GroupBox groupBoxOptions;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelUseCorrection;
        private System.Windows.Forms.CheckBox checkBoxUseCorrection;
        private System.Windows.Forms.NumericUpDown numericUpDownAmplifier;
        private System.Windows.Forms.Label labelAmplifier;
        private System.Windows.Forms.Button buttonEncZero;
        private System.Windows.Forms.Button buttonStatus;
        private System.Windows.Forms.Label labelOffset;
        private System.Windows.Forms.TextBox textBoxOffset;
        private System.Windows.Forms.GroupBox groupBoxExternalRoute;
        private System.Windows.Forms.Button buttonClearExternalRoute;
        private System.Windows.Forms.Button buttonBrowseExternalRoute;
        private System.Windows.Forms.TextBox textBoxExternalRoute;
        private System.Windows.Forms.Label labelResetV0;
        private System.Windows.Forms.CheckBox checkBoxResetV0;
        private System.Windows.Forms.Label labelReset0;
        private System.Windows.Forms.CheckBox checkBoxReset0;
    }
}

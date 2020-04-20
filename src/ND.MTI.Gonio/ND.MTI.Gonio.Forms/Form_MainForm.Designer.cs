namespace ND.MTI.Gonio.Forms
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
            this.checkBoxXAuto = new System.Windows.Forms.CheckBox();
            this.buttonNew = new System.Windows.Forms.Button();
            this.buttonGoToZero = new System.Windows.Forms.Button();
            this.buttonGoToVirtualZero = new System.Windows.Forms.Button();
            this.buttonSetVirtualZero = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonContinue = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonPause = new System.Windows.Forms.Button();
            this.buttonResults = new System.Windows.Forms.Button();
            this.buttonExcelExport = new System.Windows.Forms.Button();
            this.buttonEdtExport = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.labelX = new System.Windows.Forms.Label();
            this.labelY = new System.Windows.Forms.Label();
            this.textBoxStartX = new System.Windows.Forms.TextBox();
            this.textBoxStartY = new System.Windows.Forms.TextBox();
            this.textBoxEndY = new System.Windows.Forms.TextBox();
            this.textBoxEndX = new System.Windows.Forms.TextBox();
            this.textBoxStepY = new System.Windows.Forms.TextBox();
            this.textBoxStepX = new System.Windows.Forms.TextBox();
            this.checkBoxYAuto = new System.Windows.Forms.CheckBox();
            this.labelStart = new System.Windows.Forms.Label();
            this.labelEnd = new System.Windows.Forms.Label();
            this.labelStep = new System.Windows.Forms.Label();
            this.labelCurrentPosition = new System.Windows.Forms.Label();
            this.textBoxXCurrentPosition = new System.Windows.Forms.TextBox();
            this.textBoxYCurrentPosition = new System.Windows.Forms.TextBox();
            this.buttonRegistration = new System.Windows.Forms.Button();
            this.buttonEncZero = new System.Windows.Forms.Button();
            this.buttonStatus = new System.Windows.Forms.Button();
            this.labelMeasuredIlluminationText = new System.Windows.Forms.Label();
            this.labelStatusText = new System.Windows.Forms.Label();
            this.labelStatusValue = new System.Windows.Forms.Label();
            this.textBoxMeasuredIlluminationExtension = new System.Windows.Forms.Label();
            this.textBoxMeasuredIllumination = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // checkBoxXAuto
            // 
            this.checkBoxXAuto.AutoSize = true;
            this.checkBoxXAuto.Location = new System.Drawing.Point(291, 31);
            this.checkBoxXAuto.Name = "checkBoxXAuto";
            this.checkBoxXAuto.Size = new System.Drawing.Size(47, 17);
            this.checkBoxXAuto.TabIndex = 0;
            this.checkBoxXAuto.Text = "auto";
            this.checkBoxXAuto.UseVisualStyleBackColor = true;
            this.checkBoxXAuto.CheckedChanged += new System.EventHandler(this.CheckBoxXAuto_CheckedChanged);
            // 
            // buttonNew
            // 
            this.buttonNew.Location = new System.Drawing.Point(10, 208);
            this.buttonNew.Name = "buttonNew";
            this.buttonNew.Size = new System.Drawing.Size(75, 23);
            this.buttonNew.TabIndex = 2;
            this.buttonNew.Text = "New";
            this.buttonNew.UseVisualStyleBackColor = true;
            this.buttonNew.Click += new System.EventHandler(this.ButtonNew_Click);
            // 
            // buttonGoToZero
            // 
            this.buttonGoToZero.Location = new System.Drawing.Point(10, 150);
            this.buttonGoToZero.Name = "buttonGoToZero";
            this.buttonGoToZero.Size = new System.Drawing.Size(75, 23);
            this.buttonGoToZero.TabIndex = 4;
            this.buttonGoToZero.Text = "Go to 0";
            this.buttonGoToZero.UseVisualStyleBackColor = true;
            this.buttonGoToZero.Click += new System.EventHandler(this.ButtonGoToZero_Click);
            // 
            // buttonGoToVirtualZero
            // 
            this.buttonGoToVirtualZero.Enabled = false;
            this.buttonGoToVirtualZero.Location = new System.Drawing.Point(91, 150);
            this.buttonGoToVirtualZero.Name = "buttonGoToVirtualZero";
            this.buttonGoToVirtualZero.Size = new System.Drawing.Size(75, 23);
            this.buttonGoToVirtualZero.TabIndex = 7;
            this.buttonGoToVirtualZero.Text = "Go to V0";
            this.buttonGoToVirtualZero.UseVisualStyleBackColor = true;
            this.buttonGoToVirtualZero.Click += new System.EventHandler(this.ButtonGoToVirtualZero_Click);
            // 
            // buttonSetVirtualZero
            // 
            this.buttonSetVirtualZero.Location = new System.Drawing.Point(91, 179);
            this.buttonSetVirtualZero.Name = "buttonSetVirtualZero";
            this.buttonSetVirtualZero.Size = new System.Drawing.Size(75, 23);
            this.buttonSetVirtualZero.TabIndex = 6;
            this.buttonSetVirtualZero.Text = "Set V0";
            this.buttonSetVirtualZero.UseVisualStyleBackColor = true;
            this.buttonSetVirtualZero.Click += new System.EventHandler(this.ButtonSetVirtualZero_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Enabled = false;
            this.buttonStop.Location = new System.Drawing.Point(253, 150);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(75, 23);
            this.buttonStop.TabIndex = 13;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.ButtonStop_Click);
            // 
            // buttonContinue
            // 
            this.buttonContinue.Enabled = false;
            this.buttonContinue.Location = new System.Drawing.Point(253, 179);
            this.buttonContinue.Name = "buttonContinue";
            this.buttonContinue.Size = new System.Drawing.Size(75, 23);
            this.buttonContinue.TabIndex = 12;
            this.buttonContinue.Text = "Continue";
            this.buttonContinue.UseVisualStyleBackColor = true;
            this.buttonContinue.Click += new System.EventHandler(this.ButtonContinue_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(172, 150);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 10;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.ButtonStart_Click);
            // 
            // buttonPause
            // 
            this.buttonPause.Enabled = false;
            this.buttonPause.Location = new System.Drawing.Point(172, 179);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(75, 23);
            this.buttonPause.TabIndex = 9;
            this.buttonPause.Text = "Pause";
            this.buttonPause.UseVisualStyleBackColor = true;
            this.buttonPause.Click += new System.EventHandler(this.ButtonPause_Click);
            // 
            // buttonResults
            // 
            this.buttonResults.Location = new System.Drawing.Point(172, 208);
            this.buttonResults.Name = "buttonResults";
            this.buttonResults.Size = new System.Drawing.Size(75, 23);
            this.buttonResults.TabIndex = 8;
            this.buttonResults.Text = "Results";
            this.buttonResults.UseVisualStyleBackColor = true;
            this.buttonResults.Click += new System.EventHandler(this.ButtonResults_Click);
            // 
            // buttonExcelExport
            // 
            this.buttonExcelExport.Enabled = false;
            this.buttonExcelExport.Location = new System.Drawing.Point(332, 150);
            this.buttonExcelExport.Name = "buttonExcelExport";
            this.buttonExcelExport.Size = new System.Drawing.Size(75, 23);
            this.buttonExcelExport.TabIndex = 16;
            this.buttonExcelExport.Text = "Excel export";
            this.buttonExcelExport.UseVisualStyleBackColor = true;
            this.buttonExcelExport.Click += new System.EventHandler(this.ButtonExcelExport_Click);
            // 
            // buttonEdtExport
            // 
            this.buttonEdtExport.Enabled = false;
            this.buttonEdtExport.Location = new System.Drawing.Point(332, 179);
            this.buttonEdtExport.Name = "buttonEdtExport";
            this.buttonEdtExport.Size = new System.Drawing.Size(75, 23);
            this.buttonEdtExport.TabIndex = 15;
            this.buttonEdtExport.Text = "EDT export";
            this.buttonEdtExport.UseVisualStyleBackColor = true;
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(332, 208);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 23);
            this.buttonExit.TabIndex = 14;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.ButtonExit_Click);
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Location = new System.Drawing.Point(7, 32);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(14, 13);
            this.labelX.TabIndex = 19;
            this.labelX.Text = "X";
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.Location = new System.Drawing.Point(7, 55);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(14, 13);
            this.labelY.TabIndex = 20;
            this.labelY.Text = "Y";
            // 
            // textBoxStartX
            // 
            this.textBoxStartX.Location = new System.Drawing.Point(48, 29);
            this.textBoxStartX.Name = "textBoxStartX";
            this.textBoxStartX.Size = new System.Drawing.Size(75, 20);
            this.textBoxStartX.TabIndex = 21;
            // 
            // textBoxStartY
            // 
            this.textBoxStartY.Location = new System.Drawing.Point(48, 52);
            this.textBoxStartY.Name = "textBoxStartY";
            this.textBoxStartY.Size = new System.Drawing.Size(75, 20);
            this.textBoxStartY.TabIndex = 22;
            // 
            // textBoxEndY
            // 
            this.textBoxEndY.Location = new System.Drawing.Point(129, 52);
            this.textBoxEndY.Name = "textBoxEndY";
            this.textBoxEndY.Size = new System.Drawing.Size(75, 20);
            this.textBoxEndY.TabIndex = 24;
            // 
            // textBoxEndX
            // 
            this.textBoxEndX.Location = new System.Drawing.Point(129, 29);
            this.textBoxEndX.Name = "textBoxEndX";
            this.textBoxEndX.Size = new System.Drawing.Size(75, 20);
            this.textBoxEndX.TabIndex = 23;
            // 
            // textBoxStepY
            // 
            this.textBoxStepY.Enabled = false;
            this.textBoxStepY.Location = new System.Drawing.Point(210, 52);
            this.textBoxStepY.Name = "textBoxStepY";
            this.textBoxStepY.Size = new System.Drawing.Size(75, 20);
            this.textBoxStepY.TabIndex = 26;
            // 
            // textBoxStepX
            // 
            this.textBoxStepX.Enabled = false;
            this.textBoxStepX.Location = new System.Drawing.Point(210, 29);
            this.textBoxStepX.Name = "textBoxStepX";
            this.textBoxStepX.Size = new System.Drawing.Size(75, 20);
            this.textBoxStepX.TabIndex = 25;
            // 
            // checkBoxYAuto
            // 
            this.checkBoxYAuto.AutoSize = true;
            this.checkBoxYAuto.Location = new System.Drawing.Point(291, 54);
            this.checkBoxYAuto.Name = "checkBoxYAuto";
            this.checkBoxYAuto.Size = new System.Drawing.Size(47, 17);
            this.checkBoxYAuto.TabIndex = 27;
            this.checkBoxYAuto.Text = "auto";
            this.checkBoxYAuto.UseVisualStyleBackColor = true;
            this.checkBoxYAuto.CheckedChanged += new System.EventHandler(this.CheckBoxYAuto_CheckedChanged);
            // 
            // labelStart
            // 
            this.labelStart.AutoSize = true;
            this.labelStart.Location = new System.Drawing.Point(88, 9);
            this.labelStart.Name = "labelStart";
            this.labelStart.Size = new System.Drawing.Size(29, 13);
            this.labelStart.TabIndex = 28;
            this.labelStart.Text = "Start";
            // 
            // labelEnd
            // 
            this.labelEnd.AutoSize = true;
            this.labelEnd.Location = new System.Drawing.Point(169, 9);
            this.labelEnd.Name = "labelEnd";
            this.labelEnd.Size = new System.Drawing.Size(26, 13);
            this.labelEnd.TabIndex = 29;
            this.labelEnd.Text = "End";
            // 
            // labelStep
            // 
            this.labelStep.AutoSize = true;
            this.labelStep.Location = new System.Drawing.Point(250, 9);
            this.labelStep.Name = "labelStep";
            this.labelStep.Size = new System.Drawing.Size(29, 13);
            this.labelStep.TabIndex = 30;
            this.labelStep.Text = "Step";
            // 
            // labelCurrentPosition
            // 
            this.labelCurrentPosition.AutoSize = true;
            this.labelCurrentPosition.Location = new System.Drawing.Point(343, 9);
            this.labelCurrentPosition.Name = "labelCurrentPosition";
            this.labelCurrentPosition.Size = new System.Drawing.Size(61, 13);
            this.labelCurrentPosition.TabIndex = 40;
            this.labelCurrentPosition.Text = "Current pos";
            // 
            // textBoxXCurrentPosition
            // 
            this.textBoxXCurrentPosition.Enabled = false;
            this.textBoxXCurrentPosition.Location = new System.Drawing.Point(335, 29);
            this.textBoxXCurrentPosition.Name = "textBoxXCurrentPosition";
            this.textBoxXCurrentPosition.ReadOnly = true;
            this.textBoxXCurrentPosition.Size = new System.Drawing.Size(75, 20);
            this.textBoxXCurrentPosition.TabIndex = 41;
            // 
            // textBoxYCurrentPosition
            // 
            this.textBoxYCurrentPosition.Enabled = false;
            this.textBoxYCurrentPosition.Location = new System.Drawing.Point(335, 51);
            this.textBoxYCurrentPosition.Name = "textBoxYCurrentPosition";
            this.textBoxYCurrentPosition.ReadOnly = true;
            this.textBoxYCurrentPosition.Size = new System.Drawing.Size(75, 20);
            this.textBoxYCurrentPosition.TabIndex = 42;
            // 
            // buttonRegistration
            // 
            this.buttonRegistration.Location = new System.Drawing.Point(253, 208);
            this.buttonRegistration.Name = "buttonRegistration";
            this.buttonRegistration.Size = new System.Drawing.Size(75, 23);
            this.buttonRegistration.TabIndex = 43;
            this.buttonRegistration.Text = "Registration";
            this.buttonRegistration.UseVisualStyleBackColor = true;
            this.buttonRegistration.Click += new System.EventHandler(this.ButtonRegistration_Click);
            // 
            // buttonEncZero
            // 
            this.buttonEncZero.Location = new System.Drawing.Point(10, 179);
            this.buttonEncZero.Name = "buttonEncZero";
            this.buttonEncZero.Size = new System.Drawing.Size(75, 23);
            this.buttonEncZero.TabIndex = 44;
            this.buttonEncZero.Text = "ENC ZERO";
            this.buttonEncZero.UseVisualStyleBackColor = true;
            this.buttonEncZero.Click += new System.EventHandler(this.ButtonEncZero_Click);
            // 
            // buttonStatus
            // 
            this.buttonStatus.Location = new System.Drawing.Point(91, 208);
            this.buttonStatus.Name = "buttonStatus";
            this.buttonStatus.Size = new System.Drawing.Size(75, 23);
            this.buttonStatus.TabIndex = 45;
            this.buttonStatus.Text = "Status";
            this.buttonStatus.UseVisualStyleBackColor = true;
            // 
            // labelMeasuredIlluminationText
            // 
            this.labelMeasuredIlluminationText.AutoSize = true;
            this.labelMeasuredIlluminationText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelMeasuredIlluminationText.Location = new System.Drawing.Point(12, 86);
            this.labelMeasuredIlluminationText.Name = "labelMeasuredIlluminationText";
            this.labelMeasuredIlluminationText.Size = new System.Drawing.Size(71, 15);
            this.labelMeasuredIlluminationText.TabIndex = 46;
            this.labelMeasuredIlluminationText.Text = "Illumination";
            // 
            // labelStatusText
            // 
            this.labelStatusText.AutoSize = true;
            this.labelStatusText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelStatusText.Location = new System.Drawing.Point(12, 109);
            this.labelStatusText.Name = "labelStatusText";
            this.labelStatusText.Size = new System.Drawing.Size(41, 15);
            this.labelStatusText.TabIndex = 47;
            this.labelStatusText.Text = "Status";
            // 
            // labelStatusValue
            // 
            this.labelStatusValue.AutoSize = true;
            this.labelStatusValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelStatusValue.Location = new System.Drawing.Point(116, 109);
            this.labelStatusValue.Name = "labelStatusValue";
            this.labelStatusValue.Size = new System.Drawing.Size(47, 15);
            this.labelStatusValue.TabIndex = 48;
            this.labelStatusValue.Text = "READY";
            // 
            // textBoxMeasuredIlluminationExtension
            // 
            this.textBoxMeasuredIlluminationExtension.AutoSize = true;
            this.textBoxMeasuredIlluminationExtension.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxMeasuredIlluminationExtension.Location = new System.Drawing.Point(169, 86);
            this.textBoxMeasuredIlluminationExtension.Name = "textBoxMeasuredIlluminationExtension";
            this.textBoxMeasuredIlluminationExtension.Size = new System.Drawing.Size(16, 15);
            this.textBoxMeasuredIlluminationExtension.TabIndex = 49;
            this.textBoxMeasuredIlluminationExtension.Text = "lx";
            // 
            // textBoxMeasuredIllumination
            // 
            this.textBoxMeasuredIllumination.Location = new System.Drawing.Point(88, 85);
            this.textBoxMeasuredIllumination.Name = "textBoxMeasuredIllumination";
            this.textBoxMeasuredIllumination.ReadOnly = true;
            this.textBoxMeasuredIllumination.Size = new System.Drawing.Size(75, 20);
            this.textBoxMeasuredIllumination.TabIndex = 50;
            // 
            // Form_MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 240);
            this.ControlBox = false;
            this.Controls.Add(this.textBoxMeasuredIllumination);
            this.Controls.Add(this.textBoxMeasuredIlluminationExtension);
            this.Controls.Add(this.labelStatusValue);
            this.Controls.Add(this.labelStatusText);
            this.Controls.Add(this.labelMeasuredIlluminationText);
            this.Controls.Add(this.buttonStatus);
            this.Controls.Add(this.buttonEncZero);
            this.Controls.Add(this.buttonRegistration);
            this.Controls.Add(this.textBoxYCurrentPosition);
            this.Controls.Add(this.textBoxXCurrentPosition);
            this.Controls.Add(this.labelCurrentPosition);
            this.Controls.Add(this.labelStep);
            this.Controls.Add(this.labelEnd);
            this.Controls.Add(this.labelStart);
            this.Controls.Add(this.checkBoxYAuto);
            this.Controls.Add(this.textBoxStepY);
            this.Controls.Add(this.textBoxStepX);
            this.Controls.Add(this.textBoxEndY);
            this.Controls.Add(this.textBoxEndX);
            this.Controls.Add(this.textBoxStartY);
            this.Controls.Add(this.textBoxStartX);
            this.Controls.Add(this.labelY);
            this.Controls.Add(this.labelX);
            this.Controls.Add(this.buttonExcelExport);
            this.Controls.Add(this.buttonEdtExport);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonContinue);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.buttonPause);
            this.Controls.Add(this.buttonResults);
            this.Controls.Add(this.buttonGoToVirtualZero);
            this.Controls.Add(this.buttonSetVirtualZero);
            this.Controls.Add(this.buttonGoToZero);
            this.Controls.Add(this.buttonNew);
            this.Controls.Add(this.checkBoxXAuto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form_MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GONIO";
            this.Load += new System.EventHandler(this.Form_MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxXAuto;
        private System.Windows.Forms.Button buttonNew;
        private System.Windows.Forms.Button buttonGoToZero;
        private System.Windows.Forms.Button buttonGoToVirtualZero;
        private System.Windows.Forms.Button buttonSetVirtualZero;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonContinue;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonPause;
        private System.Windows.Forms.Button buttonResults;
        private System.Windows.Forms.Button buttonExcelExport;
        private System.Windows.Forms.Button buttonEdtExport;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.TextBox textBoxStartX;
        private System.Windows.Forms.TextBox textBoxStartY;
        private System.Windows.Forms.TextBox textBoxEndY;
        private System.Windows.Forms.TextBox textBoxEndX;
        private System.Windows.Forms.TextBox textBoxStepY;
        private System.Windows.Forms.TextBox textBoxStepX;
        private System.Windows.Forms.CheckBox checkBoxYAuto;
        private System.Windows.Forms.Label labelStart;
        private System.Windows.Forms.Label labelEnd;
        private System.Windows.Forms.Label labelStep;
        private System.Windows.Forms.Label labelCurrentPosition;
        private System.Windows.Forms.TextBox textBoxXCurrentPosition;
        private System.Windows.Forms.TextBox textBoxYCurrentPosition;
        private System.Windows.Forms.Button buttonRegistration;
        private System.Windows.Forms.Button buttonEncZero;
        private System.Windows.Forms.Button buttonStatus;
        private System.Windows.Forms.Label labelMeasuredIlluminationText;
        private System.Windows.Forms.Label labelStatusText;
        private System.Windows.Forms.Label labelStatusValue;
        private System.Windows.Forms.Label textBoxMeasuredIlluminationExtension;
        private System.Windows.Forms.TextBox textBoxMeasuredIllumination;
    }
}

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_MainForm));
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
            this.labelStatusText = new System.Windows.Forms.Label();
            this.textBoxHoldTime = new System.Windows.Forms.TextBox();
            this.LabelHold = new System.Windows.Forms.Label();
            this.textBoxMeasurementStatus = new System.Windows.Forms.TextBox();
            this.buttonAdvanced = new System.Windows.Forms.Button();
            this.textBoxLuminousIntensivity = new System.Windows.Forms.TextBox();
            this.labelLuminousIntensivity = new System.Windows.Forms.Label();
            this.textBoxVirtualZero = new System.Windows.Forms.TextBox();
            this.labelVirtualZero = new System.Windows.Forms.Label();
            this.progressBarProgress = new System.Windows.Forms.ProgressBar();
            this.labelPercentage = new System.Windows.Forms.Label();
            this.labelLuminousUnit = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // checkBoxXAuto
            // 
            this.checkBoxXAuto.AutoSize = true;
            this.checkBoxXAuto.Location = new System.Drawing.Point(257, 31);
            this.checkBoxXAuto.Name = "checkBoxXAuto";
            this.checkBoxXAuto.Size = new System.Drawing.Size(47, 17);
            this.checkBoxXAuto.TabIndex = 3;
            this.checkBoxXAuto.Text = "auto";
            this.checkBoxXAuto.UseVisualStyleBackColor = true;
            this.checkBoxXAuto.CheckedChanged += new System.EventHandler(this.CheckBoxXAuto_CheckedChanged);
            // 
            // buttonNew
            // 
            this.buttonNew.Location = new System.Drawing.Point(10, 130);
            this.buttonNew.Name = "buttonNew";
            this.buttonNew.Size = new System.Drawing.Size(75, 23);
            this.buttonNew.TabIndex = 16;
            this.buttonNew.Text = "New";
            this.buttonNew.UseVisualStyleBackColor = true;
            this.buttonNew.Click += new System.EventHandler(this.ButtonNew_Click);
            // 
            // buttonGoToZero
            // 
            this.buttonGoToZero.Location = new System.Drawing.Point(91, 130);
            this.buttonGoToZero.Name = "buttonGoToZero";
            this.buttonGoToZero.Size = new System.Drawing.Size(113, 23);
            this.buttonGoToZero.TabIndex = 17;
            this.buttonGoToZero.Text = "Go to NULL";
            this.buttonGoToZero.UseVisualStyleBackColor = true;
            this.buttonGoToZero.Click += new System.EventHandler(this.ButtonGoToZero_Click);
            // 
            // buttonGoToVirtualZero
            // 
            this.buttonGoToVirtualZero.Enabled = false;
            this.buttonGoToVirtualZero.Location = new System.Drawing.Point(91, 159);
            this.buttonGoToVirtualZero.Name = "buttonGoToVirtualZero";
            this.buttonGoToVirtualZero.Size = new System.Drawing.Size(113, 23);
            this.buttonGoToVirtualZero.TabIndex = 19;
            this.buttonGoToVirtualZero.Text = "Go to virtual NULL";
            this.buttonGoToVirtualZero.UseVisualStyleBackColor = true;
            this.buttonGoToVirtualZero.Click += new System.EventHandler(this.ButtonGoToVirtualZero_Click);
            // 
            // buttonSetVirtualZero
            // 
            this.buttonSetVirtualZero.Location = new System.Drawing.Point(91, 188);
            this.buttonSetVirtualZero.Name = "buttonSetVirtualZero";
            this.buttonSetVirtualZero.Size = new System.Drawing.Size(113, 23);
            this.buttonSetVirtualZero.TabIndex = 18;
            this.buttonSetVirtualZero.Text = "Set virtual NULL";
            this.buttonSetVirtualZero.UseVisualStyleBackColor = true;
            this.buttonSetVirtualZero.Click += new System.EventHandler(this.ButtonSetVirtualZero_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Enabled = false;
            this.buttonStop.Location = new System.Drawing.Point(210, 217);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(75, 23);
            this.buttonStop.TabIndex = 14;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.ButtonStop_Click);
            // 
            // buttonContinue
            // 
            this.buttonContinue.Enabled = false;
            this.buttonContinue.Location = new System.Drawing.Point(210, 188);
            this.buttonContinue.Name = "buttonContinue";
            this.buttonContinue.Size = new System.Drawing.Size(75, 23);
            this.buttonContinue.TabIndex = 13;
            this.buttonContinue.Text = "Continue";
            this.buttonContinue.UseVisualStyleBackColor = true;
            this.buttonContinue.Click += new System.EventHandler(this.ButtonContinue_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(210, 130);
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
            this.buttonPause.Location = new System.Drawing.Point(210, 159);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(75, 23);
            this.buttonPause.TabIndex = 12;
            this.buttonPause.Text = "Pause";
            this.buttonPause.UseVisualStyleBackColor = true;
            this.buttonPause.Click += new System.EventHandler(this.ButtonPause_Click);
            // 
            // buttonResults
            // 
            this.buttonResults.Location = new System.Drawing.Point(10, 188);
            this.buttonResults.Name = "buttonResults";
            this.buttonResults.Size = new System.Drawing.Size(75, 23);
            this.buttonResults.TabIndex = 11;
            this.buttonResults.Text = "Results";
            this.buttonResults.UseVisualStyleBackColor = true;
            this.buttonResults.Click += new System.EventHandler(this.ButtonResults_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(391, 280);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 23);
            this.buttonExit.TabIndex = 23;
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
            this.textBoxStartX.Size = new System.Drawing.Size(99, 20);
            this.textBoxStartX.TabIndex = 1;
            this.textBoxStartX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxStartY
            // 
            this.textBoxStartY.Location = new System.Drawing.Point(48, 52);
            this.textBoxStartY.Name = "textBoxStartY";
            this.textBoxStartY.Size = new System.Drawing.Size(99, 20);
            this.textBoxStartY.TabIndex = 5;
            this.textBoxStartY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxEndY
            // 
            this.textBoxEndY.Enabled = false;
            this.textBoxEndY.Location = new System.Drawing.Point(153, 52);
            this.textBoxEndY.Name = "textBoxEndY";
            this.textBoxEndY.Size = new System.Drawing.Size(98, 20);
            this.textBoxEndY.TabIndex = 6;
            this.textBoxEndY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxEndX
            // 
            this.textBoxEndX.Enabled = false;
            this.textBoxEndX.Location = new System.Drawing.Point(153, 29);
            this.textBoxEndX.Name = "textBoxEndX";
            this.textBoxEndX.Size = new System.Drawing.Size(98, 20);
            this.textBoxEndX.TabIndex = 2;
            this.textBoxEndX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxStepY
            // 
            this.textBoxStepY.Enabled = false;
            this.textBoxStepY.Location = new System.Drawing.Point(310, 51);
            this.textBoxStepY.Name = "textBoxStepY";
            this.textBoxStepY.Size = new System.Drawing.Size(75, 20);
            this.textBoxStepY.TabIndex = 8;
            this.textBoxStepY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxStepX
            // 
            this.textBoxStepX.Enabled = false;
            this.textBoxStepX.Location = new System.Drawing.Point(310, 28);
            this.textBoxStepX.Name = "textBoxStepX";
            this.textBoxStepX.Size = new System.Drawing.Size(75, 20);
            this.textBoxStepX.TabIndex = 4;
            this.textBoxStepX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // checkBoxYAuto
            // 
            this.checkBoxYAuto.AutoSize = true;
            this.checkBoxYAuto.Location = new System.Drawing.Point(257, 54);
            this.checkBoxYAuto.Name = "checkBoxYAuto";
            this.checkBoxYAuto.Size = new System.Drawing.Size(47, 17);
            this.checkBoxYAuto.TabIndex = 7;
            this.checkBoxYAuto.Text = "auto";
            this.checkBoxYAuto.UseVisualStyleBackColor = true;
            this.checkBoxYAuto.CheckedChanged += new System.EventHandler(this.CheckBoxYAuto_CheckedChanged);
            // 
            // labelStart
            // 
            this.labelStart.AutoSize = true;
            this.labelStart.Location = new System.Drawing.Point(71, 9);
            this.labelStart.Name = "labelStart";
            this.labelStart.Size = new System.Drawing.Size(29, 13);
            this.labelStart.TabIndex = 28;
            this.labelStart.Text = "Start";
            // 
            // labelEnd
            // 
            this.labelEnd.AutoSize = true;
            this.labelEnd.Location = new System.Drawing.Point(190, 9);
            this.labelEnd.Name = "labelEnd";
            this.labelEnd.Size = new System.Drawing.Size(26, 13);
            this.labelEnd.TabIndex = 29;
            this.labelEnd.Text = "End";
            // 
            // labelStep
            // 
            this.labelStep.AutoSize = true;
            this.labelStep.Location = new System.Drawing.Point(334, 8);
            this.labelStep.Name = "labelStep";
            this.labelStep.Size = new System.Drawing.Size(29, 13);
            this.labelStep.TabIndex = 30;
            this.labelStep.Text = "Step";
            // 
            // labelCurrentPosition
            // 
            this.labelCurrentPosition.AutoSize = true;
            this.labelCurrentPosition.Location = new System.Drawing.Point(399, 9);
            this.labelCurrentPosition.Name = "labelCurrentPosition";
            this.labelCurrentPosition.Size = new System.Drawing.Size(61, 13);
            this.labelCurrentPosition.TabIndex = 40;
            this.labelCurrentPosition.Text = "Current pos";
            // 
            // textBoxXCurrentPosition
            // 
            this.textBoxXCurrentPosition.Enabled = false;
            this.textBoxXCurrentPosition.Location = new System.Drawing.Point(391, 29);
            this.textBoxXCurrentPosition.Name = "textBoxXCurrentPosition";
            this.textBoxXCurrentPosition.ReadOnly = true;
            this.textBoxXCurrentPosition.Size = new System.Drawing.Size(75, 20);
            this.textBoxXCurrentPosition.TabIndex = 41;
            this.textBoxXCurrentPosition.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxYCurrentPosition
            // 
            this.textBoxYCurrentPosition.Enabled = false;
            this.textBoxYCurrentPosition.Location = new System.Drawing.Point(391, 51);
            this.textBoxYCurrentPosition.Name = "textBoxYCurrentPosition";
            this.textBoxYCurrentPosition.ReadOnly = true;
            this.textBoxYCurrentPosition.Size = new System.Drawing.Size(75, 20);
            this.textBoxYCurrentPosition.TabIndex = 42;
            this.textBoxYCurrentPosition.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonRegistration
            // 
            this.buttonRegistration.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonRegistration.Location = new System.Drawing.Point(10, 159);
            this.buttonRegistration.Name = "buttonRegistration";
            this.buttonRegistration.Size = new System.Drawing.Size(75, 23);
            this.buttonRegistration.TabIndex = 20;
            this.buttonRegistration.Text = "Registration";
            this.buttonRegistration.UseVisualStyleBackColor = true;
            this.buttonRegistration.Click += new System.EventHandler(this.ButtonRegistration_Click);
            // 
            // labelStatusText
            // 
            this.labelStatusText.AutoSize = true;
            this.labelStatusText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelStatusText.Location = new System.Drawing.Point(7, 105);
            this.labelStatusText.Name = "labelStatusText";
            this.labelStatusText.Size = new System.Drawing.Size(41, 15);
            this.labelStatusText.TabIndex = 47;
            this.labelStatusText.Text = "Status";
            // 
            // textBoxHoldTime
            // 
            this.textBoxHoldTime.Location = new System.Drawing.Point(71, 78);
            this.textBoxHoldTime.Name = "textBoxHoldTime";
            this.textBoxHoldTime.Size = new System.Drawing.Size(87, 20);
            this.textBoxHoldTime.TabIndex = 9;
            this.textBoxHoldTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LabelHold
            // 
            this.LabelHold.AutoSize = true;
            this.LabelHold.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LabelHold.Location = new System.Drawing.Point(7, 78);
            this.LabelHold.Name = "LabelHold";
            this.LabelHold.Size = new System.Drawing.Size(58, 15);
            this.LabelHold.TabIndex = 51;
            this.LabelHold.Text = "Hold(ms)";
            // 
            // textBoxMeasurementStatus
            // 
            this.textBoxMeasurementStatus.Cursor = System.Windows.Forms.Cursors.No;
            this.textBoxMeasurementStatus.Enabled = false;
            this.textBoxMeasurementStatus.Location = new System.Drawing.Point(71, 104);
            this.textBoxMeasurementStatus.Name = "textBoxMeasurementStatus";
            this.textBoxMeasurementStatus.ReadOnly = true;
            this.textBoxMeasurementStatus.Size = new System.Drawing.Size(87, 20);
            this.textBoxMeasurementStatus.TabIndex = 54;
            this.textBoxMeasurementStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonAdvanced
            // 
            this.buttonAdvanced.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAdvanced.Enabled = false;
            this.buttonAdvanced.Location = new System.Drawing.Point(391, 76);
            this.buttonAdvanced.Name = "buttonAdvanced";
            this.buttonAdvanced.Size = new System.Drawing.Size(75, 23);
            this.buttonAdvanced.TabIndex = 58;
            this.buttonAdvanced.Text = "Advanced";
            this.buttonAdvanced.UseVisualStyleBackColor = true;
            this.buttonAdvanced.Click += new System.EventHandler(this.ButtonAdvanced_Click);
            // 
            // textBoxLuminousIntensivity
            // 
            this.textBoxLuminousIntensivity.Enabled = false;
            this.textBoxLuminousIntensivity.Location = new System.Drawing.Point(257, 78);
            this.textBoxLuminousIntensivity.Name = "textBoxLuminousIntensivity";
            this.textBoxLuminousIntensivity.ReadOnly = true;
            this.textBoxLuminousIntensivity.Size = new System.Drawing.Size(103, 20);
            this.textBoxLuminousIntensivity.TabIndex = 59;
            this.textBoxLuminousIntensivity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelLuminousIntensivity
            // 
            this.labelLuminousIntensivity.AutoSize = true;
            this.labelLuminousIntensivity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelLuminousIntensivity.Location = new System.Drawing.Point(161, 79);
            this.labelLuminousIntensivity.Name = "labelLuminousIntensivity";
            this.labelLuminousIntensivity.Size = new System.Drawing.Size(90, 15);
            this.labelLuminousIntensivity.TabIndex = 60;
            this.labelLuminousIntensivity.Text = "Lum. intensivity";
            // 
            // textBoxVirtualZero
            // 
            this.textBoxVirtualZero.Enabled = false;
            this.textBoxVirtualZero.Location = new System.Drawing.Point(257, 104);
            this.textBoxVirtualZero.Name = "textBoxVirtualZero";
            this.textBoxVirtualZero.ReadOnly = true;
            this.textBoxVirtualZero.Size = new System.Drawing.Size(209, 20);
            this.textBoxVirtualZero.TabIndex = 61;
            this.textBoxVirtualZero.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelVirtualZero
            // 
            this.labelVirtualZero.AutoSize = true;
            this.labelVirtualZero.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelVirtualZero.Location = new System.Drawing.Point(183, 105);
            this.labelVirtualZero.Name = "labelVirtualZero";
            this.labelVirtualZero.Size = new System.Drawing.Size(68, 15);
            this.labelVirtualZero.TabIndex = 62;
            this.labelVirtualZero.Text = "Virtual zero";
            // 
            // progressBarProgress
            // 
            this.progressBarProgress.Location = new System.Drawing.Point(10, 246);
            this.progressBarProgress.Name = "progressBarProgress";
            this.progressBarProgress.Size = new System.Drawing.Size(456, 23);
            this.progressBarProgress.TabIndex = 63;
            // 
            // labelPercentage
            // 
            this.labelPercentage.AutoSize = true;
            this.labelPercentage.BackColor = System.Drawing.Color.Transparent;
            this.labelPercentage.Location = new System.Drawing.Point(223, 280);
            this.labelPercentage.Name = "labelPercentage";
            this.labelPercentage.Size = new System.Drawing.Size(47, 13);
            this.labelPercentage.TabIndex = 64;
            this.labelPercentage.Text = "0/0 (0%)";
            // 
            // labelLuminousUnit
            // 
            this.labelLuminousUnit.AutoSize = true;
            this.labelLuminousUnit.Location = new System.Drawing.Point(360, 81);
            this.labelLuminousUnit.Name = "labelLuminousUnit";
            this.labelLuminousUnit.Size = new System.Drawing.Size(19, 13);
            this.labelLuminousUnit.TabIndex = 65;
            this.labelLuminousUnit.Text = "cd";
            // 
            // Form_MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 312);
            this.ControlBox = false;
            this.Controls.Add(this.labelLuminousUnit);
            this.Controls.Add(this.labelPercentage);
            this.Controls.Add(this.progressBarProgress);
            this.Controls.Add(this.textBoxVirtualZero);
            this.Controls.Add(this.labelVirtualZero);
            this.Controls.Add(this.textBoxLuminousIntensivity);
            this.Controls.Add(this.labelLuminousIntensivity);
            this.Controls.Add(this.buttonAdvanced);
            this.Controls.Add(this.textBoxMeasurementStatus);
            this.Controls.Add(this.textBoxHoldTime);
            this.Controls.Add(this.LabelHold);
            this.Controls.Add(this.labelStatusText);
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
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
        private System.Windows.Forms.Label labelStatusText;
        private System.Windows.Forms.TextBox textBoxHoldTime;
        private System.Windows.Forms.Label LabelHold;
        private System.Windows.Forms.TextBox textBoxMeasurementStatus;
        private System.Windows.Forms.Button buttonAdvanced;
        private System.Windows.Forms.TextBox textBoxLuminousIntensivity;
        private System.Windows.Forms.Label labelLuminousIntensivity;
        private System.Windows.Forms.TextBox textBoxVirtualZero;
        private System.Windows.Forms.Label labelVirtualZero;
        private System.Windows.Forms.ProgressBar progressBarProgress;
        private System.Windows.Forms.Label labelPercentage;
        private System.Windows.Forms.Label labelLuminousUnit;
    }
}

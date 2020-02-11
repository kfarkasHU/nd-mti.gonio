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
            this.textBoxCommand = new System.Windows.Forms.TextBox();
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.buttonSendCommand = new System.Windows.Forms.Button();
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
            this.labelFsmGonio = new System.Windows.Forms.Label();
            this.labelYMotor = new System.Windows.Forms.Label();
            this.labelXMotor = new System.Windows.Forms.Label();
            this.pictureBoxFsmGonioStatus = new System.Windows.Forms.PictureBox();
            this.pictureBoxYMotor = new System.Windows.Forms.PictureBox();
            this.pictureBoxXMotor = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFsmGonioStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxYMotor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxXMotor)).BeginInit();
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
            // textBoxCommand
            // 
            this.textBoxCommand.Enabled = false;
            this.textBoxCommand.Location = new System.Drawing.Point(415, 211);
            this.textBoxCommand.Name = "textBoxCommand";
            this.textBoxCommand.Size = new System.Drawing.Size(292, 20);
            this.textBoxCommand.TabIndex = 1;
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
            // richTextBox1
            // 
            this.richTextBox1.Enabled = false;
            this.richTextBox1.Location = new System.Drawing.Point(415, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(373, 190);
            this.richTextBox1.TabIndex = 17;
            this.richTextBox1.Text = "";
            // 
            // buttonSendCommand
            // 
            this.buttonSendCommand.Enabled = false;
            this.buttonSendCommand.Location = new System.Drawing.Point(713, 211);
            this.buttonSendCommand.Name = "buttonSendCommand";
            this.buttonSendCommand.Size = new System.Drawing.Size(75, 23);
            this.buttonSendCommand.TabIndex = 18;
            this.buttonSendCommand.Text = "Send";
            this.buttonSendCommand.UseVisualStyleBackColor = true;
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
            // labelFsmGonio
            // 
            this.labelFsmGonio.AutoSize = true;
            this.labelFsmGonio.Location = new System.Drawing.Point(34, 128);
            this.labelFsmGonio.Name = "labelFsmGonio";
            this.labelFsmGonio.Size = new System.Drawing.Size(75, 13);
            this.labelFsmGonio.TabIndex = 37;
            this.labelFsmGonio.Text = "FSM Gonio 01";
            // 
            // labelYMotor
            // 
            this.labelYMotor.AutoSize = true;
            this.labelYMotor.Location = new System.Drawing.Point(34, 106);
            this.labelYMotor.Name = "labelYMotor";
            this.labelYMotor.Size = new System.Drawing.Size(44, 13);
            this.labelYMotor.TabIndex = 38;
            this.labelYMotor.Text = "Y Motor";
            // 
            // labelXMotor
            // 
            this.labelXMotor.AutoSize = true;
            this.labelXMotor.Location = new System.Drawing.Point(34, 84);
            this.labelXMotor.Name = "labelXMotor";
            this.labelXMotor.Size = new System.Drawing.Size(44, 13);
            this.labelXMotor.TabIndex = 39;
            this.labelXMotor.Text = "X Motor";
            // 
            // pictureBoxFsmGonioStatus
            // 
            this.pictureBoxFsmGonioStatus.Image = global::ND.MTI.Gonio.Forms.Properties.Resources.disconnect;
            this.pictureBoxFsmGonioStatus.Location = new System.Drawing.Point(12, 125);
            this.pictureBoxFsmGonioStatus.Name = "pictureBoxFsmGonioStatus";
            this.pictureBoxFsmGonioStatus.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxFsmGonioStatus.TabIndex = 36;
            this.pictureBoxFsmGonioStatus.TabStop = false;
            this.pictureBoxFsmGonioStatus.Click += new System.EventHandler(this.PictureBoxFsmGonioStatus_Click);
            // 
            // pictureBoxYMotor
            // 
            this.pictureBoxYMotor.Image = global::ND.MTI.Gonio.Forms.Properties.Resources.disconnect;
            this.pictureBoxYMotor.Location = new System.Drawing.Point(12, 103);
            this.pictureBoxYMotor.Name = "pictureBoxYMotor";
            this.pictureBoxYMotor.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxYMotor.TabIndex = 35;
            this.pictureBoxYMotor.TabStop = false;
            this.pictureBoxYMotor.Click += new System.EventHandler(this.PictureBoxYMotor_Click);
            // 
            // pictureBoxXMotor
            // 
            this.pictureBoxXMotor.Image = global::ND.MTI.Gonio.Forms.Properties.Resources.disconnect;
            this.pictureBoxXMotor.Location = new System.Drawing.Point(12, 81);
            this.pictureBoxXMotor.Name = "pictureBoxXMotor";
            this.pictureBoxXMotor.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxXMotor.TabIndex = 34;
            this.pictureBoxXMotor.TabStop = false;
            this.pictureBoxXMotor.Click += new System.EventHandler(this.PictureBoxXMotor_Click);
            // 
            // Form_MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 240);
            this.ControlBox = false;
            this.Controls.Add(this.labelXMotor);
            this.Controls.Add(this.labelYMotor);
            this.Controls.Add(this.labelFsmGonio);
            this.Controls.Add(this.pictureBoxFsmGonioStatus);
            this.Controls.Add(this.pictureBoxYMotor);
            this.Controls.Add(this.pictureBoxXMotor);
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
            this.Controls.Add(this.buttonSendCommand);
            this.Controls.Add(this.richTextBox1);
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
            this.Controls.Add(this.textBoxCommand);
            this.Controls.Add(this.checkBoxXAuto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form_MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GONIO";
            this.Load += new System.EventHandler(this.Form_MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFsmGonioStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxYMotor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxXMotor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxXAuto;
        private System.Windows.Forms.TextBox textBoxCommand;
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
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button buttonSendCommand;
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
        private System.Windows.Forms.PictureBox pictureBoxXMotor;
        private System.Windows.Forms.PictureBox pictureBoxYMotor;
        private System.Windows.Forms.PictureBox pictureBoxFsmGonioStatus;
        private System.Windows.Forms.Label labelFsmGonio;
        private System.Windows.Forms.Label labelYMotor;
        private System.Windows.Forms.Label labelXMotor;
    }
}
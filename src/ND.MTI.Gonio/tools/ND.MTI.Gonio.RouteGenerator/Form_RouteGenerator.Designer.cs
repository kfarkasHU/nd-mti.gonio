namespace ND.MTI.Gonio.RouteGenerator
{
    partial class Form_RouteGenerator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_RouteGenerator));
            this.buttonClose = new System.Windows.Forms.Button();
            this.dataGridViewXSegments = new System.Windows.Forms.DataGridView();
            this.buttonClearY = new System.Windows.Forms.Button();
            this.buttonClearX = new System.Windows.Forms.Button();
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.groupBoxXSegments = new System.Windows.Forms.GroupBox();
            this.groupBoxYSegments = new System.Windows.Forms.GroupBox();
            this.dataGridViewYSegments = new System.Windows.Forms.DataGridView();
            this.labelStart = new System.Windows.Forms.Label();
            this.labelEnd = new System.Windows.Forms.Label();
            this.textBoxStart = new System.Windows.Forms.TextBox();
            this.textBoxEnd = new System.Windows.Forms.TextBox();
            this.labelStep = new System.Windows.Forms.Label();
            this.buttonAddX = new System.Windows.Forms.Button();
            this.buttonAddY = new System.Windows.Forms.Button();
            this.textBoxStep = new System.Windows.Forms.TextBox();
            this.buttonDeleteY = new System.Windows.Forms.Button();
            this.buttonDeleteX = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewXSegments)).BeginInit();
            this.groupBoxXSegments.SuspendLayout();
            this.groupBoxYSegments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewYSegments)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(673, 225);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 0;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // dataGridViewXSegments
            // 
            this.dataGridViewXSegments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewXSegments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewXSegments.Location = new System.Drawing.Point(6, 19);
            this.dataGridViewXSegments.MultiSelect = false;
            this.dataGridViewXSegments.Name = "dataGridViewXSegments";
            this.dataGridViewXSegments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewXSegments.Size = new System.Drawing.Size(352, 150);
            this.dataGridViewXSegments.TabIndex = 2;
            // 
            // buttonClearY
            // 
            this.buttonClearY.Location = new System.Drawing.Point(673, 196);
            this.buttonClearY.Name = "buttonClearY";
            this.buttonClearY.Size = new System.Drawing.Size(75, 23);
            this.buttonClearY.TabIndex = 3;
            this.buttonClearY.Text = "Clear Y";
            this.buttonClearY.UseVisualStyleBackColor = true;
            this.buttonClearY.Click += new System.EventHandler(this.buttonClearY_Click);
            // 
            // buttonClearX
            // 
            this.buttonClearX.Location = new System.Drawing.Point(592, 196);
            this.buttonClearX.Name = "buttonClearX";
            this.buttonClearX.Size = new System.Drawing.Size(75, 23);
            this.buttonClearX.TabIndex = 4;
            this.buttonClearX.Text = "Clear X";
            this.buttonClearX.UseVisualStyleBackColor = true;
            this.buttonClearX.Click += new System.EventHandler(this.buttonClearX_Click);
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Location = new System.Drawing.Point(592, 225);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(75, 23);
            this.buttonGenerate.TabIndex = 5;
            this.buttonGenerate.Text = "Generate";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
            // 
            // groupBoxXSegments
            // 
            this.groupBoxXSegments.Controls.Add(this.dataGridViewXSegments);
            this.groupBoxXSegments.Location = new System.Drawing.Point(12, 12);
            this.groupBoxXSegments.Name = "groupBoxXSegments";
            this.groupBoxXSegments.Size = new System.Drawing.Size(365, 178);
            this.groupBoxXSegments.TabIndex = 7;
            this.groupBoxXSegments.TabStop = false;
            this.groupBoxXSegments.Text = "X Segments";
            // 
            // groupBoxYSegments
            // 
            this.groupBoxYSegments.Controls.Add(this.dataGridViewYSegments);
            this.groupBoxYSegments.Location = new System.Drawing.Point(383, 12);
            this.groupBoxYSegments.Name = "groupBoxYSegments";
            this.groupBoxYSegments.Size = new System.Drawing.Size(365, 178);
            this.groupBoxYSegments.TabIndex = 8;
            this.groupBoxYSegments.TabStop = false;
            this.groupBoxYSegments.Text = "Y Segments";
            // 
            // dataGridViewYSegments
            // 
            this.dataGridViewYSegments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewYSegments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewYSegments.Location = new System.Drawing.Point(6, 19);
            this.dataGridViewYSegments.MultiSelect = false;
            this.dataGridViewYSegments.Name = "dataGridViewYSegments";
            this.dataGridViewYSegments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewYSegments.Size = new System.Drawing.Size(352, 150);
            this.dataGridViewYSegments.TabIndex = 2;
            // 
            // labelStart
            // 
            this.labelStart.AutoSize = true;
            this.labelStart.Location = new System.Drawing.Point(15, 201);
            this.labelStart.Name = "labelStart";
            this.labelStart.Size = new System.Drawing.Size(29, 13);
            this.labelStart.TabIndex = 9;
            this.labelStart.Text = "Start";
            // 
            // labelEnd
            // 
            this.labelEnd.AutoSize = true;
            this.labelEnd.Location = new System.Drawing.Point(15, 225);
            this.labelEnd.Name = "labelEnd";
            this.labelEnd.Size = new System.Drawing.Size(26, 13);
            this.labelEnd.TabIndex = 10;
            this.labelEnd.Text = "End";
            // 
            // textBoxStart
            // 
            this.textBoxStart.Location = new System.Drawing.Point(56, 198);
            this.textBoxStart.Name = "textBoxStart";
            this.textBoxStart.Size = new System.Drawing.Size(100, 20);
            this.textBoxStart.TabIndex = 11;
            // 
            // textBoxEnd
            // 
            this.textBoxEnd.Location = new System.Drawing.Point(56, 222);
            this.textBoxEnd.Name = "textBoxEnd";
            this.textBoxEnd.Size = new System.Drawing.Size(100, 20);
            this.textBoxEnd.TabIndex = 12;
            // 
            // labelStep
            // 
            this.labelStep.AutoSize = true;
            this.labelStep.Location = new System.Drawing.Point(162, 201);
            this.labelStep.Name = "labelStep";
            this.labelStep.Size = new System.Drawing.Size(29, 13);
            this.labelStep.TabIndex = 13;
            this.labelStep.Text = "Step";
            // 
            // buttonAddX
            // 
            this.buttonAddX.Location = new System.Drawing.Point(309, 196);
            this.buttonAddX.Name = "buttonAddX";
            this.buttonAddX.Size = new System.Drawing.Size(75, 23);
            this.buttonAddX.TabIndex = 15;
            this.buttonAddX.Text = "Add X";
            this.buttonAddX.UseVisualStyleBackColor = true;
            this.buttonAddX.Click += new System.EventHandler(this.buttonAddX_Click);
            // 
            // buttonAddY
            // 
            this.buttonAddY.Location = new System.Drawing.Point(309, 225);
            this.buttonAddY.Name = "buttonAddY";
            this.buttonAddY.Size = new System.Drawing.Size(75, 23);
            this.buttonAddY.TabIndex = 16;
            this.buttonAddY.Text = "Add Y";
            this.buttonAddY.UseVisualStyleBackColor = true;
            this.buttonAddY.Click += new System.EventHandler(this.buttonAddY_Click);
            // 
            // textBoxStep
            // 
            this.textBoxStep.Location = new System.Drawing.Point(203, 198);
            this.textBoxStep.Name = "textBoxStep";
            this.textBoxStep.Size = new System.Drawing.Size(100, 20);
            this.textBoxStep.TabIndex = 17;
            // 
            // buttonDeleteY
            // 
            this.buttonDeleteY.Location = new System.Drawing.Point(388, 226);
            this.buttonDeleteY.Name = "buttonDeleteY";
            this.buttonDeleteY.Size = new System.Drawing.Size(75, 23);
            this.buttonDeleteY.TabIndex = 22;
            this.buttonDeleteY.Text = "Delete Y";
            this.buttonDeleteY.UseVisualStyleBackColor = true;
            this.buttonDeleteY.Click += new System.EventHandler(this.buttonDeleteY_Click);
            // 
            // buttonDeleteX
            // 
            this.buttonDeleteX.Location = new System.Drawing.Point(389, 196);
            this.buttonDeleteX.Name = "buttonDeleteX";
            this.buttonDeleteX.Size = new System.Drawing.Size(75, 23);
            this.buttonDeleteX.TabIndex = 21;
            this.buttonDeleteX.Text = "Delete X";
            this.buttonDeleteX.UseVisualStyleBackColor = true;
            this.buttonDeleteX.Click += new System.EventHandler(this.buttonDeleteX_Click);
            // 
            // Form_RouteGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 255);
            this.ControlBox = false;
            this.Controls.Add(this.buttonDeleteY);
            this.Controls.Add(this.buttonDeleteX);
            this.Controls.Add(this.textBoxStep);
            this.Controls.Add(this.buttonAddY);
            this.Controls.Add(this.buttonAddX);
            this.Controls.Add(this.labelStep);
            this.Controls.Add(this.textBoxEnd);
            this.Controls.Add(this.textBoxStart);
            this.Controls.Add(this.labelEnd);
            this.Controls.Add(this.labelStart);
            this.Controls.Add(this.groupBoxYSegments);
            this.Controls.Add(this.groupBoxXSegments);
            this.Controls.Add(this.buttonGenerate);
            this.Controls.Add(this.buttonClearX);
            this.Controls.Add(this.buttonClearY);
            this.Controls.Add(this.buttonClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_RouteGenerator";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GONIO::RouteGenerator";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewXSegments)).EndInit();
            this.groupBoxXSegments.ResumeLayout(false);
            this.groupBoxYSegments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewYSegments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.DataGridView dataGridViewXSegments;
        private System.Windows.Forms.Button buttonClearY;
        private System.Windows.Forms.Button buttonClearX;
        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.GroupBox groupBoxXSegments;
        private System.Windows.Forms.GroupBox groupBoxYSegments;
        private System.Windows.Forms.DataGridView dataGridViewYSegments;
        private System.Windows.Forms.Label labelStart;
        private System.Windows.Forms.Label labelEnd;
        private System.Windows.Forms.TextBox textBoxStart;
        private System.Windows.Forms.TextBox textBoxEnd;
        private System.Windows.Forms.Label labelStep;
        private System.Windows.Forms.Button buttonAddX;
        private System.Windows.Forms.Button buttonAddY;
        private System.Windows.Forms.TextBox textBoxStep;
        private System.Windows.Forms.Button buttonDeleteY;
        private System.Windows.Forms.Button buttonDeleteX;
    }
}


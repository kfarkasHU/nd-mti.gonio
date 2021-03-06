﻿using System;
using System.Windows.Forms;
using ND.MTI.Gonio.Common.Utils;
using ND.MTI.Gonio.Common.RuntimeContext;
using ND.MTI.Gonio.ServiceInterface;

namespace ND.MTI.Gonio.Forms
{
    internal partial class Form_ResultsForm : Form
    {
        private readonly GonioTimer _timer;
        private readonly IExcelExportService _excelExportService;

        public Form_ResultsForm(IExcelExportService excelExportService)
        {
            _excelExportService = excelExportService;

            _timer = new GonioTimer(OnTimerTick, 1000);
            _timer.Start();

            InitializeComponent();

            var hashCodeCol = new DataGridViewTextBoxColumn();
            hashCodeCol.HeaderText = "Hash code";
            hashCodeCol.Visible = false;

            var positionCol = new DataGridViewTextBoxColumn();
            positionCol.HeaderText = "Position";

            var measuredIlluminationCol = new DataGridViewTextBoxColumn();
            measuredIlluminationCol.HeaderText = "Measured illumination (lx)";

            var correctionCol = new DataGridViewTextBoxColumn();
            correctionCol.HeaderText = "Correction";

            var correctedIlluminationCol = new DataGridViewTextBoxColumn();
            correctedIlluminationCol.HeaderText = "Corrected illumination (lx)";

            var luminousIntensityCol = new DataGridViewTextBoxColumn();
            luminousIntensityCol.HeaderText = "Lum. intensity (cd)";

            dataGridViewResults.Columns.Add(hashCodeCol);
            dataGridViewResults.Columns.Add(positionCol);
            dataGridViewResults.Columns.Add(measuredIlluminationCol);
            dataGridViewResults.Columns.Add(correctionCol);
            dataGridViewResults.Columns.Add(correctedIlluminationCol);
            dataGridViewResults.Columns.Add(luminousIntensityCol);

            dataGridViewResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            BindData();
        }

        private void OnTimerTick(object sender, EventArgs e) => BindData();

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            _timer.Stop();
            Close();
        }

        private void ButtonExcelExport_Click(object sender, EventArgs e) => _excelExportService.ExportToExcel(RuntimeContext.Results);

        private void BindData()
        {
            for (var i = 0; i < RuntimeContext.Results.Count; i++)
            {
                var needToAdd = true;

                foreach (DataGridViewRow row in dataGridViewResults.Rows)
                    if (row.Cells[0].Value.ToString() == RuntimeContext.Results[i].GetHashCode().ToString())
                        needToAdd = false;


                if (needToAdd)
                    dataGridViewResults.Rows.Add(
                        RuntimeContext.Results[i].GetHashCode(),
                        RuntimeContext.Results[i].Position,
                        RuntimeContext.Results[i].MeasuredIllumination,
                        RuntimeContext.Results[i].Correction,
                        RuntimeContext.Results[i].CorrectedIllumination,
                        RuntimeContext.Results[i].Candela
                    );
            }
            dataGridViewResults.Update();
        }
    }
}

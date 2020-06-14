using System;
using System.Windows.Forms;
using ND.MTI.Gonio.ServiceInterface;
using ND.MTI.Gonio.Common.RuntimeContext;

namespace ND.MTI.Gonio.Forms
{
    public partial class Form_Finished : Form
    {
        private readonly IExcelExportService _excelExportService;
        private readonly IMeasurementService _measurementService;

        public Form_Finished(IExcelExportService excelExportService, IMeasurementService measurementService)
        {
            _excelExportService = excelExportService;
            _measurementService = measurementService;

            InitializeComponent();

            labelFinished.Parent = pictureBoxFinished;
            Cursor = Cursors.Hand;

            DialogResult = DialogResult.OK;
        }


        private void LabelFinished_Click(object sender, EventArgs e) => CloseInternal();
        private void PictureBoxFinished_Click(object sender, EventArgs e) => CloseInternal();
        private void ButtonClose_Click(object sender, EventArgs e) => CloseInternal();

        private void CloseInternal()
        {
            _measurementService.SetReady();

            Close();
        }

        private void ButtonExcelExport_Click(object sender, EventArgs e)
        {
            _excelExportService.ExportToExcel(RuntimeContext.Results);

            CloseInternal();
        }
    }
}

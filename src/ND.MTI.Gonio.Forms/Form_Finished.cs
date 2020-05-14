using System;
using System.Windows.Forms;
using ND.MTI.Gonio.Service;

namespace ND.MTI.Gonio.Forms
{
    public partial class Form_Finished : Form
    {
        private readonly IMeasurementService _measurementService;

        public Form_Finished(IMeasurementService measurementService)
        {
            _measurementService = measurementService;

            InitializeComponent();

            labelFinished.Parent = pictureBoxFinished;
            Cursor = Cursors.Hand;

            DialogResult = DialogResult.OK;
        }


        private void LabelFinished_Click(object sender, EventArgs e) => CloseInternal();
        private void PictureBoxFinished_Click(object sender, EventArgs e) => CloseInternal();

        private void CloseInternal()
        {
            _measurementService.SetReady();

            Close();
        }
    }
}

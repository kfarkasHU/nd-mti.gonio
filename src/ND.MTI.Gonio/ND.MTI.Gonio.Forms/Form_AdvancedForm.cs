using System;
using ND.MTI.Gonio.Model;
using ND.MTI.Gonio.Service;
using System.Windows.Forms;
using ND.MTI.Gonio.Common.Utils;
using ND.MTI.Gonio.Service.Worker;
using ND.MTI.Gonio.Common.RuntimeContext;

namespace ND.MTI.Gonio.Forms
{
    public partial class Form_AdvancedForm : Form
    {
        private readonly Primitive_Userconfig _model;

        private readonly IIOWorker _ioWorker;
        private readonly IMeasurementService _measurementService;

        public Form_AdvancedForm()
        {
            InitializeComponent();

            _ioWorker = new IOWorker();
            _measurementService = new MeasurementService();

            _model = RuntimeContext.UserConfig;

            checkBoxReset0.Checked = _model.ResetToZero;
            checkBoxResetV0.Checked = _model.ResetToVZero;
            textBoxOffset.Text = _model.Offset.ToString();
            checkBoxUseCorrection.Checked = _model.UseCorrection;
            numericUpDownAmplifier.Value = (decimal)_model.Amplification;
            textBoxMeasuresInSamePosition.Text = _model.MeasuresInSamePosition.ToString();
            checkBoxSendNotificationFinished.Checked = _model.SendNotificationOnComplete;
            checkBoxSendNotificationError.Checked = _model.SendNotificationOnError;
        }

        private void ButtonCancel_Click(object sender, EventArgs e) => Close();

        private void ButtonStatus_Click(object sender, EventArgs e)
        {
            var statusForm = new Form_Status();
            statusForm.Show();
        }

        private void ButtonEncZero_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure?", "Encoder zero", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                _measurementService.EncoderZero();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            var measuresInSamePosition = Parser.StringToInteger(textBoxMeasuresInSamePosition.Text);

            if (measuresInSamePosition < 1)
                throw new Exception("Measures in same position must be greater than 1!");

            _model.ResetToZero = checkBoxReset0.Checked;
            _model.ResetToVZero = checkBoxResetV0.Checked;
            _model.UseCorrection = checkBoxUseCorrection.Checked;
            _model.MeasuresInSamePosition = measuresInSamePosition;
            _model.Offset = Parser.StringToDouble(textBoxOffset.Text);
            _model.Amplification = Parser.DecimalToDouble(numericUpDownAmplifier.Value);
            _model.SendNotificationOnError = checkBoxSendNotificationError.Checked;
            _model.SendNotificationOnComplete = checkBoxSendNotificationFinished.Checked;

            RuntimeContext.UserConfig = _model;

            Close();
        }

        private void ButtonClearExternalRoute_Click(object sender, EventArgs e)
        {
            textBoxExternalRoute.Text = string.Empty;
            buttonClearExternalRoute.Enabled = false;
        }

        private void ButtonBrowseExternalRoute_Click(object sender, EventArgs e)
        {
            var file = _ioWorker.LoadFile(IOWorker_Filter.RouteFile);

            if (file != string.Empty)
                _model.ExternalRouteFilePath = file;
        }
    }
}

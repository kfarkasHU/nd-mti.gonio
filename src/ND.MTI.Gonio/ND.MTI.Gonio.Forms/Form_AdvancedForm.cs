using System;
using ND.MTI.Gonio.Model;
using ND.MTI.Gonio.Service;
using System.Windows.Forms;
using ND.MTI.Gonio.Common.Utils;
using ND.MTI.Gonio.Service.Worker;
using ND.MTI.Gonio.Common.Userconfig;

namespace ND.MTI.Gonio.Forms
{
    public partial class Form_AdvancedForm : Form
    {
        private Primitive_Userconfig _model;

        private readonly IIOWorker _ioWorker;
        private readonly IUserconfig _userconfig;
        private readonly IMeasurementService _measurementService;

        public Form_AdvancedForm()
        {
            InitializeComponent();

            _ioWorker = new IOWorker();
            _userconfig = Userconfig.GetInstance();
            _measurementService = new MeasurementService();

            _model = _userconfig.UserConfig;

            checkBoxReset0.Checked = _model.ResetToZero;
            checkBoxResetV0.Checked = _model.ResetToVZero;
            textBoxOffset.Text = _model.Offset.ToString();
            checkBoxUseCorrection.Checked = _model.UseCorrection;
            numericUpDownAmplifier.Value = (decimal)_model.Amplification;            
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

            Close();
        }

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

            _model.ResetToZero = checkBoxReset0.Checked;
            _model.ResetToVZero = checkBoxResetV0.Checked;
            _model.UseCorrection = checkBoxUseCorrection.Checked;
            _model.Offset = Parser.StringToDouble(textBoxOffset.Text);
            _model.Amplification = Parser.DecimalToDouble(numericUpDownAmplifier.Value);

            _userconfig.SaveUserConfig(_model);

            DialogResult = DialogResult.OK;

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

using System;
using System.Linq;
using System.Threading;
using ND.MTI.Gonio.Model;
using System.Windows.Forms;
using ND.MTI.Gonio.Service;
using ND.MTI.Gonio.Model.Enum;
using ND.MTI.Gonio.Common.Utils;
using ND.MTI.Gonio.Common.Validator;
using ND.MTI.Gonio.Common.Configuration;
using ND.MTI.Gonio.Common.RuntimeContext;

namespace ND.MTI.Gonio.Forms
{
    internal partial class Form_MainForm : Form
    {
        private readonly Thread _thread;
        private readonly GonioTimer _timer;
        private readonly Complex_MainModel _model;
        private readonly EventWaitHandle _waitHandle;
        private readonly MainFormHelper _mainFormHelper;
        private readonly IMeasurementService _measurementService;
        private readonly IGonioConfiguration _gonioConfiguration;

        internal Form_MainForm()
        {
            InitializeComponent();

            _model = new Complex_MainModel();
            _thread = new Thread(ThreadWorker);
            _mainFormHelper = new MainFormHelper();
            _measurementService = new MeasurementService();
            _waitHandle = new ManualResetEvent(initialState: true);
            _gonioConfiguration = GonioConfiguration.GetInstance();
            _timer = new GonioTimer(OnTimerTick, _gonioConfiguration.Pokeys_ReadInterval);

            SetModel();

            _timer.Start();

            _thread.IsBackground = true;
            _thread.Start();
        }

        private void ThreadWorker()
        {
            while (true)
            {
                _ = _waitHandle.WaitOne();
                UpdateLuminousText(_measurementService.MeasureLumenance().ToString());
            }
        }

        private void UpdateLuminousText(string text)
        {
            if (InvokeRequired)
            {
                _ = Invoke(new Action<string>(UpdateLuminousText), text);
                return;
            }

            textBoxLuminousIntensivity.Text = text;
        }

        private void Form_MainForm_Load(object sender, EventArgs e) => Text = $"GONIO v{Application.ProductVersion}";

        private void OnTimerTick(object sender, EventArgs e)
        {
            var position = _measurementService.GetPosition();

            textBoxXCurrentPosition.Text = position.X.ToString();
            textBoxYCurrentPosition.Text = position.Y.ToString();

            textBoxVirtualZero.Text = RuntimeContext.VirtualZeroPosition.ToString();

            HandleState(_measurementService.State);
        }

        private void HandleState(MeasurementStatus state)
        {
            textBoxMeasurementStatus.Text = _measurementService.State.ToString();

            switch (state)
            {
                case MeasurementStatus.RUNNING:
                    _waitHandle.Reset();

                    #region [ UI ]

                    buttonNew.Enabled = false;
                    buttonNew.Cursor = Cursors.No;
                    buttonExit.Enabled = false;
                    buttonExit.Cursor = Cursors.No;
                    buttonStart.Enabled = false;
                    buttonStart.Cursor = Cursors.No;
                    buttonGoToZero.Enabled = false;
                    buttonGoToZero.Cursor = Cursors.No;
                    buttonContinue.Enabled = false;
                    buttonContinue.Cursor = Cursors.No;
                    buttonSetVirtualZero.Enabled = false;
                    buttonSetVirtualZero.Cursor = Cursors.No;
                    buttonGoToVirtualZero.Enabled = false;
                    buttonGoToVirtualZero.Cursor = Cursors.No;
                    
                    buttonStop.Enabled = true;
                    buttonStop.Cursor = Cursors.Hand;
                    buttonPause.Enabled = true;
                    buttonPause.Cursor = Cursors.Hand;
                    buttonResults.Enabled = true;
                    buttonResults.Cursor = Cursors.Hand;

                    textBoxEndX.Enabled = false;
                    textBoxEndX.Cursor = Cursors.No;
                    textBoxEndY.Enabled = false;
                    textBoxEndY.Cursor = Cursors.No;
                    textBoxStepX.Enabled = false;
                    textBoxStepX.Cursor = Cursors.No;
                    textBoxStepY.Enabled = false;
                    textBoxStepY.Cursor = Cursors.No;
                    checkBoxXAuto.Enabled = false;
                    checkBoxXAuto.Cursor = Cursors.No;
                    checkBoxYAuto.Enabled = false;
                    checkBoxYAuto.Cursor = Cursors.No;
                    textBoxStartX.Enabled = false;
                    textBoxStartX.Cursor = Cursors.No;
                    textBoxStartY.Enabled = false;
                    textBoxStartY.Cursor = Cursors.No;
                    textBoxHoldTime.Enabled = false;
                    textBoxHoldTime.Cursor = Cursors.No;

                    var current = _measurementService.CurrentStepNumber;
                    var max = _measurementService.NumberOfSteps;

                    if (max is 0)
                        max++;

                    var percentage = (current / (double)max) * 100.0;
                    labelPercentage.Text = $"{current}/{max} ({percentage:0.##}%)";
                    progressBarProgress.Maximum = max;
                    progressBarProgress.Value = current;

                    #endregion [ UI ]

                    break;

                case MeasurementStatus.PAUSED:
                    #region [ UI ]

                    buttonNew.Enabled = false;
                    buttonNew.Cursor = Cursors.No;
                    buttonExit.Enabled = false;
                    buttonExit.Cursor = Cursors.No;
                    buttonPause.Enabled = false;
                    buttonPause.Cursor = Cursors.No;
                    buttonStart.Enabled = false;
                    buttonStart.Cursor = Cursors.No;
                    buttonGoToZero.Enabled = false;
                    buttonGoToZero.Cursor = Cursors.No;
                    buttonSetVirtualZero.Enabled = false;
                    buttonSetVirtualZero.Cursor = Cursors.No;
                    buttonGoToVirtualZero.Enabled = false;
                    buttonGoToVirtualZero.Cursor = Cursors.No;

                    buttonStop.Enabled = true;
                    buttonStop.Cursor = Cursors.Hand;
                    buttonResults.Enabled = true;
                    buttonResults.Cursor = Cursors.Hand;
                    buttonContinue.Enabled = true;
                    buttonContinue.Cursor = Cursors.Hand;

                    textBoxEndX.Enabled = false;
                    textBoxEndX.Cursor = Cursors.No;
                    textBoxEndY.Enabled = false;
                    textBoxEndY.Cursor = Cursors.No;
                    textBoxStepX.Enabled = false;
                    textBoxStepX.Cursor = Cursors.No;
                    textBoxStepY.Enabled = false;
                    textBoxStepY.Cursor = Cursors.No;
                    checkBoxXAuto.Enabled = false;
                    checkBoxXAuto.Cursor = Cursors.No;
                    checkBoxYAuto.Enabled = false;
                    checkBoxYAuto.Cursor = Cursors.No;
                    textBoxStartX.Enabled = false;
                    textBoxStartX.Cursor = Cursors.No;
                    textBoxStartY.Enabled = false;
                    textBoxStartY.Cursor = Cursors.No;

                    #endregion [ UI ]

                    break;

                case MeasurementStatus.READY:
                    _waitHandle.Set();

                    #region [ UI ]

                    buttonNew.Enabled = true;
                    buttonNew.Cursor = Cursors.Hand;
                    buttonExit.Enabled = true;
                    buttonExit.Cursor = Cursors.Hand;
                    buttonStart.Enabled = true;
                    buttonStart.Cursor = Cursors.Hand;
                    buttonResults.Enabled = true;
                    buttonResults.Cursor = Cursors.Hand;
                    buttonGoToZero.Enabled = true;
                    buttonGoToZero.Cursor = Cursors.Hand;
                    buttonSetVirtualZero.Enabled = true;
                    buttonSetVirtualZero.Cursor = Cursors.Hand;
                    buttonGoToVirtualZero.Enabled = true;
                    buttonGoToVirtualZero.Cursor = Cursors.Hand;
                    buttonStop.Enabled = false;
                    buttonStop.Cursor = Cursors.No;
                    buttonPause.Enabled = false;
                    buttonPause.Cursor = Cursors.No;
                    buttonContinue.Enabled = false;
                    buttonContinue.Cursor = Cursors.No;
                    buttonRegistration.Enabled = true;
                    buttonRegistration.Cursor = Cursors.Hand;
                    buttonAdvanced.Enabled = RuntimeContext.IsAdminContext;
                    buttonAdvanced.Cursor = RuntimeContext.IsAdminContext ? Cursors.Hand : Cursors.No;

                    textBoxEndX.Enabled = _model.IsXAuto;
                    textBoxEndX.Cursor = _model.IsXAuto ? Cursors.Hand : Cursors.No;
                    textBoxEndY.Enabled = _model.IsYAuto;
                    textBoxEndY.Cursor = _model.IsXAuto ? Cursors.Hand : Cursors.No;
                    textBoxStepX.Enabled = _model.IsXAuto;
                    textBoxStepX.Cursor = _model.IsXAuto ? Cursors.Hand : Cursors.No;
                    textBoxStepY.Enabled = _model.IsYAuto;
                    textBoxStepY.Cursor = _model.IsYAuto ? Cursors.Hand : Cursors.No;
                    checkBoxXAuto.Enabled = true;
                    checkBoxXAuto.Cursor = Cursors.Hand;
                    checkBoxYAuto.Enabled = true;
                    checkBoxYAuto.Cursor = Cursors.Hand;
                    textBoxStartX.Enabled = true;
                    textBoxStartX.Cursor = Cursors.Hand;
                    textBoxStartY.Enabled = true;
                    textBoxStartY.Cursor = Cursors.Hand;
                    textBoxHoldTime.Enabled = true;
                    textBoxHoldTime.Cursor = Cursors.Hand;

                    progressBarProgress.Value = 0;
                    labelPercentage.Text = $"0/0 (0%)";

                    #endregion [ UI ]

                    break;

                case MeasurementStatus.FINISHED:
                    
                    if (Application.OpenForms.OfType<Form_Finished>().Any())
                        return;

                    #region [ UI ]
                    
                    buttonStop.Enabled = false;
                    buttonPause.Enabled = false;
                    buttonResults.Enabled = false;
                    buttonAdvanced.Enabled = false;
                    buttonRegistration.Enabled = false;

                    buttonStop.Cursor = Cursors.No;
                    buttonPause.Cursor = Cursors.No;
                    buttonResults.Cursor = Cursors.No;
                    buttonAdvanced.Cursor = Cursors.No;
                    buttonRegistration.Cursor = Cursors.No;

                    #endregion [ UI ]

                    var finishedForm = new Form_Finished(_measurementService);
                    finishedForm.Show();

                    break;
            }
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            var exit = MessageBox.Show("Are your sure?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(exit == DialogResult.Yes)
                RuntimeContext.LoadFormInstance.Close();
        }

        private void CheckBoxYAuto_CheckedChanged(object sender, EventArgs e)
        {
            _model.IsYAuto = checkBoxYAuto.Checked;

            textBoxEndY.Enabled = checkBoxYAuto.Checked;
            textBoxEndY.Cursor = checkBoxYAuto.Checked ? Cursors.Hand : Cursors.No;

            textBoxStepY.Enabled = checkBoxYAuto.Checked;
            textBoxStepY.Cursor = checkBoxYAuto.Checked ? Cursors.Hand : Cursors.No;
        }

        private void CheckBoxXAuto_CheckedChanged(object sender, EventArgs e)
        {
            _model.IsXAuto = checkBoxXAuto.Checked;

            textBoxEndX.Enabled = checkBoxXAuto.Checked;
            textBoxEndX.Cursor = checkBoxXAuto.Checked ? Cursors.Hand : Cursors.No;

            textBoxStepX.Enabled = checkBoxXAuto.Checked;
            textBoxStepX.Cursor = checkBoxXAuto.Checked ? Cursors.Hand : Cursors.No;
        }
        
        private void ButtonNew_Click(object sender, EventArgs e)
        {
            _model.Reset();
            SetModel();

            RuntimeContext.Results.Clear();
        }

        private void SetModel()
        {
            checkBoxXAuto.Checked = _model.IsXAuto;
            checkBoxYAuto.Checked = _model.IsYAuto;
            textBoxEndX.Text = _model.End.X.ToString();
            textBoxEndY.Text = _model.End.Y.ToString();
            textBoxStartX.Text = _model.Start.X.ToString();
            textBoxStartY.Text = _model.Start.Y.ToString();
            textBoxStepX.Text = _model.IsXAuto ? _model.StepX.ToString() : string.Empty;
            textBoxStepY.Text = _model.IsYAuto ? _model.StepY.ToString() : string.Empty;
            textBoxHoldTime.Text = _model.HoldTime.ToString();
        }

        private void GetModel()
        {
            _model.IsXAuto = checkBoxXAuto.Checked;
            _model.IsYAuto = checkBoxYAuto.Checked;
            _model.End.X = Parser.StringToDouble(textBoxEndX.Text);
            _model.End.Y = Parser.StringToDouble(textBoxEndY.Text);
            _model.Start.X = Parser.StringToDouble(textBoxStartX.Text);
            _model.Start.Y = Parser.StringToDouble(textBoxStartY.Text);
            _model.StepX = _model.IsXAuto ? Parser.StringToDouble(textBoxStepX.Text) : (double?)null;
            _model.StepY = _model.IsYAuto ? Parser.StringToDouble(textBoxStepY.Text) : (double?)null;
            _model.HoldTime = Parser.StringToInteger(textBoxHoldTime.Text);
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            GetModel();

            Complex_MainModelValidator.ValidateModel(_model);

            _measurementService.Configure(_model);

            _measurementService.Start();
        }

        private void ButtonContinue_Click(object sender, EventArgs e) => _measurementService.Continue();

        private void ButtonRegistration_Click(object sender, EventArgs e)
        {
            var form = new Form_Registration();

            _measurementService.SetRunning();

            _ = form.ShowDialog();

            _measurementService.SetReady();
        }
        
        private void ButtonStop_Click(object sender, EventArgs e) => _measurementService.Stop();

        private void ButtonPause_Click(object sender, EventArgs e) => _measurementService.Pause();

        private void ButtonResults_Click(object sender, EventArgs e)
        {
            var resultsFrom = new Form_ResultsForm();
            resultsFrom.Show();
        }

        private void ButtonGoToZero_Click(object sender, EventArgs e) => _mainFormHelper.SetPositionToZero();

        private void ButtonGoToVirtualZero_Click(object sender, EventArgs e) => _mainFormHelper.SetPositionVirtualZero();

        private void ButtonSetVirtualZero_Click(object sender, EventArgs e)
        {
            var virtualZeroForm = new Form_VirtualZeroForm();

            virtualZeroForm.Show();
        }

        private void ButtonAdvanced_Click(object sender, EventArgs e)
        {
            var advancedForm = new Form_AdvancedForm();
            advancedForm.Show();
        }
    }
}

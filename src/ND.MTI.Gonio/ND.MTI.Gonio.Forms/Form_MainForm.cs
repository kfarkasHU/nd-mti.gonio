using System;
using ND.MTI.Gonio.Model;
using System.Windows.Forms;
using ND.MTI.Gonio.Service;
using ND.MTI.Gonio.Model.Enum;
using ND.MTI.Gonio.Common.Utils;
using ND.MTI.Gonio.Service.Worker;
using ND.MTI.Gonio.Common.Configuration;
using ND.MTI.Gonio.Common.RuntimeContext;

namespace ND.MTI.Gonio.Forms
{
    // TODO: Exit?
    // TODO: DgView scrolls (update from thread, and scrollable)
    // TODO: Optional correction.
    // TODO: Amplifier (0 - 2 double) Optional
    // TODO: Offset optional
    // TODO: Userconfig

    /* TODO: Advanced
            - ENC ZERO
            - Status
            - Optional correction
            - Amplifier
            - Offset
            - External route
    */

    internal partial class Form_MainForm : Form
    {
        private readonly Timer _timer;
        private readonly IIOWorker _ioWorker;
        private readonly Complex_MainModel _model;
        private readonly MainFormHelper _mainFormHelper;
        private readonly IMeasurementService _measurementService;
        private readonly IExcelExportService _excelExportService;
        private readonly IGonioConfiguration _gonioConfiguration;

        internal Form_MainForm()
        {
            InitializeComponent();

            _timer = new Timer();
            _ioWorker = new IOWorker();
            _model = new Complex_MainModel();
            _mainFormHelper = new MainFormHelper();
            _measurementService = new MeasurementService();
            _excelExportService = new ExcelExportService();
            _gonioConfiguration = GonioConfiguration.GetInstance();
            
            SetModel();

            _timer.Interval = _gonioConfiguration.Pokeys_ReadInterval;
            _timer.Tick += OnTimerTick;
            _timer.Start();

            if (RuntimeContext.IsAdminContext)
                buttonEncZero.Enabled = true;
        }

        private void Form_MainForm_Load(object sender, EventArgs e) => Text = $"GONIO v{Application.ProductVersion}";

        private void OnTimerTick(object sender, EventArgs e)
        {
            var position = _measurementService.GetPosition();

            textBoxXCurrentPosition.Text = position.X.ToString();
            textBoxYCurrentPosition.Text = position.Y.ToString();

            HandleState(_measurementService.State);
        }

        private void HandleState(MeasurementStatus state)
        {
            textBoxMeasurementStatus.Text = _measurementService.State.ToString();

            switch (state)
            {
                case MeasurementStatus.RUNNING:
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
                    buttonExcelExport.Enabled = false;
                    buttonExcelExport.Cursor = Cursors.No;
                    buttonSetVirtualZero.Enabled = false;
                    buttonSetVirtualZero.Cursor = Cursors.No;
                    buttonGoToVirtualZero.Enabled = false;
                    buttonGoToVirtualZero.Cursor = Cursors.No;
                    buttonClearExternelRoute.Enabled = false;
                    buttonClearExternelRoute.Cursor = Cursors.No;
                    buttonBrowseExternalRoute.Enabled = false;
                    buttonBrowseExternalRoute.Cursor = Cursors.No;
                    
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
                    buttonExcelExport.Enabled = false;
                    buttonExcelExport.Cursor = Cursors.No;
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
                    buttonExcelExport.Enabled = true;
                    buttonExcelExport.Cursor = Cursors.Hand;
                    buttonSetVirtualZero.Enabled = true;
                    buttonSetVirtualZero.Cursor = Cursors.Hand;
                    buttonGoToVirtualZero.Enabled = true;
                    buttonGoToVirtualZero.Cursor = Cursors.Hand;
                    buttonClearExternelRoute.Enabled = true;
                    buttonClearExternelRoute.Cursor = Cursors.Hand;
                    buttonBrowseExternalRoute.Enabled = true;
                    buttonBrowseExternalRoute.Cursor = Cursors.Hand;

                    buttonStop.Enabled = false;
                    buttonStop.Cursor = Cursors.No;
                    buttonPause.Enabled = false;
                    buttonPause.Cursor = Cursors.No;
                    buttonContinue.Enabled = false;
                    buttonContinue.Cursor = Cursors.No;

                    textBoxEndX.Enabled = true;
                    textBoxEndX.Cursor = Cursors.Hand;
                    textBoxEndY.Enabled = true;
                    textBoxEndY.Cursor = Cursors.Hand;
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

                    #endregion [ UI ]

                    break;
            }
        }

        private void ButtonExit_Click(object sender, EventArgs e) => RuntimeContext.LoadFormInstance.Close();

        private void CheckBoxYAuto_CheckedChanged(object sender, EventArgs e)
        {
            _model.IsYAuto = checkBoxYAuto.Checked;
            textBoxStepY.Enabled = checkBoxYAuto.Checked;
            textBoxStepY.Cursor = checkBoxYAuto.Checked ? Cursors.Hand : Cursors.No;
        }

        private void CheckBoxXAuto_CheckedChanged(object sender, EventArgs e)
        {
            _model.IsXAuto = checkBoxXAuto.Checked;
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
            textBoxExternalRouteFile.Text = _model.ExternalRoute;
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
            _model.ExternalRoute = textBoxExternalRouteFile.Text;
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            GetModel();

            _model.Validate();
            _measurementService.Configure(_model);

            _measurementService.Start();
        }

        private void ButtonContinue_Click(object sender, EventArgs e) => _measurementService.Continue();

        private void ButtonRegistration_Click(object sender, EventArgs e)
        {
            var form = new Form_Registration();
            form.Show();
        }
        
        private void ButtonStop_Click(object sender, EventArgs e) => _measurementService.Stop();

        private void ButtonPause_Click(object sender, EventArgs e) => _measurementService.Pause();

        private void ButtonExcelExport_Click(object sender, EventArgs e) => _excelExportService.ExportToExcel(RuntimeContext.Results);

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

        private void ButtonEncZero_Click(object sender, EventArgs e) => _measurementService.EncoderZero();

        private void ButtonStatus_Click(object sender, EventArgs e)
        {
            var statusForm = new Form_Status();
            statusForm.Show();
        }

        private void ButtonBrowseExternalRoute_Click(object sender, EventArgs e)
        {
            var file = _ioWorker.LoadFile(IOWorker_Filter.RouteFile);

            if (file == string.Empty)
                return;

            textBoxExternalRouteFile.Text = file;
        }

        private void ButtonClearExternelRoute_Click(object sender, EventArgs e) => textBoxExternalRouteFile.Text = string.Empty;
    }
}

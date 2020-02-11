using System;
using ND.MTI.Service;
using System.Drawing;
using System.Resources;
using ND.MTI.Gonio.Model;
using System.Windows.Forms;
using ND.MTI.Gonio.Common.Utils;
using ND.MTI.Gonio.Forms.Properties;
using ND.MTI.Gonio.ServiceInterface;
using ND.MTI.Gonio.Common.Configuration;
using ND.MTI.Gonio.Common.RuntimeContext;

namespace ND.MTI.Gonio.Forms
{
    // TODO (FK): Connect on startup to cfg.
    // TODO (FK): Button validations (connections).
    // TODO (FK): UI Review and refactor.
    // TODO (FK): Generate *.Debug files to serials.

    public partial class Form_MainForm : Form
    {
        private readonly Complex_MainModel _model;
        private readonly ResourceManager _resourceManager;
        private readonly IMeasurementService _measurementService;
        private readonly IExcelExportService _excelExportService;
        private readonly IGonioConfiguration _gonioConfiguration;

        public Form_MainForm()
        {
            InitializeComponent();

            _model = new Complex_MainModel();
            _resourceManager = Resources.ResourceManager;
            _measurementService = new MeasurementService();
            _excelExportService = new ExcelExportService();

            _gonioConfiguration = GonioConfiguration.GetInstance();

            SetModel();

            RuntimeContext.Init();
        }

        private void Form_MainForm_Load(object sender, EventArgs e)
        {
            #region [ UI ]

            buttonNew.Enabled = true;
            buttonNew.Cursor = Cursors.Hand;
            buttonExit.Enabled = true;
            buttonExit.Cursor = Cursors.Hand;
            buttonStart.Enabled = true;
            buttonStart.Cursor = Cursors.Hand;
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
            buttonResults.Enabled = false;
            buttonResults.Cursor = Cursors.No;
            buttonContinue.Enabled = false;
            buttonContinue.Cursor = Cursors.No;
            buttonExcelExport.Enabled = false;
            buttonExcelExport.Cursor = Cursors.No;

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

            pictureBoxXMotor.Enabled = true;
            pictureBoxXMotor.Cursor = Cursors.Hand;
            pictureBoxYMotor.Enabled = true;
            pictureBoxYMotor.Cursor = Cursors.Hand;
            pictureBoxFsmGonioStatus.Enabled = true;
            pictureBoxFsmGonioStatus.Cursor = Cursors.Hand;

            #endregion [ UI ]
        }

        private void ButtonExit_Click(object sender, EventArgs e) => RuntimeContext.LoadFormInstance.Close();

        private void CheckBoxYAuto_CheckedChanged(object sender, EventArgs e) => textBoxStepY.Enabled = checkBoxYAuto.Checked;

        private void CheckBoxXAuto_CheckedChanged(object sender, EventArgs e) => textBoxStepX.Enabled = checkBoxXAuto.Checked;
        
        private void ButtonNew_Click(object sender, EventArgs e)
        {
            // TODO (FK): Is model is changed, ask for change.

            _model.Reset();
            SetModel();

            #region [ UI ]

            buttonNew.Enabled = true;
            buttonNew.Cursor = Cursors.Hand;
            buttonExit.Enabled = true;
            buttonExit.Cursor = Cursors.Hand;
            buttonStart.Enabled = true;
            buttonStart.Cursor = Cursors.Hand;
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
            buttonResults.Enabled = false;
            buttonResults.Cursor = Cursors.No;
            buttonContinue.Enabled = false;
            buttonContinue.Cursor = Cursors.No;
            buttonExcelExport.Enabled = false;
            buttonExcelExport.Cursor = Cursors.No;

            textBoxEndX.Enabled = true;
            textBoxEndX.Cursor = Cursors.Hand;
            textBoxEndY.Enabled = true;
            textBoxEndY.Cursor = Cursors.Hand;
            textBoxStepX.Enabled = _model.IsXAuto;
            textBoxStepX.Cursor = Cursors.Hand;
            textBoxStepY.Enabled = _model.IsYAuto;
            textBoxStepY.Cursor = Cursors.Hand;
            checkBoxXAuto.Enabled = true;
            checkBoxXAuto.Cursor = Cursors.Hand;
            checkBoxYAuto.Enabled = true;
            checkBoxYAuto.Cursor = Cursors.Hand;
            textBoxStartX.Enabled = true;
            textBoxStartX.Cursor = Cursors.Hand;
            textBoxStartY.Enabled = true;
            textBoxStartY.Cursor = Cursors.Hand;

            pictureBoxXMotor.Enabled = true;
            pictureBoxXMotor.Cursor = Cursors.Hand;
            pictureBoxYMotor.Enabled = true;
            pictureBoxYMotor.Cursor = Cursors.Hand;
            pictureBoxFsmGonioStatus.Enabled = true;
            pictureBoxFsmGonioStatus.Cursor = Cursors.Hand;

            #endregion [ UI ]

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
        }

        private void PictureBoxFsmGonioStatus_Click(object sender, EventArgs e)
        {
            if(RuntimeContext.FsmGonioConnected)
            {
                RuntimeContext.FsmGonioConnected = false;
                _measurementService.DisconnectFsmGonio();
            }
            else
            {
                RuntimeContext.FsmGonioConnected = _measurementService.ConnectFsmGonio(_gonioConfiguration.FsmGonioConfig);
            }

            pictureBoxFsmGonioStatus.Image = (Image)_resourceManager.GetObject(GetImageFor(RuntimeContext.FsmGonioConnected));
        }

        private void PictureBoxXMotor_Click(object sender, EventArgs e)
        {
            if (RuntimeContext.XConnected)
            {
                RuntimeContext.XConnected = false;
                _measurementService.DisconnectXMotor();
            }
            else
            {
                RuntimeContext.XConnected = _measurementService.ConnectXMotor(_gonioConfiguration.XMotorConfig);
            }

            pictureBoxXMotor.Image = (Image)_resourceManager.GetObject(GetImageFor(RuntimeContext.XConnected));
        }

        private void PictureBoxYMotor_Click(object sender, EventArgs e)
        {
            if (RuntimeContext.YConnected)
            {
                RuntimeContext.YConnected = false;
                _measurementService.DisconnectYMotor();
            }
            else
            {
                RuntimeContext.YConnected = _measurementService.ConnectXMotor(_gonioConfiguration.YMotorConfig);
            }

            pictureBoxYMotor.Image = (Image)_resourceManager.GetObject(GetImageFor(RuntimeContext.YConnected));
        }

        private string GetImageFor(bool status) => status ? "connect" : "disconnect";

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            GetModel();

            _model.Validate();

            StartOrContinue();
        }

        private void ButtonContinue_Click(object sender, EventArgs e) => StartOrContinue();

        private void StartOrContinue()
        {
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

            pictureBoxXMotor.Enabled = false;
            pictureBoxXMotor.Cursor = Cursors.No;
            pictureBoxYMotor.Enabled = false;
            pictureBoxYMotor.Cursor = Cursors.No;
            pictureBoxFsmGonioStatus.Enabled = false;
            pictureBoxFsmGonioStatus.Cursor = Cursors.No;

            #endregion [ UI ]

            RuntimeContext.Status = Status.Started;
            _measurementService.Start();
        }

        private void ButtonStop_Click(object sender, EventArgs e)
        {
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

            pictureBoxXMotor.Enabled = true;
            pictureBoxXMotor.Cursor = Cursors.Hand;
            pictureBoxYMotor.Enabled = true;
            pictureBoxYMotor.Cursor = Cursors.Hand;
            pictureBoxFsmGonioStatus.Enabled = true;
            pictureBoxFsmGonioStatus.Cursor = Cursors.Hand;

            #endregion [ UI ]

            RuntimeContext.Status = Status.Stopped;
            _measurementService.Stop();
        }

        private void ButtonPause_Click(object sender, EventArgs e)
        {
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

            pictureBoxXMotor.Enabled = false;
            pictureBoxXMotor.Cursor = Cursors.No;
            pictureBoxYMotor.Enabled = false;
            pictureBoxYMotor.Cursor = Cursors.No;
            pictureBoxFsmGonioStatus.Enabled = false;
            pictureBoxFsmGonioStatus.Cursor = Cursors.No;

            #endregion [ UI ]

            RuntimeContext.Status = Status.Paused;
            _measurementService.Pause();
        }

        private void ButtonExcelExport_Click(object sender, EventArgs e) => _excelExportService.ExportToExcel(RuntimeContext.Results);

        private void ButtonResults_Click(object sender, EventArgs e)
        {
            var resultsFrom = new Form_ResultsForm();
            resultsFrom.Show();
        }

        private void ButtonGoToZero_Click(object sender, EventArgs e) => _measurementService.SetPositionZero();

        private void ButtonGoToVirtualZero_Click(object sender, EventArgs e) => _measurementService.SetPositionVirtualZero();

        private void ButtonSetVirtualZero_Click(object sender, EventArgs e)
        {
            var virtualZeroForm = new Form_VirtualZeroForm();

            virtualZeroForm.Show();
        }
    }
}

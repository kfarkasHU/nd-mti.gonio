using System;
using System.Threading;
using ND.MTI.Gonio.Model;
using System.Windows.Forms;
using ND.MTI.Gonio.Common.Utils;
using ND.MTI.Gonio.Common.Configuration;
using ND.MTI.Gonio.Common.RuntimeContext;
using ND.MTI.Gonio.ServiceInterface;

namespace ND.MTI.Gonio.Forms
{
    internal partial class Form_VirtualZeroForm : Form
    {
        private Thread _thread;
        private Primitive_Position _targetPosition;

        private readonly GonioTimer _timer;
        private readonly IPositionWorker _positionWorker;
        private readonly IGonioConfiguration _gonioConfiguration;

        private bool _keyPressed;

        public Form_VirtualZeroForm(IPositionWorker positionWorker)
        {
            _positionWorker = positionWorker;
            _gonioConfiguration = GonioConfiguration.GetInstance();

            InitializeComponent();

            KeyPreview = true;
            KeyUp += new KeyEventHandler(OnKeyUp);
            KeyDown += new KeyEventHandler(OnKeyDown);

            _timer = new GonioTimer(OnTimerTick, _gonioConfiguration.Pokeys_ReadInterval * 3);
            _timer.Start();
        }

        private void Form_VirtualZeroForm_Load(object sender, EventArgs e) => SetModelInternal();

        private void ButtonClose_Click(object sender, EventArgs e) => Close();

        private void ButtonSave_Click(object sender, EventArgs e) => SaveInternal();

        private void ButtonSaveAndClose_Click(object sender, EventArgs e)
        {
            SaveInternal();
            Close();
        }

        private void ButtonClearVirtualZero_Click(object sender, EventArgs e) => RuntimeContext.VirtualZeroPosition = new Primitive_Position(0, 0);

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            var keyChar = (int)e.KeyCode;
            if (47 < keyChar && keyChar < 58)
                return;

            if (keyChar == 8 || keyChar == 46) // backspace + del
                return;

            if (_keyPressed)
                return;

            _keyPressed = true;

            switch (e.KeyCode)
            {
                case Keys.Q:
                    DecrementXInternalSlow();
                    break;

                case Keys.W:
                    IncrementXInternalSlow();
                    break;

                case Keys.E:
                    DecrementXInternalFast();
                    break;

                case Keys.R:
                    IncrementXInternalFast();
                    break;

                case Keys.A:
                    DecrementYInternalSlow();
                    break;

                case Keys.S:
                    IncrementYInternalSlow();
                    break;

                case Keys.D:
                    DecrementYInternalFast();
                    break;

                case Keys.F:
                    IncrementYInternalFast();
                    break;
            }

            e.Handled = true;
            e.SuppressKeyPress = true;
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            var keyChar = (int)e.KeyCode;
            if (47 < keyChar && keyChar < 58)
                return;

            if (keyChar == 8 || keyChar == 46) // backspace + del
                return;

            _keyPressed = false;

            switch (e.KeyCode)
            {
                case Keys.Q:
                case Keys.W:
                case Keys.E:
                case Keys.R:
                    StopXInternal();
                    break;

                case Keys.A:
                case Keys.S:
                case Keys.D:
                case Keys.F:
                    StopYInternal();
                    break;
            }

            e.Handled = true;
            e.SuppressKeyPress = true;
        }

        private void ButtonStopX_Click(object sender, EventArgs e) => StopXInternal();

        private void ButtonStopY_Click(object sender, EventArgs e) => StopYInternal();

        private void IncrementXInternalSlow() => _positionWorker.IncrementXSlow();
        private void IncrementXInternalFast() => _positionWorker.IncrementXFast();

        private void IncrementYInternalSlow() => _positionWorker.IncrementYSlow();
        private void IncrementYInternalFast() => _positionWorker.IncrementYFast();

        private void DecrementXInternalSlow() => _positionWorker.DecrementXSlow();
        private void DecrementXInternalFast() => _positionWorker.DecrementXFast();

        private void DecrementYInternalSlow() => _positionWorker.DecrementYSlow();
        private void DecrementYInternalFast() => _positionWorker.DecrementYFast();

        private void StopXInternal() => _positionWorker.StopX();

        private void StopYInternal() => _positionWorker.StopY();

        private void OnTimerTick(object sender, EventArgs e) => SetModelInternal();

        private void SetModelInternal()
        {
            var positionRelatedToV0 = _positionWorker.GetPosition();
            var positionRelatedToA0 = positionRelatedToV0 + RuntimeContext.VirtualZeroPosition;

            textBoxXCoordV0.Text = positionRelatedToV0.X.ToString();
            textBoxYCoordV0.Text = positionRelatedToV0.Y.ToString();

            textBoxXCoordA0.Text = positionRelatedToA0.X.ToString();
            textBoxYCoordA0.Text = positionRelatedToA0.Y.ToString();

            textBoxVirtualZeroX.Text = RuntimeContext.VirtualZeroPosition.X.ToString();
            textBoxVirtualZeroY.Text = RuntimeContext.VirtualZeroPosition.Y.ToString();
        }

        private void ButtonGo_Click(object sender, EventArgs e)
        {
            var posX = Parser.StringToDouble(textBoxSetPositionX.Text);
            var posY = Parser.StringToDouble(textBoxSetPositionY.Text);

            _targetPosition = new Primitive_Position(posX, posY);

            _thread = new Thread(OnThreadWorking);
            _thread.IsBackground = true;
            _thread.Start();
        }

        private void OnThreadWorking()
        {
            _positionWorker.SetPosition(_targetPosition);
            _thread.Abort();
        }

        private void ButtonDecrementXSlow_Click(object sender, EventArgs e) => DecrementXInternalSlow();

        private void ButtonIncrementXSlow_Click(object sender, EventArgs e) => IncrementXInternalSlow();

        private void ButtonIncrementXFast_Click(object sender, EventArgs e) => IncrementXInternalFast();

        private void ButtonDecrementXFast_Click(object sender, EventArgs e) => DecrementXInternalFast();

        private void ButtonIncrementYSlow_Click(object sender, EventArgs e) => IncrementYInternalSlow();

        private void ButtonDecrementYSlow_Click(object sender, EventArgs e) => DecrementYInternalSlow();

        private void ButtonIncrementYFast_Click(object sender, EventArgs e) => IncrementYInternalFast();

        private void ButtonDecrementYFast_Click(object sender, EventArgs e) => DecrementYInternalFast();

        private void SaveInternal() => RuntimeContext.VirtualZeroPosition += _positionWorker.GetPosition();
    }
}

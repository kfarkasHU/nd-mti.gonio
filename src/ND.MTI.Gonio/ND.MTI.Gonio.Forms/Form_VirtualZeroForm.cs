using System;
using System.Threading;
using ND.MTI.Gonio.Model;
using System.Windows.Forms;
using ND.MTI.Gonio.Common.Utils;
using ND.MTI.Gonio.Service.Worker;
using ND.MTI.Gonio.Common.Configuration;
using ND.MTI.Gonio.Common.RuntimeContext;

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

        internal Form_VirtualZeroForm()
        {
            _positionWorker = PositionWorker.GetInstance();
            _gonioConfiguration = GonioConfiguration.GetInstance();

            InitializeComponent();

            KeyPreview = true;
            KeyUp += new KeyEventHandler(OnKeyUp);
            KeyDown += new KeyEventHandler(OnKeyDown);

            _timer = new GonioTimer(OnTimerTick, _gonioConfiguration.Pokeys_ReadInterval * 3);
            _timer.Start();
        }

        private void Form_VirtualZeroForm_Load(object sender, EventArgs e) => SetModelInternal(_positionWorker.GetPosition());

        private void ButtonClose_Click(object sender, EventArgs e) => Close();

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            RuntimeContext.VirtualZeroPosition += _positionWorker.GetPosition();

            Close();
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            var keyChar = (int)e.KeyCode;
            if (47 < keyChar && keyChar < 58)
                return;

            if (keyChar == 27 || keyChar == 46) // esc + del
                return;

            if (_keyPressed)
                return;

            _keyPressed = true;

            switch (e.KeyCode)
            {
                case Keys.Q:
                    DecrementXInternal();
                    break;

                case Keys.W:
                    IncrementXInternal();
                    break;

                case Keys.A:
                    DecrementYInternal();
                    break;

                case Keys.S:
                    IncrementYInternal();
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

            if (keyChar == 27 || keyChar == 46) // esc + del
                return;

            _keyPressed = false;

            switch (e.KeyCode)
            {
                case Keys.Q:
                case Keys.W:
                    StopXInternal();
                    break;

                case Keys.A:
                case Keys.S:
                    StopYInternal();
                    break;
            }

            e.Handled = true;
            e.SuppressKeyPress = true;
        }

        private void ButtonIncrementX_Click(object sender, EventArgs e) => IncrementXInternal();

        private void ButtonIncrementY_Click(object sender, EventArgs e) => IncrementYInternal();

        private void ButtonDecrementX_Click(object sender, EventArgs e) => DecrementXInternal();

        private void ButtonDecrementY_Click(object sender, EventArgs e) => DecrementYInternal();

        private void ButtonStopX_Click(object sender, EventArgs e) => StopXInternal();

        private void ButtonStopY_Click(object sender, EventArgs e) => StopYInternal();

        private void IncrementXInternal() => _positionWorker.IncrementX();

        private void IncrementYInternal() => _positionWorker.IncrementY();

        private void DecrementXInternal() => _positionWorker.DecrementX();

        private void DecrementYInternal() => _positionWorker.DecrementY();

        private void StopXInternal() => _positionWorker.StopX();

        private void StopYInternal() => _positionWorker.StopY();

        private void OnTimerTick(object sender, EventArgs e) => SetModelInternal(_positionWorker.GetPosition());

        private void SetModelInternal(Primitive_Position position)
        {
            var posX = Math.Round(position.X, 3);
            var posY = Math.Round(position.Y, 3);

            textBoxXCoord.Text = posX.ToString();
            textBoxYCoord.Text = posY.ToString();
        }

        private void ButtonGo_Click(object sender, EventArgs e)
        {
            var posX = Parser.StringToDouble(textBoxSetPositionX.Text);
            var posY = Parser.StringToDouble(textBoxSetPositionY.Text);

            _targetPosition = new Primitive_Position(posX, posY);

            _thread = new Thread(OnThreadWorking);
            _thread.IsBackground = true;
        }

        private void OnThreadWorking()
        {
            _positionWorker.SetPosition(_targetPosition);
            _thread.Abort();
        }
    }
}

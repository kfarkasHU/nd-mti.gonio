using System;
using ND.MTI.Gonio.Model;
using System.Windows.Forms;
using ND.MTI.Gonio.Service.Worker;
using ND.MTI.Gonio.Common.RuntimeContext;
using ND.MTI.Gonio.Common.Configuration;

namespace ND.MTI.Gonio.Forms
{
    internal partial class Form_VirtualZeroForm : Form
    {
        private readonly Timer _timer;
        private readonly IPositionWorker _positionWorker;
        private readonly IGonioConfiguration _gonioConfiguration;

        private bool _keyPressed;

        internal Form_VirtualZeroForm()
        {
            _positionWorker = PositionWorker.GetInstance();
            _gonioConfiguration = GonioConfiguration.GetInstance();

            InitializeComponent();

            KeyPreview = true;
            KeyDown += new KeyEventHandler(OnKeyDown);
            KeyUp += new KeyEventHandler(OnKeyUp);

            _timer = new Timer();
            _timer.Interval = _gonioConfiguration.Pokeys_ReadInterval * 3;
            _timer.Tick += OnTimerTick;
            _timer.Start();
            
            EnableForm();
        }

        private void Form_VirtualZeroForm_Load(object sender, EventArgs e) => SetModelInternal(_positionWorker.GetPosition());

        private void ButtonClose_Click(object sender, EventArgs e) => Close();

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            RuntimeContext.VirtualZeroPosition = _positionWorker.GetPosition();

            Close();
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (_keyPressed)
                return;

            _keyPressed = true;

            DisableForm();
            Cursor = Cursors.WaitCursor;

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

            EnableForm();
            Cursor = Cursors.Arrow;
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
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

        private void OnTimerTick(object sender, EventArgs e)  => SetModelInternal(_positionWorker.GetPosition());

        private void DisableForm() => SetFormState(false, Cursors.No);

        private void EnableForm() => SetFormState(true, Cursors.Hand);

        private void SetFormState(bool enabled, Cursor cursor)
        {
            buttonSave.Enabled = enabled;
            buttonClose.Enabled = enabled;
            buttonStopX.Enabled = enabled;
            buttonStopY.Enabled = enabled;
            buttonDecrementX.Enabled = enabled;
            buttonDecrementY.Enabled = enabled;
            buttonIncrementX.Enabled = enabled;
            buttonIncrementY.Enabled = enabled;

            buttonSave.Cursor = cursor;
            buttonClose.Cursor = cursor;
            buttonStopX.Cursor = cursor;
            buttonStopY.Cursor = cursor;
            buttonDecrementX.Cursor = cursor;
            buttonDecrementY.Cursor = cursor;
            buttonIncrementX.Cursor = cursor;
            buttonIncrementY.Cursor = cursor;
        }

        private void SetModelInternal(Primitive_Position position)
        {
            var posX = Math.Round(position.X, 3);
            var posY = Math.Round(position.Y, 3);

            textBoxXCoord.Text = posX.ToString();
            textBoxYCoord.Text = posY.ToString();
        }
    }
}

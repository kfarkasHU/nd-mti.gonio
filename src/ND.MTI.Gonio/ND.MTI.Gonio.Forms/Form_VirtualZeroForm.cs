﻿using System;
using ND.MTI.Gonio.Model;
using System.Windows.Forms;
using ND.MTI.Service.Worker;
using ND.MTI.Gonio.Common.Utils;
using ND.MTI.Gonio.Common.RuntimeContext;

namespace ND.MTI.Gonio.Forms
{
    public partial class Form_VirtualZeroForm : Form
    {
        private readonly IPositionWorker _positionWorker;

        public Form_VirtualZeroForm()
        {
            _positionWorker = PositionWorker.GetInstance();

            InitializeComponent();
        }
        private void Form_VirtualZeroForm_Load(object sender, EventArgs e) => SetModelInternal(_positionWorker.GetPosition());

        private void ButtonClose_Click(object sender, EventArgs e) => Close();

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            RuntimeContext.VirtualZeroPosition = _positionWorker.GetPosition();

            Close();
        }

        private void ButtonIncrementX_Click(object sender, EventArgs e)
        {
            _positionWorker.IncrementX(GetStepInternal());
            SetModelInternal();
        }

        private void ButtonIncrementY_Click(object sender, EventArgs e)
        {
            _positionWorker.IncrementY(GetStepInternal());
            SetModelInternal();
        }

        private void ButtonDecrementX_Click(object sender, EventArgs e)
        {
            _positionWorker.DecrementX(GetStepInternal());
            SetModelInternal();
        }

        private void ButtonDecrementY_Click(object sender, EventArgs e)
        {
            _positionWorker.DecrementY(GetStepInternal());
            SetModelInternal();
        }

        private int GetStepInternal() => Parser.StringToInteger(comboBoxStep.SelectedItem.ToString());

        private void SetModelInternal() => SetModelInternal(_positionWorker.GetPosition());

        private void SetModelInternal(Primitive_Position position)
        {
            textBoxXCoord.Text = position.X.ToString();
            textBoxYCoord.Text = position.Y.ToString();
        }
    }
}

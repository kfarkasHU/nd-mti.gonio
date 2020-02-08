using System;
using System.Windows.Forms;
using ND.MTI.Gonio.Common.Utils;

namespace ND.MTI.Gonio.Forms
{
    public partial class Form_ConnectionForm : Form
    {
        public Form_ConnectionForm()
        {
            InitializeComponent();
        }

        private void Form_ConnectionForm_Load(object sender, EventArgs e)
        {
            var comboBoxes = new ComboBox[]
            {
                comboBoxEncoderX,
                comboBoxEncoderY,
                comboBoxFsmGonio,
                comboBoxMotorX,
                comboBoxMotorY
            };

            var comPorts = COMUtils.SelectAllComPortNames();

            foreach(var comboBox in comboBoxes)
                BindComboBox(comboBox);

            void BindComboBox(ComboBox comboBox)
            {
                foreach (var comPort in comPorts)
                    comboBox.Items.Add(comPort);
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e) => Close();

        private void ButtonSave_Click(object sender, EventArgs e) => SaveInternal();

        private void SaveInternal()
        {
            throw new NotImplementedException();
        }
    }
}

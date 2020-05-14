using System;
using System.Drawing;
using System.Windows.Forms;
using ND.MTI.Gonio.Forms.Properties;
using ND.MTI.Gonio.Common.RuntimeContext;

namespace ND.MTI.Gonio.Forms
{
    public partial class Form_Status : Form
    {
        public Form_Status()
        {
            InitializeComponent();
        }

        private void Form_Status_Load(object sender, EventArgs e)
        {
            pictureBoxFSMGonio.Image = (Bitmap)Resources.ResourceManager.GetObject(GetImageFor(RuntimeContext.IsFSMGonioConnected));
            pictureBoxPokeys57U.Image = (Bitmap)Resources.ResourceManager.GetObject(GetImageFor(RuntimeContext.IsPokeys57Connected));
            pictureBoxSSIPanel.Image = (Bitmap)Resources.ResourceManager.GetObject(GetImageFor(RuntimeContext.IsSSIPanelConnected));
        }

        private string GetImageFor(bool state) => state ? "connect" : "disconnect";

        private void buttonClose_Click(object sender, EventArgs e) => Close();
    }
}

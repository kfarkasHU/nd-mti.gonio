using System;
using System.Drawing;
using System.Windows.Forms;
using ND.MTI.Gonio.Forms.Properties;

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
            //TODO: Implement this.
            pictureBoxFSMGonio.Image = (Bitmap)Resources.ResourceManager.GetObject(GetImageFor(true));
            pictureBoxPokeys57U.Image = (Bitmap)Resources.ResourceManager.GetObject(GetImageFor(true));
            pictureBoxSSIPanel.Image = (Bitmap)Resources.ResourceManager.GetObject(GetImageFor(true));
        }

        private string GetImageFor(bool state) => state ? "connect" : "disconnect";

        private void buttonClose_Click(object sender, EventArgs e) => Close();
    }
}

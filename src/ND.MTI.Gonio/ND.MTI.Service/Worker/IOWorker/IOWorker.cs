using System.Windows.Forms;

namespace ND.MTI.Service.Worker
{
    public class IOWorker : IIOWorker
    {
        public void SaveFile(byte[] content)
        {
            var saveFileDialog = new SaveFileDialog();
            
            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var stream = saveFileDialog.OpenFile();
                stream.Write(content, 0, content.Length);

                stream.Close();
                stream.Dispose();
            }
        }
    }
}

using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;

namespace ND.MTI.Service.Worker
{
    public class IOWorker : IIOWorker
    {
        public IList<Tuple<string, string>> ReadAllLines(string absolutePath, char separator)
        {
            var list = new List<Tuple<string, string>>();
            var lines = File.ReadAllLines(absolutePath);

            foreach (var line in lines)
                list.Add(ToTuple(line));

            return list;

            Tuple<string, string> ToTuple(string line)
            {
                var s = line.Split(separator);
                return new Tuple<string, string>(s[0], s[1]);
            }
        }

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

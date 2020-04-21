using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace ND.MTI.Gonio.Service.Worker
{
    public class IOWorker : IIOWorker
    {
        public IList<string> ReadAllLines(string absolutePath) => ReadAllLinesInternal(absolutePath);

        public IList<Tuple<string, string>> ReadAllLines(string absolutePath, char separator)
        {
            var list = new List<Tuple<string, string>>();
            var lines = ReadAllLinesInternal(absolutePath);

            foreach (var line in lines)
                list.Add(ToTuple(line));

            return list;

            Tuple<string, string> ToTuple(string line)
            {
                var s = line.Split(separator);
                return new Tuple<string, string>(s[0], s[1]);
            }
        }

        private IList<string> ReadAllLinesInternal(string path) => File.ReadAllLines(path);

        public string LoadFile(string extension)
        {
            var dialog = new OpenFileDialog();

            dialog.Filter = extension;

            return dialog.ShowDialog() == DialogResult.OK
                ? dialog.FileName
                : string.Empty;
        }

        public void SaveFile(byte[] content, string extension)
        {
            var saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = extension;

            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var stream = saveFileDialog.OpenFile();
                stream.Write(content, 0, content.Length);

                stream.Close();
                stream.Dispose();
            }
        }

        public void SaveFile(object[] lines, string extension)
        {
            var saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = extension;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var lineStr = new List<string>();
                for (var i = 0; i < lines.Count(); i++)
                    lineStr.Add(lines[i].ToString());

                File.WriteAllLines(saveFileDialog.FileName, lineStr);
            }
        }
    }
}

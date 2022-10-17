using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using MessageBox = System.Windows.MessageBox;

namespace KMS1_Zach.SupportClasses
{
    public class FileHelper
    {

        public string openFile()
        {
            var fileContent = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    return openFileDialog.FileName;
                }
                else return null;
            }
        }

        public void saveFileAsTxt(string content)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.FileName = "DefaultOutputTxt.txt";
            save.Filter = "Text File | *.txt";

            if (save.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(save.OpenFile()))
                {
                    writer.WriteLine(content);
                    writer.Dispose();

                    MessageBox.Show("saved!", "Info");
                }
            }
        }

    }
}

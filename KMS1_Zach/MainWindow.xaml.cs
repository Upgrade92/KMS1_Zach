using KMS1_Zach.SupportClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KMS1_Zach
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private string content = string.Empty;
        private string filePath = string.Empty;

        public MainWindow()
        {
            InitializeComponent();
        }

        private  void buttonSelect_Click(object sender, RoutedEventArgs e)
        {
            filePath = new FileHelper().openFile();
            
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            if (content != string.Empty)
            {
                new FileHelper().saveFileAsTxt(content);
            }
            else MessageBox.Show("Nothing to save", "Error");
        }

        private async void buttonConvert_Click(object sender, RoutedEventArgs e)
        {
            if (content != string.Empty)
            {
                Helper.startProgressBar(progressBar);
                content = await Helper.fileReading(filePath);
                content = await new Filter().filterString(content);

            }
            else MessageBox.Show("No file selected", "Error");
        }

        private async Task Button_ClickAsync(object sender, RoutedEventArgs e)
        {
            //textBlock.Text = new Filter().filterString(textBlock.Text);
            if (filePath != null)
            {
                Helper.startProgressBar(progressBar);
                //content = await new Helper().readText(filePath);
                

            }
            else MessageBox.Show("Lol", "Error");
        }
    }
}

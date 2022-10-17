using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using MessageBox = System.Windows.MessageBox;

namespace KMS1_Zach.SupportClasses
{
    public class Helper
    {
        public static async void startProgressBar(ProgressBar progressBar)
        {
            for (int i = 0; i < 100; i++)
            {
                progressBar.Value++;
                await Task.Delay(150);
                if (progressBar.Value == 100) break;
            }
        }

        public static void fillProgressBar(ProgressBar progressBar)
        {
            for (int i = 0; i < 100; i++)
            {
                progressBar.Value++;
            }
        }

        public async Task<string[]> readText(string selectedFile)
        {
            string content;
            try
            {
                await Task.Run(() =>
                {
                    content = File.ReadAllText(selectedFile);
                    //using (StreamReader sr = new StreamReader(selectedFile))
                    //{
                    //    content = await sr.ReadToEndAsync();
                    //    sr.Dispose();
                    //    sr.Close();
                    //    return content;
                    //}
                });
                //return content;
            }
            catch (ArgumentNullException e)
            {
                MessageBox.Show("No file selected", "Error");
            }
            return null;
        }


        public static async Task<string[]> fileReading(string path)
        {
            string[] lines =  File.ReadAllLines(path);

            //StringBuilder sb = new StringBuilder();

            //foreach (var item in lines)
            //{
            //    sb.AppendLine(await new Filter().filterString(item.ToLower()));
            //}
            //return sb.ToString();

            return lines;

        }
    }




}

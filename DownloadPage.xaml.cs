using Microsoft.Win32;
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

namespace Muhu_SL
{
    /// <summary>
    /// DownloadPage.xaml 的交互逻辑
    /// </summary>
    public partial class DownloadPage : Page
    {
        public DownloadPage()
        {
            InitializeComponent();
        }
        public static string[] DownloadClass =
{
            "Java - JRE",
            "PaperAPI - 服务器API",
            "SpigotAPI - 服务器API"
        };
        public static string[] JreDownload =
        {
            "https://ghdl.feizhuqwq.cf/https://github.com/Muhu-C/MuhuSL-JREDownloads/releases/download/MuhuSL-Java-Downloads/OpenJDK18U-jre_x64_windows_hotspot_18.0.2.1_1.msi",
            "https://ghdl.feizhuqwq.cf/https://github.com/Muhu-C/MuhuSL-JREDownloads/releases/download/MuhuSL-Java-Downloads/OpenJDK17U-jre_x64_windows_hotspot_17.0.5_8.msi",
            "https://ghdl.feizhuqwq.cf/https://github.com/Muhu-C/MuhuSL-JREDownloads/releases/download/MuhuSL-Java-Downloads/OpenJDK11U-jre_x64_windows_hotspot_2023-01-13-05-36.msi",
            "https://ghdl.feizhuqwq.cf/https://github.com/Muhu-C/MuhuSL-JREDownloads/releases/download/MuhuSL-Java-Downloads/OpenJDK8U-jre_x64_windows_hotspot_8u352b08.msi",
        };
        public static string[] PaperAPIDownload =
        {
            "https://ghdl.feizhuqwq.cf/https://github.com/Muhu-C/MuhuSL-PaperDownloads/releases/download/MuhuSL-Paper/paper-1.19.3-381.jar",
            "https://ghdl.feizhuqwq.cf/https://github.com/Muhu-C/MuhuSL-PaperDownloads/releases/download/MuhuSL-Paper/paper-1.18.2-388.jar",
            "https://ghdl.feizhuqwq.cf/https://github.com/Muhu-C/MuhuSL-PaperDownloads/releases/download/MuhuSL-Paper/paper-1.17.1-411.jar",
            "https://ghdl.feizhuqwq.cf/https://github.com/Muhu-C/MuhuSL-PaperDownloads/releases/download/MuhuSL-Paper/paper-1.16.5-794.jar",
            "https://ghdl.feizhuqwq.cf/https://github.com/Muhu-C/MuhuSL-PaperDownloads/releases/download/MuhuSL-Paper/paper-1.15.2-393.jar",
            "https://ghdl.feizhuqwq.cf/https://github.com/Muhu-C/MuhuSL-PaperDownloads/releases/download/MuhuSL-Paper/paper-1.14.4-245.jar",
            "https://ghdl.feizhuqwq.cf/https://github.com/Muhu-C/MuhuSL-PaperDownloads/releases/download/MuhuSL-Paper/paper-1.13.2-657.jar",
            "https://ghdl.feizhuqwq.cf/https://github.com/Muhu-C/MuhuSL-PaperDownloads/releases/download/MuhuSL-Paper/paper-1.12.2-1620.jar",
            "https://ghdl.feizhuqwq.cf/https://github.com/Muhu-C/MuhuSL-PaperDownloads/releases/download/MuhuSL-Paper/paper-1.11.2-1106.jar",
            "https://ghdl.feizhuqwq.cf/https://github.com/Muhu-C/MuhuSL-PaperDownloads/releases/download/MuhuSL-Paper/paper-1.10.2-918.jar",
            "https://ghdl.feizhuqwq.cf/https://github.com/Muhu-C/MuhuSL-PaperDownloads/releases/download/MuhuSL-Paper/paper-1.9.4-775.jar",
            "https://ghdl.feizhuqwq.cf/https://github.com/Muhu-C/MuhuSL-PaperDownloads/releases/download/MuhuSL-Paper/paper-1.8.8-445.jar",
        };
        public static string[] SpigotAPIDownload =
        {
            "https://ghdl.feizhuqwq.cf/https://github.com/Muhu-C/Spigot-Downloads/releases/download/MuhuSL-Spigot/spigot-1.19.3.jar",
            "https://ghdl.feizhuqwq.cf/https://github.com/Muhu-C/Spigot-Downloads/releases/download/MuhuSL-Spigot/spigot-1.18.2.jar",
            "https://ghdl.feizhuqwq.cf/https://github.com/Muhu-C/Spigot-Downloads/releases/download/MuhuSL-Spigot/spigot-1.17.1.jar",
            "https://ghdl.feizhuqwq.cf/https://github.com/Muhu-C/Spigot-Downloads/releases/download/MuhuSL-Spigot/spigot-1.16.5.jar",
            "https://ghdl.feizhuqwq.cf/https://github.com/Muhu-C/Spigot-Downloads/releases/download/MuhuSL-Spigot/spigot-1.15.2.jar",
            "https://ghdl.feizhuqwq.cf/https://github.com/Muhu-C/Spigot-Downloads/releases/download/MuhuSL-Spigot/spigot-1.14.4.jar",
            "https://ghdl.feizhuqwq.cf/https://github.com/Muhu-C/Spigot-Downloads/releases/download/MuhuSL-Spigot/spigot-1.13.2.jar",
            "https://ghdl.feizhuqwq.cf/https://github.com/Muhu-C/Spigot-Downloads/releases/download/MuhuSL-Spigot/spigot-1.12.2.jar",
            "https://ghdl.feizhuqwq.cf/https://github.com/Muhu-C/Spigot-Downloads/releases/download/MuhuSL-Spigot/spigot-1.11,2.jar",
            "https://ghdl.feizhuqwq.cf/https://github.com/Muhu-C/Spigot-Downloads/releases/download/MuhuSL-Spigot/spigot-1.10.2-R0.1-SNAPSHOT-latest.jar",
            "https://ghdl.feizhuqwq.cf/https://github.com/Muhu-C/Spigot-Downloads/releases/download/MuhuSL-Spigot/spigot-1.9.4-R0.1-SNAPSHOT-latest.jar",
            "https://ghdl.feizhuqwq.cf/https://github.com/Muhu-C/Spigot-Downloads/releases/download/MuhuSL-Spigot/spigot-1.8.8-R0.1-SNAPSHOT-latest.jar",
        };
        public static string[] Jre =
        {
            "Jre 18 - Java",
            "Jre 17 - Java",
            "Jre 11 - Java",
            "Jre 8 - Java",
        };
        public static string[] Paper =
        {
            "Paper 1.19.3 Latest",
            "Paper 1.18.2 Latest",
            "Paper 1.17.1 Latest",
            "Paper 1.16.5 Latest",
            "Paper 1.15.2 Latest",
            "Paper 1.14.4 Latest",
            "Paper 1.13.2 Latest",
            "Paper 1.12.2 Latest",
            "Paper 1.11.2 Latest",
            "Paper 1.10.2 Latest",
            "Paper 1.9.4 Latest",
            "Paper 1.8.8 Latest"
        };
        public static string[] Spigot =
        {
            "Spigot 1.19.3 Latest",
            "Spigot 1.18.2 Latest",
            "Spigot 1.17.1 Latest",
            "Spigot 1.16.5 Latest",
            "Spigot 1.15.2 Latest",
            "Spigot 1.14.4 Latest",
            "Spigot 1.13.2 Latest",
            "Spigot 1.12.2 Latest",
            "Spigot 1.11.2 Latest",
            "Spigot 1.10.2 Latest",
            "Spigot 1.9.4 Latest",
            "Spigot 1.8.8 Latest"
        };

        public static string[][] Downloads = { JreDownload, PaperAPIDownload, SpigotAPIDownload };

        public static int DownloadVersionIndex = -1;
        public static int DownloadClassIndex = -1;
        public static int DownloadClientIndex = -1;
        private static string DownloadFileURL;




        /// <summary>        
        /// c#,.net 下载文件        
        /// </summary>        
        /// <param name="URL">下载文件地址</param>       
        /// 
        /// <param name="Filename">下载后的存放地址</param>        
        /// <param name="Prog">用于显示的进度条</param>        
        /// 
        public void DownloadFile(string URL, string filename, ProgressBar prog, Label label1)
        {
            float percent = 0;
            try
            {
                System.Net.HttpWebRequest Myrq = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(URL);
                System.Net.HttpWebResponse myrp = (System.Net.HttpWebResponse)Myrq.GetResponse();
                long totalBytes = myrp.ContentLength;
                if (prog != null)
                {
                    prog.Maximum = (int)totalBytes;
                }
                System.IO.Stream st = myrp.GetResponseStream();
                System.IO.Stream so = new System.IO.FileStream(filename, System.IO.FileMode.Create);
                long totalDownloadedByte = 0;
                byte[] by = new byte[1024];
                int osize = st.Read(by, 0, (int)by.Length);
                while (osize > 0)
                {
                    totalDownloadedByte = osize + totalDownloadedByte;
                    System.Windows.Forms.Application.DoEvents();
                    so.Write(by, 0, osize);
                    if (prog != null)
                    {
                        prog.Value = (int)totalDownloadedByte;
                    }
                    osize = st.Read(by, 0, (int)by.Length);

                    percent = (float)totalDownloadedByte / (float)totalBytes * 100;
                    double percent_number = Math.Round(percent,2);
                    label1.Content = percent_number.ToString() + "%";
                    System.Windows.Forms.Application.DoEvents();
                }
                so.Close();
                st.Close();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        private void LbClass_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DownloadClassLabel.Content = LbClass.SelectedItem.ToString().Substring(LbClass.SelectedItem.ToString().LastIndexOf(": ") + 2);
            DownloadVersionLabel.Content = "";
            if (LbClass.SelectedIndex==0)
            {
                DownloadClassIndex = 0;
                LbVersions.Items.Clear();
                LbVersions.SelectedItem = null;
                foreach (string i in Jre)
                {
                    LbVersions.Items.Add(i);
                }
            }
            else if (LbClass.SelectedIndex == 1)
            {
                DownloadClassIndex = 1;
                LbVersions.Items.Clear();
                LbVersions.SelectedItem = null;
                foreach (string i in Paper)
                {
                    LbVersions.Items.Add(i);
                }
            }
            else
            {
                DownloadClassIndex = 2;
                LbVersions.Items.Clear();
                LbVersions.SelectedItem = null;
                foreach (string i in Spigot)
                {
                    LbVersions.Items.Add(i);
                }
            }
        }

        private void LbVersions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (LbVersions.SelectedItem != null)
                {
                    DownloadVersionLabel.Content = LbVersions.SelectedItem.ToString();
                }
                DownloadVersionIndex = LbClass.SelectedIndex;
                DownloadClientIndex = LbVersions.SelectedIndex;
                DownloadFileURL = Downloads[DownloadClassIndex][DownloadClientIndex];
            }
            catch(System.Exception)
            {
                DownloadVersionIndex = -1;
                DownloadClientIndex = -1;//a
            }
        }

        private void DownloadClick(object sender, RoutedEventArgs e)
        {
            if (DownloadClassIndex < 0 || DownloadVersionIndex < 0) { MessageBox.Show("未选择！"); }
            else
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                if (DownloadClassIndex == 0) 
                {
                    saveFileDialog1.Filter = "安装包文件(*.msi)|*.msi";
                    if (saveFileDialog1.ShowDialog() == true)
                    {
                        string filename = saveFileDialog1.FileName;
                        MessageBox.Show(DownloadFileURL + "\n" + filename);
                        DownloadFile(DownloadFileURL, filename, ProgressBarA, ProgressLabel);
                    }
                }
                else 
                { 
                    saveFileDialog1.Filter = "Java Archive(*.jar)|*.jar";
                    if (saveFileDialog1.ShowDialog() == true)
                    {
                        string filename = saveFileDialog1.FileName;
                        MessageBox.Show(DownloadFileURL + "\n" + filename);
                        DownloadFile(DownloadFileURL, filename, ProgressBarA, ProgressLabel);
                    }
                }

            }
        }
    }
}

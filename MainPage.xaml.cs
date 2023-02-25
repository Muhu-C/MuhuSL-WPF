using System;
using MuhuLib;
using System.Collections.Generic;
using System.IO;
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
using System.Globalization;

namespace Muhu_SL
{
    /// <summary>
    /// MainPage.xaml 的交互逻辑
    /// </summary>
    public partial class MainPage : Page
    {
        #region 变量
        
        public static string SERV_Pth;
        public static string JAVA_Pth = "java";
        public static string JAVA_Nme;
        public static string SERV_Fle;//服务器文件
        public static string SERV_Ver;
        public static string[] RAM = { "128", "2048" };//min,max
        #endregion

        public MainPage() { InitializeComponent(); }
        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            maxRAMtb_cb.Items.Clear();
            minRAMtb_cb.Items.Clear();
            maxRAMtb_cb.Items.Add("MB");
            maxRAMtb_cb.Items.Add("GB");
            minRAMtb_cb.Items.Add("MB");
            minRAMtb_cb.Items.Add("GB");
            maxRAMtb_cb.SelectedItem = MainWindow.mbgb[0];
            minRAMtb_cb.SelectedItem = MainWindow.mbgb[1];
            try
            {
                JAVA_Nme = ServerProcess.SearchJava(JAVA_Pth);
                javaVerLabel.Content = JAVA_Nme + "(Path变量中)";
            }
            catch { }
        }

        #region Choose
        private void ChooseServer_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog SVfolderBrowser = new System.Windows.Forms.FolderBrowserDialog
            {
                Description = "请选择带有服务器API的文件夹",
                SelectedPath = @"C:\"
            };
            if (SVfolderBrowser.ShowDialog() == System.Windows.Forms.DialogResult.OK) { SERV_Pth = SVfolderBrowser.SelectedPath; }
            svPathLabel.Content = SERV_Pth;
            try
            {
                var ServerFileList = Directory.GetFiles(SERV_Pth, "*.jar");
                int Files = ServerFileList.Count();
                if (Files > 1 | Files <= 0)
                {
                    MessageBox.Show("请规范放置服务器API", "提示");
                }
                else
                {
                    SERV_Fle = ServerFileList[0];
                    svVerLabel.Content = "正在加载...";
                    AsyncRunTask(SERV_Fle, svVerLabel);
                }
            }
            catch (System.IO.DirectoryNotFoundException) { MessageBox.Show("未能找到路径 \"" + SERV_Pth + "\"", "错误"); }
            catch (System.ArgumentNullException) { }
        }
        private async void AsyncRunTask(string svpath, Label lb1)
        {
            var result = await Task.Factory.StartNew(() => ServerProcess.GetServerName(svpath));
            SERV_Ver = result;
            lb1.Content = result;
        }


        private void ChooseJava_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog FileDialog1 = new System.Windows.Forms.OpenFileDialog
            {
                Filter = "Java|java.exe|所有文件|*.*",
                InitialDirectory = @"C:\"
            };
            if (FileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK) { JAVA_Pth = FileDialog1.FileName; }
            javaVerLabel.Content = ServerProcess.SearchJava(JAVA_Pth);
            JAVA_Nme = ServerProcess.SearchJava(JAVA_Pth);
        }
        #endregion

        #region RAM
        private void MaxRAMtb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (maxRAMtb_cb.SelectedIndex == 0)
            {
                RAM[1] = maxRAMtb.Text;
                MainWindow.mbgb[0] = "MB";
            }
            else if(maxRAMtb_cb.SelectedIndex == 1)
            {
                try
                {
                    int RAMnum = Convert.ToInt32(maxRAMtb.Text);
                    string ram_MB = (RAMnum * 1024).ToString();
                    RAM[1] = ram_MB;
                    MainWindow.mbgb[0] = "GB";
                }
                catch {  }
            }
        }

        private void MinRAMtb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (minRAMtb_cb.SelectedIndex == 0)
            {
                RAM[0] = minRAMtb.Text;
                MainWindow.mbgb[1] = "MB";
            }
            else if (maxRAMtb_cb.SelectedIndex == 1)
            {
                try
                {
                    int RAMnum = Convert.ToInt32(minRAMtb.Text);
                    string ram_MB = (RAMnum * 1024).ToString();
                    RAM[0] = ram_MB;
                    MainWindow.mbgb[1] = "GB";
                }
                catch {  }
            }
        }

        private void maxRAMtb_cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (maxRAMtb_cb.SelectedIndex == 0)
            {
                RAM[1] = maxRAMtb.Text;
                MainWindow.mbgb[0] = "MB";
            }
            else if (maxRAMtb_cb.SelectedIndex == 1)
            {
                try
                {
                    int RAMnum = Convert.ToInt32(maxRAMtb.Text);
                    string ram_MB = (RAMnum * 1024).ToString();
                    RAM[1] = ram_MB;
                    MainWindow.mbgb[0] = "GB";
                }
                catch {  }
            }
        }

        private void minRAMtb_cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (minRAMtb_cb.SelectedIndex == 0)
            {
                RAM[0] = minRAMtb.Text;
                MainWindow.mbgb[1] = "MB";
            }
            else if (maxRAMtb_cb.SelectedIndex == 1)
            {
                try
                {
                    int RAMnum = Convert.ToInt32(minRAMtb.Text);
                    string ram_MB = (RAMnum * 1024).ToString();
                    RAM[0] = ram_MB;
                    MainWindow.mbgb[1] = "GB";
                }
                catch {  }
            }
        }
        #endregion
    }
    public class StateToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value)
            {

                default:
                    return Brushes.Transparent.Color;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

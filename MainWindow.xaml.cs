using System;
using MuhuLib;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using System.Xml.Linq;

namespace Muhu_SL
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Form主题
        public static string[] mbgb = {"MB","MB"};//max.min]
        public static MainPage Page1 = new MainPage();
        public static ServerConsole Page2 = new ServerConsole();
        public static DownloadPage Page4 = new DownloadPage();
        public static InfoPage Page5 = new InfoPage();
        private System.Windows.Forms.NotifyIcon _notifyIcon = null;

        public MainWindow()
        {
            if (InfoPage.GetWindowsTheme())
            {
                ResourceDictionary resource = new ResourceDictionary() { Source = new Uri("/Themes/Black.xaml", UriKind.RelativeOrAbsolute) };
                Application.Current.Resources.MergedDictionaries[0] = resource;
            }
            else
            {
                ResourceDictionary resource = new ResourceDictionary() { Source = new Uri("/Themes/White.xaml", UriKind.RelativeOrAbsolute) };
                Application.Current.Resources.MergedDictionaries[0] = resource;
            }
            InitializeComponent();
            InitialTray();
        }

        #region 最小化系统托盘
        private void InitialTray()
        {
            //设置托盘的各个属性
            _notifyIcon = new System.Windows.Forms.NotifyIcon
            {
                Icon = Muhu_SL.Properties.Resources.icon,
                Text = "Muhu_SL",
                Visible = true//托盘按钮是否
            };
            _notifyIcon.MouseClick += notifyIcon_MouseClick;
            //窗体状态改变时触发
            this.StateChanged += MainWindow_StateChanged;
        }
        #endregion

        #region 窗口状态改变
        private void MainWindow_StateChanged(object sender, EventArgs e)
        {
            if (this.WindowState == WindowState.Minimized)
            {
                this.Visibility = Visibility.Collapsed;
            }
        }
        #endregion

        #region 托盘图标鼠标单击事件
        private void notifyIcon_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (this.Visibility == Visibility.Visible)
                {
                    this.Visibility = Visibility.Collapsed;
                }
                else
                {
                    this.Show();
                    this.Activate();
                }
            }
            else
            {
                if(MessageBox.Show("是否关闭程序","",MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    this.Close();
                }
            }
        }

        public void MenuOpen_OnClick(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Visible;
            this.Show();
            this.Activate();
        }
        private void MenuExit_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion
        private void MainForm_MouseMove(object sender, MouseEventArgs e)//鼠标移动
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        private void MainToolsGrid_Load(object sender, RoutedEventArgs e)
        {
            frame1.Content = Page1;
        }
        private void Window_MiniSize(object sender, RoutedEventArgs e) { this.Visibility = Visibility.Collapsed; }
        private void Window_Close(object sender, RoutedEventArgs e) { Application.Current.Shutdown(); }
        #endregion
        private void FORMCLOSING(object sender, RoutedEventArgs e)
        {
            try
            {
                FileProcess.DeleteFolder(System.IO.Path.GetTempPath() + "\\a");
            }
            catch {; }
        }
        private void Bt1_Click(object sender, RoutedEventArgs e) { frame1.Content = Page1; }
        private void Bt2_Click(object sender, RoutedEventArgs e) { frame1.Content = Page2; }
        private void Bt5_Click(object sender, RoutedEventArgs e) { frame1.Content = Page5; }
        private void Bt4_Click(object sender, RoutedEventArgs e) { frame1.Content = Page4; }
    }
}

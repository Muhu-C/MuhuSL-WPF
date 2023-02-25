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
    /// InfoPage.xaml 的交互逻辑
    /// </summary>
    public partial class InfoPage : Page
    {
        public InfoPage() { InitializeComponent(); }

        private static string[] formColors = {"White","Black"};
        private static string MainColor = "Black";

        private void WhiteButton_Checked(object sender, RoutedEventArgs e) { MainColor = formColors[0]; }
        private void BlackButton_Checked(object sender, RoutedEventArgs e) { MainColor = formColors[1]; }
        private void WindowButton_Checked(object sender, RoutedEventArgs e)
        {
            if(GetWindowsTheme()) { MainColor = formColors[1]; }
            else { MainColor = formColors[0]; }
        }

        private void UseButton_Click(object sender, RoutedEventArgs e)
        {
            ResourceDictionary resource = new ResourceDictionary() { Source = new Uri("/Themes/" + MainColor + ".xaml", UriKind.RelativeOrAbsolute) };
            Application.Current.Resources.MergedDictionaries[0] = resource;
        }

        public static bool GetWindowsTheme()
        {
            const string RegistryKeyPath = @"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize";
            const string RegistryValueName = "AppsUseLightTheme";
            object registryValueObject = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(RegistryKeyPath)?.GetValue(RegistryValueName);
            if (registryValueObject is null) return false;
            return (int)registryValueObject > 0 ? false : true;
        }

        private void Muhu_C_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://space.bilibili.com/1469137723");
        }
    }
}

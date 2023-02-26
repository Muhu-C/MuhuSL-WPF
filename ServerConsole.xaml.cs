using MuhuLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// ServerConsole.xaml 的交互逻辑
    /// </summary>
    public partial class ServerConsole : Page
    {
        public Thread Server;
        public StreamWriter writer = null;
        public Process p = null;
        public bool RESET;
        public bool SvInfo;//start true
        public string WriteC;
        
        public ServerConsole()
        {
            InitializeComponent();
        }
        private void ServerConsole_Load(object sender, EventArgs e)
        {
            
        }
        private void TbInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            WriteC = TbInput.Text;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(SvInfo)
            {
                WriteC = "stop";
                if (writer == null)
                {
                    MessageBox.Show("服务器未开启", "提示");
                    SvInfo = false;
                    button.Content = "开启";
                    button.Background = Brushes.Green;
                }
                else
                {
                    try
                    {
                        writer.WriteLine(WriteC);
                    }
                    catch (System.ObjectDisposedException)
                    {
                        MessageBox.Show("已关闭", "提示");
                        SvInfo = false;
                        button.Content = "开启";
                        button.Background = Brushes.Green;
                    }
                }
            }
            else
            {
                if (MainPage.SERV_Fle != null)
                {
                    if (ServerProcess.ServerVersionAndJava(MainPage.SERV_Ver, MainPage.JAVA_Nme))
                    {
                        MessageBox.Show("Java版本不适配服务器版本");
                        SvInfo = false;
                        button.Content = "开启";
                        button.Background = Brushes.Green;
                    }
                    else if (!SvInfo || RESET)
                    {
                        TbOutput.Clear();
                        Server = new Thread(STS)
                        {
                            IsBackground = true
                        };
                        Server.Start();
                    }
                    else
                    {
                        MessageBox.Show("服务器未关闭！", "提示");
                        button.Content = "开启";
                        button.Background = Brushes.Green;
                    }
                }
                else
                {
                    button.Content = "开启";
                    button.Background = Brushes.Green;
                    MessageBox.Show("请填写服务器内存和服务器API位置", "错误");
                }
            }
        }
        #region 开启服务器
        public void STS()
        {
            
            StreamWriter sw = new StreamWriter(MainPage.SERV_Pth + "\\start.bat");
            sw.Write("@echo off\ncd " + MainPage.SERV_Pth + "&" + MainPage.SERV_Pth[0] + MainPage.SERV_Pth[1] +"\n"+ MainPage.JAVA_Pth + " -jar " + MainPage.SERV_Fle + " nogui Xms" + MainPage.RAM[0] + "M Xmx" + MainPage.RAM[1] + "M\nexit");
            sw.Flush();
            sw.Close();

            if (MainPage.SERV_Fle.Length <= 7)
            {
                MessageBox.Show("请填写服务器内存和服务器API位置", "错误");
            }
            else
            {
                ProcessStartInfo start = new ProcessStartInfo(MainPage.SERV_Pth + "\\start.bat")
                {
                    CreateNoWindow = true,
                    RedirectStandardOutput = true,
                    RedirectStandardInput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false
                };
                p = Process.Start(start);
                writer = p.StandardInput;



                p.OutputDataReceived += new DataReceivedEventHandler(Serveroutput);
                p.ErrorDataReceived += new DataReceivedEventHandler(Serveroutput);
                p.BeginOutputReadLine();
                p.WaitForExit();
                p.Close();
                writer.Close();
            }
        }
        #endregion

        #region 服务器重定向输出
        void Serveroutput(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                Dispatcher.Invoke
                (
                    new Action
                    (
                        delegate 
                        {
                            ShowText(TbOutput, e.Data);
                        }
                    )
                );
            }
        }
        #endregion

        #region 判断服务器输出
        private void ShowText(TextBox tb, string line)
        {
            tb.AppendText(line + "\n");
            tb.ScrollToEnd();
            if (line.Length > 20)
            {
                try
                {
                    if (line.Substring(line.Length - 13, 13) == "Timings Reset" | line.Substring(18, 19) == " thread/INFO]: Done")
                    {
                        SvInfo = true;
                        button.Content = "关闭";
                        button.Background = Brushes.Red;
                    }
                }
                catch (System.ArgumentOutOfRangeException) { }
            }

            if (line.Length > 32)
            {
                if (line.Substring(line.Length - 19, 19) == "Closing Thread Pool" | line.Substring(line.Length - 28, 28) == "(DIM1): All chunks are saved")
                {
                    SvInfo = false;
                    button.Content = "开启";
                    button.Background = Brushes.Green;
                }
                if (line.Substring(line.Length - 23, 23) == "FAILED TO BIND TO PORT!")
                {
                    MessageBox.Show("服务器端口被占用！","错误");
                    SvInfo = false;
                    button.Content = "开启";
                    button.Background = Brushes.Green;

                }
            }
            if (line.Length > 48)
            {
                if (line.Substring(line.Length - 29, 29) == "Go to eula.txt for more info.")
                {
                    Server.Abort();
                    Process.Start("https://www.minecraft.net/en-us/eula");
                    if (System.Windows.Forms.MessageBox.Show("是否同意协议？", "设置", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        StreamWriter sw = new StreamWriter(MainPage.SERV_Pth + "\\eula.txt");
                        sw.Write("eula=true");
                        sw.Flush();
                        sw.Close();
                        RESET = true;
                    }
                    else
                    {
                        SvInfo = false;
                    }
                }
            }
        }
        #endregion

        private void TbInput_TextChanged(object sender, EventArgs e)
        {
            WriteC = TbInput.Text;
        }

        private void TbInput_Keypress(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                if (writer == null)
                {
                    MessageBox.Show("服务器未开启", "提示");
                }
                else
                {
                    try
                    {
                        if (WriteC == "stop")
                        {
                            writer.WriteLine(WriteC);
                            ShowText(TbOutput, ">>" + WriteC);
                            TbInput.Clear();
                            button.Content = "开启";
                            button.Background = Brushes.Green;
                            SvInfo = false;
                        }
                        else
                        {
                            writer.WriteLine(WriteC);
                            ShowText(TbOutput, ">>" + WriteC);
                            TbInput.Clear();
                        }
                    }
                    catch (System.ObjectDisposedException) { MessageBox.Show("服务器未开启", "提示"); }
                }
            }
        }
    }
}

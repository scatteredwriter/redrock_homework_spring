using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace RedRock_HomeWork_Spring
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public Button but;
        public string dispaly, n1, n2, f = "";
        public string num_temp;
        public string temp;
        public int leng;
        public Int64 result;
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_num_Click(object sender, RoutedEventArgs e)
        {
            but = (Button)sender;
            num_temp = but.Content.ToString();
            dispaly += num_temp;
            if(f!="")
            {
                n2 += num_temp;
            }
            else
            {
                n1 += num_temp;
            }
            tb.Text = dispaly;
        }

        private void Chehui_Click(object sender, RoutedEventArgs e)
        {
            if(dispaly==null||dispaly=="")
            {
                return;
            }
            leng = dispaly.Length;
            temp = Convert.ToString(dispaly[leng-1]);
            if(temp=="÷"||temp=="×"||temp=="－"||temp=="＋")
            {
                f = "";
            }
            else if(f!="")
            {
                leng = n2.Length;
                n2 = n2.Remove(leng - 1);
            }
            else if(f=="")
            {
                leng = n1.Length;
                n1 = n1.Remove(leng - 1);
            }
            dispaly = n1 + f + n2;
            tb.Text = dispaly;
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            if(App.time==0)
            {
                return;
            }
            Frame.Navigate(typeof(HistoryPage));
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            if(f=="")
            {
                return;
            }
            if(f=="÷")
            {
                result = Convert.ToInt64(n1) / Convert.ToInt64(n2);
            }
            else if(f=="×")
            {
                result = Convert.ToInt64(n1) * Convert.ToInt64(n2);
            }
            else if(f=="－")
            {
                result = Convert.ToInt64(n1) - Convert.ToInt64(n2);
            }
            else if(f=="＋")
            {
                result = Convert.ToInt64(n1) + Convert.ToInt64(n2);
            }
            dispaly = dispaly + "＝" + Convert.ToString(result);
            newtb();
            dispaly = Convert.ToString(result);
            tb.Text = dispaly;
            App.time++;
        }

        private void newtb()
        {
            App.history = App.history.Insert(0, "\n");
            App.history = App.history.Insert(0, dispaly);
        }

        private void Button_C_Click(object sender, RoutedEventArgs e)
        {
            tb.Text = "";
            n1 = "";
            n2 = "";
            f = "";
            num_temp = "";
            dispaly = "";
        }

        private void Button_fangfa_Click(object sender, RoutedEventArgs e)
        {
            but = (Button)sender;
            f = but.Content.ToString();
            dispaly += f;
            tb.Text = dispaly;
        }
    }
}

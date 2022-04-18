using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Marathon_Pace_Calculation
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    /// 
    public class people
    {
        public string dist { get; set; }
        public string pace { get; set; }
        public string time { get; set; }
    }

    public partial class MainWindow : Window
    {


        ObservableCollection<people> peopleList = new ObservableCollection<people>();
        public MainWindow()
        {
            InitializeComponent();
        }


        //将秒数转化为时分秒
        private string sec_to_hms(int duration)
        {
            TimeSpan ts = new TimeSpan(0, 0, Convert.ToInt32(duration));
            string str = "";
            if (ts.Hours > 0)
            {
                str = String.Format("{0:00}", ts.Hours) + ":" + String.Format("{0:00}", ts.Minutes) + ":" + String.Format("{0:00}", ts.Seconds);
            }
            if (ts.Hours == 0 && ts.Minutes > 0)
            {
                str = "00:" + String.Format("{0:00}", ts.Minutes) + ":" + String.Format("{0:00}", ts.Seconds);
            }
            if (ts.Hours == 0 && ts.Minutes == 0)
            {
                str = "00:00:" + String.Format("{0:00}", ts.Seconds);
            }
            return str;
        }


        //创建dataGrid数据
        private void LoadData(string min, string sec)
        {
            for (int i = 1; i <= 42; ++i)
            {
                peopleList.Add(new people()
                {
                    dist = i.ToString(),
                    pace = min + ":" + sec,
                    time = sec_to_hms((Convert.ToInt32(min)*60 + Convert.ToInt32(sec))*i),
                });
                if (i == 21)
                {
                    peopleList.Add(new people()
                    {
                        dist = 21.0975.ToString(),
                        pace = min + ":" + sec,
                        time = sec_to_hms((Convert.ToInt32(min) * 60 + Convert.ToInt32(sec)) * 210975/10000),
                    });
                }

                if (i == 42)
                {
                    peopleList.Add(new people()
                    {
                        dist = 42.195.ToString(),
                        pace = min + ":" + sec,
                        time = sec_to_hms((Convert.ToInt32(min) * 60 + Convert.ToInt32(sec)) * 42195 / 1000),
                    });
                }
            }
            ((this.FindName("dataGrid1")) as DataGrid).ItemsSource = peopleList;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            peopleList.Clear();
            dataGrid1.Items.Refresh();
            if (sec_value.Text != String.Empty && min_value.Text != String.Empty)
            {
                LoadData(min_value.Text, sec_value.Text);
            }
            else
            {
                MessageBox.Show("请输出正确数值！！！");
            }
        }
    }
}

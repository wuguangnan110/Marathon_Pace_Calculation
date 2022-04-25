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
        public string max_Hrate { get; set; }
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

        List<string> LS = new List<string>();

        public void addColumn(string title)
        {
            LS.Clear();
            if (title == "Hrate")
            {
                LS.Add("项目");
                LS.Add("HRR%~HRR%");
                LS.Add("最低心率");
                LS.Add("最高心率");
            }
            else if (title == "pace")
            {
                LS.Add("公里");
                LS.Add("配速");
                LS.Add("累计用时");
                LS.Add("");
            }

            //dataGrid1.Columns.Clear();
            for (int i = 0; i < LS.Count; i++)
            {
                DataGridTextColumn dl = new DataGridTextColumn();
                dataGrid1.Columns[i].Header = LS[i];
            }
        }

        //创建dataGrid数据
        private void LoadData(string min, string sec)
        {
            addColumn("pace");
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

        private void LoadDataHrate(int MHR, int RHR)
        {
            addColumn("Hrate");
            peopleList.Add(new people()
            {
                dist = "轻松跑",
                pace = "60%~65%",
                time = Convert.ToString((int)(RHR + (MHR - RHR)*0.6)),
                max_Hrate = Convert.ToString((int)(RHR + (MHR - RHR) * 0.65)),
            });

            peopleList.Add(new people()
            {
                dist = "配速跑",
                pace = "80%~85%",
                time = Convert.ToString((int)(RHR + (MHR - RHR) * 0.8)),
                max_Hrate = Convert.ToString((int)(RHR + (MHR - RHR) * 0.85)),
            });

            peopleList.Add(new people()
            {
                dist = "间歇跑",
                pace = "90%~95%",
                time = Convert.ToString((int)(RHR + (MHR - RHR) * 0.9)),
                max_Hrate = Convert.ToString((int)(RHR + (MHR - RHR) * 0.95)),
            });

            peopleList.Add(new people()
            {
                dist = "LSD",
                pace = "65%~70%",
                time = Convert.ToString((int)(RHR + (MHR - RHR) * 0.65)),
                max_Hrate = Convert.ToString((int)(RHR + (MHR - RHR) * 0.70)),
            });

            peopleList.Add(new people()
            {
                dist = "LFD",
                pace = "80%~85%",
                time = Convert.ToString((int)(RHR + (MHR - RHR) * 0.8)),
                max_Hrate = Convert.ToString((int)(RHR + (MHR - RHR) * 0.85)),
            });

            peopleList.Add(new people()
            {
                dist = "全马前半程",
                pace = "80%~85%",
                time = Convert.ToString((int)(RHR + (MHR - RHR) * 0.8)),
                max_Hrate = Convert.ToString((int)(RHR + (MHR - RHR) * 0.85)),
            });

            peopleList.Add(new people()
            {
                dist = "全马后半程",
                pace = "85%~90%",
                time = Convert.ToString((int)(RHR + (MHR - RHR) * 0.85)),
                max_Hrate = Convert.ToString((int)(RHR + (MHR - RHR) * 0.9)),
            });

            peopleList.Add(new people()
            {
                dist = "超马前半程",
                pace = "65%~70%",
                time = Convert.ToString((int)(RHR + (MHR - RHR) * 0.65)),
                max_Hrate = Convert.ToString((int)(RHR + (MHR - RHR) * 0.7)),
            });

            peopleList.Add(new people()
            {
                dist = "超马后半程",
                pace = "60%~65%",
                time = Convert.ToString((int)(RHR + (MHR - RHR) * 0.6)),
                max_Hrate = Convert.ToString((int)(RHR + (MHR - RHR) * 0.65)),
            });


            peopleList.Add(new people()
            {
                dist = "轻松跑E区间",
                pace = "59%~74%",
                time = Convert.ToString((int)(RHR + (MHR - RHR) * 0.59)),
                max_Hrate = Convert.ToString((int)(RHR + (MHR - RHR) * 0.74)),
            });

            peopleList.Add(new people()
            {
                dist = "马拉松配速M区间",
                pace = "74%~84%",
                time = Convert.ToString((int)(RHR + (MHR - RHR) * 0.74)),
                max_Hrate = Convert.ToString((int)(RHR + (MHR - RHR) * 0.84)),
            });

            peopleList.Add(new people()
            {
                dist = "乳酸阈值强度T区间",
                pace = "84%~88%",
                time = Convert.ToString((int)(RHR + (MHR - RHR) * 0.84)),
                max_Hrate = Convert.ToString((int)(RHR + (MHR - RHR) * 0.88)),
            });

            peopleList.Add(new people()
            {
                dist = "无氧耐力强度A区间",
                pace = "88%~95%",
                time = Convert.ToString((int)(RHR + (MHR - RHR) * 0.88)),
                max_Hrate = Convert.ToString((int)(RHR + (MHR - RHR) * 0.95)),
            });

            peopleList.Add(new people()
            {
                dist = "最大摄氧强度I区间",
                pace = "95%~100%",
                time = Convert.ToString((int)(RHR + (MHR - RHR) * 0.95)),
                max_Hrate = Convert.ToString((int)(RHR + (MHR - RHR) * 1)),
            });


            peopleList.Add(new people()
            {
                dist = "爆发力训练强度R区间",
                pace = "不考虑心率",
                time = "",
                max_Hrate = "",
            });

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

        private void Button_Click_Hrate(object sender, RoutedEventArgs e)
        {
            peopleList.Clear();
            dataGrid1.Items.Refresh();
            if (MHR.Text != String.Empty && RHR.Text != String.Empty)
            {
                LoadDataHrate(Convert.ToInt32(MHR.Text), Convert.ToInt32(RHR.Text));
            }
            else
            {
                MessageBox.Show("请输出正确数值！！！");
            }
        }

        private void Button_Click_help(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("MHR(Maximum Heart Rate：最大心率(心跳次数/每分钟) 懒人公式: 220-年龄\n"+
                "RHR：静止心跳(Resting Heart Rate)\n" +
                "HRR=（MHR最大心率-RHR静息心率）×强度百分比+RHR静息心率\n" +
                "参考：\n" +
                "https://www.sohu.com/a/210408415_100048225 \n" +
                "https://zhuanlan.zhihu.com/p/51501684"
                );
        }
    }
}

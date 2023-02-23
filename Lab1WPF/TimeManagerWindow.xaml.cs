using Lab1Core;
using System;
using System.Windows;

namespace Lab1WPF
{
    /// <summary>
    /// Логика взаимодействия для TimeManagerWindow.xaml
    /// </summary>
    public partial class TimeManagerWindow : Window
    {
        MyDateTime dateTime;
        public TimeManagerWindow()
        {
            InitializeComponent();
            dateTime = new MyDateTime();
            dateTime.TimeTicker += UpdateTime;
            dateTime.StartTimeTickerEvent();
        }

        void UpdateTime() => CurrentTimeLabel.Content = "Current time: " + DateTime.Now.ToString("\tdddd, dd MMMM yyyy HH:mm:ss");
    }
}

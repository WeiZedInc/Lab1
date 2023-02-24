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

        private void ValidateBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddTimeBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SubtractTimeBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FindDayBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UseTimeZoneBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SwitchCalendarBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FindPopularDayBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

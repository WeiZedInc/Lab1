using ActiproSoftware.Windows.Controls;
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
        bool isSecondBlockVisible = true;
        public TimeManagerWindow()
        {
            InitializeComponent();
            dateTime = new MyDateTime();
            dateTime.TimeTicker += UpdateTime;
            dateTime.StartTimeTickerEvent();
        }

        void UpdateTime() => CurrentTimeLabel.Content = "Current time: " + DateTime.Now.ToString("\tdddd, dd MMMM yyyy HH:mm:ss");

        private void CalculateTimeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CheckInputs() == false) return;
            string result = "";
            var dialog = new UserPromptControl()
            {
                Header = "Do you want to subtract dates?",
                Content = "Press YES to subtract. \nPress NO to add.",
                StandardButtons = UserPromptStandardButtons.YesNo,
                StandardStatusImage = UserPromptStandardImage.Question,
            };
            var answ = UserPromptWindow.ShowDialog(dialog);

            if (isSecondBlockVisible) // with curr
            {
                if (answ == UserPromptStandardResult.Yes)
                    result = dateTime.CalculateTime(true, true);
                else
                    result = dateTime.CalculateTime(true, false);
            }
            else
            {
                if (answ == UserPromptStandardResult.Yes)
                    result = dateTime.CalculateTime(false, true);
                else
                    result = dateTime.CalculateTime(false, false);
            }
            MessageBox.Show(result);
        }

        private void FindDayBtn_Click(object sender, RoutedEventArgs e)
        {
            if (dateTime.ValidateDateTime(FirstInputBox.Text, true) == false)
            {
                MessageBox.Show("Wrong input of the first date!");
                return;
            }
            MessageBox.Show(dateTime.FindDayByDate());
        }

        private void UseTimeZoneBtn_Click(object sender, RoutedEventArgs e) //
        {
            var timezones = "";
            foreach (TimeZoneInfo tz in TimeZoneInfo.GetSystemTimeZones())
                timezones += tz.DisplayName + " - \n" + tz.Id + "\n";
            MessageBox.Show(timezones + "\nChoose prefered time zone (use only english timezone names from the offered list):");

            MessageBox.Show(dateTime.SwitchTimeZones());
        }

        private void JulianCalendarBtn_Click(object sender, RoutedEventArgs e)
        {
            if (dateTime.ValidateDateTime(FirstInputBox.Text, true) == false)
            {
                MessageBox.Show("Wrong input of the first date!");
                return;
            }
            MessageBox.Show(dateTime.FindDayByDate());
        }

        private void FindPopularDayBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CheckInputs() == false) return;
            var result = dateTime.FindMostPopularDayOfTheWeek(1);
            if (result.Length == 0)
            {
                MessageBox.Show("Wrong input data!");
            }
        }

        bool CheckInputs()
        {
            if (dateTime.ValidateDateTime(FirstInputBox.Text, true) == false)
            {
                MessageBox.Show("Wrong input of the first date!");
                return false;
            }
            if (isSecondBlockVisible == true && dateTime.ValidateDateTime(SecondInputBox.Text, false) == false)
            {
                MessageBox.Show("Wrong input of the second date!");
                return false;
            }
            return true;
        }

        private void WithCurrentCheckBox_Click(object sender, RoutedEventArgs e)
        {
            isSecondBlockVisible = !isSecondBlockVisible;
            if (isSecondBlockVisible)
                SecondTimeBlock.Visibility = Visibility.Visible;
            else
                SecondTimeBlock.Visibility = Visibility.Hidden;
        }
    }
}

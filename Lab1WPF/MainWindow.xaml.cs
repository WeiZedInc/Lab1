using System.Windows;
using Lab1Core.Menu;

namespace Lab1WPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void SortManagerBtn_Click(object sender, RoutedEventArgs e)
        {
            // add new window opening with  SortManager.SortMenuSwitcher();
            SortManagerWindow sortManagerWindow = new SortManagerWindow();
            sortManagerWindow.Closed += (object? sender, System.EventArgs e) => { this.Visibility = Visibility.Visible; };
            this.Visibility = Visibility.Hidden;
            sortManagerWindow.Show();
        }

        private void TimeManagerBtn_Click(object sender, RoutedEventArgs e)
        {
            // add new window opening with  TimeManager.TimeMenuSwitcher();
            TimeManagerWindow timeManagerWindow = new TimeManagerWindow();
            timeManagerWindow.Closed += (object? sender, System.EventArgs e) => { this.Visibility = Visibility.Visible; };
            this.Visibility = Visibility.Hidden;
            timeManagerWindow.Show();
        }
    }
}

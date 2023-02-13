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

        private void TimeManagerBtn_Click(object sender, RoutedEventArgs e)
        {
            // add new window opening with  TimeManager.TimeMenuSwitcher();
        }

        private void SortManagerBtn_Click(object sender, RoutedEventArgs e)
        {
            // add new window opening with  SortManager.SortMenuSwitcher();
        }
    }
}

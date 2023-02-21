using System.Windows;
using System.Windows.Controls;

namespace Lab1WPF
{
    /// <summary>
    /// Логика взаимодействия для SortManagerWindow.xaml
    /// </summary>
    public partial class SortManagerWindow : Window
    {
        public SortManagerWindow()
        {
            InitializeComponent();
        }

        private void GetResult_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CollectionType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem selectedItem = (ComboBoxItem)CollectionType.SelectedItem;
            //MessageBox.Show("You selected: " + selectedItem.Content);
        }

        private void HowToUseButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Firstly, choose what do You want to sort:\n" +
                "1.Array<T>\n" +
                "2.List<T>\n" +
                "3.LinkedList<T>\n\n" +
                "Than choose the type (T) for desired array:\n" +
                "1.int\n" +
                "2.float\n" +
                "3.double\n" +
                "4.short\n" +
                "5.ushort\n" +
                "6.uint\n\n" +
                "Than choose the sorting alghoritm.\n" +
                "Afterall input values to the left input box and click Result button.\n\n" +
                "If You want to sort array of floating values,\nuse the WHITESPACE separator, example [23,4 -23,431 0,13f]\n\n" +
                "If You want to sort array of integers,\nuse ',' or whitespace or ';' separators", "How to use soting");
        }

        private void ValueType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SortignAlgorithm_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

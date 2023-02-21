using Lab1Core;
using System;
using System.Collections;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace Lab1WPF
{
    /// <summary>
    /// Логика взаимодействия для SortManagerWindow.xaml
    /// </summary>
    public partial class SortManagerWindow : Window
    {
        SortManager sortMngr;
        string collectionTypeName, valueTypeName, algorithmName;

        public SortManagerWindow()
        {
            InitializeComponent();
            sortMngr = SortManager.Instance;
            ExecutionTimeLabel.Visibility = Visibility.Hidden;
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


        private void GetResult_Click(object sender, RoutedEventArgs e)
        {
            OutputTextBox.Text= string.Empty;
            if (string.IsNullOrWhiteSpace(collectionTypeName) || string.IsNullOrWhiteSpace(valueTypeName) || string.IsNullOrWhiteSpace(algorithmName))
                MessageBox.Show("Unexpected error", "Error");
            var inputValues = InputTextBox.Text;
            IEnumerable? collection = null;
            switch (collectionTypeName)
            {
                case "Array":
                    collection = valueTypeName switch
                    {
                        "Int32" => sortMngr.CreateFillAndSortArray<int>(algorithmName, inputValues),
                        "Double" => sortMngr.CreateFillAndSortArray<double>(algorithmName, inputValues),
                        "Single" => sortMngr.CreateFillAndSortArray<float>(algorithmName, inputValues),
                        "Int16" => sortMngr.CreateFillAndSortArray<short>(algorithmName, inputValues),
                        "UInt16" => sortMngr.CreateFillAndSortArray<ushort>(algorithmName, inputValues),
                        "UInt32" => sortMngr.CreateFillAndSortArray<uint>(algorithmName, inputValues),
                        _ => null
                    };
                    break;
                case "List":
                    collection = valueTypeName switch
                    {
                        "Int32" => sortMngr.CreateFillAndSortList<int>(algorithmName, inputValues),
                        "Double" => sortMngr.CreateFillAndSortList<double>(algorithmName, inputValues),
                        "Single" => sortMngr.CreateFillAndSortList<float>(algorithmName, inputValues),
                        "Int16" => sortMngr.CreateFillAndSortList<short>(algorithmName, inputValues),
                        "UInt16" => sortMngr.CreateFillAndSortList<ushort>(algorithmName, inputValues),
                        "UInt32" => sortMngr.CreateFillAndSortList<uint>(algorithmName, inputValues),
                        _ => null
                    };
                    break;
                case "LinkedList":
                    collection = valueTypeName switch
                    {
                        "Int32" => sortMngr.CreateFillAndSortLinkedList<int>(algorithmName, inputValues),
                        "Double" => sortMngr.CreateFillAndSortLinkedList<double>(algorithmName, inputValues),
                        "Single" => sortMngr.CreateFillAndSortLinkedList<float>(algorithmName, inputValues),
                        "Int16" => sortMngr.CreateFillAndSortLinkedList<short>(algorithmName, inputValues),
                        "UInt16" => sortMngr.CreateFillAndSortLinkedList<ushort>(algorithmName, inputValues),
                        "UInt32" => sortMngr.CreateFillAndSortLinkedList<uint>(algorithmName, inputValues),
                        _ => null
                    };
                    break;
                default:
                    MessageBox.Show("Unexpected error", "Error");
                    break;
            }

            if (collection == null) MessageBox.Show("Unexpected error", "Error");

            foreach (var item in collection)
                OutputTextBox.Text += item + " ";
        }

        private void CollectionType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem selectedItem = (ComboBoxItem)CollectionType.SelectedItem;
            collectionTypeName = selectedItem?.Content.ToString();
        }

        private void ValueType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem selectedItem = (ComboBoxItem)ValueType.SelectedItem;
            valueTypeName = selectedItem?.Content.ToString();
        }

        private void SortignAlgorithm_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem selectedItem = (ComboBoxItem)SortignAlgorithm.SelectedItem;
            algorithmName = selectedItem?.Content.ToString();
        }

    }
}

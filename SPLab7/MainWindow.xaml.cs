using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SPLab7
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<string> rItems = new ObservableCollection<string>();
        public ObservableCollection<string> lItems = new ObservableCollection<string>();
        public MainWindow()
        {
            InitializeComponent();
            lList.ItemsSource = lItems;
            rList.ItemsSource = rItems;
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            if (!lItems.Contains(input.Text))
            {
                if(!String.IsNullOrEmpty(input.Text))
                    lItems.Add(input.Text);
                input.Text = "";
            }
            else
                MessageBox.Show($"{input.Text} already exists!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void ToRight(object sender, RoutedEventArgs e)
        {
            if (lList.SelectedItem != null && !rItems.Contains(lList.SelectedItem as String))
                rItems.Add(lList.SelectedItem as String);
        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            lItems.Clear();
            rItems.Clear();
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            if (lList.SelectedItem != null)
                lItems.Remove(lList.SelectedItem as String);
            if (rList.SelectedItem != null)
                rItems.Remove(rList.SelectedItem as String);
        }
    }
}

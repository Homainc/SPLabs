using System.Windows;

namespace SPLab8
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Draw(object sender, RoutedEventArgs e) => cnv.Visibility = Visibility.Visible;
        private void Clear(object sender, RoutedEventArgs e) => cnv.Visibility = Visibility.Hidden;
    }
}

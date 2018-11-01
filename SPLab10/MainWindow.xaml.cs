using System;
using System.Collections.Generic;
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

namespace SPLab10
{
    public partial class MainWindow : Window
    {
        private DrawWin win;
        public MainWindow()
        {
            InitializeComponent();
            this.win = new DrawWin(this);
            win.Show();
        }

        private void checkRed_Checked(object sender, RoutedEventArgs e) => win?.SetColor("red");
        private void checkGreen_Checked(object sender, RoutedEventArgs e) => win?.SetColor("green");
        private void checkBlue_Checked(object sender, RoutedEventArgs e) => win?.SetColor("blue");

        private void checkSquare_Checked(object sender, RoutedEventArgs e) => win?.SetFigure("square");
        private void checkCircle_Checked(object sender, RoutedEventArgs e) => win?.SetFigure("circle");
        private void checkRhomb_Checked(object sender, RoutedEventArgs e) => win?.SetFigure("rhomb");
        private void checkStar_Checked(object sender, RoutedEventArgs e) => win?.SetFigure("star");
    }
}

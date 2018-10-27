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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SPLabs
{
    public partial class MainWindow : Window
    {
        private TextBlock text;
        private ThicknessAnimation anim;
        private bool active = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Start(object sender, RoutedEventArgs e)
        {
            if(text == null)
            {
                text = new TextBlock();
                text.Text = "Lab 6 text";
                text.FontSize = 24;
                mainStack.Children.Add(text);
            }
            anim = new ThicknessAnimation();
            anim.From = text.Margin;
            anim.To = new Thickness(text.Margin.Left > 90?0:180, 0, 0, 0);
            anim.Duration = TimeSpan.FromSeconds(2);
            anim.AutoReverse = true;
            anim.Completed += completed;
            text.BeginAnimation(TextBlock.MarginProperty, anim);
            active = true;

        }
        private void completed(object sender, EventArgs e)
        {
            if(active)
                text.BeginAnimation(TextBlock.MarginProperty, anim);
        }
        private void Stop(object sender, RoutedEventArgs e) {
            double ml = text.Margin.Left;
            text.BeginAnimation(TextBlock.MarginProperty, null);
            text.Margin = new Thickness(ml, 0, 0, 0);
            active = false;
        }
    }
}

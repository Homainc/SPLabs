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
using System.Windows.Shapes;

namespace SPLab10
{
    public partial class DrawWin : Window
    {
        private MainWindow win;
        public DrawWin(MainWindow win)
        {
            InitializeComponent();
            this.win = win;
        }
        private void Focus(object sender, EventArgs e)
        {
            MessageBox.Show("Focused");
        }
    }
}

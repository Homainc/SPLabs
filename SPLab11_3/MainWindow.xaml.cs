using System;
using System.Threading;
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

namespace SPLab11_3
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Task.Run(new Action(Thread1));
            Task.Run(new Action(Thread2));
            Task.Run(new Action(Thread3));
        }
        public async void Thread1()
        {
            while (true)
            {
                Thread.Sleep(TimeSpan.FromSeconds(0.5));
                await Dispatcher.BeginInvoke(new Action(() => edit1.Text = new Random().Next(0, 1000).ToString()));
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
        }
        public async void Thread2()
        {
            while (true)
            {
                await Dispatcher.BeginInvoke(new Action(() => edit2.Text = new Random().Next(0, 1000).ToString()));
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
        }
        public async void Thread3()
        {
            while (true)
            {
                Thread.Sleep(TimeSpan.FromSeconds(0.2));
                await Dispatcher.BeginInvoke(new Action(() => edit3.Text = new Random().Next(0, 1000).ToString()));
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
        }
    }
}

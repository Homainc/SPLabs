using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
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

namespace SPLab13
{
    public partial class MainWindow : Window
    {
        public struct MProcess
        {
            public UInt32 id;
            public override string ToString()
            {
                return id.ToString();
            }
        }
        public ObservableCollection<Process> procs;
        public MainWindow()
        {
            InitializeComponent();
            procs = new ObservableCollection<Process>(Process.GetProcesses());
            procList.ItemsSource = procs;
        }

        private void procList_Selected(object sender, RoutedEventArgs e)
        {
            try
            {
                var proc = procList.SelectedItem as Process;
                var modules = new ObservableCollection<string>();
                foreach (ProcessModule m in proc.Modules)
                    modules.Add(m.ModuleName);
                modList.ItemsSource = modules;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void setPriority(ProcessPriorityClass prior)
        {
            try
            {
                var proc = procList.SelectedItem as Process;
                proc.PriorityClass = prior;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void High(object sender, RoutedEventArgs e) => setPriority(ProcessPriorityClass.High);
        private void Middle(object sender, RoutedEventArgs e) => setPriority(ProcessPriorityClass.High);
        private void Low(object sender, RoutedEventArgs e) => setPriority(ProcessPriorityClass.High);
    }
}

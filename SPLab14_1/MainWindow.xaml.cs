using Microsoft.Win32;
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

namespace SPLab14_1
{
    public class RegResult
    {
        public RegResult(string path, string key, string value)
        {
            this.Path = path;
            this.Key = key;
            this.Value = value;
        }
        public string Path { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
    public partial class MainWindow : Window
    {
        private string skey;
        private string okPath;
        public ObservableCollection<RegResult> results = new ObservableCollection<RegResult>();
        public MainWindow()
        {
            InitializeComponent();
            keys.ItemsSource = results;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            results.Clear();
            RegistryKey cu = Registry.CurrentUser;
            skey = txtS.Text;
            search(cu);
            
        }
        private RegResult search(RegistryKey key, string path = "")
        {
            foreach (string k in key.GetValueNames())
            {
                if (k == skey)
                {
                    okPath = path;
                    return new RegResult(path, skey, key.GetValue(skey).ToString());
                }
            }
            foreach (string k in key.GetSubKeyNames())
            {
                try
                {
                    RegResult result = search(key.OpenSubKey(k), path + $"{k}/");
                    if (result != null)
                        results.Add(result);
                }
                catch { }
            }
            return null;
        }
    }
}

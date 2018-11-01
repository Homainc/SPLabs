using System;
using System.Windows;
using System.Threading;

namespace SPLab12_4
{
    public partial class MainWindow : Window
    {
        private bool isMutex = false;
        public Mutex mutexObj = new Mutex();
        public Semaphore semaphoreObj = new Semaphore(3, 3);
        public MainWindow()
        {
            InitializeComponent();
            ThreadStart f;
            if (isMutex)
                f = MutexFunc;
            else
                f = SemaphoreFunc;
            for (int i = 0; i < 3; i++)
            {
                Thread t = new Thread(f);
                t.Name = "String" + (i+1).ToString();
                t.Start();
            }
        }
        public void MutexFunc()
        {
            mutexObj.WaitOne();
            string str = Thread.CurrentThread.Name;
            Dispatcher.BeginInvoke(new Action(()=> {
                edit.Text = str;
            }));
            mutexObj.ReleaseMutex();
        }
        public void SemaphoreFunc()
        {
            semaphoreObj.WaitOne();
            string str = Thread.CurrentThread.Name;
            Dispatcher.BeginInvoke(new Action(()=> {
                edit.Text = str;
            }));
            semaphoreObj.Release();
        }
    }
}

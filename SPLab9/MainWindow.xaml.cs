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

namespace SPLab9
{
    public partial class MainWindow : Window
    {
        private double speed = 2;
        private ObjectAnimationUsingKeyFrames imgAnim;
        private DoubleAnimation posAnimX;
        private DoubleAnimation posAnimY;
        private bool active = false;
        private Rectangle obj;
        public MainWindow()
        {
            InitializeComponent();
            obj = new Rectangle();
            obj.Fill = (ImageBrush)this.Resources["anim0"];
            obj.Height = 32;
            obj.Width = 32;
            mainCanvas.Children.Add(obj);
            Canvas.SetTop(obj, 50);
            Canvas.SetLeft(obj, 50);
            imgAnim = new ObjectAnimationUsingKeyFrames();
            imgAnim.KeyFrames.Add(new DiscreteObjectKeyFrame(this.Resources["anim0"], KeyTime.FromPercent(0)));
            imgAnim.KeyFrames.Add(new DiscreteObjectKeyFrame(this.Resources["anim1"], KeyTime.FromPercent(.25)));
            imgAnim.KeyFrames.Add(new DiscreteObjectKeyFrame(this.Resources["anim2"], KeyTime.FromPercent(.50)));
            imgAnim.KeyFrames.Add(new DiscreteObjectKeyFrame(this.Resources["anim3"], KeyTime.FromPercent(.75)));
            imgAnim.AutoReverse = true;
            imgAnim.SpeedRatio = 5;
            imgAnim.Completed += imgCompleted;
            posAnimX = new DoubleAnimation();
            posAnimY = new DoubleAnimation();
            posAnimX.Completed += moveCompleted;
        }

        private void mouseClick(object sender, MouseButtonEventArgs e)
        {
            Point p = e.GetPosition(mainCanvas);
            posAnimX.To = p.X;
            posAnimY.To = p.Y;
            active = true;
            obj.BeginAnimation(Canvas.TopProperty, posAnimY);
            obj.BeginAnimation(Canvas.LeftProperty, posAnimX);
            obj.BeginAnimation(Rectangle.FillProperty, imgAnim);
        }
        private void moveCompleted(object sender, EventArgs e)
        {
            active = false;
            obj.BeginAnimation(Rectangle.FillProperty, null);
        }
        private void imgCompleted(object sender, EventArgs e)
        {
            if(active)
                obj.BeginAnimation(Rectangle.FillProperty, imgAnim);
        }
    }
}

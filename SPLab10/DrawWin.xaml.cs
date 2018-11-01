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
        private string checkedFigure;
        public void SetFigure(string f) => checkedFigure = f;
        private string checkedColor;
        public void SetColor(string c) => checkedColor = c;
        public DrawWin(MainWindow win)
        {
            InitializeComponent();
            this.win = win;
        }
        private void Focus(object sender, EventArgs e)
        {
            if (!(bool)win.checkDraw.IsChecked)
                return;
            Color color = getColor();
            Shape figure = getFigure();
            if(figure != null)
            {
                figure.Fill = new SolidColorBrush(color);
                cnv.Children.Clear();
                cnv.Children.Add(figure);
                Canvas.SetTop(figure, 100);
                Canvas.SetLeft(figure, 100);
            }
        }
        private Color getColor()
        {
            switch (checkedColor)
            {
                case "blue":
                    return Color.FromRgb(0, 0, 255);
                case "green":
                    return Color.FromRgb(0, 255, 0);
                default:
                    return Color.FromRgb(255, 0, 0);
            }
        }
        private Shape getFigure()
        {
            switch (checkedFigure) {
                case "star":
                    Point leftTop = new Point(0, 0);
                    Point rightBottom = new Point(50, 50);
                    RectangleGeometry sq1 = new RectangleGeometry(new Rect(leftTop, rightBottom), 0, 0, new RotateTransform(45, 25, 25));
                    RectangleGeometry sq2 = new RectangleGeometry(new Rect(leftTop, rightBottom), 0, 0, new RotateTransform(0, 25, 25));
                    CombinedGeometry star = new CombinedGeometry(sq1, sq2);
                    Path path = new Path();
                    path.Data = star;
                    return path;
                case "square":
                    Rectangle sqrt = new Rectangle();
                    sqrt.Height = 70;
                    sqrt.Width = 70;
                    return sqrt;
                case "circle":
                    Ellipse crcl = new Ellipse();
                    crcl.Width = 70;
                    crcl.Height = 70;
                    return crcl;
                case "rhomb":
                    Point lT = new Point(0, 0);
                    Point rB = new Point(50, 50);
                    RectangleGeometry rhomb = new RectangleGeometry(new Rect(lT, rB), 0, 0, new RotateTransform(45, 25, 25));
                    Path p = new Path();
                    p.Data = rhomb;
                    return p;
                default:
                    return null;
            }   
        }
    }
}

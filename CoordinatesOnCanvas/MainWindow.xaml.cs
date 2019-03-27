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

namespace CoordinatesOnCanvas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Map Boundaries
        const double LATMAX = 40;
        const double LATMIN = 0;
        const double LNGMAX = 100;
        const double LNGMIN = 20;
        double LATRANGE {
            get => LATMAX - LATMIN
        }
        double LNGRANGE = LNGMAX - LNGMIN;

        // Canvas values
        const double WIDTH = 600;
        const double HEIGHT = 800;

        enum Type { Circles, Crosses};
        Type Shape { get; set; }

        // true, y = 0 === top
        // false, y = 0 === bottom
        bool OriginTop { get; set; }

        List<Point> points { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Shape = Type.Circles;
            OriginTop = true;
            points = new List<Point>();
            points.Add(new Point() { X = 20, Y = 1 });
        }

        void Draw()
        {
            canvas.Children.Clear();
            double x, y;
            points.ForEach(p =>
            {
                coordToPoint(p, out x, out y);

                if (Shape == Type.Circles)
                    DrawCircle(x, y);
                if (Shape == Type.Crosses)
                    DrawCross(x, y);
            });
        }

        private void coordToPoint(Point p, out double x, out double y)
        {
            x = (p.X - LNGMIN) * WIDTH / LNGRANGE;
            Console.WriteLine(x);
            if (OriginTop)
            {
                y = (p.Y - LATMIN) * HEIGHT / LATRANGE;
            }
            else
            {
                y = HEIGHT - ((p.Y - LATMIN) * HEIGHT / LATRANGE);
            }
        }

        void DrawCross(double x, double y)
        {
            Console.WriteLine("Test");
            Dispatcher.Invoke(() =>
            {
                var l1 = new Line()
                {
                    X1 = x - 10,
                    X2 = x + 10,
                    Y1 = y + 10,
                    Y2 = y - 10,
                    StrokeThickness = 4,
                    Stroke = Brushes.Black
                };

                var l2 = new Line()
                {
                    X1 = x - 10,
                    X2 = x + 10,
                    Y1 = y - 10,
                    Y2 = y + 10,
                    StrokeThickness = 4,
                    Stroke = Brushes.Black
                };

                canvas.Children.Add(l1);
                canvas.Children.Add(l2);
            });
        }

        void DrawCircle(double x, double y)
        {
            Dispatcher.Invoke(() =>
            {
                var circle = new Ellipse()
                {
                    Height = 20,
                    Width = 20,
                    Stroke = Brushes.Black
                };
                // Middle point of the ellipse is not the real middlepoint
                // but the upper left corner of the box the ellipse is in
                // the -10 is width/2  length/2
                Canvas.SetTop(circle, y - 10);
                Canvas.SetLeft(circle, x - 10);
                canvas.Children.Add(circle);
            });
        }

        private void Circles_Click(object sender, RoutedEventArgs e)
        {
            Shape = Type.Circles;
            Draw();
        }

        private void Crosses_Click(object sender, RoutedEventArgs e)
        {
            Shape = Type.Crosses;
            Draw();
        }

        private void TopSwitch_Click(object sender, RoutedEventArgs e)
        {
            if (OriginTop)
                TopSwitch.Content = "Boundary min is Bottom";
            else
                TopSwitch.Content = "Boundary min is Top";

            OriginTop = !OriginTop;
            Draw();
        }
    }
}

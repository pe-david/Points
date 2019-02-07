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

namespace Points
{
    /// <summary>
    /// Interaction logic for PointsRectangle.xaml
    /// </summary>
    public partial class PointsRectangle : UserControl
    {
        private static readonly int Spacing = 25;
        private static readonly int DotDiameter = 10;
        private Point _centerPoint;

        public PointsRectangle()
        {
            InitializeComponent();
        }

        private void CtrlCanvas_OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            _centerPoint = new Point((e.NewSize.Width - 1) / 2, (e.NewSize.Height - 1) / 2);
            DrawRow(_centerPoint);
        }

        private bool DrawDot(Point location)
        {
            double x = location.X;
            double y = location.Y;

            if (!PointInRect(x,y)) return false;

            var dot = new Dot(DotDiameter);
            CtrlCanvas.Children.Add(dot.Ellipse);

            Canvas.SetLeft(dot.Ellipse, x);
            Canvas.SetTop(dot.Ellipse, y);
            return true;
        }

        private void DrawRow(Point centerPoint)
        {
            var newPoint = new Point(centerPoint.X, centerPoint.Y);
            DrawDot(newPoint);

            var pointDrawn = false;
            do
            {
                newPoint = new Point(newPoint.X + Spacing, newPoint.Y);
                pointDrawn = DrawDot(newPoint);
            } while (pointDrawn);

            pointDrawn = false;
            newPoint = new Point(centerPoint.X, centerPoint.Y);
            do
            {
                newPoint = new Point(newPoint.X - Spacing, newPoint.Y);
                pointDrawn = DrawDot(newPoint);
            } while (pointDrawn);
        }

        private bool PointInRect(double x, double y)
        {
            if (!(x > 0) || !(x < this.ActualWidth))
                return false;

            return (y > 0 && y < this.ActualHeight);
        }
    }
}

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

namespace Points
{
    /// <summary>
    /// User Control of uniform points spread over a rectangle.
    /// </summary>
    /// <remarks>
    /// Spacing constant controls the spacing of the dots.
    /// DotDiameter constant controls the dot diameter.
    /// </remarks>
    public partial class PointsRectangle : UserControl
    {
        private static readonly int Spacing = 25;
        private static readonly int DotDiameter = 8;
        private Point _centerPoint;
        private List<Tuple<decimal, decimal>> _pointsList = new List<Tuple<decimal, decimal>>();

        public static readonly DependencyProperty LaserPointsProperty =
            DependencyProperty.Register(
                "LaserPoints",
                typeof(ObservableCollection<Tuple<decimal, decimal>>),
                typeof(PointsRectangle),
                new PropertyMetadata(null));

        public PointsRectangle()
        {
            InitializeComponent();
        }

        public ObservableCollection<Tuple<decimal, decimal>> LaserPoints
        {
            get { return (ObservableCollection<Tuple<decimal, decimal>>)GetValue(LaserPointsProperty); }
            set { SetValue(LaserPointsProperty, value); }
        }

        private void CtrlCanvas_OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            CtrlCanvas.Children.Clear();
            _centerPoint = new Point((e.NewSize.Width - 1) / 2, (e.NewSize.Height - 1) / 2);
            DrawGrid();
        }

        private void DrawGrid()
        {
            _pointsList.Clear();
            DrawRow(_centerPoint);

            var multiplier = 1;
            var newCenter = new Point(_centerPoint.X, _centerPoint.Y + multiplier * Spacing);
            while (PointInRect(newCenter))
            {
                DrawRow(newCenter);

                multiplier++;
                newCenter = new Point(_centerPoint.X, _centerPoint.Y + multiplier * Spacing);
            }

            multiplier = 1;
            newCenter = new Point(_centerPoint.X, _centerPoint.Y - multiplier * Spacing);
            while (PointInRect(newCenter))
            {
                DrawRow(newCenter);

                multiplier++;
                newCenter = new Point(_centerPoint.X, _centerPoint.Y - multiplier * Spacing);
            }

            var test = _pointsList.OrderBy(p => p.Item2).ThenBy(p => p.Item1);
            LaserPoints = new ObservableCollection<Tuple<decimal, decimal>>(test);
        }

        private bool DrawDot(Point location)
        {
            if (!PointInRect(location)) return false;

            _pointsList.Add(new Tuple<decimal, decimal>((decimal)location.X, (decimal)location.Y));
            var dot = new Dot(DotDiameter);
            CtrlCanvas.Children.Add(dot.Ellipse);

            Canvas.SetLeft(dot.Ellipse, location.X);
            Canvas.SetTop(dot.Ellipse, location.Y);
            return true;
        }

        private bool DrawRow(Point centerPoint)
        {
            if (!PointInRect(centerPoint)) return false;

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

            return true;
        }

        private bool PointInRect(Point location)
        {
            if (!(location.X > 0) || !(location.X < this.ActualWidth))
                return false;

            return (location.Y > 0 && location.Y < this.ActualHeight);
        }
    }
}

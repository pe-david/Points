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
        private readonly Point point;

        public PointsRectangle()
        {
            InitializeComponent();

            point = new Point(5);
            CtrlCanvas.Children.Add(point.Ellipse);
        }

        private void CtrlCanvas_OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            DrawPoints(e.NewSize.Height, e.NewSize.Width);
        }

        private void DrawPoints(double height, double width)
        {
            Canvas.SetLeft(point.Ellipse, (width - 1) / 2);
            Canvas.SetTop(point.Ellipse, (height - 1) / 2);
        }
    }
}

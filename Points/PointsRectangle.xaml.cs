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
        public PointsRectangle()
        {
            InitializeComponent();

            var point = new Point(5);
            CtrlCanvas.Children.Add(point.Ellipse);
        }
    }
}

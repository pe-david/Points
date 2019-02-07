﻿using System;
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

            point = new Point(12);
            CtrlCanvas.Children.Add(point.Ellipse);
        }

        private void CtrlCanvas_OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            double x = (e.NewSize.Width - 1) / 2;
            double y = (e.NewSize.Height - 1) / 2;
            DrawRow(x, y);
        }

        private void DrawRow(double x, double y)
        {
            if (!PointInRect(x,y)) return;

            Canvas.SetLeft(point.Ellipse, x);
            Canvas.SetTop(point.Ellipse, y);
        }

        private bool PointInRect(double x, double y)
        {
            if (!(x > 0) || !(x < this.ActualWidth))
                return false;

            return (y > 0 && y < this.ActualHeight);
        }
    }
}

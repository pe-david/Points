﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Points
{
    public class Point
    {
        public Ellipse Ellipse { get; }

        public Point(int diameter)
        {
            Ellipse = new Ellipse()
            {
                Height = diameter,
                Width = diameter,
                Fill = Brushes.Black,
                Stroke = Brushes.BlanchedAlmond,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
        }
    }
}

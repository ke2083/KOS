using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kos.Ui
{
    public struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public static Point New(int x, int y)
        {
            var p = new Point();
            p.X = x;
            p.Y = y;
            return p;
        }
    }
}

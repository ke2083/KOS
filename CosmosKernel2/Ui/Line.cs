using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kos.Ui
{
    public struct Line
    {
        public Point Start { get; set; }
        public Point End { get; set; }
        public static Line New(Point start, Point end)
        {
            var l = new Line();
            l.Start = start;
            l.End = end;
            return l;
        }
    }
}

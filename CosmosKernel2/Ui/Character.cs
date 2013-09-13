using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kos.Ui
{
    public struct Character
    {
        public char Symbol { get; set; }
        public Line[] Strokes { get; set; }
    }
}

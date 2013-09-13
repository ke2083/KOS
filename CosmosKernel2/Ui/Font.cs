using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kos.Ui
{
    public class Font
    {



        public int Height { get; set; }
        public int Width { get; set; }

        private readonly FontLookup charmap;

        /// <summary>
        /// Initializes a new instance of the Font class.
        /// </summary>
        public Font()
        {
            Height = 12;
            Width = 8;
            charmap = new FontLookup(255);
            charmap[0] = new Character()
            {
                Symbol = 'A',
                Strokes = new Line[] { 
                    Line.New(Point.New(0, Height), Point.New(Math.Abs(Width / 2), 0)),
                    Line.New(Point.New(Math.Abs(Width / 2), 0), Point.New(Width, Height)),
                    Line.New(Point.New(0,Math.Abs(Height / 2)), Point.New(Width,Math.Abs(Height / 2)))
                }
            };
            charmap[1] = new Character()
            {
                Symbol = 'B',
                Strokes = new Line[] { 
                    Line.New(Point.New(0, Height), Point.New(Math.Abs(Width / 2), 0)),
                    Line.New(Point.New(Math.Abs(Width / 2), 0), Point.New(Width, Height)),
                    Line.New(Point.New(0,Math.Abs(Height / 2)), Point.New(Width,Math.Abs(Height / 2)))
                }

            };
            charmap[2] = new Character()
            {
                Symbol = 'C',
                Strokes = new Line[] { 
                    Line.New(Point.New(0, Height), Point.New(Math.Abs(Width / 2), 0)),
                    Line.New(Point.New(Math.Abs(Width / 2), 0), Point.New(Width, Height)),
                    Line.New(Point.New(0,Math.Abs(Height / 2)), Point.New(Width,Math.Abs(Height / 2)))
                }
            };
        }

        public void Plot(char character, int x, int y, Layer layer, Colour colour)
        {
            var characterLines = charmap[character] as Line[];
            for (int i = 0; i < characterLines.Length; i++)
            {
                layer.DrawLine(characterLines[i].Start.X + x, characterLines[i].Start.Y + y, characterLines[i].End.X + x, characterLines[i].End.Y + y, colour);
            }
        }
    }
}

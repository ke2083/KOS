using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kos.Ui
{
    public class FontRenderer
    {
        private readonly Layer layer;
        private readonly Font font;
        private readonly int charWidth;
        private readonly int charHeight;

        /// <summary>
        /// Initializes a new instance of the FontRenderer class.
        /// </summary>
        public FontRenderer(Layer layer, Font font, int charWidth, int charHeight)
        {
            this.layer = layer;
            this.font = font;
            this.charWidth = charWidth;
            this.charHeight = charHeight;
        }

        public void Write(string value, int x, int y, Colour colour)
        {
            for (int i = 0; i < value.Length; i++)
            {
                var character = value[i];
                font.Plot(character, (x + charWidth) * i, y, layer, colour);
            }
        }
    }
}

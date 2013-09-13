using Cosmos.Hardware;
using System;

namespace Kos.Ui
{
    public class Canvas
    {
        #region Fields

        private Layer[] buffer = new Layer[0];

        private readonly Screen screen = null;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the Canvas class.
        /// </summary>
        public Canvas(Screen screen)
        {
            this.screen = screen;
        }

        #endregion

        #region Public Methods

        public void Clear()
        {
            this.screen.Clear();
        }

        #endregion

        #region Private Methods

        public int CreateLayer()
        {
            var newBuffer = new Layer[buffer.Length + 1];
            for (int i = 0; i < buffer.Length; i++)
            {
                newBuffer[i] = buffer[i];
            }

            var layer = new Layer(this.screen.Width, this.screen.Height);
            newBuffer[buffer.Length] = layer;
            buffer = newBuffer;
            return buffer.Length - 1;
        }

        public Layer GetLayer(int position)
        {
            return buffer[position];
        }

        public void Redraw()
        {
            for (int i = 0; i < this.screen.Width; i++)
            {
                for (int n = 0; n < this.screen.Height; n++)
                {
                    var point = false;
                    var z = buffer.Length - 1;
                    while (point == false && z >= 0)
                    {
                        if (buffer[z].HasDataAt(n, i))
                        {
                            var colour = buffer[z].ColourAt(n, i);
                            this.screen.DrawPoint(n, i, colour);
                            point = true;
                        }

                        z--;
                    }
                }
            }
        }

        #endregion

    }
}

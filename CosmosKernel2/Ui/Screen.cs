namespace Kos.Ui
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Cosmos.Hardware;

    public class Screen
    {
        #region Fields

        private readonly VGAScreen vga;

        #endregion

        #region Constructors

        public Screen(VGAScreen vga)
        {
            this.vga = vga;
        }

        /// <summary>
        /// Initializes a new instance of the Screen class.
        /// </summary>
        public Screen()
        {
            
        }

        #endregion

        #region Properties

        public int Height
        {
            get
            {
                if (vga == null) return 250;
                return vga.PixelHeight;
            }
        }

        public int Width
        {
            get
            {
                if (vga == null) return 250;
                return vga.PixelWidth;
            }
        }

        #endregion

        #region Public Methods

        public virtual void DrawPoint(int x, int y, Colour colour)
        {
            if (vga == null) return;
            vga.SetPixel((uint)x, (uint)y, (uint)colour);
        }

        public void Clear()
        {
            if (vga == null) return;
            vga.Clear((int)Colour.Black);
        }

        #endregion

    }
}

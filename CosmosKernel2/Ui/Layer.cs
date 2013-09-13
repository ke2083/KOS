using System;

namespace Kos.Ui
{
    public class Layer
    {
        #region Fields

        private readonly Colour[][] buffer = null;

        private readonly int height = 0;

        private readonly int width = 0;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the Layer class.
        /// </summary>
        public Layer(int screenWidth, int screenHeight)
        {
            height = screenHeight;
            width = screenWidth;
            buffer = new Colour[height][];
            for (int i = 0; i < height; i++)
            {
                buffer[i] = new Colour[width];
                for (int n = 0; n < buffer[i].Length; n++)
                {
                    buffer[i][n] = Colour.Black;
                }
            }
        }

        #endregion

        #region Public Methods

        public void Clear()
        {
            for (int i = 0; i < buffer.Length; i++)
            {
                for (int n = 0; n < buffer[i].Length; n++)
                {
                    buffer[i][n] = Colour.Black;
                }
            }
        }

        public Colour ColourAt(int x, int y)
        {
            return this.buffer[y][x];
        }

        public void DrawBox(int x, int y, int height, int width, Colour colour)
        {
            DrawLine(x, y, (x + width), y, colour);
            DrawLine((x + width), y, (x + width), (y + height), colour);
            DrawLine((x + width), (y + height), x, (y + height), colour);
            DrawLine(x, (y + height), x, y, colour);
        }

        public void DrawLine(int startX, int startY, int endX, int endY, Colour colour)
        {
            var steep = Math.Abs(endY - startY) > Math.Abs(endX - endY);
            if (steep)
            {
                var temp = startX;
                startX = startY;
                startY = temp;
                temp = endX;
                endX = endY;
                endY = temp;
            }

            if (startX > endX)
            {
                var temp = startX;
                startX = endX;
                endX = temp;
                temp = startY;
                startY = endY;
                endY = temp;
            }

            var deltax = (endX - startX);
            var deltay = Math.Abs(endY - startY);
            int error = deltax / 2;
            var ystep = 0;
            var y = startY;
            if (startY < endY) ystep = 1;
            else ystep = -1;
            for (int x = startX; x < endX; x++)
            {
                if (x > width) x = width;
                if (y > height) y = height;
                if (steep) this.DrawPoint(y, x, colour);
                else this.DrawPoint(x, y, colour);

                error -= (int)deltay;
                if (error < 0)
                {
                    y -= ystep;
                    error += deltax;
                }
            }

        }


        private int ipart(decimal x) {

            return (int)decimal.Floor(x);
        
        }


        private int round(int x){

        }

//function round(x) is
//     return ipart(x + 0.5)
// 
//function fpart(x) is
//     return 'fractional part of x'
// 
//function rfpart(x) is
//     return 1 - fpart(x)
// 
//function drawLine(x0,y0,x1,y1) is
//     boolean steep := abs(y1 - y0) > abs(x1 - x0)
// 
//     if steep then
//         swap(x0, y0)
//         swap(x1, y1)
//     end if
//     if x0 > x1 then
//       swap(x0, x1)
//       swap(y0, y1)
//     end if
// 
//     dx := x1 - x0
//     dy := y1 - y0
//     gradient := dy / dx
// 
//     // handle first endpoint
//     xend := round(x0)
//     yend := y0 + gradient * (xend - x0)
//     xgap := rfpart(x0 + 0.5)
//     xpxl1 := xend   //this will be used in the main loop
//     ypxl1 := ipart(yend)
//     if steep then
//         plot(ypxl1,   xpxl1, rfpart(yend) * xgap)
//         plot(ypxl1+1, xpxl1,  fpart(yend) * xgap)
//     else
//         plot(xpxl1, ypxl1  , rfpart(yend) * xgap)
//         plot(xpxl1, ypxl1+1,  fpart(yend) * xgap)
//     end if
//     intery := yend + gradient // first y-intersection for the main loop
// 
//     // handle second endpoint
// 
//     xend := round(x1)
//     yend := y1 + gradient * (xend - x1)
//     xgap := fpart(x1 + 0.5)
//     xpxl2 := xend //this will be used in the main loop
//     ypxl2 := ipart(yend)
//     if steep then
//         plot(ypxl2  , xpxl2, rfpart(yend) * xgap)
//         plot(ypxl2+1, xpxl2,  fpart(yend) * xgap)
//     else
//         plot(xpxl2, ypxl2,  rfpart(yend) * xgap)
//         plot(xpxl2, ypxl2+1, fpart(yend) * xgap)
//     end if
// 
//     // main loop
// 
//     for x from xpxl1 + 1 to xpxl2 - 1 do
//          if  steep then
//             plot(ipart(intery)  , x, rfpart(intery))
//             plot(ipart(intery)+1, x,  fpart(intery))
//         else
//             plot(x, ipart (intery),  rfpart(intery))
//             plot(x, ipart (intery)+1, fpart(intery))
//         end if
//         intery := intery + gradient
// end function





        public void DrawPoint(int x, int y, Colour colour)
        {
            this.buffer[y][x] = colour;
        }

        public bool HasDataAt(int x, int y)
        {
            return this.buffer[y][x] != Colour.Black;
        }

        #endregion

    }
}

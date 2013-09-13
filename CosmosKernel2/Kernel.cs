// ----------------------------------------------------------------
// <copyright file="Kernel.cs" company="Acromas">
// (c) Acromas Travel
// </copyright>
// <author>Kaylee.Eluvian</author>
// <created>11 September 2013</created>
// -----------------------------------------------------------------

namespace Kos
{
    using Cosmos.Hardware;
    using Kos.Ui;

    public class Kernel : Cosmos.System.Kernel
    {
        #region Fields

        private Canvas canvas = null;

        private readonly Mouse mouse = new Mouse();

        private Layer mouseLayer = null;

        private Screen screen = null;

        #endregion

        #region Protected Methods

        protected override void BeforeRun()
        {
            var vga = new VGAScreen();
            vga.SetGraphicsMode(VGAScreen.ScreenSize.Size320x200, VGAScreen.ColorDepth.BitDepth8);
            screen = new Screen(vga);
            canvas = new Canvas(screen);
            canvas.Clear();
            mouse.Initialize();
            var ml = canvas.CreateLayer();
            mouseLayer = canvas.GetLayer(ml);
            //mouseLayer.DrawLine(0, 0, 200, 200, Colour.LimeGreen);
            //canvas.Redraw();
        }

        protected override void Run()
        {
            mouseLayer.Clear();

            var f = new Font();
            var fr = new FontRenderer(mouseLayer, f, 20, 35);

            fr.Write("ABC", 0, 0, Colour.Grey);
            fr.Write("ABC", 0, 12, Colour.LightBlue);
            fr.Write("ABC", 0, 24, Colour.LightGreen);

            //mouseLayer.DrawLine(0, 0, 300, 300, Colour.Magenta);
            canvas.Redraw();
            //var input = Console.ReadLine();
            //var components = input.Split(' ');
            //var x = (uint)int.Parse(components[0]);
            //var y = (uint)int.Parse(components[1]);
            //var x1 = int.Parse(components[2]);
            //var y1 = int.Parse(components[3]);
            //var c = (uint)int.Parse(components[4]);
            //canvas.DrawBox(x, y, x1, y1, c);

        }

        #endregion

    }
}

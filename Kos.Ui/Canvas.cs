using Cosmos.Hardware;

namespace Kos.Ui
{
    public class Canvas
    {
        private readonly VGAScreen screen = null;


        /// <summary>
        /// Initializes a new instance of the Canvas class.
        /// </summary>
        public Canvas(VGAScreen screen)
        {
            this.screen = screen;
        }

        public void Clear()
        {
            this.screen.Clear(1);
        }
    }
}

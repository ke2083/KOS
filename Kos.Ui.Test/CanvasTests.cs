using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Rhino.Mocks;

namespace Kos.Ui.Test
{
    [TestFixture]
    public class CanvasTests
    {
        private Screen screen;


        [Test]
        public void TestCanvasCreatesLayerCorrectly()
        {
            screen = MockRepository.GenerateMock<Screen>();
            var canvas = new Canvas(screen);
            var layerId = canvas.CreateLayer();
            var layer = canvas.GetLayer(layerId);
            Assert.That(layer, Is.Not.Null);
        }

        [Test]
        public void TestCanvasDrawsPointCorrectly()
        {
            screen = MockRepository.GenerateStub<Screen>();
            var canvas = new Canvas(screen);
            var layerId = canvas.CreateLayer();
            var layer = canvas.GetLayer(layerId);
            layer.DrawPoint(20, 20, Colour.LightBlue);
            screen.Expect(s => s.DrawPoint(20, 20, Colour.LightBlue)).Repeat.Once();
            canvas.Redraw();
            screen.VerifyAllExpectations();
        }
    }
}

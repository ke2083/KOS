using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Kos.Ui.Test
{

    [TestFixture]
    public class LayerTests
    {
        [Test]
        public void TestLayerIsInitialisedCorrectly()
        {
            var layer = new Layer(50, 50);
            Enumerable.Range(0, 50).ToList().ForEach(x => {
                Enumerable.Range(0, 50).ToList().ForEach(y => {
                    Assert.That(layer.ColourAt(x, y), Is.EqualTo(Colour.Black));
                    Assert.That(layer.HasDataAt(x, y), Is.False);
                });           
            });
            
        }

        [Test]
        public void TestLayerCanDrawPointCorrectly()
        {
            var layer = new Layer(50, 50);
            layer.DrawPoint(25, 25, Colour.Brown);
            Enumerable.Range(0, 50).ToList().ForEach(x =>
            {
                Enumerable.Range(0, 50).ToList().ForEach(y =>
                {
                    if (x == 25 && y == 25)
                    {
                        Assert.That(layer.ColourAt(x, y), Is.EqualTo(Colour.Brown));
                        Assert.That(layer.HasDataAt(x, y), Is.True);
                    }
                    else
                    {
                        Assert.That(layer.ColourAt(x, y), Is.EqualTo(Colour.Black));
                        Assert.That(layer.HasDataAt(x, y), Is.False);
                    }
                });
            });
        }
    }
}

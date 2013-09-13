using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kos.Ui
{
    public class FontLookup
    {
        private readonly Character[] collection;
        /// <summary>
        /// Initializes a new instance of the Lookup class.
        /// </summary>
        public FontLookup(int size)
        {
            collection = new Character[size];
        }

        public Line[] this[char character]
        {
            get
            {
                for (int i = 0; i < collection.Length; i++)
                {
                    if (collection[i].Symbol == character) return collection[i].Strokes;
                }

                return new Line[0];
            }
            set
            {
                for (int i = 0; i < collection.Length; i++)
                {
                    if (collection[i].Symbol == character) collection[i].Strokes = value;
                }
            }
        }

        public Character this[int position]
        {
            get
            {
                return collection[position];
            }
            set
            {
                collection[position] = value;
            }
        }

    }

}

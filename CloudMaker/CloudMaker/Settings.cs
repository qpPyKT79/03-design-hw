using System;
using System.Collections.Generic;
using System.Drawing;
using Nuclex.Game.Packing;

namespace CloudMaker
{
    public class Settings
    {
        public CloudMakerOptions CloudOptions { get; }
        public string Filename { get; }
        public Color[] Colors { get; }

        public Settings(string filename, Func<int, int, RectanglePacker> alg, Tuple<int, int> fontSize, Color[] colors)
        {
            CloudOptions = new CloudMakerOptions(fontSize.Item1, fontSize.Item2, alg);
            Filename = filename;
            Colors = colors;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using Nuclex.Game.Packing;

namespace CloudMaker
{
    public class Settings
    {
        private static readonly Dictionary<AlgName, Func<int, int, RectanglePacker>> Packers = new Dictionary<AlgName, Func<int, int, RectanglePacker>>
        {
            {AlgName.simple, (width, height) => new SimpleRectanglePacker(width, height) },
            {AlgName.arevalo, (width, height) => new ArevaloRectanglePacker(width, height) }
        };
        public CloudMakerOptions CloudOptions { get; }
        public string Filename { get; }
        public Color[] Colors { get; }

        public Settings(string filename, AlgName alg, Tuple<int, int> fontSize, Color[] colors)
        {
            CloudOptions = new CloudMakerOptions(fontSize.Item1, fontSize.Item2,Packers[alg]);
            Filename = filename;
            Colors = colors;
        }
    }
}

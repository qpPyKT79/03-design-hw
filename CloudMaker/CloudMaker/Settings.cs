using System;
using System.Drawing;
using CloudMaker.Visualisations;

namespace CloudMaker
{
    public class Settings
    {
        public Tuple<int, int> FontSize { get; }
        public AlgName Alg { get; }
        public string Filename { get; }
        public Color[] Colors { get; }

        public Settings(string filename, AlgName alg, Tuple<int, int> fontSize, Color[] colors)
        {
            FontSize = fontSize;
            Alg = alg;
            Filename = filename;
            Colors = colors;
        }
    }
}

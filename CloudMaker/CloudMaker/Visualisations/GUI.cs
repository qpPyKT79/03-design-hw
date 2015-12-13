using System;
using System.Drawing;
using Nuclex.Game.Packing;

namespace CloudMaker.Visualisations
{
    public class GUI
    {
        public Func<int, int, RectanglePacker> GetCloudMakerAlg()
        {
            throw new NotImplementedException();
        }

        public string GetName()
        {
            throw new NotImplementedException();
        }

        public Tuple<int, int> GetSize()
        {
            throw new NotImplementedException();
        }

        public Color[] GetColors()
        {
            throw new NotImplementedException();
        }

        public void AllDone()
        {
            throw new NotImplementedException();
        }
        public Settings GetSettings() => new Settings(GetName(), GetCloudMakerAlg(), GetSize(), GetColors());
    }
}

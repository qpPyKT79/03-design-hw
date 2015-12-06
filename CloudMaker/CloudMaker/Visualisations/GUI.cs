using System;
using System.Drawing;

namespace CloudMaker.Visualisations
{
    public class GUI
    {
        public AlgName GetCloudMakerAlg()
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
        public Settings GetSettings() => new Settings(GetSize, GetCloudMakerAlg, GetName, GetColors);
    }
}

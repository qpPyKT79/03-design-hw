using System;
using System.Drawing;

namespace CloudMaker.Visualisations
{
    public class GUI : IVisulisation
    {
        public IVisulisation GetCloudMakerAlg(out AlgName cloudMakerAlg)
        {
            throw new NotImplementedException();
        }

        public IVisulisation GetName(out string sourceName)
        {
            throw new NotImplementedException();
        }

        public IVisulisation GetSize(out int minSize, out int maxSize)
        {
            throw new NotImplementedException();
        }

        public IVisulisation GetColors(out Color[] colors)
        {
            throw new NotImplementedException();
        }

        public IVisulisation AllDone()
        {
            throw new NotImplementedException();
        }
    }
}

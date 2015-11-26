using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudMaker.Visualisations
{
    public class GUI : IVisulisation
    {
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

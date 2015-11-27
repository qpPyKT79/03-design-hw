using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudMaker
{
    public interface IVisulisation
    {
        IVisulisation GetCloudMakerAlg(out string cloudMakerAlg);
        IVisulisation GetName(out string sourceName);
        IVisulisation GetSize(out int minSize, out int maxSize);
        IVisulisation GetColors(out Color[] colors);
        IVisulisation AllDone();
    }
}

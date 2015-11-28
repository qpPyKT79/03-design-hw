using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudMaker.Visualisations;

namespace CloudMaker
{
    interface ICloudMaker
    {
        List<CloudTag> CreateCloud(List<string> source, AlgName packerAlgorithm, int minSize = 1, int maxSize = 25);
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudMaker
{
    interface ICloudMaker
    {
        List<CloudTag> CreateCloud(List<string> source, int minSize, int maxSize);
    }
}

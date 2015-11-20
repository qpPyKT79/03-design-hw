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
        IEnumerable<CloudTag> CreateCloud(IEnumerable<string> source, int minSize, int maxSize);
    }
}

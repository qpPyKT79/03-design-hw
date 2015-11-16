using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudMaker
{
    interface ICloudMaker
    {
        IEnumerable<CloudTag> MakeCloud(IEnumerable<string> source);
    }
}

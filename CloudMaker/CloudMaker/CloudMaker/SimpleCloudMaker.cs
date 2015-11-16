using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudMaker.CloudMaker
{
    class SimpleCloudMaker :ICloudMaker
    {
        public IEnumerable<CloudTag> MakeCloud(IEnumerable<string> source)
        {
            throw new NotImplementedException();
        }
    }
}

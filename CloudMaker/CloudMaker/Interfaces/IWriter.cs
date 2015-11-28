using System.Collections.Generic;
using System.Drawing;

namespace CloudMaker
{
    interface IWriter
    {
        void WriteTo(List<CloudTag> tags, Color[] colors = null);
    }
}

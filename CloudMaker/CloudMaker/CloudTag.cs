using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudMaker
{
    public class CloudTag
    {
        public Color TagColor { get; }
        public int TagSize { get; }
        public int Frequency { get; }

        public CloudTag(Color tagColor, int size, int frequency)
        {
            TagColor = tagColor;
            TagSize = size;
            Frequency = frequency;
        }
    }
}

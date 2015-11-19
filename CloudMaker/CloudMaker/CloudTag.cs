using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudMaker
{
    public class CloudTag : IComparable
    {
        public Color TagColor { get; }
        public SizeF TagSize { get; }
        public float Frequency { get; }

        public string Word { get; }

        public CloudTag(Color tagColor, SizeF size, float frequency, string word)
        {
            TagColor = tagColor;
            TagSize = size;
            Frequency = frequency;
            Word = word;
        }

        public CloudTag(string word) 
        {
            Word = word;
        }

        public CloudTag SetColor(Color newColor) => new CloudTag(newColor, TagSize, Frequency, Word);

        public CloudTag SetSize(SizeF newSize) => new CloudTag(TagColor, newSize, Frequency, Word);

        public CloudTag SetFrequency(float newFrequency) => new CloudTag(TagColor, TagSize, newFrequency, Word);


        public int CompareTo(object obj)
        {
            if (Frequency > ((CloudTag) obj).Frequency) return 1;
            if (Frequency < ((CloudTag) obj).Frequency) return -1;
            return 0;
        }
    }
}

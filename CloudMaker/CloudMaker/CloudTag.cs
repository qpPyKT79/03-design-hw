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
        public Point Location { get; }

        public string Word { get; }

        private CloudTag(Color tagColor, SizeF size, float frequency, string word, Point location)
        {
            TagColor = tagColor;
            TagSize = size;
            Frequency = frequency;
            Word = word;
            Location = location;
        }

        public CloudTag(string word) 
        {
            Word = word;
        }

        public CloudTag SetColor(Color newColor) => new CloudTag(newColor, TagSize, Frequency, Word, Location);

        public CloudTag SetSize(SizeF newSize) => new CloudTag(TagColor, newSize, Frequency, Word, Location);

        public CloudTag SetFrequency(float newFrequency) => new CloudTag(TagColor, TagSize, newFrequency, Word, Location);

        public CloudTag SetLocation(Point location) => new CloudTag(TagColor, TagSize, Frequency, Word, location);


        public int CompareTo(object obj)
        {
            if (Frequency > ((CloudTag) obj).Frequency) return 1;
            if (Frequency < ((CloudTag) obj).Frequency) return -1;
            return 0;
        }
    }
}

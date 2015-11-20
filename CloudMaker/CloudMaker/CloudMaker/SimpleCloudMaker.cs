using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudMaker.CloudMaker
{
    public class SimpleCloudMaker :ICloudMaker
    {
        private Dictionary<string, float> Frequencies { get; set; }

        public SimpleCloudMaker()
        {
            Frequencies = new Dictionary<string, float>();
        }

        private IEnumerable<CloudTag> MakeCloudTags(IEnumerable<string> source)
        {
            foreach (var word in source)
            {
                if (Frequencies.ContainsKey(word))
                    Frequencies[word]++;
                else
                {
                    Frequencies[word] = 0;
                }
            }
            return Scaling;
            
        }
        private IEnumerable<CloudTag> Scaling => Frequencies.Select(pair => new CloudTag(pair.Key).SetFrequency(pair.Value));

        public IEnumerable<CloudTag> CreateCloud(IEnumerable<string> source, int minSize = 1, int maxSize = 24)
        {
            var tags = MakeCloudTags(source).ToList();
            tags = SetSize(tags).ToList();
            tags.Sort();
            return SetLocatons(tags);
        }

        private IEnumerable<CloudTag> SetLocatons(IEnumerable<CloudTag> tags)
        {
            var canvas = new Mapper.Canvas();
            return tags.Select(tag =>
            {
                var x = 0;
                var y = 0;
                var z = 0;
                canvas.AddRectangle((int)tag.TagSize.Width, (int)tag.TagSize.Height, out x, out y, out z);
                return tag.SetLocation(new Point(x, y));
            });
        }

        private static IEnumerable<CloudTag> SetSize(IEnumerable<CloudTag> tags)
        {
            using (Image tempImage = new Bitmap(1, 1))
            using (var g = Graphics.FromImage(tempImage))
                return tags.Select(
                    tag => tag.SetSize(g.MeasureString(tag.Word, new Font(FontFamily.GenericSerif, tag.Frequency))));
        }
    }
}

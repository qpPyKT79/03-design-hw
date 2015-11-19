using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudMaker.CloudMaker
{
    class SimpleCloudMaker :ICloudMaker
    {
        private Dictionary<string, float> Frequencies { get; set; }

        private Image Image { get; set; }
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

        public Image CreateCloud(IEnumerable<string> source, int minSize = 1, int maxSize = 24)
        {
            var tags = MakeCloudTags(source).ToList();
            SetSize(tags);
            tags.Sort();
            var canvas  = new Mapper.Canvas();
            foreach (var tag in tags)
            {
                var x = 0;
                var y = 0;
                var z = 0;
                canvas.AddRectangle((int) tag.TagSize.Width, (int) tag.TagSize.Height, out x, out y, out z);
                
            }
            return null;
        }

        private static void SetSize(IEnumerable<CloudTag> tags)
        {
            using (Image tempImage = new Bitmap(1, 1))
            using (var g = Graphics.FromImage(tempImage))
                tags.Select(tag => g.MeasureString(tag.Word, new Font(FontFamily.GenericSerif, tag.Frequency)));
        }
    }
}

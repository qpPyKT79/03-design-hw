using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudMaker.Visualisations
{
    public class CUI : IVisulisation
    {
        public CUI() { }

        public IVisulisation GetName(out string sourceName)
        {
            Console.WriteLine("Plese type Filename");
            sourceName = Console.ReadLine();
            return this;
        }

        public IVisulisation GetSize(out int minSize, out int maxSize)
        {
            Console.WriteLine("Size is not set or minSize > maxSize");
            Console.WriteLine("Write u min and max size");
            minSize = int.Parse(Console.ReadLine());
            maxSize = int.Parse(Console.ReadLine());
            return minSize <= maxSize ? this :  GetSize(out minSize, out maxSize);
        }

        public IVisulisation GetColors(out Color[] colors)
        {
            Console.WriteLine("Write colors separated with whitespase (if u dont want to set up colors, just set an empty string)");
            var stringColors = Console.ReadLine();
            colors = string.IsNullOrWhiteSpace(stringColors) ? null: stringColors.Split(' ').Select(Color.FromName).ToArray();
            return this;
        }

        public IVisulisation AllDone()
        {
            Console.WriteLine("Done!");
            return this;
        }
    }
}

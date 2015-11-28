using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace CloudMaker.Visualisations
{
    public enum AlgName
    {
        arevalo,
        simple
    }

    public class CUI : IVisulisation
    {
        private static HashSet<string> algs = new HashSet<string> {"arevalo", "simple"} ;
        public IVisulisation GetCloudMakerAlg(out AlgName cloudMakerAlg)
        {
            cloudMakerAlg = AlgName.arevalo;
            Console.WriteLine();
            Console.WriteLine("Set algorithm of making cloud, members are:");
            Console.WriteLine(string.Join(" ",algs));
            Console.WriteLine();
            Console.WriteLine("if u dont want to set up this field. just set an empty string");
            var inputString = Console.ReadLine();
            AlgName.TryParse(inputString, out cloudMakerAlg);
            return this;

        }

        public IVisulisation GetName(out string sourceName)
        {
            Console.WriteLine("Plese type Filename");
            sourceName = Console.ReadLine();
            return this;
        }

        public IVisulisation GetSize(out int minSize, out int maxSize)
        {
            minSize = 5;
            maxSize = 25;
            Console.WriteLine();
            Console.WriteLine("Font size is not set or minSize > maxSize");
            Console.WriteLine("Note! minSIze must be >= 5 and maxSize <= 25");
            Console.WriteLine("Write u min and max size separated with whitespace");
            Console.WriteLine();
            Console.WriteLine("if u dont want to set up font size, just set an empty string");
            var sizeString = Console.ReadLine();
            var sizeNums = string.IsNullOrEmpty(sizeString) ? null : sizeString.Split(' ').Select(int.Parse).ToArray();
            if (sizeNums?.Length<2)
                GetSize(out minSize, out maxSize);
            else
            {
                if (sizeNums == null)
                    return this;
                minSize = sizeNums[0];
                maxSize = sizeNums[1];
            }
            return minSize>=5 && maxSize<= 25 && minSize!=maxSize? this : GetSize(out minSize, out maxSize);
        }

        public IVisulisation GetColors(out Color[] colors)
        {
            Console.WriteLine();
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

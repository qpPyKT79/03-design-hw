using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudMaker.Filters;
using CloudMaker.Readers;
using CloudMaker.Visualisations;
using CloudMaker.Writers;

namespace CloudMaker
{
    public class MainArgs
    {
        public static readonly Dictionary<string, Type> description = new Dictionary<string, Type>
        {
            {"list", typeof(ListFileReader) },
            {"CUI", typeof (CUI)},
            {"GUI", typeof (GUI)},
            {"png", typeof (PngWriter)},
            {"jpeg", typeof (JpegWriter)},
            {"normalizer", typeof(Normalizer)},
            {"boringWords", typeof (BoringWords)}
        };
        public Type InputFileType { get; set; }
        public Type Visualisation { get; set; }
        public Type OutputFileType { get; set ; }
        public List<Type> Filters { get; set; }

        public MainArgs(string[] args)
        {
            if (args.Length<3) errorPrint();
            InputFileType = description[args[0]];
            Visualisation = description[args[1]];
            OutputFileType = description[args[2]];
            Filters = new List<Type>();
            if (args.Length >= 4) Filters.Add(description[args[3]]);
            if (args.Length == 5) Filters.Add(description[args[4]]);
        }

        private void errorPrint() => Console.WriteLine("arguments not enough \n " +
                                                 "unput type (required): list or text \n " +
                                                 "vusialization type (required): CUI or GUI" +
                                                 "output type (required): png or jpeg" +
                                                 "filters (not required): normalizer or/and boringWords");
    }
}

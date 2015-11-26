using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudMaker.Filters;
using CloudMaker.Readers;
using CloudMaker.Visualisations;
using CloudMaker.Writers;
using CommandLine;
using CommandLine.Text;

namespace CloudMaker
{
    public class Options
    {
        public static readonly Dictionary<string, Type> a = new Dictionary<string, Type>
        {
            {"CUI", typeof (CUI)},
            {"GUI", typeof (GUI)},
            {"png", typeof (PngWriter)},
            {"jpeg", typeof (JpegWriter)},
            {"normalizer", typeof(Normalizer)},
            {"boringWords", typeof (BoringWords)},
            {"doc", typeof (DocFileReader)},
            {"txt", typeof (TxtFileReader)}
        };

        [Option(Required = true, HelpText = "Input filename")]
        public string InputFileName { get; set; }

        [Option(Required = true, HelpText = "visualisation type: CUI or GUI")]
        public string Visualisation { get; set; }

        [Option(Required = true, HelpText = "output file type: png or jpeg")]
        public string OutputFileName { get; set ; }

        [OptionList(Required = true, HelpText = "filters: boringWOrds or/and Normalizer")]
        public string[] Filters { get; set; }
    }
}

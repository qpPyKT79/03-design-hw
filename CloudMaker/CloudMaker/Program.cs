using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudMaker.CloudMaker;
using CloudMaker.Filters;
using CloudMaker.Readers;
using CloudMaker.Visualisations;
using CloudMaker.Writers;
using System.Drawing;
using NHunspell;
using Ninject;

namespace CloudMaker
{
    class Program
    {
        private ICloudMaker Maker { get; }
        private IFilter[] Filters { get; }
        private ISourceReader Reader { get; }
        private IVisulisation UI { get; }
        private IWriter Writer { get; }

        public Program(ICloudMaker maker, IFilter[] filters, ISourceReader reader, IVisulisation ui, IWriter writer)
        {
            Maker = maker;
            Filters = filters;
            Reader = reader;
            UI = ui;
            Writer = writer;
        }
        
        static void Main(string[] args)
        {
            var kernel = new StandardKernel();
            kernel.Bind<ICloudMaker>().To<SimpleCloudMaker>();
            kernel.Bind<IFilter>().To<Normalizer>();
            kernel.Bind<IFilter>().To<BoringWords>();
            kernel.Bind<ISourceReader>().To<TxtFileReader>();
            kernel.Bind<ISourceReader>().To<DocFileReader>();
            kernel.Bind<IVisulisation>().To<CUI>();
            kernel.Bind<IVisulisation>().To<GUI>();
            kernel.Bind<IWriter>().To<PngWriter>();
            kernel.Bind<IWriter>().To<JpegWriter>();
            new Program(kernel.Get<SimpleCloudMaker>(),
                new [] {kernel.Get<Normalizer>()}, 
                kernel.Get<TxtFileReader>(), 
                kernel.Get<CUI>(), 
                kernel.Get<PngWriter>() ).Run();

        }

        public void Run()
        {
            //фильтры и конфигурация на аргументах ком строки
            var inputFilename = string.Empty;
            int minSize;
            int maxSize;
            Color[] colors;
            UI.GetName(out inputFilename).GetSize(out minSize, out maxSize).GetColors(out colors);
            Writer.WriteTo(Maker.CreateCloud(Reader.ReadWords(inputFilename, Filters), minSize, maxSize), colors);
            UI.AllDone();
        }
    }
}

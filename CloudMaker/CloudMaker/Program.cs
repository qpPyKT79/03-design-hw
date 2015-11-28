using System.Linq;
using CloudMaker.CloudMaker;
using CloudMaker.Filters;
using CloudMaker.Visualisations;
using CloudMaker.Writers;
using System.Drawing;
using CloudMaker.SourceReaders;
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

        private Program(ICloudMaker maker, IFilter[] filters, ISourceReader reader, IVisulisation ui, IWriter writer)
        {
            Maker = maker;
            Filters = filters;
            Reader = reader;
            UI = ui;
            Writer = writer;
        }
        
        static void Main(string[] argv)
        {
            var kernel = new StandardKernel();
            var args = new MainArgs(argv);
            kernel.Bind<ICloudMaker>().To<SimpleCloudMaker>();
            kernel.Bind<IFilter>().To<Normalizer>();
            kernel.Bind<IFilter>().To<BoringWords>();
            kernel.Bind<ISourceReader>().To<ListFileReader>();
            kernel.Bind<IVisulisation>().To<CUI>();
            kernel.Bind<IVisulisation>().To<GUI>();
            kernel.Bind<IWriter>().To<PngWriter>();
            kernel.Bind<IWriter>().To<JpegWriter>();
            new Program(kernel.Get<SimpleCloudMaker>(),
                args.Filters.Select(filter => (IFilter)kernel.Get(filter)).ToArray(),
                (ISourceReader)kernel.Get(args.InputFileType), 
                (IVisulisation)kernel.Get(args.Visualisation),
                (IWriter)kernel.Get(args.OutputFileType)).Run();
        }

        private void Run()
        {
            var inputText = Reader.ReadWords(UI.GetName(), Filters);
            var size = UI.GetSize();
            if (inputText.Count >0)
                Writer.WriteTo(Maker.CreateCloud(inputText, UI.GetCloudMakerAlg(), size.Item1, size.Item2), UI.GetColors());
            UI.AllDone();
        }
    }
}

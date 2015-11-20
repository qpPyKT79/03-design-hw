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
using NHunspell;
using Ninject;

namespace CloudMaker
{
    class Program
    {
        
        static void Main(string[] args)
        {
            var kernel = new StandardKernel();
            kernel.Bind<ICloudMaker>().To<SimpleCloudMaker>();
            kernel.Bind<IFilter>().To<Normalizer>();
            kernel.Bind<IFilter>().To<BoringWords>();
            kernel.Bind<ISourceReader>().To<TxtFileReader>();
            kernel.Bind<ISourceReader>().To<DocFileReader>();
            kernel.Bind<ITextReader>().To<ListReader>();
            kernel.Bind<IVisulisation>().To<CUI>();
            kernel.Bind<IVisulisation>().To<GUI>();
            kernel.Bind<IWriter>().To<PngWriter>();
            kernel.Bind<IWriter>().To<JpegWriter>();
        }

        public void Run()
        {
            
        }
    }
}

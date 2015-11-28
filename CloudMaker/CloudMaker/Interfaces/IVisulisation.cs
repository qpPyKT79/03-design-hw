using System;
using System.Drawing;
using CloudMaker.Visualisations;

namespace CloudMaker
{
    public interface IVisulisation
    {
        AlgName GetCloudMakerAlg();
        string GetName();
        Tuple<int,int> GetSize();
        Color[] GetColors();
        void AllDone();
    }
}

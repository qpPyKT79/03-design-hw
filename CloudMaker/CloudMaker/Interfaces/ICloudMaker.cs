﻿using System.Collections.Generic;
using CloudMaker.Visualisations;

namespace CloudMaker
{
    public interface ICloudMaker
    {
        List<CloudTag> CreateCloud(List<string> source, AlgName packerAlgorithm, int minSize = 1, int maxSize = 25);
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudMaker.Filters
{
    public class BoringWords :IFilter
    {
        //todo: фильтрация не нужных слов (предлоги союзы и проч)
        public BoringWords()
        {
            
        } 
        public IEnumerable<string> FilterWords(IEnumerable<string> words)
        {
            throw new NotImplementedException();
        }
    }
}

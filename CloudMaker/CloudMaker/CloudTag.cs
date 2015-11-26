﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudMaker
{
    public class CloudTag : IComparable
    {
        public SizeF TagSize { get; }
        public float Frequency { get; }
        public float X { get; }
        public float Y { get; }

        public string Word { get; }

        private CloudTag(SizeF size, float frequency, string word, float x, float y)
        {
            TagSize = size;
            Frequency = frequency;
            Word = word;
            X = x;
            Y = y;
        }

        public CloudTag(string word) 
        {
            Word = word;
        }

        public CloudTag SetSize(SizeF newSize) => new CloudTag(newSize, Frequency, Word, X, Y);

        public CloudTag SetFrequency(float newFrequency) => new CloudTag(TagSize, newFrequency, Word, X, Y);
        
        public CloudTag SetLocation(float x, float y) => new CloudTag(TagSize, Frequency, Word, x,y);


        public int CompareTo(object obj)
        {
            if (Frequency > ((CloudTag) obj).Frequency) return 1;
            if (Frequency < ((CloudTag) obj).Frequency) return -1;
            return 0;
        }
    }
}

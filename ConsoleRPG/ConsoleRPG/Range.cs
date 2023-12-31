using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    internal class Range
    {
        public Range(int mLow, int mHigh)
        {
            this.Low = mLow;
            this.Hight = mHigh;
        }

        public int Low { get; set; }
        public int Hight { get; set; }
    }
}

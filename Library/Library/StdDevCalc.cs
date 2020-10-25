using System;
using System.Collections.Generic;
using System.Linq;
using Oligonucs;

namespace Library
{
    public class StdDevCalc
    {
        public StdDevCalc()
        {
        }

        public void Calc(List<TrinucDiff> triDiff)
        {
            List<double> cdsDiff = new List<double>();
            List<double> ncdsDiff = new List<double>();

            foreach (var item in triDiff)
            {
                if (item.SeqType == "NCDS")
                {
                    ncdsDiff.Add(item.DiffSum);
                }
                else
                {
                    cdsDiff.Add(item.DiffSum);
                }
            }

            double cdsMean = cdsDiff.Average();
            double ncdsMean = ncdsDiff.Average();
        }
    }
}

using System;
using System.Linq;
using Oligonucs;
using System.Collections.Generic;

namespace Library
{
    public class TrinucStd
    {
        public double Mean { get; set; } = 0;
        public double Deviation { get; set; } = 0;
    }

    public class CalculateStdDev
    {
        public TrinucStd CalcStdDev(List<double> values)
        {
            TrinucStd trinucStd = new TrinucStd();

            if (values.Count > 0)
            {
                trinucStd.Mean = values.Average();

                //Perform the Sum of (value-avg)^2
                double sum = values.Sum(d => Math.Pow(d - trinucStd.Mean, 2));

                //Perform Standard dev
                trinucStd.Deviation = Math.Sqrt((double)sum / (double)(values.Count - 1));
            }

            return trinucStd;
        }
    }
}

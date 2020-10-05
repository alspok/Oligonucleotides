using System;
using System.Linq;
using System.Collections.Generic;

namespace Library
{
    public class CalculateStdDev
    {

        public double CalcStdDev(List<double> values)
        {

            double ret = 0;

            if (values.Count > 0)
            {
                //Compute the Average
                double avg = values.Average();

                //Perform the Sum of (value-avg)^2
                double sum = values.Sum(d => Math.Pow(d - avg, 2));

                //Put it all together
                ret = Math.Sqrt((sum) / values.Count - 1);
            }
            return ret;
        }
    }
}

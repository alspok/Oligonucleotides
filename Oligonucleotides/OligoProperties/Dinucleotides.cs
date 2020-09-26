using System;

namespace Oligonucs
{
        public class Dinucleotides
	{
        	public string Dinuc { get; set; }
                public int Dinuc1st { get; set; } = 0;
                public int Dinuc2nd { get; set; } = 0;
                public double DinucFrq1st { get; set; } = 0;
                public double DinucFrq2nd { get; set; } = 0;
                public double DinucFrqDiff { get; set; } = 0;
	}

        public class DinucArray
        {
                public string[] dinuc = new string[64];
                public string[] monoNuc = { "a", "c", "g", "t" };

                public DinucArray()
                {
                        int i = 0;
                        foreach (var item1 in monoNuc)
                        {
                                foreach (var item2 in monoNuc)
                                {
                                        dinuc[i++] = item1 + item2;
                                }
                        }
                }
        }

        public class DinucCalculation
        {
                public Dinucleotides[] dinucleotides = new Dinucleotides[16];
                DinucArray dinucArray = new DinucArray();

        		public DinucCalculation()
        		{
                        for (int i = 0; i < 16; i++)
                        {
                            dinucleotides[i] = new Dinucleotides
                            {
                                Dinuc = dinucArray.dinuc[i]
                            };
                        }
                }
        }
}
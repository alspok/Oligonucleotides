using System;
namespace Oligonucleotides
{
        public class Trinucleotides
        {
            public string Trinuc { get; set; }
            public int Trinuc1st { get; set; }
            public int Trinuc2nd { get; set; }
            public int Trinuc3rd { get; set; }
            public double TrinucFrq1st { get; set; }
            public double TrinucFrq2nd { get; set; }
            public double TrinucFrq3rd { get; set; }
            public double TrinucDiff1st2nd { get; set; }
            public double TrinucDiff2nd3rd { get; set; }
            public double TrinucDiff1st3rd { get; set; }
            public double TrinucDiffSum { get; set; }
        }

        public class TrinucArray
        {
            public string[] trinuc = new string[64];
            public string[] monoNuc = { "a", "c", "g", "t" };

            public TrinucArray()
            {
                int i = 0;
                foreach (var item1 in monoNuc)
                {
                    foreach (var item2 in monoNuc)
                    {
                        foreach (var item3 in monoNuc)
                        {
                            trinuc[i++] = item1 + item2 + item3;
                        }
                    }
                }
            }
        }

        public class TrinucCalculation
        {
            public Trinucleotide[] trinucleotides = new Trinucleotide[64];
            TrinucArray trinucArray = new TrinucArray();

            public TrinucCalculation()
            {
                for (int i = 0; i < 64; i++)
                {
                    trinucleotides[i] = new Trinucleotide
                    {
                        Trinuc = trinucArray.trinuc[i],
                        Trinuc1st = 0,
                        Trinuc2nd = 0,
                        Trinuc3rd = 0,
                        TrinucFrq1st = 0,
                        TrinucFrq2nd = 0,
                        TrinucFrq3rd = 0,
                        TrinucDiff1st2nd = 0,
                        TrinucDiff2nd3rd = 0,
                        TrinucDiff1st3rd = 0,
                        TrinucDiffSum = 0
                    };
                }
            }
        }
    }
}

using System;

namespace Oligonucleotides
{
        public class Trinucleotides
        {
                public string Trinuc { get; set; }
                public int Trinuc1st { get; set; } = 0;
                public int Trinuc2nd { get; set; } = 0;
                public int Trinuc3rd { get; set; } = 0;
                public double TrinucFrq1st { get; set; } = 0;
                public double TrinucFrq2nd { get; set; } = 0;
                public double TrinucFrq3rd { get; set; } = 0;
                public double TrinucDiff1st2nd { get; set; } = 0;
                public double TrinucDiff2nd3rd { get; set; } = 0;
                public double TrinucDiff1st3rd { get; set; } = 0;
                public double TrinucDiffSum { get; set; } = 0;
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
                public Trinucleotides[] trinucleotides = new Trinucleotides[64];
                TrinucArray trinucArray = new TrinucArray();

                public TrinucCalculation()
                {
                        for (int i = 0; i < 64; i++)
                        {
                                trinucleotides[i] = new Trinucleotides
                                {
                                        Trinuc = trinucArray.trinuc[i]
                                };
                        }
                }
        }
}

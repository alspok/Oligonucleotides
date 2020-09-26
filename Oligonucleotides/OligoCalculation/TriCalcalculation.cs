using System;
using System.Collections.Generic;
using Oligonucs;

namespace OligoCalculation
{
    //Seq trinucleotides calculation. No constructor class
    public class TriCalculation
    {
            TrinucArray trinucArray = new TrinucArray();
            List<TrinucleotideMatch> trinucMatches = new List<TrinucleotideMatch>();
            TrinucCalculation trinucCalculation = new TrinucCalculation();
            TrinucDiff trinucDiff = new TrinucDiff();

        int trinucCount = 0;

        public TrinucDiff TriCalc(string seqType, string seq)
        {
                string seqCalc = "nnn" + seq + seq.Substring(0, 9);

                for(int i = 0; i < seqCalc.Length - 9; i++)
                {
                    string oligoFrag = seqCalc.Substring(i, 3);

                    if (Array.IndexOf(trinucArray.trinuc, oligoFrag) < 0)
                    {
                        trinucMatches.Add(new TrinucleotideMatch { TrinucPosition = i, TrinucMatch = oligoFrag });
                        continue;
                    }

                    if (i % 3 == 0)
                    {
                        var index = Array.FindIndex(trinucCalculation.trinucleotides, row => row.Trinuc == oligoFrag);
                        trinucCalculation.trinucleotides[index].Trinuc1st += 1;
                        trinucCount += 1;
                    }
                    else if ((i - 1) % 3 == 0)
                    {
                        var index = Array.FindIndex(trinucCalculation.trinucleotides, row => row.Trinuc == oligoFrag);
                        trinucCalculation.trinucleotides[index].Trinuc2nd += 1;
                    }
                    else if ((i - 2) % 3 == 0)
                    {
                        var index = Array.FindIndex(trinucCalculation.trinucleotides, row => row.Trinuc == oligoFrag);
                        trinucCalculation.trinucleotides[index].Trinuc3rd += 1;
                    }
                }

                foreach (var item in trinucCalculation.trinucleotides)
                {
                    item.TrinucFrq1st = (double)item.Trinuc1st / trinucCount;
                    item.TrinucFrq2nd = (double)item.Trinuc2nd / trinucCount;
                    item.TrinucFrq3rd = (double)item.Trinuc3rd / trinucCount;

                    item.TrinucFrqDiff1st2nd = Math.Abs(item.TrinucFrq1st - item.TrinucFrq2nd);
                    item.TrinucFrqDiff1st3rd = Math.Abs(item.TrinucFrq1st - item.TrinucFrq3rd);
                    item.TrinucFrqDiff2nd3rd = Math.Abs(item.TrinucFrq2nd - item.TrinucFrq3rd);
                }

                trinucDiff.SeqType = seqType;

                foreach (var item in trinucCalculation.trinucleotides)
                {
                    trinucDiff.DiffSum1st2nd += item.TrinucFrqDiff1st2nd;
                    trinucDiff.DiffSum1st3rd += item.TrinucFrqDiff1st3rd;
                    trinucDiff.DiffSum2nd3rd += item.TrinucFrqDiff2nd3rd;
                }

                trinucDiff.DiffSum = trinucDiff.DiffSum1st2nd + trinucDiff.DiffSum1st3rd + trinucDiff.DiffSum2nd3rd;

                return trinucDiff;
        }
    }
}

using System;
using Oligonucleotides;

namespace TrinucConsole
{
        public class TrinucleotideCalc
        {
                TrinucArray trinucArray = new TrinucArray();
                public string seq;
                public Trinucleotides[] trinucleotide;

                //Constructor
                public TrinucleotideCalc(string seq)
                {
                        this.seq = seq;
                        trinucleotide = new Trinucleotides[64];

                        for (var i = 0; i < 64; i++)
                        {
                                trinucleotide[i] = new Trinucleotides{ Trinuc = trinucArray.trinuc[i],
                                                                                                Trinuc1st = 0, Trinuc2nd = 0, Trinuc3rd = 0,
                                                                                                TrinucFrq1st = 0, TrinucFrq2nd = 0, TrinucFrq3rd = 0,
                                                                                                TrinucDiff1st2nd = 0, TrinucDiff2nd3rd = 0, TrinucDiff1st3rd = 0,
                                                                                                TrinucDiffSum = 0 };
                        }
                }

                public void TrinucCalc()
                {
                        string seqTrinuc = string.Empty;
                        int trinucIndex = 0;
                        int firstFrame = 0;
                        int secondFrame = 0;
                        int thirdFrame = 0;

                        string seqCalc = seq + seq.Substring(0, 6);

                        for (int i = 0; i < seq.Length; i +=3)
                        {
                                seqTrinuc = seqCalc.Substring(i, 3);
                                trinucIndex = Array.FindIndex(trinucArray.trinuc, item => item == seqTrinuc);
                                trinucleotide[trinucIndex].Trinuc1st += 1;
                                firstFrame += 1;
                        }

                        for (int i = 1; i < seq.Length + 1; i += 3)
                        {
                                seqTrinuc = seqCalc.Substring(i, 3);
                                trinucIndex = Array.FindIndex(trinucArray.trinuc, item => item == seqTrinuc);
                                trinucleotide[trinucIndex].Trinuc2nd += 1;
                                secondFrame += 1;
                        }

                        for (int i =2; i < seq.Length + 2; i += 3)
                        {
                                seqTrinuc = seqCalc.Substring(i, 3);
                                trinucIndex = Array.FindIndex(trinucArray.trinuc, item => item == seqTrinuc);
                                trinucleotide[trinucIndex].Trinuc3rd += 1;
                                thirdFrame += 1;
                        }

                        foreach (var item in trinucleotide)
                        {
                                item.TrinucFrq1st = (double)item.Trinuc1st / (double)firstFrame;
                                item.TrinucFrq2nd = (double)item.Trinuc2nd / (double)secondFrame;
                                item.TrinucFrq3rd = (double)item.Trinuc3rd / (double)thirdFrame;
                        }

                        foreach (var item in trinucleotide)
                        {
                                item.TrinucDiff1st2nd = Math.Abs(item.TrinucFrq1st - item.TrinucFrq2nd);
                                item.TrinucDiff2nd3rd = Math.Abs(item.TrinucFrq2nd - item.TrinucFrq3rd);
                                item.TrinucDiff1st3rd = Math.Abs(item.TrinucFrq1st - item.TrinucFrq3rd);
                        }

                        foreach (var item in trinucleotide)
                        {
                                item.TrinucDiffSum = item.TrinucDiff1st2nd + item.TrinucDiff2nd3rd + item.TrinucDiff1st3rd;
                        }

                        //TrinucOutput trinucOutput = new TrinucOutput(seq, trinucleotide);
                        //trinucOutput.TrinucOut();
                }
        }
}

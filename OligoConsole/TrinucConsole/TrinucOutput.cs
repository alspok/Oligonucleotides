using System;
using Oligonucleotides;

namespace TrinucConsole
{
        public class TrinucOutput
        {
                private string seq;
                private Trinucleotides[] trinucleotide;

                public TrinucOutput(string seq, Trinucleotides[] trinucleotide)
                {
                        this.seq = seq;
                        this.trinucleotide = trinucleotide;
                }

                public void TrinucOut()
                {
                        //Console.WriteLine("Seq: " + seq);
                        Console.WriteLine("Seq length: " + seq.Length + "\n");

                        foreach (var item in trinucleotide)
                        {
                                Console.Write(item.Trinuc + "\t");
                        }
                        Console.WriteLine("\n");

                        foreach (var item in trinucleotide)
                        {
                                Console.Write(item.Trinuc1st + "\t");
                        }
                        Console.WriteLine();

                        foreach (var item in trinucleotide)
                        {
                                Console.Write(item.Trinuc2nd + "\t");
                        }
                        Console.WriteLine();

                        foreach (var item in trinucleotide)
                        {
                                Console.Write(item.Trinuc3rd + "\t");
                        }
                        Console.WriteLine("\n");

                        foreach (var item in trinucleotide)
                        {
                                Console.Write(item.TrinucFrq1st.ToString("0.0000") + "\t");
                        }
                        Console.WriteLine();

                        foreach (var item in trinucleotide)
                        {
                                Console.Write(item.TrinucFrq2nd.ToString("0.0000") + "\t");
                        }
                        Console.WriteLine();

                        foreach (var item in trinucleotide)
                        {
                                Console.Write(item.TrinucFrq3rd.ToString("0.0000") + "\t");
                        }
                        Console.WriteLine("\n");

                        for (var i = 0; i < 64; i++)
                        {
                                Console.Write(trinucleotide[i].TrinucDiff1st2nd.ToString("0.0000") + "\t");
                        }
                        Console.WriteLine();

                        for (var i = 0; i < 64; i++)
                        {
                                Console.Write(trinucleotide[i].TrinucDiff2nd3rd.ToString("0.0000") + "\t");
                        }
                        Console.WriteLine();

                        for (var i = 0; i < 64; i++)
                        {
                                Console.Write(trinucleotide[i].TrinucDiff1st3rd.ToString("0.0000") + "\t");
                        }
                        Console.WriteLine("\n");

                        double trinucDiffSum = 0;
                        for (var i = 0; i< 64; i++)
                        {
                                Console.Write((trinucleotide[i].TrinucDiff1st2nd + trinucleotide[i].TrinucDiff2nd3rd + trinucleotide[i].TrinucDiff1st3rd).ToString("0.0000") +"\t");
                                trinucDiffSum += trinucleotide[i].TrinucDiff1st2nd + trinucleotide[i].TrinucDiff2nd3rd + trinucleotide[i].TrinucDiff1st3rd;
                        }
                        Console.WriteLine();

                        Console.WriteLine(trinucDiffSum.ToString("0.0000"));
                        Console.WriteLine("\n");
                }
        }
}

using System;
using System.Collections.Generic;
using System.IO;
using TrinucConsole;

namespace CDSsearch
{
        class MainClass
        {
                public static void Main(string[] args)
                {
                        Console.WriteLine("CDS search using trinuc frequencies in three frames.");

                        TrinucCalculation trinucCalculation = new TrinucCalculation();

                        string FASTAfileName = @"/home/alvydas/Sequencies/Bacteria/Escherichia.coli.fasta";

                        int seqLength = 3000;
                        int stepLength = 10;
                        int fragmentLengt = 100;
                        List<double> fragTrinucFrq = new List<double>();

                        string seq = string.Empty;

                        using (StreamReader streamReader = new StreamReader(FASTAfileName))
                        {
                                seq = streamReader.ReadToEnd().ToLower().Replace("\n", string.Empty);
                        }

                        string fragSeq = seq.Substring(0, seqLength);

                        for (int i = 0; i < fragSeq.Length - fragmentLengt + stepLength; i += stepLength)
                        {
                                string frag = fragSeq.Substring(i, fragmentLengt);
                                //Console.WriteLine(frag);
                                TriCalc triCalc = new TriCalc(frag);
                                var tri = triCalc.Calc();

                                double sum = 0;
                                foreach (var item in tri.trinucleotides)
                                {
                                        sum += item.TrinucDiffSum;
                                }

                                fragTrinucFrq.Add(sum);
                                Console.WriteLine(i + "\t" + sum);
                        }
                }
        }
}

using System;
using GBFile;
using Oligonucs;
using OligoCalculation;
using Library;
using System.IO;
using System.Collections.Generic;
namespace SeqTest
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            //string fileName = "/home/alvydas/Oligonucleotides/Sequencies/Bacteria/Escherichia.coli.gb";
            //string fileName = "/home/alvydas/Oligonucleotides/Sequencies/Bacteria/Escherichia.coli.test.gb";
            string fileName = "/home/alvydas/Oligonucleotides/Sequencies/Bacteria/Escherichia.coli.short.gb";
            //string fileName = "/home/alvydas/Oligonucleotides/Sequencies/Bacteria/Escherichia.coli.short1.gb";
            //string fileName = "/home/alvydas/Oligonucleotides/Sequencies/Bacteria/Escherichia.coli.short2.gb";
            //string fileName = "/home/alvydas/Oligonucleotides/Sequencies/Bacteria/Escherichia.coli.shuffle.test.gb";
            Console.WriteLine($"Calc seq cds trinucs for { Path.GetFileName(fileName) }");

            GBSequence gbSequence = new GBSequence(fileName);
            var gbSeq = gbSequence.GbSeq();

            GBSeqFeatures gBSeqFeatures = new GBSeqFeatures(fileName);
            List<GBFeat> cdsFeatures = gBSeqFeatures.FeaturesSeparation();
            List<GBFeat> completeFeatures = gBSeqFeatures.CompleteSeparation(cdsFeatures);

            List<TrinucDiff> triDiff = new List<TrinucDiff>();

            foreach(var item in completeFeatures)
            {
                string subSeq = string.Empty;
                Console.Write($"{item.SeqType}\t{item.SeqStart}\t{item.SeqEnd}\t");

                if (item.SeqEnd - item.SeqStart > 40)
                {
                    subSeq = gbSeq.Seq.Substring(item.SeqStart, item.SeqEnd - item.SeqStart + 1);
                        
                    if (item.SeqType == "CDS" || item.SeqType == "JCDS" || item.SeqType == "NCDS")
                    {
                        Console.Write($"{subSeq.Substring(0, 10)}...{subSeq.Substring(subSeq.Length - 10)}\t");
                        TrinucCalc trinucCalc = new TrinucCalc();
                        TrinucDiff trinucDiff = trinucCalc.Calculation(item.SeqType, subSeq);
                        Console.WriteLine($"{ trinucDiff.DiffSum1st2nd.ToString("0.0000") }\t" +
                        	              $"{ trinucDiff.DiffSum1st3rd.ToString("0.0000") }\t" +
                                          $"{ trinucDiff.DiffSum2nd3rd.ToString("0.0000") }\t" +
                                          $"{ trinucDiff.DiffSum.ToString("0.0000") }");

                        if (item.SeqType == "CDS" || item.SeqType == "NCDS")
                        {
                            triDiff.Add(new TrinucDiff { SeqType = item.SeqType,
                                                         DiffSum1st2nd = trinucDiff.DiffSum1st2nd,
                                                         DiffSum1st3rd = trinucDiff.DiffSum1st3rd,
                                                         DiffSum2nd3rd = trinucDiff.DiffSum2nd3rd,
                                                         DiffSum = trinucDiff.DiffSum });
                        }
                    }
                    else if(item.SeqType == "CCDS" || item.SeqType == "CJCDS")
                    {
                        GBSequenceComp gbSequenceComp = new GBSequenceComp(subSeq);
                        subSeq = gbSequenceComp.SeqComp();
                        Console.Write($"{subSeq.Substring(0, 10)}...{subSeq.Substring(subSeq.Length - 10)}\t");
                        TrinucCalc trinucCalc = new TrinucCalc();
                        TrinucDiff trinucDiff = trinucCalc.Calculation(item.SeqType, subSeq);
                        Console.WriteLine($"{ trinucDiff.DiffSum1st2nd.ToString("0.0000") }\t" +
                                          $"{ trinucDiff.DiffSum1st3rd.ToString("0.0000") }\t" +
                                          $"{ trinucDiff.DiffSum2nd3rd.ToString("0.0000") }\t" +
                                          $"{ trinucDiff.DiffSum.ToString("0.0000") }");

                        triDiff.Add(new TrinucDiff { SeqType = item.SeqType,
                                                     DiffSum1st2nd = trinucDiff.DiffSum1st2nd,
                                                     DiffSum1st3rd = trinucDiff.DiffSum1st3rd,
                                                     DiffSum2nd3rd = trinucDiff.DiffSum2nd3rd,
                                                     DiffSum = trinucDiff.DiffSum });
                    }
                }
                else
                {
                    Console.WriteLine("nnnnnnnnnn...nnnnnnnnnn\t0.0000");
                }
            }

            Console.WriteLine();

            string filePath = string.Empty;
            StreamWriter FH;

            filePath = "/home/alvydas/Oligonucleotides/TrinucCalc/cdsframe.dat";
            FH = new StreamWriter(filePath);
            foreach (var item in triDiff)
            {
                if(item.SeqType == "CDS" || item.SeqType == "CCDS")
                {
                    Console.WriteLine($"{item.SeqType}\t{item.DiffSum1st2nd.ToString("0.0000")}\t{item.DiffSum1st3rd.ToString("0.0000")}\t{item.DiffSum2nd3rd.ToString("0.0000")}\t{item.DiffSum.ToString("0.0000")}");
                    FH.WriteLine($"{item.SeqType}\t{item.DiffSum1st2nd.ToString("0.0000")}\t{item.DiffSum1st3rd.ToString("0.0000")}\t{item.DiffSum2nd3rd.ToString("0.0000")}\t{item.DiffSum.ToString("0.0000")}");
                }
            }
            FH.Close();

            Console.WriteLine();

            filePath = "/home/alvydas/Oligonucleotides/TrinucCalc/ncdsframe.dat";
            FH = new StreamWriter(filePath);
            foreach (var item in triDiff)
            {
                if(item.SeqType == "NCDS")
                {
                    Console.WriteLine($"{item.SeqType}\t{item.DiffSum1st2nd.ToString("0.0000")}\t{item.DiffSum1st3rd.ToString("0.0000")}\t{item.DiffSum2nd3rd.ToString("0.0000")}\t{item.DiffSum.ToString("0.0000")}");
                    FH.WriteLine($"{item.SeqType}\t{item.DiffSum1st2nd.ToString("0.0000")}\t{item.DiffSum1st3rd.ToString("0.0000")}\t{item.DiffSum2nd3rd.ToString("0.0000")}\t{item.DiffSum.ToString("0.0000")}");
                }
            }
            FH.Close();

            string rpath = "/usr/bin/Rscript";
            //string arg1 = "/home/alvydas/Oligonucleotides/TrinucCalc/R/cdsframe.dat";
            //string arg2 = "/home/alvydas/Oligonucleotides/TrinucCalc/R/ncdsframe.dat";
            string scriptpath = "/home/alvydas/Oligonucleotides/TrinucCalc/framefrq.R cdsframe.dat ncdsframe.dat";
            string output = RScript.RunRScript(rpath, scriptpath);
        }
    }
}
using System;
using GBFile;
using Oligonucs;
using OligoCalculation;
using Library;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace SeqTest
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            //string fileName = "/home/alvydas/Oligonucleotides/Sequencies/Bacteria/Escherichia.coli.gb";
            string fileName = "/home/alvydas/Oligonucleotides/Sequencies/Bacteria/Escherichia.coli.test.gb";
            //string fileName = "/home/alvydas/Oligonucleotides/Sequencies/Bacteria/Escherichia.coli.short.gb";
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
                            var trinucDiff = trinucCalc.Calculation(item.SeqType, subSeq);
                            Console.WriteLine(trinucDiff.ToString("0.0000"));

                            triDiff.Add(new TrinucDiff {SeqType = item.SeqType, DiffSum = trinucDiff });
                        }
                        else if(item.SeqType == "CCDS" || item.SeqType == "CJCDS")
                        {
                            GBSequenceComp gbSequenceComp = new GBSequenceComp(subSeq);
                            subSeq = gbSequenceComp.SeqComp();
                            Console.Write($"{subSeq.Substring(0, 10)}...{subSeq.Substring(subSeq.Length - 10)}\t");
                            TrinucCalc trinucCalc = new TrinucCalc();
                            var trinucDiff = trinucCalc.Calculation(item.SeqType, subSeq);
                            Console.WriteLine(trinucDiff.ToString("0.0000"));

                            triDiff.Add(new TrinucDiff {SeqType = item.SeqType, DiffSum = trinucDiff });
                        }
                    }
                else
                {
                    Console.WriteLine("nnnnnnnnnn...nnnnnnnnnn\t0.0000");
                }
            }

            //CDS and NonCDS Mean and Std Deviation calculation
            CalculateStdDev calculateStdDev = new CalculateStdDev();
            List<double> cdsDiff = new List<double>();
            List<double> ncdsDiff = new List<double>();

            foreach (var item in triDiff)
            {
                if (item.SeqType == "NCDS")
                {
                    ncdsDiff.Add(item.DiffSum);
                }
                else
                {
                    cdsDiff.Add(item.DiffSum);
                }
            }

            double cdsStdDev = calculateStdDev.CalcStdDev(cdsDiff);
            double ncdsStdDev = calculateStdDev.CalcStdDev(ncdsDiff);

            Console.WriteLine();
            Console.WriteLine($"CDS Mean\t{ cdsDiff.Average().ToString("0.0000") }\tStdDev\t{ cdsStdDev.ToString("0.0000") }");
            Console.WriteLine($"NonCDS Mean\t{ ncdsDiff.Average().ToString("0.0000") }\tStdDev\t{ ncdsStdDev.ToString("0.0000") }");
        }
    }
}
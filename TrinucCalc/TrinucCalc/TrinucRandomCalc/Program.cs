using System;
using GBFile;
using Oligonucs;
using OligoCalculation;
using Library;
using System.IO;
using System.Collections.Generic;
using System.Runtime.InteropServices;

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
            //string fileName = "/home/alvydas/Oligonucleotides/Sequencies/Bacteria/Escherichia.coli.short3.gb";
            //string fileName = "/home/alvydas/Oligonucleotides/Sequencies/Bacteria/Escherichia.coli.shuffle.test.gb";
            Console.WriteLine($"Calc seq cds trinucs for { Path.GetFileName(fileName) }");

            GBSequence gbSequence = new GBSequence(fileName);
            GBSeq gbSeq = gbSequence.GbSeq();
            Console.WriteLine(gbSeq);

            GBSeqFeatures gBSeqFeatures = new GBSeqFeatures(fileName);
            List<GBFeat> cdsFeatures = gBSeqFeatures.FeaturesSeparation();
            List<GBFeat> completeFeatures = gBSeqFeatures.CompleteSeparation(cdsFeatures);

            TrinucCalc trinucCalc = new TrinucCalc();
            Sequence mixSeq = new Sequence() { SeqName = "CDS and random seq mix" };
            RandSeq randSeq = new RandSeq();

            double trinucDiff = 0;

            foreach (var item in completeFeatures)
            {
                string subSeq = string.Empty;
                string randomSubSeq = string.Empty;

                if (item.SeqType == "CDS" && item.SeqEnd - item.SeqStart > 30)
                {
                    Console.Write($"{item.SeqType}\t{item.SeqStart}\t{item.SeqEnd}\t");
                    subSeq = gbSeq.Seq.Substring(item.SeqStart, item.SeqEnd - item.SeqStart + 1);
                    //var trinucCalc = new TrinucCalc(item.SeqType, subSeq);
                    trinucDiff = trinucCalc.Calculation("CDS", subSeq);
                    Console.WriteLine($"{subSeq}\t{trinucDiff.ToString("0.0000")}");
                    mixSeq.Seq += subSeq;

                    int randSeqNumber = 20;
                    double averageRCDS1 = 0;

                    for (int i = 0; i < randSeqNumber; i++)
                    {
                        randomSubSeq = randSeq.RandomSeq(subSeq, 1);
                        Console.Write($"RCDS1\t{item.SeqStart}\t{item.SeqEnd}\t");
                        trinucDiff = trinucCalc.Calculation("RCDS1", randomSubSeq);
                        Console.WriteLine($"{randomSubSeq}\t{trinucDiff.ToString("0.0000")}");
                        averageRCDS1 += trinucDiff;
                    }
                    Console.WriteLine($"Average RCDS1 {(averageRCDS1/randSeqNumber).ToString("0.0000")}\n");
                    mixSeq.Seq += randomSubSeq;

                    double averageRCDS2 = 0;
                    for (int i = 0; i < randSeqNumber; i++)
                    {
                        randomSubSeq = randSeq.RandomSeq(subSeq, 2);
                        Console.Write($"RCDS2\t{item.SeqStart}\t{item.SeqEnd}\t");
                        trinucDiff = trinucCalc.Calculation("RCDS2", randomSubSeq);
                        Console.WriteLine($"{randomSubSeq}\t{trinucDiff.ToString("0.0000")}");
                        averageRCDS2 += trinucDiff;
                    }
                    Console.WriteLine($"Average RCDS2 {(averageRCDS2/ randSeqNumber).ToString("0.0000")}\n");
                    mixSeq.Seq += randomSubSeq;

                    double averageRCDS3 = 0;
                    for (int i = 0; i < randSeqNumber; i++)
                    {
                        randomSubSeq = randSeq.RandomSeq(subSeq, 3);
                        Console.Write($"RCDS3\t{item.SeqStart}\t{item.SeqEnd}\t");
                        trinucDiff = trinucCalc.Calculation("RCDS3", randomSubSeq);
                        Console.WriteLine($"{randomSubSeq}\t{trinucDiff.ToString("0.0000")}");
                        averageRCDS3 += trinucDiff;
                    }
                    Console.WriteLine($"Average RCDS3 {(averageRCDS3 / randSeqNumber).ToString("0.0000")}\n");
                    mixSeq.Seq += randomSubSeq;

                    Console.WriteLine("\n");
                    //Console.WriteLine(subSeq);
                    //Console.WriteLine(randomSubSeq);
                    //Console.WriteLine(  );
                }
            }

            //CDS search in artificial sequence mooving fragment by particular step. 
            //for (int i = 0; i < mixSeq.Seq.Length; i++)
            //{
            //    if (i > 0 && i % 60 == 0) Console.Write("\n");
            //    Console.Write(mixSeq.Seq[i]);
            //}
            Console.WriteLine("\n");

            string seq = mixSeq.Seq;
            int fragment = 65;
            //int step = 66;
            int step = 5;

            try
            {
                for (int i = 0; i < seq.Length; i += step)
                {
                    string fragSeq = seq.Substring(i, fragment);
                    //Console.WriteLine( fragSeq);
                    trinucDiff = trinucCalc.Calculation("FRAG", fragSeq);
                    Console.WriteLine($"FRAG\t{fragSeq}\t{trinucDiff.ToString("0.0000")}");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
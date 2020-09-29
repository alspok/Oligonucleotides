using System;
using GBFile;
using OligoCalculation;

namespace TrinucSeqScan
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string fileName = "/home/alvydas/Oligonucleotides/Sequencies/Bacteria/Escherichia.coli.test.gb";

            GBSequence gbSequence = new GBSequence(fileName);
            GBSeq gbSeq = gbSequence.GbSeq();
            TrinucCalc trinucCalc = new TrinucCalc();

            int scanStart = 20000;
            int scanEnd = 40000;
            string scanSeq = gbSeq.Seq.Substring(scanStart, scanEnd - scanStart);
            int fragment = 65;
            //int step = 66;
            int step = 5;

            try
            {
                for (int i = 0; i < scanSeq.Length; i += step)
                {
                    string fragSeq = scanSeq.Substring(i, fragment);
                    //Console.WriteLine( fragSeq);
                    double trinucDiff = trinucCalc.Calculation("FRAG", fragSeq);
                    Console.WriteLine($"FRAG\t{fragSeq}\t{trinucDiff.ToString("0.0000")}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }



        }
    }
}

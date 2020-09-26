using System;
using GBFile;

namespace TrinucSeqScan
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string fileName = "/home/alvydas/Oligonucleotides/Sequencies/Bacteria/Escherichia.coli.test.gb";

            GBSequence gbSequence = new GBSequence(fileName);
            GBSeq gbSeq = gbSequence.GbSeq();





        }
    }
}

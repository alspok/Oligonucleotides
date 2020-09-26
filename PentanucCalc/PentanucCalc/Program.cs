using System;
using GBFile;
using Oligonucs;
using OligoCalculation;
using System.Collections.Generic;
using System.Linq;

namespace Pentanuc
{
    class MainClass
    {
        public static void Main(string [] args)
        {
            Console.WriteLine("Pentanuc calculation");

            string fileName = "/home/alvydas/SequenciesTest/Bacteria/Escherichia.coli.test.gb";
            GBSequence gbSequence = new GBSequence(fileName);
            var gbSeq = gbSequence.GbSeq();

            Console.WriteLine("Seq length " + gbSeq.Seq.Length + " Pentanucs " + gbSeq.Seq.Length/ 5);
            Console.WriteLine(gbSeq.Seq);
            //Console.WriteLine($"{gbSeq.Seq.Substring(0, 60)}...{gbSeq.Seq.Substring(gbSeq.Seq.Length - 60)}");

            PentanucCalc pentanucCalculation = new PentanucCalc(gbSeq.Seq);
            var pentanuc = pentanucCalculation.Calculation();

            foreach(var item in pentanuc.pentanucleotides)
            {
                Console.Write($"{item.Pentanuc}\t");
                Console.Write($"{ item.Pentanuc1st}\t{item.Pentanuc2nd}\t{item.Pentanuc3rd}\t{item.Pentanuc4th}\t{item.Pentanuc5th}\t");
                Console.Write($"{item.PentaFrq1st.ToString("0.0000")}\t{item.PentaFrq2nd.ToString("0.0000")}\t{item.PentaFrq3rd.ToString("0.0000")}\t{item.PentaFrq4th.ToString("0.0000")}\t{item.PentaFrq5th.ToString("0.0000")}\t");
                Console.WriteLine($"{(item.PentaFrq1st+ item.PentaFrq2nd+ item.PentaFrq3rd+ item.PentaFrq4th+item.PentaFrq5th).ToString("0.0000")}");

            }
        }
    }
}
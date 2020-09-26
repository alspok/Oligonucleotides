using System;
using GBFile;
using Oligonucs;
using OligoCalculation;
using Library;
using System.IO;

namespace SeqTest
{
	public class MainClass
	{
		public static void Main (string [] args)
		{
			//string fileName = "/home/alvydas/Oligonucleotides/Sequencies/Bacteria/Escherichia.coli.gb";
			string fileName = "/home/alvydas/Oligonucleotides/Sequencies/Bacteria/Escherichia.coli.test.gb";
			//string fileName = "/home/alvydas/Oligonucleotides/Sequencies/Bacteria/Escherichia.coli.short.gb";
			//string fileName = "/home/alvydas/Oligonucleotides/Sequencies/Bacteria/Escherichia.coli.short1.gb";
			//string fileName = "/home/alvydas/Oligonucleotides/Sequencies/Bacteria/Escherichia.coli.short2.gb";
			//string fileName = "/home/alvydas/Oligonucleotides/Sequencies/Bacteria/Escherichia.coli.shuffle.test.gb";
			Console.WriteLine ($"Calc seq cds trinucs for { Path.GetFileName (fileName) }");

			GBSequence gbSequence = new GBSequence (fileName);
			var gbSeq = gbSequence.GbSeq ();



			GBFeatures gbFeatures = new GBFeatures (fileName);
			var gbCds = gbFeatures.Cds ();

			GBSeparation gBSeparation = new GBSeparation (gbSeq, gbCds);
			gBSeparation.GBSeq ();

			TrinucDiff trinucDiff = new TrinucDiff ();

			Console.WriteLine ($"Seq length {gbSeq.Seq.Length}\n{ gbSeq.Seq.Substring (0, 30)}....{ gbSeq.Seq.Substring (gbSeq.Seq.Length - 30)}\n");

			int randFragLength = 1;

			foreach (var item in gbCds)
			{
				if(item.CdsEnd - item.CdsStart >= 60)
				{
					TrinucCalc trinucCalc = new TrinucCalc ("CDS", item.CdsSeq);
					trinucDiff = trinucCalc.Calculation ();
					Console.Write ($"CDS\t{item.CdsStart}\t{item.CdsEnd}\t{item.CdsSeq.Substring (0, 9)}...{item.CdsSeq.Substring (item.CdsSeq.Length - 9)}\t");
					Console.Write ($"{trinucDiff.DiffSum1st2nd.ToString("0.0000")}\t{trinucDiff.DiffSum1st3rd.ToString ("0.0000")}\t{trinucDiff.DiffSum2nd3rd.ToString ("0.0000")}\t");
					Console.WriteLine ($"{trinucDiff.DiffSum.ToString("0.0000")}");

					for (int i = 0; i < 10; i++)
					{
						RandomSeq randomSeq = new RandomSeq (item.CdsSeq);
						string randSeq = randomSeq.RandomSeqByFragment (randFragLength);

						TrinucCalc randtrinucCalc = new TrinucCalc ("RCDS", randSeq);
						trinucDiff = randtrinucCalc.Calculation ();
						Console.Write ($"RCDS\t{item.CompCdsStart}\t{item.CompCdsEnd}\t{randSeq.Substring (0, 9)}...{randSeq.Substring (randSeq.Length - 9)}\t");
						Console.Write ($"{trinucDiff.DiffSum1st2nd.ToString ("0.0000")}\t{trinucDiff.DiffSum1st3rd.ToString ("0.0000")}\t{trinucDiff.DiffSum2nd3rd.ToString ("0.0000")}\t");
						Console.WriteLine ($"{trinucDiff.DiffSum.ToString ("0.0000")}");
					}
				}

				if(item.CompCdsEnd - item.CompCdsStart >= 60)
				{
					TrinucCalc trinucCalc = new TrinucCalc ("CCDS", item.CompCdsSeq);
					trinucDiff = trinucCalc.Calculation ();
					Console.Write ($"CCDS\t{item.CompCdsStart}\t{item.CompCdsEnd}\t{item.CompCdsSeq.Substring (0, 9)}...{item.CompCdsSeq.Substring (item.CompCdsSeq.Length - 9)}\t");
					Console.Write ($"{trinucDiff.DiffSum1st2nd.ToString ("0.0000")}\t{trinucDiff.DiffSum1st3rd.ToString ("0.0000")}\t{trinucDiff.DiffSum2nd3rd.ToString ("0.0000")}\t");
					Console.WriteLine ($"{trinucDiff.DiffSum.ToString ("0.0000")}");

					for (int i = 0; i < 10; i++)
					{
						RandomSeq randomSeq = new RandomSeq (item.CompCdsSeq);
						string randSeq = randomSeq.RandomSeqByFragment (randFragLength);

						TrinucCalc randtrinucCalc = new TrinucCalc ("RCCDS", randSeq);
						trinucDiff = randtrinucCalc.Calculation ();
						Console.Write ($"RCCDS\t{item.CdsStart}\t{item.CdsEnd}\t{randSeq.Substring (0, 9)}...{randSeq.Substring (randSeq.Length - 9)}\t");
						Console.Write ($"{trinucDiff.DiffSum1st2nd.ToString ("0.0000")}\t{trinucDiff.DiffSum1st3rd.ToString ("0.0000")}\t{trinucDiff.DiffSum2nd3rd.ToString ("0.0000")}\t");
						Console.WriteLine ($"{trinucDiff.DiffSum.ToString ("0.0000")}");
					}
				}
				
				//PrintOut printOut = new PrintOut (gbSeq, gbCds, 30, trinucDiff);
				//printOut.SeqPrint ();
				//printOut.CdsPrint ();
				//printOut.CompCdsPrint ();
			}
		}
	}
}

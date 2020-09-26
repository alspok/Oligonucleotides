using System;

namespace GBFile
{
	class MainClass
	{
	        public static void Main(string[] args)
	        {
	            	Console.WriteLine("GB seq cds start end.");

	            	string fileName = "/home/alvydas/Sequencies/Bacteria/Escherichia.coli.test.gb";

	            	GBFeatures gBFeatures = new GBFeatures(fileName);
	            	var cdsList = gBFeatures.Cds();

			int i = 1;
			foreach(var item in cdsList)
			{
				Console.WriteLine(i++ + "\t" + item.CdsStart + "\t" + item.CdsEnd);
			}

			GBSequence gBSequence = new GBSequence (fileName);
			var gb = gBSequence.GbSeq ();

			Console.WriteLine (gb.Seq);
		}
	}
}

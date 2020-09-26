using System;

namespace FASTAFile
{
	class MainClass
	{
		public static void Main (string [] args)
		{
			Console.WriteLine ("Read FASTA seq");

			string fileName = "/home/alvydas/Sequencies/Bacteria/Escherichia.coli.test.fasta";

			FASTASequence fastaSequence = new FASTASequence (fileName);

			var fastaSeq = fastaSequence.FastaSequence ();

			Console.WriteLine (fastaSeq.SeqFeatures);
			Console.WriteLine (fastaSeq.Seq.Substring (0, 60) + "....." + fastaSeq.Seq.Substring(fastaSeq.Seq.Length - 60));
		}
	}
}

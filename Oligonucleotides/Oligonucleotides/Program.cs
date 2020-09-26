using System;
using System.IO;
using OligoCalculation;

public sealed class MyEventArgs : System.EventArgs
{
	public MyEventArgs ()
	{
		
	}
}
namespace Oligonucleotides
{
    class Program
	    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Oligonucleotides frq calculation.");

            string seq = string.Empty;
            //string fileName = @"/home/alvydas/Sequencies/Homo.sapience/Cromosome1.fasta";
            //string fileName = @"/home/alvydas/Sequencies/Virus/Hepatitis.delta.fasta";
            //string fileName = "//home//alvydas//Sequencies//Bacteria//Lactococcus.lactis.fasta";
            //seq = "aaacagatcacccgctgagcgggttatctgtt";


            seq = "aaaaacaagaatacaaccacgactagaagcaggagtataatcatgattcaacaccagcatccacccccgcctcgacgccggcgtctactcctgcttgaagacgaggatgcagccgcggctggaggcgggggtgtagtcgtggtttaatactagtattcatcctcgtcttgatgctggtgtttattcttgttt";
            /*
            string fileName = @"/home/alvydas/Sequencies/Bacteria/Escherichia.coli.fasta";

            var fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream))
            {
                seq = streamReader.ReadToEnd().ToLower().Replace("\n", string.Empty);
            }
            Console.WriteLine(fileName);
            /*
            string [ ] mono = { "a" , "c" , "g" , "t" };
            foreach(var item1 in mono )
            {
                foreach ( var item2 in mono )
                {
                    foreach ( var item3 in mono )
                    {
                        foreach ( var item4 in mono )
                        {
                            seq += item1 + item2 + item3 + item4;
                        }
                    }
                }
            }
            */
            DinucCalc dinucCalc = new DinucCalc(seq);
            var diCalc = dinucCalc.Calculation ();

            TrinucCalc trinucCalc = new TrinucCalc ( seq );
            var triCalc = trinucCalc.Calculation ( );

            TetranucCalc tetranucCalc = new TetranucCalc ( seq );
            var tetraCalc = tetranucCalc.Calculation ( );
        }
    }
}

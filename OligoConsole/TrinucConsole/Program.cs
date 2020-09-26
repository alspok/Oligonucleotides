using System;
using System.IO;
using SeqShuffle;

namespace TrinucConsole
{
        class MainClass
        {
                public static void Main(string[] args)
                {
                        string seq;
                        string fileName = @"/home/alvydas/Sequencies/Homo.sapience/Cromosome1.fasta";
                        //string fileName = @"/home/alvydas/Sequencies/Virus/Hepatitis.delta.fasta";
                        //string fileName = "//home//alvydas//Sequencies//Bacteria//Esherichia.coli.fasta";
                        //string fileName = "//home//alvydas//Sequencies//Bacteria//Lactococcus.lactis.fasta";
                        var fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                        using (var streamReader = new StreamReader(fileStream))
                        {
                                seq = streamReader.ReadToEnd().ToLower().Replace("\n", string.Empty);
                        }
                        Console.WriteLine(fileName);
                        //string fileName = "//home//alvydas//Downloads//Esherichia.coli.fasta";
                        //Console.WriteLine(fileName);
                        //StreamReader file = File.OpenText(fileName);
                        // Read the file into a string
                        //string seq = file.ReadToEnd().ToLower().Replace("\n", String.Empty);
                        //string seq = "acgtat";
                        //string seq = "aaacagatcacccgctgagcgggttatctgtta";
                        //string seq = "aaaagggg";
                        //string seq = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaggggggggggggggtttttttttttttttcggggggtatagaacagatagatagacaccccccacgg";
                        //string seq = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
                        //string seq = "aaaaacaagaataaaaacaagaataaaaacaagaat";
                        //string seq = "aaaaacaagaatacaaccacgactagaagcaggagtataatcatgatt" +
                        //"caacaccagcatccacccccgcctcgacgccggcgtctactcctgctt" +
                        //"gaagacgaggatgcagccgcggctggaggcgggggtgtagtcgtggtt" +
                        //"taatactagtattcatcctcgtcttgatgctggtgtttattcttgttt" +

                        //"aaaaacaagaatacaaccacgactagaagcaggagtataatcatgatt" +
                        //"caacaccagcatccacccccgcctcgacgccggcgtctactcctgctt" +
                        //"gaagacgaggatgcagccgcggctggaggcgggggtgtagtcgtggtt" +
                        //"taatactagtattcatcctcgtcttgatgctggtgtttattcttgttt";

                        //string[] mono = { "a", "c", "g", "t" };
                        //string seq = string.Empty;
                        //foreach (var item1 in mono)
                        //{
                        //        foreach (var item2 in mono)
                        //        {
                        //                foreach (var item3 in mono){
                        //                        seq += item1 + item2 + item3;
                        //                }
                        //        }
                        //}

                        TrinucleotideCalc trinucleotideCalc = new TrinucleotideCalc(seq);
                        trinucleotideCalc.TrinucCalc();

                        for (int i = 0; i < 6; i++)
                        {
                                SequnceShuffle sequnceShuffle = new SequnceShuffle(seq, 3);
                                var seqShuffle = sequnceShuffle.SeqShuffle();
                                trinucleotideCalc = new TrinucleotideCalc(seqShuffle);
                                trinucleotideCalc.TrinucCalc();
                        }

                }
        }
}

using System;

namespace SeqShuffle
{
        class MainClass
        {
                public static void Main(string[] args)
                {
                        Console.WriteLine("Seq Shuffle");

                        string seq = "acgaccgatgcggatgcgacgatgcgatgaaa";
                        Console.WriteLine(seq);

                        int seqPattern = 3;
                        SequnceShuffle seqShuffle = new SequnceShuffle(seq, seqPattern);
                        seq = seqShuffle.SeqShuffle();
                        Console.WriteLine(seq);
                }
        }
}

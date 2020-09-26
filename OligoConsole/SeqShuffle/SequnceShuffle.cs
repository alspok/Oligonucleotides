using System;
using System.Collections.Generic;
using Medallion;

namespace SeqShuffle
{
        public class SequnceShuffle
        {
                private string seq;
                private readonly int seqPattern;
                private int seqLength;

                public SequnceShuffle(string seq, int seqPattern)
                {
                        this.seq = seq;
                        this.seqPattern = seqPattern;
                        seqLength = seq.Length;
                }

                public string SeqShuffle()
                {
                        string seqShuffle = string.Empty;
                        List<string> seqPatternList = new List<string>();

                        int i = 0;
                        while (seqLength - seqPattern >= 0)
                        {
                                seqPatternList.Add(seq.Substring(i, seqPattern));
                                seqLength = seqLength - seqPattern;
                                i += 3;
                        }

                        Random random = new Random();
                        seqPatternList.Shuffle(random);

                        seqShuffle = string.Join("", seqPatternList.ToArray());

                        return seqShuffle;
                }
        }
}

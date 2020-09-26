using System;
using System.Collections.Generic;
using System.Linq;

namespace Library
{
    //Random seq without  constructor.
    public class RandSeq
    {
        public string RandomSeq(string seq, int chunkSize)
        {
            List<string> splitSeq = new List<string>();

            for (int i = 0; i < seq.Length; i += chunkSize)
            {
                if ((i + chunkSize) < seq.Length)
                    splitSeq.Add(seq.Substring(i, chunkSize));
                else
                    splitSeq.Add(seq.Substring(i));
            }

            List<string> shuffledSeq = splitSeq.OrderBy(x => Guid.NewGuid()).ToList();

            return string.Join("", shuffledSeq);
        }
    }
}

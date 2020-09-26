using System;
using DinucMVC.Models;

namespace DinucMVC.Helpers
{
    public class SeqOutput
    {
        private string _seq;
        private readonly int _seqLength;

        public SeqOutput(Sequence sequence)
        {
            _seq = sequence.Seq;
            _seqLength = sequence.SeqLength;
        }

        public string SeqOut()
        {
            string outSeq = String.Empty;

            if (_seqLength >= 60)
            {
                string sqStart = _seq.Substring(0, 16);
                string sqEnd = _seq.Substring(_seqLength - 16);
                outSeq = sqStart + " ..... " + sqEnd;
            }
            else
            {
                outSeq = _seq;
            }

            return outSeq;
        }
    }
}

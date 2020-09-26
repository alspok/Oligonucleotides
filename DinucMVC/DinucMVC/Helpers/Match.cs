using System;
using System.Text.RegularExpressions;

namespace DinucMVC.Helpers
{
    public class Match
    {
        public Match()
        {
        }

        public bool MatchNuc(string seq)
        {
            bool regResult = Regex.IsMatch(seq, @"^[acgtACGT]+$");

            return regResult ? true : false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Library
{
 	public class RandomSeq
	{
		readonly string seq;
		//readonly int chunkSize;
		//readonly string  randomSeq;
	
        public RandomSeq(string seq)
        {
		this.seq = seq;
		//this.chunkSize = chunkSize;
        }

		public List<string> Split (int chunkSize)
		{
			List<string> splitString = new List<string> ();

			for (int i = 0; i < seq.Length; i += chunkSize)
			{
				if ((i + chunkSize) < seq.Length)
					splitString.Add (seq.Substring (i, chunkSize));
				else
					splitString.Add (seq.Substring (i));
			}
			return splitString;

		}

    //Input split fragment size.
    //Use Split method to split seq string to list of fragment size substrings.
    //Return shuffled seq.
	public string RandomSeqByFragment (int  chunkSize)
	{
		List<string> splitSeq = Split (chunkSize);
		List<string> shuffledSeq = splitSeq.OrderBy (x => Guid.NewGuid ()).ToList ();
		
		return string.Join("", shuffledSeq);
	}
	
    }
}

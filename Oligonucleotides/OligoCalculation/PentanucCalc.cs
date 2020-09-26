using System;
using System.Collections.Generic;
using Oligonucs;

namespace OligoCalculation
{
	public class PentanucCalc
	{
		private readonly string seqCalc;
		public int pentanucCount;
		public PentanucCalculation pentanucCalculation;
		public PentanucArray pentanucArray;
		public List<PentanucleotideMatch> pentanucMatch = new List<PentanucleotideMatch> ();

		public PentanucCalc (string seq)
		{
			seqCalc = "nnnnn" + seq + seq.Substring (0, 9);
			pentanucCount = 0;
			pentanucCalculation = new PentanucCalculation ();
			pentanucArray = new PentanucArray ();
		}

		public PentanucCalculation Calculation ()
		{
			string oligoFrag = string.Empty;

			for(var i = 0; i < seqCalc.Length - 9; i++)
			{
				oligoFrag = seqCalc.Substring (i, 5);

				if (Array.IndexOf(pentanucArray.pentanuc, oligoFrag) < 0)
				{
					pentanucMatch.Add (new PentanucleotideMatch { PentanucPosition = i, PentanucMatch = oligoFrag });
					continue;
				}
				if (i % 5 == 0)
				{
		                    var index = Array.FindIndex(pentanucCalculation.pentanucleotides, row => row.Pentanuc == oligoFrag);
		                    pentanucCalculation.pentanucleotides[index].Pentanuc1st += 1;
		                    pentanucCount += 1; 
		                }
		                else if ((i - 1) % 5 == 0)
		                {
		                    var index = Array.FindIndex(pentanucCalculation.pentanucleotides, row => row.Pentanuc == oligoFrag);
		                    pentanucCalculation.pentanucleotides[index].Pentanuc2nd += 1;
		                }
		                else if((i - 2) % 5 == 0)
		                {
		                    var index = Array.FindIndex(pentanucCalculation.pentanucleotides, row => row.Pentanuc == oligoFrag);
		                    pentanucCalculation.pentanucleotides[index].Pentanuc3rd += 1;
		                }
		                else if((i - 3) % 5 == 0)
		                {
		                    var index = Array.FindIndex(pentanucCalculation.pentanucleotides, row => row.Pentanuc == oligoFrag);
		                    pentanucCalculation.pentanucleotides[index].Pentanuc4th += 1;
		                }
		                else if((i - 4) % 5 == 0)
		                {
		                    var index = Array.FindIndex(pentanucCalculation.pentanucleotides, row => row.Pentanuc == oligoFrag);
		                    pentanucCalculation.pentanucleotides[index].Pentanuc5th += 1;
		                }
			}

	            	foreach (var item in pentanucCalculation.pentanucleotides)
	            	{
		                item.PentaFrq1st = (double)item.Pentanuc1st / pentanucCount;
		                item.PentaFrq2nd = (double)item.Pentanuc2nd / pentanucCount;
		                item.PentaFrq3rd = (double)item.Pentanuc3rd / pentanucCount;
		                item.PentaFrq4th = (double)item.Pentanuc4th / pentanucCount;
		                item.PentaFrq5th = (double)item.Pentanuc5th / pentanucCount;

		                item.PentaFrqDiff1st2nd += Math.Abs(item.PentaFrq1st - item.PentaFrq2nd);
		                item.PentaFrqDiff1st3rd += Math.Abs(item.PentaFrq1st - item.PentaFrq3rd);
		                item.PentaFrqDiff1st4th += Math.Abs(item.PentaFrq1st - item.PentaFrq4th);
		                item.PentaFrqDiff1st5th += Math.Abs(item.PentaFrq1st - item.PentaFrq5th);
		                item.PentaFrqDiff2nd3rd += Math.Abs(item.PentaFrq2nd - item.PentaFrq3rd);
		                item.PentaFrqDiff2nd4th += Math.Abs(item.PentaFrq2nd - item.PentaFrq4th);
		                item.PentaFrqDiff2nd5th += Math.Abs(item.PentaFrq2nd - item.PentaFrq5th);
		                item.PentaFrqDiff3rd4th += Math.Abs(item.PentaFrq3rd - item.PentaFrq4th);
		                item.PentaFrqDiff3rd5th += Math.Abs(item.PentaFrq3rd - item.PentaFrq5th);
		                item.PentaFrqDiff4th5th += Math.Abs(item.PentaFrq4th - item.PentaFrq5th);
	            	}

            		return pentanucCalculation;
		}
	}
}

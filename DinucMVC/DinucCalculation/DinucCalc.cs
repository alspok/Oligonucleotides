using System;
using System.Collections.Generic;

namespace DinucCalculation
{
	public class DinucCalc
	{
		private string seq;
		List<Dinucleotide> dinucleotide = new List<Dinucleotide>();

		public DinucCalc(string seq)
		{
			this.seq = seq;
		}

		public List<Dinucleotide> GetDinucleotides()
		{
			while(seq.Length >= 2)
			{
				var dinuc = seq.Substring(0, 2);
				var temp = dinucleotide.FindIndex(x => x.Dinuc.Equals(dinuc));
				if(temp == -1)
				{
					dinucleotide.Add(new Dinucleotide { Dinuc = dinuc, Dinuc1st = 0, Dinuc2nd = 0, Dinuc1stFrq = 0, Dinuc2ndFrq = 0 });
				}
			}

			return dinucleotide;
		}
	}
}

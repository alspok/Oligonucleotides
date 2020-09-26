using System;
namespace DinucCalculationCons
{
	public class DinucleotideCalc
	{
		private readonly string[] dinuc = {     "aa", "ac", "ag", "at",
										"aa", "ac", "ag", "at",
										"aa", "ac", "ag", "at",
										"aa", "ac", "ag", "at"	};
		private readonly string seq;

		public DinucleotideCalc(string seq)
		{
			this.seq = seq;

			Dinucleotide[] dinucleotide = new Dinucleotide[16];
			//Dinucleotide dinucleotide = new Dinucleotide();
			//dinucleotide[0] = new Dinucleotide { Dinuc = "", Dinuc1st = 0,Dinuc2nd = 0, };
			for (int i = 0; i < 16; i++)
			{
				dinucleotide[i] = new Dinucleotide();
				dinucleotide[i].Dinuc = dinuc[i];
				dinucleotide[i].Dinuc1st = 0;
				dinucleotide[i].Dinuc2nd = 0;
			}
		}

		public void DinucCalc()
		{
		}
	}
}

using System;

namespace DinucConsole
{
	public class DinucleotideCalc
	{
		DinucArray dinucArray = new DinucArray();
		//private readonly string[] dinuc = {  "aa",  "ac",  "ag",  "at",  "ca",  "cc",  "cg",  "ct",  "ga",  "gc",  "gg",  "gt",  "ta",  "tc",  "tg",  "tt"  };

		private readonly string seq;
		private Dinucleotide[] dinucleotide;

		public DinucleotideCalc(string seq)
		{
			this.seq = seq;
			dinucleotide = new Dinucleotide[16];

			for (int i = 0; i < 16; i++)
			{
				dinucleotide[i] = new Dinucleotide { Dinuc = dinucArray.dinuc[i], Dinuc1st = 0, Dinuc2nd = 0, DinucFrq1st = 0, DinucFrq2nd = 0, DinucFrqDiff = 0 };
			}
		}

		public void DinucCalc()
		{
			string seqDinuc = string.Empty;
			int dinucIndex = 0;
			int evenDinuc = 0;
			int oddDinuc = 0;

			string seqCalc = seq + seq.Substring(0, 6);

			//Calc dinuc when seq length is even number (porinis).
			if(seq.Length % 2 == 0)
			{
				for(int i = 0; i < seq.Length - 1; i += 2)
				{
					seqDinuc = seqCalc.Substring(i, 2);
					dinucIndex = Array.FindIndex(dinucArray.dinuc, item => item == seqDinuc);
					dinucleotide[dinucIndex].Dinuc1st += 1;
					evenDinuc += 1;
				}

				for(int i = 1; i < seq.Length + 1; i += 2)
				{
					seqDinuc = seqCalc.Substring(i, 2);
					dinucIndex = Array.FindIndex(dinucArray.dinuc, item => item == seqDinuc);
					dinucleotide[dinucIndex].Dinuc2nd += 1;
					oddDinuc += 1;
				}
			}

	    		//Calc dinuc when seq length is odd number (neporinis).
			if(seq.Length % 2 != 0)
			{
				for(int i = 0; i < seq.Length - 1; i += 2)
				{
					seqDinuc = seqCalc.Substring(i, 2);
					dinucIndex = Array.FindIndex(dinucArray.dinuc, item => item == seqDinuc);
					dinucleotide[dinucIndex].Dinuc1st += 1;
					evenDinuc += 1;
				}

				for(int i = 1; i < seq.Length; i += 2)
				{
					seqDinuc = seqCalc.Substring(i, 2);
					dinucIndex = Array.FindIndex(dinucArray.dinuc, item => item == seqDinuc);
					dinucleotide[dinucIndex].Dinuc2nd += 1;
					oddDinuc += 1;
				}
			}

			foreach(var item in dinucleotide)
			{
				item.DinucFrq1st = (double)item.Dinuc1st / (double)evenDinuc;
				item.DinucFrq2nd = (double)item.Dinuc2nd / (double)oddDinuc;
			}

			foreach (var item in dinucleotide)
			{
				item.DinucFrqDiff = Math.Abs(item.DinucFrq1st - item.DinucFrq2nd);
			}

			DinucOutput dinucOutput = new DinucOutput(seq, dinucleotide);
			dinucOutput.DinucOut();
		}
	}
}

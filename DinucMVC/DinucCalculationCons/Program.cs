using System;

namespace DinucCalculationCons
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			string seq = "aaacagatcacccgctgagcgggttatctgtt";

			DinucleotideCalc dinucleotideCalc = new DinucleotideCalc(seq);
			dinucleotideCalc.DinucCalc();
		}
	}
}

using System;
namespace DinucConsole
{
	public class Dinucleotide
	{
		public string Dinuc { get; set; }
		public int Dinuc1st { get; set; }
		public int Dinuc2nd { get; set; }
		public double DinucFrq1st { get; set; }
		public double DinucFrq2nd { get; set; }
		public double DinucFrqDiff { get; set; }
	}

	public class DinucArray
	{
		public string[] dinuc = new string[16];
		public string[] monoNuc = { "a", "c", "g", "t" };

		public DinucArray()
		{
			int i = 0;
			foreach (var item1 in monoNuc)
			{
				foreach (var item2 in monoNuc)
				{
					dinuc[i++] = item1 + item2;
				}
			}
		}
	}
}

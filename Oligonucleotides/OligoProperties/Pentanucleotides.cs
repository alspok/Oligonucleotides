using System;
namespace Oligonucs
{
	//Pentanuc count, frq, count and frq differencies in 5 frames properties.
	public class Pentanucleotides
	{
		public string Pentanuc { get; set; }
		public int Pentanuc1st { get; set; } = 0;
		public int Pentanuc2nd { get; set; } = 0;
		public int Pentanuc3rd { get; set; } = 0;
		public int Pentanuc4th { get; set; } = 0;
		public int Pentanuc5th { get; set; } = 0;
		public double PentaFrq1st { get; set; } = 0;
		public double PentaFrq2nd { get; set; } = 0;
		public double PentaFrq3rd { get; set; } = 0;
		public double PentaFrq4th { get; set; } = 0;
		public double PentaFrq5th { get; set; } = 0;
		public double PentaFrqDiff1st2nd { get; set; } = 0;
		public double PentaFrqDiff1st3rd { get; set; } = 0;
		public double PentaFrqDiff1st4th { get; set; } = 0;
		public double PentaFrqDiff1st5th { get; set; } = 0;
		public double PentaFrqDiff2nd3rd { get; set; } = 0;
		public double PentaFrqDiff2nd4th { get; set; } = 0;
		public double PentaFrqDiff2nd5th { get; set; } = 0;
		public double PentaFrqDiff3rd4th { get; set; } = 0;
		public double PentaFrqDiff3rd5th { get; set; } = 0;
		public double PentaFrqDiff4th5th { get; set; } = 0;
	}

	public class PentanucDiffSum
	{
		public string SeqType { get; set; }
		public double DiffSum1st2nd { get; set; }
		public double DiffSum2nd3rd { get; set; }
		public double DiffSum3rd4th { get; set; }
		public double DiffSum4th5th { get; set; }

	}

	//Pentanuc must match a, c, g, t only otherwise pattern collects here.
	public class PentanucleotideMatch
	{
		public int PentanucPosition { get; set; }
		public string PentanucMatch { get; set; }
	}

	//Pentanuc array assembly.
	public class PentanucArray
	{
		public string[] pentanuc = new string[1024];
		public string[] monoNuc = { "a", "c", "g", "t" };

		public PentanucArray()
		{
			int i = 0;
    			foreach (var item1 in monoNuc)
			{
				foreach (var item2 in monoNuc)
				{
					foreach (var item3 in monoNuc)
					{
						foreach (var item4 in monoNuc)
						{
							foreach (var item5 in monoNuc)
							{
								pentanuc[i++] = item1 + item2 + item3 + item4 + item5;
							}
						}
					}
				}
			}
		}
	}

	//Pentanuc array to properties array.
	public class PentanucCalculation
	{
		public Pentanucleotides[] pentanucleotides = new Pentanucleotides[1024];
		PentanucArray pentanucArray = new PentanucArray();
		
		public PentanucCalculation()
		{
			for (int i = 0; i < 1024; i++)
			{
		                pentanucleotides[i] = new Pentanucleotides{Pentanuc = pentanucArray.pentanuc[i]};
            		}	
		}
	}
}

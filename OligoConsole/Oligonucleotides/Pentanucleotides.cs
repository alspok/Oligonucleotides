using System;
namespace Oligonucleotides
{
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
		public double PentaDiff1st2nd { get; set; } = 0;
		public double PentaDiff1st3rd { get; set; } = 0;
		public double PentaDiff1st4th { get; set; } = 0;
		public double PentaDiff1st5th { get; set; } = 0;
		public double PentaDiff2nd3rd { get; set; } = 0;
		public double PentaDiff2nd4th { get; set; } = 0;
		public double PentaDiff2nd5th { get; set; } = 0;
		public double PentaDiff3rd4th { get; set; } = 0;
		public double PentaDiff3rd5th { get; set; } = 0;
		public double PentaDiff4th5th { get; set; } = 0;
    }

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

	public class PentaCalculation
	{
		public Pentanucleotides[] pentanucleotides = new Pentanucleotides[1024];
		PentanucArray pentanucArray = new PentanucArray();
		
		public PentaCalculation()
		{
			for (int i = 0; i < 1024; i++)
			{
		                pentanucleotides[i] = new Pentanucleotides
		                {
		                    Pentanuc = pentanucArray[i]
		                };
            		}	
		}
	}
}

using System;
namespace DinucConsole
{
	public class DinucOutput
	{
		private string seq;
		private Dinucleotide[] dinucleotide;

		public DinucOutput(string seq, Dinucleotide[] dinucleotide)
		{
			this.seq = seq;
			this.dinucleotide = dinucleotide;
		}

		public void DinucOut()
		{
			Console.WriteLine("Hello from DinucCalc\n");
			Console.WriteLine("Seq: " + seq);
			Console.WriteLine("Seq length: " + seq.Length + "\n");

			int dinucSum1st = 0;
			int dinucSum2nd = 0;

			//Dinucleoide 
	  		 foreach(var item in dinucleotide)
			{
				Console.Write(item.Dinuc + "\t");
			}
			Console.WriteLine();

			//Dinucleotide quantity in first frame
			foreach (var item in dinucleotide)
			{
				Console.Write(item.Dinuc1st + "\t");
				dinucSum1st += item.Dinuc1st;
			}
			Console.WriteLine();

			foreach(var item in dinucleotide)
			{
				Console.Write(item.DinucFrq1st.ToString("0.0000") + "\t");
			}
			Console.WriteLine();

			//Dinucleotide quantity in second frame
			foreach (var item in dinucleotide)
			{
				Console.Write(item.Dinuc2nd + "\t");
				dinucSum2nd += item.Dinuc2nd;
			}
			Console.WriteLine();

			foreach(var item in dinucleotide)
			{
				Console.Write(item.DinucFrq2nd.ToString("0.0000") + "\t");
			}
			Console.WriteLine("\n");

			//Dinucleotides frequencys difference in abs in two frames
	    		foreach(var item in dinucleotide)
			{
				Console.Write(Math.Abs(item.DinucFrq1st - item.DinucFrq2nd).ToString("0.0000") + "\t");
			}
			Console.WriteLine("\n");

			//Dinucleotides differencies sum
			double diffSum = 0;
			foreach(var item in dinucleotide)
			{
				diffSum += Math.Abs(item.DinucFrq1st - item.DinucFrq2nd);
			}
			Console.Write("Dinuc diff sum: " + diffSum.ToString("0.0000"));
		}
	}
}

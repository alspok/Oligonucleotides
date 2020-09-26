namespace Oligonucs
{  
    public class Trinucleotides
    {
    	public string Trinuc { get; set; } = string.Empty;
        public int Trinuc1st { get; set; } = 0;
        public int Trinuc2nd { get; set; } = 0;
        public int Trinuc3rd { get; set; } = 0;
        public double TrinucFrq1st { get; set; } = 0;
        public double TrinucFrq2nd { get; set; } = 0;
        public double TrinucFrq3rd { get; set; } = 0;
        public double TrinucFrqDiff1st2nd { get; set; } = 0;
        public double TrinucFrqDiff2nd3rd { get; set; } = 0;
        public double TrinucFrqDiff1st3rd { get; set; } = 0;
	}

	public class TrinucDiff
	{
		public string SeqType { get; set; } = string.Empty;
		public double DiffSum1st2nd { get; set; } = 0;
		public double DiffSum2nd3rd { get; set; } = 0;
		public double DiffSum1st3rd { get; set; } = 0;
		public double DiffSum { get; set; } = 0;
	}

	public class TrinucleotideMatch
	{
	        public int TrinucPosition { get; set; }
	        public string TrinucMatch { get; set; }
	}

	public class TrinucArray
	{
	        public string[] trinuc = new string[64];
	        public string[] monoNuc = { "a", "c", "g", "t" };

		public TrinucArray ()
		{
			int i = 0;
			foreach (var item1 in monoNuc)
			{
				foreach (var item2 in monoNuc)
				{
					foreach (var item3 in monoNuc)
					{
						trinuc [i++] = item1 + item2 + item3;
					}
				}
			}
		}
	}

	public class TrinucCalculation
	{
	        public Trinucleotides[] trinucleotides = new Trinucleotides[64];
	        TrinucArray trinucArray = new TrinucArray();
	        //List<TrinucNotMatch> trinucNotMatch = new List<TrinucNotMatch>( );

		public TrinucCalculation()
		{
			for (int i = 0; i < 64; i++)
			{
				trinucleotides[i] = new Trinucleotides{Trinuc = trinucArray.trinuc[i]};
			}
		}
	}

    public class Sequence
    {
        public string SeqName { get; set; } = "Seq name";
        public string Seq { get; set; } = string.Empty;
    }
}

using System;
namespace Oligonucs
{
	public class Tetranucleotides
	{
		public string Tetranuc { get; set; }
        	public int Tetranuc1st { get; set; } = 0;
		public int Tetranuc2nd { get; set; } = 0;
	        public int Tetranuc3rd { get; set; } = 0;
	        public int Tetranuc4th { get; set; } = 0;
	        public double TetranucFrq1st { get; set; } = 0;
	        public double TetranucFrq2nd { get; set; } = 0;
	        public double TetranucFrq3rd { get; set; } = 0;
	        public double TetranucFrq4th { get; set; } = 0;
	        public double TetranucDiff1st2nd { get; set; } = 0;
	        public double TetranucDiff1st3rd { get; set; } = 0;
	        public double TetranucDiff1st4th { get; set; } = 0;
	        public double TetranucDiff2nd3rd { get; set; } = 0;
	        public double TetranucDiff2nd4th { get; set; } = 0;
	        public double TetranucDiff3rd4th { get; set; } = 0;
    }

    public class TetranucleotideMatch
    {
        public int TetranucPasition { get; set; }
        public string TetranucMatch { get; set; }
    }

    public class TetranucArray
	{
	        public string[] tetranuc = new string[256];
	        public string[] monoNuc = { "a", "c", "g", "t" };
		
		public TetranucArray()
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
                            				tetranuc[i++] = item1 + item2 + item3 + item4;
			                        }
                    			}
        		        }
            		}
        	}
    	}

    	public class TetranucCalculation
    	{
        	public Tetranucleotides[] tetranucleotides = new Tetranucleotides[256];
        	TetranucArray tetranucArray = new TetranucArray();
		
		public TetranucCalculation()
	        {
	    		for (int i = 0; i < 256; i++)
			{
		                tetranucleotides[i] = new Tetranucleotides
		                {
					Tetranuc = tetranucArray.tetranuc[i]
		                };
			}
        	}
	}
}

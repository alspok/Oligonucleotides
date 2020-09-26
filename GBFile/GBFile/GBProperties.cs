using System;
namespace GBFile
{
	public class GBcds
	{
		public int CdsStart { get; set; } = 0;
		public int CdsEnd { get; set; } = 0;
		public int CompCdsStart { get; set; } = 0;
		public int CompCdsEnd { get; set; } = 0;
		public int NonCdsStart { get; set; } = 0;
		public int NonCdsEnd { get; set; } = 0;
	}

 	public class GBSeq
	{
		public string Seq { get; set; } = String.Empty;
	}
}

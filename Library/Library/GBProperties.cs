namespace GBFile
{
	public class GBFeat
	{
		public string SeqType { get; set; } = string.Empty;
		public int SeqStart { get; set; } = 0;
		public int SeqEnd { get; set; } = 0;
	}

	public class GBcds
	{
		public int CdsStart { get; set; } = 0;
		public int CdsEnd { get; set; } = 0;
		public string CdsSeq { get; set; } = string.Empty;

		public int CompCdsStart { get; set; } = 0;
		public int CompCdsEnd { get; set; } = 0;
		public string CompCdsSeq { get; set; } = string.Empty;

		public int NonCdsStart { get; set; } = 0;
		public int NonCdsEnd { get; set; } = 0;
		public string NonCdsSeq { get; set; } = string.Empty;
	}

	public class TotalCDS
	{
		public int Start { get; set; } = 0;
		public int End { get; set; } = 0;
	}

	public class GBSeq
	{
		public string Seq { get; set; } = string.Empty;
	}

	public class CDSSeq
	{
		public string Seq { get; set; } = string.Empty;
		public string SeqType { get; set; } = string.Empty; //"cds" or "comp".
		public int SeqStart { get; set; } = 0;
		public int SeqEnd { get; set; } = 0;
	}

	public  class NonCDSSeq
	{
		public string Seq { get; set; } = string.Empty;
		public string SeqType { get; set; } = string.Empty;//"noncds".
		public int SeqStart { get; set; } = 0;
		public int SeqEnd { get; set; } = 0;
	}
}

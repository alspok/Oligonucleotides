using System.Collections.Generic;

namespace GBFile
{
	public class GBSeparation
	{
		private GBSeq gbSeq;
		private List<GBcds> gbCds;

		public GBSeparation (GBSeq gbSeq, List<GBcds> gbCds)
		{
			this.gbSeq = gbSeq;
			this.gbCds = gbCds;
		}

		public void GBSeq ()
		{
			foreach(var item in gbCds)
			{
				if(item.CdsEnd - item.CdsStart > 0)
				{
					item.CdsSeq = gbSeq.Seq.Substring (item.CdsStart - 1, item.CdsEnd - item.CdsStart);
				}

				if(item.CompCdsEnd - item.CompCdsStart > 0)
				{
					var subSeq = gbSeq.Seq.Substring (item.CompCdsStart, item.CompCdsEnd - item.CompCdsStart);
					GBSequenceComp gbSequenceComp = new GBSequenceComp (subSeq);
					item.CompCdsSeq = gbSequenceComp.SeqComp ();
				}

				if(item.NonCdsEnd - item.NonCdsStart > 0)
				{
					item.NonCdsSeq = gbSeq.Seq.Substring (item.NonCdsStart - 1, item.NonCdsEnd - item.NonCdsStart);
				}
			}
		}
	}
}

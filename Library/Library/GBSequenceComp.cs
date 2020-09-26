using System.Linq;

namespace GBFile
{
	//Convert GB file seq to complement.
	public class GBSequenceComp
	{
		private readonly string seq;
		private string seqComp = string.Empty;

		public GBSequenceComp (string seq)
		{
			this.seq = seq;
		}

		//Convert seq to its complement.
		//Return complement reversed seq.
		public string SeqComp ()
		{
			foreach (var nuc in seq)
			{
				switch (nuc)
				{
				case 'a':
					seqComp += 't';
					break;
				case 'c':
					seqComp += 'g';
					break;
				case 'g':
					seqComp += 'c';
					break;
				case 't':
					seqComp += 'a';
					break;
				default:
					seqComp += nuc;
					break;
				}
			}

			return new string (seqComp.Reverse ().ToArray ());
		}

	}
}

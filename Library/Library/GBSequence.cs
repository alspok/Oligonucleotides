using System;
using System.IO;
using System.Text.RegularExpressions;

namespace GBFile
{
	//Get seq from GB file.
	//Parameter - GB file path and name.
    	//Return - seq string.
	public class GBSequence
	{
		private readonly string fileName;

		public GBSequence (string fileName)
		{
			this.fileName = fileName;
		}

		public GBSeq GbSeq ()
		{
			GBSeq gbSeq = new GBSeq ();

			using(StreamReader streamReader = File.OpenText (fileName))
			{
				string line = string.Empty;
				while((line = streamReader.ReadLine()) != null)
				{
					if (line.Contains ("ORIGIN"))
					{
						while((line = streamReader.ReadLine()) != "//")
						{
							string seqLine = Regex.Replace(line, "[^A-Za-z]", "").ToString();
							gbSeq.Seq += seqLine;
						}
					}
				}
			}
			return gbSeq;
		}
	}
}

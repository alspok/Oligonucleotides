using System;
using System.IO;

namespace FASTAFile
{
	public class FASTASequence
	{
		private readonly string fileName;

		public FASTASequence (string fileName)
		{
			this.fileName = fileName;
		}

		public FASTAProperties FastaSequence ()
		{
			FASTAProperties fastaProperties = new FASTAProperties();

			using(StreamReader streamReader = File.OpenText (fileName))
			{
				string line = string.Empty;
				while((line = streamReader.ReadLine()) != null)
				{
					if (line.Contains (">"))
					{
						fastaProperties.SeqFeatures = line;
					}
					else
					{
						fastaProperties.Seq += line.ToLower();
					}
				}
			}

			return fastaProperties;
		}
	}
}

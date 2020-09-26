using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace GBFile
{
	//Get start, end  possitions from GB file.
        public class GBFeatures
        {
                private readonly string fileName;

                public GBFeatures(string fileName)
                {
                        this.fileName = fileName;
                }

		//Read GB file Features CDS for 5'-3', join, complement, complement-join positions.
		//Return list of start, end positions
		public List<GBcds> Cds()
                {
                        List<GBcds> cds = new List<GBcds>();

			using (StreamReader streamReader = File.OpenText(fileName))
                        {
				string line = string.Empty;
				while ((line = streamReader.ReadLine()) != null)
                                {
					if (line.Contains("     CDS     "))
                                        {
                                                int[] numbers = Regex.Matches(line, @"\d+").OfType<Match>().Select(m => int.Parse(m.Value)).ToArray();

						for(var i = 0; i < numbers.Length - 1; i+=2)
						{
							if (line.Contains ("complement"))
							{
								cds.Add (new GBcds { CompCdsStart = numbers [i], CompCdsEnd = numbers [i + 1]});
							}
							else
							{
								cds.Add (new GBcds { CdsStart = numbers [i], CdsEnd = numbers [i + 1] });
							}
						}
                                        }
                                }
                        }

			//Reads cds start and end.  Writes noncds start and end points.
	 		for(var i = 0; i < cds.Count - 1; i++)
	 		{
				if(i == 0)
				{
					cds [i].NonCdsStart = 1;
					cds [i].NonCdsEnd = cds [i].CdsStart - 1;
				}
				else
				{
					cds [i].NonCdsStart = cds [i].CdsEnd + 1;
					cds [i].NonCdsEnd = cds [i + 1].CdsStart - 1;
				}
			}

			return cds;
                }
        }
}

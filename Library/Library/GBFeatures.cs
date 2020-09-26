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
				while ((line = streamReader.ReadLine()) != null )
                                {
					if (line.Contains ("ORIGIN")) break;
					if (line.Contains ("join")) continue;

					if (line.Contains("CDS"))
                                        {
                                                int[] numbers = Regex.Matches(line, @"\d+").OfType<Match>().Select(m => int.Parse(m.Value)).ToArray();

						for(var i = 0; i < numbers.Length - 1; i+=2)
						{
							if (line.Contains ("complement"))
							{
								cds.Add (new GBcds { CompCdsStart = numbers [i] - 1, CompCdsEnd = numbers [i + 1] });
							}
							else
							{
								cds.Add (new GBcds { CdsStart = numbers [i], CdsEnd = numbers [i + 1] + 1 });
							}
						}
                                        }
                                }
                        }

			//Total cds. No difference between cds and compcds.
			List<TotalCDS> totalCDS = new List<TotalCDS> ();
			foreach(var item in cds)
			{
				if (item.CdsStart != 0 && item.CdsEnd != 0)
				{
					totalCDS.Add (new TotalCDS { Start = item.CdsStart, End = item.CdsEnd });
				}
				else if (item.CompCdsStart != 0 && item.CompCdsEnd != 0)
				{
					totalCDS.Add (new TotalCDS { Start = item.CompCdsStart, End = item.CompCdsEnd });
				}
				else
				{
					continue;
				}
			}

			//Reads cds start and end.  Writes noncds start and end points.
			for (var i = 0; i < totalCDS.Count - 1; i++)
	 		{

				if(i == 0)
				{
					cds [i].NonCdsStart = 1;
					cds [i].NonCdsEnd = totalCDS [i].Start - 1;
				}
				else
				{
					cds [i].NonCdsStart = totalCDS [i].End + 1;
					cds [i].NonCdsEnd = totalCDS [i + 1].Start - 1;
				}
			}

			return cds;
                }
        }
}

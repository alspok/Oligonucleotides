using System;
using System.IO;
using System.Collections.Generic;
using GBFile;
using System.Text.RegularExpressions;
using System.Linq;

namespace Library
{
	public class GBSeqFeatures
	{
		private readonly string fileName;
        //private IEnumerable<object> gBFeaturesSeparation;

        public GBSeqFeatures(string fileName)
        {
			this.fileName = fileName;
        }

        public List<GBFeat> FeaturesSeparation ()
		{
            List<GBFeat> cdsFeatures = new List<GBFeat>();

            using (StreamReader streamReader = File.OpenText (fileName))
			{
				string line = string.Empty;
				string feature = string.Empty;

                try
                {
                    while (!(line = streamReader.ReadLine()).Contains("ORIGIN"))
                    {
                        if (line.Contains("CDS"))
                        {
                            int[] numbers = Regex.Matches(line, @"\d+").OfType<Match>().Select(m => int.Parse(m.Value)).ToArray();

                            if (line.Contains("CDS") && line.Contains("complement") && line.Contains("join"))
                            {
                                for (int i = 0; i < numbers.Length; i += 2)
                                {
                                    cdsFeatures.Add(new GBFeat{
                                        SeqType = "CJCDS",
                                        SeqStart = numbers[i] - 1,
                                        SeqEnd = numbers[i + 1] - 1 });
                                }
                            }
                            else if (line.Contains("CDS") && line.Contains("complement"))
                            {
                                cdsFeatures.Add(new GBFeat{
                                    SeqType = "CCDS",
                                    SeqStart = numbers[0] - 1,
                                    SeqEnd = numbers[1] - 1 });
                            }
                            else if (line.Contains("CDS") && line.Contains("join"))
                            {
                                for (int i = 0; i < numbers.Length; i += 2)
                                {
                                    cdsFeatures.Add(new GBFeat{
                                        SeqType = "JCDS",
                                        SeqStart = numbers[i] - 1,
                                        SeqEnd = numbers[i + 1] - 1 });
                                }
                            }
                            else
                            {
                                cdsFeatures.Add(new GBFeat{
                                    SeqType = "CDS",
                                    SeqStart = numbers[0] - 1,
                                    SeqEnd = numbers[1] - 1 });
                            }
                        }
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            return cdsFeatures;
        }

        public List<GBFeat> CompleteSeparation(List<GBFeat> _cdsFeatures)
        {
            List<GBFeat> cdsFeatures = _cdsFeatures;

            List<GBFeat> completeFeatures = new List<GBFeat>();

                for (var i = 0; i < cdsFeatures.Count - 1; i++)
                {
                    completeFeatures.Add(new GBFeat {
                        SeqType = cdsFeatures[i].SeqType,
                        SeqStart = cdsFeatures[i].SeqStart,
                        SeqEnd = cdsFeatures[i].SeqEnd, });

                    completeFeatures.Add(new GBFeat {
                        SeqType = "NCDS",
                        SeqStart = cdsFeatures[i].SeqEnd + 1,
                        SeqEnd = cdsFeatures[i + 1].SeqStart });
                }

            return completeFeatures;
        }
    }
}

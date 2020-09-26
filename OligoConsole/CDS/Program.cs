using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using TrinucConsole;

namespace CDS
{
        class MainClass
        {
                public static void Main(string[] args)
                {
                        Console.WriteLine("Get trinuc frq form CDS and nonCDS.");

                        //Escherichia.coli GB and FASTA files.
                        //string GBfileName = @"/home/alvydas/Sequencies/Bacteria/Escherichia.coli.gb";
                        //string FASTAfileName = @"/home/alvydas/Sequencies/Bacteria/Escherichia.coli.fasta";

                        //Lactococcus lactis GB and FASTA files.
                        //string GBfileName = @"/home/alvydas/Sequencies/Bacteria/Lactococcus.lactis.gb";
                        //string FASTAfileName = @"/home/alvydas/Sequencies/Bacteria/Lactococcus.lactis.fasta";                       

                        //Bacillus subtilis GB and FASTA files.
                        //string GBfileName = @"/home/alvydas/Sequencies/Bacteria/Bacilius.subtilis.gb";
                        //string FASTAfileName = @"/home/alvydas/Sequencies/Bacteria/Bacillus.subtilis.fasta";

                        //Salmonella typhimurium GB and FASTA files.
                        //string GBfileName = @"/home/alvydas/Sequencies/Bacteria/Salmonella.typhimurium.fasta";
                        //string FASTAfileName = @"/home/alvydas/Sequencies/Bacteria/Salmonella.typhimurium.gb";

                        //Staphylococcus aureus GB and FASTA files.
                        //string GBfileName = @"/home/alvydas/Sequencies/Bacteria/Staphylococcus.aureus.gb";
                        //string FASTAfileName = @"/home/alvydas/Sequencies/Bacteria/Staphylococcus.aureus.fasta";

                        //Streptococcus equinus GB and FASTA files.
                        string GBfileName = @"/home/alvydas/Sequencies/Bacteria/Streptococcus.equinus.gb";
                        string FASTAfileName = @"/home/alvydas/Sequencies/Bacteria/Streptococcus.equinus.fasta";

                        //Reading GB file. Making CDS list.
                        List<int> CDS = new List<int>();

                        using (StreamReader reader = new StreamReader(GBfileName))
                        {
                                string line;
                                int j = 1;
                                while ((line = reader.ReadLine()) != null)
                                {
                                        if (line.Contains("CDS   ") && !line.Contains("complement") && !line.Contains("join"))
                                        {
                                                Console.WriteLine(j++ + "\t" + line);
                                                var numbersFromString = new String(line.Where(Char.IsDigit).ToArray());
                                                int[] numbers = Regex.Matches(line, @"\d+").OfType<Match>().Select(m => int.Parse(m.Value)).ToArray();
                                                //CDS.Add(numbers);
                                                CDS.AddRange(numbers);
                                        }
                                }
                                CDS.Add(-1);
                                CDS.Add(-1);
                                CDS.Add(-1);
                        }

                        //
                        int[] arrayCDS = CDS.ToArray();

                        string seq = string.Empty;

                        using (StreamReader streamReader = new StreamReader(FASTAfileName))
                        {
                                seq = streamReader.ReadToEnd().ToLower().Replace("\n", string.Empty);
                        }



                        string codeSeq = string.Empty;
                        string nonCodeSeq = string.Empty;

                        int k = 1;
                        int n = 1;
                        for (int i = 0; i < arrayCDS.Length - 2; i++)
                        {
                                if (i % 2 == 0 && arrayCDS[i + 1] > arrayCDS[i] + 1 && arrayCDS[i] > 0)
                                {
                                        var subSeq = seq.Substring(arrayCDS[i] - 1, arrayCDS[i+1] - arrayCDS[i] + 1);
                                        if (subSeq.Length > 12)
                                        {
                                                Console.WriteLine(k++ + "\t\t" + arrayCDS[i] + "\t" + arrayCDS[i + 1] + "\t" + subSeq.Substring(0, 9) + "...." + subSeq.Substring(subSeq.Length - 9));
                                                codeSeq += subSeq;
                                        }
                                }

                                if(i % 2 != 0 && arrayCDS[i + 1] > arrayCDS[i] + 1 && arrayCDS[i] > 0)
                                {
                                        var subSeq = seq.Substring(arrayCDS[i] - 1, arrayCDS[i + 1] - arrayCDS[i] + 1);
                                        if (subSeq.Length > 12)
                                        {
                                                Console.WriteLine("\t" + n++ + "\t" + arrayCDS[i] + "\t" + arrayCDS[i + 1] + "\t" + subSeq.Substring(0, 9) + "...." + subSeq.Substring(subSeq.Length - 9));
                                                nonCodeSeq += subSeq ;
                                        }
                                }
                                //int start = item[0] - 1;
                                //int stop = start + item[1] - item[0] + 1;
                                //string seqCDS = seq.Substring(start, stop - start);
                                //bigSeqCDS += seqCDS;
                                //Console.WriteLine(seqCDS.Length);
                                //Console.WriteLine(seqCDS.Substring(0, 9) + "..." + seqCDS.Substring(seqCDS.Length - 9, 9));
                                //Console.WriteLine(seqCDS + "\n");
                        }

                        Console.WriteLine("Code seq length: " + codeSeq.Length);
                        TrinucleotideCalc trinucleotideCalc = new TrinucleotideCalc(codeSeq);
                        trinucleotideCalc.TrinucCalc();

                        Console.WriteLine("NonCode seq length: " + nonCodeSeq.Length);
                        trinucleotideCalc = new TrinucleotideCalc(nonCodeSeq);
                        trinucleotideCalc.TrinucCalc();
                }
        }
}

using System;
using System.Collections.Generic;
using Oligonucs;

namespace OligoCalculation
{
    public class TetranucCalc
    {
        private readonly string seqCalc;
        public int tetranucCount;
        public TetranucCalculation tetranucCalculation;
        public TetranucArray tetranucArray;
        public List<TetranucleotideMatch> tetranucMatches = new List<TetranucleotideMatch> ( );

        public TetranucCalc (string seq)
        {
            seqCalc = "nnnn" + seq + seq.Substring ( 0 , 9 );
            tetranucCount = 0;
            tetranucCalculation = new TetranucCalculation ( );
            tetranucArray = new TetranucArray ( );
        }

        public TetranucCalculation Calculation ( )
        {
            string oligoFrag = string.Empty;
            Console.WriteLine ( seqCalc.Substring ( 0 , 9 ) + "..." + seqCalc.Substring ( seqCalc.Length - 9 ) );

            for (var i = 0; i < seqCalc.Length - 9; i++ )
            {
                oligoFrag = seqCalc.Substring ( i , 4 );

                if(Array.IndexOf(tetranucArray.tetranuc, oligoFrag) < 0 )
                {
                    tetranucMatches.Add ( new TetranucleotideMatch { TetranucPasition = i , TetranucMatch = oligoFrag } );
                    continue;
                }

                if(i % 4 == 0 )
                {
                    var index = Array.FindIndex ( tetranucCalculation.tetranucleotides, row => row.Tetranuc == oligoFrag );
                    tetranucCalculation.tetranucleotides [ index ].Tetranuc1st += 1;
                    tetranucCount += 1;
                }
                else if((i - 1) % 4 == 0 )
                {
                    var index = Array.FindIndex ( tetranucCalculation.tetranucleotides, row => row.Tetranuc == oligoFrag );
                    tetranucCalculation.tetranucleotides [ index ].Tetranuc2nd += 1;
                }
                else if((i - 2) % 4 == 0 )
                {
                    var index = Array.FindIndex ( tetranucCalculation.tetranucleotides , row => row.Tetranuc == oligoFrag );
                    tetranucCalculation.tetranucleotides [ index ].Tetranuc3rd += 1;
                }
                else if((i - 3) % 4 == 0 )
                {
                    var index = Array.FindIndex ( tetranucCalculation.tetranucleotides , row => row.Tetranuc == oligoFrag );
                    tetranucCalculation.tetranucleotides [ index ].Tetranuc4th += 1;
                }
            }

            double diffSum1st2nd = 0;
            double diffSum1st3rd = 0;
            double diffSum1st4th = 0;
            double diffSum2nd3rd = 0;
            double diffSum2nd4th = 0;
            double diffSum3rd4th = 0;

            foreach(var item in tetranucCalculation.tetranucleotides )
            {
                item.TetranucFrq1st = ( double ) item.Tetranuc1st / ( double ) tetranucCount;
                item.TetranucFrq2nd = ( double ) item.Tetranuc2nd / ( double ) tetranucCount;
                item.TetranucFrq3rd = ( double ) item.Tetranuc3rd / ( double ) tetranucCount;
                item.TetranucFrq4th = ( double ) item.Tetranuc4th / ( double ) tetranucCount;

                item.TetranucDiff1st2nd = Math.Abs ( item.TetranucFrq1st - item.TetranucFrq2nd );
                diffSum1st2nd += item.TetranucDiff1st2nd;
                item.TetranucDiff1st3rd = Math.Abs ( item.TetranucFrq1st - item.TetranucFrq3rd );
                diffSum1st3rd += item.TetranucDiff1st3rd;
                item.TetranucDiff1st4th = Math.Abs ( item.TetranucFrq1st - item.TetranucFrq4th );
                diffSum1st4th += item.TetranucDiff1st4th;

                item.TetranucDiff2nd3rd = Math.Abs ( item.TetranucFrq2nd - item.TetranucFrq3rd );
                diffSum2nd3rd += item.TetranucDiff2nd3rd;
                item.TetranucDiff2nd4th = Math.Abs ( item.TetranucFrq2nd - item.TetranucFrq4th );
                diffSum2nd4th += item.TetranucDiff2nd4th;

                item.TetranucDiff3rd4th = Math.Abs ( item.TetranucFrq3rd - item.TetranucFrq4th );
                diffSum3rd4th += item.TetranucDiff3rd4th;
            }

            foreach(var item in tetranucCalculation.tetranucleotides )
            {
                Console.WriteLine ( item.Tetranuc + "\t" +
                                                        item.Tetranuc1st + "\t"  +
                                                        item.Tetranuc2nd + "\t" +
                                                        item.Tetranuc3rd + "\t" +
                                                        item.Tetranuc4th + "\t" +
                                                        item.TetranucFrq1st.ToString("0.00000") + "\t" +
                                                        item.TetranucFrq2nd.ToString ( "0.00000" ) + "\t" +
                                                        item.TetranucFrq3rd.ToString ( "0.00000" ) + "\t" +
                                                        item.TetranucFrq4th.ToString ( "0.00000" ) );
            }

            Console.WriteLine ( "\nTetranuc diff sums:\n" +
                                                    diffSum1st2nd.ToString ( "0.00000") + "\t" +
                                                    diffSum1st3rd.ToString ( "0.00000") + "\t" +
                                                    diffSum1st4th.ToString ( "0.00000") + "\t" +
                                                    diffSum2nd3rd.ToString ( "0.00000") + "\t" +
                                                    diffSum2nd4th.ToString ( "0.00000" ) + "\t" +
                                                    diffSum3rd4th.ToString ( "0.00000" ));

            return tetranucCalculation;
        }
    }
}

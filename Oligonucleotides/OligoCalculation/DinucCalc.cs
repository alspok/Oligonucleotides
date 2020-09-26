using System;
using Oligonucs;

namespace OligoCalculation
{
    public class DinucCalc
    {
        private readonly string seqCalc;
        int dinucCount;
        DinucCalculation dinucCalculation;

        public DinucCalc( string seq )
        {
            seqCalc = seq + seq.Substring ( 0, 9 );
            dinucCount = 0;
            dinucCalculation = new DinucCalculation ();
        }

        public DinucCalculation Calculation()
        {
            string oligoFrag = string.Empty;
            Console.WriteLine ( seqCalc .Substring(0, 6) + "..." + seqCalc.Substring(seqCalc.Length - 9));

            for(var i = 0; i < seqCalc.Length - 9; i++ )
            {
                oligoFrag = seqCalc.Substring ( i, 2 );

                if (i  % 2 == 0 )
                {
                    var index = Array.FindIndex ( dinucCalculation.dinucleotides, row => row.Dinuc == oligoFrag);
                    dinucCalculation.dinucleotides [ index ].Dinuc1st += 1;
                    dinucCount += 1;
                }
                else if(i % 2 != 0)
                {
                    var index = Array.FindIndex ( dinucCalculation.dinucleotides , row => row.Dinuc == oligoFrag );
                    dinucCalculation.dinucleotides [ index ].Dinuc2nd += 1;
                }
            }

            double diffSum = 0;

            foreach ( var item in dinucCalculation.dinucleotides )
            {
                item.DinucFrq1st = (double)item.Dinuc1st / (double) dinucCount;
                item.DinucFrq2nd = ( double ) item.Dinuc2nd / ( double ) dinucCount;
                item.DinucFrqDiff = Math.Abs ( item.DinucFrq1st - item.DinucFrq2nd );
                diffSum += item.DinucFrqDiff;
            }

            foreach (var item in dinucCalculation.dinucleotides )
            {
                Console.WriteLine ( item.Dinuc + "\t" +
                                                        item.Dinuc1st + "\t" + 
                                                        item.Dinuc2nd + "\t" +
                                                        item.DinucFrq1st.ToString("0.0000")  +"\t" +
                                                        item.DinucFrq2nd.ToString ( "0.0000" ) );
            }

            Console.WriteLine ( "\nDinuc diff sum: \n" + diffSum.ToString("0.0000") + "\n" );

            return dinucCalculation;
        }
    }
}
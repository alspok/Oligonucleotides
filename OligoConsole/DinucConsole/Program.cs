using System;

namespace DinucConsole
{
    class MainClass
    {
        public static void Main(string[] args)
        {
		//string seq = "aaacagatcacccgctgagcgggttatctgtt";
		//string seq = "aaaagggg";
		//string seq = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaggggggggggggggtttttttttttttttcggggggtatagaacagatagatagacaccccccac";
		//string seq = "ggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggg";
		string seq = "agctgggtgatcagtcgatgacagctgggtgatcagtcgatgacaagctgggtgatcagtcgatgacagctgggtgatcagtcgatgaca";


	    DinucleotideCalc dinucleotideCalc = new DinucleotideCalc(seq);
            dinucleotideCalc.DinucCalc();
        }
    }
}

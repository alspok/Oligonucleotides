using System.Web.Mvc;
using DinucCalculation;
using DinucMVC.Helpers;
using DinucMVC.Models;

namespace DinucMVC.Controllers
{

    public class SeqController : Controller
    {
        [HttpPost]
        public ActionResult SeqInput(string seq)
        {
            Match match = new Match();
            if (match.MatchNuc(seq))
            {
                Sequence sequence = new Sequence
                {
                    Seq = seq,
                    SeqLength = seq.Length
                };

                SeqOutput seqOutput = new SeqOutput(sequence);
                ViewBag.SeqLength = sequence.SeqLength;
                ViewBag.SeqOutput = seqOutput.SeqOut();

		//Dinucleotide calculation
		DinucCalc dinucCalc = new DinucCalc(sequence.Seq);
		var dinucList = dinucCalc.GetDinucleotides();

                return View("~/Views/Seq/SeqCalc.cshtml");
            }
            else
            {
                ViewBag.SeqCorrect = "false";
                //MessageBox.Show("ACGT only!");
                return View("~/Views/Home/SeqInput.cshtml");
            }
        }
    }
}

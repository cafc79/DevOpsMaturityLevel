using MaturityEvaluation.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace MaturityEvaluation.Pages
{
    public class EvaluacionInicialModel : PageModel
    {
        [BindProperty]
        public int mCurrent { get; set; }

        [BindProperty]
        public string mQuestion { get; set; }
               
        

        public void OnGet()
        {
            EvaluationT1 ev = new EvaluationT1();
            var survey = ev.GetNext(0, null);
            mCurrent = survey.Destiny;
            mQuestion = survey.Question;
        }

        public async Task<IActionResult> OnPost(int pCurrent, string pAnswer)
        {
            //ModelState.ClearValidationState(mCurrent)
            EvaluationT1 ev = new EvaluationT1();
            var survey = ev.GetNext(pCurrent, String.IsNullOrEmpty(pAnswer) ? "N" : pAnswer);
            if (survey.Destiny < 100)
            {
                mCurrent = survey.Destiny;
                mQuestion = survey.Question;
                return new PageResult();
            }
            else
                return new RedirectToPageResult("EvalResult", null, new { stage = survey.Question });
            
        }
    }
}
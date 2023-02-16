using MaturityEvaluation.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MaturityEvaluation.Pages
{
    public class EvaluacionDetalladaModel : PageModel
    {
        [BindProperty]
        public int mCurrent { get; set; }

        [BindProperty]
        public string mQuestion { get; set; }

        public void OnGet()
        {
            //EvaluationT2 ev = new EvaluationT2();
            //var survey = ev.GetNext(0, null);
            //mCurrent = survey.m;
            //mQuestion = survey.Question;
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

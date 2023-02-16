using MaturityEvaluation.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MaturityEvaluation.Pages
{
    public class EvalResultModel : PageModel
    {
        [BindProperty(Name = "stage", SupportsGet = true)]
        public string mTitle { get; set; }

        [BindProperty]
        public string mDescripcion { get; set; }

        public void OnGet()
        {            
            EvaluationT1 ev = new EvaluationT1();
            mTitle = Request.Query["stage"];
            mDescripcion = ev.GetResult(Request.Query["stage"]);            
        }
    }
}

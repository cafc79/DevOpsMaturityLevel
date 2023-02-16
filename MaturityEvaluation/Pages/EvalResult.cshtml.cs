using MaturityEvaluation.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace MaturityEvaluation.Pages
{
    public class EvalResultModel : PageModel
    {
        [BindProperty(Name = "stage", SupportsGet = true)]
        public string mTitle { get; set; }

        [BindProperty]
        public string mLevel { get; set; }

        [BindProperty]
        public string mDescripcion { get; set; }

        public void OnGet()
        {            
            EvaluationT1 ev = new EvaluationT1();
            mTitle = Request.Query["stage"];
            mDescripcion = ev.GetResult(Request.Query["stage"]);
            switch (mTitle) {
                case "Ad-Hoc":
                    mLevel = "alert-danger";
                    break;
                case "Defined":
                    mLevel = "alert-warning";
                    break;
                default:
                    mLevel = "alert-success";
                    break;
            }
        }
    }
}

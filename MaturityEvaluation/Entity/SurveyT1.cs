
namespace MaturityEvaluation.Entity
{
    public partial class SurveyT1
    {        
        public int Origin { get; set; }

        public string? Transicion { get; set; }

        public int Destiny { get; set; }

        public string Question { get; set; }

        public SurveyT1(byte origin, string? transicion, int destiny, string question)
        {
            Origin = origin;
            Transicion = transicion;
            Destiny = destiny;
            Question = question;
        }   
    }

    public partial class EvaluationT1
    {
        private readonly List<SurveyT1> ST1;

        public EvaluationT1()
        {
            ST1 = new List<SurveyT1>();
            ST1.Add(new SurveyT1(0, null, 1, "Do you have push button deployment"));
            ST1.Add(new SurveyT1(1, "Y", 2, "Do you have zero-touch continuous deployment"));
            ST1.Add(new SurveyT1(1, "N", 9, "Are your developments done manually?"));
            ST1.Add(new SurveyT1(2, "Y", 3, "Do you have automatic data state changes with every deployment?"));
            ST1.Add(new SurveyT1(2, "N", 5, "Are your teams fully cross-functional?"));
            ST1.Add(new SurveyT1(3, "Y", 4, "Are defects found and automatically fixed ?"));
            ST1.Add(new SurveyT1(3, "N", 6, "Are your development teams responsible all the way to production ?"));
            ST1.Add(new SurveyT1(4, "Y", 100, "Optimized"));
            ST1.Add(new SurveyT1(4, "N", 6, "Are your development teams responsible all the way to production ?"));
            ST1.Add(new SurveyT1(5, "Y", 6, "Are your development teams responsible all the way to production ?"));
            ST1.Add(new SurveyT1(5, "N", 11, "Can your builds be recreated from source control?"));
            ST1.Add(new SurveyT1(6, "Y", 7, "Are your development teams responsible all the way to production ?"));
            ST1.Add(new SurveyT1(6, "N", 8, "Any changes to data stores automatically performed during deployment ?"));
            ST1.Add(new SurveyT1(7, "Y", 100, "Optimized"));
            ST1.Add(new SurveyT1(7, "N", 120, "Measured"));
            ST1.Add(new SurveyT1(8, "Y", 120, "Measured"));
            ST1.Add(new SurveyT1(8, "N", 130, "Managed"));
            ST1.Add(new SurveyT1(9, "Y", 15, "Are deployments stressful, involve working on nights or weekends ?"));
            ST1.Add(new SurveyT1(9, "N", 10, "Do you have automated integration tests ?"));
            ST1.Add(new SurveyT1(10, "Y", 11, "Can your builds be recreated from source control?"));
            ST1.Add(new SurveyT1(10, "N", 13, "Are reports automatic and visible to teams ?"));
            ST1.Add(new SurveyT1(11, "Y", 8, "Any changes to data stores automatically performed during deployment ?"));
            ST1.Add(new SurveyT1(11, "N", 12, "Is your pipeline difficult to trace ?"));
            ST1.Add(new SurveyT1(12, "Y", 140, "Defined"));
            ST1.Add(new SurveyT1(13, "N", 14, "Do you have automated unit tests ?"));
            ST1.Add(new SurveyT1(14, "N", 150, "Ad-Hoc"));
            ST1.Add(new SurveyT1(15, "Y", 16, "Are reports done manually ?"));
            ST1.Add(new SurveyT1(15, "N", 13, "Are reports automatic and visible to teams ?"));
            ST1.Add(new SurveyT1(16, "Y", 150, "Ad-Hoc"));
            ST1.Add(new SurveyT1(16, "N", 13, "Are reports automatic and visible to teams ?"));
        }

        public SurveyT1 GetNext(int bOrigen, string? cTransition)
        {
            if (bOrigen == 0)
            {
                var s = (from st in ST1 where st.Origin.Equals(bOrigen) select st);
                return s.FirstOrDefault();
            }

            else
            {
                var s = (from st in ST1 where st.Origin.Equals(bOrigen) && st.Transicion == cTransition select st);
                return s.FirstOrDefault();
            }
        }

        public string? GetResult(string estado) { 

            Dictionary<string, string> rs1 = new Dictionary<string, string>();
            rs1.Add("Optimized", "Congratulation! You are in the top percentile of DevOps practitioners. Your continuous assessments of the overall  process lead you to achieve your business objectives with minimal risk and cost.");
            rs1.Add("Measured", "Process quality and performance are measured to achieve visibility and predictability. The performance of your processes is controlled using statistical and other measurable techniques");
            rs1.Add("Managed", "Processes are well characterized and standardized across all projects. Your standard processes are used to establish consistency throughout the organization");
            rs1.Add("Defined", "Your processes are defined but not standardized across projects or even across different lifecycle stages of the same project.");
            rs1.Add("Ad-Hoc", "Your processes are usually ad-hoc and disordered. Outcomes are unpredictable, often exceeding allocated budget and timelines");
            return rs1.GetValueOrDefault(estado);
        }
    }
}
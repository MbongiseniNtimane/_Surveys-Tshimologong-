namespace _Surveys.Models
{
    public class SurveyResults
    {
        public int TotalSurveys { get; set; }
        public double AverageAge { get; set; }
        public int MaxAge { get; set; }
        public int MinAge { get; set; }

        public int PizzaCount { get; set; }
        public int PastaCount { get; set; }
        public int PapWorsCount { get; set; }

        public double AvgMovies { get; set; }
        public double AvgRadio { get; set; }
        public double AvgEatOut { get; set; }
        public double AvgTV { get; set; }
    }
}

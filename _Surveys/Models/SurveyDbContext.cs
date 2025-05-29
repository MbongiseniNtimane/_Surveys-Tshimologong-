using Microsoft.EntityFrameworkCore;

namespace _Surveys.Models
{
    public class SurveyDbContext:DbContext
    {
        public DbSet<FillOutSurvey> FillOutSurveys { get; set; }

        public SurveyDbContext(DbContextOptions options) : base(options) 
        { 

        }
        
    }
}

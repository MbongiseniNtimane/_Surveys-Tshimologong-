using Microsoft.AspNetCore.Mvc;
using _Surveys.Models;
using System;
using System.Linq;

namespace _Surveys.Controllers
{
    public class FillOutSurveyController : Controller
    {
        private readonly SurveyDbContext _context;

        public FillOutSurveyController(SurveyDbContext context)
        {
            _context = context;
        }

        public IActionResult FillOutSurvey()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FillOutSurvey(FillOutSurvey model)
        {
            if (ModelState.IsValid)
            {
                _context.FillOutSurveys.Add(model);
                _context.SaveChanges();

                // ✅ Redirect after successful submission to avoid duplicate posts
                return RedirectToAction("SurveyResults");
            }

            return View(model);
        }

        public IActionResult SurveyResults()
        {
            var data = _context.FillOutSurveys.ToList();

            if (!data.Any())
            {
                ViewBag.Message = "No Surveys Available";
                return View("SurveyResultsEmpty");
            }

            var viewModel = new SurveyResults
            {
                TotalSurveys = data.Count,
                AverageAge = data.Average(x => CalculateAge(x.DateOfBirth)),
                MaxAge = data.Max(x => CalculateAge(x.DateOfBirth)),
                MinAge = data.Min(x => CalculateAge(x.DateOfBirth)),

                PizzaCount = data.Count(x => x.FavoriteFood == "Pizza"),
                PastaCount = data.Count(x => x.FavoriteFood == "Pasta"),
                PapWorsCount = data.Count(x => x.FavoriteFood == "Pap and Wors"),

                AvgMovies = data.Average(x => x.WatchMovies),
                AvgRadio = data.Average(x => x.ListenToRadio),
                AvgEatOut = data.Average(x => x.EatOut),
                AvgTV = data.Average(x => x.WatchTV)
            };

            return View(viewModel);
        }

        private int CalculateAge(DateTime dob)
        {
            var today = DateTime.Today;
            var age = today.Year - dob.Year;
            if (dob.Date > today.AddYears(-age)) age--;
            return age;
        }
    }
}

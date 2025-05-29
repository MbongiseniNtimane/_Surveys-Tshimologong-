using System.ComponentModel.DataAnnotations;

namespace _Surveys.Models
{
    public class FillOutSurvey
    {
        
        public int Id { get; set; }

        [Required(ErrorMessage = "Full name is required")]
        [StringLength(100)]
        public required string FullNames { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Date of Birth is required")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Contact number is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        public required string ContactNumber { get; set; }

        // Favorite food options
        [Required(ErrorMessage = "Pick a your favorite food")]
        public required string FavoriteFood { get; set; }

        // This is my Survey Questions
        [Required(ErrorMessage = "Pick from options")]
        public int WatchMovies { get; set; }
        [Required(ErrorMessage = "Pick from options")]
        public int ListenToRadio { get; set; }
        [Required(ErrorMessage = "Pick from options")]
        public int EatOut { get; set; }
        [Required(ErrorMessage = "Pick from options")]
        public int WatchTV { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace MoviesAppApi.Domin.Models.DB
{
    public class Review
    {
        public int Id { get; set; }

        [Required]
        public string Message { get; set; }

        [Required]
        public int MovieId { get; set; }
    }
}
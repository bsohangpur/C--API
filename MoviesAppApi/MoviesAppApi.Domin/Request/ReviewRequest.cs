using System.ComponentModel.DataAnnotations;

namespace MoviesAppApi.Models.Request
{
    public class ReviewRequest
    {
        public int Id { get; set; }

        [Required, StringLength(500)]
        public string Message { get; set; }

        [Required]
        public int MovieId { get; set; }
    }
}
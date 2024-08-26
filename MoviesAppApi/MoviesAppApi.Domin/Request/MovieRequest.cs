using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace MoviesAppApi.Models.Request
{
    public class MovieRequest
    {
        public int Id { get; set; }
        [Required, StringLength(200)]
        public string Name { get; set; }
        [Required]
        public int YearOfRelease { get; set; }
        [StringLength(500)]
        public string Plot { get; set; }
        [Required]
        public int ProducerId { get; set; }
        [Required, Url]
        public string CoverImage { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Language { get; set; }
        public int Profit { get; set; }
        public List<int> ActorIds { get; set; }
        public List<int> GenreIds { get; set; }
    }
}
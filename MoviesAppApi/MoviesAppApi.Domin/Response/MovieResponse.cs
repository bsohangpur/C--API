using MoviesAppApi.Domin.Models.DB;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace MoviesAppApi.Models.Response
{
    public class MovieResponse
    {
        public int Id { get; set; }
        [Required, StringLength(200)]
        public string Name { get; set; }
        [Required]
        public int YearOfRelease { get; set; }
        [StringLength(500)]
        public string Plot { get; set; }
        public Producer Producer { get; set; }
        [Required, Url]
        public string CoverImage { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Language { get; set; }
        public int Profit { get; set; }
        public IList<Actor> Actors { get; set; } 
        public IList<Genre> Genres { get; set; }
        public IList<Review> Reviews { get; set; }
    }
}
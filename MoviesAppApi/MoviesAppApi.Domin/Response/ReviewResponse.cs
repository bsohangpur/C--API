
using MoviesAppApi.Domin.Models.DB;
using System.ComponentModel.DataAnnotations;

namespace MoviesAppApi.Models.Response
{
    public class ReviewResponse
    {
        public int Id { get; set; }

        [Required, StringLength(500)]
        public string Message { get; set; }
        public MovieResponse Movie { get; set; }
    }
}
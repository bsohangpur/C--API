using System.ComponentModel.DataAnnotations;

namespace MoviesAppApi.Models.Request
{
    public class GenreRequest
    {
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }
    }
}
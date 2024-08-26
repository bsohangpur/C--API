using System.ComponentModel.DataAnnotations;

namespace MoviesAppApi.Models.Response
{
    public class GenreResponse
    {
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }
    }
}
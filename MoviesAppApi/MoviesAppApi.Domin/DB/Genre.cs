using System.ComponentModel.DataAnnotations;

namespace MoviesAppApi.Domin.Models.DB
{
    public class Genre
    {
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }
    }
}
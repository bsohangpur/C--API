using System.ComponentModel.DataAnnotations;

namespace MoviesAppApi.Domin.Models.DB
{
    public class Producer
    {
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }
        public string Bio { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        [Required, StringLength(10)]
        public string Gender { get; set; }
    }
}
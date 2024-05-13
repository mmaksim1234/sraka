using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dyplom.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Введіть ім'я")]
        [MaxLength(50, ErrorMessage = "Ваше ім'я занадто довге")]
        [MinLength(2, ErrorMessage = "Ваше ім'я закоротке")]
        public string Name { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Введіть email")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [NotMapped]
        [Compare("Password", ErrorMessage = "Repeat password")]
        public string repeatPassword { get; set; }

    }
}

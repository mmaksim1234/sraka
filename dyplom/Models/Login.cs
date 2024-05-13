using System.ComponentModel.DataAnnotations;

namespace dyplom.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Enter your email!")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter your password!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

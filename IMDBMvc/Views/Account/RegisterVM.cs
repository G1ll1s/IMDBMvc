using System.ComponentModel.DataAnnotations;

namespace IMDBMvc.Views.Account
{
    public class RegisterVM
    {
        [Required]
        public string Username { get; set; } = null!;

        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}

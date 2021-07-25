using System.ComponentModel.DataAnnotations;

namespace EducationPortal.Models
{
    public class RegisterRequest
    {
        [Required(ErrorMessage = "Не указан Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароль введен неверно")]
        public string ConfirmPassword { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace EducationPortal.Models
{
    public class SignInRequest
    {
        [Required(ErrorMessage = "Не указан Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

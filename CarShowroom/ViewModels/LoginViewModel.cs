using System.ComponentModel.DataAnnotations;

namespace CarShowroom.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Поле не може бути порожнім")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Поле не може бути порожнім")]
        public string Password { get; set; }
    }
}

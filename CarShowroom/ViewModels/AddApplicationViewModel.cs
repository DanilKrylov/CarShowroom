using CarShowroom.Models;
using System.ComponentModel.DataAnnotations;

namespace CarShowroom.ViewModels
{
    public class AddApplicationViewModel
    {
        [Required(ErrorMessage = "Поле не може бути порожнім")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Довжина повинна бути від 5 до 20 символів")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле не може бути порожнім")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Довжина повинна бути від 5 до 20 символів")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Поле не може бути порожнім")]
        [StringLength(12, MinimumLength = 5, ErrorMessage = "Довжина повинна бути  12 цифр")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Поле не може бути порожнім")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Поле не може бути порожнім")]
        public Color Color { get; set; }
        [Required(ErrorMessage = "Поле не може бути порожнім")]
        public CarType Type { get; set; }
        [Required(ErrorMessage = "Поле не може бути порожнім")]
        [Range(2000, 1000000, ErrorMessage ="Повинно бути в діапазоні від 2.000 до 1.000.000")]
        public int Budget { get; set; }

        public Application GetApplication(string userEmail)
        {
            return new Application()
            {
                UserAccountEmail = userEmail,
                Name = Name,
                Surname = Surname,
                Phone = Phone,
                Email = Email,
                Color = Color,
                Type = Type,
                Budget = Budget,
                State = ApplicationState.Waiting
            };
        }
    }
}

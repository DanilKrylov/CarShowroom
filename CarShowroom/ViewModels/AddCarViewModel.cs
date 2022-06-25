using CarShowroom.Models;
using System.ComponentModel.DataAnnotations;

namespace CarShowroom.ViewModels
{
    public class AddCarViewModel
    {
        [Required(ErrorMessage = "Поле не може бути порожнім")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Довжина повинна бути від 5 до 20 символів")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле не може бути порожнім")]
        [Range(1000, 1000000, ErrorMessage = "Повинно бути від 1.000 до 1.000.000")]
        public int Cost { get; set; }

        [Required(ErrorMessage = "Поле не може бути порожнім")]
        public Color Color { get; set; }

        [Required(ErrorMessage = "Поле не може бути порожнім")]
        [Range(1000, 2022, ErrorMessage = "Повинно бути від 1000 до 2022")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Поле не може бути порожнім")]
        public CarType Type { get; set; }

        [Required(ErrorMessage = "Поле не може бути порожнім")]
        public CarState State { get; set; }


        [Required(ErrorMessage = "Поле не може бути порожнім")]
        [StringLength(200, MinimumLength = 10, ErrorMessage = "Довжина повинна бути від 10 до 200 символів")]
        public string Desc { get; set; }
        public Car GetCar()
        {
            return new Car()
            {
                Name = Name,
                Color = Color,
                Year = Year,
                Type = Type,
                State = State,
                Desc = Desc,
                Cost = Cost,
            };
        }
    }
}

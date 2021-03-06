using CarShowroom.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarShowroom.ViewModels
{
    public class StatusApplicationViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string UserAccountEmail { get; set; }
        public int CarId { get; set; }
        public Color Color { get; set; }
        public CarType Type { get; set; }
        public int Budget { get; set; }
        public List<Car> Cars { get; set; }
        public ApplicationState State { get; set; }
        [Required(ErrorMessage ="Не може бути порожнім")]
        public string Desc { get; set; }
    }
}

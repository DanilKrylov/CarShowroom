using System.ComponentModel.DataAnnotations;

namespace CarShowroom.Models
{
    public enum CarType
    {
        [Display(Name = "Будь-який")]
        Any,
        [Display(Name = "Седан")]
        Sedan,
        [Display(Name = "Хатчбек")]
        Hatchback,
        [Display(Name = "Купе")]
        Coupe,
        [Display(Name = "Джип")]
        Jeep,
        [Display(Name = "Кросовер")]
        Crossover,
        [Display(Name = "Універсальна")]
        Universal,
        [Display(Name = "Спортивна")]
        Sport,
        [Display(Name = "Грузова")]
        Cargo
    }
}

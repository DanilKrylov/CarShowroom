using System.ComponentModel.DataAnnotations;

namespace CarShowroom.Models
{
    public enum Color
    {
        [Display(Name = "Будь-який")]
        Any,
        [Display(Name = "Червоний")]
        Red,
        [Display(Name = "Зелений")]
        Green,
        [Display(Name = "Синій")]
        Blue,
        [Display(Name = "Білий")]
        White,
        [Display(Name = "Чорний")]
        Black
    }
}

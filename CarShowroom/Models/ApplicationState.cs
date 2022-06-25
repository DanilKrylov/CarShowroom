using System.ComponentModel.DataAnnotations;

namespace CarShowroom.Models
{
    public enum ApplicationState
    {
        [Display(Name ="Очікування")]
        Waiting,
        [Display(Name = "Підтверджено")]
        Confirmed,
        [Display(Name = "Відхилено")]
        Denied,
        [Display(Name = "Немає машини")]
        NoSuitableCar,
    }
}
using System.ComponentModel.DataAnnotations;

namespace CarShowroom.Models
{
    public enum CarState
    {
        [Display(Name = "Будь-який")]
        Any,
        [Display(Name = "Нова")]
        New,
        [Display(Name = "Б/У")]
        Maintained,
        [Display(Name = "Після аварії")]
        AfterAccident,
    }
}
using System.ComponentModel.DataAnnotations;

namespace CarShowroom.Models
{
    public enum SortParam
    {
        [Display(Name ="Ціна за спаданням")]
        CostDecreasing,
        [Display(Name ="Ціна за зростанням")]
        CostIncreasing
    }
}

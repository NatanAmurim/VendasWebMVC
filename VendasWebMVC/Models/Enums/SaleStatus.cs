
using System.ComponentModel.DataAnnotations;

namespace SalesWebMVC.Models.Enums
{
    public enum SaleStatus : int
    {
        [Display(Name = "Pendente")]
        Pending = 0,
        [Display(Name = "Confirmado")]
        Billed = 1,
        [Display(Name = "Cancelado")]
        Canceled = 2
    }
}

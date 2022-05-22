using System.ComponentModel.DataAnnotations;

namespace SuperMarketManagement.Domain.Models.User;

public enum UserRole
{
    [Display(Name = "مدیر")]
    Manager,
    [Display(Name = "فروشنده")]
    Seller,
    [Display(Name = "مشتری")]
    Customer
}
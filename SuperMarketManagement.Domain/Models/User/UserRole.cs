using System.ComponentModel.DataAnnotations;

namespace SuperMarketManagement.Domain.Models.User;

public enum UserRole
{
    [Display(Name = "مشتری")]
    Customer,
    [Display(Name = "مدیر")]
    Manager,
}
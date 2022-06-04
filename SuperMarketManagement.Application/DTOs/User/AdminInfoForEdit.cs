using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SuperMarketManagement.Application.DTOs.User;

public class AdminInfoForEdit
{
    public AdminInfoForEdit()
    {
        UserName = "";
        Password = "";
    }

    public int Id { get; set; }

    [DisplayName("نام کاربری")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [MaxLength(400, ErrorMessage = "{0} نمیتواند بیش از {1} کاراکتر داشته باشد")]
    public string UserName { get; set; }
    
    public string? Password { get; set; }
}
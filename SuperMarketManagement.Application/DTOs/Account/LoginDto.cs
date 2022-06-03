
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace SuperMarketManagement.Application.DTOs.Account
{
    public class LoginDto
    {
        public LoginDto()
        {
            UserName = "";
            Password = "";
        }

        [DisplayName("نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        public string UserName { get; set; }

        [DisplayName("رمز عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        public string Password { get; set; }
    }
    
    public enum LoginResult
    {
        Success,
        UserNameNotFound,
        PasswordNotMatch,
        Error
    }
}

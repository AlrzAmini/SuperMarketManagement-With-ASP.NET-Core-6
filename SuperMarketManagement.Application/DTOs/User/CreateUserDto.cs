using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using SuperMarketManagement.Domain.Models.User;

namespace SuperMarketManagement.Application.DTOs.User
{
    public class CreateUserDto
    {
        public CreateUserDto()
        {
            Address = "بدون آدرس";
            Password = "123456";
        }
        
        #region properties

        [DisplayName("نام کاربری")]
        [MaxLength(400, ErrorMessage = "{0} نمیتواند بیش از {1} کاراکتر داشته باشد")]
        public string? UserName { get; set; }

        [DisplayName("آدرس")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(700, ErrorMessage = "{0} نمیتواند بیش از {1} کاراکتر داشته باشد")]
        public string Address { get; set; }

        [DisplayName("نقش کاربر")]        
        public UserRole UserRole { get; set; }

        [DisplayName("رمز عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        public string Password { get; set; }

        #endregion
    }
}

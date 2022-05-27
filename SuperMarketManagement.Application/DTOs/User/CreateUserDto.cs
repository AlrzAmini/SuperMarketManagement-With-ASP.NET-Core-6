using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using SuperMarketManagement.Domain.Models.User;

namespace SuperMarketManagement.Application.DTOs.User
{
    public class CreateUserDto
    {
        #region properties

        [DisplayName("نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(400, ErrorMessage = "{0} نمیتواند بیش از {1} کاراکتر داشته باشد")]
        public string? UserName { get; set; }

        [DisplayName("آدرس")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(700, ErrorMessage = "{0} نمیتواند بیش از {1} کاراکتر داشته باشد")]
        public string? Address { get; set; }

        #endregion
    }
}


using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace SuperMarketManagement.Application.DTOs.User
{
    public class EditUserDto
    {
        #region properties

        public int UserId { get; set; }

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

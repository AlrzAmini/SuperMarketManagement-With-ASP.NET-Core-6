using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using SuperMarketManagement.Domain.Models.Base;

namespace SuperMarketManagement.Domain.Models.User
{
    public class Admin : BaseEntity
    {
        #region properties

        public Admin()
        {
            UserName = "";
            Password = "";
        }

        [DisplayName("نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(400, ErrorMessage = "{0} نمیتواند بیش از {1} کاراکتر داشته باشد")]
        public string UserName { get; set; }

        [DisplayName("رمز عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        public string Password { get; set; }

        public bool IsDeleted { get; set; }

        #endregion
    }

    public enum AddAdminResult
    {
        Success,
        UserNameExist,
        Error
    }
}

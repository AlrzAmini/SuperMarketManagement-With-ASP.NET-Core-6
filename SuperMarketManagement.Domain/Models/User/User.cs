using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using SuperMarketManagement.Domain.Models.Base;

namespace SuperMarketManagement.Domain.Models.User
{
    public class User : BaseEntity
    {
        #region properties

        [DisplayName("نام کاربری")]
        [MaxLength(400, ErrorMessage = "{0} نمیتواند بیش از {1} کاراکتر داشته باشد")]
        public string? UserName { get; set; }

        [DisplayName("آدرس")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(700, ErrorMessage = "{0} نمیتواند بیش از {1} کاراکتر داشته باشد")]
        public string? Address { get; set; }

        public bool IsDelete { get; set; }

        #endregion

        #region relations

        

        #endregion
    }
}

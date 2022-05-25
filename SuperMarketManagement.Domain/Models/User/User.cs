using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SuperMarketManagement.Domain.Models.User
{
    public class User
    {
        #region constructor

        public User()
        {
            Address = "بدون آدرس";
            RegisterDate = DateTime.Now;
            UserRole = UserRole.Customer;
            Password = "123456";
        }

        #endregion

        #region properties

        [Key]
        public int UserId { get; set; }

        [DisplayName("نام کاربری")]
        [MaxLength(400, ErrorMessage = "{0} نمیتواند بیش از {1} کاراکتر داشته باشد")]
        public string? UserName { get; set; }

        [DisplayName("آدرس")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(700, ErrorMessage = "{0} نمیتواند بیش از {1} کاراکتر داشته باشد")]
        public string Address { get; set; }

        [DisplayName("رمز عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        public string? Password { get; set; }

        [DisplayName("تاریخ ثبت نام")]
        public DateTime RegisterDate { get; set; }

        public UserRole UserRole { get; set; }

        public bool IsDelete { get; set; }

        #endregion

        #region relations

        

        #endregion
    }
}

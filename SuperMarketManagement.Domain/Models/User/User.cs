using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketManagement.Domain.Models.User
{
    public class User
    {
        #region constructor

        public User()
        {
            Address = "Default";
            RegisterDate = DateTime.Now;
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

        public DateTime RegisterDate { get; set; }

        #endregion

        #region relations

        

        #endregion
    }
}

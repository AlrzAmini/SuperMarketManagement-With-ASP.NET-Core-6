using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarketManagement.Domain.Models.User;

namespace SuperMarketManagement.Application.DTOs.User
{
    public class EditUserDto
    {
        #region properties

        public int UserId { get; set; }

        [DisplayName("نام کاربری")]
        [MaxLength(400, ErrorMessage = "{0} نمیتواند بیش از {1} کاراکتر داشته باشد")]
        public string? UserName { get; set; }

        [DisplayName("آدرس")]
        [MaxLength(700, ErrorMessage = "{0} نمیتواند بیش از {1} کاراکتر داشته باشد")]
        public string? Address { get; set; }

        #endregion
    }
}

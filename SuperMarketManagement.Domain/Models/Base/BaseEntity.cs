using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketManagement.Domain.Models.Base
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "تاریخ ثبت")]
        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}

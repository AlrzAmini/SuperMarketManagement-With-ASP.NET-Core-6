using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketManagement.Domain.Models.Product
{
    public class ProductSize
    {
        #region properties

        public int Id { get; set; }

        [DisplayName("محصول")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        public int? ProductId { get; set; }

        [DisplayName("طول")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        public int Length { get; set; }

        [DisplayName("عرض")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        public int Width { get; set; }

        [DisplayName("ارتفاع")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]        
        public int Height { get; set; }

        public bool IsDeleted { get; set; }

        #endregion

        #region relations

        public Product? Product { get; set; }

        #endregion
    }
}

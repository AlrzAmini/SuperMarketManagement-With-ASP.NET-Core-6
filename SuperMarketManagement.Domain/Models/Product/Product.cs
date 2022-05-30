using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using SuperMarketManagement.Domain.Models.Base;

namespace SuperMarketManagement.Domain.Models.Product
{
    public class Product : BaseEntity
    {
        #region properties

        public int? GroupId { get; set; }

        [DisplayName("عنوان کالا")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(500, ErrorMessage = "{0} نمیتواند بیش از {1} کاراکتر داشته باشد")]
        public string? Title { get; set; }

        [DisplayName("قیمت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [Range(1000, double.MaxValue, ErrorMessage = "{0} باید بیشتر از {1} باشد")]
        public int Price { get; set; }

        [DisplayName("وزن")]
        [Range(1, double.MaxValue, ErrorMessage = "{0} باید بیشتر از {1} باشد")]
        public int? Weight { get; set; }

        [DisplayName("توضیحات")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(800, ErrorMessage = "{0} نمیتواند بیش از {1} کاراکتر داشته باشد")]
        public string? Description { get; set; }

        public bool IsDeleted { get; set; }

        #endregion

        #region relations

        public ProductGroup? Group { get; set; }

        #endregion

    }
}

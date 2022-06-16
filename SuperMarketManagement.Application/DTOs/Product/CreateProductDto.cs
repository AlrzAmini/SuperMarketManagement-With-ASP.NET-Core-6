using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarketManagement.Domain.Models.Product;

namespace SuperMarketManagement.Application.DTOs.Product
{
    public class CreateProductDto
    {
        #region properties

        public int GroupId { get; set; }

        public int SizeId { get; set; }

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

        [DisplayName("طول")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        public int Length { get; set; }

        [DisplayName("عرض")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        public int Width { get; set; }

        [DisplayName("ارتفاع")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        public int Height { get; set; }

        #endregion
    }

    public enum CreateProductResult
    {
        Success,
        Error,
        SizeError,
        GroupError,
    }
}

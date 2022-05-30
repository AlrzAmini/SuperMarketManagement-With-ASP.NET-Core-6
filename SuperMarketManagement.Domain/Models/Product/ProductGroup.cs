using System;
using SuperMarketManagement.Domain.Models.Base;

namespace SuperMarketManagement.Domain.Models.Product
{
    public class ProductGroup : BaseEntity
    {
        #region properties

        public string? Title { get; set; }

        public bool IsDeleted { get; set; }

        #endregion

        #region relations

        public ICollection<Product>? Products { get; set; }

        #endregion
    }
}

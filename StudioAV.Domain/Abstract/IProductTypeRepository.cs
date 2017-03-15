using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudioAV.Domain.Abstract
{
    public interface IProductTypeRepository
    {
        IEnumerable<ProductType> ProductTypes { get; }

        IEnumerable<ProductCategory> Categories { get; }

        bool SaveProductType(ProductType productType);

        ProductType DeleteProductType(int productTypeId);
    }
}

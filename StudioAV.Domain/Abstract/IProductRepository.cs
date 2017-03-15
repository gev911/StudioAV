using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudioAV.Domain.Abstract
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }

        IEnumerable<ProductType> ProductTypes { get; } 

        bool SaveProduct(Product product);

        Product DeleteProduct(int productId);
    }
}

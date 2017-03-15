using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudioAV.Domain.Abstract;

namespace StudioAV.Domain.Concrete
{
    public class EFProductRepository : IProductRepository
    {
        private StudioAVEntities _context = new StudioAVEntities();

        public IEnumerable<Product> Products { get { return _context.Products; } }

        public IEnumerable<ProductType> ProductTypes { get { return _context.ProductTypes; } }

        public bool SaveProduct(Product product)
        {
            try
            {
                if (product.Id == 0)
                {
                    product.DateCreated = DateTime.Now;
                    _context.Products.Add(product);
                }
                else
                {
                    Product dbEntry = _context.Products.Find(product.Id);
                    if (dbEntry != null)
                    {
                        dbEntry.DateModified = DateTime.Now;
                        dbEntry.Description = product.Description;
                        dbEntry.Material = product.Material;
                        dbEntry.Name = product.Name;
                        dbEntry.Price = product.Price;
                        dbEntry.ProductCode = product.ProductCode;
                        dbEntry.ProductTypeId = product.ProductTypeId;
                        dbEntry.ImageType = product.ImageType;
                        dbEntry.ImageData = product.ImageData;
                        dbEntry.Size = product.Size;
                    }
                    else
                    {
                        return false;
                    }
                }
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public Product DeleteProduct(int productId)
        {
            Product DbEntry = _context.Products.Find(productId);
            if (DbEntry != null)
            {
                _context.Products.Remove(DbEntry);
                _context.SaveChanges();
            }
            return DbEntry;
        }
    }
}

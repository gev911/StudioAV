﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudioAV.Domain.Abstract;

namespace StudioAV.Domain.Concrete
{
    public class EFProductTypeRepository : IProductTypeRepository
    {
        private StudioAVEntities _context;

        public IEnumerable<ProductType> ProductTypes
        {
            get
            {
                _context = new StudioAVEntities();
                return _context.ProductTypes;
            }
        }

        public IEnumerable<ProductCategory> Categories
        {
            get
            {
                _context = new StudioAVEntities();
                return _context.ProductCategories;
            }
        }

        public bool SaveProductType(ProductType productType)
        {
            using (_context = new StudioAVEntities())
            {
                try
                {
                    if (productType.Id == 0)
                    {
                        _context.ProductTypes.Add(productType);
                    }
                    else
                    {
                        ProductType DbEntity = _context.ProductTypes.Find(productType.Id);

                        DbEntity.Description = productType.Description;
                        DbEntity.Name = productType.Name;
                        DbEntity.ProductCategoryId = productType.ProductCategoryId;
                        DbEntity.Order = productType.Order;
                    }
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        public ProductType DeleteProductType(int productTypeId)
        {
            using (_context = new StudioAVEntities())
            {
                ProductType DbEntity = new ProductType();
                DbEntity = _context.ProductTypes.Find(productTypeId);
                if (DbEntity != null)
                {
                    _context.ProductTypes.Remove(DbEntity);
                    _context.SaveChanges();
                }
                return DbEntity;
            }

        }
    }
}

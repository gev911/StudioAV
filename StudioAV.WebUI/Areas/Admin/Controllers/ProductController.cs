using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudioAV.Domain;
using StudioAV.Domain.Abstract;
using StudioAV.WebUI.Areas.Admin.Models;
using StudioAV.WebUI.Infrastructure;

namespace StudioAV.WebUI.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository _repository;
        public static int ItemsPerPage = 12;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        // GET: Admin/Product
        public ViewResult Products(int page = 1)
        {
            ProductListViewModel model = new ProductListViewModel();
            model.Products = _repository.Products.
                OrderBy(c => c.ProductCode).
                Skip((page - 1)*ItemsPerPage).
                Take(12).
                Select(p => new ProductListItem
                {
                    ProductId = p.Id,
                    ProductCode = p.ProductCode,
                    Name = p.Name,
                    Type = p.ProductType.Name,
                    Size = p.Size,
                    Material = p.Material,
                    Price = (decimal) p.Price
                });
            model.PagingInfo = new PagingInfo
            {
                CorrentPage = page,
                ItemsPerPage = ItemsPerPage,
                TotalItems = _repository.Products.Count()
            };

            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new ProductViewModel();
            model.ProductTypes = _repository.ProductTypes.Select(
                p => new ProductTypeView
                {
                    Id = p.Id,
                    Name = p.Name
                });

            return View("Edit", model);
        }

        [HttpPost]
        public ActionResult Create(ProductViewModel model, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                var Product = new Product();

                if (image != null)
                {
                    Product.ImageType = image.ContentType;
                    Product.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(Product.ImageData, 0, image.ContentLength);
                }

                Product.Id = 0;
                Product.Name = model.Name;
                Product.Size = model.Size;
                Product.Material = model.Material;
                Product.Description = model.Description;
                Product.Price = model.Price;
                Product.DateCreated = DateTime.Now;
                Product.DateModified = DateTime.Now;
                Product.ProductTypeId = model.ProducTypeId;
                Product.ProductCode = model.ProductCode;

                _repository.SaveProduct(Product);

                TempData["Message"] = string.Format("{0} has been added", model.Name);

                return RedirectToAction("Products");
            }
            else
            {
                return View("Edit", model);
            }
        }

        [HttpGet]
        public ActionResult Edit(int productId)
        {
            var model = new ProductViewModel();
            var entity = _repository.Products.First(p => p.Id == productId);

            model.ProductCode = entity.ProductCode;
            model.Description = entity.Description;
            model.ImageData = entity.ImageData;
            model.Material = entity.Material;
            model.Name = entity.Name;
            model.Price = entity.Price;
            model.ProducTypeId = entity.ProductTypeId;
            model.Size = entity.Size;
            model.ProductId = entity.Id;

            model.ProductTypes = _repository.ProductTypes.Select(
                p => new ProductTypeView
                {
                    Id = p.Id,
                    Name = p.Name
                });

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(ProductViewModel model,HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                var product = new Product();

                if (image != null)
                {
                    product.ImageType = image.ContentType;
                    product.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(product.ImageData, 0, image.ContentLength);
                }
                
                product.Id = model.ProductId;
                product.Name = model.Name;
                product.Size = model.Size;
                product.Material = model.Material;
                product.Description = model.Description;
                product.Price = model.Price;
                product.DateModified = DateTime.Now;
                product.ProductTypeId = model.ProducTypeId;
                product.ProductCode = model.ProductCode;

                _repository.SaveProduct(product);

                TempData["Message"] = string.Format("{0} has been saved", model.Name);

                return RedirectToAction("Products");
            }
            else
            {
                return View("Edit", model);
            }
        }

        public FileContentResult GetImage(int productId)
        {
            Product model = _repository.Products.FirstOrDefault(p => p.Id == productId);

            if (model != null)
            {
                return File(model.ImageData, model.ImageType);
            }
            else
            {
                return null;
            }
        }

        [HttpPost]
        public ActionResult Delete(int productId)
        {
            var product = _repository.DeleteProduct(productId);

            TempData["Message"] = string.Format("{0} has been Deleted", product.Name);

            return RedirectToAction("Products");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudioAV.Domain;
using StudioAV.Domain.Abstract;
using StudioAV.WebUI.Areas.Admin.Models;

namespace StudioAV.WebUI.Areas.Admin.Controllers
{
    public class ProductTypeController : Controller
    {
        private IProductTypeRepository _repository;

        public ProductTypeController(IProductTypeRepository repository)
        {
            _repository = repository;
        }

        // GET: Admin/ProductType
        public ActionResult ProductTypes()
        {
            ProductTypeListViewModel model = new ProductTypeListViewModel();
            model.ProductTypes = _repository.ProductTypes.OrderBy(p => p.Order).Select(p => new ProductTypeItem
            {
                ProductTypeId = p.Id,
                Name = p.Name,
                Description = p.Description,
                Order = p.Order,
                Category = p.ProductCategory.Name
            });

            return View(model);
        }
        
        [HttpGet]
        public ActionResult Create()
        {
            var model = new ProductTypeViewModel();
            model.Categories = _repository.Categories.Select(p => new Category
            {
                Id = p.Id,
                Name = p.Name
            });

            return View("Edit", model);
        }

        [HttpPost]
        public ActionResult Create(ProductTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var Type = new ProductType();
                Type.Id = 0;
                Type.Description = model.Description;
                Type.Name = model.Name;
                Type.Order = model.Order;
                Type.ProductCategoryId = model.CategoryId;

                _repository.SaveProductType(Type);

                //TODO: Add temp message

                return RedirectToAction("ProductTypes");
            }
            else
            {
                return View("Edit", model);
            }

        }

        [HttpGet]
        public ActionResult Edit(int productTypeId)
        {
            var model = new ProductTypeViewModel();
            var entity = _repository.ProductTypes.First(p => p.Id == productTypeId);

            model.Order = entity.Order;
            model.CategoryId = entity.ProductCategoryId;
            model.Description = entity.Description;
            model.Name = entity.Name;

            model.Categories = _repository.Categories.Select(p => new Category
            {
                Id = p.Id,
                Name = p.Name
            });

            return View();
        }

        [HttpPost]
        public ActionResult Edit(ProductTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var Type = new ProductType();

                Type.Id = model.ProductTypeId;
                Type.Description = model.Description;
                Type.Name = model.Name;
                Type.Order = model.Order;
                Type.ProductCategoryId = model.CategoryId;

                _repository.SaveProductType(Type);

                //TODO: Add temp message

                return RedirectToAction("ProductTypes");
            }
            else
            {
                return View("Edit", model);
            }
        }

        [HttpPost]
        public ActionResult Delete(int productTypeId)
        {
            var Type = _repository.DeleteProductType(productTypeId);

            //TODO: Add temp message

            return RedirectToAction("ProductTypes");
        }
    }
}
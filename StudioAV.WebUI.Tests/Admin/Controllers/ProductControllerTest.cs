using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StudioAV.Domain;
using StudioAV.Domain.Abstract;
using StudioAV.WebUI.Areas.Admin.Controllers;
using StudioAV.WebUI.Areas.Admin.Models;

namespace StudioAV.WebUI.Tests.Admin.Controllers
{
    [TestClass]
    public class ProductControllerTests
    {
        [TestMethod]
        public void CanRetrieveProducts()
        {
            //Arrange
            var productType = new ProductType
            {
                Name = "Type",
                ProductCategoryId = 1,
                Id = 1
            };

            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]
            {
                new Product {ProductType = productType, ProductCode = 1, Id = 1, Name = "one", DateCreated = DateTime.Now, DateModified = DateTime.Now,Price = 100, ProductTypeId = 1, Size = "size", Material = "material"},
                new Product {ProductType = productType, ProductCode = 2, Id = 2, Name = "two", DateCreated = DateTime.Now, DateModified = DateTime.Now,Price = 100, ProductTypeId = 1, Size = "size", Material = "material"},
                new Product {ProductType = productType, ProductCode = 3, Id = 3, Name = "three", DateCreated = DateTime.Now, DateModified = DateTime.Now,Price = 100, ProductTypeId = 1, Size = "size", Material = "material"},
                new Product {ProductType = productType, ProductCode = 4, Id = 4, Name = "four", DateCreated = DateTime.Now, DateModified = DateTime.Now,Price = 100, ProductTypeId = 1, Size = "size", Material = "material"},
                new Product {ProductType = productType, ProductCode = 5, Id = 5, Name = "five", DateCreated = DateTime.Now, DateModified = DateTime.Now,Price = 100, ProductTypeId = 1, Size = "size", Material = "material"},
            });


            ProductController controller = new ProductController(mock.Object);
            controller.ItemsPerPage = 3;

            //Act
            ProductListViewModel result = (ProductListViewModel)controller.Products().Model;

            Assert.IsTrue(result.Products.Any());

        }

        [TestMethod]
        public void CanPaginate()
        {
            //Arrange
            var productType = new ProductType
            {
                Name = "Type",
                ProductCategoryId = 1,
                Id = 1
            };

            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]
            {
                new Product {ProductType = productType, ProductCode = 1, Id = 1, Name = "one", DateCreated = DateTime.Now, DateModified = DateTime.Now,Price = 100, ProductTypeId = 1, Size = "size", Material = "material"},
                new Product {ProductType = productType, ProductCode = 2, Id = 2, Name = "two", DateCreated = DateTime.Now, DateModified = DateTime.Now,Price = 100, ProductTypeId = 1, Size = "size", Material = "material"},
                new Product {ProductType = productType, ProductCode = 3, Id = 3, Name = "three", DateCreated = DateTime.Now, DateModified = DateTime.Now,Price = 100, ProductTypeId = 1, Size = "size", Material = "material"},
                new Product {ProductType = productType, ProductCode = 4, Id = 4, Name = "four", DateCreated = DateTime.Now, DateModified = DateTime.Now,Price = 100, ProductTypeId = 1, Size = "size", Material = "material"},
                new Product {ProductType = productType, ProductCode = 5, Id = 5, Name = "five", DateCreated = DateTime.Now, DateModified = DateTime.Now,Price = 100, ProductTypeId = 1, Size = "size", Material = "material"},
            });
            

            ProductController controller = new ProductController(mock.Object);
            controller.ItemsPerPage = 3;

            //Act
            ProductListViewModel result = (ProductListViewModel)controller.Products(2).Model;

            //Assert
            var array = result.Products.ToArray();

            Assert.IsTrue(array.Length == 2);
            Assert.AreEqual(array[0].Name, "four");
            Assert.AreEqual(array[1].Name, "five");

            //Assert.IsTrue(result.Products.Any());
        }

        [TestMethod]
        public void CanAddImage()
        {
            
        }
    }
}

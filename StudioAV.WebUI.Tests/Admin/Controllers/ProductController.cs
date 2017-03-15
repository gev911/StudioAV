using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StudioAV.Domain;
using StudioAV.Domain.Abstract;
using StudioAV.WebUI.Areas.Admin.Controllers;

namespace StudioAV.WebUI.Tests.Admin.Controllers
{
    [TestClass]
    public class ProductControllerTests
    {
        [TestMethod]
        public void CanRetrieveProducts()
        {
        }

        [TestMethod]
        public void CanPaginate()
        {
            //Arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]
            {
                new Product {ProductCode = 1, Id = 1, Name = "one"},
                new Product {ProductCode = 2, Id = 2, Name = "two"},
                new Product {ProductCode = 3, Id = 3, Name = "three"},
                new Product {ProductCode = 4, Id = 4, Name = "four"},
                new Product {ProductCode = 5, Id = 5, Name = "five"},
            });

            ProductController controller = new ProductController(mock.Object);
            
        }
    }
}

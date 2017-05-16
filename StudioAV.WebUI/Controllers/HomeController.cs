using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudioAV.Domain.Abstract;
using StudioAV.WebUI.Models;
using StudioAV.WebUI.Models.Common;

namespace StudioAV.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IProductRepository _productRepository;
        private ISpecialOfferRepository _specialOfferRepository;

        public HomeController(IProductRepository productRepo, ISpecialOfferRepository specialOfferRepo)
        {
            _productRepository = productRepo;
            _specialOfferRepository = specialOfferRepo;
        }

        // GET: Home
        public ActionResult Index()
        {
            var model = new MainPageViewModel();

            model.SpecialOffers = _specialOfferRepository.SpecialOffers.
                Where(s => s.Actual == true).
                Select(o => new Models.SpecialOffer
                {
                    ImagePath = o.BannerPath,
                    Url = o.URL
                });

            model.Products = _productRepository.Products.
                Where(p => p.ShowInFirstPage == true).
                Take(6).
                Select(p => new ProductThumbnailViewModel
                {
                    Name = p.Name,
                    ProductCode = p.ProductCode,
                    ShortDescription = p.Description,
                    ThumbnailPath = p.ThumbnailPath
                });

            return View(model);
        }
    }
}
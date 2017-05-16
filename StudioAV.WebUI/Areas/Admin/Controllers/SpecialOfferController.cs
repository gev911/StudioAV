using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudioAV.Domain;
using StudioAV.Domain.Abstract;
using StudioAV.WebUI.Areas.Admin.Models;
using StudioAV.WebUI.Infrastructure;

namespace StudioAV.WebUI.Areas.Admin.Controllers
{
    public class SpecialOfferController : Controller
    {
        private ISpecialOfferRepository _repository;
        static int ItemsPerPage = 12;

        public SpecialOfferController(ISpecialOfferRepository repository)
        {
            _repository = repository;
        }

        // GET: Admin/SpecialOffer
        public ActionResult SpecialOffers(int page = 1)
        {
            SpecialOfferListViewModel model = new SpecialOfferListViewModel();
            model.SpecialOffers = _repository.SpecialOffers.Where(o => o.Actual).
                OrderBy(o => o.Id).
                Skip((page - 1) * ItemsPerPage).
                Take(12).
                Select(m => new SpecialOfferListItem
                {
                    Id = m.Id,
                    Name = m.Name,
                    DateCreated = m.DateCreated
                });

            model.PagingInfo = new PagingInfo
            {
                CorrentPage = page,
                ItemsPerPage = ItemsPerPage,
                TotalItems = _repository.SpecialOffers.Count()
            };
            
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new SpecialOfferViewModel();

            return View("Edit", model);
        }

        [HttpPost]
        public ActionResult Create(SpecialOfferViewModel model, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                SpecialOffer offer = new SpecialOffer();
                var path = "";

                if (image != null)
                {
                    //write image to ~/Content/Images/SpecialOffers
                    path = Path.Combine("~/Content/Images/SpecialOffers", Guid.NewGuid() + Path.GetExtension(image.FileName));
                    image.SaveAs(path);
                }

                offer.Name = model.Name;
                offer.Actual = true;
                offer.DateCreated = DateTime.Now;
                offer.Description = model.Description;
                offer.URL = model.Url;
                offer.BannerPath = path;

                _repository.Save(offer);

                TempData["Message"] = string.Format("{0} has been saved", model.Name);

                return RedirectToAction("SpecialOffers");
            }
            else
            {
                return View("Edit", model);
            }
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var model = new SpecialOfferViewModel();
            var entity = _repository.SpecialOffers.First(o => o.Id == Id);

            model.Id = Id;
            model.Name = entity.Name;
            model.Description = entity.Description;
            model.DateCreated = entity.DateCreated;
            model.Url = entity.URL;
            model.BannerPath = entity.BannerPath;

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(SpecialOfferViewModel model, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                var offer = new SpecialOffer();
                var path = "";

                if (image != null)
                {
                    //write image to ~/Content/Images/SpecialOffers
                    path = Path.Combine("~/Content/Images/SpecialOffers", Guid.NewGuid() + Path.GetExtension(image.FileName));
                    image.SaveAs(Server.MapPath(path));
                }

                offer.Id = model.Id;
                offer.Name = model.Name;
                offer.Actual = true;
                offer.DateCreated = model.DateCreated;
                offer.Description = model.Description;
                offer.URL = model.Url;
                offer.BannerPath = path;

                _repository.Save(offer);

                TempData["Message"] = string.Format("{0} has been saved", model.Name);

                return RedirectToAction("SpecialOffers");
            }
            else
            {
                return View("Edit", model);
            }
        }
    }
}
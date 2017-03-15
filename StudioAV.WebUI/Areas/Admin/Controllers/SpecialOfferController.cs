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
            model.SpecialOffers = _repository.SpecialOffers.Where(o => o.Actual == true).
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

                if (image != null)
                {
                    offer.ImageType = image.ContentType;
                    offer.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(offer.ImageData, 0, image.ContentLength);
                }

                offer.Name = model.Name;
                offer.Actual = true;
                offer.DateCreated = DateTime.Now;
                offer.Description = model.Description;

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
        public ActionResult Edit(int offerId)
        {
            var model = new SpecialOfferViewModel();
            var entity = _repository.SpecialOffers.First(o => o.Id == offerId);

            model.Name = entity.Name;
            model.Description = entity.Description;
            model.DateCreated = entity.DateCreated;
            model.ImageData = entity.ImageData;
            model.ImageType = entity.ImageType;

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(SpecialOfferViewModel model, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                var offer = new SpecialOffer();

                if (image != null)
                {
                    offer.ImageType = image.ContentType;
                    offer.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(offer.ImageData, 0, image.ContentLength);
                }

                offer.Id = model.Id;
                offer.Name = model.Name;
                offer.Actual = true;
                offer.DateCreated = model.DateCreated;
                offer.Description = model.Description;

                _repository.Save(offer);

                TempData["Message"] = string.Format("{0} has been saved", model.Name);

                return RedirectToAction("SpecialOffers");
            }
            else
            {
                return View("Edit", model);
            }
        }

        public FileContentResult GetImage(int offerId)
        {
            var entity = _repository.SpecialOffers.FirstOrDefault(o => o.Id == offerId);

            if (entity != null)
            {
                return File(entity.ImageData, entity.ImageType);
            }
            else
            {
                return null;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudioAV.WebUI.Models.Common;

namespace StudioAV.WebUI.Models
{
    public class MainPageViewModel
    {
        public IEnumerable<SpecialOffer> SpecialOffers { get; set; }

        public IEnumerable<ProductThumbnailViewModel> Products { get; set; }
    }

    public class SpecialOffer
    {
        public string ImagePath { get; set; }

        public string Url { get; set; }
    }
}
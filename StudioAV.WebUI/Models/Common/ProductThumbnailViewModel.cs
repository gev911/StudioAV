using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudioAV.WebUI.Models.Common
{
    public class ProductThumbnailViewModel
    {
        public string Name { get; set; }

        public int ProductCode { get; set; }

        public string ShortDescription { get; set; }

        public string ThumbnailPath { get; set; }
    }
}
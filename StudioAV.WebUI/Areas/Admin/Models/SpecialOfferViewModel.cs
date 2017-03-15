using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudioAV.WebUI.Areas.Admin.Models
{
    public class SpecialOfferViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime DateCreated { get; set; }

        public byte[] ImageData { get; set; }

        public string ImageType { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudioAV.WebUI.Infrastructure;

namespace StudioAV.WebUI.Areas.Admin.Models
{
    public class SpecialOfferListViewModel
    {
        public IEnumerable<SpecialOfferListItem> SpecialOffers { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }

    public class SpecialOfferListItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateCreated { get; set; }

        public bool IsActual { get; set; }
    }
}
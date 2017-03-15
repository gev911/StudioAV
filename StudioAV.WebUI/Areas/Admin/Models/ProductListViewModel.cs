using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudioAV.WebUI.Infrastructure;

namespace StudioAV.WebUI.Areas.Admin.Models
{
    public class ProductListViewModel
    {
        public IEnumerable<ProductListItem> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }

    public class ProductListItem
    {
        public int ProductId { get; set; }

        public int ProductCode { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Size { get; set; }

        public string Material { get; set; }

        public decimal Price { get; set; }
    }

    //public class PagingInfo
    //{
    //    public int CorrentPage { get; set; }

    //    public int ItemsPerPage { get; set; }

    //    public int TotalItems { get; set; }

    //    public int TotalPages { get { return TotalItems/ItemsPerPage; } }
    //}
}
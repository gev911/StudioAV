using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudioAV.WebUI.Areas.Admin.Models
{
    public class ProductTypeListViewModel
    {
        public IEnumerable<ProductTypeItem> ProductTypes { get; set; }
    }

    public class ProductTypeItem
    {
        public int ProductTypeId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Order { get; set; }

        public string Category { get; set; }
    }
}
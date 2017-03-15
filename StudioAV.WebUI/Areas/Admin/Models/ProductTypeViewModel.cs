using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudioAV.WebUI.Areas.Admin.Models
{
    public class ProductTypeViewModel
    {
        public int ProductTypeId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Order { get; set; }

        public int CategoryId { get; set; }

        public IEnumerable<Category> Categories { get; set; }
    }

    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}

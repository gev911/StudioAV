using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudioAV.Domain;

namespace StudioAV.WebUI.Areas.Admin.Models
{
    public class ProductViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Please Enter product code")]
        [Range(0,999999,ErrorMessage = "Please enter valid product code [0..999999]")]
        public int ProductCode { get; set; }

        [Required(ErrorMessage = "Please Enter product Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter Size")]
        public string Size { get; set; }

        [Required(ErrorMessage = "Please Enter Material")]
        public string Material { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please Enter valid price >0.01")]
        public decimal Price { get; set; }

        public byte[] ImageData { get; set; }

        public string ImageType { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public int ProducTypeId { get; set; }

        public IEnumerable<ProductTypeView> ProductTypes { get; set; }
    }

    public class ProductTypeView
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
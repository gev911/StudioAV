//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudioAV.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public string Material { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public System.DateTime DateCreated { get; set; }
        public System.DateTime DateModified { get; set; }
        public int ProductTypeId { get; set; }
        public int ProductCode { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageType { get; set; }
    
        public virtual ProductType ProductType { get; set; }
    }
}
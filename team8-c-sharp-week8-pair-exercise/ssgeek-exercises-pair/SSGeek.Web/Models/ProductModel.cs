using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSGeek.Web.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string ProductImage { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
    }
}
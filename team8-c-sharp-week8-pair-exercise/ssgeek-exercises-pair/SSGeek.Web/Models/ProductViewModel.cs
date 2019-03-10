using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSGeek.Web.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string ProductImage { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }

        public IList<ProductModel> Products { get; set; }
        public ProductModel Product { get; set; }
    }
}

using System.Collections.Generic;
using SSGeek.Web.Models;

namespace SSGeek.Web.DAL
{
    public interface IProductsDAL
    {
        IList<ProductModel> GetProducts();
        ProductModel GetProduct(int id);
    }
}

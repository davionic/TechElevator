using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SSGeek.Web.DAL;
using SSGeek.Web.Extensions;
using SSGeek.Web.Models;

namespace SSGeek.Web.Controllers
{
    public class StoreController : Controller
    {
        private readonly IProductsDAL _productsDal;

        public StoreController(IProductsDAL productsDal)
        {
            _productsDal = productsDal;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ProductViewModel model = new ProductViewModel
            {
                Products = _productsDal.GetProducts()
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            ProductViewModel model = new ProductViewModel
            {
                Product = _productsDal.GetProduct(id)
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult AddToCart(ProductModel product, int quantity)
        {
            // Add whichever Product productId represents to the shopping cart

            //1.  Get the Product associated with id
            product = _productsDal.GetProduct(product.Id);

            //2.  Add Product, qty 1 to our active shopping cart
            Models.ShoppingCart cart = GetActiveShoppingCart();
            cart.AddToCart(product, 1);

            //3. Save shopping cart
            SaveActiveShoppintCart(cart);

            return RedirectToAction("ViewCart");
        }

        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            // Get the product associated with the id
            var product = _productsDal.GetProduct(id);

            // Find the active shopping cart
            var cart = GetActiveShoppingCart();

            // Remove Qty 1 of product from shopping cart
            cart.RemoveOne(product);

            // Save shopping cart
            SaveActiveShoppintCart(cart);

            // Redirect to ViewCart
            return RedirectToAction("ViewCart");
        }

        public ActionResult ViewCart()
        {
            Models.ShoppingCart cart = GetActiveShoppingCart();
            return View(cart);
        }

        private Models.ShoppingCart GetActiveShoppingCart()
        {
            Models.ShoppingCart cart = null;

            // See if the user has a shopping cart stored in session            
            if (HttpContext.Session.Get<Models.ShoppingCart>("Shopping_Cart") == null)
            {
                cart = new Models.ShoppingCart();
                SaveActiveShoppintCart(cart);
            }
            else
            {
                cart = HttpContext.Session.Get<Models.ShoppingCart>("Shopping_Cart"); // <-- gets the shopping cart out of session
            }

            // If not, create one for them

            return cart;
        }

        private void SaveActiveShoppintCart(Models.ShoppingCart cart)
        {
            HttpContext.Session.Set("Shopping_Cart", cart);        // <-- saves the shopping cart into session
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCModels.Web.DAL;
using MVCModels.Web.Models;

namespace MVCModels.Web.Controllers
{
    public class RecipesController : Controller
    {        
        // GET: recipes/
        // GET: recipes/index
        public IActionResult Index()
        {
            IRecipeDAL dal = new MockRecipeDAL();
            IList<Recipe> recipes = dal.GetRecipes(); 

            return View(recipes);
        }

        // GET: recipes/table
        public IActionResult Table()
        {
            IRecipeDAL dal = new MockRecipeDAL();
            IList<Recipe> recipes = dal.GetRecipes();

            return View(recipes);
        }

        // GET: recipes/detail/1
        // GET: recipes/detail/3
        // GET: recipes/detail?id=1
        // GET: recipes/detail?id=3
        public IActionResult Detail(int id = 1)
        {
            IRecipeDAL dal = new MockRecipeDAL();
            Recipe recipe = dal.GetRecipe(id);

            return View(recipe);
        }
    }
}
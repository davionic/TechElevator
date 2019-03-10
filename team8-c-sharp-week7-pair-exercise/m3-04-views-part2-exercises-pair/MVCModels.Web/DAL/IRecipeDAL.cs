using MVCModels.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCModels.Web.DAL
{
    public interface IRecipeDAL
    {
        /// <summary>
        /// Gets a single recipe
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Recipe GetRecipe(int id);

        /// <summary>
        /// Returns all of the recipes
        /// </summary>
        /// <returns></returns>
        IList<Recipe> GetRecipes();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCModels.Web.Models
{
    public class Recipe
    {
        public int Id { get; set; }

        /// <summary>
        /// Name of the recipe
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description of the recipe
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The image name for the recipe
        /// </summary>
        public string ImageName { get; set; }

        /// <summary>
        /// Ingredients in the recipe
        /// </summary>
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

        /// <summary>
        /// Steps for preparing the recipe
        /// </summary>
        public List<string> PreparationSteps { get; set; } = new List<string>();

        /// <summary>
        /// Average rating of the recioe
        /// </summary>
        public double AverageRating { get; set; }

        /// <summary>
        /// Approx. time in minutes to cook
        /// </summary>
        public int CookTimeInMinutes { get; set; }

        /// <summary>
        /// Type of recipe
        /// </summary>
        public string RecipeType { get; set; }
    }
}

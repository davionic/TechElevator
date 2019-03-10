using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCModels.Web.Models
{
    public class Ingredient
    {
        /// <summary>
        /// Name of the ingredient
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Quantity of the ingredient in the recipe
        /// </summary>
        public string Quantity { get; set; }
    }
}

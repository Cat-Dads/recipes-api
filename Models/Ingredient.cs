using System.Collections.Generic;

namespace recipes_api.Models
{
    public class Ingredient
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public ICollection<RecipeIngredient> RecipeIngredients { get; set; }
    }
}
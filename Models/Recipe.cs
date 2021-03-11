using System.Collections.Generic;

namespace recipes_api.Models
{
    public class Recipe
    {
        public long Id { get; set; }
        public decimal Rating { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public string Directions { get; set; }
    }
}
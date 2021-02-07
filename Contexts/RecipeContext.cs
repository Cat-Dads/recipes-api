using Microsoft.EntityFrameworkCore;
using recipes_api.Models;

namespace recipes_api.Contexts
{
    public class RecipeContext : DbContext
    {
        public RecipeContext(DbContextOptions<RecipeContext> options) : base(options) { }

        public DbSet<Recipe> RecipeItems { get; set; }
    }
}
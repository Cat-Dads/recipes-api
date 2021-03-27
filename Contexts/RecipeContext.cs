using Microsoft.EntityFrameworkCore;
using recipes_api.Models;

namespace recipes_api.Contexts
{
    public class RecipeContext : DbContext
    {
        public RecipeContext(DbContextOptions<RecipeContext> options) : base(options) { }

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<RecipeIngredient>()
        //         .HasKey(ri => new { ri.RecipeId, ri.IngredientId });

        //     modelBuilder.Entity<Recipe>()
        //         .HasMany(r => r.RecipeIngredients)
        //         .WithRequired()
        // }

        public DbSet<Recipe> RecipeItems { get; set; }
        public DbSet<Ingredient> IngredientItems { get; set; }
    }
}
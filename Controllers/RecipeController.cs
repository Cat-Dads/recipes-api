using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using recipes_api.Contexts;
using recipes_api.Models;

namespace recipes_api.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowLocalhost")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly RecipeContext _context;

        public RecipeController(RecipeContext context)
        {
            _context = context;
        }

        // GET: api/Recipe
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recipe>>> GetRecipeItems()
        {
            return await _context.RecipeItems.ToListAsync();
        }

        // GET: api/Recipe/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Recipe>> GetRecipe(long id)
        {
            var recipe = await _context
                .RecipeItems
                .Include(recipe => recipe.Ingredients)
                .FirstOrDefaultAsync(recipe => recipe.Id == id);

            if (recipe == null)
            {
                return NotFound();
            }

            return recipe;
        }

        // PUT: api/Recipe/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecipe(long id, Recipe recipe)
        {
            if (id != recipe.Id)
            {
                return BadRequest();
            }

            _context.Entry(recipe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Recipe
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Recipe>> PostRecipe(Recipe recipe)
        {
            Console.WriteLine($"Received recipe: {JsonSerializer.Serialize(recipe)}");

            _context.RecipeItems.Add(recipe);
            _context.IngredientItems.AddRange(recipe.Ingredients);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRecipe", new { id = recipe.Id }, recipe);
        }

        // DELETE: api/Recipe/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipe(long id)
        {
            var recipe = await _context.RecipeItems.FindAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }

            _context.RecipeItems.Remove(recipe);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RecipeExists(long id)
        {
            return _context.RecipeItems.Any(e => e.Id == id);
        }
    }
}

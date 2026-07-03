using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projebridgeapi.Models;
using projectbridgeapi.Models;

namespace projebridgeapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public CategoriesController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet("GetCategories")]
        public async Task<IActionResult> GetCategories()
        {
            var values = await context.Categories.ToListAsync();
            return Ok(values);
        }

        [HttpGet("GetCategoryById/{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var value = await context.Categories.FindAsync(id);

            if (value == null)
            {
                return NotFound();
            }

            return Ok(value);
        }

        [HttpPost("AddCategory")]
        public async Task<IActionResult> AddCategory(Category category)
        {
            await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();

            return Ok("Kategori başarıyla eklendi.");
        }

        [HttpPut("UpdateCategory/{id}")]
        public async Task<IActionResult> UpdateCategory(int id, Category category)
        {
            var value = await context.Categories.FindAsync(id);

            if (value == null)
            {
                return NotFound();
            }

            value.CategoryName = category.CategoryName;
            value.Description = category.Description;

            await context.SaveChangesAsync();

            return Ok("Kategori başarıyla güncellendi.");
        }

        [HttpDelete("DeleteCategory/{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var value = await context.Categories.FindAsync(id);

            if (value == null)
            {
                return NotFound();
            }

            context.Categories.Remove(value);
            await context.SaveChangesAsync();

            return Ok("Kategori başarıyla silindi.");
        }
    }
}
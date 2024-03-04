using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly APIContext _context;

        public CategoriesController(APIContext context)
        {
            _context = context;
        }

        [HttpGet("products")]
        public ActionResult<IEnumerable<Category>> GetCategoriesProducts()
        {
            return _context.Categories.Include(p => p.Products).ToList();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Category>> Get()
        {
            return Ok(_context.Categories.ToList());
        }

        [HttpGet("{id:int}")]
        public ActionResult<Category> Get(int id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.CategoryId == id);
            if (category == null)
            {
                return NotFound("No category was found...");
            }
            return Ok(category);
        }

        [HttpPost]
        public ActionResult Post(Category category)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Categories.Add(category);
            _context.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = category.CategoryId }, category);

        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Category category)
        {
            if (id != category.CategoryId)
            {
                return BadRequest(ModelState);
            }
            _context.Entry(category).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(category);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.CategoryId == id);
            if (category is null)
                return NotFound("Category not found...");

            _context.Categories.Remove(category);
            _context.SaveChanges();

            return Ok(category);
        }
    }
}

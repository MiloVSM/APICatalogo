using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly APIContext _context;

        public ProductsController(APIContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            var products = _context.Products.AsNoTracking().Take(10).ToList();
            if (products is null)
            {
                return NotFound("Produtos não encontrados...");
            }
            return products;
        }

        [HttpGet("{id:int}")]
        public ActionResult<Product> Get(int id)
        {
            var product = _context.Products.AsNoTracking().FirstOrDefault(p => p.ProductId == id);
            if (product is null)
            {
                return NotFound("Produto não encontrado...");
            }
            return product;
        }

        [HttpPost]
        public ActionResult Post(Product product)
        {
            if (product is null)
            {
                return BadRequest();   
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Products.Add(product);
            _context.SaveChanges(); 

            return CreatedAtAction(nameof(Get), new { id = product.ProductId }, product);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Product newProduct)
        {
            var product = _context.Products.FirstOrDefault(p => p.ProductId == id);
            if (product is null)
            {
                return BadRequest("Product was not found... Check Product Id");
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(product);
        }


        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                return NotFound("Produto não encontrado...");
            }
            _context.Products.Remove(product);
            _context.SaveChanges();

            return Ok(product);
        }

    }
}

using EFCorePageinationNET6.Data;
using EFCorePageinationNET6.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCorePageinationNET6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DataContext _context;
        // inject
        public ProductController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{page}")]
        //[Route("{page}")]
        public async Task<ActionResult<List<Product>>> GetProducts(int page)
        {
            if (_context.Products == null)
            {
                return NotFound();
            }

            var pageResults = 3f;
            var pageCount = Math.Ceiling(_context.Products.Count() / pageResults); // for implement search: product(title/description: {searchTerm}) ?(maybe)

            var products = await _context.Products
                .Skip((page - 1)* (int)pageResults)
                .Take((int)pageResults)
                .ToListAsync();

            var respone = new ProductResponseDTO
            {
                Products = products,
                CurrentPage = page,
                Pages = (int)pageCount
            };

            return Ok(respone);
        }

    }
}

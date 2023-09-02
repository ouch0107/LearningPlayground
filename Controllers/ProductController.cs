using LearningPlayground.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LearningPlayground.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductRepository _productRepository;

        public ProductController(
            ILogger<ProductController> logger,
            IProductRepository productRepository
            )
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productRepository.GetProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(string id)
        {
            var product = await _productRepository.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(product);
            }
        }
    }
}
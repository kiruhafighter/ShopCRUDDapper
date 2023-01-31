using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopCRUDDapper.Models;

namespace ShopCRUDDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductRepository productRepository;

        public ProductController()
        {
            productRepository = new ProductRepository();
        }

        [HttpGet]
        //[ProducesResponseType(200, Type= typeof(IEnumerable<Product>))]  
        public IEnumerable<Product> Get()
        {
            return productRepository.GetAll();
        }

        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return productRepository.GetById(id);
        }

        [HttpPost]
        public void Post([FromBody] Product product)
        {
            if (ModelState.IsValid)
            {
                productRepository.Add(product);
            }
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Product product)
        {
            product.Id = id;
            if (ModelState.IsValid)
            {
                productRepository.Update(product);
            }
        }

        [HttpDelete]
        public void Delete(int id)
        {
            productRepository.Delete(id);
        }

    }
}

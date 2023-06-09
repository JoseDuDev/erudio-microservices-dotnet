using GeekShopping.ProductAPI.Data.ValueObjects;
using GeekShopping.ProductAPI.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.ProductAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductVO>>> Get()
        {
            var produtos = await _repository.FindAll();
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductVO>> GetById(long id)
        {
            var produto = await _repository.FindById(id);
            if (produto.Id <= 0) return NotFound();

            return Ok(produto);
        }

        [HttpPost]
        public async Task<ActionResult<ProductVO>> Create([FromBody] ProductVO productvo)
        {
            if (productvo == null) return BadRequest();
            var produto = await _repository.Create(productvo);

            return Ok(produto);
        }

        [HttpPut]
        public async Task<ActionResult<ProductVO>> Update([FromBody] ProductVO productvo)
        {
            if (productvo == null) return BadRequest();
            var produto = await _repository.Update(productvo);

            return Ok(produto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var status = await _repository.DeleteById(id);
            if (!status) return BadRequest();

            return Ok(status);
        }
    }
}

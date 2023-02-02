namespace SimpleShopApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> ProductsAsync()
        {
            return Ok(await _service.ProductsGetAllAsync());
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductDto>> ProductGetByIdAsync([FromRoute] int id)
        {
            return Ok(await _service.ProductGetByIdAsync(id));
        }
        [HttpGet("{name}")]
        public async Task<ActionResult<ProductDto>> ProductGetByNameAsync([FromRoute] string name)
        {
            return Ok(await _service.ProductGetByNameAsync(name));
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<ProductDto>>> ProductsCreate([FromBody] IEnumerable<ProductAddDto> dtos)
        {
            return Ok(await _service.ProductsCreateAsync(dtos));
        }

        [HttpPut]
        public async Task<ActionResult<IEnumerable<ProductDto>>> ProductsUpdata([FromBody] IEnumerable<ProductUpdataDto> dtos)
        {
            return Ok(await _service.ProductsUpdataAsync(dtos));
        }

        [HttpDelete]
        public async Task<ActionResult<IEnumerable<string>>> ProductsDelte([FromBody] IEnumerable<string> names)
        {
            await _service.ProductsDeleteAsync(names);
            return Ok();
        }
    }
}

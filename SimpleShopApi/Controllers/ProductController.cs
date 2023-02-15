namespace SimpleShopApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<ProductDto>>> ProductsAsync()
        {
            return Ok(await _service.ProductsGetAllAsync());
        }
        [HttpGet("{id:int}")]
        [AllowAnonymous]
        public async Task<ActionResult<ProductDto>> ProductGetByIdAsync([FromRoute] int id)
        {
            return Ok(await _service.ProductGetByIdAsync(id));
        }
        [HttpGet("{name}")]
        [AllowAnonymous]
        public async Task<ActionResult<ProductDto>> ProductGetByNameAsync([FromRoute] string name)
        {
            return Ok(await _service.ProductGetByNameAsync(name));
        }

        [HttpPost]
        [Authorize(Roles = "admin,manager")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> ProductsCreate([FromBody] IEnumerable<ProductAddDto> dtos)
        {
            return Ok(await _service.ProductsCreateAsync(dtos));
        }

        [HttpPut]
        [Authorize(Roles = "admin,manager")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> ProductsUpdata([FromBody] IEnumerable<ProductUpdataDto> dtos)
        {
            return Ok(await _service.ProductsUpdataAsync(dtos));
        }

        [HttpDelete]
        [Authorize(Roles = "admin,manager")]
        public async Task<ActionResult<IEnumerable<string>>> ProductsDelte([FromBody] IEnumerable<string> names)
        {
            await _service.ProductsDeleteAsync(names);
            return Ok();
        }
    }
}


namespace SimpleShopApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _service;
        private readonly ProductsDbContext _dbContext;
        public AccountController(IAccountService service, ProductsDbContext dbContext)
        {
            _service = service;
            _dbContext = dbContext;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult> UserRegister(UserRegisterDto registerDto)
        {
            var userDto = await _service.UserRegisterAsync(registerDto);

            return Ok("User register account complete successfully.");
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> UserGetALL()
        {
            var list = await _service.UsersAsync();

            return Ok(list);
        }

        //USER ROLE SECTION FOR CODEING PORPOSE 
        [HttpGet]
        [Route("UsersRole")]
        public ActionResult<List<UserRole>> UsersRoleGet()
        {
            var list = _dbContext.UsersRoles.ToList();

            return Ok(list);
        }
    }
}
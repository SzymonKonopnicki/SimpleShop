namespace SimpleShopApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _service;
        private readonly ProductsDbContext _dbContext;
        public AccountController(IAccountService service, ProductsDbContext dbContext)
        {
            _service = service;
            _dbContext = dbContext;
        }

        [HttpGet]
        [Authorize(Roles = "admin,manager")]
        //[AllowAnonymous]
        public async Task<ActionResult<List<User>>> UserGetALL()
        {
            var list = await _service.UsersAsync();

            return Ok(list);
        }

        [HttpPost]
        [Route("Register")]
        [AllowAnonymous]
        public async Task<ActionResult> UserRegister([FromBody]UserRegisterDto registerDto)
        {
            var userDto = await _service.UserRegisterAsync(registerDto);

            return Ok("User register account complete successfully.");
        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public ActionResult UserLoging([FromBody]UserLoginDto loginDto)
        {
            string token =  _service.GenerateJwt(loginDto);

            return Ok(token);
        }

        [HttpGet]
        [Route("UsersRole")]
        [Authorize(Roles = "admin")]
        public ActionResult<List<UserRole>> UsersRoleGet()
        {
            var list = _dbContext.UsersRoles.ToList();

            return Ok(list);
        }
    }
}
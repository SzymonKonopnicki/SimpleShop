
namespace SimpleShopApi.Services
{
    public class AccoundService : IAccountService
    {
        private readonly ProductsDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<AccoundService> _logger;
        private readonly IPasswordHasher<User> _hasher;
        private readonly AuthenticationSettings _autenticationSettings;

        public AccoundService(ProductsDbContext dbContext, IMapper mapper, ILogger<AccoundService> logger, IPasswordHasher<User> hasger, AuthenticationSettings autenticationSettings)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
            _hasher = hasger;
            _autenticationSettings = autenticationSettings;
        }

        public async Task<UserDto> UserRegisterAsync(UserRegisterDto registerDto)
        {
            _logger.LogWarning("Initiation of changes in the database.");
            var user = new User();

            user = _mapper.Map<User>(registerDto);
            user.UserRoleId = 3;
            user.Password = _hasher.HashPassword(user, user.Password);

            _dbContext.Users.AddAsync(user);
            _dbContext.SaveChangesAsync();
            _logger.LogWarning("Changes saved in Db.");

            return _mapper.Map<UserDto>(user);
        }

        public string GenerateJwt(UserLoginDto loginDto)
        {
            var user = _dbContext.Users
                .Include(x => x.UserRole)
                .FirstOrDefault(x => x.Mail == loginDto.Mail);

            if (user is null)
                throw new BadRequestException("Invalid user name or password");

            var result = _hasher.VerifyHashedPassword(user, user.Password, loginDto.Password);

            if (result == PasswordVerificationResult.Failed)
                throw new BadRequestException("Invalid user name or password");

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.Role, user.UserRole.UserRoleName.ToString()),
                new Claim(ClaimTypes.Email, user.Mail)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_autenticationSettings.Key));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var exp = DateTime.Now.AddDays(_autenticationSettings.ExpireDays);

            var token = new JwtSecurityToken(
                _autenticationSettings.Issuer, 
                _autenticationSettings.Issuer, 
                claims, 
                expires: exp,
                signingCredentials: cred);

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }

        //USER ROLE SECTION FOR CODEING PORPOSE 
        public Task<List<User>> UsersAsync()
        {
            var users = _dbContext.Users
                .Include(x => x.UserRole)
                .ToListAsync();
            return users;
        }
    }
}

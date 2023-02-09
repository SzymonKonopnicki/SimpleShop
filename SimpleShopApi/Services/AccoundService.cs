using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace SimpleShopApi.Services
{
    public class AccoundService : IAccountService
    {
        private readonly ProductsDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<AccoundService> _logger;
        public AccoundService(ProductsDbContext dbContext, IMapper mapper, ILogger<AccoundService> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<UserDto> UserRegisterAsync(UserRegisterDto registerDto)
        {
            _logger.LogWarning("Initiation of changes in the database.");
            var user = new User();

            user = _mapper.Map<User>(registerDto);
            user.UserRoleId = 3; 

            _dbContext.Users.AddAsync(user);
            _dbContext.SaveChangesAsync();
            _logger.LogWarning("Changes saved in Db.");

            return _mapper.Map<UserDto>(user);
        }

        public Task<List<User>> UsersAsync()
        {
            var users = _dbContext.Users
                .Include(x => x.UserRole)
                .ToListAsync();
            return users;
        }
    }
}

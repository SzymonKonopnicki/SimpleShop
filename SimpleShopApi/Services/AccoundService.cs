using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SimpleShopApi.Entities;
using System.Collections.Generic;

namespace SimpleShopApi.Services
{
    public class AccoundService : IAccountService
    {
        private readonly ProductsDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<AccoundService> _logger;
        private readonly IPasswordHasher<User> _hasher;

        public AccoundService(ProductsDbContext dbContext, IMapper mapper, ILogger<AccoundService> logger, IPasswordHasher<User> hasger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
            _hasher = hasger;
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

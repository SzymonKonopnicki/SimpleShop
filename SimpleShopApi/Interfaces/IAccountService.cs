using SimpleShopApi.Entities;

namespace SimpleShopApi.Interfaces
{
    public interface IAccountService
    {
        public Task<UserDto> UserRegisterAsync(UserRegisterDto registerDto);
        public Task<List<User>> UsersAsync();
    }
}
using SimpleShopApi.Entities;

namespace SimpleShopApi.Interfaces
{
    public interface IAccountService
    {
        Task<string> GenerateJwt(UserLoginDto loginDto);
        public Task<UserDto> UserRegisterAsync(UserRegisterDto registerDto);
        public Task<List<User>> UsersAsync();
    }
}

namespace SimpleShopApi.Interfaces
{
    public interface IAccountService
    {
        string GenerateJwt(UserLoginDto loginDto);
        public Task<UserDto> UserRegisterAsync(UserRegisterDto registerDto);
        public Task<List<User>> UsersAsync();
    }
}
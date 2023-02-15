
namespace SimpleShopApi.Models.ModelsDto
{
    public class UserRegisterDto
    {
        public string? LastName { get; set; }

        public string? FirstName { get; set; }

        public string Mail { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

    }
}

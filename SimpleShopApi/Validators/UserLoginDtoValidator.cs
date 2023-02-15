
namespace SimpleShopApi.Validators
{
    public class UserLoginDtoValidator : AbstractValidator<UserLoginDto>
    {
        private readonly ProductsDbContext _dbContext;

        public UserLoginDtoValidator(ProductsDbContext dbContext)
        {
            _dbContext = dbContext;

            RuleFor(x => x.Mail)
                .EmailAddress()
                .NotEmpty();

            RuleFor(x => x.Password)
                .NotEmpty();
        }
    }
}

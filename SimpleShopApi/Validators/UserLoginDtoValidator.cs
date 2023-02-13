using SimpleShopApi.Entities;

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
                .NotEmpty()
                .Custom((value, context) =>
                {
                    var dbValue = _dbContext
                        .Users
                        .Any(x => x.Mail == value);
                    if (!dbValue)
                        context.AddFailure("Invalid data.");
                });

            RuleFor(x => x.Password)
                .NotEmpty();
        }
    }
}


namespace SimpleShopApi.Validators
{
    public class UserRegisterDtoValidator : AbstractValidator<UserRegisterDto>
    {
        private readonly ProductsDbContext _dbContext;
        public UserRegisterDtoValidator(ProductsDbContext dbContext)
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
                    if (dbValue)
                        context.AddFailure("Invalid data.");
                });

            RuleFor(x => x.Password)
                .MinimumLength(7)
                .NotEmpty();

            RuleFor(x => x.ConfirmPassword)
                .MinimumLength(7)
                .NotEmpty()
                .Equal(x => x.Password);
        }
    }
}

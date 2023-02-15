
namespace SimpleShopApi
{
    public class DataSeeder
    {
        private readonly ProductsDbContext _dbContext;
        public DataSeeder(ProductsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seeds()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.UsersRoles.Any())
                {
                    SeedUserRoles();
                }
            }
        }

        private void SeedUserRoles()
        {
            List<UserRole> userRoles = new List<UserRole>()
            {
                new UserRole
                {
                     UserRoleName = "admin",
                },
                new UserRole
                {
                    UserRoleName = "manager",
                },
                new UserRole
                {
                    UserRoleName = "user",
                },
            };

            _dbContext.UsersRoles.AddRange(userRoles);
            _dbContext.SaveChanges();
        }
    }
}

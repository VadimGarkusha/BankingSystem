namespace BankingSystem.DAL.Users
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApiContext context) : base(context)
        {
        }
    }
}

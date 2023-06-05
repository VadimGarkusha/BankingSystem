using BankingSystem.Data;

namespace BankingSystem.Features.Users.Data
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApiContext context) : base(context)
        {
        }
    }
}

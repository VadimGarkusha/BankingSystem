using BankingSystem.Data;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.Features.Accounts.Data
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        public AccountRepository(ApiContext context) : base(context)
        {
        }

        public async Task<Account> Create(Account account)
        {
            var res = await dbSet.AddAsync(account);

            return res.Entity;
        }

        public void Update(Account account)
        {
            dbSet.Attach(account);
        }
    }
}

using BankingSystem.Data;

namespace BankingSystem.Features.Accounts.Data
{
    public interface IAccountRepository : IGenericRepository<Account>
    {
        public Task<Account> Create(Account account);
        void Update(Account account);
    }
}

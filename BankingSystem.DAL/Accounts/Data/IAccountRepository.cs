namespace BankingSystem.DAL.Accounts
{
    public interface IAccountRepository : IGenericRepository<Account>
    {
        public Task<Account> Create(Account account);
        void Update(Account account);
    }
}

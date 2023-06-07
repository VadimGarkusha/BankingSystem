namespace BankingSystem.DAL.AccountTransactions
{
    public class AccountTransactionRepository : GenericRepository<AccountTransaction>, IAccountTransactionRepository
    {
        public AccountTransactionRepository(ApiContext context) : base(context)
        {
        }

        public async Task<AccountTransaction> Create(AccountTransaction accountTransaction)
        {
            var res = await dbSet.AddAsync(accountTransaction);

            return res.Entity;
        }
    }
}

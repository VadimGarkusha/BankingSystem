namespace BankingSystem.DAL.AccountTransactions
{
    public interface IAccountTransactionRepository
    {
        Task<AccountTransaction> Create(AccountTransaction accountTransaction);
    }
}
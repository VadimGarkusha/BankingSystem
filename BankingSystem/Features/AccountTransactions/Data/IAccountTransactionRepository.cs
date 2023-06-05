namespace BankingSystem.Features.AccountTransactions.Data
{
    public interface IAccountTransactionRepository
    {
        Task<AccountTransaction> Create(AccountTransaction accountTransaction);
    }
}
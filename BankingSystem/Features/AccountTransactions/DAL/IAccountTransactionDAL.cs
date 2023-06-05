using BankingSystem.Features.AccountTransactions.Data;

namespace BankingSystem.Features.AccountTransactions.DAL
{
    public interface IAccountTransactionDAL
    {
        Task<AccountTransaction> CreateAccountTransaction(int accountId, double amount);
    }
}
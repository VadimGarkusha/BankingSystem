namespace BankingSystem.DAL.AccountTransactions
{
    public interface IAccountTransactionDAL
    {
        Task<AccountTransaction> CreateAccountTransaction(int accountId, double amount);
    }
}
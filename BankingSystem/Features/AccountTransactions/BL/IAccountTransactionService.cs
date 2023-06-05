namespace BankingSystem.Features.AccountTransactions.BL
{
    public interface IAccountTransactionService
    {
        Task<AccountTransactionDTO?> ProcessTransaction(int accountId, double amount);
    }
}
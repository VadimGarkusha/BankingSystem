namespace BankingSystem.BL.AccountTransactions
{
    public interface IAccountTransactionService
    {
        Task<AccountTransactionDTO?> Deposit(int accountId, double amount);
        Task<AccountTransactionDTO?> Withdraw(int accountId, double amount);
    }
}
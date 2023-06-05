using BankingSystem.Features.Accounts.Data;

namespace BankingSystem.Features.Accounts.DAL
{
    public interface IAccountDAL
    {
        Task<Account> CreateAccount(int userId, double startingAmount, string accountName);
        Task Delete(int accountId);
        Task<Account> GetAccountById(int accountId);
        Task<List<Account>> GetAllAccounts();
    }
}
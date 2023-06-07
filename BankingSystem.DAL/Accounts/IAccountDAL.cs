namespace BankingSystem.DAL.Accounts
{
    public interface IAccountDAL
    {
        Task<Account> CreateAccount(int userId, double startingAmount, string accountName);
        Task Delete(int accountId);
        Task<Account> GetAccountById(int accountId);
        Task<List<Account>> GetAllAccounts();
    }
}
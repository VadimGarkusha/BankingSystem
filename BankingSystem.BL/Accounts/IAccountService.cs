namespace BankingSystem.BL.Accounts
{
    public interface IAccountService
    {
        public Task<AccountDTO?> CreateAccount(int userId, double startingAmount, string accountName);
        Task<bool> DeleteAccount(int accountId);
        Task<AccountDTO?> GetAccountById(int accountId);
        Task<List<AccountDTO>> GetAllAccounts();
    }
}
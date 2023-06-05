namespace BankingSystem.Features.Accounts.BL
{
    public interface IAccountService
    {
        public Task<AccountDTO?> CreateAccount(int userId, double startingAmount, string accountName);
        Task<bool> DeleteAccount(int accountId);
        Task<AccountDTO?> GetAccountById(int accountId);
        Task<List<AccountDTO>> GetAllAccounts();
    }
}
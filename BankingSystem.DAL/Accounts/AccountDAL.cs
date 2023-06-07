using BankingSystem.DAL.AccountTransactions;

namespace BankingSystem.DAL.Accounts
{
    public class AccountDAL : IAccountDAL
    {
        private readonly IUnitOfWork _unitOfWork;

        public AccountDAL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Account> CreateAccount(int userId, double startingAmount, string accountName)
        {
            var account = new Account()
            {
                Name = accountName,
                UserId = userId,
                CurrentAmount = startingAmount
            };

            var createdAccount = await _unitOfWork.AccountRepository.Create(account);

            var accountTransaction = new AccountTransaction
            {
                OriginalAmount = 0,
                FinalAmount = startingAmount,
                AccountId = createdAccount.Id,
            };

            await _unitOfWork.AccountTransactionRepository.Create(accountTransaction);

            await _unitOfWork.Save();

            return createdAccount;
        }

        public async Task Delete(int accountId)
        {
            var account = await _unitOfWork.AccountRepository.GetByID(accountId);

            var accountTransaction = new AccountTransaction
            {
                OriginalAmount = account.CurrentAmount,
                FinalAmount = 0,
                AccountId = accountId,
            };

            await _unitOfWork.AccountTransactionRepository.Create(accountTransaction);

            account.CurrentAmount = 0;
            account.IsDeleted = true;

            _unitOfWork.AccountRepository.Update(account);
            await _unitOfWork.Save();
        }

        public async Task<Account> GetAccountById(int accountId)
        {
            var result = await _unitOfWork.AccountRepository.GetByID(accountId);
            return result == null || result.IsDeleted ? null : result;
        }

        public async Task<List<Account>> GetAllAccounts()
        {
            var result = await _unitOfWork.AccountRepository.GetAll();

            return result.Where(a => !a.IsDeleted).ToList();
        }
    }
}

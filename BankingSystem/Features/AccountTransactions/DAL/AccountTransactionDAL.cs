using BankingSystem.Data;
using BankingSystem.Features.AccountTransactions.Data;

namespace BankingSystem.Features.AccountTransactions.DAL
{
    public class AccountTransactionDAL : IAccountTransactionDAL
    {
        IUnitOfWork _unitOfWork;
        public AccountTransactionDAL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<AccountTransaction> CreateAccountTransaction(int accountId, double amount)
        {
            var account = await _unitOfWork.AccountRepository.GetByID(accountId);

            if (account == null)
            {
                return null;
            }

            var newAmount = account.CurrentAmount + amount;

            var transaction = new AccountTransaction()
            {
                AccountId = accountId,
                OriginalAmount = account.CurrentAmount,
                FinalAmount = newAmount,
            };

            var createdTransaction = await _unitOfWork.AccountTransactionRepository.Create(transaction);

            account.CurrentAmount = newAmount;
            _unitOfWork.AccountRepository.Update(account);

            await _unitOfWork.Save();

            return createdTransaction;
        }
    }
}

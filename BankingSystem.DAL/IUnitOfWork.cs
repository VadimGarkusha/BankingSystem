using BankingSystem.DAL.Accounts;
using BankingSystem.DAL.AccountTransactions;
using BankingSystem.DAL.Users;

namespace BankingSystem.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        public IAccountRepository AccountRepository { get; }
        public IUserRepository UserRepository { get; }
        public IAccountTransactionRepository AccountTransactionRepository { get; }

        Task Save();
    }
}

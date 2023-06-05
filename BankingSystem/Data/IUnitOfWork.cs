using BankingSystem.Features.Accounts.Data;
using BankingSystem.Features.AccountTransactions.Data;
using BankingSystem.Features.Users.Data;

namespace BankingSystem.Data
{
    public interface IUnitOfWork : IDisposable
    {
        public IAccountRepository AccountRepository { get; }
        public IUserRepository UserRepository { get; }
        public IAccountTransactionRepository AccountTransactionRepository { get; }

        Task Save();
    }
}

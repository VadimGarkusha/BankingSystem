using BankingSystem.Features.Accounts.Data;
using BankingSystem.Features.AccountTransactions.Data;
using BankingSystem.Features.Users.Data;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BankingSystem.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApiContext _context;
        public IAccountRepository AccountRepository { get; }
        public IUserRepository UserRepository { get; }
        public IAccountTransactionRepository AccountTransactionRepository { get; }

        public UnitOfWork(ApiContext context, IAccountRepository accountRepository, IUserRepository userRepository,
            IAccountTransactionRepository accountTransactionRepository)
        {
            AccountRepository = accountRepository;
            UserRepository = userRepository;
            AccountTransactionRepository = accountTransactionRepository;
            _context = context;
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        private bool disposed = false;

        public void Dispose()
        {
            if (!disposed)
            {
                _context.Dispose();
            }
            disposed = true;
        }
    }
}

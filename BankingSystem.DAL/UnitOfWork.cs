using BankingSystem.DAL.Accounts;
using BankingSystem.DAL.AccountTransactions;
using BankingSystem.DAL.Users;
using System.Data;

namespace BankingSystem.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApiContext _context;

        private IAccountRepository _accountRepository;
        private IUserRepository _userRepository;
        private IAccountTransactionRepository _accountTransactionRepository;

        public IAccountRepository AccountRepository
        {
            get
            {
                if(_accountRepository == null)
                    _accountRepository = new AccountRepository(_context);

                return _accountRepository;
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                if(_userRepository == null)
                    _userRepository = new UserRepository(_context);

                return _userRepository;
            }
        }

        public IAccountTransactionRepository AccountTransactionRepository
        {
            get
            {
                if(_accountTransactionRepository == null)
                    _accountTransactionRepository = new AccountTransactionRepository(_context);

                return _accountTransactionRepository;
            }
        }

        public UnitOfWork()
        {
            _context = new ApiContext(); 
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

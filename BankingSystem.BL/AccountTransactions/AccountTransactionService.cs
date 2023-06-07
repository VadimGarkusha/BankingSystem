using AutoMapper;
using BankingSystem.BL.Accounts;
using BankingSystem.DAL.Accounts;
using BankingSystem.DAL.AccountTransactions;

namespace BankingSystem.BL.AccountTransactions
{
    public class AccountTransactionService : IAccountTransactionService
    {
        private readonly IAccountTransactionDAL _accountTransactionDAL;
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public AccountTransactionService(IAccountTransactionDAL accountTransactionDAL, IAccountService accountService, IMapper mapper)
        {
            _accountTransactionDAL = accountTransactionDAL;
            _accountService = accountService;
            _mapper = mapper;
        }

        public async Task<AccountTransactionDTO?> Deposit(int accountId, double amount)
        {
            var account = await _accountService.GetAccountById(accountId);

            if (account == null)
            {
                return null;
            }

            var result = await _accountTransactionDAL.CreateAccountTransaction(accountId, amount);

            return _mapper.Map<AccountTransactionDTO>(result);
        }

        public async Task<AccountTransactionDTO?> Withdraw(int accountId, double amount)
        {
            var account = await _accountService.GetAccountById(accountId);

            if (account == null)
            {
                return null;
            }

            var negativeAmount = amount;

            var result = await _accountTransactionDAL.CreateAccountTransaction(accountId, negativeAmount);

            return _mapper.Map<AccountTransactionDTO>(result);
        }
    }
}

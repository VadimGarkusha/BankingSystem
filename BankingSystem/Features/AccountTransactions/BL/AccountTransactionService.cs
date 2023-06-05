using AutoMapper;
using BankingSystem.Features.Accounts.BL;
using BankingSystem.Features.AccountTransactions.DAL;

namespace BankingSystem.Features.AccountTransactions.BL
{
    public class AccountTransactionService : IAccountTransactionService
    {
        private IAccountTransactionDAL _accountTransactionDAL;
        private IAccountService _accountService;
        private IMapper _mapper;

        public AccountTransactionService(IAccountTransactionDAL accountTransactionDAL, IAccountService accountService, IMapper mapper)
        {
            _accountTransactionDAL = accountTransactionDAL;
            _accountService = accountService;
            _mapper = mapper;
        }

        public async Task<AccountTransactionDTO?> ProcessTransaction(int accountId, double amount)
        {
            var account = await _accountService.GetAccountById(accountId);

            if (account == null)
            {
                return null;
            }

            var result = await _accountTransactionDAL.CreateAccountTransaction(accountId, amount);

            return _mapper.Map<AccountTransactionDTO>(result);
        }
    }
}

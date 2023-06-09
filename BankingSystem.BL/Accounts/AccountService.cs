﻿using AutoMapper;
using BankingSystem.BL.Users;
using BankingSystem.DAL.Accounts;

namespace BankingSystem.BL.Accounts
{
    public class AccountService : IAccountService
    {
        private readonly IAccountDAL _accountDAL;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public AccountService(IAccountDAL accountDAL, IUserService userService, IMapper mapper)
        {
            _accountDAL = accountDAL;
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<AccountDTO?> CreateAccount(int userId, double startingAmount, string accountName)
        {
            var user = await _userService.GetUserById(userId);

            if (user == null)
            {
                return null;
            }

            var createdAccount = await _accountDAL.CreateAccount(userId, startingAmount, accountName);

            return _mapper.Map<AccountDTO>(createdAccount);
        }

        public async Task<bool> DeleteAccount(int accountId)
        {
            var account = await _accountDAL.GetAccountById(accountId);

            if (account == null)
            {
                return false;
            }

            await _accountDAL.Delete(accountId);

            return true;
        }

        public async Task<AccountDTO?> GetAccountById(int accountId)
        {
            var result = await _accountDAL.GetAccountById(accountId);
            return _mapper.Map<AccountDTO>(result);
        }

        public async Task<List<AccountDTO>> GetAllAccounts()
        {
            var accounts = await _accountDAL.GetAllAccounts();

            return accounts.Select(a => _mapper.Map<AccountDTO>(a)).ToList();
        }
    }
}

using AutoMapper;
using BankingSystem.Features.Accounts.BL;
using BankingSystem.Features.Accounts.Data;
using BankingSystem.Features.AccountTransactions;
using BankingSystem.Features.AccountTransactions.Data;
using BankingSystem.Features.Users.BL;
using BankingSystem.Features.Users.Data;

namespace BankingSystem
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {            
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Account, AccountDTO>().ReverseMap();
            CreateMap<AccountTransaction, AccountTransactionDTO>().ReverseMap();
        }
    }
}

using AutoMapper;
using BankingSystem.BL.Accounts;
using BankingSystem.BL.AccountTransactions;
using BankingSystem.BL.Users;
using BankingSystem.DAL.Accounts;
using BankingSystem.DAL.AccountTransactions;
using BankingSystem.DAL.Users;

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

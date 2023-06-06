using AutoMapper;
using BankingSystem.BL.Accounts;
using BankingSystem.Common;
using BankingSystem.DAL;
using BankingSystem.DAL.Accounts;
using BankingSystem.DAL.AccountTransactions;
using BankingSystem.DAL.Users;
using FluentValidation;
using BankingSystem.BL.Users;
using BankingSystem.BL.AccountTransactions;
using BankingSystem.Accounts;
using BankingSystem.AccountTransactions;

namespace BankingSystem.Helpers
{
    public class ServiceDependecyHelper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddDbContext<ApiContext>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IAccountTransactionRepository, AccountTransactionRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IAccountDAL, AccountDAL>();
            services.AddTransient<IUserDAL, UserDAL>();
            services.AddTransient<IAccountTransactionDAL, AccountTransactionDAL>();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAccountTransactionService, AccountTransactionService>();

            services.AddTransient<ITransactionLimitsProvider, TransactionLimitsProvider>();

            services.AddTransient<IValidator<CreateAccountRequest>, CreateAccountRequestValidator>();
            services.AddTransient<IValidator<DepositRequest>, DepositRequestValidator>();
            services.AddTransient<IValidator<WithdrawRequest>, WithdrawRequestValidator>();
        }
    }
}

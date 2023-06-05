using AutoMapper;
using BankingSystem.Common;
using BankingSystem.Data;
using BankingSystem.Features.Accounts;
using BankingSystem.Features.Accounts.BL;
using BankingSystem.Features.Accounts.DAL;
using BankingSystem.Features.Accounts.Data;
using BankingSystem.Features.AccountTransactions;
using BankingSystem.Features.AccountTransactions.BL;
using BankingSystem.Features.AccountTransactions.DAL;
using BankingSystem.Features.AccountTransactions.Data;
using BankingSystem.Features.Users.BL;
using BankingSystem.Features.Users.DAL;
using BankingSystem.Features.Users.Data;
using FluentValidation;

namespace BankingSystem.Helpers
{
    public class ServiceDependecyHelper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddDbContext<ApiContext>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IAccountTransactionRepository, AccountTransactionRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IAccountDAL, AccountDAL>();
            services.AddScoped<IUserDAL, UserDAL>();
            services.AddScoped<IAccountTransactionDAL, AccountTransactionDAL>();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAccountTransactionService, AccountTransactionService>();

            services.AddScoped<ITransactionLimitsProvider, TransactionLimitsProvider>();

            services.AddScoped<IValidator<CreateAccountRequest>, CreateAccountRequestValidator>();
            services.AddScoped<IValidator<DepositRequest>, DepositRequestValidator>();
            services.AddScoped<IValidator<WithdrawRequest>, WithdrawRequestValidator>();
        }
    }
}

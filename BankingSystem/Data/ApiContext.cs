using BankingSystem.Features.Accounts.Data;
using BankingSystem.Features.AccountTransactions.Data;
using BankingSystem.Features.Users.Data;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.Data
{
    public class ApiContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "BankingDB");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountTransaction> AccountTransactions { get; set; }
    }
}

using BankingSystem.DAL.Accounts;
using BankingSystem.DAL.AccountTransactions;
using BankingSystem.DAL.Users;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.DAL
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

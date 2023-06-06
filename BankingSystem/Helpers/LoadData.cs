using BankingSystem.DAL;
using BankingSystem.DAL.Accounts;
using BankingSystem.DAL.Users;
using System;

namespace BankingSystem.Helpers
{
    public class LoadData
    {
        public static void LoadInMemoryData(WebApplication app)
        {
            var scope = app.Services.CreateScope();
            var context = scope.ServiceProvider.GetService<ApiContext>();

            var users = new List<User>
            {
                new User
                {
                    Name = "John Smith",
                    Email = "jsmith@gmail.com",
                    Accounts = new List<Account>
                    {
                        new Account
                        {
                            Name = "Main Account",
                            CurrentAmount = 200,
                        },
                        new Account
                        {
                            Name = "Savings Account",
                            CurrentAmount = 200,
                        }
                    }
                },
                new User
                {
                    Name = "Vadym Harkusha",
                    Email = "vharkusha@gmail.com",
                    Accounts = new List<Account>
                    {
                        new Account
                        {
                            Name = "Checking Account",
                            CurrentAmount = 100,
                        }
                    }
                }
            };

            context.Users.AddRange(users);
            context.SaveChanges();
        }
    }
}

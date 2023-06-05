using BankingSystem.Data;
using BankingSystem.Features.Accounts.Data;

namespace BankingSystem.Features.Users.Data
{
    public class User
    {
        public User()
        {
            IsDeleted = false;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Account> Accounts { get; set; }
        public bool IsDeleted { get; set; }
    }
}

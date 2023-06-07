using BankingSystem.DAL.AccountTransactions;

namespace BankingSystem.DAL.Accounts
{
    public class Account
    {
        public Account()
        {
            IsDeleted = false;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public double CurrentAmount { get; set; }
        public int UserId { get; set; }
        public List<AccountTransaction> Transactions { get; set; }
        public bool IsDeleted { get; set; }
    }
}

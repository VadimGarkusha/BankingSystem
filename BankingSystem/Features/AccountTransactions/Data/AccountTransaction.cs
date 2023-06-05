using BankingSystem.Data;

namespace BankingSystem.Features.AccountTransactions.Data
{
    public class AccountTransaction
    {
        public AccountTransaction()
        {
            IsDeleted = false;
            PostedTimestamp = DateTime.UtcNow;
        }

        public int Id { get; set; }
        public int AccountId { get; set; }
        public DateTime PostedTimestamp { get; set; }
        public double OriginalAmount { get; set; }
        public double FinalAmount { get; set; }
        public bool IsDeleted { get; set; }
    }
}
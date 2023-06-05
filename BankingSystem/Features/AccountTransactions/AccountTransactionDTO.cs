namespace BankingSystem.Features.AccountTransactions
{
    public class AccountTransactionDTO
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public DateTime PostedTimestamp { get; set; }
        public double OriginalAmount { get; set; }
        public double FinalAmount { get; set; }
    }
}
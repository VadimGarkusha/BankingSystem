namespace BankingSystem.Features.AccountTransactions
{
    public class DepositRequest
    {
        public int AccountId { get; set; }
        public double Amount { get; set; }
    }
}

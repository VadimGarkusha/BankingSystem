namespace BankingSystem.Features.AccountTransactions
{
    public class WithdrawRequest
    {
        public int AccountId { get; set; }
        public double Amount { get; set; }
    }
}

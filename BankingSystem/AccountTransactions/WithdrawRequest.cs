namespace BankingSystem.AccountTransactions
{
    public class WithdrawRequest
    {
        public int AccountId { get; set; }
        public double Amount { get; set; }
    }
}
